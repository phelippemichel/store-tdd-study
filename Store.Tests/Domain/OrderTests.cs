using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Phelippe Michel", "phe@mail.com");
        private readonly Product _product = new Product("Produto 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")]
        public void Should_Return_Sucess_Had_Order_With_8_Characters()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Should_Return_Sucess_When_Status_Waiting_Payment()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Should_Return_Sucess_When_Status_Waiting_Delivery()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 1);
            order.Pay(10);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Should_Return_Sucess_When_Status_Canceled()
        {
            var order = new Order(_customer, 0, null);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        // [TestMethod]
        // [TestCategory("Domain")]
        // public void Should_Return_Sucess_When_Add_Item_Nothing_Product()
        // {
        //     var order = new Order(_customer, 0, null);
        //     order.AddItem(null, 10);
        //     Assert.AreEqual(Order.Items.Count, 0);
        // }
    }
}