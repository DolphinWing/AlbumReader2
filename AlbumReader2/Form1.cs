using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using dolphin.Util;
using System.Text.RegularExpressions;

namespace AlbumReader2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_d_thread_action("tsslStatus.Text", "initial");
			// initial
			cbAlbumType.SelectedIndex = 0;

			tbUserID.Text = "dolphinwing";

			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
			_d_thread_action("tbPhotoFolder.Text", folder);

			this.WindowState = FormWindowState.Maximized;
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			wbPreview.Width = this.Width - tcCtrlPanel.Width - 10;
		}

		#region + thread delegate .
		delegate void ThreadActionCallback(string id, object value);
		protected void _d_thread_action(string id, object value)
		{
			switch (id) {
				case "cbAlbumType.Items.Add":
					if (cbAlbumType.InvokeRequired) break;
					cbAlbumType.Items.Add(value);
					cbAlbumType.Update();
					return;

				// status bar
				case "tsslStatus.Text":
					Debug.WriteLine(System.Convert.ToString(value));
					//if (tsslStatus.InvokeRequired) break;
					tsslStatus.Text = System.Convert.ToString(value);
					//tsslStatus.Update();
					return;

				// album list
				case "lbAlbumList.Items.Add":
					if (lbAlbumList.InvokeRequired) break;
					lbAlbumList.Items.Add(value);
					lbAlbumList.Update();
					return;
				case "lbAlbumList.Items.Clear":
					if (lbAlbumList.InvokeRequired) break;
					lbAlbumList.Items.Clear();
					lbAlbumList.Update();
					return;

				// photo list
				case "lbPhotoList.Items.Add":
					if (lbPhotoList.InvokeRequired) break;
					lbPhotoList.Items.Add(value);
					lbPhotoList.Update();
					return;
				case "lbPhotoList.Items.Clear":
					if (lbPhotoList.InvokeRequired) break;
					lbPhotoList.Items.Clear();
					lbPhotoList.Update();
					return;

				// ctrl panel
				case "tcCtrlPanel.SelectTab":
					if (tcCtrlPanel.InvokeRequired) break;
					tcCtrlPanel.SelectTab(System.Convert.ToInt32(value));
					tcCtrlPanel.Update();
					return;

				// preview panel
				case "wbPreview.Navigate":
					if (wbPreview.InvokeRequired) break;
					wbPreview.Navigate(System.Convert.ToString(value));
					wbPreview.Update();
					return;

				// folder selection
				case "tbPhotoFolder.Text":
					if (tbPhotoFolder.InvokeRequired) break;
					tbPhotoFolder.Text = System.Convert.ToString(value);
					tbPhotoFolder.Update();
					return;

				// rename
				case "tbPhotoPrefix.Enabled":
					if (tbPhotoPrefix.InvokeRequired) break;
					tbPhotoPrefix.Enabled = System.Convert.ToBoolean(value);
					tbPhotoPrefix.Update();
					return;
				case "nudPhotoNumber.Enabled":
					if (nudPhotoNumber.InvokeRequired) break;
					nudPhotoNumber.Enabled = System.Convert.ToBoolean(value);
					nudPhotoNumber.Update();
					return;
				case "cbbPhotoExtension.Enabled":
					if (cbbPhotoExtension.InvokeRequired) break;
					cbbPhotoExtension.Enabled = System.Convert.ToBoolean(value);
					cbbPhotoExtension.Update();
					return;
				case "lPhotoNameExample.Text":
					if (lPhotoNameExample.InvokeRequired) break;
					lPhotoNameExample.Text = System.Convert.ToString(value);
					lPhotoNameExample.Update();
					return;

				default:
					break;
			}

			ThreadActionCallback d = new ThreadActionCallback(_d_thread_action);
			this.Invoke(d, new object[] { id, value });
		}
		protected void _d_messagebox_info(string msg, MessageBoxButtons btns, MessageBoxIcon icon)
		{
			MessageBox.Show(this, msg, null, btns, icon);
		}
		#endregion

		protected AlbumUtil m_auCurrConfig = null;

		private void btCheckUserID_Click(object sender, EventArgs e)
		{
			tbUserID.Text = tbUserID.Text.Trim();
			if (tbUserID.Text == "") return;//no user id

			DateTime dtStart = DateTime.Now;

			AlbumType type = AlbumUtil.ToAlbumType(cbAlbumType.SelectedIndex);
			m_auCurrConfig = new AlbumUtil(type, tbUserID.Text);
			// set ui
			_d_thread_action("lbAlbumList.Items.Clear", null);
			
			// get url data, attached to list
			// 1. get first page, parse and check if more pages
			string html = m_auCurrConfig.GetHTML(m_auCurrConfig.BaseUrl);
			m_auCurrConfig.AttachAlbumList(html);
			int tp = m_auCurrConfig.GetAlbumPage(html);
			_d_thread_action("tsslStatus.Text", "get first page");
			// 2. if more than one page, get the url and parse
			// 3. extra demand
			for (int p = 2; p <= tp; p++) {
				html = m_auCurrConfig.GetHTML(m_auCurrConfig.GetAlbumPageUrl(p));
				m_auCurrConfig.AttachAlbumList(html);

				// pixnet special vip
				#region for PIXNET folder (VIP) @ 2009-01-31      +
				if (m_auCurrConfig.Type == AlbumType.Pixnet) {
					//<span class="albDir"><span><img src="http://s.pixfs.net/f.pixnet.net/images/album/albDir.gif" alt="AlbDir" title="AlbDir" align="absmiddle" border="0" /></span></span>
					//<span class="albTitle"><a href="http://albertayu773.pixnet.net/album/folder/1547764">日本雜誌特集</a><span class="albNum">(4)</span>
					string strFolderUrlPattern = "albTitle[^<]*[^>]*album/(?<1>folder/[\\d]+)";
					MatchCollection mcFolderList = Regex.Matches(html, strFolderUrlPattern, RegexOptions.IgnoreCase);
					foreach (Match mf in mcFolderList) { // trace the folder
						string folderUrl = m_auCurrConfig.BaseUrl + mf.Groups[1].Captures[0].Value;
						string folderHTML = m_auCurrConfig.GetHTML(folderUrl);
						// get pages
						int folderPages = 1;
						//<li><a href="/album/folder/14191403/2"
						string folderPagePattern = "<li><a href=\"/album/folder";
						MatchCollection mcfp = Regex.Matches(folderHTML, folderPagePattern, RegexOptions.IgnoreCase);
						if (mcfp.Count > 1) { folderPages = mcfp.Count; }

						for (int fp = 1; fp <= folderPages; fp++) {
							string folderPageHTML = m_auCurrConfig.GetHTML(folderUrl + "/" + fp);
							// get albums
							m_auCurrConfig.AttachAlbumList(folderPageHTML);
						}
					}
				}
				#endregion

				_d_thread_action("tsslStatus.Text", "now page " + p + " is done");
			}

			// 4. insert to list
			foreach (string album in m_auCurrConfig.AlbumList) {
				_d_thread_action("lbAlbumList.Items.Add", album);
			}

			// get time split
			TimeSpan ts = DateTime.Now.Subtract(dtStart);
			_d_thread_action("tsslStatus.Text", ts.ToString());

			// navigate to next tab
			_d_thread_action("tcCtrlPanel.SelectTab", 1);
		}

		private void lbAlbumList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbAlbumList.SelectedItem == null) {
				return; // added @ 2008-05-01 by dolphin
			}

			_d_thread_action("lbPhotoList.Items.Clear", null);
			#region album id selected                      .
			// check the album
			string strAlbumIDPattern = @"\((?<1>[\w]*)";
			Match mAlbumID = Regex.Match(lbAlbumList.SelectedItem.ToString(), strAlbumIDPattern, RegexOptions.IgnoreCase);
			try {
				m_auCurrConfig.AlbumID = mAlbumID.Groups[1].Captures[0].Value;
			}
			catch { }
			#endregion
			#region Encripted Album, not yet implement     .
			if (lbAlbumList.SelectedItem.ToString().Contains(m_auCurrConfig.EncryptIcon)) {
				_d_messagebox_info("m_strNoEncriptedAlbumDownload", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			#endregion

			DateTime dtStart = DateTime.Now;

			string html = m_auCurrConfig.GetHTML(m_auCurrConfig.AlbumUrl);
			m_auCurrConfig.AttachPhotoList(html);
			int tp = m_auCurrConfig.GetPhotoPage(html);
			_d_thread_action("tsslStatus.Text", "get first page");
			// 2. if more than one page, get the url and parse
			// 3. extra demand
			for (int p = 2; p <= tp; p++) {
				html = m_auCurrConfig.GetHTML(m_auCurrConfig.GetPhotoPageUrl(p));
				m_auCurrConfig.AttachPhotoList(html);

				_d_thread_action("tsslStatus.Text", "now page " + p + " is done");
			}

			// 4. insert to list
			foreach (string photo in m_auCurrConfig.PhotoList) {
				_d_thread_action("lbPhotoList.Items.Add", photo);
			}

			// get time split
			TimeSpan ts = DateTime.Now.Subtract(dtStart);
			_d_thread_action("tsslStatus.Text", ts.ToString());

			// navigate to next tab
			_d_thread_action("tcCtrlPanel.SelectTab", 2);
		}

		string m_strPhotoMultiSelection = "";
		private void lbPhotoList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbPhotoList.SelectedItem == null) {
				return; // added @ 2008-05-01 by dolphin
			}

			string strSelectedPhotoID = lbPhotoList.SelectedItem.ToString();
			#region multiple photo selection     .
			// need to solve the multi-selection to show the file
			if (!cbPhotoSelectAll.Checked) {
				string m_strPhotoMultiSelectionTemp = ""; // temp list
				for (int s = 0; s < lbPhotoList.SelectedItems.Count; s++) { // check every selection
					string photoID = lbPhotoList.SelectedItems[s].ToString();
					photoID = photoID.Remove(photoID.IndexOf("["));
					m_strPhotoMultiSelectionTemp += photoID + ";";    // insert to the temp list
					if (!m_strPhotoMultiSelection.Contains(photoID)) { // check existancy
						// just selected
						strSelectedPhotoID = lbPhotoList.SelectedItem.ToString();//photoID;
					}
				}
				// assign the list for next selection
				m_strPhotoMultiSelection = m_strPhotoMultiSelectionTemp;
			}
			#endregion

			string previewID = strSelectedPhotoID.Substring(strSelectedPhotoID.IndexOf("[") + 1);
			previewID = previewID.Remove(previewID.Length - 1);
			_d_thread_action("wbPreview.Navigate", m_auCurrConfig.GetPhotoPreviewUrl(previewID));
		}

		private void cbPhotoSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			lbPhotoList.SelectionMode = (cbPhotoSelectAll.Checked) ? SelectionMode.One : SelectionMode.MultiSimple;
		}

		private void btPhotoFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbdDlg = new FolderBrowserDialog();
			fbdDlg.SelectedPath = tbPhotoFolder.Text;
			DialogResult dr = fbdDlg.ShowDialog();
			if (dr == DialogResult.OK) {
				_d_thread_action("tbPhotoFolder.Text", fbdDlg.SelectedPath);
			}
		}

		private void cbPhotoRename_CheckedChanged(object sender, EventArgs e)
		{
			_d_thread_action("tbPhotoPrefix.Enabled", cbPhotoRename.Checked);
			_d_thread_action("nudPhotoNumber.Enabled", cbPhotoRename.Checked);
			_d_thread_action("cbbPhotoExtension.Enabled", cbPhotoRename.Checked);
		}

		protected void set_example_photo_rename()
		{
			string estr = "ex: " + tbPhotoPrefix.Text;

			int num = System.Convert.ToInt32(nudPhotoNumber.Value);
			for (int x = 0; x < num; x++) {
				estr += "?";
			}
			//if (cbbPhotoExtension.SelectedItem != null)
			estr += cbbPhotoExtension.SelectedItem.ToString();

			_d_thread_action("lPhotoNameExample.Text", estr);
		}

		private void tbPhotoPrefix_TextChanged(object sender, EventArgs e)
		{
			set_example_photo_rename();
		}

		private void nudPhotoNumber_ValueChanged(object sender, EventArgs e)
		{
			set_example_photo_rename();
		}

		private void cbbPhotoExtension_SelectedIndexChanged(object sender, EventArgs e)
		{
			set_example_photo_rename();
		}

		private void btDownloadStart_Click(object sender, EventArgs e)
		{
			// check the essential data
			if (cbPhotoRename.Checked && tbPhotoPrefix.Text.Trim() == "") {
				MessageBox.Show("m_strPhotoPrefixEmpty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			// check if photos to download
			if (!cbPhotoSelectAll.Checked && lbPhotoList.SelectedItems.Count <= 0) {
				MessageBox.Show("m_strSelectedPhotoEmpty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			// folder setup
			// ui setup
			// get photo list
			// download photos
		}

		private void btDownloadStop_Click(object sender, EventArgs e)
		{

		}
	}
}