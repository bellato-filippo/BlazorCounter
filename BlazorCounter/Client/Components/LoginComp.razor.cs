using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class LoginComp
{
    [Inject]
    public HttpClient Http {  get; set; }

    //[Parameter]
    public EventCallback<Models.AuthCli> OnSalva { get; set; }
    //[Parameter]
    public Models.AuthCli Dati {  get; set;} = new Models.AuthCli();

    public void IsAuth()
    {
        if (Dati.FirstName == "Fil" && Dati.LastName == "Bel" && Dati.Password == "Pass")
            Dati.IsAdmin = true;
        else
            Dati.IsAdmin = false;
    }


}
