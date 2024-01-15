using System.Security.Cryptography;
using AI.Integration;
using Azure.AI.Translation.Text;
using Azure.AI.Translation.Text.Custom;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAzureClients(clientBuilder =>
{
    DotNetEnv.Env.TraversePath().Load();
    var AZURE_AI_SERVICE_ENDPOINT = DotNetEnv.Env.GetString("AZURE_AI_SERVICE_ENDPOINT");
    var AZURE_AI_SERVICE_KEY = DotNetEnv.Env.GetString("AZURE_AI_SERVICE_KEY");

    _ = clientBuilder.AddTextAnalyticsClient(
        new Uri(AZURE_AI_SERVICE_ENDPOINT),
        new Azure.AzureKeyCredential(AZURE_AI_SERVICE_KEY)
        );

    clientBuilder.AddTextTranslationClient(
        new Azure.AzureKeyCredential(AZURE_AI_SERVICE_KEY),
         new Uri(AZURE_AI_SERVICE_ENDPOINT)
        );

});

builder.Services.AddSingleton<ILanguageService, LanguageService>();
builder.Services.AddSingleton<ITranslationService, TranslationService>();

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
