using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
           builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(200)");
            //builder.Property(d => d.CreatedON).HasDefaultValueSql("GETDATE");
            //builder.Property(d => d.LastModifiedOn).HasDefaultValueSql("GETDATE");
            builder
    .Property(d => d.CreatedON)
    .HasDefaultValueSql("GETDATE()");

            builder
                .Property(d => d.LastModifiedOn)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
