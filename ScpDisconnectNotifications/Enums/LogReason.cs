// -----------------------------------------------------------------------
// <copyright file="LogReason.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications.Enums
{
    /// <summary>
    /// Represents a reason to log.
    /// </summary>
    public enum LogReason
    {
        /// <summary>
        /// The player has died to a tesla gate.
        /// </summary>
        Tesla,

        /// <summary>
        /// The player has died to the void.
        /// </summary>
        Void,

        /// <summary>
        /// The player has left the game.
        /// </summary>
        Left,
    }
}