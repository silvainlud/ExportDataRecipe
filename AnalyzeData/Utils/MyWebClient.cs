using System.Net;

namespace ExportData.Utils;

public class MyWebClient :  WebClient 
{
	protected override WebRequest GetWebRequest(Uri address)
	{
		WebRequest lWebRequest = base.GetWebRequest(address);
		lWebRequest.Timeout = 3000;
		// ((HttpWebRequest)lWebRequest).ReadWriteTimeout = 2500;
		return lWebRequest;
	}
}