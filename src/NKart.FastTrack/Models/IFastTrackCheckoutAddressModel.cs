namespace NKart.FastTrack.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using NKart.Web.Models.Ui;

    /// <summary>
    /// A base class for FastTrack <see cref="ICheckoutAddressModel"/>.
    /// </summary>
    public interface IFastTrackCheckoutAddressModel : ICheckoutAddressModel, ISuccessRedirectUrl
    {
        /// <summary>
        /// Gets or sets the list of countries for the view drop down list.
        /// </summary>
        IEnumerable<SelectListItem> Countries { get; set; }
    }
}