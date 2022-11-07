using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.Abstractions.BrandModule.DTO
{
    /// <summary>
    /// 品牌信息接口
    /// </summary>
    public interface IBrandDto
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
