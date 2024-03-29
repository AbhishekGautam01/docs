﻿namespace GraphQLDemo.API.Schema.Queries
{
    public class InstructorType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public IEnumerable<CourseType> Courses { get; set; } = Enumerable.Empty<CourseType>();
    }
}
