using Employee.Frontend.Repositories;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Clerks;

public partial class ClerkEdit
{
    private Clerk? clerk;

    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [CascadingParameter] public IMudDialogInstance? MudDialog { get; set; }

    [Parameter] public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await Repository.GetAsync<Clerk>($"api/clerks/{Id}");

        if (response.Error)
        {
            if (response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                if (MudDialog != null)
                    MudDialog.Cancel();
                else
                    Nav.NavigateTo("clerks");
                return;
            }

            var msg = await response.GetErrorMessageAsync();
            Snackbar.Add(msg ?? "Error al cargar el empleado.", Severity.Error);
            MudDialog?.Cancel();
            return;
        }

        clerk = response.Response!;
    }

    private async Task EditAsync(Clerk model)
    {
        var response = await Repository.PutAsync("api/clerks", model);

        if (response.Error)
        {
            var msg = await response.GetErrorMessageAsync();
            Snackbar.Add(msg ?? "Error al guardar.", Severity.Error);
            return;
        }

        Snackbar.Add("Registro guardado.", Severity.Success);
        MudDialog?.Close(DialogResult.Ok(true));
    }

    private void Cancel() => MudDialog?.Cancel();
}