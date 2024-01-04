using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;

namespace Store.Tests.Queries
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void Given_an_invalid_command_the_order_should_not_be_generated()
        {
            // Arrange
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "12345678";
            command.PromoCode = "";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            // Act
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }
    }
}