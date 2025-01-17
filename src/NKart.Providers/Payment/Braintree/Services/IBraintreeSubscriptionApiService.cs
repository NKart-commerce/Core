﻿namespace NKart.Providers.Payment.Braintree.Services
{
    using System;
    using System.Collections.Generic;

    using global::Braintree;

    using Umbraco.Core;
    using Umbraco.Core.Services;

    /// <summary>
    /// Defines the BraintreeSubscriptionApiProvider.
    /// </summary>
    public interface IBraintreeSubscriptionApiService : IService
    {
        /// <summary>
        /// Creates a <see cref="Subscription"/>.
        /// </summary>
        /// <param name="paymentMethodToken">
        /// The payment method token.
        /// </param>
        /// <param name="planId">
        /// The plan id.
        /// </param>
        /// <param name="price">
        /// An optional price used to override the plan price.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt{Subscription}"/>.
        /// </returns>
        Attempt<Subscription> Create(string paymentMethodToken, string planId, decimal? price = null);

        /// <summary>
        /// Creates a <see cref="Subscription"/>.
        /// </summary>
        /// <param name="paymentMethodToken">
        /// The payment method token.
        /// </param>
        /// <param name="planId">
        /// The plan id.
        /// </param>
        /// <param name="trialDuration">
        /// The trial duration.
        /// </param>
        /// <param name="trialDurationUnit">
        /// The trial duration unit.
        /// </param>
        /// <param name="addTrialPeriod">
        /// The add trial period.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt{Subscription}"/>.
        /// </returns>
        Attempt<Subscription> Create(string paymentMethodToken, string planId, int trialDuration, SubscriptionDurationUnit trialDurationUnit, bool addTrialPeriod = false);

        /// <summary>
        /// Creates a <see cref="Subscription"/>.
        /// </summary>
        /// <param name="paymentMethodToken">
        /// The payment method token.
        /// </param>
        /// <param name="planId">
        /// The plan id.
        /// </param>
        /// <param name="firstBillingDate">
        /// The first billing date.
        /// </param>
        /// <returns>
        /// The <see cref="SubscriptionRequest"/>.
        /// </returns>
        Attempt<Subscription> Create(string paymentMethodToken, string planId, DateTime firstBillingDate);

        /// <summary>
        /// Creates a <see cref="Subscription"/>.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt{Subscription}"/>.
        /// </returns>
        Attempt<Subscription> Create(SubscriptionRequest request);

        /// <summary>
        /// Cancels a subscription.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        /// <returns>
        /// A value indicating whether the subscription cancellation was successful.
        /// </returns>
        bool Cancel(string subscriptionId);

        /// <summary>
        /// Updates an existing <see cref="Subscription"/>
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Result{Subscription}"/>.
        /// </returns>
        /// <remarks>
        /// This is a direct pass through to the .Net SDK Update method
        /// https://developers.braintreepayments.com/javascript+dotnet/sdk/server/recurring-billing/update
        /// </remarks>
        Attempt<Subscription> Update(SubscriptionRequest request);
            
        /// <summary>
        /// Gets the <see cref="Subscription"/>.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        /// <returns>
        /// The <see cref="Subscription"/>.
        /// </returns>
        /// <remarks>
        /// Subscription Id can either be specified or generated by the API.
        /// Note: this is the Details method in the .Net SDK
        /// </remarks>
        Subscription GetSubscription(string subscriptionId);

        /// <summary>
        /// Determines if a subscription exists
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        /// <returns>
        /// A value indicating whether or not a subscription exists.
        /// </returns>
        bool Exists(string subscriptionId);

        /// <summary>
        /// Gets a list of all <see cref="Plan"/>.
        /// </summary>
        /// <returns>
        /// The collection of all <see cref="Plan"/>.
        /// </returns>
        IEnumerable<Plan> GetAllPlans();
            
        /// <summary>
        /// Gets a list of all discounts.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Discount}"/>.
        /// </returns>
        IEnumerable<Discount> GetAllDiscounts(); 
            
        /// <summary>
        /// Gets a list of all AddOn(s).
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{AddOn}"/>.
        /// </returns>
        IEnumerable<AddOn> GetAllAddOns();
    }
}