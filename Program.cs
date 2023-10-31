using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Play.Catalog.Data.Contexts;
using Play.Catalog.Data.Interfaces;
using Play.Catalog.Repositories;
using Play.Catalog.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the ItemContext and ItemRepository services with the container
builder.Services.AddScoped<IItemContext, ItemContext>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

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