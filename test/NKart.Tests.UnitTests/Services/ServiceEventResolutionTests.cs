﻿using System;
using System.Linq;
using System.Reflection;
using NKart.Core.Models;
using NKart.Core.Observation;
using NKart.Core.Persistence;
using NKart.Core.Services;
using NKart.Tests.Base.DataMakers;
using NKart.Tests.Base.Respositories;
using NKart.Tests.Base.Services;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Events;

namespace NKart.Tests.UnitTests.Services
{
    using NKart.Core.Cache;

    using Umbraco.Core;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Persistence.SqlSyntax;

    [TestFixture]
    [Category("Service Events")]
    public class ServiceEventResolutionTests : ServiceTestsBase<IOrder>
    {
        private IOrderService _orderService;
        private OrderStatusInvokeTester _orderStatusInvokeTester;        

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            var mockSettingService = new Mock<IStoreSettingService>();
            mockSettingService.Setup(x => x.GetNextOrderNumber(1)).Returns(111);

            var logger = Logger.CreateWithDefaultLog4NetConfiguration();
            var syntax = new Mock<ISqlSyntaxProvider>().Object;
            var cache = new CacheHelper(
                new ObjectCacheRuntimeCacheProvider(),
                new StaticCacheProvider(),
                new NullCacheProvider());

            var repositoryFactory = new RepositoryFactory(cache, logger, syntax);

            _orderService = new OrderService(new MockUnitOfWorkProvider(), repositoryFactory, logger, new StoreSettingService(repositoryFactory, logger), new ShipmentService(repositoryFactory, logger));

            _orderStatusInvokeTester = new OrderStatusInvokeTester();

            var saved = typeof(OrderService).GetEvent("Saved");
            Assert.NotNull(saved, "Saved could not be found");
            //var mi = GetType().GetMethod("Invoke", BindingFlags.Instance | BindingFlags.NonPublic);
            var mi = _orderStatusInvokeTester.GetType().GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);

            //saved.AddEventHandler(this, Delegate.CreateDelegate(saved.EventHandlerType, this, mi));
            saved.AddEventHandler(_orderStatusInvokeTester, Delegate.CreateDelegate(saved.EventHandlerType, _orderStatusInvokeTester, mi));

        }

        
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            Before = null;
            After = null;

        }

        [TestFixtureTearDown]
        public override void FixtureTearDown()
        {
            base.FixtureTearDown();

            //OrderService.Saved -= OrderServiceOnSaved;
        }

        
        [Test]
        public void Can_Show_Dynamically_Bound_Event_Triggers()
        {
            //// Arrange
            var notFulfilled = MockOrderStatusMaker.OrderStatusNotFulfilledMock();
            var order = new Order(notFulfilled, Guid.NewGuid()) { Key = Guid.NewGuid() };

            //// Act
            _orderService.Save(order);

            //// Assert
            Assert.NotNull(_orderStatusInvokeTester.After);
            Assert.AreEqual(_orderStatusInvokeTester.After.Key, order.Key);
        }
 
    }


    internal class OrderStatusInvokeTester : ITrigger
    {

        public IOrder After { get; set; }
        public void Invoke(object sender, EventArgs e)
        {
            After = ((SaveEventArgs<IOrder>) e).SavedEntities.FirstOrDefault();
        }

        public bool HasMonitors {
            get { return true; }
        }
        public int MonitorCount {
            get { return 1;  }
        }
    }
}