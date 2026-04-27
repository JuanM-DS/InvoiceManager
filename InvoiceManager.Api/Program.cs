using InvoiceManager.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddWebApplicationBuilderExt();
builder.Services.AddApiServices(builder.Configuration);
var app = builder.Build();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.Run();
