namespace UrlReplace.Core
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Text.RegularExpressions;
	using System.Xml.Serialization;

	[Serializable]
	public class ActionItem : IFormattable
	{
		private bool ignoreCase;

		private bool isRegEx;

		private Regex regex;

		private string seek;

		internal ActionItem()
		{
			this.HostOnly = false;
			this.Key = Guid.NewGuid()
				.ToString();
			this.Seek = string.Empty;
			this.Replace = string.Empty;
			this.Group = string.Empty;
			this.Active = true;
			this.IsRegEx = false;
			this.IgnoreCase = true;
			this.Comment = string.Empty;
			this.regex = null;
			this.SessionIds = new List<int>();
		}

		public event EventHandler<EventArgs> ActionHit;

		[XmlAttribute]
		[DefaultValue(true)]
		public bool Active { get; set; }

		[XmlAttribute]
		[DefaultValue("")]
		public string Comment { get; set; }

		[XmlAttribute]
		[DefaultValue("")]
		public string Group { get; set; }

		[XmlIgnore]
		public long HitCount { get; private set; }

		[XmlAttribute]
		[DefaultValue(false)]
		public bool HostOnly { get; set; }

		[XmlAttribute]
		[DefaultValue(true)]
		public bool IgnoreCase
		{
			get => this.ignoreCase;
			set
			{
				this.ignoreCase = value;
				this.RefreshRegEx();
			}
		}

		[XmlIgnore]
		public double Index { get; set; }

		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsRegEx
		{
			get => this.isRegEx;
			set
			{
				this.isRegEx = value;
				this.RefreshRegEx();
			}
		}

		public string Key { get; }

		[XmlAttribute]
		public string Replace { get; set; }

		[XmlAttribute]
		public string Seek
		{
			get => this.seek;
			set
			{
				this.seek = value;
				this.RefreshRegEx();
			}
		}

		[XmlIgnore]
		public List<int> SessionIds { get; }

		public bool DoReplace(ref Uri url, int sessionId)
		{
			if (string.IsNullOrEmpty(this.Seek) || !this.Active)
			{
				return false;
			}

			var source = this.HostOnly ? url.Authority : url.ToString();
			var result = string.Empty;
			var isMatch = false;

			if (!this.IsRegEx)
			{
				var comparison = this.IgnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
				if (source.IndexOf(this.Seek, comparison) != -1)
				{
					result = source;
					var stringIndex = result.IndexOf(this.Seek, comparison);
					var seekLength = this.Seek.Length;
					while (stringIndex > -1)
					{
						result = result.Substring(0, stringIndex) + this.Replace + result.Substring(stringIndex + seekLength);
						stringIndex = result.IndexOf(this.Seek, stringIndex + this.Replace.Length, comparison);
					}

					isMatch = true;
				}
			}
			else
			{
				if (this.regex.IsMatch(source))
				{
					result = this.regex.Replace(source, this.Replace);
					isMatch = true;
				}
			}

			if (!isMatch)
			{
				return false;
			}

			if (this.HostOnly)
			{
				result = url.Scheme + "://" + result + url.PathAndQuery;
			}

			if (Uri.TryCreate(result, UriKind.Absolute, out var resultUrl))
			{
				url = resultUrl;
				this.SessionIds.Add(sessionId);
				this.RegisterActionHit();
				return true;
			}

			return false;
		}

		public void ResetHitCount()
		{
			this.HitCount = 0;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			switch (format.ToLower())
			{
				case "active":
					return this.Active.ToString(formatProvider);
				case "activestring":
					return this.Active ? "Active" : "Passive";
				case "comment":
					return this.Comment;
				case "group":
					return this.Group;
				case "hitcount":
					return this.HitCount.ToString(formatProvider);
				case "hostonly":
					return this.HostOnly.ToString(formatProvider);
				case "hostonlystring":
					return this.HostOnly ? "Host only" : "Full Url";
				case "ignorecase":
					return this.IgnoreCase.ToString(formatProvider);
				case "ignorecasestring":
					return this.IgnoreCase ? "Case Insensitive" : "Case Sensitive";
				case "index":
					return this.Index.ToString(formatProvider);
				case "regex":
					return this.IsRegEx.ToString(formatProvider);
				case "regexstring":
					return this.IsRegEx ? "Regular expression" : "Plain Text";
				case "replace":
					return this.Replace;
				case "seek":
					return this.Seek;
			}

			return format;
		}

		private void RefreshRegEx()
		{
			if (string.IsNullOrEmpty(this.Seek))
			{
				this.regex = null;
			}
			else
			{
				var options = this.IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
				this.regex = this.IsRegEx ? new Regex(this.Seek, options) : null;
			}
		}

		private void RegisterActionHit()
		{
			this.HitCount++;
			this.ActionHit?.Invoke(this, new EventArgs());
		}
	}
}