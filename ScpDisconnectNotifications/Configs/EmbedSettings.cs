// -----------------------------------------------------------------------
// <copyright file="EmbedSettings.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// Handles configs related to the embed message.
    /// </summary>
    public class EmbedSettings
    {
        /// <summary>
        /// Gets or sets the translation of the 'User Disconnected' title.
        /// </summary>
        [Description("Translation of the 'User Disconnected' title.")]
        public string UserDisconnected { get; set; } = "User Disconnected";

        /// <summary>
        /// Gets or sets the translation of the 'User Disconnected' title.
        /// </summary>
        [Description("Translation of the 'User Disconnected' title.")]
        public string UserSuicided { get; set; } = "User Suicided";

        /// <summary>
        /// Gets or sets the translation of the 'Role' title.
        /// </summary>
        [Description("Translation of the 'Role' title.")]
        public string Role { get; set; } = "Role";
    }
}