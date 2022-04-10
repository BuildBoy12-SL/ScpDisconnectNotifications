// -----------------------------------------------------------------------
// <copyright file="WebhookController.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpDisconnectNotifications
{
    using System;
    using DSharp4Webhook.Core;
    using DSharp4Webhook.Core.Constructor;
    using Exiled.API.Features;
    using ScpDisconnectNotifications.Models;

    /// <summary>
    /// Handles the sending of messages via a webhook.
    /// </summary>
    public class WebhookController : IDisposable
    {
        private static readonly MessageBuilder MessageBuilder = ConstructorProvider.GetMessageBuilder();
        private readonly Plugin plugin;
        private readonly IWebhook webhook;
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookController"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public WebhookController(Plugin plugin)
        {
            this.plugin = plugin;
            webhook = WebhookProvider.CreateStaticWebhook(plugin.Config.WebhookUrl);
        }

        /// <summary>
        /// Sends a message via the <see cref="webhook"/>.
        /// </summary>
        /// <param name="discordLog">The log to log.</param>
        public void SendMessage(DiscordLog discordLog)
        {
            if (isDisposed)
                throw new ObjectDisposedException(nameof(WebhookController));

            MessageBuilder messageBuilder = PrepareMessage(discordLog);
            if (messageBuilder is null)
                return;

            webhook.SendMessage(messageBuilder.Build()).Queue((result, isSuccessful) =>
            {
                if (!isSuccessful)
                    Log.Warn("Failed to send scp disconnect message.");
            });
        }

        /// <inheritdoc />
        public void Dispose()
        {
            isDisposed = true;
            webhook?.Dispose();
        }

        private MessageBuilder PrepareMessage(DiscordLog discordLog)
        {
            if (isDisposed)
                throw new ObjectDisposedException(nameof(WebhookController));

            MessageBuilder.Reset();

            if (!plugin.Config.MessageTranslations.TryGetValue(discordLog.LogReason, out string toFormat))
                return null;

            MessageBuilder.Append(string.Format(toFormat, discordLog.PlayerName, discordLog.Role.ToString()));
            return MessageBuilder;
        }
    }
}