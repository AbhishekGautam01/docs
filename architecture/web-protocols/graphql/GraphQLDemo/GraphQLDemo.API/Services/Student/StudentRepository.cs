using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Student
{
    public class StudentRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;

        public StudentRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<StudentDTO> Get()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Students
                    .ToList();
            }
        }

        public async Task<StudentDTO> GetByIdAsync(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Students.FirstOrDefaultAsync(i => i.Id == id);
            }

        }

        public async Task<StudentDTO> Create(StudentDTO student)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();
                return student;
            }
        }

        public async Task<StudentDTO> Update(StudentDTO student)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                schoolDbContext.Students.Update(student);
                await schoolDbContext.SaveChangesAsync();
                return student;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                StudentDTO student = new StudentDTO()
                {
                    Id = id
                };
                schoolDbContext.Students.Remove(student);
                return await schoolDbContext.SaveChangesAsync() > 0;
            }
        }
    }
}
