using System;
using System.Collections.Concurrent;

namespace Decorator
{
    public class CachedAuthorRepository : IAuthorRepository
    {
        private readonly IAuthorRepository _repo;
        private readonly ConcurrentDictionary<Guid, Author> _dict;
        public CachedAuthorRepository(IAuthorRepository repo)
        {
            _repo = repo;
            _dict = new ConcurrentDictionary<Guid, Author>();
        }

        public Author GetById(Guid id)
        {
            return _dict.GetOrAdd(id, i => _repo.GetById(i));
        }
    }
}
