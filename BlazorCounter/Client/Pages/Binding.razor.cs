
using BlazorCounter.Client.Models;

namespace BlazorCounter.Client.Pages;
public partial class Binding
{
    public Numero Val { get; set; } = new Numero();

    public void Su()
    {
        Val.Value++;
        Console.WriteLine("Premuto Up");
        Console.WriteLine("Valore attuale: " + Val.Value);
        Console.WriteLine("Valore vecchio: " + Val.CompareValue);
    }

    public bool Compara = false;

    public void CompareOriginal()
    {
        Val.CompareValue = Val.Value;
        Val.Value = 0;
        Compara = true;
        Console.WriteLine("Premuto Compare");
        Console.WriteLine("Valore attuale: " + Val.Value);
        Console.WriteLine("Valore vecchio: " + Val.CompareValue);
    }

    public void Ok()
    {
        Compara = false;
        Console.WriteLine("Premuto Conferma");
        Console.WriteLine("Valore attuale: " + Val.Value);
        Console.WriteLine("Valore vecchio: " + Val.CompareValue);
    }
}
