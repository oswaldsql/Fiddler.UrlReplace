namespace UrlReplace
{
	using System;

	public class StatusChangedEventArgs : EventArgs
	{
		public StatusChangedEventArgs(string status)
		{
			this.Status = status;
		}

		public string Status { get; }
	}
}