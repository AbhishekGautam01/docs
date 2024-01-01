namespace GraphQLDemo.API.Schema.Queries
{
    public class StudentResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }
    }
}
