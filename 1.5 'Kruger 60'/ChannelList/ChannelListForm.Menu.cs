// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using IpTviewr.ChannelList.Properties;
using IpTviewr.UiServices.Common.Forms;
using IpTviewr.UiServices.Configuration;
using IpTviewr.UiServices.Discovery.BroadcastList;
using System;
using System.Collections.Generic;

namespace IpTviewr.ChannelList
{
    partial class ChannelListForm
    {
        #region 'IPTViewr' menu event handlers

        private void menuItemDvbRecent_DropDownOpening(object sender, EventArgs e)
        {
            // TODO: update recent list
        }  // menuItemDvbRecent_DropDownOpening

        private void menuItemDvbRecent_Click(object sender, EventArgs e)
        {
            NotImplementedBox.ShowBox(this, "menuItemDvbRecent");
        }  // menuItemDvbRecent_Click

        private void menuItemDvbSettings_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemDvbSettings_Click, sender, e);
        } // menuItemDvbSettings_Click

        private void menuItemDvbExport_Click(object sender, EventArgs e)
        {
            NotImplementedBox.ShowBox(this, "menuItemDvbExport");
        } // menuItemDvbExport_Click

        private void menuItemDvbExit_Click(object sender, EventArgs e)
        {
            Close();
        } // menuItemDvbExit_Click

        #endregion

        #region 'IPTViewr' menu event handlers implementation

        private void Implementation_menuItemDvbSettings_Click(object sender, EventArgs e)
        {
            var applyChanges = new Dictionary<Guid, Action>(1);
            applyChanges.Add(UiBroadcastListSettingsRegistration.SettingsGuid, () =>
            {
                _listManager.Settings = UiBroadcastListSettingsRegistration.Settings;
            });

            ConfigurationForm.ShowConfigurationForm(this, true, applyChanges);
        } // menuItemDvbSettings_Click

        #endregion

        #region 'Help' menu event handlers

        private void menuItemHelpDocumentation_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemHelpDocumentation_Click, sender, e);
        } // menuItemHelpDocumentation_Click

        private void menuItemHelpHomePage_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemHelpHomePage_Click, sender, e);
        } // menuItemHelpHomePage_Click

        private void menuItemHelpReportIssue_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemHelpReportIssue_Click, sender, e);
        } // menuItemHelpReportIssue_Click

        private void menuItemHelpCheckUpdates_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemHelpCheckUpdates_Click, sender, e);
        } // menuItemHelpCheckUpdates_Click

        private void menuItemHelpAbout_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemHelpAbout_Click, sender, e);
        } // menuItemHelpAbout_Click

        #endregion

        #region 'Help' menu event handlers implementation

        private void Implementation_menuItemHelpDocumentation_Click(object sender, EventArgs e)
        {
            OpenUrl(InvariantTexts.UrlDocumentation);
        } // Implementation_menuItemHelpDocumentation_Click

        private void Implementation_menuItemHelpHomePage_Click(object sender, EventArgs e)
        {
            OpenUrl(InvariantTexts.UrlHomePage);
        } // Implementation_menuItemHelpHomePage_Click

        private void Implementation_menuItemHelpReportIssue_Click(object sender, EventArgs e)
        {
            OpenUrl(InvariantTexts.UrlReportIssue);
        } // Implementation_menuItemHelpReportIssue_Click

        private void Implementation_menuItemHelpCheckUpdates_Click(object sender, EventArgs e)
        {
            OpenUrl(InvariantTexts.UrlCheckForUpdatesManual);
        } // Implementation_menuItemHelpCheckUpdates_Click

        private void Implementation_menuItemHelpAbout_Click(object sender, EventArgs e)
        {
            using (var box = new AboutBox())
            {
                box.ApplicationData = new AboutBoxApplicationData()
                {
                    LargeIcon = Resources.AboutIcon,
                    Name = Texts.AppName,
                    Version = Texts.AppVersion,
                    Status = Texts.AppStatus,
                    LicenseTextRtf = Texts.SolutionLicenseRtf
                };
                box.ShowDialog(this);
            } // using box
        } // menuItemHelpAbout_Click_Implementation

        #endregion
    } // partial class ChannelListForm
} // namespace
