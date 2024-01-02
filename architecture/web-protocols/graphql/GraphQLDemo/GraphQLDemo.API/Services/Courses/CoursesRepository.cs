using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Courses
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _context;

        public CoursesRepository(IDbContextFactory<SchoolDbContext> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDTO>> Get()
        {
            using(SchoolDbContext schoolDbContext = _context.CreateDbContext()) { 
                return await schoolDbContext.Courses
                    .ToListAsync<CourseDTO>();
            }
        }

        public async Task<CourseDTO> GetById(Guid id)
        {
            using (SchoolDbContext  schoolDbContext = _context.CreateDbContext())
            {
                return await schoolDbContext.Courses.FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using(SchoolDbContext schoolDbContext = _context.CreateDbContext())
            {
                schoolDbContext.Courses.Add(course);
                await schoolDbContext.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDbContext schoolDbContext = _context.CreateDbContext())
            {
                schoolDbContext.Courses.Update(course);
                await schoolDbContext.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext schoolDbContext = _context.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    Id = id };
                schoolDbContext.Courses.Remove(course);
                return await schoolDbContext.SaveChangesAsync() > 0;
            }
        }
    }
}
