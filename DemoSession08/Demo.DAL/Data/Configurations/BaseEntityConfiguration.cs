using Demo.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T :BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedON)
                  .HasDefaultValueSql("GETDATE()");


            builder.Property(d => d.LastModifiedOn)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
