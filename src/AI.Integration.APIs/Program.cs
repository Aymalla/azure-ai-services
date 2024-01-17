using AI.Integration;
using Azure.AI.Translation.Text.Custom;
using Microsoft.Extensions.Azure;
using Microsoft.CognitiveServices.Speech;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.TraversePath().Load();
var AZURE_AI_SERVICE_ENDPOINT = DotNetEnv.Env.GetString("AZURE_AI_SERVICE_ENDPOINT");
var AZURE_AI_SERVICE_KEY = DotNetEnv.Env.GetString("AZURE_AI_SERVICE_KEY");
var AZURE_AI_SERVICE_REGION = DotNetEnv.Env.GetString("AZURE_AI_SERVICE_REGION");


builder.Services.AddAzureClients(clientBuilder =>
{
    _ = clientBuilder.AddTextAnalyticsClient(new Uri(AZURE_AI_SERVICE_ENDPOINT),
            new Azure.AzureKeyCredential(AZURE_AI_SERVICE_KEY)
        );

    clientBuilder.AddTextTranslationClient(new Azure.AzureKeyCredential(AZURE_AI_SERVICE_KEY),
            new Uri(AZURE_AI_SERVICE_ENDPOINT)
        );

});

builder.Services.AddSingleton((sp) =>
{

    // Creates an instance of a speech translation config with specified subscription key and service region.
    // Please replace the service subscription key with your subscription key
    //var v2EndpointInString = String.Format("wss://{0}.stt.speech.microsoft.com/speech/universal/v2", AZURE_AI_SERVICE_REGION);
    //var v2EndpointUrl = new Uri(v2EndpointInString);
    //return SpeechTranslationConfig.FromEndpoint(v2EndpointUrl, AZURE_AI_SERVICE_KEY);

    var config = SpeechTranslationConfig.FromSubscription(AZURE_AI_SERVICE_KEY, AZURE_AI_SERVICE_REGION);
    config.SetProperty("OPENSSL_DISABLE_CRL_CHECK", "true");
    return config;
});

builder.Services.AddSingleton<LanguageService>();
builder.Services.AddSingleton<TranslationService>();
builder.Services.AddSingleton<SpeechService>();

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
