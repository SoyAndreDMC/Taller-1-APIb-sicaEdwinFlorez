using Employee.Frontend.Repositories;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Clerks;

public partial class ClerkCreate
{
    private Clerk clerk = new()
    {
        FirstName = string.Empty,
        LastName = string.Empty,
        HireDate = DateOnly.FromDateTime(DateTime.Today),
        IsActive = true,
        Salary = 0
    };

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [CascadingParameter] private IMudDialogInstance? MudDialog { get; set; }

    private async Task CreateAsync(Clerk model)
    {
        var responseHttp = await Repository.PostAsync("/api/clerks", model);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message ?? "Ocurrió un error al crear el registro", Severity.Error);
            return;
        }

        Snackbar.Add("Registro creado", Severity.Success);
        MudDialog?.Close(DialogResult.Ok(true));
    }

    private void Return()
    {
        MudDialog?.Cancel();
    }
}