using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Core;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Queries
{
    public class BrandSearch : BrandPagedSearchVo, IRequest<PagedList<BrandDto>>
    {

    }
}
