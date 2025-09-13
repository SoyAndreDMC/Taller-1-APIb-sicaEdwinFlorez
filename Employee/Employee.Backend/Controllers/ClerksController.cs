using Employee.Backend.Data;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClerksController : GenericController<Clerk>
{
    public ClerksController(IGenericUnitOfWork<Clerk> unitOfWork) : base(unitOfWork)
    {
    }
}