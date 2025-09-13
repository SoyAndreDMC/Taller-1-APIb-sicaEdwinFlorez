using Employee.Backend.Data;
using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Implementations;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClerksController : GenericController<Clerk>
{
    private readonly IClerksUnitOfWork _clerksUnitOfWork;

    public ClerksController(IGenericUnitOfWork<Clerk> unitOfWork, IClerksUnitOfWork clerksUnitOfWork) : base(unitOfWork)
    {
        _clerksUnitOfWork = clerksUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await _clerksUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _clerksUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }

    [HttpGet("byname/{filter}")]
    public async Task<IActionResult> GetByNameAsync(string filter)
    {
        var action = await _clerksUnitOfWork.GetByNameAsync(filter);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return NotFound(action.Message);
    }
}