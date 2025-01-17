﻿using System.Linq;
using NKart.Core;
using NKart.Core.Models;
using NKart.Core.Services;
using NKart.Tests.IntegrationTests.TestHelpers;
using NUnit.Framework;

namespace NKart.Tests.IntegrationTests.Services.Customer
{
    using System;

    using NKart.Tests.Base.DataMakers;

    [TestFixture]
    [Category("Service Integration")]
    public class CustomerServiceTests : DatabaseIntegrationTestBase
    {
        private ICustomerService _customerService;

        private const string FixtureLoginName = "fixtureTester";

        private IAddress _address;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _customerService = PreTestDataWorker.CustomerService;

            _address = new Address()
            {
                Name = "Mindfly Web Design Studio",
                Address1 = "115 W. Magnolia St.",
                Address2 = "Suite 300",
                Locality = "Bellingham",
                Region = "WA",
                PostalCode = "98225",
                CountryCode = "US"
            };
        }

        [SetUp]
        public void Initialize()
        {
            PreTestDataWorker.DeleteAllAnonymousCustomers();
            PreTestDataWorker.DeleteAllCustomers();

            // create a customer for retrieval tests
            var customer = _customerService.CreateCustomerWithKey(
                FixtureLoginName,
                "firstName",
                "lastName",
                "test@test.com");
        }

        /// <summary>
        /// Tests verifies that an anonymous customer can be created and persisted
        /// </summary>
        [Test]
        public void Can_Create_An_AnonymousCustomer()
        {
            //// Arrange

            //// Act
            var anonymous = _customerService.CreateAnonymousCustomerWithKey();

            //// Assert
            Assert.NotNull(anonymous);
            Assert.IsTrue(anonymous.HasIdentity);
        }

        [Test]
        public void Can_Retrieve_An_AnonymousCustomer()
        {
            //// Arrange
            var anonymous = _customerService.CreateAnonymousCustomerWithKey();
            var key = anonymous.Key;

            //// Act
            var retrieved = _customerService.GetAnyByKey(key);

            //// Assert
            Assert.NotNull(retrieved);            
        }

