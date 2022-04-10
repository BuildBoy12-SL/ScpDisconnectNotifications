// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications
{
    using System;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class Plugin : Plugin<Config, Translation>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override string Name => "ScpDisconnectNotifications";

        /// <inheritdoc/>
        public override string Prefix => "ScpDisconnectNotifications";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <summary>
        /// Gets an instance of the <see cref="ScpDisconnectNotifications.WebhookController"/> class.
        /// </summary>
        public WebhookController WebhookController { get; private set; }

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            if (string.IsNullOrEmpty(Config.WebhookUrl))
            {
                Log.Error("The webhook url cannot be empty! ScpDisconnectNotifications will not be loaded.");
                return;
            }

            WebhookController = new WebhookController(this);
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.Dying += eventHandlers.OnDying;
            Exiled.Events.Handlers.Player.Left += eventHandlers.OnLeft;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Dying -= eventHandlers.OnDying;
            Exiled.Events.Handlers.Player.Left -= eventHandlers.OnLeft;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}