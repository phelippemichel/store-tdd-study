using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly Product _product;
        private readonly Quantity _quantity;
        private readonly DeliveryFee _deliveryFee;
        private readonly Discount _discount;
    }

    public OrderTests()
    {
        _customer = new Customer("Phelippe Michel");
        _product = new Product("Produto 1", 10, true);
        _quantity = new Quantity(1);
        _deliveryFee = new DeliveryFee(10);
        _discount = new Discount(10, DateTime.Now.AddDays(5));
    }

    [TestMethod] 
    [TestCategory("Domain")]
    public void Should_Return_Sucess_Had_Active_Order()
    {
        var order = new Order(_customer, _deliveryFee, _discount);
        Assert.AreEqual(8, order.Number.Length);
    }
}