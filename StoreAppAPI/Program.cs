using StoreAppBL;
using StoreAppDL;
using StoreAppModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<iRepository<Customer>, SQLCustomerRepository>(Repo => new SQLCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iCustomerBL, CustomerBL>();
builder.Services.AddScoped<iRepository<Order>, SQLOrderRepositoryRepo>(Repo => new SQLOrderRepositoryRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iOrderBL, OrderBL>();
builder.Services.AddScoped<iRepository<StoreFront>, SQLStoreFrontRepository>(Repo => new SQLStoreFrontRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iStoreFrontBL, StoreFrontBL>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
