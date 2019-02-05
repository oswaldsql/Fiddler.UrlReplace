namespace UrlReplace
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;

	using UrlReplace.Core;

	public partial class BulkUrlReplace : UserControl
	{
		private MenuItem enabledMenuItem;

		private MenuItem shownMenuItem;

		public BulkUrlReplace()
		{
			this.InitializeComponent();
			this.ActionItems = Factory.ActionItems();
			this.ActionItems.ListChanged += this.ActionItemsListChanged;
			this.LoadFromSettings();
			this.CreateMenuItems();
		}

		public MenuItem MenuItem { get; private set; }

		private static void HelpClick(object sender, EventArgs e)
		{
			Process.Start("https://github.com/oswaldsql/Fiddler.UrlReplace");
		}

		/// <exception cref="ArgumentOutOfRangeException">
		///     <c /> is out of range.
		/// </exception>
		private void ActionItemsListChanged(object sender, ActionListChangedEventArgs e)
		{
			this.SaveToSettings();
			switch (e.ChangeType)
			{
				case ActionListChangeType.Added:
					this.AddActionItemToActionList(e.Item);
					break;
				case ActionListChangeType.Changed:
					this.UpdateItemValues(e.Item, this.ActionList.Items[e.Item.Key]);
					break;
				case ActionListChangeType.Removed:
					this.ActionList.Items.Remove(this.ActionList.Items[e.Item.Key]);
					break;
				case ActionListChangeType.Reset:
					this.PopulateActionList();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void ActionListColumnClick(object sender, ColumnClickEventArgs e)
		{
			this.ChangeSortColumn(e.Column);
		}

		private void ActionListItemChecked(object sender, ItemCheckedEventArgs e)
		{
			this.SetActionItemActiveState((ActionItem)e.Item.Tag, e.Item.Checked);
			this.SaveToSettings();
		}

		private void AddClick(object sender, EventArgs e)
		{
			this.AddNewActionItem();
		}

		private void BulkUrlReplaceClick(object sender, EventArgs e)
		{
			Process.Start("https://github.com/oswaldsql/Fiddler.UrlReplace");
		}

		private void BulkUrlReplaceSizeChanged(object sender, EventArgs e)
		{
			this.ActionList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void CheckForUpdatesClick(object sender, EventArgs e)
		{
			Process.Start("https://github.com/oswaldsql/Fiddler.UrlReplace?title=version" + this.GetType().Assembly.GetName().Version + "&referringTitle=Versions");
		}

		private void ChkEnabledCheckedChanged(object sender, EventArgs e)
		{
			this.SetEnabledState(this.chkEnabled.Checked);
		}

		private void ClearClick(object sender, EventArgs e)
		{
			this.ClearActionItems();
		}

		private void CommandLineHelpClick(object sender, EventArgs e)
		{
			this.DisplayHelp();
		}

		private void ContextMenuOpening(object sender, CancelEventArgs e)
		{
			this.editToolStripMenuItem.Enabled = this.ActionList.SelectedItems.Count == 1;
			this.removeToolStripMenuItem.Enabled = this.ActionList.SelectedItems.Count > 0;
			this.clearToolStripMenuItem.Enabled = this.ActionList.Items.Count > 0;
			this.saveToolStripMenuItem.Enabled = this.ActionList.Items.Count > 0;
		}

		private void DisableAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.SetActiveState(false);
		}

		private void DisplayToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			this.SetColumns(e.ClickedItem.Tag.ToString());
		}

		private void EditClick(object sender, EventArgs e)
		{
			this.EditSelectedItem();
		}

		private void EnableAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.SetActiveState(true);
		}

		private void EnabledMenuItemClick(object sender, EventArgs e)
		{
			if (!this.shownMenuItem.Checked)
			{
				var result = MessageBox.Show("The UrlReplace UI is not currently shown. Do you wish to show the UI while enabling UrlReplace?", "Show UrlReplace UI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						this.ShownMenuItemClick(null, null);
						break;
					case DialogResult.No:
						break;
				}
			}

			this.enabledMenuItem.Checked = !this.enabledMenuItem.Checked;
			this.chkEnabled.Checked = this.enabledMenuItem.Checked;
		}

		private void GroupByToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			this.SetGroupString(e.ClickedItem.Tag.ToString());
		}

		private void ListActionHit(object sender, EventArgs e)
		{
			this.MarkActionHit(sender as ActionItem);
		}

		private void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			this.MarkSelectedActionItems();
		}

		private void LoadClick(object sender, EventArgs e)
		{
			this.LoadActionItems();
		}

		private void MergeClick(object sender, EventArgs e)
		{
			this.MergeActionItems();
		}

		private void RemoveClick(object sender, EventArgs e)
		{
			this.RemoveActionItem();
		}

		private void ResetHitcountToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.ActionItems.ResetHitCount();
			this.PopulateActionList();
		}

		private void SaveClick(object sender, EventArgs e)
		{
			this.SaveActionItems();
		}

		private void ShownMenuItemClick(object sender, EventArgs e)
		{
			var show = !this.shownMenuItem.Checked;
			if (this.chkEnabled.Checked && !show)
			{
				var result = MessageBox.Show("UrlReplace is currently enabled.\nDo you want to disable the functionality while hiding the UI?", "Disable UrlReplace?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						{
							this.EnabledMenuItemClick(null, null);
						}

						break;
					case DialogResult.No:
						break;
				}
			}

			this.shownMenuItem.Checked = show;
			this.Enabled = show;
		}

		private void ActionList_ItemDrag(object sender, ItemDragEventArgs e)
		{

		}

		private void ActionList_DragEnter(object sender, DragEventArgs e)
		{
			var test = e.Data.GetData("Fiddler.Session[]") as Fiddler.Session[];
			if (test != null && test.Length == 1)
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void ActionList_DragDrop(object sender, DragEventArgs e)
		{
			var test = e.Data.GetData("Fiddler.Session[]") as Fiddler.Session[];
			if (test != null && test.Length == 1)
			{
				var positionInForm = this.GetPositionInForm(this.ActionList);
				var listViewItem = this.ActionList.GetItemAt(e.X + positionInForm.X, e.Y - positionInForm.Y)?.Tag as ActionItem;

				e.Effect = DragDropEffects.Link;

				var actionItem = Factory.ActionItem();
				actionItem.Seek = test.First().fullUrl;
				if (listViewItem != null)
				{
					actionItem.Group = listViewItem.Group;
				}

				var editUrlReplace = new EditUrlReplace
					                     {
						                     ActionItems = this.ActionItems, ActionItem = actionItem, Mode = EditMode.Add
					                     };
				editUrlReplace.Show();
				editUrlReplace.Closing += this.EditUrlReplaceClosing;
			}
		}

		public Point GetPositionInForm(Control ctrl)
		{
			Point p = ctrl.Location;
			Control parent = ctrl.Parent;
			while (! (parent is Form))
			{
				p.Offset(parent.Location.X, parent.Location.Y);
				parent = parent.Parent;
			}
			return p;
		}

		private void ActionList_DragOver(object sender, DragEventArgs e)
		{
		}
	}
}