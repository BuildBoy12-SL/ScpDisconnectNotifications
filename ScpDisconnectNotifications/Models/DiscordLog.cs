// -----------------------------------------------------------------------
// <copyright file="DiscordLog.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications.Models
{
    using Exiled.API.Features;
    using ScpDisconnectNotifications.Enums;

    /// <summary>
    /// Represents a set of fields to be logged to Discord.
    /// </summary>
    public readonly struct DiscordLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscordLog"/> struct.
        /// </summary>
        /// <param name="player">The player to log.</param>
        /// <param name="plugin">An instance of the plugin class.</param>
        /// <param name="role"><inheritdoc cref="Role"/></param>
        /// <param name="logReason"><inheritdoc cref="LogReason"/></param>
        public DiscordLog(Player player, Plugin plugin, RoleType role, LogReason logReason)
        {
            PlayerName = plugin.Config.ShowUserId ? player.Nickname + " " + $"({player.UserId})" : player.Nickname;
            Role = role;
            LogReason = logReason;
        }

        /// <summary>
        /// Gets the player's name field.
        /// </summary>
        public string PlayerName { get; }

        /// <summary>
        /// Gets the role of the player.
        /// </summary>
        public RoleType Role { get; }

        /// <summary>
        /// Gets the reason for logging.
        /// </summary>
        public LogReason LogReason { get; }
    }
}