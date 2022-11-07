using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.VO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    public class CheckBrandExistedCommand : IRequest<Brand>
    {
        public ExistedBrandVo BrandVo { get; private set; }

        public CheckBrandExistedCommand(ExistedBrandVo brandVo)
        {
            BrandVo = brandVo;
        }
    }
}
