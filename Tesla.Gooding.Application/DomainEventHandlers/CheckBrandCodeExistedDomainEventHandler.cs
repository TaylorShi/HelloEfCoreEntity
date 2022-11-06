using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Domain.Abstractions;
using Tesla.Framework.Infrastructure.Core.Extensions;
using Tesla.Gooding.Application.Extensions;
using Tesla.Gooding.DataContract.Common;
using Tesla.Gooding.Domain.Events.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;

namespace Tesla.Gooding.Application.DomainEventHandlers
{
    /// <summary>
    /// 检查品牌编码已存在事件处理程序
    /// </summary>
    internal class CheckBrandCodeExistedDomainEventHandler : IDomainEventHandler<CheckBrandCodeExistedDomainEvent>
    {
        private readonly GoodingSlaveContext goodingSlaveContext;

        public CheckBrandCodeExistedDomainEventHandler(GoodingSlaveContext goodingSlaveContext)
        {
            this.goodingSlaveContext = goodingSlaveContext;
        }

        public async Task Handle(CheckBrandCodeExistedDomainEvent notification, CancellationToken cancellationToken)
        {
            var isAny = await goodingSlaveContext.Brands
                .WhereIf(notification.TenantId > 0, x => x.TenantId == notification.TenantId)
                .WhereIf(!string.IsNullOrEmpty(notification.Code), x => x.Code == notification.Code)
                .AnyAsync();

            if (isAny)
            {
                // 品牌编码重复
                EnumCode.ErrBrandCodeExisted.ThrowLanMessage();
            }
        }
    }
}
