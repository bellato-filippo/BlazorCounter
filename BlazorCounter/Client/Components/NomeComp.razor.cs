
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class NomeComp : ComponentBase
{
    [Parameter]
    public Models.NomeCli? N { get; set; }
    [Parameter]
    public List<Models.NomeCli>? ListaNome { get; set; }
    [Parameter]
    public EventCallback<Models.NomeCli> OnSalva { get; set; }
    [Parameter]
    public EventCallback Nav {  get; set; }
}
