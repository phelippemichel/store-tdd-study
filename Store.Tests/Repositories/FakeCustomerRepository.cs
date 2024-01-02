using Store.Domon.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustumerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678901")
                return new Customer("Phelippe Michel", "phe@dev.com");

            return null;
        }
    }
}