using WebStoreViewApp.Domain;
using WebStoreViewApp.Services;

var pedidoServices = new OrderService();

var produtos = new List<Product>()
{
    new Product() { Id = 1, Nome = "Guitarra Ibanez", Valor = 1000 },
    new Product() { Id = 2, Nome = "Guitarra Fender", Valor = 2000 },
    new Product() { Id = 3, Nome = "Guitarra Gibson", Valor = 3000 },
    new Product() { Id = 4, Nome = "Guitarra Condor", Valor = 500 },
};

var pedido = pedidoServices.CreateOrder(produtos, 100);

Console.WriteLine($"Id do pedido: {pedido.Id}");
Console.WriteLine($"Desconto: {pedido.Discount}");
Console.WriteLine($"Valor total: {pedido.ValorTotal}");
Console.WriteLine($"Qtd itens: {pedido.QtdItens}");
Console.WriteLine("===================================");

foreach (var produto in pedido.Product)
{
    Console.WriteLine($"Id do produto: {produto.Id}");
    Console.WriteLine($"Nome do produto: {produto.Nome}");
    Console.WriteLine($"Valor do produto: {produto.Valor}");
}

Console.ReadKey();