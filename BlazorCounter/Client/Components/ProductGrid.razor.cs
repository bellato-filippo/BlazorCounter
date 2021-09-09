
using BlazorCounter.Client.Models;

namespace BlazorCounter.Client.Components;
public partial class ProductGrid
{
    public List<string> Title { get; set; } = new List<string> { "Id", "Nome", "Descrizione", "Prezzo", "Data", "Disponibile"};

    public List<ProdottoCli> ListaProd {  get; set; }
}
