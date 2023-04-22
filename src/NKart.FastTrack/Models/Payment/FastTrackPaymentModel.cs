namespace NKart.FastTrack.Models.Payment
{
    using NKart.Web.Store.Models;

    /// <summary>
    /// The cash payment model for the FastTrack store.
    /// </summary>
    public class FastTrackPaymentModel : StorePaymentModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the success redirect url.
        /// </summary>
        public string SuccessRedirectUrl { get; set; }
    }
}