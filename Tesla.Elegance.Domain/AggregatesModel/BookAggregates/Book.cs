using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Domain.AggregatesModel.UserAggregates;

namespace Tesla.Elegance.Domain.AggregatesModel.BookAggregates
{
    public class Book : Entity<Guid>
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public string SN { get; set; } //图书序列号
        public string? UserId { get; set; }
        public virtual User? User { get; set; } //租借该书的用户
    }
}
