using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.VO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    public class CheckBrandModifyCommand : IRequest<Brand>
    {
        public ModifyBrandVo BrandVo { get; private set; }

        public CheckBrandModifyCommand(ModifyBrandVo brandVo)
        {
            BrandVo = brandVo;
        }
    }
}
