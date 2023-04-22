namespace NKart.FastTrack.Models
{
    using NKart.Web.Models.Ui;
    using NKart.Web.Store.Models;

    /// <summary>
    /// A model for FastTrack ship rate quotes.
    /// </summary>
    public class FastTrackShipRateQuoteModel : StoreShipRateQuoteModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the success URL to redirect to the shipping entry stage.
        /// </summary>
        public string SuccessRedirectUrl { get; set; }
    }
}