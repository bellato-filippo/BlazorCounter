using Microsoft.AspNetCore.Components;
namespace BlazorCounter.Client.Components;
public partial class ListaEventi
{
    [Parameter]
    public string Titolo { get; set; } = "Lista eventi";
    [Parameter]
    public List<Models.ElementoListaEventi>? ListaEl { get; set; }

    [Parameter]
    public EventCallback<Models.ElementoListaEventi> OnElimina { get; set; }

    [Parameter]
    public EventCallback OnCrea {  get; set; }

    [Parameter]
    public EventCallback<Models.ElementoListaEventi> OnModifica {  get; set; }
}
