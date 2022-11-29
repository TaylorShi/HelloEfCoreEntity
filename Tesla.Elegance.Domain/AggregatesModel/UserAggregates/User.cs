using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Domain.AggregatesModel.BookAggregates;

namespace Tesla.Elegance.Domain.AggregatesModel.UserAggregates
{
    public class User : Entity<Guid>
    {
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; } //该用户所借的书
    }
}
