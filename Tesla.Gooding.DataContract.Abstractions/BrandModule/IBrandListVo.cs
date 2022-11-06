using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule
{
    /// <summary>
    /// 品牌入参接口
    /// </summary>
    public interface IBrandListVo
    {
        /// <summary>
        /// 品牌编码列表
        /// </summary>
        List<string> BrandCodeList { get; set; }
    }
}
