﻿using Deme.Unitities.Constast;
using Demo.Application.Catalog.Commonn;
using Demo.Application.Catalog;
using Demo.Application.Catalog.Producttt;
using Demo.DataBase.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Ket Nối Database
builder.Services.AddDbContext<DemoDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstanst.MainConnectionString));

});

//Declare DI
builder.Services.AddTransient<IStorageService,FileStorageService>();

builder.Services.AddTransient<IPublicProductService, PublicProductService>();

builder.Services.AddTransient<IManageProductService, ManageProductService>();





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
