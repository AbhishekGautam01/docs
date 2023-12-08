namespace GraphQLDemo.API.Schema.Queries
{
    public class Mutation
    {
        private readonly List<CourseType> _courses;
        public Mutation()
        {
            _courses = new List<CourseType>();
        }

        /*
         mutation{
          createCourse(name: "algo", subject: MATHS, instructorId: "c4c60b46-ab4c-49d2-a929-69765aae1a4f")
        }
         */
        public bool CreateCourse(string name, Subject subject, Guid instructorId)
        {
            CourseType course = new CourseType()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                Instructor = new InstructorType
                {
                    Id = instructorId,
                }
            };
            _courses.Add(course);
            return true;
        }
    }
}
