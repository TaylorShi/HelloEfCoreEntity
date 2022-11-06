using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Core;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Queries
{
    /// <summary>
    /// 品牌查询
    /// </summary>
    public class BrandQuery : BrandPagedQueryVo, IRequest<PagedList<BrandDto>>
    {

    }
}
