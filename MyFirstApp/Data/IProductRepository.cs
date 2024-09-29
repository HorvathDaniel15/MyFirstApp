using MyFirstApp.Models;

namespace MyFirstApp.Data
{
    public interface IProductRepository
    {
        void Create(Product item);
        void Delete(int id);
        Product? Read(int id);
        IEnumerable<Product> ReadAll();
        void Update(Product item);
    }
}