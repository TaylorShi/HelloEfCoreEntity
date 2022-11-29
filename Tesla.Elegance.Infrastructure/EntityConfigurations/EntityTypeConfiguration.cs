using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain.Abstractions;

namespace Tesla.Elegance.Infrastructure.EntityConfigurations
{
    public abstract class EntityTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
           where TEntity : Entity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var entityType = typeof(TEntity);

            builder.HasKey(x => x.Id);

            if (typeof(ISoftDelete).IsAssignableFrom(entityType))
            {
                builder.HasQueryFilter(d => EF.Property<bool>(d, "IsDeleted") == false);
            }
        }
    }

}
