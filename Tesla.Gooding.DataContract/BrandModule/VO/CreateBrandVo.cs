﻿using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.DataContract.Abstractions.TenantModule.VO;
using Tesla.Gooding.DataContract.Abstractions.BrandModule.VO;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 创建品牌
    /// </summary>
    public class CreateBrandVo : TenantVo, IBrandCreateVo
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BrandCode { get; set; }
    }
}
