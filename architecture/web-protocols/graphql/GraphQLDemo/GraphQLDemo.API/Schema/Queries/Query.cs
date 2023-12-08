using Bogus;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        private Faker<StudentType> _studentFaker;

        private Faker<InstructorType> _instructorFaker;

        private Faker<CourseType> _courseFaker;
        /// As a common practise we should not remove the queries and resolvers from out schema rather then we should mark them deprecated.
        [GraphQLDeprecated("This query is deprecated.")]
        public string Instructions => "Sample Query Text";

        // Resolver for GetCourses Query.
        public IEnumerable<CourseType> GetCourses()
        {
            _studentFaker = new Faker<StudentType>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.GPA, f => f.Random.Double(0, 4));
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Salary, f => f.Random.Double(30000, 100000));
            _courseFaker = new Faker<CourseType>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Subject, f => f.PickRandom<Subject>())
                .RuleFor(x => x.Instructor, f => _instructorFaker.Generate())
                .RuleFor(x => x.Students, f => _studentFaker.Generate(3));
            var result = _courseFaker.Generate(5);
            return result;
        }

        /*
         query {
            courseById(id: "ceb7a3b9-fabb-4e24-8c2d-707c91c6e911"){
              id
              name
              instructor{
                firstName
              }
              students{
                firstName
              }
            }
           }
         */
        // THE QUERY NAME IS MADE BY HOT CHOCOLATE BY REMOVING SUFFIX & PREFIX LIKE GET OR ASYNC. HENCE THE NAME COURSEBYID
        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            Task.Delay(1000);
            _studentFaker = new Faker<StudentType>()
              .RuleFor(x => x.Id, f => f.Random.Guid())
              .RuleFor(x => x.FirstName, f => f.Person.FirstName)
              .RuleFor(x => x.LastName, f => f.Person.LastName)
              .RuleFor(x => x.GPA, f => f.Random.Double(0, 4));
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Salary, f => f.Random.Double(30000, 100000));
            _courseFaker = new Faker<CourseType>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Subject, f => f.PickRandom<Subject>())
                .RuleFor(x => x.Instructor, f => _instructorFaker.Generate())
                .RuleFor(x => x.Students, f => _studentFaker.Generate(3));
            CourseType course = _courseFaker.Generate(1).First();
            course.Id = id;
            return course;
        }
    }
}
