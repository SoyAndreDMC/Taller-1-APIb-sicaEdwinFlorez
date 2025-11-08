using Employee.Backend.Data;
using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Implementations;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.DTOs;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class ClerksController : GenericController<Clerk>
{
    private readonly IClerksUnitOfWork _clerksUnitOfWork;

    public ClerksController(IGenericUnitOfWork<Clerk> unitOfWork, IClerksUnitOfWork clerksUnitOfWork) : base(unitOfWork)
    {
        _clerksUnitOfWork = clerksUnitOfWork;
    }

    [AllowAnonymous]
    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _clerksUnitOfWork.GetComboAsync());
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var filter = HttpContext?.Request?.Query["filter"].ToString();
        filter = string.IsNullOrWhiteSpace(filter) ? null : filter;

        var response = await _clerksUnitOfWork.GetAsync(pagination, filter);
        return response.WasSuccess
            ? Ok(response.Result)
            : BadRequest(response.Message ?? "No fue posible obtener los empleados.");
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