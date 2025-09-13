using Employee.Backend.Data;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClerksController : ControllerBase
{
    private readonly DataContext _context;

    public ClerksController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Clerks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Clerk clerk)
    {
        _context.Clerks.Add(clerk);
        await _context.SaveChangesAsync();
        return Ok(clerk);
    }
}