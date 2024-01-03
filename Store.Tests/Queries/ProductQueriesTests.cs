using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Product 01", 10, true));
            _products.Add(new Product("Product 02", 20, true));
            _products.Add(new Product("Product 03", 30, true));
            _products.Add(new Product("Product 04", 40, false));
            _products.Add(new Product("Product 05", 50, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Given_the_query_of_inactive_products_must_return_3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Given_the_query_of_inactive_products_must_return_2()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }
}