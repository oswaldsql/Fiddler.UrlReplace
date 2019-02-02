namespace UrlReplace.Core
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml;
	using System.Xml.Serialization;

	public class ActionItems : IEnumerable<ActionItem>
	{
		private readonly List<ActionItem> internalList = new List<ActionItem>();

		internal ActionItems()
		{
			this.Enabled = true;
		}

		public event EventHandler<ActionListChangedEventArgs> ListChanged;

		public int Count => this.internalList.Count;

		public bool Enabled { get; set; }

		public void Add(ActionItem actionItem)
		{
			this.internalList.Add(actionItem);
			this.ReindexInternalList();
			this.DoListChanged(ActionListChangeType.Added, actionItem);
		}

		public void Clear()
		{
			this.internalList.Clear();
			this.DoListChanged(ActionListChangeType.Reset, null);
		}

		public void DeserializeFromStream(XmlReader reader, bool merge)
		{
			var serialize = new XmlSerializer(typeof(ActionItem[]));
			var result = (ActionItem[])serialize.Deserialize(reader);
			if (!merge)
			{
				this.internalList.Clear();
			}

			this.internalList.AddRange(result);

			this.ReindexInternalList();

			this.DoListChanged(ActionListChangeType.Reset, null);
		}

		public bool ExecuteReplace(Uri url, int sessionId, out Uri result)
		{
			result = url;

			if (this.Enabled)
			{
				foreach (var actionItem in this.internalList)
				{
					if (actionItem.DoReplace(ref result, sessionId))
					{
						return true;
					}
				}
			}

			return false;
		}

		public IEnumerator<ActionItem> GetEnumerator()
		{
			return this.internalList.GetEnumerator();
		}

		public void Load(string serialized)
		{
			var reader = new XmlTextReader(new StringReader(serialized));
			this.DeserializeFromStream(reader, false);
		}

		public void Merge(string serialized)
		{
			var reader = new XmlTextReader(new StringReader(serialized));
			this.DeserializeFromStream(reader, true);
		}

		public void MoveToIndex(ActionItem[] items, double offset)
		{
			if (items.Length > 999)
			{
				return;
			}

			var newIndex = offset + 0.01;
			foreach (var item in items)
			{
				item.Index = newIndex++;
			}

			this.internalList.Sort(new ActionItemSorter());
			this.ReindexInternalList();
		}

		public void Remove(ActionItem actionItem)
		{
			this.internalList.Remove(actionItem);
			this.DoListChanged(ActionListChangeType.Removed, actionItem);
		}

		public void ResetHitCount()
		{
			foreach (var item in this.internalList)
			{
				item.ResetHitCount();
			}
		}

		public void ResetSessionIds()
		{
			foreach (var item in this.internalList)
			{
				item.SessionIds.Clear();
			}
		}

		public string Serialize()
		{
			using (var sw = new StringWriter())
			{
				var settings = new XmlWriterSettings
					               {
						               OmitXmlDeclaration = true
					               };
				using (var xw = XmlWriter.Create(sw, settings))
				{
					this.SerializeToStream(xw);
				}

				return sw.ToString();
			}
		}

		public void SerializeToStream(XmlWriter writer)
		{
			var ns = new XmlSerializerNamespaces();
			ns.Add(string.Empty, string.Empty);

			var serializer = new XmlSerializer(typeof(ActionItem[]));
			serializer.Serialize(writer, this.internalList.ToArray(), ns);
			writer.Flush();
			writer.Close();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private void DoListChanged(ActionListChangeType changeType, ActionItem actionItem)
		{
			this.ListChanged?.Invoke(this, new ActionListChangedEventArgs(changeType, actionItem));
		}

		private void ReindexInternalList()
		{
			var offset = 1;
			foreach (var item in this.internalList)
			{
				item.Index = offset++;
			}
		}
	}
}