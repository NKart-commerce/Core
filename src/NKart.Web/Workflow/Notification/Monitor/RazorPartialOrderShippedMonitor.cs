namespace NKart.Web.Workflow.Notification.Monitor
{
    using NKart.Core.Gateways.Notification;
    using NKart.Core.Gateways.Notification.Triggering;
    using NKart.Core.Models.MonitorModels;
    using NKart.Core.Observation;

    /// <summary>
    /// The razor partial order shipped monitor.
    /// </summary>
    [MonitorFor("9927CB8B-00AF-4DDB-BB68-987EF89C60EF", typeof(PartialOrderShippedTrigger), "Partial Order Shipped (Razor)", true)]
    public class RazorPartialOrderShippedMonitor : RazorMonitorBase<IShipmentResultNotifyModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RazorPartialOrderShippedMonitor"/> class.
        /// </summary>
        /// <param name="notificationContext">
        /// The <see cref="NotificationContext"/>.
        /// </param>
        public RazorPartialOrderShippedMonitor(INotificationContext notificationContext)
            : base(notificationContext)
        {
        }
    }
}