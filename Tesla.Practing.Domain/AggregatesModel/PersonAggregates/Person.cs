using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Practing.Domain.AggregatesModel.PersonAggregates
{
    /// <summary>
    /// 个人
    /// </summary>
    [Table("person")]
    [Index(nameof(FirstName), nameof(LastName))]
    [Index(nameof(Url), Name = "Person_Url", IsUnique = true)]
    public class Person : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; private set; }
    }
}
