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
    internal class CheckPageQueryDomainEventEventHandler : IDomainEventHandler<CheckPageQueryDomainEvent>
    {
        public Task Handle(CheckPageQueryDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.PageVo.PageIndex <= 0)
            {
                // 分页条件不合规(查询起始不得低于{0})
                EnumCode.ErrPageIndexLowerMin.ThrowLanMessageParams(1);
            }

            if (notification.PageVo.PageSize <= 0)
            {
                // 分页条件不合规(查询不得低于{0}条)
                EnumCode.ErrPageSizeLowerMin.ThrowLanMessageParams(1);
            }

            if (notification.PageVo.PageSize > 200)
            {
                // 分页条件不合规(查询不得超过{0}条)
                EnumCode.ErrPageSizeOverMax.ThrowLanMessageParams(200);
            }

            return Task.CompletedTask;
        }
    }
}
