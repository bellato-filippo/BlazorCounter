
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class Grid : ComponentBase
{
    [Parameter]
    public List<string>? Columns {  get; set;}
}
