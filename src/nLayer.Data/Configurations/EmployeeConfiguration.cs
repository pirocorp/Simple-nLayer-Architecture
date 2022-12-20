namespace nLayer.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using nLayer.Data.Entities;

using static Common.DataConstants.Employee;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> employee)
    {
        employee
            .HasKey(e => e.Id);

        employee
            .Property(e => e.Address)
            .HasMaxLength(ADDRESS_MAX_LENGTH);

        employee
            .Property(e => e.Email)
            .HasMaxLength(EMAIL_MAX_LENGTH);

        employee
            .Property(e => e.Name)
            .HasMaxLength(NAME_MAX_LENGTH);

        employee
            .Property(e => e.Salary)
            .HasPrecision(SALARY_PRECISION, SALARY_SCALE);

        employee
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
