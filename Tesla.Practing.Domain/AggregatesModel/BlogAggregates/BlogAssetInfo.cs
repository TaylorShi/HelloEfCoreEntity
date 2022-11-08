using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 博客附件信息
    /// </summary>
    [ComplexType]
    public class BlogAssetInfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// 博客描述
        /// </summary>
        [MaxLength(250)]
        public string Description { get; private set; }
    }
}
