using GraphQLDemo.API.Model;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Services.Instructor;
using GraphQLDemo.API.Services.Student;

namespace GraphQLDemo.API.Schema.Queries
{

    public class Query
    {
        private readonly InstructorRepository _instructorRepository;
        private readonly CoursesRepository _courseRepository;
        private readonly StudentRepository _studentRepository;

        public Query(InstructorRepository instructorRepository, CoursesRepository courseRepository, StudentRepository studentRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        /*
         query{
          instructors{
            id
            firstName
            lastName
            salary
            courses{
              id
              name
              subject
              description
            }
          }
        }
         */
        public IEnumerable<InstructorType> GetInstructors()
        {
            var instructors = _instructorRepository.Get();
            var instructorResult = instructors.Select(i => new InstructorType
            {
                FirstName = i.FirstName,
                LastName = i.LastName,
                Id = i.Id,
                Salary = i.Salary,
                Courses = (!i.Courses.Any()) ? Enumerable.Empty<CourseType>() : i.Courses.Select(x => new CourseType
                {
                    Subject = x.Subject,
                    Id = x.Id,
                    Name = x.Name,
                    Instructor = new InstructorType
                    {
                        FirstName = i.FirstName,
                    }
                })
            });

            return instructorResult;
        }

        /*
         query{
          instructorById(id: "dd330c60-0553-490b-9f0e-33351fc9be1b"){
            id
            firstName
            lastName
            salary
            courses{
              id
              name
              subject
              description
            }
          }
        }
         */
        public async Task<InstructorType> GetInstructorById(Guid id)
        {

            var instructor = await _instructorRepository.GetByIdAsync(id);

            return instructor == null
             ? null
             : new InstructorType
             {
                 FirstName = instructor.FirstName,
                 LastName = instructor.LastName,
                 Id = id,
                 Salary = instructor.Salary,
                 Courses = instructor.Courses?.Select(x => new CourseType
                 {
                     Subject = x.Subject,
                     Id = x.Id,
                     Name = x.Name,
                 }) ?? Enumerable.Empty<CourseType>()
             };
        }

        /*
         query{
          courses{
            id
            name
            subject
            instructor{
              id
              firstName
              lastName
              salary
            }
          }
        }
         */
        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            var courses = await _courseRepository.Get();

            return courses.Select(c => new CourseType
            {
                Id = c.Id,
                Name = c.Name,
                Instructor = new InstructorType
                {
                    Id = c.Instructor.Id,
                    FirstName = c.Instructor.FirstName,
                    LastName = c.Instructor.LastName,
                    Salary = c.Instructor.Salary
                },
                Subject = c.Subject,
            });
        }

        /*
         query{
          courseById(id: "aaa46bd4-6678-4429-8105-99e3c58ff038"){
            id
            name
            subject
            instructor{
              id
              firstName
              lastName
              salary
            }
          }
        }
         */
        public async Task<CourseType> GetCourseById(Guid Id)
        {
            var course = await _courseRepository.GetById(Id);
            return new CourseType
            {
                Id = course.Id,
                Name = course.Name,
                Instructor = new InstructorType()
                {
                    Id = course.Instructor.Id,
                    FirstName = course.Instructor.FirstName,
                    LastName = course.Instructor.LastName,
                    Salary = course.Instructor.Salary
                },
                Subject = course.Subject,
            };
        }

        /*
         query{
          students{
            id
            firstName
            lastName
            gql
          }
        }
         */
        public async Task<IEnumerable<StudentType>> GetStudents()
        {
            var students = _studentRepository.Get();

            return students.Select(s => new StudentType
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GPA = s.GPA
            });
        }

        /*
         query{
          studentsById(id: "aa79050c-7720-4b16-969e-a54c769709bf"){
            id
            firstName
            lastName
            gql
          }
        }
         */
        public async Task<StudentType> GetStudentsById(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return new StudentType
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GPA = student.GPA
            };
        }
    }
    #region OLD SIMPLE QUERY CODE
    //public class Query
    //{
    //    private Faker<StudentType> _studentFaker;

    //    private Faker<InstructorType> _instructorFaker;

    //    private Faker<CourseType> _courseFaker;
    //    /// As a common practise we should not remove the queries and resolvers from out schema rather then we should mark them deprecated.
    //    [GraphQLDeprecated("This query is deprecated.")]
    //    public string Instructions => "Sample Query Text";

    //    // Resolver for GetCourses Query.
    //    public IEnumerable<CourseType> GetCourses()
    //    {
    //        _studentFaker = new Faker<StudentType>()
    //            .RuleFor(x => x.Id, f => f.Random.Guid())
    //            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
    //            .RuleFor(x => x.LastName, f => f.Person.LastName)
    //            .RuleFor(x => x.GPA, f => f.Random.Double(0, 4));
    //        _instructorFaker = new Faker<InstructorType>()
    //            .RuleFor(x => x.Id, f => f.Random.Guid())
    //            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
    //            .RuleFor(x => x.LastName, f => f.Person.LastName)
    //            .RuleFor(x => x.Salary, f => f.Random.Double(30000, 100000));
    //        _courseFaker = new Faker<CourseType>()
    //            .RuleFor(x => x.Id, f => f.Random.Guid())
    //            .RuleFor(x => x.Name, f => f.Random.Word())
    //            .RuleFor(x => x.Subject, f => f.PickRandom<Subject>())
    //            .RuleFor(x => x.Instructor, f => _instructorFaker.Generate())
    //            .RuleFor(x => x.Students, f => _studentFaker.Generate(3));
    //        var result = _courseFaker.Generate(5);
    //        return result;
    //    }

    //    /*
    //     query {
    //        courseById(id: "ceb7a3b9-fabb-4e24-8c2d-707c91c6e911"){
    //          id
    //          name
    //          instructor{
    //            firstName
    //          }
    //          students{
    //            firstName
    //          }
    //        }
    //       }
    //     */
    //    // THE QUERY NAME IS MADE BY HOT CHOCOLATE BY REMOVING SUFFIX & PREFIX LIKE GET OR ASYNC. HENCE THE NAME COURSEBYID
    //    public async Task<CourseType> GetCourseByIdAsync(Guid id)
    //    {
    //        Task.Delay(1000);
    //        _studentFaker = new Faker<StudentType>()
    //          .RuleFor(x => x.Id, f => f.Random.Guid())
    //          .RuleFor(x => x.FirstName, f => f.Person.FirstName)
    //          .RuleFor(x => x.LastName, f => f.Person.LastName)
    //          .RuleFor(x => x.GPA, f => f.Random.Double(0, 4));
    //        _instructorFaker = new Faker<InstructorType>()
    //            .RuleFor(x => x.Id, f => f.Random.Guid())
    //            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
    //            .RuleFor(x => x.LastName, f => f.Person.LastName)
    //            .RuleFor(x => x.Salary, f => f.Random.Double(30000, 100000));
    //        _courseFaker = new Faker<CourseType>()
    //            .RuleFor(x => x.Id, f => f.Random.Guid())
    //            .RuleFor(x => x.Name, f => f.Random.Word())
    //            .RuleFor(x => x.Subject, f => f.PickRandom<Subject>())
    //            .RuleFor(x => x.Instructor, f => _instructorFaker.Generate())
    //            .RuleFor(x => x.Students, f => _studentFaker.Generate(3));
    //        CourseType course = _courseFaker.Generate(1).First();
    //        course.Id = id;
    //        return course;
    //    }
    //}
    #endregion
}
