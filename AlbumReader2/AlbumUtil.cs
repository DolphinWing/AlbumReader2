using System;
using System.Collections.Generic;
using System.Text;

using dolphin.Util;
using System.Text.RegularExpressions;
using System.Collections;

namespace AlbumReader2
{
	public class AlbumUtil
	{
		//public AlbumUtil(int type, string userID)
		//{
		//    this(AlbumUtil.ToAlbumType(type), userID);
		//}
		public AlbumUtil(AlbumType type, string userID)
		{
			m_strUserID = userID;
			m_atType = type;
			m_alAlbumList = new ArrayList();
			m_alPhotoList = new ArrayList();

			switch (type) { 
				case AlbumType.Pixnet:
					m_strBaseUrl = "http://" + m_strUserID + ".pixnet.net/album/";
					// <a href="/album/2" class="page
					m_strAlbumPagePattern = "<a href=\"/album/[\\d]+\" class=\"page";
					// <span class="albInfo"><a href="#14210843"><span>
					// <img src="http://s.pixfs.net/f.pixnet.net/images/album/albInfo.gif" border="0" align="absmiddle" />
					// </span></a></span>
					//<span class="albPrivate"><span><img src="http://s.pixfs.net/f.pixnet.net/images/album/albPrivate.gif" alt="privateAlb" title="privateAlb" align="absmiddle" border="0" /></span></span>
					// <span class="albTitle">2008-11-01_逛淡水<span class="albNum">(6)
					m_strAlbumIdPattern = "<span class=\"albInfo\"><a href=\"#(?<1>[\\w]*)[^>]*>" +
						"<span[^<]*<img[^<]*</span[^<]*</a[^<]*</span[^<]*" +
						"(<span class=\"albPrivate(?<3>[^<]*)<span><img[^<]*</span[^<]*</span[^<]*)?" +
						//"<span class=\"albTitle\"[^>]*>(?<2>[^<]*)";// modified @ 2009-01-31 by dolphin
						"<span class=\"albTitle\"[^>]*><a[^>]*>(?<2>[^<]*)";

					// class="pageLast" title="..." >16</a>
					m_strPhotoPagePattern = "class=\"pageLast[^>]*>(?<1>[\\w]+)";
					
					//<a href="http://dolphinwing.pixnet.net/album/photo/108672085#pictop">
					//<img id="thumb108672085" src="http://p0.p.pixnet.net/albums/userpics/0/7/534207/thumb_49f7f243b3b5b.jpg" class="thumb" width="90" /></a><img src="//s.pixfs.net/f.pixnet.net/images/album/space.gif" class="thumbSpacer" />
					m_strPhotoIdPattern = "<a href=\"(?<2>[^\"]+)[^<]*<img [^>]*thumb_(?<1>[\\w]+).";

					m_strAlbumUrl = m_strBaseUrl + "set/@albumId";
					m_strPhotoRealBaseUrl = "";
					//http://dolphinwing.pixnet.net/album/photo/107205570#pictop
					m_strPhotoViewBaseUrl = m_strBaseUrl + "photo/@photoId#pictop";
					break;
				case AlbumType.Filckr:
					m_strBaseUrl = "http://api.flickr.com/services/rest/?api_key=" + m_strFlickrAPIKey + "&method=";
					m_bPublicAPI = true;
					break;
				case AlbumType.Wretch:
					m_strBaseUrl = "http://www.wretch.cc/album/";
					m_bReferred = true;
					break;
			}
		}

		//protected int m_nType = 0;
		protected AlbumType m_atType = AlbumType.Pixnet;
		protected System.Text.Encoding m_eCharset = System.Text.Encoding.UTF8;
		protected bool m_bReferred = false;
		protected bool m_bPublicAPI = false;
		protected string m_strUserID = "";
		protected string m_strBaseUrl = "";

		protected string m_strAlbumPagePattern = "";
		protected string m_strAlbumIdPattern = "";
		protected string m_strAlbumPageUrl = "";
		protected string m_strAlbumID = "";
		protected string m_strAlbumUrl = "";

		protected string m_strPhotoPagePattern = "";
		protected string m_strPhotoIdPattern = "";
		protected string m_strPhotoPageUrl = "";
		protected string m_strPhotoViewBaseUrl = "";
		protected string m_strPhotoRealBaseUrl = "";

