using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule.VO
{
    /// <summary>
    /// 品牌创建接口
    /// </summary>
    public interface IBrandCreateVo
    {
        /// <summary>
        /// 品牌编码
        /// </summary>
        string BrandCode { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        string BrandName { get; set; }
    }
}
