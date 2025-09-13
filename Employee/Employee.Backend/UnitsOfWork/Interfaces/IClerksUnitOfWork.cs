using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Interfaces;

public interface IClerksUnitOfWork
{
    Task<ActionResponse<Clerk>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Clerk>>> GetAsync();

    Task<ActionResponse<IEnumerable<Clerk>>> GetByNameAsync(string filter);
}