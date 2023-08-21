using System.Runtime.ExceptionServices;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var produtos = new List<Produtos.API.Models.Produtos>
{
    new Produtos.API.Models.Produtos { Id = 1, Nome = "Calça", Preco = 274.90m, Quantidade = 40 },
    new Produtos.API.Models.Produtos { Id = 2, Nome = "Casaco de Moletom", Preco = 140.00m, Quantidade = 25 },
    new Produtos.API.Models.Produtos { Id = 3, Nome = "Camiseta", Preco = 80.50m, Quantidade = 13 },
    new Produtos.API.Models.Produtos { Id = 4, Nome = "Top", Preco = 76.95m, Quantidade = 7 }
};

builder.Services.AddSingleton(produtos);
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Produtos.API", Version = "v1"});
});

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.MapGet("/produtos", () => 
{
    var produtoService = app.Services.GetRequiredService<List<Produtos.API.Models.Produtos>>();
    return Results.Ok(produtoService);
});

app.MapGet("/produtos/{id}", (int id, HttpRequest request) =>
{
    var produtoService = app.Services.GetRequiredService<List<Produtos.API.Models.Produtos>>();
    var produto = produtoService.FirstOrDefault(p => p.Id == id);

    if(produto == null)
    {
        return Results.NotFound();
    }
        return Results.Ok(produto);
});

app.MapPost("/produtos", (Produtos.API.Models.Produtos produto) =>
{
    var produtoService = app.Services.GetRequiredService<List<Produtos.API.Models.Produtos>>();
    produto.Id = produtoService.Max(p => p.Id) + 1;
    produtoService.Add(produto);
    return Results.Created($"/produtos/{produto.Id}", produto);
});

app.MapPut("/produtos/{id}", (int id, Produtos.API.Models.Produtos produto) =>
{
    var produtoService = app.Services.GetRequiredService<List<Produtos.API.Models.Produtos>>();
    var existeProduto = produtoService.FirstOrDefault(p => p.Id == id);

    if(existeProduto == null)
    {
        return Results.NotFound();
    }
        existeProduto.Nome = produto.Nome;
        existeProduto.Preco = produto.Preco;
        existeProduto.Quantidade = produto.Quantidade;

        return Results.NoContent();
});

app.MapDelete("/produtos/{id}", (int id) =>
{
    var produtoService = app.Services.GetRequiredService<List<Produtos.API.Models.Produtos>>();
    var existeProduto = produtoService.FirstOrDefault(p => p.Id == id);

    if(existeProduto == null)
    {
        return Results.NotFound();
    }

    produtoService.Remove(existeProduto);

    return Results.NoContent();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
