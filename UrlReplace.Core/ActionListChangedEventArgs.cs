namespace UrlReplace.Core
{
	using System;

	public class ActionListChangedEventArgs : EventArgs
	{
		public ActionListChangedEventArgs(ActionListChangeType changeType, ActionItem item)
		{
			this.ChangeType = changeType;
			this.Item = item;
		}

		public ActionListChangeType ChangeType { get; }

		public ActionItem Item { get; }
	}
}