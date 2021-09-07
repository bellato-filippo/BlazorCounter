
using BlazorCounter.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCounter.Server.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Prodotto {  get; set; }
}
