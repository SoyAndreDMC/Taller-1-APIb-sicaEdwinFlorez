using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.Repositories.Interfaces;

public interface IClerksRepository
{
    Task<ActionResponse<Clerk>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Clerk>>> GetAsync();

    Task<ActionResponse<IEnumerable<Clerk>>> GetByNameAsync(string filter);
}