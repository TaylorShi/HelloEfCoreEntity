using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 博客附件
    /// </summary>
    [Table("blogassets")]
    public class BlogAsset : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        public BlogAssetInfo Assets { get; private set; }
    }
}
