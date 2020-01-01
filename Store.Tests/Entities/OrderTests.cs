using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Luis Gabriel N. Simas", "gabrielsimas@gmail.com");
        private readonly Product _product = new Product("Produto 1", 10, true);
        private readonly Discount _discount = new Discount(10,DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoDeveGerarUmNumeroComOitoCaracteres()
        {            
            Order order = new Order(_customer,0,_discount);
            Assert.AreEqual(8, order.Number.Length);
        }

        public void DadoUmNovoPedidoSeuStatusDeveSerAguardandoPagamento()
        {
            Assert.Fail();
        }

        public void DadoUmPagamentoDoPedidoSeuStatusDeveSerAguardandoEntrega()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoCanceladoSeuStatusDeveSerCancelado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemSemProdutoOMesmoNaoDeveSerAdicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemComQuantidadeZeroOuMenorOMesmoNaoDeveSerAdicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoSeuTotalDeveSerCinquenta()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoExpiradoOValorDoPedidoDeveSerSessenta()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoInvalidoOValorDoPedidoDeveSerSessenta()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoDeDezPorcentoOValorDoPedidoDeveSerCinquenta()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmaTaxaDeEntregaDeDezOValorDoPedidoDeveSerSessenta()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoSemClienteOmesmodeveSerInvalido()
        {
            Assert.Fail();
        }
    }
}