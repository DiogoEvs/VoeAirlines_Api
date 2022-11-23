using VoeAirlines.Contexts;
using VoeAirlines.Middlewares;
using VoeAirlines.Services;
using VoeAirlines.Validators;

using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VoeAirlinesContext>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<VooService>();
builder.Services.AddTransient<ManutencaoService>();
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();
builder.Services.AddTransient<ExcluirAeronaveValidator>();
builder.Services.AddTransient<AdicionarPilotoValidator>();
builder.Services.AddTransient<AtualizarPilotoValidator>();
builder.Services.AddTransient<ExcluirPilotoValidator>();
builder.Services.AddTransient<AdicionarVooValidator>();
builder.Services.AddTransient<AtualizarVooValidator>();
builder.Services.AddTransient<ExcluirVooValidator>();
builder.Services.AddTransient<CancelarVooValidator>();
builder.Services.AddTransient<AdicionarManutencaoValidator>();
builder.Services.AddTransient<AtualizarManutencaoValidator>();
builder.Services.AddTransient<ExcluirManutencaoValidator>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

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

app.UseMiddleware<ValidationExceptionHandlerMiddleware>();

app.Run();
