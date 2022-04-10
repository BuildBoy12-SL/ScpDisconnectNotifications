// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using ScpDisconnectNotifications.Enums;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets the literal translation for User Id.
        /// </summary>
        [Description("The literal translation for User Id.")]
        public string UserId { get; set; } = "User Id";

        /// <summary>
        /// Gets or sets the literal translation for Role.
        /// </summary>
        [Description("The literal translation for Role.")]
        public string Role { get; set; } = "Role";

        /// <summary>
        /// Gets or sets the translations for the headers.
        /// </summary>
        [Description("The translations for the headers.")]
        public Dictionary<LogReason, string> Headers { get; set; } = new Dictionary<LogReason, string>
        {
            { LogReason.Void, "User Suicided via Void" },
            { LogReason.Tesla, "User Suicided via Tesla" },
            { LogReason.Left, "User Disconnected" },
        };

        /// <summary>
        /// Gets or sets the translations for the colors.
        /// </summary>
        [Description("The translations for the colors.")]
        public Dictionary<LogReason, string> Colors { get; set; } = new Dictionary<LogReason, string>
        {
            { LogReason.Void, "#808080" },
            { LogReason.Tesla, "#808080" },
            { LogReason.Left, "#ff0000" },
        };
    }
}