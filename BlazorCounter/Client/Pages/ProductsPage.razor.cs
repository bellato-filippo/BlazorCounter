using BlazorCounter.Client.Models;
namespace BlazorCounter.Client.Pages;
public partial class ProductsPage
{
    public List<ProdottoCli>? ListaCorrente { get; set; }
    = new List<ProdottoCli>();

    public void Generate()
    {
        for (int i = 1; i < 101; i++)
        {
            Random r = new Random();
            ProdottoCli Temp = new();
            Temp.Id = i;
            Temp.Name = "prodotto" + r.Next(1, 500);
            Temp.Description = "Descrizione" + r.Next(1, 500);
            Temp.CreationDate = DateTime.Now;
            Temp.Price = r.Next(5, 100);
            Temp.IsAvailable = r.Next(2) == 0;

            ListaCorrente.Add(Temp);
        }
    }

    public void SortById()
    {
        List<ProdottoCli> Temp = ListaCorrente.OrderBy(x => x.Id).ToList();
        ListaCorrente = Temp;
    }

    public void SortByName()
    {
        List<ProdottoCli> Temp = ListaCorrente.OrderBy(x => x.Name).ToList();
        ListaCorrente = Temp;
    }

    public void SortByDescription()
    {
        List<ProdottoCli> Temp = ListaCorrente.OrderBy(x => x.Description).ToList();
        ListaCorrente = Temp;
    }

    public void SortByPrice()
    {
        List<ProdottoCli> Temp = ListaCorrente.OrderBy(x => x.Price).ToList();
        ListaCorrente = Temp;
    }
    public void SortByDate()
    {
        List<ProdottoCli> Temp = ListaCorrente.OrderBy(x => x.CreationDate).ToList();
        ListaCorrente = Temp;
    }
    protected override void OnInitialized()
    {
        Generate();
    }
}
