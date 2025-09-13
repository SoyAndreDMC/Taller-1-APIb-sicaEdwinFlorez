using Employee.Shared.Entities;

namespace Employee.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckClerksAsync();
    }

    private async Task CheckClerksAsync()
    {
        _context.Clerks.Add(new Clerk { FirstName = "Nicolle", LastName = "Cañas", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2025, 4, 15)), Salary = 1600000 });
        _context.Clerks.Add(new Clerk { FirstName = "Edwin", LastName = "Florez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2025, 7, 12)), Salary = 2000000 });
        _context.Clerks.Add(new Clerk { FirstName = "María", LastName = "Pérez", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2023, 7, 5)), Salary = 1800000 });
        _context.Clerks.Add(new Clerk { FirstName = "Carlos", LastName = "Ramírez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2022, 9, 20)), Salary = 2500000 });
        _context.Clerks.Add(new Clerk { FirstName = "Laura", LastName = "Martínez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2021, 3, 14)), Salary = 1700000 });
        _context.Clerks.Add(new Clerk { FirstName = "David", LastName = "Gómez", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2020, 1, 25)), Salary = 1500000 });
        _context.Clerks.Add(new Clerk { FirstName = "Camila", LastName = "Rodríguez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2019, 11, 30)), Salary = 2200000 });
        _context.Clerks.Add(new Clerk { FirstName = "Jorge", LastName = "Castro", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 6, 18)), Salary = 1950000 });
        _context.Clerks.Add(new Clerk { FirstName = "Sofía", LastName = "Hernández", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2017, 8, 8)), Salary = 1400000 });
        _context.Clerks.Add(new Clerk { FirstName = "Felipe", LastName = "Torres", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2016, 2, 2)), Salary = 2100000 });
        _context.Clerks.Add(new Clerk { FirstName = "Juan", LastName = "Palomino", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2024, 3, 10)), Salary = 1800000 });
        _context.Clerks.Add(new Clerk { FirstName = "Julian", LastName = "Puertas", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2023, 6, 22)), Salary = 1900000 });
        _context.Clerks.Add(new Clerk { FirstName = "Ana", LastName = "Malagon", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2022, 9, 5)), Salary = 1750000 });
        _context.Clerks.Add(new Clerk { FirstName = "Cristian", LastName = "Juarez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2021, 12, 18)), Salary = 2000000 });
        _context.Clerks.Add(new Clerk { FirstName = "Daniela", LastName = "Sosa", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2020, 11, 1)), Salary = 1850000 });
        _context.Clerks.Add(new Clerk { FirstName = "Julieta", LastName = "Riveros", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2019, 5, 27)), Salary = 1600000 });
        _context.Clerks.Add(new Clerk { FirstName = "Julián", LastName = "Cifuentes", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 7, 14)), Salary = 2100000 });
        _context.Clerks.Add(new Clerk { FirstName = "Juana", LastName = "Zuluaga", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2017, 2, 3)), Salary = 1700000 });
        _context.Clerks.Add(new Clerk { FirstName = "Julia", LastName = "Gonzalez", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2016, 8, 29)), Salary = 1500000 });
        _context.Clerks.Add(new Clerk { FirstName = "Andrés", LastName = "Benjumea", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2015, 4, 12)), Salary = 2300000 });
        await _context.SaveChangesAsync();
    }
}