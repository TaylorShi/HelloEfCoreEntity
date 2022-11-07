using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule.VO
{
    /// <summary>
    /// 品牌搜索接口
    /// </summary>
    public interface IBrandSearchVo
    {
        /// <summary>
        /// 品牌Id列表
        /// </summary>
        List<string> BrandIdList { get; set; }

        /// <summary>
        /// 品牌编码列表
        /// </summary>
        List<string> BrandCodeList { get; set; }

        /// <summary>
        /// 品牌名称列表
        /// </summary>
        List<string> BrandNameList { get; set; }
    }
}
