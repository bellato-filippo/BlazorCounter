
using System.Net.Http.Json;

namespace BlazorCounter.Client.Pages;
public partial class NomePag
{
    private string? apiUrl = @"http://localhost:5002/api/nomeser";
    public List<Models.NomeCli>? ListaCorrente { get; set; } = new List<Models.NomeCli>();
    public Models.NomeCli? NomeCorrente { get; set; } = new Models.NomeCli();

    protected override Task OnInitializedAsync()
    {
        return caricaEventi();
    }

    private async Task caricaEventi()
    {
        ListaCorrente = await Http.GetFromJsonAsync<List<Models.NomeCli>>(apiUrl);
    }

    public async Task Salvataggio(Models.NomeCli no)
    {
        await Http.PostAsJsonAsync<Models.NomeCli>(apiUrl, no);
        NomeCorrente.Name = "";
        await caricaEventi();
    }
}
