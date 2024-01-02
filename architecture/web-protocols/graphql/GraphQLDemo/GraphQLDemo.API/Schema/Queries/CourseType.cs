using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.Model;
using GraphQLDemo.API.Services.Instructor;

namespace GraphQLDemo.API.Schema.Queries
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }

        // Hot Chocolate injects the dependency here using [Service]
        [GraphQLNonNullType]
        public async  Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            // When we hit the resolver N time the data loader will batch this resolver and run it just once to solve the N + 1 Problem. 
            var instructor = await instructorDataLoader.LoadAsync(InstructorId, CancellationToken.None);
            return new InstructorType { Id = instructor.Id, FirstName = instructor.FirstName, LastName = instructor.LastName, Salary = instructor.Salary };
        }
        public IEnumerable<StudentType> Students { get; set; }

        // this is a resolver
        /*
         query {
            courses{
              description
            }
        }
         */
        public string Description()
        {
            return $"{Name} This is a course by";
        }
    }
}
