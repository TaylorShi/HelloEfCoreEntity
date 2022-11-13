using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tasla.DataAnnotation.Console
{
    /// <summary>
    /// 随笔
    /// </summary>
    [Table("posts")]
    public class Post
    {
        /// <summary>
        /// 博客ID
        /// </summary>
        [Required]
        [Index("BlogId")]
        public long BlogId { get; private set; }
    }
}
