using Microsoft.AspNetCore.Components;


namespace BlazorCounter.Client.Components;
public partial class CounterComp : ComponentBase
{
    [Parameter]
    public int Skip { get; set; } = 1;

    [Parameter]
    public Models.ContatoreCli? Cont { get; set; }

    [Parameter]
    public EventCallback<Models.ContatoreCli> OnSalva { get; set; }

    [Parameter]
    public EventCallback Up {  get; set; }

    [Parameter]
    public EventCallback Down {  get; set; }
    /*
    public void Up()
    {
        Cont.Valore += Skip;
    }

    public void Down()
    {
        Cont.Valore -= Skip;
    }
    */
}
