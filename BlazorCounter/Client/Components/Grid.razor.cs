
using BlazorCounter.Client.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class Grid
{
    [Parameter]
    public List<ProdottoCli> ListaProd {  get; set; }

    [Parameter]
    public EventCallback OrderId {  get; set; }

    [Parameter]
    public EventCallback OrderName { get; set; }

    [Parameter]
    public EventCallback OrderDescription { get; set; }

    [Parameter]
    public EventCallback OrderPrice { get; set; }

    [Parameter]
    public EventCallback OrderDate { get; set; }
}
