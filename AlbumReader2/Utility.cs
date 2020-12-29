using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace dolphin.Util
{
	class Utility
	{
		public static string GetURLContents(string url, System.Text.Encoding encoding)
		{
			WebProxy proxyObject = new WebProxy();

			try {
				HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(url);

				WebResponse MyWebResponse = MyRequest.GetResponse();

				Stream MyStream = MyWebResponse.GetResponseStream();
				StreamReader Reader = new StreamReader(MyStream, encoding);

				return Reader.ReadToEnd();
			}
			catch {
			}

			// error handle, return nothing
			return "";
		}

		// added @ 2008-05-14 by dolphin
		public static string GetURLContents(string url, string userID, string passwd, System.Text.Encoding encoding)
		{
			WebProxy proxyObject = new WebProxy();

			try {
				HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(url);
				MyRequest.Credentials = new NetworkCredential(userID, passwd);

				WebResponse MyWebResponse = MyRequest.GetResponse();

				Stream MyStream = MyWebResponse.GetResponseStream();
				StreamReader Reader = new StreamReader(MyStream, encoding);

				return Reader.ReadToEnd();
			}
			catch {
			}

			// error handle, return nothing
			return "";
		}

		public static string RemoveHTMLTags(string HtmlContents)
		{
			Regex regularExpression = new Regex("<[^>]*>");
			HtmlContents = regularExpression.Replace(HtmlContents, "");

			return HtmlContents;
		}

		//public static string AppSettings(string key)
		//{
		//    try {
		//        return System.Configuration.ConfigurationSettings.AppSettings[key];
		//    }
		//    catch { }

		//    return "";
		//}
	}
}
