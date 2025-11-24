using Employee.Frontend.Repositories;
using Employee.Frontend.Services;
using Employee.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Employee.Frontend.Components.Pages.Auth;

public partial class Login
{
    private LoginDTO loginDTO = new();
    private bool wasClose;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private ILoginService LoginService { get; set; } = null!;

    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;

    private void ShowModalResendConfirmationEmail()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true, MaxWidth = MaxWidth.ExtraLarge };
        DialogService.Show<ResendConfirmationEmailToken>("Reenvio de correo", options);
    }

    private void ShowModalRecoverPassword()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true, MaxWidth = MaxWidth.ExtraLarge };
        DialogService.Show<RecoverPassword>("Rec. contraseña", options);
    }

    private void CloseModal()
    {
        wasClose = true;
        MudDialog.Cancel();
    }

    private async Task LoginAsync()
    {
        if (wasClose)
        {
            NavigationManager.NavigateTo("/");
            return;
        }

        var responseHttp = await Repository.PostAsync<LoginDTO, TokenDTO>("/api/accounts/Login", loginDTO);

        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message ?? "Ha ocurrido un error inesperado al iniciar sesión.", Severity.Error);
            return;
        }

        try
        {
            await LoginService.LoginAsync(responseHttp.Response!.Token);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error procesando el token de login: {ex.Message}", Severity.Error);

            await LoginService.LogoutAsync();
        }
    }
}