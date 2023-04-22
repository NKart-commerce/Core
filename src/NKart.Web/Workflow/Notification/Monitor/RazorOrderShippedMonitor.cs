namespace NKart.Web.Workflow.Notification.Monitor
{
    using NKart.Core.Gateways.Notification;
    using NKart.Core.Gateways.Notification.Triggering;
    using NKart.Core.Models.MonitorModels;
    using NKart.Core.Observation;

    /// <summary>
    /// A razor based order shipped monitor.
    /// </summary>
    [MonitorFor("641FC661-4A17-4CB1-A321-AF267985B03F", typeof(OrderShippedTrigger), "Order Shipped (Razor)", true)]
    public class RazorOrderShippedMonitor : RazorMonitorBase<IShipmentResultNotifyModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RazorOrderShippedMonitor"/> class.
        /// </summary>
        /// <param name="notificationContext">
        /// The notification context.
        /// </param>
        public RazorOrderShippedMonitor(INotificationContext notificationContext)
            : base(notificationContext)
        {
        }
    }
}