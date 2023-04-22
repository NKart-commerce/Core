using NKart.Web.Pluggable;

namespace NKart.Web.Mvc
{
    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Web.Pluggable;

    /// <summary>
    /// The merchello view page.
    /// </summary>
    /// <typeparam name="TModel">
    /// The type of the model to be rendered
    /// </typeparam>
    public abstract class MerchelloViewPage<TModel> : MerchelloHelperViewPage<TModel>
    {
        /// <summary>
        /// The <see cref="CustomerContext"/>.
        /// </summary>
        private ICustomerContext _customerContext;


        /// <summary>
        /// Gets the CurrentCustomer from the CustomerContext
        /// </summary>
        public ICustomerBase CurrentCustomer
        {
            get
            {
                if (_customerContext == null)
                    _customerContext = PluggableObjectHelper.GetInstance<CustomerContextBase>("CustomerContext", UmbracoContext);

                return _customerContext.CurrentCustomer;
            }
        }
    }
}