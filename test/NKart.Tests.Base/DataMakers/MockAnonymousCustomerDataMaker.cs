using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKart.Core.Models;
using NKart.Core.Models.EntityBase;

namespace NKart.Tests.Base.DataMakers
{
    /// <summary>
    /// Helper class to assist in putting together anonymous customer data for testing
    /// </summary>
    public class MockAnonymousCustomerDataMaker : MockDataMakerBase
    {
        public static IAnonymousCustomer AnonymousCustomerForInserting()
        {   
            var anonymous = new AnonymousCustomer();
            return anonymous;
        }


    }
}
