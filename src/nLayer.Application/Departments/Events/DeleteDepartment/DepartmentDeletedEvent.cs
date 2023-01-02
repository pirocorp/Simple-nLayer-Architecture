namespace nLayer.Application.Departments.Events.DeleteDepartment;

using Data.Entities;
using nLayer.Application.Common;

public class DepartmentDeletedEvent : BaseEvent<Department>
{
    public DepartmentDeletedEvent(Department item) 
        : base(item)
    {
    }
}
