// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using ScpDisconnectNotifications.Enums;
    using ScpDisconnectNotifications.Models;

    /// <summary>
    /// General event handlers.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnDied(DiedEventArgs)"/>
        public void OnDying(DyingEventArgs ev)
        {
            if (!ev.IsAllowed || !Round.IsStarted || !plugin.Config.LoggedRoles.Contains(ev.Target.Role))
                return;

            switch (ev.Handler.Type)
            {
                case DamageType.Tesla:
                    plugin.WebhookController.SendMessage(new DiscordLog(ev.Target, plugin, ev.Target.Role, LogReason.Tesla));
                    break;
                case DamageType.Crushed:
                    plugin.WebhookController.SendMessage(new DiscordLog(ev.Target, plugin, ev.Target.Role, LogReason.Void));
                    break;
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnLeft(LeftEventArgs)"/>
        public void OnLeft(LeftEventArgs ev)
        {
            if (Round.IsStarted && plugin.Config.LoggedRoles.Contains(ev.Player.Role))
                plugin.WebhookController.SendMessage(new DiscordLog(ev.Player, plugin, ev.Player.Role, LogReason.Left));
        }
    }
}