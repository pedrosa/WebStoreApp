using AutoFixture;
using FluentAssertions;
using Moq;
using WebStoreViewApp.Domain;
using WebStoreViewApp.Services;
using WebStoreViewApp.Services.Interfaces;

namespace WebStoreViewApp.Tests
{
    public class PedidoServicesTests
    {
        private readonly Mock<List<Product>> _productMock = new();
        private readonly Mock<IOrderService> _productServiceMock = new();
        private readonly Fixture _fixture = new();
        
        [Fact]
        public void CriacaoPedidoSucesso()
        {
            // Arrange
            _productServiceMock.Setup(service => service.CreateOrder(_productMock.Object, 5))
                .Returns(It.IsAny<Order>());
        }

        // [Fact]
        // public void CriacaoPedidoSucessoSemDesconto()
        // {
        //     var pedidoServices = new OrderService();
        //
        //     var produtos = CreateProducts();
        //
        //     var pedido = pedidoServices.CreateOrder(produtos, 0);
        //
        //     Assert.Equal(4, pedido.QtdItens);
        //     Assert.Equal(6500, pedido.ValorTotal);
        // }

        [Fact]
        public void CriacaoPedidoSucessoSemDesconto3Itens()
        {
            var pedidoServices = new OrderService();
            var product = _fixture.CreateMany<Product>();

            var pedido = pedidoServices.CreateOrder(product.ToList(), 0);

            Assert.Equal(3, pedido.QtdItens);
            Assert.Equal(3500, pedido.ValorTotal);
        }

        [Fact]
        public void CriacaoPedidoSucessoComDescontoMetadeValor2Itens()
        {
            var pedidoServices = new OrderService();

            var produtos = new List<Product>()
            {
                new Product() { Id = 1, Nome = "Guitarra Ibanez", Valor = 1000 },
                new Product() { Id = 2, Nome = "Guitarra Fender", Valor = 2000 }
            };

            var pedido = pedidoServices.CreateOrder(produtos, 1500);

            Assert.Equal(2, pedido.QtdItens);
            Assert.Equal(2850, pedido.ValorTotal);
        }

        [Fact]
        public void CriacaoPedidoDescontoNegativoFalha()
        {
            var pedidoServices = new OrderService();

            var produtos = new List<Product>()
            {
                new Product() { Id = 1, Nome = "Guitarra Ibanez", Valor = 1000 },
                new Product() { Id = 2, Nome = "Guitarra Fender", Valor = 2000 },
                new Product() { Id = 4, Nome = "Guitarra Condor", Valor = 500 },
            };
            
            Assert.Throws<ArgumentException>(
                () => pedidoServices.CreateOrder(produtos, -100));
        }
    }
}