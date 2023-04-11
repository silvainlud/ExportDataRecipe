// See https://aka.ms/new-console-template for more information

// Parse Json from file output.json

using ExportData;
using Newtonsoft.Json;

string json = File.ReadAllText("output.json");
List<ExportedRecipeObject.RootObject> recipes = JsonConvert.DeserializeObject<List<ExportedRecipeObject.RootObject>>(json);


if (File.Exists(LoadPicture.OutputDirectory))
{
	Directory.Delete(LoadPicture.OutputDirectory, true);
}
Directory.CreateDirectory(LoadPicture.OutputDirectory);


ThreadPool.SetMinThreads(8, 8);

List<Task<FinalRecipeObject>> threads = new List<Task<FinalRecipeObject>>();

Mutex mutex = new Mutex(false, "535E6817-1F47-4153-B5D3-C4469D9F91C3");
int countDone = 0;


List<FinalRecipeObject> results = new List<FinalRecipeObject>();

using (var countdownEvent = new CountdownEvent(recipes.Count))
{
	foreach (var recipe in recipes)
	{
		ThreadPool.QueueUserWorkItem(_ =>
		{
			FinalRecipeObject r;
			try
			{
				r = new FinalRecipeObject(recipe);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return;
			}

			mutex.WaitOne();
			countDone++;
			results.Add(r);
			Console.WriteLine("\t\tNombre de recettes traitées : " + countDone + " / " + recipes.Count);
			mutex.ReleaseMutex();

			countdownEvent.Signal();

		});	
	}

	countdownEvent.Wait();
}


// var b = (await Task.WhenAll(threads)).Where(x => x != null).ToList();
// Console.WriteLine(b.Count());
File.WriteAllText("output_final.json", JsonConvert.SerializeObject(recipes));