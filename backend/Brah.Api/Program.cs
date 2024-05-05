using Brah.Api.Extensions;
using Brah.BL.Extensions;
using Brah.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddJwtConfigured()
    .AddDbContextConfigured()
    .AddRepositories()
    .AddBlServices()
    .AddAutoMapperConfigured()
    .AddControllers();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    opt => opt
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();