using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 创建品牌命令
    /// </summary>
    public class CreateBrandCommand : CreateBrandVo, IRequest<bool>
    {

    }
}
