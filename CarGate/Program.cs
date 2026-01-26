using CarGate.Configuration;
using CarGate.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CepikEndpoints>(
    builder.Configuration.GetSection("Cepik:Endpoints"));

builder.Services.AddHttpClient("CepikClient", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(config["Cepik:BaseUrl"]);
});

builder.Services.AddScoped<CepikSystemService>();
builder.Services.AddScoped<VoivodeshipDictionaryService>();
builder.Services.AddScoped<FilteringService>();
builder.Services.AddScoped<FilesService>();
builder.Services.AddScoped<VehicleDetailsService>();

var app = builder.Build();





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
