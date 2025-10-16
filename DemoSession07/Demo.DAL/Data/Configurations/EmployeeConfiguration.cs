using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configurations
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");

            builder.Property(e => e.Gender).HasConversion((empGender) => empGender.ToString(),
               (gender) => (Gender) Enum.Parse(typeof(Gender),gender));

            builder.Property(e => e.EmployeeTypes).HasConversion((empType) => empType.ToString(),
               (type) => (EmployeeTypes)Enum.Parse(typeof(EmployeeTypes), type));
            base.Configure(builder);
        }
    }
}
