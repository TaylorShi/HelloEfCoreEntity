using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 删除品牌命令
    /// </summary>
    public class DeleteBrandCommand : ExistedBrandVo, IRequest<bool>
    {

    }
}
