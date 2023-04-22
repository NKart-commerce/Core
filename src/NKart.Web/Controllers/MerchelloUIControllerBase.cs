using NKart.Web.Models.Ui;
using NKart.Web.Mvc;

namespace NKart.Web.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NKart.Web.Models.Ui;
    using NKart.Web.Mvc;

    /// <summary>
    /// A base controller for Merchello UI Controllers.
    /// </summary>
    public abstract class MerchelloUIControllerBase : MerchelloSurfaceController
    {
        /// <summary>
        /// Validates a model.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The result of the validation.
        /// </returns>
        protected virtual bool ValidateModel(ICheckoutModel model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
    }
}