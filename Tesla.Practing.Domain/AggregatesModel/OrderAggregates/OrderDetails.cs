using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Practing.Domain.AggregatesModel.OrderAggregates
{
    /// <summary>
    /// 订单详情
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// 账单地址
        /// </summary>
        public Address BillingAddress { get; private set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        public Address ShippingAddress { get; private set; }
    }
}
