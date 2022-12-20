namespace Services.UnitTests.Mappings;

using System.Runtime.Serialization;

using AutoMapper;

using nLayer.Data.Entities;
using nLayer.Services.Mappings;
using nLayer.Services.Models.Departments;
using nLayer.Services.Models.Employees;

public class MappingTests
{
    private readonly IConfigurationProvider configuration;
    private readonly IMapper mapper;

    public MappingTests()
    {
        this.configuration = new MapperConfiguration(
            config 
                => config.AddProfile<MappingProfile>());

        this.mapper = this.configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        this.configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Department), typeof(DepartmentDetailsDto))]
    [TestCase(typeof(Department), typeof(DepartmentFullDetailsDto))]
    [TestCase(typeof(Department), typeof(DepartmentListingDto))]
    [TestCase(typeof(Employee), typeof(EmployeeListingDto))]
    [TestCase(typeof(Employee), typeof(EmployeeDetailsDto))]
    [TestCase(typeof(Employee), typeof(EmployeeDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = this.GetInstanceOf(source);

        this.mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
        => type.GetConstructor(Type.EmptyTypes) != null 
            ? Activator.CreateInstance(type)! 
            : FormatterServices.GetUninitializedObject(type);
}
