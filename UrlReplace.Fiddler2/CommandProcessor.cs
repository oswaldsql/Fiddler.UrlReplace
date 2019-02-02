namespace UrlReplace
{
	using System;

	using UrlReplace.Core;

	public class CommandProcessor
	{
		public BulkUrlReplace Parent { get; set; }

		public bool Process(string command)
		{
			if (!command.Trim().StartsWith("urlreplace", StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}

			var split = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			switch (split.Length)
			{
				case 1:
					this.Parent.InvertEnabledState();
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
			var offset = 0;
			foreach (var subCommand in split)
			{
				if (subCommand.StartsWith("/"))
				{
					switch (subCommand)
					{
						case "/r":
							result.IsRegEx = true;
							break;
						case "/a":
							result.Active = true;
							break;
						case "/d":
							result.Active = false;
							break;
						case "/i":
							result.IgnoreCase = true;
							break;
						case "/c":
							result.IgnoreCase = false;
							break;
					}
				}
				else
				{
					switch (offset)
					{
						case 0:
							// This is the url replace itself
							break;
						case 1:
							result.Seek = subCommand;
							break;
						case 2:
							result.Replace = subCommand;
							break;
						case 3:
							result.Group = subCommand;
							break;
						case 4:
							result.Comment = subCommand;
							break;
						default:
							return false;
					}

					offset++;
				}
			}

			if ((offset > 2) & (offset < 6))
			{
				this.Parent.ActionItems.Add(result);
			}
			else
			{
				this.Parent.DisplayHelp();
			}

			return true;
		}

		private bool HandleSingleCommand(string split)
		{
			switch (split.ToLowerInvariant())
			{
				case "?":
				case "/?":
				case "help":
					this.Parent.DisplayHelp();
					break;
				case "load":
					this.Parent.LoadActionItems();
					break;
				case "merge":
					this.Parent.MergeActionItems();
					break;
				case "save":
					this.Parent.SaveActionItems();
					break;
				case "clear":
					this.Parent.ClearActionItems();
					break;
				default:
					return false;
			}

			return true;
		}
	}
}