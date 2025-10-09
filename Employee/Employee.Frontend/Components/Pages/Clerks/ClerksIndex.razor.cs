using Employee.Frontend.Repositories;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Employee.Frontend.Components.Pages.Clerks
{
    public partial class ClerksIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        private List<Clerk>? clerks;

        protected override async Task OnInitializedAsync()
        {
            var httpResult = await Repository.GetAsync<List<Clerk>>("/api/clerks");
            clerks = httpResult.Response;
        }
    }
}