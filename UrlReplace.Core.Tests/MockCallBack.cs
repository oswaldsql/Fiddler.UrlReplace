namespace UrlReplace.Core.Tests
{
	public class MockCallBack : IProcessorCallbackObject
	{
		public int ClearCount { get; set; }

		public int HelpCount { get; set; }

		public int LoadCount { get; set; }

		public int MergeCount { get; set; }

		public int SaveCount { get; set; }

		public bool Clear()
		{
			this.ClearCount += 1;
			return true;
		}

		public void DisplayHelp()
		{
			this.HelpCount += 1;
		}

		public string Load()
		{
			this.LoadCount += 1;
			return "<ArrayOfActionItem/>";
		}

		public string Merge()
		{
			this.MergeCount += 1;
			return "<ArrayOfActionItem/>";
		}

		public void Save(string serialized)
		{
			this.SaveCount += 1;
		}
	}
}