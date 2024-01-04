using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{

    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        public CreateOrderItemCommand() { }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateOrderItemCommand>()
                .Requires()
                .IsTrue(Product.ToString().Length == 32, "Product", "Product invalid")
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantity invalid")
            );
        }
    }
}