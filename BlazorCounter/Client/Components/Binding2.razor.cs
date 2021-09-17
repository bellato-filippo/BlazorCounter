
using BlazorCounter.Client.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class Binding2
{
    [Parameter]
    public Numero Value2 {  get; set; }

    [Parameter]
    public bool Compare {  get; set; }
}
