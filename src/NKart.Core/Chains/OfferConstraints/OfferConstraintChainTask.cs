using NKart.Core.Marketing.Constraints;
using NKart.Core.Marketing.Offer;
using NKart.Core.Models;

namespace NKart.Core.Chains.OfferConstraints
{
    using System;
    using System.ComponentModel;

    using NKart.Core.Marketing.Constraints;
    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The offer constraint chain task.
    /// </summary>
    /// <typeparam name="T">
    /// The type of 
    /// </typeparam>
    public abstract class OfferConstraintChainTask<T> : AttemptChainTaskBase<T>, IOfferConstraintChainTask
    {
        /// <summary>
        /// The <see cref="OfferComponentBase"/>.
        /// </summary>
        private readonly OfferConstraintComponentBase<T> _component;

        /// <summary>
        /// The <see cref="ICustomerBase"/>.
        /// </summary>
        private readonly ICustomerBase _customer;

        public OfferConstraintChainTask(OfferConstraintComponentBase<T> component, ICustomerBase customer)
        {
            Ensure.ParameterNotNull(component, "component");
            Ensure.ParameterNotNull(customer, "customer");

            _component = component;
            _customer = customer;
        }

        protected OfferConstraintComponentBase<T> Component 
        { 
            get
            {
                return _component;
            } 
        }

        protected ICustomerBase Customer
        {
            get
            {
                return _customer; 
            }
        }
    }
}