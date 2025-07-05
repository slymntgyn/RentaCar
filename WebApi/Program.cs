using WebApi.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Database tanýmlamalarý
builder.Services.ConfigureDbContext(builder.Configuration);
//Lower case routing tanýmlamalarý
builder.Services.ConfigureRouting();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureAndCheckMigration();

app.MapControllers();

app.Run();
