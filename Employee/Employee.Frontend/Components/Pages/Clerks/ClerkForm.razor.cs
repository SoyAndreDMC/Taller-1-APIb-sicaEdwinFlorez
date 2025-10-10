using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;

namespace Employee.Frontend.Components.Pages.Clerks;

public partial class ClerkForm
{
    private EditContext editContext = default!;
    private DateTime? _hireDate;

    [EditorRequired, Parameter] public Clerk Clerk { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback<Clerk> OnSave { get; set; }
    [EditorRequired, Parameter] public EventCallback OnCancel { get; set; }

    protected override void OnParametersSet()
    {
        if (editContext is null || !ReferenceEquals(editContext.Model, Clerk))
            editContext = new EditContext(Clerk);

        _hireDate = Clerk.HireDate == default
            ? (DateTime?)null
            : Clerk.HireDate.ToDateTime(TimeOnly.MinValue);
    }

    private async Task HandleValidSubmit()
    {
        Clerk.HireDate = _hireDate.HasValue
            ? DateOnly.FromDateTime(_hireDate.Value)
            : default;

        await OnSave.InvokeAsync(Clerk);
    }

    private async Task HandleCancel() => await OnCancel.InvokeAsync();
}