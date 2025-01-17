﻿using System.Collections.Generic;
using System.Linq;
using NKart.Core.Models;
using NUnit.Framework;

namespace NKart.Tests.Base.Visitors
{
    public class MockLineItemVistor : ILineItemVisitor
    {
        private readonly List<ILineItem> _visited;

        public MockLineItemVistor()
        {
            _visited = new List<ILineItem>();
        }

        public void Visit(ILineItem lineItem)
        {
            _visited.Add(lineItem);
        }

        public IEnumerable<ILineItem> Visited {
            get { return _visited; }
        }
    }
}