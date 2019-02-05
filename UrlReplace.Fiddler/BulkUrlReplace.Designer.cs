using System.Windows.Forms;

namespace UrlReplace
{
    partial class BulkUrlReplace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkUrlReplace));
			this.ActionList = new System.Windows.Forms.ListView();
			this.chActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chSeek = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chReplace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHitCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chExecutionOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHostOnly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chIgnoreCase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chIsRegEx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.enableAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disableAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetHitcountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.groupByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.simpelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executionOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Replaces = new System.Windows.Forms.GroupBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.mergeFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.HomePageLink = new System.Windows.Forms.LinkLabel();
			this.actionItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			this.contextMenu.SuspendLayout();
			this.Replaces.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.actionItemsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ActionList
			// 
			this.ActionList.AllowColumnReorder = true;
			this.ActionList.AllowDrop = true;
			this.ActionList.CheckBoxes = true;
			this.ActionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chActive,
            this.chGroup,
            this.chSeek,
            this.chReplace,
            this.chComment,
            this.chHitCount,
            this.chExecutionOrder,
            this.chHostOnly,
            this.chIgnoreCase,
            this.chIsRegEx});
			this.ActionList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ActionList.FullRowSelect = true;
			this.ActionList.HideSelection = false;
			this.ActionList.Location = new System.Drawing.Point(3, 16);
			this.ActionList.Name = "ActionList";
			this.ActionList.Size = new System.Drawing.Size(669, 370);
			this.ActionList.SmallImageList = this.imageList1;
			this.ActionList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ActionList.TabIndex = 0;
			this.ActionList.UseCompatibleStateImageBehavior = false;
			this.ActionList.View = System.Windows.Forms.View.Details;
			this.ActionList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ActionListColumnClick);
			this.ActionList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ActionListItemChecked);
			this.ActionList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ActionList_ItemDrag);
			this.ActionList.SelectedIndexChanged += new System.EventHandler(this.ListView1SelectedIndexChanged);
			this.ActionList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ActionList_DragDrop);
			this.ActionList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ActionList_DragEnter);
			this.ActionList.DragOver += new System.Windows.Forms.DragEventHandler(this.ActionList_DragOver);
			// 
			// chActive
			// 
			this.chActive.Tag = "{0:Active}";
			this.chActive.Text = "Active";
			// 
			// chGroup
			// 
			this.chGroup.DisplayIndex = 8;
			this.chGroup.Tag = "{0:Group}";
			this.chGroup.Text = "Group";
			// 
			// chSeek
			// 
			this.chSeek.DisplayIndex = 1;
			this.chSeek.Tag = "{0:Seek}";
			this.chSeek.Text = "Seek";
			// 
			// chReplace
			// 
			this.chReplace.DisplayIndex = 2;
			this.chReplace.Tag = "{0:Replace}";
			this.chReplace.Text = "Replace";
			// 
			// chComment
			// 
			this.chComment.DisplayIndex = 3;
			this.chComment.Tag = "{0:Comment}";
			this.chComment.Text = "Comment";
			// 
			// chHitCount
			// 
			this.chHitCount.DisplayIndex = 4;
			this.chHitCount.Tag = "{0:HitCount}";
			this.chHitCount.Text = "Hit Count";
			this.chHitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chExecutionOrder
			// 
			this.chExecutionOrder.DisplayIndex = 5;
			this.chExecutionOrder.Tag = "{0:Index}";
			this.chExecutionOrder.Text = "Execution Order";
			// 
			// chHostOnly
			// 
			this.chHostOnly.DisplayIndex = 6;
			this.chHostOnly.Tag = "{0:HostOnly}";
			this.chHostOnly.Text = "Host Only";
			// 
			// chIgnoreCase
			// 
			this.chIgnoreCase.DisplayIndex = 7;
			this.chIgnoreCase.Tag = "{0:IgnoreCase}";
			this.chIgnoreCase.Text = "Ignore Case";
			// 
			// chIsRegEx
			// 
			this.chIsRegEx.Tag = "{0:RegEx}";
			this.chIsRegEx.Text = "RegEx";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "TextReplace.ico");
			this.imageList1.Images.SetKeyName(1, "RegExReplace.ico");
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableAllToolStripMenuItem,
            this.disableAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.resetHitcountToolStripMenuItem,
            this.toolStripMenuItem3,
            this.groupByToolStripMenuItem,
            this.displayToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(185, 286);
			this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuOpening);
			// 
			// enableAllToolStripMenuItem
			// 
			this.enableAllToolStripMenuItem.Name = "enableAllToolStripMenuItem";
			this.enableAllToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.enableAllToolStripMenuItem.Text = "Enable All";
			this.enableAllToolStripMenuItem.Click += new System.EventHandler(this.EnableAllToolStripMenuItemClick);
			// 
			// disableAllToolStripMenuItem
			// 
			this.disableAllToolStripMenuItem.Name = "disableAllToolStripMenuItem";
			this.disableAllToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.disableAllToolStripMenuItem.Text = "Disable All";
			this.disableAllToolStripMenuItem.Click += new System.EventHandler(this.DisableAllToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
			this.addToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.addToolStripMenuItem.Text = "&Add...";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.AddClick);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.removeToolStripMenuItem.Text = "&Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.editToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.editToolStripMenuItem.Text = "&Edit...";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.EditClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.loadToolStripMenuItem.Text = "&Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.saveToolStripMenuItem.Text = "&Save...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveClick);
			// 
			// mergeToolStripMenuItem
			// 
			this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
			this.mergeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
			this.mergeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.mergeToolStripMenuItem.Text = "&Merge...";
			this.mergeToolStripMenuItem.Click += new System.EventHandler(this.MergeClick);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearClick);
			// 
			// resetHitcountToolStripMenuItem
			// 
			this.resetHitcountToolStripMenuItem.Name = "resetHitcountToolStripMenuItem";
			this.resetHitcountToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.resetHitcountToolStripMenuItem.Text = "Reset Hitcount";
			this.resetHitcountToolStripMenuItem.Click += new System.EventHandler(this.ResetHitcountToolStripMenuItemClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
			// 
			// groupByToolStripMenuItem
			// 
			this.groupByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupToolStripMenuItem,
            this.activeToolStripMenuItem,
            this.noneToolStripMenuItem,
            this.typeToolStripMenuItem});
			this.groupByToolStripMenuItem.Name = "groupByToolStripMenuItem";
			this.groupByToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.groupByToolStripMenuItem.Text = "Group by";
			this.groupByToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.GroupByToolStripMenuItemDropDownItemClicked);
			// 
			// groupToolStripMenuItem
			// 
			this.groupToolStripMenuItem.Checked = true;
			this.groupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
			this.groupToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.groupToolStripMenuItem.Tag = "{0:Group}";
			this.groupToolStripMenuItem.Text = "Group";
			// 
			// activeToolStripMenuItem
			// 
			this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
			this.activeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.activeToolStripMenuItem.Tag = "Active = {0:Active}";
			this.activeToolStripMenuItem.Text = "Active";
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.noneToolStripMenuItem.Tag = " ";
			this.noneToolStripMenuItem.Text = "None";
			// 
			// typeToolStripMenuItem
			// 
			this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
			this.typeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.typeToolStripMenuItem.Tag = "{0:HostOnlyString} : {0:RegExString} : {0:IgnoreCaseString} : {0:ActiveString}";
			this.typeToolStripMenuItem.Text = "Type";
			// 
			// displayToolStripMenuItem
			// 
			this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.simpelToolStripMenuItem,
            this.executionOrderToolStripMenuItem,
            this.allValuesToolStripMenuItem});
			this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
			this.displayToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.displayToolStripMenuItem.Text = "Display";
			this.displayToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStripMenuItemDropDownItemClicked);
			// 
			// defaultToolStripMenuItem
			// 
			this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
			this.defaultToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.defaultToolStripMenuItem.Tag = "Default";
			this.defaultToolStripMenuItem.Text = "Default";
			// 
			// simpelToolStripMenuItem
			// 
			this.simpelToolStripMenuItem.Name = "simpelToolStripMenuItem";
			this.simpelToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.simpelToolStripMenuItem.Tag = "Simpel";
			this.simpelToolStripMenuItem.Text = "Simpel";
			// 
			// executionOrderToolStripMenuItem
			// 
			this.executionOrderToolStripMenuItem.Name = "executionOrderToolStripMenuItem";
			this.executionOrderToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.executionOrderToolStripMenuItem.Tag = "ExecutionOrder";
			this.executionOrderToolStripMenuItem.Text = "Execution order";
			// 
			// allValuesToolStripMenuItem
			// 
			this.allValuesToolStripMenuItem.Name = "allValuesToolStripMenuItem";
			this.allValuesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.allValuesToolStripMenuItem.Tag = "All";
			this.allValuesToolStripMenuItem.Text = "All values";
			// 
			// Replaces
			// 
			this.Replaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Replaces.Controls.Add(this.ActionList);
			this.Replaces.Location = new System.Drawing.Point(3, 26);
			this.Replaces.Name = "Replaces";
			this.Replaces.Size = new System.Drawing.Size(675, 389);
			this.Replaces.TabIndex = 1;
			this.Replaces.TabStop = false;
			this.Replaces.Text = "Replaces";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "xml";
			this.saveFileDialog.Filter = "UrlReplace files (*.xml)|*.xml|All files (*.*)|*.*";
			this.saveFileDialog.Title = "Save replace settings";
			// 
			// loadFileDialog
			// 
			this.loadFileDialog.DefaultExt = "xml";
			this.loadFileDialog.Filter = "UrlReplace files (*.xml)|*.xml|All files (*.*)|*.*";
			this.loadFileDialog.Title = "Load replace settings";
			// 
			// mergeFileDialog
			// 
			this.mergeFileDialog.DefaultExt = "xml";
			this.mergeFileDialog.Filter = "UrlReplace files (*.xml)|*.xml|All files (*.*)|*.*";
			this.mergeFileDialog.Title = "Load and merge replace settings";
			// 
			// HomePageLink
			// 
			this.HomePageLink.AutoSize = true;
			this.HomePageLink.Location = new System.Drawing.Point(3, 4);
			this.HomePageLink.Name = "HomePageLink";
			this.HomePageLink.Size = new System.Drawing.Size(238, 13);
			this.HomePageLink.TabIndex = 2;
			this.HomePageLink.TabStop = true;
			this.HomePageLink.Text = "https://github.com/oswaldsql/Fiddler.UrlReplace";
			this.HomePageLink.Click += new System.EventHandler(this.BulkUrlReplaceClick);
			// 
			// actionItemsBindingSource
			// 
			this.actionItemsBindingSource.DataSource = typeof(UrlReplace.Core.ActionItems);
			// 
			// chkEnabled
			// 
			this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkEnabled.AutoSize = true;
			this.chkEnabled.Checked = global::UrlReplace.Properties.Settings.Default.UrlReplaceEnabled;
			this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::UrlReplace.Properties.Settings.Default, "UrlReplaceEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkEnabled.Location = new System.Drawing.Point(614, 3);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(65, 17);
			this.chkEnabled.TabIndex = 0;
			this.chkEnabled.Text = "Enabled";
			this.chkEnabled.UseVisualStyleBackColor = true;
			this.chkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabledCheckedChanged);
			// 
			// BulkUrlReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ContextMenuStrip = this.contextMenu;
			this.Controls.Add(this.HomePageLink);
			this.Controls.Add(this.Replaces);
			this.Controls.Add(this.chkEnabled);
			this.Name = "BulkUrlReplace";
			this.Size = new System.Drawing.Size(682, 418);
			this.SizeChanged += new System.EventHandler(this.BulkUrlReplaceSizeChanged);
			this.contextMenu.ResumeLayout(false);
			this.Replaces.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.actionItemsBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ActionList;
        private System.Windows.Forms.GroupBox Replaces;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.CheckBox chkEnabled;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog loadFileDialog;
        private OpenFileDialog mergeFileDialog;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem mergeToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem enableAllToolStripMenuItem;
        private ToolStripMenuItem disableAllToolStripMenuItem;
        private ColumnHeader chExecutionOrder;
        private ColumnHeader chHostOnly;
        private ColumnHeader chIgnoreCase;
        private BindingSource actionItemsBindingSource;
        private ColumnHeader chGroup;
        private ColumnHeader chSeek;
        private ColumnHeader chReplace;
        private ColumnHeader chActive;
        private ColumnHeader chComment;
        private ColumnHeader chHitCount;
        private ColumnHeader chIsRegEx;
        private ToolStripMenuItem groupByToolStripMenuItem;
        private ToolStripMenuItem groupToolStripMenuItem;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripMenuItem allValuesToolStripMenuItem;
        private ToolStripMenuItem simpelToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem executionOrderToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem typeToolStripMenuItem;
        private ToolStripMenuItem resetHitcountToolStripMenuItem;
        private LinkLabel HomePageLink;
    }
}