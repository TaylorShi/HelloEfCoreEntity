using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.DataContract.BrandModule.VO
{
    /// <summary>
    /// 修改品牌
    /// </summary>
    public class ModifyBrandVo : CreateBrandVo
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        public string BrandId { get; set; }
    }
}
