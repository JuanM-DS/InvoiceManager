using InvoiceManager.Api.Decorator;
using InvoiceManager.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddWebApplicationBuilderExt();
builder.Services.AddProblemDetails();
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();
app.RegisterApp();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.Run();
