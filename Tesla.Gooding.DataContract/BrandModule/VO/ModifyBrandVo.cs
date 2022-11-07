using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.Abstractions.BrandModule.VO;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 修改品牌
    /// </summary>
    public class ModifyBrandVo : CreateBrandVo, IBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        public string BrandId { get; set; }
    }
}
