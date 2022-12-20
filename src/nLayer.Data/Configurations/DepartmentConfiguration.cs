namespace nLayer.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using nLayer.Data.Entities;

using static Common.DataConstants.Department;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> department)
    {
        department
            .HasKey(d => d.Id);

        department
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(NAME_MAX_LENGTH);

        department
            .HasIndex(d => d.Name)
            .IsUnique();
    }
}
