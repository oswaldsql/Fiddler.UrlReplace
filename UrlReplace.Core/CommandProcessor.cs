namespace UrlReplace.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;

	public class CommandProcessor
	{
		private static readonly Dictionary<string, Action<CommandProcessor>> Commands;

		private static readonly Dictionary<string, Action<ActionItem>> Options;

		private readonly ActionItems model;

		static CommandProcessor()
		{
			Options = new Dictionary<string, Action<ActionItem>>(StringComparer.InvariantCultureIgnoreCase)
				          {
					          {
						          string.Empty, item =>
							          {
							          }
					          },
					          {
						          "/r", item => item.IsRegEx = true
					          },
					          {
						          "/a", item => item.Active = true
					          },
					          {
						          "/d", item => item.Active = false
					          },
					          {
						          "/i", item => item.IgnoreCase = true
					          },
					          {
						          "/c", item => item.IgnoreCase = false
					          },
					          {
						          "/h", item => item.HostOnly = true
					          }
				          };
			Commands = new Dictionary<string, Action<CommandProcessor>>(StringComparer.InvariantCultureIgnoreCase)
				           {
					           {
						           "?", t => t.DisplayHelpCallback.Invoke()
					           },
					           {
						           "/?", t => t.DisplayHelpCallback.Invoke()
					           },
					           {
						           "help", t => t.DisplayHelpCallback.Invoke()
					           },
					           {
						           "load", t => t.model.Load(t.LoadCallback.Invoke())
					           },
					           {
						           "merge", t => t.model.Merge(t.MergeCallback.Invoke())
					           },
					           {
						           "save", t => t.SaveCallback.Invoke(t.model.Serialize())
					           },
					           {
						           "clear", t =>
							           {
								           if (t.ClearCallback.Invoke())
								           {
									           t.model.Clear();
								           }
							           }
					           }
				           };
		}

		public CommandProcessor(ActionItems actionItems, IProcessorCallbackObject callbackObject)
			: this(actionItems)
		{
			this.DisplayHelpCallback = callbackObject.DisplayHelp;
			this.LoadCallback = callbackObject.Load;
			this.MergeCallback = callbackObject.Merge;
			this.SaveCallback = callbackObject.Save;
			this.ClearCallback = callbackObject.Clear;
		}

		public CommandProcessor(ActionItems actionItems)
		{
			this.model = actionItems;
		}

		public Func<bool> ClearCallback { get; set; }

		public Action DisplayHelpCallback { get; set; }

		public Func<string> LoadCallback { get; set; }

		public Func<string> MergeCallback { get; set; }

		public Action<string> SaveCallback { get; set; }

		public bool Process(string command)
		{
			if (!command.Trim().StartsWith("urlreplace", StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}

			var regex = new Regex("(\"[^\"]+\"|[^ ]+)");

			var split = regex.Matches(command)
				.OfType<Match>()
				.Select(match => match.Value.Trim('"'))
				.ToArray();

			switch (split.Length)
			{
				case 1:
					this.model.Enabled = !this.model.Enabled;
					return true;
				case 2:
					return this.HandleSingleCommand(split[1]);
				default:
					return this.HandelMultiCommand(split);
			}
		}

		private bool HandelMultiCommand(string[] split)
		{
			var result = Factory.ActionItem();
			result.Active = true;
			result.Seek = split.TakeAndBlank(1);
			result.Replace = split.TakeAndBlank(2);

			split[0] = string.Empty;
			if (split.Length > 3 && !split[3].StartsWith("/"))
			{
				result.Group = split.TakeAndBlank(3);
				if (split.Length > 4 && !split[4].StartsWith("/"))
				{
					result.Comment = split.TakeAndBlank(4);
				}
			}

			foreach (var subCommand in split)
			{
				if (Options.TryGetValue(subCommand, out var action))
				{
					action.Invoke(result);
				}
				else
				{
					this.DisplayHelpCallback.Invoke();
					return false;
				}
			}

			this.model.Add(result);

			return true;
		}

		private bool HandleSingleCommand(string split)
		{
			if (!Commands.TryGetValue(split, out var action))
			{
				this.DisplayHelpCallback.Invoke();
				return false;
			}

			action.Invoke(this);
			return true;
		}
	}
}