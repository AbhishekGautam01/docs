using GraphQLDemo.API.Schema.Queries;
using HotChocolate.Data.Filters;

namespace GraphQLDemo.API.Schema.Filters
{
    public class CourseFilterType: FilterInputType<CourseType>
    {
        protected override void Configure(IFilterInputTypeDescriptor<CourseType> descriptor)
        {
            base.Configure(descriptor);
            {
                // Ignore filtering on student
                descriptor.Ignore(x => x.Students);
                base.Configure(descriptor);
            }
        }
    }
}
