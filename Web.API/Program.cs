using Application;
using Infraestructure;
using Web.API;
using Web.API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.AppyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
