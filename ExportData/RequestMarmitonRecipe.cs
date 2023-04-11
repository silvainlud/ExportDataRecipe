using System.Net;
using Newtonsoft.Json;

namespace ExportData;

public class RequestMarmitonRecipe
{
	public static object GetRecipeData(RecipeListDataObject.Data data)
	{
		var request = (HttpWebRequest)WebRequest.Create($"https://api.unify.uno/mobile-app-v5/recipes/{data.id}?w=1080");
		// Get Response from the request and display in the console
		var response = (HttpWebResponse)request.GetResponse();
		// display the body in the console
		var stream = response.GetResponseStream();
		var reader = new StreamReader(stream);
		var rootObject = JsonConvert.DeserializeObject<RecipeDataObject.RootObject>(reader.ReadToEnd());

		return new
		{
			source = "marmiton",
			id = data.id,
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