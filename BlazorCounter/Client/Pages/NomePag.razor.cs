
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCounter.Client.Pages;
public partial class NomePag
{
    [Inject]
    public HttpClient Http {  get; set; }
    [Inject]
    public NavigationManager NavigationManager {  get; set; }

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
        await Http.PostAsJsonAsync(apiUrl, no);
        NomeCorrente.Name = "";
        await caricaEventi();
    }

    public void Vai()
    {
        NavigationManager.NavigateTo("Eventi");
    }

    public async Task Elimina(Models.NomeCli nom)
    {
        try
        {
            int last = ListaCorrente.Count - 1;
            int del = ListaCorrente.ElementAt(last).Id;
            await Http.DeleteAsync($"{apiUrl}/{del}");
            ListaCorrente = await Http.GetFromJsonAsync<List<Models.NomeCli>>(apiUrl);
        } catch (System.ArgumentOutOfRangeException)
        {
            ListaCorrente = await Http.GetFromJsonAsync<List<Models.NomeCli>>(apiUrl);
        }
    }
}
