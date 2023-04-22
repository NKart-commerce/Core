using NKart.Core.Models;
using NKart.Core.Models.MonitorModels;
using NKart.Core.Observation;

namespace NKart.Core.Gateways.Notification.Triggering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NKart.Core.Models;
    using NKart.Core.Models.MonitorModels;
    using NKart.Core.Observation;

    /// <summary>            
    /// Represents and OrderShippedTrigger
    /// </summary>
    [TriggerFor("OrderShipped", Topic.Notifications)]
    public class OrderShippedTrigger : NotificationTriggerBase<IShipment, IShipmentResultNotifyModel>
    {
        /// <summary>
        /// The <see cref="ShipmentResultNotifyModelFactory"/>.
        /// </summary>
        private readonly Lazy<ShipmentResultNotifyModelFactory> _factory = new Lazy<ShipmentResultNotifyModelFactory>(() => new ShipmentResultNotifyModelFactory()); 

        /// <summary>
        /// Value to pass to the notification monitors
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="contacts">
        /// An additional list of contacts
        /// </param>
        protected override void Notify(IShipment model, IEnumerable<string> contacts)
        {
            if (model == null || !model.Items.Any()) return;

            var notifyModel = _factory.Value.Build(model, contacts);

            NotifyMonitors(notifyModel);
        }
    }
}