		protected string m_strFlickrAPIKey = "9da26fc93cf988bea3079cda4a5bf2d0";
		protected string m_strEncryptedIcon = "(*)";

		public static AlbumType ToAlbumType(int type)
		{
			switch (type) {
				case 1: return AlbumType.Filckr;
				case 2: return AlbumType.Wretch;
				case 3: return AlbumType.PChome;
				case 4: return AlbumType.Xuite;
				case 5: return AlbumType.yam;
				case 0:
				default:
					return AlbumType.Pixnet;
			}
		}

		public int GetAlbumPage(string html)
		{
			int page = 0;

			//string html = Utility.GetURLContents(m_strBaseUrl, m_eCharset);
			MatchCollection mcPage = Regex.Matches(html, m_strAlbumPagePattern, RegexOptions.IgnoreCase);
			switch (m_atType) { 
				case AlbumType.Pixnet:
					// modified @ 2008-11-24 by dolphin, fix the count<=0
					//iPage = ((mcPage.Count - 1) <= 0) ? 1 : ((mcPage.Count - 1) / 2);
					// modified @ 2009-03-02 by dolphin, fix the count of Pixnet new style
					page = (mcPage.Count > 0) ? mcPage.Count / 2 : 1;
					// --//http://www.pixnet.net/home/dolphinwing/2
					// modified @ 2008-11-21 by dolphin, Pixnet updates the url format
					// http://dolphinwing.pixnet.net/album/2
					m_strAlbumPageUrl = m_strBaseUrl + "@page";
					break;
			}

			return page;
		}
		public int GetPhotoPage(string html)
		{
			int page = 0;
			MatchCollection mcPage = Regex.Matches(html, m_strPhotoPagePattern, RegexOptions.IgnoreCase);
			switch (m_atType) {
				case AlbumType.Pixnet:
					// modified @ 2008-11-21 by dolphin, Pixnet updates the url format
					//iPage = (mcPage.Count == 0) ? 1 : mcPage.Count / 2;
					try {
						page = System.Convert.ToInt32(mcPage[0].Groups[1].Captures[0].Value);
					}
					catch {
						page = 1;
					}
					//http://www.pixnet.net/album/dolphinwing/2007471/2
					// modified @ 2008-11-21 by dolphin, Pixnet updates the url format
					m_strPhotoPageUrl = m_strAlbumUrl + "/@page";
					break;
			}

			// get base photo url, photo may be saved at another server


			return page;
		}

		public string BaseUrl { get { return m_strBaseUrl; } }
		public string AlbumUrl { get { return m_strAlbumUrl; } }

		public System.Text.Encoding Charset { get { return m_eCharset; } }
		public string GetHTML(string url)
		{
			string html = Utility.GetURLContents(url, m_eCharset);
			return html;
		}
		public AlbumType Type { get { return m_atType; } }
		public string EncryptIcon { get { return m_strEncryptedIcon; } }
		public string AlbumID
		{
			get { return m_strAlbumID; }
			set 
			{
				m_alPhotoList = new ArrayList();//clear the old data
				m_strAlbumID = value;
				m_strAlbumUrl = m_strAlbumUrl.Replace("@albumId", m_strAlbumID);
				m_strPhotoViewBaseUrl = m_strPhotoViewBaseUrl.Replace("@albumId", m_strAlbumID);
			}
		}

