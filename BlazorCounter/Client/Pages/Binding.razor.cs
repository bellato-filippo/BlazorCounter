
namespace BlazorCounter.Client.Pages;
public partial class Binding
{
    public int Value { get; set; } = 10;

    public void Su()
    {
        Value++;
    }
}
