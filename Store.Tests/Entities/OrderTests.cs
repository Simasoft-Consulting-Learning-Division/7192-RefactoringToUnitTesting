using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

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
            Assert.AreEqual(order.Number.Length, 8);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoSeuStatusDeveSerAguardandoPagamento()
        {
            Order order = new Order(_customer, 0, _discount);          
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPagamentoDoPedidoSeuStatusDeveSerAguardandoEntrega()
        {
            Order order = new Order(_customer, 0, _discount);
            order.AddItem(_product,10);
            order.Pay(90); //Tem o desconto de 10% nesse caso!
            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoCanceladoSeuStatusDeveSerCancelado()
        {
            Order order = new Order(_customer, 0, _discount);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemSemProdutoOMesmoNaoDeveSerAdicionado()
        {
            Order order = new Order(_customer, 0, _discount);
            order.AddItem(null,1);            
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemComQuantidadeZeroOuMenorOMesmoNaoDeveSerAdicionado()
        {
            Order order = new Order(_customer, 0, _discount);
            order.AddItem(_product,-100);            
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoSeuTotalDeveSerCinquenta()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product,5);            
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoExpiradoOValorDoPedidoDeveSerSessenta()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            Order order = new Order(_customer, 10, expiredDiscount);
            order.AddItem(_product,5);                        
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoInvalidoOValorDoPedidoDeveSerSessenta()
        {            
            Order order = new Order(_customer, 10, null);
            order.AddItem(_product,5);                        
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmDescontoDeDezPorcentoOValorDoPedidoDeveSerCinquenta()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product,5);            
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmaTaxaDeEntregaDeDezOValorDoPedidoDeveSerSessenta()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product,6);            
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoSemClienteOmesmodeveSerInvalido()
        {
            Order order = new Order(null, 10, _discount);
            Assert.AreEqual(order.Valid, false);
        }
    }
}