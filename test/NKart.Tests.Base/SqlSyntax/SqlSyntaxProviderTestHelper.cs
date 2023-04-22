using System;
using NKart.Core.Gateways;
using NKart.Core.Gateways.Notification;
using NKart.Core.Gateways.Payment;
using NKart.Core.Gateways.Shipping;
using NKart.Core.Gateways.Taxation;
using NKart.Core.ObjectResolution;
using Umbraco.Core;
using Umbraco.Core.Persistence.SqlSyntax;

namespace NKart.Tests.Base.SqlSyntax
{
    internal class SqlSyntaxProviderTestHelper
    {
        public static void EstablishSqlSyntax(DbSyntax syntax = DbSyntax.SqlCe)
        {
            try
            {
                var syntaxtest = SqlSyntaxContext.SqlSyntaxProvider ;
            }
            catch (Exception)
            {

                SqlSyntaxContext.SqlSyntaxProvider = SqlSyntaxProvider(syntax);
            }
            //if (Resolution.IsFrozen) return;
           

            //PaymentGatewayProviderResolver.Current = new PaymentGatewayProviderResolver(() => PluginManager.Current.ResolveTypesWithAttribute<PaymentGatewayProviderBase, GatewayProviderActivationAttribute>());
            //NotificationGatewayProviderResolver.Current = new NotificationGatewayProviderResolver(() => PluginManager.Current.ResolveTypesWithAttribute<NotificationGatewayProviderBase, GatewayProviderActivationAttribute>());
            //TaxationGatewayProviderResolver.Current = new TaxationGatewayProviderResolver(() => PluginManager.Current.ResolveTypesWithAttribute<TaxationGatewayProviderBase, GatewayProviderActivationAttribute>());
            //ShippingGatewayProviderResolver.Current = new ShippingGatewayProviderResolver(() => PluginManager.Current.ResolveTypesWithAttribute<ShippingGatewayProviderBase, GatewayProviderActivationAttribute>());

            //if(!EventTriggerRegistry.IsInitialized)
            //EventTriggerRegistry.Current =
            //    new EventTriggerRegistry(() => PluginManager.Current.ResolveTypesWithAttribute<IEventTriggeredAction, EventTriggeredActionForAttribute>());

            //Resolution.Freeze();
        }

        public static ISqlSyntaxProvider SqlSyntaxProvider(DbSyntax syntax = DbSyntax.SqlCe)
        {
            return syntax == DbSyntax.SqlServer ? new SqlServerSyntaxProvider() : (ISqlSyntaxProvider)new SqlCeSyntaxProvider();
        }
    }
}