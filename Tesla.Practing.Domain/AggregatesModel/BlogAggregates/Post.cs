using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 随笔
    /// </summary>
    [Table("posts")]
    [Index(nameof(BlogId))]
    public class Post : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 博客ID
        /// </summary>
        [Required]
        public long BlogId { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MinLength(5), MaxLength(2000)]
        [Column("postcontent", TypeName = "nvarchar")]
        public string Content { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateModifyed { get; private set; }
    }
}
