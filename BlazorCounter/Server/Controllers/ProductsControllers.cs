using BlazorCounter.Server.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BlazorCounter.Server.Controllers;
public class ProductsControllers : ODataController
{
    private List<Product> products = new List<Product>()
    {
        new Product()
        {
            Id = 1,
            Name = "Bread",
        }
    };

    [EnableQuery]
    public List<Product> Get()
    {
        return products;
    }
}
