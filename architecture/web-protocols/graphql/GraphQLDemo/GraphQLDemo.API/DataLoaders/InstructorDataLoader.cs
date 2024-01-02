using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Services.Instructor;

namespace GraphQLDemo.API.DataLoaders
{
    public class InstructorDataLoader : BatchDataLoader<Guid, InstructorDTO>
    {
        private readonly InstructorRepository instructorRepository;

        public InstructorDataLoader(InstructorRepository instructorRepository ,IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            this.instructorRepository = instructorRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, InstructorDTO>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
           var instructors = await  instructorRepository.GetManyById(keys);
           return instructors.ToDictionary(i => i.Id);
        }
    }
}
