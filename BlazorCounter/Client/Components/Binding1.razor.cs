
using BlazorCounter.Client.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class Binding1
{
    [Parameter]
    public Numero Value1 { get; set; }

    [Parameter]
    public EventCallback Up { get; set; }

    [Parameter]
    public bool Compare {  get; set; }

    [Parameter]
    public EventCallback CompareOriginalValue {  get; set; }

    [Parameter]
    public EventCallback Conferma {  get; set; }
}
