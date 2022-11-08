using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;

namespace Tesla.Practing.Domain.AggregatesModel.PassportAggregates
{
    /// <summary>
    /// 护照
    /// </summary>
    [Table("passport")]
    public class Passport
    {
        /// <summary>
        /// 签证ID
        /// </summary>
        [Key]
        public int StampId { get; set; }

        /// <summary>
        /// 护照编号
        /// </summary>
        [ForeignKey("Passport")]
        [Column(Order = 1)]
        public int PassportNumber { get; set; }

        /// <summary>
        /// 发证国家
        /// </summary>
        [ForeignKey("Passport")]
        [Column(Order = 2)]
        public string IssuingCountry { get; set; }

        /// <summary>
        /// 发证时间
        /// </summary>
        public DateTime Issued { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expires { get; set; }
    }
}
