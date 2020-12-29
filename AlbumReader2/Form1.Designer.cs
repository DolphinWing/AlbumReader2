namespace AlbumReader2
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
		///
		/// </summary>
		private void InitializeComponent()
		{
			this.ssFormStatus = new System.Windows.Forms.StatusStrip();
			this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.wbPreview = new System.Windows.Forms.WebBrowser();
			this.tcCtrlPanel = new System.Windows.Forms.FixedTabControl();
			this.tpUserID = new System.Windows.Forms.TabPage();
			this.btCheckUserID = new System.Windows.Forms.Button();
			this.tbUserID = new System.Windows.Forms.TextBox();
			this.cbAlbumType = new System.Windows.Forms.ComboBox();
			this.tpAlbumList = new System.Windows.Forms.TabPage();
			this.lTotalAlbums = new System.Windows.Forms.Label();
			this.lbAlbumList = new System.Windows.Forms.ListBox();
			this.tpPhotoList = new System.Windows.Forms.TabPage();
			this.lTotalPhotos = new System.Windows.Forms.Label();
			this.cbPhotoSelectAll = new System.Windows.Forms.CheckBox();
			this.lbPhotoList = new System.Windows.Forms.ListBox();
			this.tpFolder = new System.Windows.Forms.TabPage();
			this.btPhotoFolder = new System.Windows.Forms.Button();
			this.tbPhotoFolder = new System.Windows.Forms.TextBox();
			this.tpDownload = new System.Windows.Forms.TabPage();
			this.btDownloadStop = new System.Windows.Forms.Button();
			this.btDownloadStart = new System.Windows.Forms.Button();
			this.gbPhotoRename = new System.Windows.Forms.GroupBox();
			this.cbPhotoRename = new System.Windows.Forms.CheckBox();
			this.lPhotoExtension = new System.Windows.Forms.Label();
			this.lPhotoNumber = new System.Windows.Forms.Label();
			this.lPhotoNameExample = new System.Windows.Forms.Label();
			this.lPhotoPrefix = new System.Windows.Forms.Label();
			this.tbPhotoPrefix = new System.Windows.Forms.TextBox();
			this.cbbPhotoExtension = new System.Windows.Forms.ComboBox();
			this.nudPhotoNumber = new System.Windows.Forms.NumericUpDown();
			this.tpHelp = new System.Windows.Forms.TabPage();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.ssFormStatus.SuspendLayout();
			this.tcCtrlPanel.SuspendLayout();
			this.tpUserID.SuspendLayout();
			this.tpAlbumList.SuspendLayout();
			this.tpPhotoList.SuspendLayout();
			this.tpFolder.SuspendLayout();
			this.tpDownload.SuspendLayout();
			this.gbPhotoRename.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPhotoNumber)).BeginInit();
			this.tpHelp.SuspendLayout();
			this.SuspendLayout();
			// 
			// ssFormStatus
			// 
			this.ssFormStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgress,
            this.tsslStatus});
			this.ssFormStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.ssFormStatus.Location = new System.Drawing.Point(0, 296);
			this.ssFormStatus.Name = "ssFormStatus";
			this.ssFormStatus.Size = new System.Drawing.Size(341, 22);
			this.ssFormStatus.TabIndex = 1;
			this.ssFormStatus.Text = "statusStrip1";
			// 
			// tspbProgress
			// 
			this.tspbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tspbProgress.Name = "tspbProgress";
			this.tspbProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// tsslStatus
			// 
			this.tsslStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(59, 14);
			this.tsslStatus.Spring = true;
			this.tsslStatus.Text = "tsslStatus";
			// 
			// wbPreview
			// 
			this.wbPreview.Dock = System.Windows.Forms.DockStyle.Right;
			this.wbPreview.Location = new System.Drawing.Point(202, 0);
			this.wbPreview.MinimumSize = new System.Drawing.Size(20, 18);
			this.wbPreview.Name = "wbPreview";
			this.wbPreview.Size = new System.Drawing.Size(139, 296);
			this.wbPreview.TabIndex = 3;
			// 
			// tcCtrlPanel
			// 
			this.tcCtrlPanel.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tcCtrlPanel.Controls.Add(this.tpUserID);
			this.tcCtrlPanel.Controls.Add(this.tpAlbumList);
			this.tcCtrlPanel.Controls.Add(this.tpPhotoList);
			this.tcCtrlPanel.Controls.Add(this.tpFolder);
			this.tcCtrlPanel.Controls.Add(this.tpDownload);
			this.tcCtrlPanel.Controls.Add(this.tpHelp);
			this.tcCtrlPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.tcCtrlPanel.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.tcCtrlPanel.Location = new System.Drawing.Point(0, 0);
			this.tcCtrlPanel.Multiline = true;
			this.tcCtrlPanel.Name = "tcCtrlPanel";
			this.tcCtrlPanel.SelectedIndex = 0;
			this.tcCtrlPanel.Size = new System.Drawing.Size(200, 296);
			this.tcCtrlPanel.TabIndex = 2;
			// 
			// tpUserID
			// 
			this.tpUserID.BackColor = System.Drawing.Color.Transparent;
			this.tpUserID.Controls.Add(this.btCheckUserID);
			this.tpUserID.Controls.Add(this.tbUserID);
			this.tpUserID.Controls.Add(this.cbAlbumType);
			this.tpUserID.Location = new System.Drawing.Point(25, 4);
			this.tpUserID.Name = "tpUserID";
			this.tpUserID.Padding = new System.Windows.Forms.Padding(3);
			this.tpUserID.Size = new System.Drawing.Size(171, 288);
			this.tpUserID.TabIndex = 0;
			this.tpUserID.Text = "Step 1";
			// 
			// btCheckUserID
			// 
			this.btCheckUserID.Location = new System.Drawing.Point(6, 59);
			this.btCheckUserID.Name = "btCheckUserID";
			this.btCheckUserID.Size = new System.Drawing.Size(75, 20);
			this.btCheckUserID.TabIndex = 3;
			this.btCheckUserID.Text = "Check";
			this.btCheckUserID.UseVisualStyleBackColor = true;
			this.btCheckUserID.Click += new System.EventHandler(this.btCheckUserID_Click);
			// 
			// tbUserID
			// 
			this.tbUserID.Location = new System.Drawing.Point(6, 33);
			this.tbUserID.Name = "tbUserID";
			this.tbUserID.Size = new System.Drawing.Size(100, 22);
			this.tbUserID.TabIndex = 3;
			// 
			// cbAlbumType
			// 
			this.cbAlbumType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAlbumType.FormattingEnabled = true;
			this.cbAlbumType.Items.AddRange(new object[] {
            "Pixnet 痞客邦",
            "Flickr",
            "Wretch 無名小站"});
			this.cbAlbumType.Location = new System.Drawing.Point(6, 7);
			this.cbAlbumType.Name = "cbAlbumType";
			this.cbAlbumType.Size = new System.Drawing.Size(121, 22);
			this.cbAlbumType.TabIndex = 3;
			// 
			// tpAlbumList
			// 
			this.tpAlbumList.BackColor = System.Drawing.Color.Transparent;
			this.tpAlbumList.Controls.Add(this.lTotalAlbums);
			this.tpAlbumList.Controls.Add(this.lbAlbumList);
			this.tpAlbumList.Location = new System.Drawing.Point(25, 4);
			this.tpAlbumList.Name = "tpAlbumList";
			this.tpAlbumList.Padding = new System.Windows.Forms.Padding(3);
			this.tpAlbumList.Size = new System.Drawing.Size(171, 288);
			this.tpAlbumList.TabIndex = 1;
			this.tpAlbumList.Text = "Step 2";
			// 
			// lTotalAlbums
			// 
			this.lTotalAlbums.AutoSize = true;
			this.lTotalAlbums.Location = new System.Drawing.Point(6, 196);
			this.lTotalAlbums.Name = "lTotalAlbums";
			this.lTotalAlbums.Size = new System.Drawing.Size(68, 14);
			this.lTotalAlbums.TabIndex = 3;
			this.lTotalAlbums.Text = "total album";
			// 
			// lbAlbumList
			// 
			this.lbAlbumList.FormattingEnabled = true;
			this.lbAlbumList.ItemHeight = 14;
			this.lbAlbumList.Location = new System.Drawing.Point(6, 5);
			this.lbAlbumList.Name = "lbAlbumList";
			this.lbAlbumList.Size = new System.Drawing.Size(158, 158);
			this.lbAlbumList.TabIndex = 3;
			this.lbAlbumList.SelectedIndexChanged += new System.EventHandler(this.lbAlbumList_SelectedIndexChanged);
			// 
			// tpPhotoList
			// 
			this.tpPhotoList.BackColor = System.Drawing.Color.Transparent;
			this.tpPhotoList.Controls.Add(this.lTotalPhotos);
			this.tpPhotoList.Controls.Add(this.cbPhotoSelectAll);
			this.tpPhotoList.Controls.Add(this.lbPhotoList);
			this.tpPhotoList.Location = new System.Drawing.Point(25, 4);
			this.tpPhotoList.Name = "tpPhotoList";
			this.tpPhotoList.Size = new System.Drawing.Size(171, 288);
			this.tpPhotoList.TabIndex = 2;
			this.tpPhotoList.Text = "Step 3";
			// 
			// lTotalPhotos
			// 
			this.lTotalPhotos.AutoSize = true;
			this.lTotalPhotos.Location = new System.Drawing.Point(3, 126);
			this.lTotalPhotos.Name = "lTotalPhotos";
			this.lTotalPhotos.Size = new System.Drawing.Size(69, 14);
			this.lTotalPhotos.TabIndex = 3;
			this.lTotalPhotos.Text = "total photo";
			// 
			// cbPhotoSelectAll
			// 
			this.cbPhotoSelectAll.AutoSize = true;
			this.cbPhotoSelectAll.Checked = true;
			this.cbPhotoSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPhotoSelectAll.Location = new System.Drawing.Point(3, 106);
			this.cbPhotoSelectAll.Name = "cbPhotoSelectAll";
			this.cbPhotoSelectAll.Size = new System.Drawing.Size(72, 18);
			this.cbPhotoSelectAll.TabIndex = 3;
			this.cbPhotoSelectAll.Text = "select all";
			this.cbPhotoSelectAll.UseVisualStyleBackColor = true;
			this.cbPhotoSelectAll.CheckedChanged += new System.EventHandler(this.cbPhotoSelectAll_CheckedChanged);
			// 
			// lbPhotoList
			// 
			this.lbPhotoList.FormattingEnabled = true;
			this.lbPhotoList.HorizontalScrollbar = true;
			this.lbPhotoList.ItemHeight = 14;
			this.lbPhotoList.Location = new System.Drawing.Point(3, 7);
			this.lbPhotoList.Name = "lbPhotoList";
			this.lbPhotoList.Size = new System.Drawing.Size(165, 88);
			this.lbPhotoList.TabIndex = 3;
			this.lbPhotoList.SelectedIndexChanged += new System.EventHandler(this.lbPhotoList_SelectedIndexChanged);
			// 
			// tpFolder
			// 
			this.tpFolder.BackColor = System.Drawing.Color.Transparent;
			this.tpFolder.Controls.Add(this.btPhotoFolder);
			this.tpFolder.Controls.Add(this.tbPhotoFolder);
			this.tpFolder.Location = new System.Drawing.Point(25, 4);
			this.tpFolder.Name = "tpFolder";
			this.tpFolder.Size = new System.Drawing.Size(171, 288);
			this.tpFolder.TabIndex = 3;
			this.tpFolder.Text = "Step 4";
			// 
			// btPhotoFolder
			// 
			this.btPhotoFolder.Location = new System.Drawing.Point(3, 32);
			this.btPhotoFolder.Name = "btPhotoFolder";
			this.btPhotoFolder.Size = new System.Drawing.Size(75, 20);
			this.btPhotoFolder.TabIndex = 3;
			this.btPhotoFolder.Text = "folder";
			this.btPhotoFolder.UseVisualStyleBackColor = true;
			this.btPhotoFolder.Click += new System.EventHandler(this.btPhotoFolder_Click);
			// 
			// tbPhotoFolder
			// 
			this.tbPhotoFolder.Location = new System.Drawing.Point(3, 7);
			this.tbPhotoFolder.Name = "tbPhotoFolder";
			this.tbPhotoFolder.ReadOnly = true;
			this.tbPhotoFolder.Size = new System.Drawing.Size(100, 22);
			this.tbPhotoFolder.TabIndex = 3;
			// 
			// tpDownload
			// 
			this.tpDownload.BackColor = System.Drawing.Color.Transparent;
			this.tpDownload.Controls.Add(this.btDownloadStop);
			this.tpDownload.Controls.Add(this.btDownloadStart);
			this.tpDownload.Controls.Add(this.gbPhotoRename);
			this.tpDownload.Location = new System.Drawing.Point(25, 4);
			this.tpDownload.Name = "tpDownload";
			this.tpDownload.Size = new System.Drawing.Size(171, 288);
			this.tpDownload.TabIndex = 4;
			this.tpDownload.Text = "Step 5";
			// 
			// btDownloadStop
			// 
			this.btDownloadStop.Location = new System.Drawing.Point(8, 189);
			this.btDownloadStop.Name = "btDownloadStop";
			this.btDownloadStop.Size = new System.Drawing.Size(75, 20);
			this.btDownloadStop.TabIndex = 3;
			this.btDownloadStop.Text = "stop";
			this.btDownloadStop.UseVisualStyleBackColor = true;
			this.btDownloadStop.Click += new System.EventHandler(this.btDownloadStop_Click);
			// 
			// btDownloadStart
			// 
			this.btDownloadStart.Location = new System.Drawing.Point(8, 164);
			this.btDownloadStart.Name = "btDownloadStart";
			this.btDownloadStart.Size = new System.Drawing.Size(75, 20);
			this.btDownloadStart.TabIndex = 3;
			this.btDownloadStart.Text = "start";
			this.btDownloadStart.UseVisualStyleBackColor = true;
			this.btDownloadStart.Click += new System.EventHandler(this.btDownloadStart_Click);
			// 
			// gbPhotoRename
			// 
			this.gbPhotoRename.Controls.Add(this.cbPhotoRename);
			this.gbPhotoRename.Controls.Add(this.lPhotoExtension);
			this.gbPhotoRename.Controls.Add(this.lPhotoNumber);
			this.gbPhotoRename.Controls.Add(this.lPhotoNameExample);
			this.gbPhotoRename.Controls.Add(this.lPhotoPrefix);
			this.gbPhotoRename.Controls.Add(this.tbPhotoPrefix);
			this.gbPhotoRename.Controls.Add(this.cbbPhotoExtension);
			this.gbPhotoRename.Controls.Add(this.nudPhotoNumber);
			this.gbPhotoRename.Location = new System.Drawing.Point(8, 7);
			this.gbPhotoRename.Name = "gbPhotoRename";
			this.gbPhotoRename.Size = new System.Drawing.Size(159, 151);
			this.gbPhotoRename.TabIndex = 24;
			this.gbPhotoRename.TabStop = false;
			// 
			// cbPhotoRename
			// 
			this.cbPhotoRename.AutoSize = true;
			this.cbPhotoRename.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbPhotoRename.Location = new System.Drawing.Point(9, 18);
			this.cbPhotoRename.Name = "cbPhotoRename";
			this.cbPhotoRename.Size = new System.Drawing.Size(67, 18);
			this.cbPhotoRename.TabIndex = 10;
			this.cbPhotoRename.Text = "rename";
			this.cbPhotoRename.UseVisualStyleBackColor = true;
			this.cbPhotoRename.CheckedChanged += new System.EventHandler(this.cbPhotoRename_CheckedChanged);
			// 
			// lPhotoExtension
			// 
			this.lPhotoExtension.AutoSize = true;
			this.lPhotoExtension.Location = new System.Drawing.Point(6, 114);
			this.lPhotoExtension.Name = "lPhotoExtension";
			this.lPhotoExtension.Size = new System.Drawing.Size(60, 14);
			this.lPhotoExtension.TabIndex = 23;
			this.lPhotoExtension.Text = "Extension";
			// 
			// lPhotoNumber
			// 
			this.lPhotoNumber.AutoSize = true;
			this.lPhotoNumber.Location = new System.Drawing.Point(6, 88);
			this.lPhotoNumber.Name = "lPhotoNumber";
			this.lPhotoNumber.Size = new System.Drawing.Size(50, 14);
			this.lPhotoNumber.TabIndex = 23;
			this.lPhotoNumber.Text = "Number";
			// 
			// lPhotoNameExample
			// 
			this.lPhotoNameExample.AutoSize = true;
			this.lPhotoNameExample.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPhotoNameExample.Location = new System.Drawing.Point(13, 40);
			this.lPhotoNameExample.Name = "lPhotoNameExample";
			this.lPhotoNameExample.Size = new System.Drawing.Size(96, 14);
			this.lPhotoNameExample.TabIndex = 24;
			this.lPhotoNameExample.Text = "ex: photo00.jpg";
			this.lPhotoNameExample.UseMnemonic = false;
			// 
			// lPhotoPrefix
			// 
			this.lPhotoPrefix.AutoSize = true;
			this.lPhotoPrefix.Location = new System.Drawing.Point(6, 65);
			this.lPhotoPrefix.Name = "lPhotoPrefix";
			this.lPhotoPrefix.Size = new System.Drawing.Size(37, 14);
			this.lPhotoPrefix.TabIndex = 23;
			this.lPhotoPrefix.Text = "Prefix";
			// 
			// tbPhotoPrefix
			// 
			this.tbPhotoPrefix.Location = new System.Drawing.Point(73, 62);
			this.tbPhotoPrefix.Name = "tbPhotoPrefix";
			this.tbPhotoPrefix.Size = new System.Drawing.Size(79, 22);
			this.tbPhotoPrefix.TabIndex = 11;
			this.tbPhotoPrefix.Text = "photo";
			this.tbPhotoPrefix.TextChanged += new System.EventHandler(this.tbPhotoPrefix_TextChanged);
			// 
			// cbbPhotoExtension
			// 
			this.cbbPhotoExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbPhotoExtension.Enabled = false;
			this.cbbPhotoExtension.FormattingEnabled = true;
			this.cbbPhotoExtension.Items.AddRange(new object[] {
            ".jpg",
            ".gif",
            ".bmp"});
			this.cbbPhotoExtension.Location = new System.Drawing.Point(73, 111);
			this.cbbPhotoExtension.Name = "cbbPhotoExtension";
			this.cbbPhotoExtension.Size = new System.Drawing.Size(79, 22);
			this.cbbPhotoExtension.TabIndex = 13;
			this.cbbPhotoExtension.SelectedIndexChanged += new System.EventHandler(this.cbbPhotoExtension_SelectedIndexChanged);
			// 
			// nudPhotoNumber
			// 
			this.nudPhotoNumber.Location = new System.Drawing.Point(73, 87);
			this.nudPhotoNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudPhotoNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudPhotoNumber.Name = "nudPhotoNumber";
			this.nudPhotoNumber.Size = new System.Drawing.Size(79, 22);
			this.nudPhotoNumber.TabIndex = 12;
			this.nudPhotoNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudPhotoNumber.ValueChanged += new System.EventHandler(this.nudPhotoNumber_ValueChanged);
			// 
			// tpHelp
			// 
			this.tpHelp.BackColor = System.Drawing.Color.Transparent;
			this.tpHelp.Controls.Add(this.cbLanguage);
			this.tpHelp.Location = new System.Drawing.Point(25, 4);
			this.tpHelp.Name = "tpHelp";
			this.tpHelp.Size = new System.Drawing.Size(171, 288);
			this.tpHelp.TabIndex = 5;
			this.tpHelp.Text = "Help";
			// 
			// cbLanguage
			// 
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Location = new System.Drawing.Point(3, 270);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(121, 22);
			this.cbLanguage.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 318);
			this.Controls.Add(this.wbPreview);
			this.Controls.Add(this.tcCtrlPanel);
			this.Controls.Add(this.ssFormStatus);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.ssFormStatus.ResumeLayout(false);
			this.ssFormStatus.PerformLayout();
			this.tcCtrlPanel.ResumeLayout(false);
			this.tpUserID.ResumeLayout(false);
			this.tpUserID.PerformLayout();
			this.tpAlbumList.ResumeLayout(false);
			this.tpAlbumList.PerformLayout();
			this.tpPhotoList.ResumeLayout(false);
			this.tpPhotoList.PerformLayout();
			this.tpFolder.ResumeLayout(false);
			this.tpFolder.PerformLayout();
			this.tpDownload.ResumeLayout(false);
			this.gbPhotoRename.ResumeLayout(false);
			this.gbPhotoRename.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPhotoNumber)).EndInit();
			this.tpHelp.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip ssFormStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.FixedTabControl tcCtrlPanel;
		private System.Windows.Forms.TabPage tpUserID;
		private System.Windows.Forms.TabPage tpAlbumList;
		private System.Windows.Forms.TabPage tpPhotoList;
		private System.Windows.Forms.TabPage tpFolder;
		private System.Windows.Forms.TabPage tpDownload;
		private System.Windows.Forms.Button btCheckUserID;
		private System.Windows.Forms.TextBox tbUserID;
		private System.Windows.Forms.ComboBox cbAlbumType;
		private System.Windows.Forms.ListBox lbAlbumList;
		private System.Windows.Forms.Label lTotalAlbums;
		private System.Windows.Forms.Label lTotalPhotos;
		private System.Windows.Forms.CheckBox cbPhotoSelectAll;
		private System.Windows.Forms.ListBox lbPhotoList;
		private System.Windows.Forms.Button btPhotoFolder;
		private System.Windows.Forms.TextBox tbPhotoFolder;
		private System.Windows.Forms.Button btDownloadStop;
		private System.Windows.Forms.Button btDownloadStart;
		private System.Windows.Forms.GroupBox gbPhotoRename;
		private System.Windows.Forms.CheckBox cbPhotoRename;
		private System.Windows.Forms.Label lPhotoExtension;
		private System.Windows.Forms.Label lPhotoNumber;
		private System.Windows.Forms.Label lPhotoNameExample;
		private System.Windows.Forms.Label lPhotoPrefix;
		private System.Windows.Forms.TextBox tbPhotoPrefix;
		private System.Windows.Forms.ComboBox cbbPhotoExtension;
		private System.Windows.Forms.NumericUpDown nudPhotoNumber;
		private System.Windows.Forms.TabPage tpHelp;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.WebBrowser wbPreview;
		private System.Windows.Forms.ToolStripProgressBar tspbProgress;
	}
}

