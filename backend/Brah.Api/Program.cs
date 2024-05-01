using Brah.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextConfigured()
    .AddRepositories()
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: add swagger
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();