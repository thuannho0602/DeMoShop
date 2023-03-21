using Deme.Unitities.Constast;
using Demo.Application.Catalog.Productt;
using Demo.Application.Common;
using Demo.DataBase.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Ket Nối Database
builder.Services.AddDbContext<DemoDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstanst.MainConnectionString));

});



builder.Services.AddTransient<IManageProductService,ManageProductService>();
builder.Services.AddTransient<IPublicProductService1, PublicProductSerivce>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
