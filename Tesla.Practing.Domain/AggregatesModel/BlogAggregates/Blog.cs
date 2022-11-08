using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.BlogAggregates
{
    /// <summary>
    /// 博客
    /// </summary>
    public class Blog : Entity<long>, IAggregateRoot
    {
        public Blog()
        {

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
        public string Url { get; private set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
