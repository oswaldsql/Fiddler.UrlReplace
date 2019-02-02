namespace UrlReplace
{
	using System;
	using System.Collections;
	using System.Windows.Forms;

	public class ListViewItemComparer : IComparer
	{
		private readonly int column;

		private readonly bool desc;

		public ListViewItemComparer(int column, bool desc)
		{
			this.column = column;
			this.desc = desc;
		}

		public int Compare(object x, object y)
		{
			var xSubItems = ((ListViewItem)x)?.SubItems;
			var ySubItems = ((ListViewItem)y)?.SubItems;
			var result = 0;
			if ((xSubItems?.Count > this.column) & (ySubItems?.Count > this.column))
			{
				result = StringComparer.CurrentCultureIgnoreCase.Compare(xSubItems[this.column].Text, ySubItems[this.column].Text);
			}

			return this.desc ? -result : result;
		}
	}
}