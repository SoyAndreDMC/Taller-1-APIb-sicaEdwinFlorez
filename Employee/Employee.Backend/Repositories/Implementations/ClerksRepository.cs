using Employee.Backend.Data;
using Employee.Backend.Repositories.Interfaces;
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
        var clerks = await _context.Clerks
            .Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter))
            .ToListAsync();

        if (clerks == null || clerks.Count == 0)
        {
            return new ActionResponse<IEnumerable<Clerk>>
            {
                Message = "No se encontraron registros con ese criterio de búsqueda."
            };
        }

        return new ActionResponse<IEnumerable<Clerk>>
        {
            WasSuccess = true,
            Result = clerks
        };
    }
}