using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.QueryModule.DTO;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Queries
{
    public class BrandSearch : PagedBrandSearchVo, IRequest<PagedList<BrandDto>>
    {

    }
}