		#region + album list
		//public string AlbumPageBaseUrl { get { return m_strAlbumPageUrl; } }
		public string GetAlbumPageUrl(int page)
		{
			string url = m_strAlbumPageUrl.Replace("@page", page.ToString());
			return url;
		}
		protected string GetAlbumPageHtml(int page)
		{
			string url = this.GetAlbumPageUrl(page);
			string html = Utility.GetURLContents(url, m_eCharset);
			return html;
		}
		protected ArrayList m_alAlbumList = new ArrayList();
		public string[] AlbumList
		{
			get {
				string[] strList = new string[m_alAlbumList.Count];
				for (int s = 0; s < m_alAlbumList.Count; s++) {
					strList[s] = m_alAlbumList[s].ToString();
				}
				return strList;
			}
		}
		public void AttachAlbumList(string srcHTML)
		{
			this.attach_to_album_list(srcHTML, m_strAlbumIdPattern);
		}
		protected void attach_to_album_list(string html, string pattern)
		{
			MatchCollection mcAlbumList = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);
			foreach (Match match in mcAlbumList) {
				string albumID = match.Groups[1].Captures[0].Value;
				string albumName = match.Groups[2].Captures[0].Value;
				string albumList = "(@id) @name";
				albumList = albumList.Replace("@id", albumID);
				albumName = albumName.Trim(); // added @ 2008-11-21 by dolphin
				#region encrypted, now only for Wretch and PChome, add Pixnet @ 2008-11-21
				// check if locked
				if (match.Groups[3] != null && match.Groups[3].Captures.Count > 0) {
					switch (m_atType) {
						case AlbumType.Wretch:
							albumName = (match.Groups[3].Captures[0].Value.Contains("key.gif")) ? m_strEncryptedIcon + albumName : albumName;
							break;
						case AlbumType.PChome:
							albumName = (match.Groups[3].Captures[0].Value.Contains("h_code.gif")) ? m_strEncryptedIcon + albumName : albumName;
							break;

						//add Pixnet @ 2008-11-21
						case AlbumType.Pixnet:
							albumName = m_strEncryptedIcon + albumName;
							break;
					}
				}
				#endregion
				// for flickr, added @ 2008-04-05
				if (match.Groups[4] != null && match.Groups[4].Captures.Count > 0) {
					albumList += " (" + match.Groups[4].Captures[0].Value + ")";
				}
				albumList = albumList.Replace("@name", albumName);
				m_alAlbumList.Add(albumList);
			}
		}

		#endregion
		#region + photo list
		public string GetPhotoPageUrl(int page)
		{
			string url = m_strPhotoPageUrl.Replace("@page", page.ToString());
			return url;
		}
		protected ArrayList m_alPhotoList = new ArrayList();
		public string[] PhotoList
		{
			get
			{
				string[] strList = new string[m_alPhotoList.Count];
				for (int s = 0; s < m_alPhotoList.Count; s++) {
					strList[s] = m_alPhotoList[s].ToString();
				}
				return strList;
			}
		}
		public void AttachPhotoList(string srcHTML)
		{
			this.attach_to_photo_list(srcHTML, m_strPhotoIdPattern);
		}
		protected void attach_to_photo_list(string html, string pattern)
		{
			// get photo list
			MatchCollection mcPhotoID = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);
			//FormStatus = "get photo list";
			try {
				foreach (Match match in mcPhotoID) {
					string photoID = match.Groups[1].Captures[0].Value;
					string pviewID = match.Groups[2].Captures[0].Value;
					//--------------------------------------
					// added @ 2008-04-02, check if this is a movie
					string pt = "./show.php?i=" + m_strUserID + "&b=" + m_strAlbumID + "&f=" + photoID;
					if (m_atType == AlbumType.Wretch && html.ToLower().Contains(pt)) {
						string strCheckHTML = html.Remove(html.ToLower().IndexOf(pt));
						strCheckHTML = strCheckHTML.Substring(strCheckHTML.LastIndexOf("<td"));
						if (strCheckHTML.Contains("v-1.gif")) {
							// this is a movie
							continue;
						}
					}
					//--------------------------------------
					// added for Flickr @ 2008-04-05 by dolphin
					if (m_atType == AlbumType.Filckr) {
						photoID += "_" + match.Groups[2].Captures[0].Value;
						photoID = match.Groups[3].Captures[0].Value + "/" + photoID;
					}

					pviewID = pviewID.Substring(pviewID.LastIndexOf("/") + 1);
					pviewID = pviewID.Remove(pviewID.IndexOf("#"));

					m_alPhotoList.Add(string.Format("{0}[{1}]", photoID, pviewID));
				}
			}
			catch { }
		}

		public string GetPhotoPreviewUrl(string photoID)
		{
			return m_strPhotoViewBaseUrl.Replace("@photoId", photoID);
		}
		#endregion
	}

	public enum AlbumType { Pixnet = 0, Filckr, Wretch, PChome, Xuite, yam, WindowsLive }

	public enum AlbumLanguage { zh_TW = 0, en_US }
}
