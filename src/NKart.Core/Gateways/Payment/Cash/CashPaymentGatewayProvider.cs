﻿using NKart.Core.Logging;
using NKart.Core.Models;
using NKart.Core.Services;

namespace NKart.Core.Gateways.Payment.Cash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NKart.Core.Logging;
    using NKart.Core.Models;
    using NKart.Core.Services;

    using Umbraco.Core.Cache;
    using Umbraco.Core.Logging;

    /// <summary>
    /// Represents a CashPaymentGatewayProvider
    /// </summary>
    [GatewayProviderActivation("B2612C3D-8BF0-411C-8C56-32E7495AE79C", "Cash Payment Provider", "Cash Payment Provider")]
    public class CashPaymentGatewayProvider : PaymentGatewayProviderBase, ICashPaymentGatewayProvider
    {
        #region AvailableResources

        /// <summary>
        /// The available resources.
        /// </summary>
        private static readonly IEnumerable<IGatewayResource> AvailableResources = new List<IGatewayResource>()
        {
            new GatewayResource("Cash", "Cash")
        };

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CashPaymentGatewayProvider"/> class.
        /// </summary>
        /// <param name="gatewayProviderService">
        /// The gateway provider service.
        /// </param>
        /// <param name="gatewayProviderSettings">
        /// The gateway provider settings.
        /// </param>
        /// <param name="runtimeCacheProvider">
        /// The runtime cache provider.
        /// </param>
        public CashPaymentGatewayProvider(
            IGatewayProviderService gatewayProviderService,
            IGatewayProviderSettings gatewayProviderSettings,
            IRuntimeCacheProvider runtimeCacheProvider)
            : base(gatewayProviderService, gatewayProviderSettings, runtimeCacheProvider)
        {
        }

        /// <summary>
        /// Creates a <see cref="IPaymentGatewayMethod"/>
        /// </summary>
        /// <param name="name">The name of the payment method</param>
        /// <param name="description">The description of the payment method</param>
        /// <returns>A <see cref="IPaymentGatewayMethod"/></returns>
        public IPaymentGatewayMethod CreatePaymentMethod(string name, string description)
        {            
            return CreatePaymentMethod(AvailableResources.First(), name, description);
        }

        /// <summary>
        /// Creates a <see cref="IPaymentGatewayMethod"/>
        /// </summary>
        /// <param name="gatewayResource">The <see cref="IGatewayResource"/> implemented by this method</param>
        /// <param name="name">The name of the payment method</param>
        /// <param name="description">The description of the payment method</param>
        /// <returns>A <see cref="IPaymentGatewayMethod"/></returns>
        public override IPaymentGatewayMethod CreatePaymentMethod(IGatewayResource gatewayResource, string name, string description)
        {
            var paymentCode = gatewayResource.ServiceCode + "-" + Guid.NewGuid();

            var attempt = GatewayProviderService.CreatePaymentMethodWithKey(GatewayProviderSettings.Key, name, description, paymentCode);

            if (attempt.Success)
            {
                PaymentMethods = null;

                return new CashPaymentGatewayMethod(GatewayProviderService, attempt.Result);
            }

            MultiLogHelper.Error<CashPaymentGatewayProvider>(string.Format("Failed to create a payment method name: {0}, description {1}, paymentCode {2}", name, description, paymentCode), attempt.Exception);

            throw attempt.Exception;
        }

        /// <summary>
        /// Gets a <see cref="IPaymentGatewayMethod"/> by it's unique 'key'
        /// </summary>
        /// <param name="paymentMethodKey">The key of the <see cref="IPaymentMethod"/></param>
        /// <returns>A <see cref="IPaymentGatewayMethod"/></returns>
        public override IPaymentGatewayMethod GetPaymentGatewayMethodByKey(Guid paymentMethodKey)
        {
            var paymentMethod = PaymentMethods.FirstOrDefault(x => x.Key == paymentMethodKey);

            if(paymentMethod == null) throw new NullReferenceException("PaymentMethod not found");

            return new CashPaymentGatewayMethod(GatewayProviderService, paymentMethod);
        }

        /// <summary>
        /// Gets a <see cref="IPaymentGatewayMethod"/> by it's payment code
        /// </summary>
        /// <param name="paymentCode">The payment code of the <see cref="IPaymentGatewayMethod"/></param>
        /// <returns>A <see cref="IPaymentGatewayMethod"/></returns>
        public override IPaymentGatewayMethod GetPaymentGatewayMethodByPaymentCode(string paymentCode)
        {
            var paymentMethod = PaymentMethods.FirstOrDefault(x => x.PaymentCode == paymentCode);

            if (paymentMethod == null) throw new NullReferenceException("PaymentMethod not found");

            return new CashPaymentGatewayMethod(GatewayProviderService, paymentMethod);
        }

        /// <summary>
        /// Returns a collection of all possible gateway methods associated with this provider
        /// </summary>
        /// <returns>A collection of <see cref="IGatewayResource"/></returns>
        public override IEnumerable<IGatewayResource> ListResourcesOffered()
        {
            return AvailableResources;
        }

    }
}