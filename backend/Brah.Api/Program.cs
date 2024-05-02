using Brah.BL.Extensions;
using Brah.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextConfigured()
    .AddRepositories()
    .AddBlServices()
    .AddAutoMapperConfigured()
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();