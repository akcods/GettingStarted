using GettingStarted.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddTypes();

builder.Services.AddGraphQLServer();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var conString = Environment.GetEnvironmentVariable("ConnectionString");
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(conString);
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var MongoClient = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var dbName = Environment.GetEnvironmentVariable("Database_name");
    return MongoClient.GetDatabase(dbName);
});

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
