namespace ExportData;

public class ExportedRecipeObject
{


public class RootObject
{
    public string source { get; set; }
    public string id { get; set; }
    public Pictures[] pictures { get; set; }
    public string description { get; set; }
    public object nutriScore { get; set; }
    public Servings servings { get; set; }
    public string shareUrl { get; set; }
    public string title { get; set; }
    public double rating { get; set; }
    public int ratingCount { get; set; }
    public string picture { get; set; }
    public bool sponsored { get; set; }
    public Brand brand { get; set; }
    public bool hasVideo { get; set; }
    public Ingredients[] ingredients { get; set; }
    public int cookingTime { get; set; }
    public int preparationTime { get; set; }
    public int restTime { get; set; }
    public int totalTime { get; set; }
    public RecipeSteps[] recipeSteps { get; set; }
    public bool recipeSeasons { get; set; }
    public string recipeDishTypes { get; set; }
    public string recipeDifficulty { get; set; }
}

public class Pictures
{
    public string id { get; set; }
    public string url { get; set; }
    public object credits { get; set; }
    public bool reportable { get; set; }
}

public class Servings
{
    public int count { get; set; }
    public string shortUnit { get; set; }
    public string unit { get; set; }
}

public class Brand
{
    public string id { get; set; }
    public string name { get; set; }
}

public class Ingredients
{
    public string id { get; set; }
    public string name { get; set; }
    public Items[] items { get; set; }
}

public class Items
{
    public double? quantity { get; set; }
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
    public object url { get; set; }
    public Brand1 brand { get; set; }
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

public class Brand1
{
    public string id { get; set; }
    public string name { get; set; }
}

public class RecipeSteps
{
    public string id { get; set; }
    public string text { get; set; }
    public object picture { get; set; }
    public Ingredients1[] ingredients { get; set; }
}

public class Ingredients1
{
    public double? quantity { get; set; }
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
    public object complement { get; set; }
    public Picture1 picture { get; set; }
    public object url { get; set; }
    public Brand2 brand { get; set; }
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

public class Picture1
{
    public string id { get; set; }
    public string url { get; set; }
    public object credits { get; set; }
    public bool reportable { get; set; }
}

public class Brand2
{
    public string id { get; set; }
    public string name { get; set; }
}


}