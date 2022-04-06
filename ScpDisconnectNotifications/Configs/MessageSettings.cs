// -----------------------------------------------------------------------
// <copyright file="MessageSettings.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// Handles configs related to the standard message.
    /// </summary>
    public class MessageSettings
    {
        /// <summary>
        /// Gets or sets the format of the message.
        /// </summary>
        [Description("The format of the left message.")]
        public string LeftFormat { get; set; } = "{0} has logged off as {1}";

        /// <summary>
        /// Gets or sets the format of the message.
        /// </summary>
        [Description("The format of the suicide message.")]
        public string SuicideFormat { get; set; } = "{0} has killed themselves as {1}";
    }
}