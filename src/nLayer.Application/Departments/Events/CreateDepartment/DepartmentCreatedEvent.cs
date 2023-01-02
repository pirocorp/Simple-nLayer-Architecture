namespace nLayer.Application.Departments.Events.CreateDepartment;

using nLayer.Application.Common;
using nLayer.Data.Entities;

public class DepartmentCreatedEvent : BaseEvent<Department>
{
    public DepartmentCreatedEvent(Department item)
        : base(item)
    { }
}
