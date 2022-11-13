using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tesla.Framework.Domain.Abstractions;
using Tesla.Framework.Domain.Abstractions.IdBuilders;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 博客
    /// </summary>
    [Table("blogs")]
    [Comment("博客")]
    public class Blog : Entity<long>, IAggregateRoot
    {
        private 

        protected Blog(IGenerateProvider idWorker)
        {
            Id = idWorker.GenerateId();
        }

        public Blog(string url)
        {
            this.Url = url;
        }

        public void Update(string url)
        {
            this.Url = url;
        }

        /// <summary>
        /// 地址
        /// </summary>
        [Comment("博客地址")]
        public string Url { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("创建时间")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Comment("修改时间")]
        public DateTime DateModifyed { get; private set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [Timestamp]
        [Comment("时间戳")]
        public Byte[] TimeStamp { get; set; }
    }
}
