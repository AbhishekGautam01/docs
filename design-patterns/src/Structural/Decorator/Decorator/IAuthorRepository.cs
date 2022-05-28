using System;

namespace Decorator
{
    public interface IAuthorRepository
    {
        Author GetById(Guid Id);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Author GetById(Guid Id)
        {
            return _context.Authors.Find(x => x.Id == Id);
        }
    }
}
