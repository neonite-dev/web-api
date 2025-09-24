using Microsoft.EntityFrameworkCore;
using workspace.Models;

var builder = WebApplication.CreateBuilder(args);

// 각 컨트롤러에서 EnableCors 속성을 추가할 것
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueAppPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173");
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CCDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
