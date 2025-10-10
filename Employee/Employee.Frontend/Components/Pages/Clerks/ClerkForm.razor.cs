using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Clerks;

public partial class ClerkForm
{
    private EditContext editContext = null!;

    [EditorRequired, Parameter] public Clerk Clerk { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    protected override void OnInitialized()
    {
        editContext = new(Clerk);
    }
}