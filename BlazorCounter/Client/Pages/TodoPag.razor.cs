using System.Net.Http.Json;

namespace BlazorCounter.Client.Pages;

public partial class TodoPag
{

    private string apiUrl = @"http://localhost:5002/api/TodoSer";

    public Models.TodoCli TodoCorrente { get; set; } = new();
    public List<Models.TodoCli> ListaCorrente {  get; set; } = new List<Models.TodoCli>();

    protected override Task OnInitializedAsync()
    {
        return CaricaElementi();
    }

    private async Task CaricaElementi()
    {
        ListaCorrente = await Http.GetFromJsonAsync<List<Models.TodoCli>>(apiUrl);
    }

    public async Task Salva(Models.TodoCli t)
    {
        await Http.PostAsJsonAsync(apiUrl, t);
        TodoCorrente.Frase = "";
        ListaCorrente = await Http.GetFromJsonAsync<List<Models.TodoCli>>(apiUrl);
    }

    public async Task Elimina(Models.TodoCli t)
    {
        await Http.DeleteAsync($"{apiUrl}/{t.Id}");
        ListaCorrente = await Http.GetFromJsonAsync<List<Models.TodoCli>>(apiUrl);
    }
}
