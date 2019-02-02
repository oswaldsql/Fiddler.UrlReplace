namespace UrlReplace.Core
{
	public interface IProcessorCallbackObject
	{
		bool Clear();

		void DisplayHelp();

		string Load();

		string Merge();

		void Save(string serialized);
	}
}