namespace SnapmaticStudio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.closeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleAsFilenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datetimeFilenamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataOverlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resizeWindowToFitImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.titleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCheckedToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metadataLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.listContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadProfileToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveSelectedToolStripMenuItem,
            this.saveSelectedToToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.saveAllToToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeSelectedToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.loadToolStripMenuItem.Text = "Load picture";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadProfileToolStripMenuItem
            // 
            this.loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
            this.loadProfileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.loadProfileToolStripMenuItem.Text = "Load profile folder";
            this.loadProfileToolStripMenuItem.Click += new System.EventHandler(this.loadProfileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // saveSelectedToolStripMenuItem
            // 
            this.saveSelectedToolStripMenuItem.Name = "saveSelectedToolStripMenuItem";
            this.saveSelectedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveSelectedToolStripMenuItem.Text = "Export selected";
            this.saveSelectedToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToolStripMenuItem_Click);
            // 
            // saveSelectedToToolStripMenuItem
            // 
            this.saveSelectedToToolStripMenuItem.Name = "saveSelectedToToolStripMenuItem";
            this.saveSelectedToToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveSelectedToToolStripMenuItem.Text = "Export selected to...";
            this.saveSelectedToToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveAllToolStripMenuItem.Text = "Export all";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveAllToToolStripMenuItem
            // 
            this.saveAllToToolStripMenuItem.Name = "saveAllToToolStripMenuItem";
            this.saveAllToToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveAllToToolStripMenuItem.Text = "Export all to...";
            this.saveAllToToolStripMenuItem.Click += new System.EventHandler(this.saveAllToToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // closeSelectedToolStripMenuItem
            // 
            this.closeSelectedToolStripMenuItem.Name = "closeSelectedToolStripMenuItem";
            this.closeSelectedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.closeSelectedToolStripMenuItem.Text = "Close selected";
            this.closeSelectedToolStripMenuItem.Click += new System.EventHandler(this.closeSelectedToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleAsFilenameMenuItem,
            this.datetimeFilenamesMenuItem,
            this.metadataExportMenuItem,
            this.metadataOverlayMenuItem,
            this.fitImageMenuItem,
            this.toolStripSeparator2,
            this.resizeWindowToFitImageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // titleAsFilenameMenuItem
            // 
            this.titleAsFilenameMenuItem.CheckOnClick = true;
            this.titleAsFilenameMenuItem.Name = "titleAsFilenameMenuItem";
            this.titleAsFilenameMenuItem.Size = new System.Drawing.Size(225, 22);
            this.titleAsFilenameMenuItem.Text = "Use title as filename";
            this.titleAsFilenameMenuItem.CheckedChanged += new System.EventHandler(this.titleAsFilenameMenuItem_CheckedChanged);
            // 
            // datetimeFilenamesMenuItem
            // 
            this.datetimeFilenamesMenuItem.CheckOnClick = true;
            this.datetimeFilenamesMenuItem.Name = "datetimeFilenamesMenuItem";
            this.datetimeFilenamesMenuItem.Size = new System.Drawing.Size(225, 22);
            this.datetimeFilenamesMenuItem.Text = "Add time && date to filename";
            this.datetimeFilenamesMenuItem.Visible = false;
            this.datetimeFilenamesMenuItem.CheckedChanged += new System.EventHandler(this.datetimeFilenamesMenuItem_CheckedChanged);
            // 
            // metadataExportMenuItem
            // 
            this.metadataExportMenuItem.CheckOnClick = true;
            this.metadataExportMenuItem.Name = "metadataExportMenuItem";
            this.metadataExportMenuItem.Size = new System.Drawing.Size(225, 22);
            this.metadataExportMenuItem.Text = "Export metadata log";
            this.metadataExportMenuItem.CheckedChanged += new System.EventHandler(this.metadataExportMenuItem_CheckedChanged);
            // 
            // metadataOverlayMenuItem
            // 
            this.metadataOverlayMenuItem.CheckOnClick = true;
            this.metadataOverlayMenuItem.Name = "metadataOverlayMenuItem";
            this.metadataOverlayMenuItem.Size = new System.Drawing.Size(225, 22);
            this.metadataOverlayMenuItem.Text = "Show metadata overlay";
            this.metadataOverlayMenuItem.CheckedChanged += new System.EventHandler(this.metadataOverlayMenuItem_CheckedChanged);
            // 
            // fitImageMenuItem
            // 
            this.fitImageMenuItem.CheckOnClick = true;
            this.fitImageMenuItem.Name = "fitImageMenuItem";
            this.fitImageMenuItem.Size = new System.Drawing.Size(225, 22);
            this.fitImageMenuItem.Text = "Zoom image to fit window";
            this.fitImageMenuItem.CheckedChanged += new System.EventHandler(this.fitImageMenuItem_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // resizeWindowToFitImageToolStripMenuItem
            // 
            this.resizeWindowToFitImageToolStripMenuItem.Name = "resizeWindowToFitImageToolStripMenuItem";
            this.resizeWindowToFitImageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.resizeWindowToFitImageToolStripMenuItem.Text = "Resize window to fit image";
            this.resizeWindowToFitImageToolStripMenuItem.Click += new System.EventHandler(this.resizeWindowToFitImageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(382, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel1.Text = "Ready to go";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1350, 538);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleHeader,
            this.fileHeader,
            this.dateHeader});
            this.listView1.ContextMenuStrip = this.listContextMenuStrip;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(382, 514);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // titleHeader
            // 
            this.titleHeader.DisplayIndex = 2;
            this.titleHeader.Text = "Title";
            this.titleHeader.Width = 142;
            // 
            // fileHeader
            // 
            this.fileHeader.DisplayIndex = 0;
            this.fileHeader.Text = "Filename";
            this.fileHeader.Width = 108;
            // 
            // dateHeader
            // 
            this.dateHeader.DisplayIndex = 1;
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 131;
            // 
            // listContextMenuStrip
            // 
            this.listContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkSelectedToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveCheckedToolStripMenuItem,
            this.saveCheckedToToolStripMenuItem,
            this.saveAllToolStripMenuItem1,
            this.saveAllToToolStripMenuItem1,
            this.toolStripSeparator5,
            this.closeSelectedToolStripMenuItem1,
            this.closeAllToolStripMenuItem1});
            this.listContextMenuStrip.Name = "listContextMenuStrip";
            this.listContextMenuStrip.Size = new System.Drawing.Size(177, 170);
            // 
            // checkSelectedToolStripMenuItem
            // 
            this.checkSelectedToolStripMenuItem.Name = "checkSelectedToolStripMenuItem";
            this.checkSelectedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.checkSelectedToolStripMenuItem.Text = "Select highlighted";
            this.checkSelectedToolStripMenuItem.Click += new System.EventHandler(this.checkSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // saveCheckedToolStripMenuItem
            // 
            this.saveCheckedToolStripMenuItem.Name = "saveCheckedToolStripMenuItem";
            this.saveCheckedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveCheckedToolStripMenuItem.Text = "Export selected";
            this.saveCheckedToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToolStripMenuItem_Click);
            // 
            // saveCheckedToToolStripMenuItem
            // 
            this.saveCheckedToToolStripMenuItem.Name = "saveCheckedToToolStripMenuItem";
            this.saveCheckedToToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveCheckedToToolStripMenuItem.Text = "Export selected to...";
            this.saveCheckedToToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem1
            // 
            this.saveAllToolStripMenuItem1.Name = "saveAllToolStripMenuItem1";
            this.saveAllToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.saveAllToolStripMenuItem1.Text = "Export all";
            this.saveAllToolStripMenuItem1.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveAllToToolStripMenuItem1
            // 
            this.saveAllToToolStripMenuItem1.Name = "saveAllToToolStripMenuItem1";
            this.saveAllToToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.saveAllToToolStripMenuItem1.Text = "Export all to...";
            this.saveAllToToolStripMenuItem1.Click += new System.EventHandler(this.saveAllToToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(173, 6);
            // 
            // closeSelectedToolStripMenuItem1
            // 
            this.closeSelectedToolStripMenuItem1.Name = "closeSelectedToolStripMenuItem1";
            this.closeSelectedToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.closeSelectedToolStripMenuItem1.Text = "Close selected";
            // 
            // closeAllToolStripMenuItem1
            // 
            this.closeAllToolStripMenuItem1.Name = "closeAllToolStripMenuItem1";
            this.closeAllToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.closeAllToolStripMenuItem1.Text = "Close all";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Controls.Add(this.metadataLabel);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 536);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // metadataLabel
            // 
            this.metadataLabel.AutoSize = true;
            this.metadataLabel.BackColor = System.Drawing.Color.Transparent;
            this.metadataLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.metadataLabel.Location = new System.Drawing.Point(4, 4);
            this.metadataLabel.Name = "metadataLabel";
            this.metadataLabel.Size = new System.Drawing.Size(0, 13);
            this.metadataLabel.TabIndex = 0;
            this.metadataLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Form1";
            this.Text = "Snapmatic Studio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.listContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureBox1.ResumeLayout(false);
            this.pictureBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleAsFilenameMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metadataExportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader titleHeader;
        private System.Windows.Forms.ColumnHeader fileHeader;
        private System.Windows.Forms.ToolStripMenuItem metadataOverlayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datetimeFilenamesMenuItem;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.Label metadataLabel;
        private System.Windows.Forms.ContextMenuStrip listContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem checkSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem resizeWindowToFitImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAllToToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCheckedToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem closeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem closeSelectedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

