using Persistence;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureCustomExceptionMiddleware();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
