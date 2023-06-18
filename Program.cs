using Microsoft.EntityFrameworkCore;
using SHORTURL.Application.Services;
using SHORTURL.Domain.Interfaces;
using SHORTURL.Infrastructure;
using SHORTURL.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<UrlDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<UrlService>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
//app.UseAuthorization();
app.MapControllers();
app.Run();