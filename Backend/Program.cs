using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Hubs;
using Backend.Classes;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddDbContext<ShoppingListContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ShoppingListContext")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddSingleton<OnlineUsersManager>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var logger = services.GetRequiredService<ILogger<Program>>();
  try
  {
    var context = services.GetRequiredService<ShoppingListContext>();
    logger.LogInformation("--- DATABASE CONNECTED ---");

    if (context.Database.GetPendingMigrations().Any())
    {
      context.Database.Migrate();
      logger.LogInformation("--- PENDING MIGRATIONS APPLIED ---");
    }
  }
  catch (Exception ex)
  {
    logger.LogError(ex, "An error occurred creating the DB.");
  }
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHub<OnlineUsersHub>("/onlineusers");

app.Run();





