using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();            
            _products.Add(new Product("Produto 01", 10, true));
            _products.Add(new Product("Produto 02", 10, true));
            _products.Add(new Product("Produto 03", 10, true));
            _products.Add(new Product("Produto 04", 10, false));
            _products.Add(new Product("Produto 05", 10, false));
        }
        
        [TestMethod]
        [TestCategory("Queries")]
        public void DadoAConsultaDeProdutosAtivosDeveRetornarTres()
        {
            var result = _products.AsQueryable().Where(p => p.Active).Count();                        
            Assert.AreEqual(result,3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void DadoAConsultaDeProdutosInativosDeveRetornarDois()
        {            
            var result = _products.AsQueryable().Where(p => !p.Active).Count();                        
            Assert.AreEqual(result,2);
        }
    }
}