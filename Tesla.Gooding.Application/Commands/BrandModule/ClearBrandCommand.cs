using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule.VO;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 删除品牌命令
    /// </summary>
    public class ClearBrandCommand : TenantVo, IRequest<bool>
    {

    }
}
