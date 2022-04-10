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
        /// <param name="role"><inheritdoc cref="Role"/></param>
        /// <param name="logReason"><inheritdoc cref="LogReason"/></param>
        public DiscordLog(Player player, string role, LogReason logReason)
        {
            Name = player.Nickname;
            Id = player.UserId;
            Role = role;
            LogReason = logReason;
        }

        /// <summary>
        /// Gets the player's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the player's user id.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the role of the player.
        /// </summary>
        public string Role { get; }

        /// <summary>
        /// Gets the reason for logging.
        /// </summary>
        public LogReason LogReason { get; }
    }
}