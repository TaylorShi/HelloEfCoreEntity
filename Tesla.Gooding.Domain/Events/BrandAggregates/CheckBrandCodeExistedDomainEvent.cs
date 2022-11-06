using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Gooding.Domain.Events.BrandAggregates
{
    /// <summary>
    /// 检查品牌编码已存在事件
    /// </summary>
    public class CheckBrandCodeExistedDomainEvent : IDomainEvent
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public long TenantId { get; private set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string Code { get; private set; }

        public CheckBrandCodeExistedDomainEvent(long tenantId, string code)
        {
            TenantId = tenantId;
            Code = code;
        }
    }
}
