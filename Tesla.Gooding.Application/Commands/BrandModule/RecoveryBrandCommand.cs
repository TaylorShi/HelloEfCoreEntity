using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 恢复品牌命令
    /// </summary>
    public class RecoveryBrandCommand : ExistedBrandVo, IRequest<bool>
    {

    }
}
