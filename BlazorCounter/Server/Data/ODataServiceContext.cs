using BlazorCounter.Server.Models;
using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BlazorCounter.Server.Data;

public class ODataServiceContext : DataServiceContext 
{
    public ODataServiceContext(Uri serviceRoot) : base(serviceRoot) 
    {
        HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;

        this.Books = base.CreateQuery<Book>("Books");
        this.Format.LoadServiceModel = () => GetEdmModel();
        this.Format.UseJson();
    }

    private IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Book>("Books").EntityType.HasKey(p => p.Id).Count().Select().Page(null, 100).Expand().Filter();
        return builder.GetEdmModel();
    }

    public DataServiceQuery<Book> Books {  get; }
}
