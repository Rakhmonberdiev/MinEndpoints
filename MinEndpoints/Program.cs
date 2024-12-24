using MinEndpoints.Extensions;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());


builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();
app.MapEndpoints();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ApplyMigrations();

app.Run();


