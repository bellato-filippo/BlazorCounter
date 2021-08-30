using BlazorCounter.Client.Models;

namespace BlazorCounter.Client.Pages;

public partial class Index
{
    List<ElementoListaEventi> ListaEventiPassati { get; set; }
        = new List<ElementoListaEventi>
            {
                new ElementoListaEventi() { Id = 1, Nome="DevDay Benevento - Blazor", Localita="Benvento", Data = new DateTime(2020, 2,8)},
                new ElementoListaEventi() { Id = 2, Nome="DotNetSide Bari - Blazor", Localita="Bari", Data = new DateTime(2020, 2, 21)}
            };

    List<ElementoListaEventi> ListaEventii { get; set; }
        = new List<ElementoListaEventi>
            {
                new ElementoListaEventi() { Id = 3, Nome="Mercoledi del Palazzo - Blazor", Localita="Salerno", Data = new DateTime(2020, 3, 11)},
                new ElementoListaEventi() { Id = 4, Nome="Visual Studio Tour - Blazor", Localita="Cagliari", Data = new DateTime(2020, 3, 21)}
            };

    public void EliminaElemento(Models.ElementoListaEventi evento)
    {
        this.ListaEventii.Remove(evento);
    }

    public void EliminaElementoPassato(Models.ElementoListaEventi evento)
    {
        this.ListaEventiPassati.Remove(evento);
    }
}
