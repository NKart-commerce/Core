namespace NKart.Web.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Core.Models;

    using NKart.Core.Services;
    using NKart.Web;
    using NKart.Web.Factories;
    using NKart.Web.Models.Ui;

    using Umbraco.Core;
    using Umbraco.Web.WebApi;

    /// <summary>
	/// An API controller for handling country regions.
	/// </summary>
	[WebApi.JsonCamelCaseFormatter]
    public abstract class CountryRegionApiControllerBase : UmbracoApiController
    {
		/// <summary>
		/// Gets a collection of <see cref="IProvince"/>.
		/// </summary>
		/// <param name="countryCode">
		/// The country code.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable{IProvince}"/>.
		/// </returns>
		[HttpPost]
        public virtual IEnumerable<IProvince> PostGetRegionsForCountry(string countryCode)
        {	
			return StoreSettingService.GetProvincesByCountryCode(countryCode);
		}
    }
}