
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class Binding1
{
    [Parameter]
    public int Value1 { get; set; }

    [Parameter]
    public EventCallback Up { get; set; }
}
