namespace NKart.FastTrack.Models
{
    using NKart.Web.Store.Models;

    /// <summary>
    /// The fast track payment selection method model.
    /// </summary>
    public class FastTrackPaymentMethodModel : StorePaymentMethodModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the success redirect url.
        /// </summary>
        public string SuccessRedirectUrl { get; set; }
    }
}