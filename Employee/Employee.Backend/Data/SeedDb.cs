using Employee.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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
        if (!_context.Clerks.Any())
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
            _context.Clerks.Add(new Clerk { FirstName = "Julieta", LastName = "Gomez", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2019, 5, 27)), Salary = 1600000 });
            _context.Clerks.Add(new Clerk { FirstName = "Julián", LastName = "Torres", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 7, 14)), Salary = 2100000 });
            _context.Clerks.Add(new Clerk { FirstName = "Juana", LastName = "Zuluaga", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2017, 2, 3)), Salary = 1700000 });
            _context.Clerks.Add(new Clerk { FirstName = "Julia", LastName = "Gonzalez", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2016, 8, 29)), Salary = 1500000 });
            _context.Clerks.Add(new Clerk { FirstName = "Andrés", LastName = "Benjumea", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2015, 4, 12)), Salary = 2300000 });

            _context.Clerks.Add(new Clerk { FirstName = "Mateo", LastName = "Valencia", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2024, 5, 21)), Salary = 1750000 });
            _context.Clerks.Add(new Clerk { FirstName = "Isabella", LastName = "López", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2023, 9, 1)), Salary = 1650000 });
            _context.Clerks.Add(new Clerk { FirstName = "Tomás", LastName = "Rojas", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2022, 11, 10)), Salary = 1450000 });
            _context.Clerks.Add(new Clerk { FirstName = "Valentina", LastName = "Cifuentes", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2021, 8, 12)), Salary = 2000000 });
            _context.Clerks.Add(new Clerk { FirstName = "Sebastián", LastName = "Arango", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2020, 10, 2)), Salary = 2100000 });
            _context.Clerks.Add(new Clerk { FirstName = "Martina", LastName = "Mejía", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2019, 6, 6)), Salary = 1550000 });
            _context.Clerks.Add(new Clerk { FirstName = "Emilio", LastName = "Restrepo", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 3, 4)), Salary = 2200000 });
            _context.Clerks.Add(new Clerk { FirstName = "Gabriela", LastName = "Ospina", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2017, 9, 9)), Salary = 1850000 });
            _context.Clerks.Add(new Clerk { FirstName = "Lucas", LastName = "Patiño", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2016, 5, 30)), Salary = 1400000 });
            _context.Clerks.Add(new Clerk { FirstName = "Antonia", LastName = "Becerra", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2015, 10, 25)), Salary = 2300000 });
            _context.Clerks.Add(new Clerk { FirstName = "Simón", LastName = "Mendoza", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2024, 1, 5)), Salary = 1950000 });
            _context.Clerks.Add(new Clerk { FirstName = "Victoria", LastName = "Salazar", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2023, 2, 15)), Salary = 1750000 });
            _context.Clerks.Add(new Clerk { FirstName = "Emilia", LastName = "Aristizábal", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2022, 4, 8)), Salary = 1500000 });
            _context.Clerks.Add(new Clerk { FirstName = "Santiago", LastName = "Duque", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2021, 11, 13)), Salary = 2050000 });
            _context.Clerks.Add(new Clerk { FirstName = "Manuela", LastName = "Echeverri", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2020, 7, 18)), Salary = 1850000 });
            _context.Clerks.Add(new Clerk { FirstName = "Samuel", LastName = "Roldán", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2019, 2, 1)), Salary = 1650000 });
            _context.Clerks.Add(new Clerk { FirstName = "Luciana", LastName = "Ortiz", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 12, 11)), Salary = 2000000 });
            _context.Clerks.Add(new Clerk { FirstName = "Nicolás", LastName = "Vásquez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2017, 6, 17)), Salary = 2150000 });
            _context.Clerks.Add(new Clerk { FirstName = "Sara", LastName = "Henao", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2016, 3, 29)), Salary = 1550000 });
            _context.Clerks.Add(new Clerk { FirstName = "Agustín", LastName = "Cardona", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2015, 8, 9)), Salary = 1900000 });
            _context.Clerks.Add(new Clerk { FirstName = "Daniel", LastName = "Giraldo", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2024, 6, 3)), Salary = 1750000 });
            _context.Clerks.Add(new Clerk { FirstName = "Paula", LastName = "Ruiz", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2023, 10, 22)), Salary = 1850000 });
            _context.Clerks.Add(new Clerk { FirstName = "Elena", LastName = "Castaño", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2022, 12, 5)), Salary = 1600000 });
            _context.Clerks.Add(new Clerk { FirstName = "Bruno", LastName = "Muñoz", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2021, 4, 2)), Salary = 2100000 });
            _context.Clerks.Add(new Clerk { FirstName = "Renata", LastName = "Galeano", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2020, 1, 9)), Salary = 2200000 });
            _context.Clerks.Add(new Clerk { FirstName = "Gabriel", LastName = "Quintero", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2019, 5, 24)), Salary = 1500000 });
            _context.Clerks.Add(new Clerk { FirstName = "Salomé", LastName = "Hoyos", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2018, 8, 28)), Salary = 1950000 });
            _context.Clerks.Add(new Clerk { FirstName = "Thiago", LastName = "Marín", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2017, 10, 7)), Salary = 2000000 });
            _context.Clerks.Add(new Clerk { FirstName = "Amanda", LastName = "Montoya", IsActive = false, HireDate = DateOnly.FromDateTime(new DateTime(2016, 1, 15)), Salary = 1450000 });
            _context.Clerks.Add(new Clerk { FirstName = "Benjamín", LastName = "Jiménez", IsActive = true, HireDate = DateOnly.FromDateTime(new DateTime(2015, 11, 3)), Salary = 2350000 });

            await _context.SaveChangesAsync();
        }
    }
}