using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Domain.Abstractions;
using Tesla.Gooding.Application.CheckEvents;
using Tesla.Gooding.Application.Extensions;
using Tesla.Gooding.DataContract.Common;

namespace Tesla.Gooding.Application.CheckEventHandlers
{
    internal class CheckBrandInfoDomainEventHandler : IDomainEventHandler<CheckBrandInfoDomainEvent>
    {
        public Task Handle(CheckBrandInfoDomainEvent notification, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(notification.BrandVo.BrandName))
            {
                // 品牌名称缺失
                EnumCode.ErrBrandNameNull.ThrowLanMessage();
            }

            if (string.IsNullOrEmpty(notification.BrandVo.BrandCode))
            {
                // 品牌编码缺失
                EnumCode.ErrBrandCodeNull.ThrowLanMessage();
            }

            return Task.CompletedTask;
        }
    }
}
