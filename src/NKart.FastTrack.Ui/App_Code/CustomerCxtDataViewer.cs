namespace NKart.FastTrack.Tests
{
    using NKart.Core.Models;
    using NKart.Web;
    using NKart.Web.Pluggable;

    using Umbraco.Web;

    public class CustomerCxtDataViewer
    {
        private readonly CustomerContextBase _ctx;

        public CustomerCxtDataViewer()
        {
            _ctx = PluggableObjectHelper.GetInstance<CustomerContextBase>("CustomerContext", UmbracoContext.Current);
        }

        public CustomerContextBase CustomerContext
        {
            get
            {
                return _ctx;
            }
        }

        public ICustomerBase CurrentCustomer
        {
            get
            {
                return _ctx.CurrentCustomer;
            }
        }
    }
}