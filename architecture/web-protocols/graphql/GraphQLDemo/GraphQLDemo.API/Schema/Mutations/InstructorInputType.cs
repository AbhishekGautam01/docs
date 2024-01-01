using GraphQLDemo.API.Model;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class InstructorInputType
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public Subject Subject { get; set; }
    }
}