        /// <summary>
        /// Test verifies a customer can be created (does not confirm is persisted)
        /// </summary>
        [Test]
        public void Can_Create_A_Customer()
        {
            //// Arrange
            var loginName = "loginName";
            var firstName = "firstName";
            var lastName = "lastName";
            var email = "test@test.com";
            
            //// Act
            var customer = _customerService.CreateCustomer(loginName, firstName, lastName, email);
 
            //// Assert
            Assert.NotNull(customer, "Customer was null");
            Assert.AreEqual(loginName, customer.LoginName);
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.LastName);
            Assert.AreEqual(email, customer.Email);
        }

        /// <summary>
        /// Test confirms a customer can be created and persisted
        /// </summary>
        [Test]
        public void Can_Create_A_CustomerWithKey()
        {
            //// Arrange
            var loginName = "loginName.test1";
            var firstName = "firstName";
            var lastName = "lastName";
            var email = "test@test.com";
            
            //// Act
            var customer = _customerService.CreateCustomerWithKey(loginName, firstName, lastName, email);


            //// Assert
            Assert.NotNull(customer, "Customer was null");
            Assert.AreEqual(loginName, customer.LoginName, "Login names did not match");
            Assert.AreEqual(firstName, customer.FirstName, "First name did not match");
            Assert.AreEqual(lastName, customer.LastName, "Last name did not match");
            Assert.AreEqual(email, customer.Email, "Email did not match");
            // the big test
            Assert.IsTrue(customer.HasIdentity, "Identity was not set.");
        }

        /// <summary>
        /// Test confirms a customer can be retrieved by their presumably Umbraco login name
        /// </summary>
        [Test]
        public void Can_Retrieve_A_Customer_By_LoginName()
        {
            //// Arrange
            var firstName = "firstName";
            var lastName = "lastName";
            var email = "test@test.com";
            
            //// Act
            var customer = _customerService.GetByLoginName(FixtureLoginName);

            //// Assert
            Assert.NotNull(customer, "customer was null");
            Assert.AreEqual(FixtureLoginName, customer.LoginName);
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.LastName);
            Assert.AreEqual(email, customer.Email);
        }

        /// <summary>
        /// Test verifies that a customer address can be created
        /// </summary>
        [Test]
        public void Can_Create_A_Customer_Address()
        {
            //// Arrange
            var loginName = "loginName.test2";
            var firstName = "firstName";
            var lastName = "lastName";
            var email = "test@test.com";
            var customer = _customerService.CreateCustomerWithKey(loginName, firstName, lastName, email);

            //// Act
            var customerAddress = customer.CreateCustomerAddress(MerchelloContext.Current, _address, "Test address", AddressType.Billing);

            //// Assert
            Assert.NotNull(customerAddress, "Customer address was null");
            Assert.AreEqual(AddressType.Billing, customerAddress.AddressType);
            Assert.IsTrue(customerAddress.HasIdentity, "Customer address does not have an identity");
            Assert.IsTrue(customerAddress.IsDefault, "Customer address is not the default address");
        }

        [Test]
        public void Can_Create_A_Customer_With_Addresses()
        {
            //// Arrange
            var customer = MockCustomerDataMaker.CustomerForInserting();
            _customerService.Save(customer);
            
            //// Act
            var customerAddresses = MockCustomerAddressDataMaker.AddressCollectionForInserting(customer, "addresses", 4).ToArray();
            customerAddresses[0].AddressType = AddressType.Billing;
            customerAddresses[1].AddressType = AddressType.Billing;
            foreach (var address in customerAddresses)
            {
                address.IsDefault = true;
                
            }
            ((Core.Models.Customer)customer).Addresses = customerAddresses;
            _customerService.Save(customer);

           //// Assert
           Assert.AreEqual(4, customer.Addresses.Count());
           var defaultBilling = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing);
           var defaultShipping = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Shipping);
            Assert.NotNull(defaultBilling);
            Assert.NotNull(defaultShipping);
            Assert.AreEqual(2, customer.Addresses.Count(x => x.AddressType == AddressType.Billing));
            Assert.AreEqual(2, customer.Addresses.Count(x => x.AddressType == AddressType.Shipping));
            Assert.AreEqual(1, customer.Addresses.Count(x => x.AddressType == AddressType.Billing && x.IsDefault));
            Assert.AreEqual(1, customer.Addresses.Count(x => x.AddressType == AddressType.Shipping && x.IsDefault));
        }

        [Test]
        public void Can_Add_New_Address_To_Customer_Add_Save_It_As_Default()
        {
            //// Arrange
            var customer = MockCustomerDataMaker.CustomerForInserting();
            _customerService.Save(customer);
           
            var customerAddresses = MockCustomerAddressDataMaker.AddressCollectionForInserting(customer, "addresses", 4).ToArray();
            customerAddresses[0].AddressType = AddressType.Billing;
            customerAddresses[1].AddressType = AddressType.Billing;
            foreach (var address in customerAddresses)
            {
                address.IsDefault = true;

            }
            ((Core.Models.Customer)customer).Addresses = customerAddresses;
            _customerService.Save(customer);
            var oldDefaultKey = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing).Key;

            //// Act
            var addresses = customer.Addresses.ToList();
            var newAddress = MockCustomerAddressDataMaker.CustomerAddressForInserting(customer.Key);
            newAddress.AddressType = AddressType.Billing;
            newAddress.IsDefault = true;
            addresses.Add(newAddress);
            ((Core.Models.Customer)customer).Addresses = addresses;
            _customerService.Save(customer);

            //// Assert
            Assert.AreEqual(5, customer.Addresses.Count());
            var newDefaultKey = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing).Key;
            Assert.AreNotEqual(oldDefaultKey, newDefaultKey);
            Assert.AreEqual(3, customer.Addresses.Count(x => x.AddressType == AddressType.Billing));
            Assert.AreEqual(2, customer.Addresses.Count(x => x.AddressType == AddressType.Shipping));
            Assert.AreEqual(1, customer.Addresses.Count(x => x.AddressType == AddressType.Billing && x.IsDefault));
            Assert.AreEqual(1, customer.Addresses.Count(x => x.AddressType == AddressType.Shipping && x.IsDefault));
        }

        /// <summary>
        /// Read the name of the method =)
        /// </summary>
        [Test]
        public void Can_Add_2_BillingAddresses_And_3_ShippingAddresses_Without_Setting_Defaults_And_Assert_Only_One_Default_Exists_For_Each_Type()
        {
            //// Arrange
            var customer = _customerService.GetByLoginName(FixtureLoginName);
            Assert.NotNull(customer, "Customer was null");            

            //// Act
            customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address1", AddressType.Billing);
            customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address2", AddressType.Billing);
            customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address3", AddressType.Shipping);
            customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address4", AddressType.Shipping);
            customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address5", AddressType.Shipping);

            //// Assert
            var all = customer.CustomerAddresses(MerchelloContext.Current);
            Assert.AreEqual(5, all.Count(), "Total address count was not five");
            Assert.AreEqual(2, all.Count(x => x.IsDefault), "There were not two defaults");

            var billings = customer.CustomerAddresses(MerchelloContext.Current, AddressType.Billing);
            Assert.AreEqual(2, billings.Count(), "There were not two billing addresses");
            Assert.AreEqual(1, billings.Count(x => x.IsDefault), "There was not one default billing address");

            var shippings = customer.CustomerAddresses(MerchelloContext.Current, AddressType.Shipping);
            Assert.AreEqual(3, shippings.Count(), "There were not two shipping addresses");
            Assert.AreEqual(1, shippings.Count(x => x.IsDefault), "There was not one default shipping address");
            
        }

        /// <summary>
        /// Test verifies that designating an address as the default address overrides all other default addresses in the respective collection
        /// </summary>
        [Test]
        public void Can_Add_Two_Addresses_Both_With_IsDefault_And_Prove_The_Second_Is_The_Only_Default()
        {
            //// Arrange
            var customer = _customerService.GetByLoginName(FixtureLoginName);
            Assert.NotNull(customer, "Customer was null");
            
            //// Act
            var address1 = customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address1", AddressType.Billing);
            var address2 = customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address2", AddressType.Billing);

            // at this point address 1 should be default
            var defaultBilling = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing);
            Assert.NotNull(defaultBilling, "Default billing was null");
            Assert.AreEqual(address1.Key, defaultBilling.Key, "Address 1 was not the default address");


            address2.IsDefault = true;
            customer.SaveCustomerAddress(MerchelloContext.Current, address2);

            //// Assert
            
            // now the address 2 should be the default billing address and the only address flagged as default
            var assertDefaultBilling = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing);
            Assert.NotNull(assertDefaultBilling, "Assert Default billing was null");
            Assert.AreEqual(address2.Key, assertDefaultBilling.Key, "Address 2 was not the default address");

            var allBillings = customer.CustomerAddresses(MerchelloContext.Current, AddressType.Billing);
            Assert.AreEqual(1, allBillings.Count(x => x.IsDefault));
        }

        /// <summary>
        /// Test proves that in a collection, if the default address is deleted another is selected.
        /// </summary>
        [Test]
        public void Can_Delete_An_Address_And_Still_Have_A_Default()
        {
            //// Arrange
            var customer = _customerService.GetByLoginName(FixtureLoginName);
            Assert.NotNull(customer, "Customer was null");

            //// Act
            var address1 = customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address1", AddressType.Billing);
            var address2 = customer.CreateCustomerAddress(MerchelloContext.Current, _address, "test address2", AddressType.Billing);

            // at this point address 1 should be default

            customer.DeleteCustomerAddress(MerchelloContext.Current, address1);

            var assertDefaultBilling = customer.DefaultCustomerAddress(MerchelloContext.Current, AddressType.Billing);
            var assertCustomer = _customerService.GetByLoginName(FixtureLoginName);
            Assert.AreEqual(1, assertCustomer.Addresses.Count(), "Customer still has 2 addresses");
            Assert.NotNull(assertDefaultBilling, "Assert Default billing was null");
            Assert.AreEqual(address2.Key, assertDefaultBilling.Key, "Address 2 was not the default address");
        }

        /// <summary>
        /// Test confirms that a customer can be retrieved by a login name when the login name is an email address
        /// </summary>
        /// <remarks>
        /// http://issues.merchello.com/youtrack/issue/M-302
        /// </remarks>
        [Test]
        public void Can_Get_A_Customer_By_Login_When_LoginName_Is_An_Email_Address()
        {
            //// Arrange
            const string email = "test@test.com";

            var arrange = _customerService.CreateCustomerWithKey(
                email,
                "firstName",
                "lastName",
                email);

            //// Act
            var customer = _customerService.GetByLoginName(email);

            //// Assert
            Assert.NotNull(customer);

        }
    }
}