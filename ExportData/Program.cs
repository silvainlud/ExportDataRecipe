// See https://aka.ms/new-console-template for more information

using System.Net;
using ExportData;
using ExportData.http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

Console.WriteLine("Hello, World!");

List<String> keywords = new List<string>() { "", "boeuf", "poulet", "tarte", "gateau", "soupe", "pates", "riz", "poisson", "saumon", "rapide", "facile", "cookeo", "thermomix", "épicée" };

// List<String> alreadyDone = new List<String>();

Console.WriteLine("--- Récupération des recettes ---");


List<RecipeListDataObject.Data> datas = new List<RecipeListDataObject.Data>();
// Récupération de toutes les recettes des keywords
foreach (string keyword in keywords)
{
	Console.WriteLine("\tRécupération des recettes pour le mot clé : " + keyword);
	RecipeListDataObject.RootObject root = await MarmitonApi.GetRecipesListFromKeyWork(keyword);
	List<String> alreadyDone = datas.Select(x => x.id).ToList();
	List<RecipeListDataObject.Data> datasToAdd = root.data.Where(x => !alreadyDone.Contains(x.id)).ToList();
	alreadyDone.AddRange(datasToAdd.Select(x => x.id));
	datas.AddRange(datasToAdd);
	Console.WriteLine("\t\tNombre de recettes récupérées : " + datasToAdd.Count);
}
Console.WriteLine("\tNombre total de recettes récupérées : " + datas.Count);

Console.WriteLine("--- Récupération des données des recettes ---");
Mutex mutex = new Mutex(false, "SaveInList");
SemaphoreSlim semaphore = new SemaphoreSlim(0, 6);
List<Object> exportedRecipes = new List<object>();

int countDone = 0;
ThreadPool.SetMaxThreads(1, 1);
List<Task<object>> threads = new List<Task<object>>();
// using (var countdownEvent = new CountdownEvent(datas.Count()))
// {


datas.ForEach(x =>
{
	var task = new Task<object>(() =>
	{
		object r;
		try
		{
			r = MarmitonApi.GetRecipeDetails(x);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return null;
		}

		mutex.WaitOne();
		countDone++;
		Console.WriteLine("\t\tNombre de recettes traitées : " + countDone + " / " + datas.Count);
		mutex.ReleaseMutex();
		return r;
	});
	task.Start();
	threads.Add(task);
	// ThreadPool.QueueUserWorkItem(_ =>
	// {
	//
	//
	// 	mutex.WaitOne();
	// 	var recipe = MarmitonApi.GetRecipeDetails(x);
	// 	exportedRecipes.Add(recipe);
	// 	countDone++;
	// 	Console.WriteLine("\t\tNombre de recettes traitées : " + countDone + " / " + datas.Count);
	// 	mutex.ReleaseMutex();
	// 	countdownEvent.Signal();
	// });
});
// countdownEvent.Wait();
// }

var b = (await Task.WhenAll(threads)).Where(x => x != null).ToList();
Console.WriteLine(b.Count());
File.WriteAllText("output.json", JsonConvert.SerializeObject(b));

//
//
// try
// {
//
// 	foreach (string keyword in keywords)
// 	{
//
// 		// Make Http Request for google.fr
// 		var request = (HttpWebRequest)WebRequest.Create($"https://api.unify.uno/mobile-app-v5/search?search={keyword}&sort=rating&limit=10000");
// 		// Get Response from the request and display in the console
// 		var response = (HttpWebResponse)request.GetResponse();
// 		Console.WriteLine(response.StatusCode);
// 		Console.WriteLine(response.Server);
// 		// display the body in the console
// 		var stream = response.GetResponseStream();
// 		var reader = new StreamReader(stream);
// 		// Console.WriteLine(reader.ReadToEnd());
//
// 		// Parse the response to a json RootObject
// 		var rootObject = JsonConvert.DeserializeObject<RecipeListDataObject.RootObject>(reader.ReadToEnd());
//
// 		int i = 0;
// 		foreach (RecipeListDataObject.Data data in rootObject.data)
// 		{
// 			i++;
// 			Console.WriteLine($"Done {keyword} {i}/{rootObject.data.Length}");
// 			if (alreadyDone.Contains(data.id))
// 			{
// 				continue;
// 			}
// 			alreadyDone.Add(data.id);
// 			try
// 			{
// 				exportedRecipes.Add(RequestMarmitonRecipe.GetRecipeData(data));
// 			}
// 			catch (Exception e)
// 			{
// 				Console.WriteLine(e);
// 			}
//
//
// 		}
//
// 		response.Close();
//
//
// 	}
// }
// catch (Exception e)
// {
// 	Console.WriteLine(e);
// }
//
// // Write in file output.json
// File.WriteAllText("output.json", JsonConvert.SerializeObject(exportedRecipes));