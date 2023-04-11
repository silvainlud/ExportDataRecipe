namespace ExportData;

public class RecipeListDataObject
{
	public record RootObject(
		string kind,
		Meta meta,
		Data[] data
	);

	public record Meta(
		Ads ads,
		Screen screen,
		int totalItems,
		int itemsPerPage,
		string apiVersion
	);

	public record Ads(
		string target,
		string authorizedFormats
	);

	public record Screen(
		Ad ad,
		Analytics analytics
	);

	public record Ad(
	);

	public record Analytics(
	);

	public record Data(
		string id,
		string title,
		double rating,
		int ratingCount,
		Picture picture,
		bool sponsored,
		object brand,
		bool hasVideo
	);

	public record Picture(
		string id,
		string url,
		string credits,
		bool reportable
	);


}