namespace UrlReplace.Core.Tests
{
	using System.Diagnostics;
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class CommandProcessorTests
	{
		public ActionItem BaseSettingOptionsFromCommand(string option)
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			processor.Process("UrlReplace Seek Replace " + option);

			return model.First();
		}

		[Test]
		public void CreateSimpleActionFromCommand()
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			var process = processor.Process("UrlReplace Seek Replace Group_1");

			Assert.That(process, Is.True);

			Assert.That(model.Count, Is.EqualTo(1));
			Assert.That(model.First().Seek, Is.EqualTo("Seek"));
			Assert.That(model.First().Replace, Is.EqualTo("Replace"));
			Assert.That(model.First().Group, Is.EqualTo("Group_1"));
		}

		[Test]
		public void InvalidOptionsShouldDisplayHelp()
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			var callback = 0;
			processor.DisplayHelpCallback = () => callback++;

			var process = processor.Process("UrlReplace Seek Replace /q");

			Assert.That(process, Is.False);
			Assert.That(callback, Is.EqualTo(1));
		}

		[Test]
		public void InvokingCallbackUsingInterface()
		{
			var model = Factory.ActionItems();

			var callbackObject = new MockCallBack();
			var processor = new CommandProcessor(model, callbackObject);

			processor.Process("UrlReplace ?");
			processor.Process("UrlReplace /?");
			processor.Process("UrlReplace Help");
			processor.Process("UrlReplace Load");
			processor.Process("UrlReplace Merge");
			processor.Process("UrlReplace Save");
			processor.Process("UrlReplace Clear");

			Assert.That(callbackObject.HelpCount, Is.EqualTo(3));
			Assert.That(callbackObject.LoadCount, Is.EqualTo(1));
			Assert.That(callbackObject.MergeCount, Is.EqualTo(1));
			Assert.That(callbackObject.SaveCount, Is.EqualTo(1));
			Assert.That(callbackObject.ClearCount, Is.EqualTo(1));
		}

		[Test]
		public void ParseComplexGroupAndDescriptionFromCommand()
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			var process = processor.Process("UrlReplace Seek Replace \"Group 1\" \"This is the comment\"");

			Assert.That(process, Is.True);

			Assert.That(model.Count, Is.EqualTo(1));
			Assert.That(model.First().Seek, Is.EqualTo("Seek"));
			Assert.That(model.First().Replace, Is.EqualTo("Replace"));
			Assert.That(model.First().Group, Is.EqualTo("Group 1"));
			Assert.That(model.First().Comment, Is.EqualTo("This is the comment"));
		}

		[Test]
		public void SettingNoOptionsShouldGiveDefaultSettings()
		{
			var sut = this.BaseSettingOptionsFromCommand(string.Empty);
			Assert.That(sut.Active, Is.True);
			Assert.That(sut.HostOnly, Is.False);
			Assert.That(sut.IgnoreCase, Is.True);
			Assert.That(sut.IsRegEx, Is.False);
			Assert.That(sut.HostOnly, Is.False);
		}

		[Test]
		public void SlashAOption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/a");
			Assert.That(actionItem.Active, Is.True);
		}

		[Test]
		public void SlashCOption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/c");
			Assert.That(actionItem.IgnoreCase, Is.False);
		}

		[Test]
		public void SlashDOption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/d");
			Assert.That(actionItem.Active, Is.False);
		}

		[Test]
		public void SlashHOption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/h");
			Assert.That(actionItem.HostOnly, Is.True);
		}

		[Test]
		public void SlashIOption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/i");
			Assert.That(actionItem.IgnoreCase, Is.True);
		}

		[Test]
		public void SlashROption()
		{
			var actionItem = this.BaseSettingOptionsFromCommand("/r");
			Assert.That(actionItem.IsRegEx, Is.True);
		}

		[Test]
		public void TriggerClearFromCommand()
		{
			var model = Factory.ActionItems();
			model.Add(Factory.ActionItem());

			Assert.That(model.Count, Is.EqualTo(1));

			var processor = new CommandProcessor(model);
			var callbackCount = 0;
			processor.ClearCallback = () =>
				{
					callbackCount++;
					return true;
				};
			processor.Process("URLReplace clear");
			Assert.That(callbackCount, Is.EqualTo(1));
			Assert.That(model.Count, Is.EqualTo(0));
		}

		[Test]
		public void TriggerHelpFromCommand()
		{
			var processor = new CommandProcessor(null);
			var callbackCount = 0;
			processor.DisplayHelpCallback = () => callbackCount++;
			processor.Process("URLReplace ?");
			processor.Process("URLReplace /?");
			processor.Process("URLReplace Help");
			Assert.That(callbackCount, Is.EqualTo(3));
		}

		[Test]
		public void TriggerInRelevantCommandFromCommand()
		{
			var processor = new CommandProcessor(null);
			var process = processor.Process("Nothing");

			Assert.That(process, Is.False);
		}

		[Test]
		public void TriggerLoadFromCommand()
		{
			var model = Factory.ActionItems();
			model.Add(Factory.ActionItem());
			model.Add(Factory.ActionItem());

			var processor = new CommandProcessor(model);

			processor.LoadCallback = () => "<ArrayOfActionItem><ActionItem Replace=\"\" Seek=\"\" /></ArrayOfActionItem>";

			processor.Process("URLReplace load");

			Assert.That(model.Count, Is.EqualTo(1));
		}

		[Test]
		public void TriggerMergeFromCommand()
		{
			var model = Factory.ActionItems();
			model.Add(Factory.ActionItem());
			model.Add(Factory.ActionItem());

			var processor = new CommandProcessor(model);

			processor.MergeCallback = () => "<ArrayOfActionItem><ActionItem Replace=\"\" Seek=\"\" /></ArrayOfActionItem>";

			processor.Process("URLReplace merge");

			Assert.That(model.Count, Is.EqualTo(3));
		}

		[Test]
		public void TriggerOnOffFromCommand()
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			Assert.That(model.Enabled, Is.True);

			processor.Process("URLReplace");

			Assert.That(model.Enabled, Is.False);

			processor.Process("URLReplace");

			Assert.That(model.Enabled, Is.True);
		}

		[Test]
		public void TriggerSaveFromCommand()
		{
			var model = Factory.ActionItems();
			model.Add(Factory.ActionItem());
			model.Add(Factory.ActionItem());

			var processor = new CommandProcessor(model);

			var serialized = string.Empty;
			processor.SaveCallback = s => serialized = s;

			processor.Process("URLReplace save");

			Debug.WriteLine(serialized);
			Assert.That(serialized, Is.Not.EqualTo(string.Empty));
		}

		[Test]
		public void UnknownSingleCommandHandeling()
		{
			var model = Factory.ActionItems();

			var processor = new CommandProcessor(model);

			var callback = 0;
			processor.DisplayHelpCallback = () => callback++;

			var process = processor.Process("URLReplace unknown");

			Assert.That(process, Is.False);
			Assert.That(callback, Is.EqualTo(1));
		}
	}
}