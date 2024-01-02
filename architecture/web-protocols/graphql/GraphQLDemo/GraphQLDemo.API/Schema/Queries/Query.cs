using GraphQLDemo.API.Model;
using GraphQLDemo.API.Services;
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
            courses(first: 3, after: "Mg=="){
                edges{
                    node{
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
                    cursor
                }
                pageInfo{
                    endCursor
                    hasNextPage
                    hasPreviousPage
                }
                totalCount
            }
        }
         */
        // This implements cursor based pagination. Also there is offset based pagination.
        // By default if we use this pagination approach just using the attribute all the data would still be fetched. What we can do is pass IQueryable instead of IEnumerable and then hot chocolate will do all the work to perform pagination till database level. 
        // But returning IQueryable is not a good idea and also as per our current implementation dbContext is disposed hence we can't return IQuerable.
        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            var courses = await _courseRepository.Get();

            return courses.Select(x => new CourseType
            {
                Id = x.Id,
                Name = x.Name,
                Subject = x.Subject,
                InstructorId = x.InstructorId
            });

            // In Below code the Instructor is being fetch and mapped even when it is not requested for. This means the joins while performing the data fetch on courses is getting wasted. 
            // To Solve this problem we can write a resolver for Instructor to fetch the data only when it is being requested for and not everytime while making the query. 
            /*
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
            */
        }

        /*
         query{
            paginatedCourses(first: 3){
                edges{
                    node{
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
                pageInfo{
                    hasNextPage
                    hasPreviousPage
                }
                totalCount
            }
        }*/
        [UseDbContext(typeof(SchoolDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        public async Task<IQueryable<CourseType>> GetPaginatedCourses([ScopedService] SchoolDbContext schoolDbContext)
        {
            return schoolDbContext.Courses.Select(x => new CourseType
            {
                Id = x.Id,
                Name = x.Name,
                Subject = x.Subject,
                InstructorId = x.InstructorId
            });
        }

        /*
         query{
        offSetCourses(skip: 3, take: 3){
            items{
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
            pageInfo{
                hasNextPage
                hasPreviousPage
            }
            totalCount
        }
    }
         */
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        public async Task<IEnumerable<CourseType>> GetOffSetCourses()
        {
            var courses = await _courseRepository.Get();

            return courses.Select(x => new CourseType
            {
                Id = x.Id,
                Name = x.Name,
                Subject = x.Subject,
                InstructorId = x.InstructorId
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
                Subject = course.Subject,
                InstructorId = course.InstructorId
            };

            // In Below code the Instructor is being fetch and mapped even when it is not requested for. This means the joins while performing the data fetch on courses is getting wasted. 
            // To Solve this problem we can write a resolver for Instructor to fetch the data only when it is being requested for and not everytime while making the query. 
            /*
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
            */
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
