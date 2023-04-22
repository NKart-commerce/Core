using System;
using NKart.Core;
using NKart.Core.Models;

namespace NKart.Tests.Base.DataMakers
{
    public class MockInvoiceStatusDataMaker : MockDataMakerBase
    {
        public static IInvoiceStatus InvoiceStatusUnpaidMock()
        {
            return new InvoiceStatus()
            {
                Key = Constants.InvoiceStatus.Unpaid,
                Alias = "unpaid",
                Name = "Unpaid",
                Active = true,
                Reportable = true,
                SortOrder = 1,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now

            };
        }

        public static IInvoiceStatus InvoiceStatusPaidMock()
        {
            return new InvoiceStatus()
            {
                Key = Constants.InvoiceStatus.Paid,
                Alias = "completed",
                Name = "Completed",
                Active = true,
                Reportable = true,
                SortOrder = 3,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now

            };
        }
    }
}
