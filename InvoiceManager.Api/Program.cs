using InvoiceManager.Api.Api.Decorator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices(builder.Configuration);
var app = builder.Build();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.Run();
