using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Service.Services;
using LojaRoupasApi.Service.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ConnectionContext>();

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
builder.Services.AddTransient<ICompraRepository, CompraRepository>();
builder.Services.AddTransient<IItemCarrinhoRepository, ItemCarrinhoRepository>();
builder.Services.AddTransient<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();

builder.Services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ICarrinhoService, CarrinhoService>();
builder.Services.AddTransient<ICompraService, CompraService>();
builder.Services.AddTransient<IItemCarrinhoService, ItemCarrinhoService>();
builder.Services.AddTransient<IProdutoEstoqueService, ProdutoEstoqueService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.MapControllers();

app.Run();
