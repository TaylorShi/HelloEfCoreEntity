using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.OrderAggregates
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : Entity<long>, IAggregateRoot
    {
        //public Address Address { get; private set; }

        public OrderDetails OrderDetails { get; private set; }
    }
}
