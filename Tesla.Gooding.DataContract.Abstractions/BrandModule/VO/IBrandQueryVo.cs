using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule.VO
{
    /// <summary>
    /// 品牌查询接口
    /// </summary>
    public interface IBrandQueryVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        string BrandId { get; set; }

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
