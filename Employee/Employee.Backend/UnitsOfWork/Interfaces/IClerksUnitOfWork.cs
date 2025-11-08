using Employee.Shared.DTOs;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Interfaces;

public interface IClerksUnitOfWork
{
    Task<ActionResponse<IEnumerable<Clerk>>> GetAsync(PaginationDTO pagination, string? filter);

    Task<IEnumerable<Clerk>> GetComboAsync();

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination, string? filter);

    Task<ActionResponse<Clerk>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Clerk>>> GetAsync();

    Task<ActionResponse<IEnumerable<Clerk>>> GetByNameAsync(string filter);
}