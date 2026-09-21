using CraftIQ.Inventory.Infrastructre;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var InventoryConnectionString = builder.Configuration.GetSection("ConnectionStrings:InventoryDatabase");
builder.Services.AddInventoryDbContext(InventoryConnectionString.Value!);
builder.Services.AddInventoryRepository();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapSwaggerUI();
app.MapSwagger();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
