using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tesla.Gooding.DataContract.Common
{
    /// <summary>
    /// 消息编码
    /// </summary>
    public enum MessageCode
    {
        /// <summary>
        /// 缺少参数
        /// </summary>
        [Description("缺少参数")]
        ErrKeyIsNull = 101,

        /// <summary>
        /// 格式错误
        /// </summary>
        [Description("格式错误")]
        ErrConvertNull = 102,

        /// <summary>
        /// 执行成功
        /// </summary>
        [Description("执行成功")]
        OK = 200,

        /// <summary>
        /// 商户信息缺失
        /// </summary>
        [Description("商户信息缺失")]
        ErrTenantIdNull = 110000,

        #region Page

        /// <summary>
        /// 分页条件不合规(查询起始不得低于{0})
        /// </summary>
        [Description("分页条件不合规(查询起始不得低于{0})")]
        ErrPageIndexLowerMin = 120000,

        /// <summary>
        /// 分页条件不合规(查询不得低于{0}条)
        /// </summary>
        [Description("分页条件不合规(查询不得低于{0}条)")]
        ErrPageSizeLowerMin = 120001,

        /// <summary>
        /// 分页条件不合规(查询不得超过{0}条)
        /// </summary>
        [Description("分页条件不合规(查询不得超过{0}条)")]
        ErrPageSizeOverMax = 120002, 

        #endregion

        #region Brand 130000

        /// <summary>
        /// 品牌名称缺失
        /// </summary>
        [Description("品牌名称缺失")]
        ErrBrandNameNull = 130000,

        /// <summary>
        /// 品牌编码缺失
        /// </summary>
        [Description("品牌编码缺失")]
        ErrBrandCodeNull = 130001,

        /// <summary>
        /// 品牌ID缺失
        /// </summary>
        [Description("品牌ID缺失")]
        ErrBrandIdNull = 130002,

        /// <summary>
        /// 品牌不存在
        /// </summary>
        [Description("品牌不存在")]
        ErrBrandNotExist = 130003,

        /// <summary>
        /// 品牌编码重复
        /// </summary>
        [Description("品牌编码重复")]
        ErrBrandCodeExisted = 130004,

        #endregion
    }
}
