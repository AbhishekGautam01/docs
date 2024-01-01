using GraphQLDemo.API.Model;
using GraphQLDemo.API.Schema.Queries;

namespace GraphQLDemo.API.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
        public virtual InstructorDTO Instructor { get; set; }

        public virtual IEnumerable<StudentDTO> Students { get; set; }
    }
}
