namespace UrlReplace
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;

	using UrlReplace.Core;
	using UrlReplace.Properties;

	public partial class EditUrlReplace : Form
	{
		private ActionItem actionItem;

		private EditMode mode = EditMode.Edit;

		public EditUrlReplace()
		{
			this.InitializeComponent();
		}

		public ActionItem ActionItem
		{
			get => this.actionItem;
			set
			{
				this.actionItem = value;

				this.chkActive.Checked = this.ActionItem.Active;
				this.chkIsRegEx.Checked = this.ActionItem.IsRegEx;
				this.chkIgnoreCase.Checked = this.ActionItem.IgnoreCase;
				this.chkHostrOnly.Checked = this.ActionItem.HostOnly;
				this.txtSeek.Text = this.ActionItem.Seek;
				this.txtReplace.Text = this.ActionItem.Replace;
				this.txtGroup.Text = this.ActionItem.Group;
				this.txtComment.Text = this.ActionItem.Comment;

				var indexValues = this.CreateIndexList();
				this.cbxIndex.DataSource = indexValues;
				this.cbxIndex.SelectedIndex = this.cbxIndex.Items.IndexOf(new KeyValuePair<string, double>("[Current position]", this.ActionItem.Index));

				this.ChkIsRegExCheckedChanged(null, null);
			}
		}

		public ActionItems ActionItems { get; set; }

		public EditMode Mode
		{
			get => this.mode;
			set
			{
				this.Text = value == EditMode.Add ? "Add UrlReplace" : "Edit UrlReplace";
				this.mode = value;
			}
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			this.ActionItem.Active = this.chkActive.Checked;
			this.ActionItem.IsRegEx = this.chkIsRegEx.Checked;
			this.ActionItem.IgnoreCase = this.chkIgnoreCase.Checked;
			this.ActionItem.HostOnly = this.chkHostrOnly.Checked;
			this.ActionItem.Seek = this.txtSeek.Text;
			this.ActionItem.Replace = this.txtReplace.Text;
			this.ActionItem.Group = this.txtGroup.Text;
			this.ActionItem.Comment = this.txtComment.Text;
			if (this.ActionItem.Index != (double)this.cbxIndex.SelectedValue)
			{
				this.ActionItem.Index = (double)this.cbxIndex.SelectedValue;
				this.ActionItems.MoveToIndex(new[]
					                             {
						                             this.ActionItem
					                             }, (double)this.cbxIndex.SelectedValue);
			}

			this.ActionItem.ResetHitCount();
			this.Close();
		}

		private void ChkIsRegExCheckedChanged(object sender, EventArgs e)
		{
			this.Icon = this.chkIsRegEx.Checked ? Resources.RegExReplace : Resources.TextReplace;
		}

		private List<KeyValuePair<string, double>> CreateIndexList()
		{
			var indexValues = new List<KeyValuePair<string, double>>();
			var isAfterItem = false;
			foreach (var item in this.ActionItems)
			{
				if (item == this.ActionItem)
				{
					indexValues.Add(new KeyValuePair<string, double>("[Current position]", item.Index));
					isAfterItem = true;
				}
				else if (!isAfterItem)
				{
					indexValues.Add(new KeyValuePair<string, double>("Before : " + item.Seek, item.Index - 1));
				}
				else
				{
					indexValues.Add(new KeyValuePair<string, double>("After : " + item.Seek, item.Index));
				}
			}

			if (this.ActionItem.Index == 0)
			{
				indexValues.Add(new KeyValuePair<string, double>("[Current position]", this.ActionItems.Count + 1));
				this.ActionItem.Index = this.ActionItems.Count + 1;
			}

			return indexValues;
		}

		private void ToolTipPopup(object sender, PopupEventArgs e)
		{
		}

		private void ValidateRegEx(object sender, EventArgs e)
		{
			if (this.chkIsRegEx.Checked)
			{
				try
				{
					var regex = new Regex(this.txtSeek.Text);
					var TestString = regex.Replace("http://www.fiddler.com/default.asp", this.txtReplace.Text);
					this.btnOk.Enabled = true;
				}
				catch
				{
					this.btnOk.Enabled = false;
				}
			}
		}
	}
}