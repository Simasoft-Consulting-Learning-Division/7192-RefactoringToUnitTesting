using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoDeveGerarUmNumeroComOitoCaracteres()
        {
            Customer customer = new Customer("Luis Gabriel N. Simas", "gabrielsimas@gmail.com");
            Discount discount = new Discount(5m,DateTime.Now.AddDays(5));
            Order order = new Order(customer,0.05m,discount);

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