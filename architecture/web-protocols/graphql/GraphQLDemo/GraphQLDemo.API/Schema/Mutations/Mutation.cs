using GraphQLDemo.API.Schema.Queries;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;
        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        /*
        mutation{
          createCourse(courseInput: {
            name: "Algo",
            subject: MATHS,
            instructorId: "faf9f622-dbce-4f0e-9dd8-6d4ad553171c"
          }){
            id
            name
          }
        }
         */
        public CourseResult CreateCourse(CourseInputType courseInput)
        {
            CourseResult course = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                Instructor = new InstructorType
                {
                    Id = courseInput.InstructorId,
                }
            };
            _courses.Add(course);
            return course;
        }

        /*
         mutation{
          updateCourse(id: "893d3d8e-5587-46e3-bcc6-7cf4ba5f7d85", name: "algo & ds", subject: SCIENCE, instructorId: "c4c60b46-ab4c-49d2-a929-69765aae1a4f"){
            id,
            name
          }
        }

        ERROR RESPONSE:
        {
          "errors": [
            {
              "message": "Unexpected Execution Error",
              "locations": [
                {
                  "line": 2,
                  "column": 3
                }
              ],
              "path": [
                "updateCourse"
              ],
              "extensions": {
                "message": "Course not found",
                "stackTrace": "   at GraphQLDemo.API.Schema.Mutations.Mutation.UpdateCourse(Guid id, String name, Subject subject, Guid instructorId) in F:\\docs\\architecture\\web-protocols\\graphql\\GraphQLDemo\\GraphQLDemo.API\\Schema\\Mutations\\Mutation.cs:line 42\r\n   at lambda_method55(Closure , IResolverContext )\r\n   at HotChocolate.Types.Helpers.FieldMiddlewareCompiler.<>c__DisplayClass9_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location ---\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"
              }
            }
          ]
        }
         */
        public CourseResult UpdateCourse(Guid id, CourseInputType courseInput)
        {
            var course = _courses.FirstOrDefault(x => x.Id == id);
            if(course == null)
            {
                // Specific GraphQL Exception whcih can return multiple exceptions.
                throw new GraphQLException(new Error("Course Not Found", "COURSE_NOT_FOUND"));
            }

            course.Name = courseInput.Name;
            course.Subject = courseInput.Subject;
            course.Instructor = new InstructorType
            {
                Id = courseInput.InstructorId,
            };
            return course;
        }

        /*mutation{
          deleteCourse(id: "faf9f622-dbce-4f0e-9dd8-6d4ad553171c")
        }*/
        public bool DeleteCourse(Guid id) {
            var course = _courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                // Specific GraphQL Exception whcih can return multiple exceptions.
                throw new GraphQLException(new Error("Course Not Found", "COURSE_NOT_FOUND"));
            }
            return _courses.Remove(course);
        }
    }
}
