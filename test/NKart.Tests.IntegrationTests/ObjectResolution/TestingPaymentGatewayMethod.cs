using NKart.Core.Gateways.Payment;
using NKart.Core.Models;
using NKart.Core.Services;

namespace NKart.Tests.IntegrationTests.ObjectResolution
{
    public class TestingPaymentGatewayMethod : PaymentGatewayMethodBase
    {
        public TestingPaymentGatewayMethod(IGatewayProviderService gatewayProviderService, IPaymentMethod paymentMethod) : base(gatewayProviderService, paymentMethod)
        {
        }

        protected override IPaymentResult PerformAuthorizePayment(IInvoice invoice, ProcessorArgumentCollection args)
        {
            throw new System.NotImplementedException();
        }

        protected override IPaymentResult PerformAuthorizeCapturePayment(IInvoice invoice, decimal amount, ProcessorArgumentCollection args)
        {
            throw new System.NotImplementedException();
        }

        protected override IPaymentResult PerformCapturePayment(IInvoice invoice, IPayment payment, decimal amount,
            ProcessorArgumentCollection args)
        {
            throw new System.NotImplementedException();
        }

        protected override IPaymentResult PerformRefundPayment(IInvoice invoice, IPayment payment, decimal amount, ProcessorArgumentCollection args)
        {
            throw new System.NotImplementedException();
        }

        protected override IPaymentResult PerformVoidPayment(IInvoice invoice, IPayment payment, ProcessorArgumentCollection args)
        {
            throw new System.NotImplementedException();
        }
    }
}