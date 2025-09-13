using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class ClerksUnitOfWork : GenericUnitOfWork<Clerk>, IClerksUnitOfWork
    {
        private readonly IClerksRepository _clerksRepository;

        public ClerksUnitOfWork(IGenericRepository<Clerk> repository, IClerksRepository clerksRepository) : base(repository)
        {
            _clerksRepository = clerksRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Clerk>>> GetAsync() => await _clerksRepository.GetAsync();

        public override async Task<ActionResponse<Clerk>> GetAsync(int id) => await _clerksRepository.GetAsync(id);

        public async Task<ActionResponse<IEnumerable<Clerk>>> GetByNameAsync(string filter) => await _clerksRepository.GetByNameAsync(filter);
    }
}