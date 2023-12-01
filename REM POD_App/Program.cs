using Microsoft.EntityFrameworkCore;
using REM_POD_App.DBcontext;
using REM_POD_App.files;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<REMcontext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString(Secret.GetConnectionString)));
builder.Services.AddScoped<IModelRepository, ModelRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
