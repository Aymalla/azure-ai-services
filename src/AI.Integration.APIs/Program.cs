using AI.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.TraversePath().Load();

var settings = new AI.Integration.Settings(
   DotNetEnv.Env.GetString("AZURE_AI_SERVICE_ENDPOINT"),
   DotNetEnv.Env.GetString("AZURE_AI_SERVICE_KEY"),
   DotNetEnv.Env.GetString("AZURE_AI_SERVICE_REGION"),
   DotNetEnv.Env.GetString("AZURE_LANG_SERVICE_ENDPOINT"),
   DotNetEnv.Env.GetString("AZURE_LANG_SERVICE_KEY"),
   DotNetEnv.Env.GetString("AZURE_LANG_SERVICE_REGION")
);


builder.Services.AddSingleton(settings); ;
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddSingleton<TranslationService>();
builder.Services.AddSingleton<SpeechService>();
builder.Services.AddSingleton<ComputerVisionService>();

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
