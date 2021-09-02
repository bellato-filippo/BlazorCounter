using Microsoft.EntityFrameworkCore;

namespace BlazorCounter.Server.Data;
public class EventManagerDbContext : DbContext
{
    public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options) { }

    public DbSet<Models.DatiEvento> Eventi  {  get; set; }
    public DbSet<Models.ContatoreSer> Contatore {  get; set; }
    public DbSet<Models.NomeSer> Nome {  get; set; }
}
