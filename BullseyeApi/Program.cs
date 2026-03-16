using BullseyeApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StockService>();
builder.Services.AddSingleton<PortfolioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

var stockService = app.Services.GetRequiredService<StockService>();
var portfolioService = app.Services.GetRequiredService<PortfolioService>();

var timer = new System.Threading.Timer(_ =>
{
    stockService.UpdatePrices();
    portfolioService.RecordValue(stockService.GetAllStocks());
}, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

app.Run();