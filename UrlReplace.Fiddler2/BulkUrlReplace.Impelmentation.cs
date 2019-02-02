namespace UrlReplace
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.IO;
	using System.Text;
	using System.Windows.Forms;
	using System.Xml;

	using UrlReplace.Core;
	using UrlReplace.Properties;

	public partial class BulkUrlReplace
	{
		private readonly Dictionary<string, EditUrlReplace> activeEdits = new Dictionary<string, EditUrlReplace>();

		private readonly string[] emptySubItemValues =
			{
				string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
			};

		private bool descSortOrder;

		private string groupString = "{0:group}";

		private int hitCountColumn = -1;

		private bool loadingFromSettings;

		private int prevSortField = -1;

		/// <summary>
		///     Thrown when a set of session id's needs to be selected
		/// </summary>
		public event EventHandler<MarkSessionsEventArgs> MarkSessions;

		/// <summary>
		///     Event used for signaling changed status of the interface
		/// </summary>
		public event EventHandler<StatusChangedEventArgs> StatusChanged;

		/// <summary>
		///     Gets or sets the <see cref="TabPage" /> control containing the interface
		/// </summary>
		public TabPage HostTab { get; set; }

		internal ActionItems ActionItems { get; }

		/// <summary>
		///     Entry point for handling commands sent to the interface from the fiddler command line
		/// </summary>
		/// <param name="command">Contains the full command</param>
		/// <returns><c>true</c> if the command is processed otherwise <c>false</c></returns>
		public bool HandelExecAction(string command)
		{
			if (!command.Trim().StartsWith("urlreplace", StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}

			var processor = new CommandProcessor
				                {
					                Parent = this
				                };
			return processor.Process(command);
		}

		/// <summary>
		///     Performs the replace action itself.
		/// </summary>
		/// <param name="url">String representation of the URL to be processed</param>
		/// <param name="sessionId">Session id identifying the session containing the URL</param>
		/// <param name="result">Resulting URL (without the protocol information)</param>
		/// <returns><c>true</c> if the replace was successful, otherwise <c>false</c></returns>
		public bool HandelReplace(string url, int sessionId, out string result)
		{
			result = url;
			if (!this.chkEnabled.Checked)
			{
				return false;
			}

			if (Uri.TryCreate(url, UriKind.Absolute, out var source))
			{
				if (this.ActionItems.ExecuteReplace(source, sessionId, out var resultUri))
				{
					result = resultUri.Authority + resultUri.PathAndQuery;
					return true;
				}
			}

			return false;
		}

		public void MarkItemsWithSessionId(int[] sessionIds)
		{
			foreach (var sessionId in sessionIds)
			{
				foreach (var item in this.ActionItems)
				{
					this.ActionList.Items[item.Key].Selected = item.SessionIds.Contains(sessionId);
				}
			}
		}

		public void ResetSessionIds()
		{
			this.ActionItems.ResetSessionIds();
		}

		internal void ClearActionItems()
		{
			if (this.ActionItems.Count == 0)
			{
				return;
			}

			if (MessageBox.Show("Are you sure you want to clear all items?", "Clear items", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.ActionItems.Clear();
			}
		}

		internal void DisplayHelp()
		{
			MessageBox.Show(Resources.HelpText, "Bulk Url Replace Syntax Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		internal void InvertEnabledState()
		{
			this.SetEnabledState(this.chkEnabled.Checked);
		}

		internal void LoadActionItems()
		{
			if (this.loadFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var reader = XmlReader.Create(this.loadFileDialog.FileName);
			this.ActionItems.DeserializeFromStream(reader, false);
		}

		internal void MergeActionItems()
		{
			if (this.mergeFileDialog.ShowDialog() == DialogResult.OK)
			{
				var reader = XmlReader.Create(this.mergeFileDialog.FileName);
				this.ActionItems.DeserializeFromStream(reader, true);
			}
		}

		internal void SaveActionItems()
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				var writer = XmlWriter.Create(this.saveFileDialog.FileName);
				this.ActionItems.SerializeToStream(writer);
			}
		}

		private void AddActionItemToActionList(ActionItem list)
		{
			var value = this.ActionList.Items.Add(list.Key, string.Empty, 0);
			value.SubItems.AddRange(this.emptySubItemValues);

			this.UpdateItemValues(list, value);

			list.ActionHit += this.ListActionHit;
		}

		private void AddNewActionItem()
		{
			var editUrlReplace = new EditUrlReplace
				                     {
					                     ActionItems = this.ActionItems, ActionItem = Factory.ActionItem(), Mode = EditMode.Add
				                     };
			editUrlReplace.Show();
			editUrlReplace.Closing += this.EditUrlReplaceClosing;
		}

		private void ChangeSortColumn(int column)
		{
			this.ActionList.Sorting = this.ActionList.Sorting == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
			if (this.prevSortField == column)
			{
				this.descSortOrder = !this.descSortOrder;
			}
			else
			{
				this.descSortOrder = false;
			}

			this.prevSortField = column;
			this.ActionList.ListViewItemSorter = new ListViewItemComparer(column, this.descSortOrder);
			this.ActionList.Sort();
		}

		private void CreateMenuItems()
		{
			var menuItem = new MenuItem("&Url Replace");
			var collection = menuItem.MenuItems;

			this.enabledMenuItem = new MenuItem("Enabled", this.EnabledMenuItemClick)
				                       {
					                       Checked = this.chkEnabled.Checked
				                       };
			collection.Add(this.enabledMenuItem);

			this.shownMenuItem = new MenuItem("Show UI", this.ShownMenuItemClick)
				                     {
					                     Checked = Settings.Default.UrlReplaceUIShown
				                     };
			collection.Add(this.shownMenuItem);

			collection.Add("-");
			collection.Add("Load settings ...", this.LoadClick);
			collection.Add("Save settings ...", this.SaveClick);
			collection.Add("Merge settings ...", this.MergeClick);
			collection.Add("Clear settings ...", this.ClearClick);
			collection.Add("-");
			collection.Add("CommandLine Help", this.CommandLineHelpClick);
			collection.Add("UrlReplace Website", HelpClick);
			collection.Add("Check for Updates", this.CheckForUpdatesClick);
			collection.Add("-");
			collection.Add("version : " + this.GetType()
				               .Assembly.GetName()
				               .Version)
				.Enabled = false;

			this.MenuItem = menuItem;
		}

		private void DoMarkSessions(int[] sessionIds)
		{
			this.MarkSessions?.Invoke(this, new MarkSessionsEventArgs(sessionIds));
		}

		private void DoStatusChanged(string status)
		{
			this.StatusChanged?.Invoke(this, new StatusChangedEventArgs(status));
		}

		private void EditActionItem(ActionItem item)
		{
			if (this.activeEdits.ContainsKey(item.Key))
			{
				this.activeEdits[item.Key].Focus();
			}
			else
			{
				var editUrlReplace = new EditUrlReplace
					                     {
						                     ActionItems = this.ActionItems, ActionItem = item
					                     };
				this.activeEdits.Add(item.Key, editUrlReplace);
				editUrlReplace.Closing += this.EditUrlReplaceClosing;
				editUrlReplace.Show();
			}
		}

		private void EditSelectedItem()
		{
			this.EditActionItem((ActionItem)this.ActionList.SelectedItems[0].Tag);
		}

		private void EditUrlReplaceClosing(object sender, CancelEventArgs e)
		{
			var editUrlReplace = sender as EditUrlReplace;
			if (editUrlReplace != null)
			{
				if (this.activeEdits.ContainsKey(editUrlReplace.ActionItem.Key))
				{
					this.activeEdits.Remove(editUrlReplace.ActionItem.Key);
				}

				if (editUrlReplace.DialogResult == DialogResult.OK)
				{
					if (editUrlReplace.Mode == EditMode.Add)
					{
						this.ActionItems.Add(editUrlReplace.ActionItem);
					}

					this.SaveToSettings();
					this.PopulateActionList();
				}
			}
		}

		private void LoadFromSettings()
		{
			this.loadingFromSettings = true;
			try
			{
				this.SetColumns(Settings.Default.DisplayMode);
				this.SetGroupString(Settings.Default.GroupeMode);

				var actionItemsXml = Settings.Default.ActionItemsXml;
				if (actionItemsXml != string.Empty)
				{
					var stringReader = new StringReader(actionItemsXml);
					var reader = XmlReader.Create(stringReader);
					this.ActionItems.DeserializeFromStream(reader, false);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Urlreplace was unable to load settings from the settings file", "Unable to load settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			this.loadingFromSettings = false;
		}

		private void MarkActionHit(ActionItem actionItem)
		{
			if (actionItem != null && this.hitCountColumn != -1)
			{
				var item = this.ActionList.Items[actionItem.Key];
				if (item != null)
				{
					item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
					item.SubItems[this.hitCountColumn].Text = actionItem.HitCount.ToString();
				}
			}
		}

		private void MarkSelectedActionItems()
		{
			var idList = new List<int>();
			foreach (ListViewItem item in this.ActionList.SelectedItems)
			{
				if (item != null && item.Tag != null && item.Tag is ActionItem)
				{
					idList.AddRange(((ActionItem)item.Tag).SessionIds);
				}
			}

			this.DoMarkSessions(idList.ToArray());
		}

		private void PopulateActionList()
		{
			this.ActionList.SuspendLayout();

			this.ActionList.Items.Clear();
			this.ActionList.Groups.Clear();
			foreach (var list in this.ActionItems)
			{
				this.AddActionItemToActionList(list);
			}

			this.ActionList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

			this.ActionList.ResumeLayout();
		}

		private void RemoveActionItem()
		{
			var removeItems = new List<ActionItem>();
			foreach (ListViewItem item in this.ActionList.SelectedItems)
			{
				if (item.Tag is ActionItem tag)
				{
					removeItems.Add(tag);
				}
			}

			this.RemoveActionItems(removeItems.ToArray());
		}

		private void RemoveActionItems(IEnumerable<ActionItem> items)
		{
			if (items == null)
			{
				return;
			}

			foreach (var item in items)
			{
				if (item != null)
				{
					this.ActionList.Items.RemoveByKey(item.Key);
					this.ActionItems.Remove(item);
				}
			}
		}

		private void SaveToSettings()
		{
			if (this.loadingFromSettings)
			{
				return;
			}

			var result = new StringBuilder();
			var writer = XmlWriter.Create(result);
			this.ActionItems.SerializeToStream(writer);
			writer.Flush();
			writer.Close();
			Settings.Default.ActionItemsXml = result.ToString();
			Settings.Default.Save();
		}

		private void SetActionItemActiveState(ActionItem actionItem, bool active)
		{
			if (actionItem != null)
			{
				actionItem.Active = active;
			}
		}

		private void SetActiveState(bool state)
		{
			foreach (var actionItem in this.ActionItems)
			{
				if (actionItem.Active != state)
				{
					actionItem.Active = state;
				}
			}

			this.SaveToSettings();
			this.PopulateActionList();
		}

		/// <exception cref="ArgumentOutOfRangeException"><c>layout</c> is out of range.</exception>
		private void SetColumns(string layout)
		{
			var layoutType = LayoutTypes.Default;
			try
			{
				layoutType = (LayoutTypes)Enum.Parse(typeof(LayoutTypes), layout, true);
				layout = layoutType.ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("Unknown layout mode", "Unable to set layout mode to '" + layout + "' resetting to default layout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			foreach (ToolStripMenuItem item in this.displayToolStripMenuItem.DropDownItems)
			{
				item.Checked = string.Compare(item.Tag.ToString(), layout, StringComparison.OrdinalIgnoreCase) == 0;
			}

			this.ActionList.Columns.Clear();
			switch (layoutType)
			{
				case LayoutTypes.Default:
					this.ActionList.Columns.AddRange(new[]
						                                 {
							                                 this.chSeek, this.chReplace, this.chComment, this.chHitCount
						                                 });
					break;
				case LayoutTypes.ExecutionOrder:
					this.ActionList.Columns.AddRange(new[]
						                                 {
							                                 this.chExecutionOrder, this.chGroup, this.chSeek, this.chReplace
						                                 });
					break;
				case LayoutTypes.All:
					this.ActionList.Columns.AddRange(new[]
						                                 {
							                                 this.chSeek, this.chReplace, this.chGroup, this.chComment, this.chHitCount, this.chExecutionOrder, this.chHostOnly, this.chIgnoreCase, this.chIsRegEx, this.chActive
						                                 });
					break;
				case LayoutTypes.Simpel:
					this.ActionList.Columns.AddRange(new[]
						                                 {
							                                 this.chSeek, this.chReplace, this.chHitCount
						                                 });
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(layout));
			}

			Settings.Default.DisplayMode = layoutType.ToString();
			Settings.Default.Save();
			this.ActionList.Refresh();

			this.hitCountColumn = this.chHitCount.Index;
			this.PopulateActionList();
		}

		private void SetEnabledState(bool state)
		{
			this.chkEnabled.Checked = state;
			this.enabledMenuItem.Checked = state;
			this.HostTab.ImageIndex = state ? 18 : 17;

			// I know this is done by the databinding but not untill it's to late...
			Settings.Default.UrlReplaceEnabled = state;
			Settings.Default.Save();
			this.DoStatusChanged("Bulk url replace " + (state ? "enabled" : "disabled"));
		}

		private void SetGroupString(string value)
		{
			foreach (ToolStripMenuItem item in this.groupByToolStripMenuItem.DropDownItems)
			{
				item.Checked = string.Compare(item.Tag.ToString(), value, StringComparison.OrdinalIgnoreCase) == 0;
			}

			this.groupString = value;
			Settings.Default.GroupeMode = value;
			Settings.Default.Save();
			this.PopulateActionList();
		}

		private void UpdateItemValues(ActionItem list, ListViewItem value)
		{
			var groupName = string.Format(this.groupString, list);
			var lowerGroupName = groupName.ToLower();
			if (this.ActionList.Groups[lowerGroupName] == null)
			{
				this.ActionList.Groups.Add(lowerGroupName, groupName);
			}

			value.Group = this.ActionList.Groups[lowerGroupName];

			var offset = 0;
			foreach (ColumnHeader column in this.ActionList.Columns)
			{
				value.SubItems[offset].Text = string.Format(column.Tag.ToString(), list);
				offset++;
			}

			if (list.HitCount > 0)
			{
				value.Font = new Font(value.Font, value.Font.Style | FontStyle.Bold);
			}

			value.Tag = list;
			value.Checked = list.Active;
			value.ImageIndex = list.IsRegEx ? 1 : 0;
		}
	}
}