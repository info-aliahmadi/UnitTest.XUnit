
using Microsoft.EntityFrameworkCore;
using XUnit.Service.Data;
using XUnit.Service.Data.Infra;
using XUnit.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// the default pool size in 1024 
//Make sure that the maxPoolSize corresponds to your usage scenario;
//if it is too low, DbContext instances will be constantly created and disposed,degrading performance.
//Setting it too high may needlessly consume memory as
//unused DbContext instances are maintained in the pool.
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("XUnit.Api"))); // the default pool size in 1024 

// services
builder.Services.AddScoped<ICommandRepository, CommandRepository>();
builder.Services.AddScoped<IQueryRepository, QueryRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IRoleService, RoleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

public partial class Program { }