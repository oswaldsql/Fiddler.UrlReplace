namespace UrlReplace
{
	using System;

	public class MarkSessionsEventArgs : EventArgs
	{
		public MarkSessionsEventArgs(int[] sessionIds)
		{
			this.SessionIds = sessionIds;
		}

		public int[] SessionIds { get; }
	}
}