using MongoDB.Driver;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddTypes();

builder.Services.AddGraphQLServer();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var conString = Environment.GetEnvironmentVariable("ConnectionString");
    return new MongoClient(conString);
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var MongoClient = sp.GetRequiredService<IMongoClient>();
    var dbName = Environment.GetEnvironmentVariable("Database_name");
    return MongoClient.GetDatabase(dbName);
});

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
