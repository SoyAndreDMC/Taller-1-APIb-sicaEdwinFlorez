using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Employee.Frontend.AuthenticationProviders;

public class AuthenticationProviderTest : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonimous = new ClaimsIdentity();
        var user = new ClaimsIdentity(authenticationType: "test");
        var admin = new ClaimsIdentity(
        [
            new("FirstName", "Edwin"),
            new("LastName", "Florez"),
            new(ClaimTypes.Name, "edwin@yopmail.com"),
            new(ClaimTypes.Role, "Admin")
        ],
        authenticationType: "test");

        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
    }
}