using Demo.DAL.Models.DeparmentModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Configurations
{
    internal class DepartmentConfiguration : BaseEntityConfiguration<Department>,IEntityTypeConfiguration<Department>
    {
        public new void  Configure(EntityTypeBuilder<Department> builder)
        {
           builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(200)");
            //builder.Property(d => d.CreatedON).HasDefaultValueSql("GETDATE");
            //builder.Property(d => d.LastModifiedOn).HasDefaultValueSql("GETDATE");

            builder.HasMany(d => d.Employees)
                   .WithOne(e => e.Department)
                   .HasForeignKey(e=>e.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);


           base.Configure(builder);
        }
    }
}
