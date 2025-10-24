using BsLayer.maaper;
using BsLayer.Services;
using BussinesLayer.Services.Jwt;
using DataLayer.Data;
using DTLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RepLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDatabase(builder.Configuration);
//builder.Services.AddAutoMapper(typeof(PeopleProfile).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.addBussinesServices();
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddRepoServices();

var app = builder.Build();




//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await services.SeedRolesAsync();
//}
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.InitializeAsync();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await services.SeedRolesAsync(); // فقط إنشاء Roles
//}