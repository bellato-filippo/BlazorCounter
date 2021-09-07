using BlazorCounter.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace BlazorCounter.Client.Pages;

public partial class Index
{
    [Inject]
    public HttpClient Http {  get; set; }
    [Inject]
    public NavigationManager NavigationManager {  get; set; }

    private string apiUrl = @"http://localhost:5002/api/authser";
    public void Redirect()
    {
        NavigationManager.NavigateTo("login");
    }
    public AuthCli Temp;
    protected override Task OnInitializedAsync()
    {
        return CaricaEventi();
    }

    private async Task CaricaEventi()
    {
        Temp = await Http.GetFromJsonAsync<AuthCli>($"{apiUrl}/{1}");
    }
}
