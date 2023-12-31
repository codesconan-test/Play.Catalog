using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Play.Catalog.Data.Contexts;
using Play.Catalog.Entities;
using Play.Common.Data;
using Play.Common.Repositories;
using Play.Common.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Register Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the ItemContext and ItemRepository services with the container
builder.Services.AddScoped<IItemContext<Item>, ItemContext>();
builder.Services.AddScoped<IItemRepository<Item>, ItemRepository<Item>>();

// Register a custom serializer for Guids as strings
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();