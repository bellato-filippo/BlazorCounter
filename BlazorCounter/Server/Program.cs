using BlazorCounter.Server.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

//builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());

builder.Services.AddDbContext<ApplicationDbContext>(
    opt => opt.UseSqlite("DataSource=productdb.db"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
    //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //app.UseHttpsRedirection();
}



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub(); //
app.MapFallbackToFile("index.html");

app.Run();
