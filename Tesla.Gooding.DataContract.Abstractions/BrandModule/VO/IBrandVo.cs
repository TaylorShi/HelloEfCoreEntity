using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule.VO
{
    /// <summary>
    /// 品牌入参接口
    /// </summary>
    public interface IBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        string BrandId { get; set; }
    }
}
