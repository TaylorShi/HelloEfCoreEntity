using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 博客详情
    /// </summary>
    [Table("blogdetail")]
    public class BlogDetail
    {
        public BlogDetail()
        {

        }

        public BlogDetail(string title, string bloggerName)
        {
            this.Title = title;
            this.BloggerName = bloggerName;
        }

        public void Modify(string title, string bloggerName)
        {
            this.Title = title;
            this.BloggerName = bloggerName;
        }

        /// <summary>
        /// 主要追踪键
        /// </summary>
        [Key]
        public int PrimaryTrackingKey { get;private set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; private set; }

        /// <summary>
        /// 博客名称
        /// </summary>
        [ConcurrencyCheck, MaxLength(10, ErrorMessage = "BloggerName must be 10 characters or less"), MinLength(5)]
        public string BloggerName { get; private set; }

        /// <summary>
        /// 博客编码
        /// </summary>
        [NotMapped]
        public string BlogCode
        {
            get
            {
                return Title.Substring(0, 1) + ":" + BloggerName.Substring(0, 1);
            }
        }
    }
}
