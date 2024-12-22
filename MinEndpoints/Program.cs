using MinEndpoints.Extensions;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
var app = builder.Build();
app.MapEndpoints();
// Configure the HTTP request pipeline.



app.Run();


