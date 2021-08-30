using Microsoft.AspNetCore.Components;
namespace BlazorCounter.Client.Components;
public partial class DettaglioEvento
{
    [Parameter]
    public Models.Evento? DettaglioElemento {  get; set; }

    [Parameter]
    public EventCallback<Models.Evento> OnSalva {  get; set; }

    [Parameter]
    public EventCallback OnAnnulla {  get; set; }
}
