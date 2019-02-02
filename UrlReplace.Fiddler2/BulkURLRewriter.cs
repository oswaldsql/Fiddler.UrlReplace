using Fiddler;

[assembly: RequiredVersion("2.2.4.6")]

namespace UrlReplace
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using Fiddler;

	public class BulkUrlRewriter : IAutoTamper, IHandleExecAction
	{
		private BulkUrlReplace applicationInterface;

		private TabPage hostTabPage;

		private bool markingInProgress;

		public void AutoTamperRequestAfter(Session oSession)
		{
		}

		public void AutoTamperRequestBefore(Session oSession)
		{
			if (this.applicationInterface != null)
			{
				if (this.applicationInterface.HandelReplace(oSession.fullUrl, oSession.id, out var result))
				{
					oSession.url = result;
				}
			}
		}

		public void AutoTamperResponseAfter(Session oSession)
		{
		}

		public void AutoTamperResponseBefore(Session oSession)
		{
		}

		public void OnBeforeReturningError(Session oSession)
		{
		}

		public void OnBeforeUnload()
		{
		}

		public bool OnExecAction(string sCommand)
		{
			if (sCommand.StartsWith("urlreplace", StringComparison.InvariantCultureIgnoreCase))
			{
				return this.applicationInterface.HandelExecAction(sCommand);
			}

			return false;
		}

		public void OnLoad()
		{
			this.applicationInterface = new BulkUrlReplace();
			this.hostTabPage = new TabPage("Url Replace")
				                   {
					                   ImageIndex = this.applicationInterface.chkEnabled.Checked ? 18 : 17
				                   };
			this.hostTabPage.Controls.Add(this.applicationInterface);
			this.applicationInterface.HostTab = this.hostTabPage;
			this.applicationInterface.Dock = DockStyle.Fill;
			this.applicationInterface.StatusChanged += this.UrlReplaceStatusChanged;
			this.applicationInterface.MarkSessions += this.UrlReplaceMarkSessions;

			this.applicationInterface.EnabledChanged += this.UrlReplaceVisibleChanged;

			FiddlerApplication.UI.tabsViews.TabPages.Add(this.hostTabPage);
			FiddlerApplication.UI.mnuTools.MenuItems.Add(this.applicationInterface.MenuItem);
			FiddlerApplication.UI.lvSessions.SelectedIndexChanged += this.LvSessionsSelectedIndexChanged;
			FiddlerApplication.UI.lvSessions.Invalidated += this.LvSessionsInvalidated;
		}

		private void LvSessionsInvalidated(object sender, InvalidateEventArgs e)
		{
			// believe me this is not my preferred way of dealing with a sessionid reset, but no events are thrown when doing this so I'm forced to do it like this
			if (FiddlerApplication.UI.lvSessions.Items.Count == 0)
			{
				this.applicationInterface.ResetSessionIds();
			}
		}

		private void LvSessionsSelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.markingInProgress)
			{
				return;
			}

			this.markingInProgress = true;

			var source = sender as ListView;
			if (source != null)
			{
				var sessionId = new List<int>();
				foreach (ListViewItem item in source.SelectedItems)
				{
					sessionId.Add(((Session)item.Tag).id);
				}

				this.applicationInterface.MarkItemsWithSessionId(sessionId.ToArray());
			}

			this.markingInProgress = false;
		}

		private void UrlReplaceMarkSessions(object sender, MarkSessionsEventArgs e)
		{
			if (this.markingInProgress)
			{
				return;
			}

			this.markingInProgress = true;

			var sessionList = new List<int>(e.SessionIds);
			foreach (ListViewItem item in FiddlerApplication.UI.lvSessions.Items)
			{
				if (item.Tag is Session)
				{
					item.Selected = sessionList.Contains(((Session)item.Tag).id);
				}
			}

			this.markingInProgress = false;
		}

		private void UrlReplaceStatusChanged(object sender, StatusChangedEventArgs e)
		{
			FiddlerApplication.UI.sbpInfo.Text = e.Status;
		}

		private void UrlReplaceVisibleChanged(object sender, EventArgs e)
		{
			if (this.applicationInterface.Enabled)
			{
				if (!FiddlerApplication.UI.tabsViews.TabPages.Contains(this.hostTabPage))
				{
					FiddlerApplication.UI.tabsViews.TabPages.Add(this.hostTabPage);
				}
			}
			else
			{
				if (FiddlerApplication.UI.tabsViews.TabPages.Contains(this.hostTabPage))
				{
					FiddlerApplication.UI.tabsViews.TabPages.Remove(this.hostTabPage);
				}
			}
		}
	}
}