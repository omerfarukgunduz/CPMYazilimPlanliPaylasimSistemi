using ControlPortal.Persistence;
using Microsoft.EntityFrameworkCore;
using Portal.Persistence.Context;
using System;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddPersistenceServices();

builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
