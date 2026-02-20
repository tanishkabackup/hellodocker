using hello_docker;
using hello_docker.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapControllers();
app.Run();
