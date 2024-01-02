using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces
{
    public interface ICustumerRepository
    {
        Customer Get(string document);
    }
}