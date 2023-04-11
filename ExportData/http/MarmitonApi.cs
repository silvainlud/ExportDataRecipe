using System.Net;
using Newtonsoft.Json;

namespace ExportData.http;

public static class MarmitonApi
{
	public static Mutex mutex = new Mutex(false, "E520AE5C-5F93-491B-B32F-6E2EFFE214B2");
	public static async Task<RecipeListDataObject.RootObject> GetRecipesListFromKeyWork(string keyword)
	{
		var request = (HttpWebRequest)WebRequest.Create($"https://api.unify.uno/mobile-app-v5/search?search={keyword}&sort=rating&limit=10000");
		var response = await request.GetResponseAsync();
		var stream = response.GetResponseStream();
		var reader = new StreamReader(stream);
		return JsonConvert.DeserializeObject<RecipeListDataObject.RootObject>(reader.ReadToEnd());
	}

	public static object GetRecipeDetails(RecipeListDataObject.Data data)
	{
		
		var request = (HttpWebRequest)WebRequest.Create($"https://api.unify.uno/mobile-app-v5/recipes/{data.id}?w=1080");
		
		// Get Response from the request and display in the console
		var response =  request.GetResponse();
		
		// display the body in the console
		var stream = response.GetResponseStream();
		var reader = new StreamReader(stream);
		var rootObject = JsonConvert.DeserializeObject<RecipeDataObject.RootObject>(reader.ReadToEnd());

		return new
		{
			source = "marmiton",
			id = data.id,
			pictures = rootObject.data.pictures,
			description = rootObject.data.authorNotes,
			nutriScore = rootObject.data.nutriScore,
			servings = rootObject.data.servings,
			shareUrl = rootObject.data.shareUrl,
			title = data.title,
			rating = data.rating,
			ratingCount = data.ratingCount,
			picture = data.picture.url,
			sponsored = data.sponsored,
			brand = data.brand,
			hasVideo = data.hasVideo,
			ingredients = rootObject.data.ingredientGroups,
			cookingTime = rootObject.data.cookingTime,
			preparationTime = rootObject.data.preparationTime,
			restTime = rootObject.data.restTime,
			totalTime = rootObject.data.totalTime,
			recipeSteps = rootObject.data.steps,
			recipeSeasons = rootObject.data.isSeasonal,
			recipeDishTypes = rootObject.data.dishType,
			recipeDifficulty = rootObject.data.difficulty,
		};

	}
}