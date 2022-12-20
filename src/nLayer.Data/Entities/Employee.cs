namespace nLayer.Data.Entities;

using nLayer.Data.Enums;

using System;

public class Employee
{
    public Employee()
    {
        this.Address = string.Empty;
        this.Email = string.Empty;
        this.Name = string.Empty;

        this.Department = null!;
    }

    public int Id { get; private set; }

    public string Address { get; set; }

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Email { get; set; }

    public Gender Gender { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; }
}
