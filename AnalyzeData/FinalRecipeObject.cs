namespace ExportData;

public class FinalRecipeObject
{
	public string? ReferenceIdentifier { get; set; } = null;
	public string Name { get; set; }
	public string Source { get; set; }
	public string Description { get; set; }
	public double Rating { get; set; }
	public int RatingCOunt { get; set; }
	public int CookingTime { get; set; }
	public int PreparationTime { get; set; }
	public int RestTime { get; set; }
	public int TotalTime { get; set; }
	public string RecipeDishTypes { get; set; }
	public string RecipeDifficulty { get; set; }

	public string? MainPictures { get; set; } = null;
	public List<string> Pictures { get; set; } = new List<string>();
	public List<FinalIngredient> Ingredients { get; set; } = new List<FinalIngredient>();
	public List<FinalStep> Steps { get; set; } = new List<FinalStep>();
	public string? NutriScore { get; set; } = null;
	public string? Url { get; set; } = null;
	public int ServingCount { get; set; } = 1;
	public string? ServingName { get; set; } = "personne";

	public FinalRecipeObject(ExportedRecipeObject.RootObject recipe)
	{
		ReferenceIdentifier = recipe.id;
		Name = recipe.title;
		Source = recipe.source;
		Description = recipe.description;

		if (recipe.nutriScore is string)
		{
			NutriScore = recipe.nutriScore.ToString();
		}

		Url = recipe.shareUrl;
		if (recipe.servings != null)
		{
			ServingCount = recipe.servings.count;
			ServingName = recipe.servings.unit;
		}
		Rating = recipe.rating;
		RatingCOunt = recipe.ratingCount;
		CookingTime = recipe.cookingTime;
		PreparationTime = recipe.preparationTime;
		RestTime = recipe.restTime;
		TotalTime = recipe.totalTime;
		RecipeDishTypes = recipe.recipeDishTypes;
		RecipeDifficulty = recipe.recipeDifficulty;
		if (!String.IsNullOrEmpty(recipe.picture))
		{
			String filename = LoadPicture.LoadPictureFromUrl(recipe.picture);
			Pictures.Add(filename);
			MainPictures = filename;
		}
		Console.WriteLine("coucou");
		Pictures.AddRange(recipe.pictures.Select(x => LoadPicture.LoadPictureFromUrl(x.url)));
		foreach (var ingredient in recipe.ingredients)
		{
			foreach (var item in ingredient.items)
			{
				Ingredients.Add(new FinalIngredient(item));
			}
		}

		Ingredients = recipe.ingredients
			.SelectMany(x => x.items)
			.Select(x => new FinalIngredient(x))
			.ToList();

		Steps = recipe.recipeSteps
			.Select(x => new FinalStep(x))
			.ToList();

	}


	public class FinalIngredient
	{
		public string? ReferenceIdentifier { get; set; } = null;
		public string Name { get; set; }
		public double? Quantity { get; set; } = null;
		public string? Unit { get; set; } = null;
		public string? Picture { get; set; } = null;

		public FinalIngredient(ExportedRecipeObject.Items ingredient)
		{
			ReferenceIdentifier = ingredient.ingredient.id;
			Name = ingredient.ingredient.name.plural;
			Quantity = ingredient.quantity;
			Unit = ingredient.unit?.name.plural;
			if (ingredient.ingredient.picture != null && String.IsNullOrEmpty(ingredient.ingredient.picture.url))
			{
				Picture = LoadPicture.LoadPictureFromUrl(ingredient.ingredient.picture.url);
			}
		}
	}

	public class FinalStep
	{
		public string Id { get; set; }
		public string StepDescription { get; set; }
		public List<FinalStepIngredient> Ingredients { get; set; } = new List<FinalStepIngredient>();

		public FinalStep(ExportedRecipeObject.RecipeSteps step)
		{
			Id = step.id;
			StepDescription = step.text;
			foreach (var ingredient in step.ingredients)
			{
				Ingredients.Add(new FinalStepIngredient
				{
					Quantity = ingredient.quantity,
					Unit = ingredient.unit?.name.plural,
					Name = ingredient.ingredient.name.plural,
					ReferenceIdentifier = ingredient.ingredient.id,
				});
			}
		}

	}

	public class FinalStepIngredient
	{
		public string? ReferenceIdentifier { get; set; } = null;
		public string Name { get; set; }
		public double? Quantity { get; set; } = null;
		public string? Unit { get; set; } = null;
		public FinalIngredient Ingredient { get; set; }
	}
}