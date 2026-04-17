using InvoiceManager.Api.Decorator.ServicesCollection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices(builder.Configuration);
var app = builder.Build();
app.UseHttpsRedirection();
app.Run();
