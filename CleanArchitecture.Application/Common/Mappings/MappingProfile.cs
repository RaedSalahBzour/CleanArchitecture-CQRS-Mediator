using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Domain.Entity;
using System.Reflection;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        CreateMap<CreateBlogCommand, Blog>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());
        //CreateMap<UpdateBlogCommand, Blog>()
        //   .ForMember(dest => dest.Id, src => src.MapFrom(src => src.blogId));

    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var mapFromType = typeof(IMapFrom<>);  // Define the generic interface type
        var mappingMethodName = nameof(IMapFrom<object>.Mapping);  // Get the name of the Mapping method

        // Function to check if a type implements IMapFrom<>
        bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

        // Retrieve all types from the assembly that implement IMapFrom<>
        var types = assembly.GetExportedTypes()
                            .Where(t => t.GetInterfaces().Any(HasInterface))
                            .ToList();

        var argumentTypes = new Type[] { typeof(Profile) };

        // Iterate over each type that implements IMapFrom<>
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);  // Create an instance of the type
            var methodInfo = type.GetMethod(mappingMethodName);  // Retrieve the Mapping method

            if (methodInfo != null)
            {
                // Invoke the Mapping method with the current profile
                methodInfo.Invoke(instance, new object[] { this });
            }
            else
            {
                // Get all interfaces that implement IMapFrom<>
                var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                if (interfaces.Count > 0)
                {
                    foreach (var @interface in interfaces)
                    {
                        // Retrieve the Mapping method from the interface
                        var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                        // Invoke the Mapping method if it exists
                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}
