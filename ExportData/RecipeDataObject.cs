namespace ExportData;

public class RecipeDataObject
{
	public class RootObject
	{
		public string kind { get; set; }
		public Meta meta { get; set; }
		public Data data { get; set; }
	}

	public class Meta
	{
		public Ads ads { get; set; }
		public Screen screen { get; set; }
		public string apiVersion { get; set; }
	}

	public class Ads
	{
		public string target { get; set; }
		public string authorizedFormats { get; set; }
	}

	public class Screen
	{
		public Ad ad { get; set; }
		public Analytics analytics { get; set; }
	}

	public class Ad
	{
		public string content_id { get; set; }
		public int recipe_cooktime { get; set; }
		public string recipe_cost { get; set; }
		public string recipe_diets { get; set; }
		public string recipe_difficulty { get; set; }
		public int recipe_preptime { get; set; }
		public string recipe_selection { get; set; }
		public string recipe_type { get; set; }
		public object ops_id { get; set; }
		public string ops_brand { get; set; }
		public string ops_name { get; set; }
		public string ad_section { get; set; }
		public string ad_site { get; set; }
		public string ad_traffic { get; set; }
		public string content_class { get; set; }
		public double content_recipeRating { get; set; }
		public string content_subtype { get; set; }
		public string content_type { get; set; }
		public string env { get; set; }
		public bool login { get; set; }
		public object ops_tag { get; set; }
		public string page_brand { get; set; }
		public string page_product { get; set; }
		public string page_title { get; set; }
		public string recipe_ingredients { get; set; }
		public string recipe_utensils { get; set; }
		public string section { get; set; }
		public string site { get; set; }
		public string subsec_lvl3 { get; set; }
		public string subsec_lvl4 { get; set; }
		public string subsec_lvl5 { get; set; }
		public string subsection { get; set; }
		public string tag { get; set; }
		public string url { get; set; }
	}

	public class Analytics
	{
		public string content_id { get; set; }
		public int recipe_cooktime { get; set; }
		public string recipe_cost { get; set; }
		public string recipe_diets { get; set; }
		public string recipe_difficulty { get; set; }
		public int recipe_preptime { get; set; }
		public string recipe_type { get; set; }
		public string ops_brand { get; set; }
		public string ops_name { get; set; }
		public string content_recipeIngredientsIds { get; set; }
		public string content_recipeNutriscore { get; set; }
		public string content_ustensilsID { get; set; }
	}

	public class Data
	{
		public string id { get; set; }
		public Author author { get; set; }
		public Pictures[] pictures { get; set; }
		public int picturesCount { get; set; }
		public string title { get; set; }
		public string shareUrl { get; set; }
		public int cookingTime { get; set; }
		public int preparationTime { get; set; }
		public int restTime { get; set; }
		public double rating { get; set; }
		public int totalTime { get; set; }
		public int ratingCount { get; set; }
		public string cost { get; set; }
		public string difficulty { get; set; }
		public string dishType { get; set; }
		public string authorNotes { get; set; }
		public Steps[] steps { get; set; }
		public Servings servings { get; set; }
		public IngredientGroups[] ingredientGroups { get; set; }
		public Utensils[] utensils { get; set; }
		public bool isStepByStep { get; set; }
		public bool isSeasonal { get; set; }
		public string nutriScore { get; set; }
		public string ecoScore { get; set; }
		public Video video { get; set; }
		public TopReviews[] topReviews { get; set; }
		public bool sponsored { get; set; }
		public object bookCategories { get; set; }
		public object personalNotes { get; set; }
	}

	public class Author
	{
		public string id { get; set; }
		public string authorType { get; set; }
		public string name { get; set; }
		public object avatarUrl { get; set; }
	}

	public class Pictures
	{
		public string id { get; set; }
		public string url { get; set; }
		public object credits { get; set; }
		public bool reportable { get; set; }
	}

	public class Steps
	{
		public string id { get; set; }
		public string text { get; set; }
		public object picture { get; set; }
		public Ingredients[] ingredients { get; set; }
	}

	public class Ingredients
	{
		public float? quantity { get; set; }
		public Unit unit { get; set; }
		public Ingredient ingredient { get; set; }
	}

	public class Unit
	{
		public string id { get; set; }
		public ShortName shortName { get; set; }
		public Name name { get; set; }
	}

	public class ShortName
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Name
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Ingredient
	{
		public string id { get; set; }
		public string token { get; set; }
		public Name1 name { get; set; }
		public FullName fullName { get; set; }
		public object complement { get; set; }
		public Picture picture { get; set; }
		public string url { get; set; }
		public Brand brand { get; set; }
	}

	public class Name1
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class FullName
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Picture
	{
		public string id { get; set; }
		public string url { get; set; }
		public object credits { get; set; }
		public bool reportable { get; set; }
	}

	public class Brand
	{
		public string id { get; set; }
		public string name { get; set; }
	}

	public class Servings
	{
		public int count { get; set; }
		public string shortUnit { get; set; }
		public string unit { get; set; }
	}

	public class IngredientGroups
	{
		public string id { get; set; }
		public string name { get; set; }
		public Items[] items { get; set; }
	}

	public class Items
	{
		public float? quantity { get; set; }
		public Unit1 unit { get; set; }
		public Ingredient1 ingredient { get; set; }
	}

	public class Unit1
	{
		public string id { get; set; }
		public ShortName1 shortName { get; set; }
		public Name2 name { get; set; }
	}

	public class ShortName1
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Name2
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Ingredient1
	{
		public string id { get; set; }
		public string token { get; set; }
		public Name3 name { get; set; }
		public FullName1 fullName { get; set; }
		public Complement complement { get; set; }
		public Picture1 picture { get; set; }
		public string url { get; set; }
		public Brand1 brand { get; set; }
	}

	public class Name3
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class FullName1
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Complement
	{
		public string single { get; set; }
		public string plural { get; set; }
	}

	public class Picture1
	{
		public string id { get; set; }
		public string url { get; set; }
		public object credits { get; set; }
		public bool reportable { get; set; }
	}

	public class Brand1
	{
		public string id { get; set; }
		public string name { get; set; }
	}

	public class Utensils
	{
		public string id { get; set; }
		public float quantity { get; set; }
		public string name { get; set; }
		public Picture2 picture { get; set; }
		public Partnership partnership { get; set; }
	}

	public class Picture2
	{
		public string id { get; set; }
		public string url { get; set; }
		public object credits { get; set; }
		public bool reportable { get; set; }
	}

	public class Partnership
	{
		public string text { get; set; }
		public string strokeText { get; set; }
		public string url { get; set; }
		public Brand2 brand { get; set; }
	}

	public class Brand2
	{
		public string id { get; set; }
		public string name { get; set; }
	}

	public class Video
	{
		public string thumbnailUrl { get; set; }
		public string dailymotionId { get; set; }
		public string uploadDate { get; set; }
		public string title { get; set; }
		public string editor { get; set; }
		public string url { get; set; }
		public string adsParams { get; set; }
	}

	public class TopReviews
	{
		public string id { get; set; }
		public string content { get; set; }
		public Author1 author { get; set; }
		public string date { get; set; }
		public int rating { get; set; }
		public int likesCount { get; set; }
	}

	public class Author1
	{
		public string id { get; set; }
		public string authorType { get; set; }
		public string name { get; set; }
		public object avatarUrl { get; set; }
	}


}