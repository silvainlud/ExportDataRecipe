using System.Net;
using ExportData.Utils;

namespace ExportData;

public class LoadPicture
{
	public const string OutputDirectory = "./output_images/";
	public const int width = 1920;
	public const int heigth = 1920;

	public static string LoadPictureFromUrl(string url)
	{
		url = url.Replace("[width]", "")
			.Replace("[height]", "");

		string extension = Path.GetExtension(url);
		string fileName = Guid.NewGuid() + extension;


		try
		{
			using (var client = new HttpClient())
			{


				Console.WriteLine("Download " + url);
				var httpResponseMessage = client.Send(new HttpRequestMessage(HttpMethod.Get, url));
				File.WriteAllText(OutputDirectory + fileName, httpResponseMessage.Content.ReadAsStringAsync().Result);
				Console.WriteLine("Downloaded " + fileName);
			}

		}
		catch (Exception e)
		{
			Console.WriteLine(url);
			Console.WriteLine(e);
			if (File.Exists(OutputDirectory + fileName))
			{
				File.Delete(OutputDirectory + fileName);
			}
			return null;
		}
		return fileName;
	}
}