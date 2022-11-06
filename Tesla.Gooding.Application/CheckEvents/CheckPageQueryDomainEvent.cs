using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.QueryModule;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Gooding.Application.CheckEvents
{
    internal class CheckPageQueryDomainEvent : IDomainEvent
    {
        public PublicPageVo PageVo { get; private set; }

        public CheckPageQueryDomainEvent(PublicPageVo pageVo)
        {
            PageVo = pageVo;
        }
    }
}
