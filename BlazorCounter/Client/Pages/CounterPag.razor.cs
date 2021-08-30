
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Pages;
public partial class CounterPag
{
    [Parameter]
    public int Skip { get; set; } = 1;

    public Models.ContatoreCli? Cont { get; set; }

    public void Up()
    {
        Cont.Valore += Skip;
    }

    public void Down()
    {
        Cont.Valore -= Skip;
    }
}
