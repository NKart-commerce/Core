﻿using System;
using System.Collections.Generic;
using NKart.Core.Formatters;
using NKart.Core.Models;

namespace NKart.Core.Gateways.Notification
{
    using System.Net.Mail;

    /// <summary>
    /// Defines the NotificationContext
    /// </summary>
    public interface INotificationContext : IGatewayProviderTypedContextBase<NotificationGatewayProviderBase>
    {
        /// <summary>
        /// Gets a collection of <see cref="INotificationMessage"/>s by a Monitor Key (Guid)
        /// </summary>
        /// <param name="monitorKey">The monitor key</param>
        /// <returns>A collection of NotificationMessage</returns>
        IEnumerable<INotificationMessage> GetNotificationMessagesByMonitorKey(Guid monitorKey);

        /// <summary>
        /// Sends a <see cref="INotificationMessage"/>
        /// </summary>
        /// <param name="message">The <see cref="INotificationMessage"/> to be sent</param>
        void Send(INotificationMessage message);

        /// <summary>
        /// Sends a <see cref="INotificationMessage"/>
        /// </summary>
        /// <param name="message">The <see cref="INotificationMessage"/> to be sent</param>
        /// <param name="formatter">The <see cref="IFormatter"/> to use when formatting the message</param>
        void Send(INotificationMessage message, IFormatter formatter);

        /// <summary>
        /// Sends a <see cref="INotificationMessage"/>.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="formatter">
        /// The formatter.
        /// </param>
        /// <param name="attachments">
        /// The attachments.
        /// </param>
        void Send(INotificationMessage message, IFormatter formatter, IEnumerable<Attachment> attachments);
    }
}