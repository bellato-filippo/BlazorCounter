using Microsoft.EntityFrameworkCore;

namespace BlazorCounter.Server.Data;
public class EventManagerDbContext : DbContext
{
    public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options) { }
}
