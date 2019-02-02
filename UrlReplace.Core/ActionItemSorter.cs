namespace UrlReplace.Core
{
	using System;
	using System.Collections.Generic;

	public class ActionItemSorter : IComparer<ActionItem>
	{
		public int Compare(ActionItem x, ActionItem y)
		{
			if (x == null || y == null)
			{
				throw new ArgumentException();
			}

			return x.Index.CompareTo(y.Index);
		}
	}
}