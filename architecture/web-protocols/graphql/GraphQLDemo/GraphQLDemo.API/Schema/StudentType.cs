namespace GraphQLDemo.API.Schema
{
    public class StudentType
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [GraphQLName("gql")]
        public double GPA { get; set; }
    }
}
