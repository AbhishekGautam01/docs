using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema.Queries;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Services.Instructor;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    #region EF CORE MUTATION IMPLEMENTATIONS
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO course = new CourseDTO()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = (DTOs.Subject)courseInput.Subject,
                InstructorId = courseInput.InstructorId,
            };

            course = await _coursesRepository.Create(course);

            CourseResult courseResult = new CourseResult()
            {
                Id = course.Id,
                Name = course.Name,
                Subject = (Queries.Subject)course.Subject,
                InstructorId = course.InstructorId,
            };

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), courseResult);
            return courseResult;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO course = new CourseDTO()
            {
                Id = id,
                Name = courseInput.Name,
                Subject = (DTOs.Subject)courseInput.Subject,
                InstructorId = courseInput.InstructorId,
            };

            course = await _coursesRepository.Update(course);

            CourseResult courseResult = new CourseResult()
            {
                Id = course.Id,
                Name = course.Name,
                Subject = (Queries.Subject)course.Subject,
                InstructorId = course.InstructorId,
            };

            string courseUpdateTopic = $"{course.Id}_{nameof(Subscription.CourseUpdate)}";
            await topicEventSender.SendAsync(courseUpdateTopic, courseResult);

            return courseResult;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
    #endregion
    
    #region OLD SIMPLER MUTATION EXAMPLES
    //public class Mutation
    //{
    //    private readonly List<CourseResult> _courses;

    //    public Mutation()
    //    {
    //        _courses = new List<CourseResult>();
    //    }

    //    /*
    //    mutation{
    //      createCourse(courseInput: {
    //        name: "Algo",
    //        subject: MATHS,
    //        instructorId: "faf9f622-dbce-4f0e-9dd8-6d4ad553171c"
    //      }){
    //        id
    //        name
    //      }
    //    }
    //     */
    //    // Directly injecting the ITopicSender Dependency to mutation method using the ITopicEventSender.
    //    public async Task<CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
    //    {
    //        CourseResult course = new CourseResult()
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = courseInput.Name,
    //            Subject = courseInput.Subject,
    //            Instructor = new InstructorType
    //            {
    //                Id = courseInput.InstructorId,
    //            }
    //        };
    //        _courses.Add(course);
    //        // Topic Name is method name however we can give custom name for this using [Topic] Attribute.
    //        await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
    //        return course;
    //    }

    //    /*
    //     mutation{
    //      updateCourse(id: "893d3d8e-5587-46e3-bcc6-7cf4ba5f7d85", name: "algo & ds", subject: SCIENCE, instructorId: "c4c60b46-ab4c-49d2-a929-69765aae1a4f"){
    //        id,
    //        name
    //      }
    //    }

    //    ERROR RESPONSE:
    //    {
    //      "errors": [
    //        {
    //          "message": "Unexpected Execution Error",
    //          "locations": [
    //            {
    //              "line": 2,
    //              "column": 3
    //            }
    //          ],
    //          "path": [
    //            "updateCourse"
    //          ],
    //          "extensions": {
    //            "message": "Course not found",
    //            "stackTrace": "   at GraphQLDemo.API.Schema.Mutations.Mutation.UpdateCourse(Guid id, String name, Subject subject, Guid instructorId) in F:\\docs\\architecture\\web-protocols\\graphql\\GraphQLDemo\\GraphQLDemo.API\\Schema\\Mutations\\Mutation.cs:line 42\r\n   at lambda_method55(Closure , IResolverContext )\r\n   at HotChocolate.Types.Helpers.FieldMiddlewareCompiler.<>c__DisplayClass9_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location ---\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"
    //          }
    //        }
    //      ]
    //    }
    //     */
    //    public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
    //    {
    //        var course = _courses.FirstOrDefault(x => x.Id == id);
    //        if (course == null)
    //        {
    //            // Specific GraphQL Exception whcih can return multiple exceptions.
    //            throw new GraphQLException(new Error("Course Not Found", "COURSE_NOT_FOUND"));
    //        }

    //        course.Name = courseInput.Name;
    //        course.Subject = courseInput.Subject;
    //        course.Instructor = new InstructorType
    //        {
    //            Id = courseInput.InstructorId,
    //        };
    //        // When listening for specific events we dont publish using the subscription name, we make the topic name as below
    //        string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdate)}";
    //        await topicEventSender.SendAsync(updateCourseTopic, course);
    //        return course;
    //    }

    //    /*mutation{
    //      deleteCourse(id: "faf9f622-dbce-4f0e-9dd8-6d4ad553171c")
    //    }*/
    //    public bool DeleteCourse(Guid id)
    //    {
    //        var course = _courses.FirstOrDefault(x => x.Id == id);
    //        if (course == null)
    //        {
    //            // Specific GraphQL Exception whcih can return multiple exceptions.
    //            throw new GraphQLException(new Error("Course Not Found", "COURSE_NOT_FOUND"));
    //        }
    //        return _courses.Remove(course);
    //    }
    //}
    #endregion


}
