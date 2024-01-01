﻿using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Instructor
{
    public class InstructorRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;

        public InstructorRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<InstructorDTO> Get()
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                return context.Instructors
                    .Include(i => i.Courses)
                    .ToList();
            }
        }

        public async Task<InstructorDTO> GetByIdAsync(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Instructors.Include(i => i.Courses).FirstOrDefaultAsync(i => i.Id == id);
            }

        }

        public async Task<InstructorDTO> Create(InstructorDTO instructor)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Instructors.Add(instructor);
                await context.SaveChangesAsync();
                return instructor;
            }
        }

        public async Task<InstructorDTO> Update(InstructorDTO instructor)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                schoolDbContext.Instructors.Update(instructor);
                await schoolDbContext.SaveChangesAsync();
                return instructor;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext schoolDbContext = _dbContextFactory.CreateDbContext())
            {
                InstructorDTO instructor = new InstructorDTO()
                {
                    Id = id
                };
                schoolDbContext.Instructors.Remove(instructor);
                return await schoolDbContext.SaveChangesAsync() > 0;
            }
        }
    }
}
