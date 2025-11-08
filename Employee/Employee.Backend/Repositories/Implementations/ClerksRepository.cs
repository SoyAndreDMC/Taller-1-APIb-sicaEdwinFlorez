using Employee.Backend.Data;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.DTOs;
using Employee.Shared.Entities;
using Employee.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations;

public class ClerksRepository : GenericRepository<Clerk>, IClerksRepository
{
    private readonly DataContext _context;

    public ClerksRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Clerk>> GetComboAsync()
    {
        return await _context.Clerks
            .OrderBy(c => c.LastName)
            .ToListAsync();
    }

    public async Task<ActionResponse<IEnumerable<Clerk>>> GetAsync(PaginationDTO pagination, string? filter)
    {
        var q = _context.Clerks.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            var f = filter.Trim().ToLower();
            q = q.Where(c => c.FirstName.ToLower().Contains(f) || c.LastName.ToLower().Contains(f));
        }

        q = q.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);

        int page = pagination.Page <= 0 ? 1 : pagination.Page;
        int take = pagination.RecordsNumber <= 0 ? 10 : Math.Min(pagination.RecordsNumber, 100);
        int skip = (page - 1) * take;

        var items = await q.Skip(skip).Take(take).ToListAsync();

        return new ActionResponse<IEnumerable<Clerk>> { WasSuccess = true, Result = items };
    }

    public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination, string? filter)
    {
        var q = _context.Clerks.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            var f = filter.Trim().ToLower();
            q = q.Where(c => c.FirstName.ToLower().Contains(f) || c.LastName.ToLower().Contains(f));
        }

        var total = await q.CountAsync();
        return new ActionResponse<int> { WasSuccess = true, Result = total };
    }

    public override async Task<ActionResponse<IEnumerable<Clerk>>> GetAsync()
    {
        var clerks = await _context.Clerks
            .ToListAsync();
        return new ActionResponse<IEnumerable<Clerk>>
        {
            WasSuccess = true,
            Result = clerks
        };
    }

    public override async Task<ActionResponse<Clerk>> GetAsync(int id)
    {
        var clerks = await _context.Clerks
            .FirstOrDefaultAsync(x => x.Id == id);
        if (clerks == null)
        {
            return new ActionResponse<Clerk>
            {
                Message = "Registro no encontrado."
            };
        }
        return new ActionResponse<Clerk>
        {
            WasSuccess = true,
            Result = clerks
        };
    }

    public async Task<ActionResponse<IEnumerable<Clerk>>> GetByNameAsync(string filter)
    {
        var f = filter.Trim().ToLower();
        var items = await _context.Clerks
            .AsNoTracking()
            .Where(c => c.FirstName.ToLower().Contains(f) || c.LastName.ToLower().Contains(f))
            .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
            .ToListAsync();

        return new ActionResponse<IEnumerable<Clerk>> { WasSuccess = true, Result = items };
    }
}