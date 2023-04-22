using System;
using NKart.Core;
using NKart.Core.Models;

namespace NKart.Tests.Base.Mocks
{
    public sealed class ShipmentStatusMock : NotifiedStatusBase, IShipmentStatus
    {
        public ShipmentStatusMock()
        {
            Key = Constants.ShipmentStatus.Quoted;
            Alias = "quoted";
            Name = "Quoted";
            Active = true;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}