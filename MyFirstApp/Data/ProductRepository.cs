using MyFirstApp.Models;

namespace MyFirstApp.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Product> ReadAll()
        {
            return _context.Products.ToList();
        }

        public Product? Read(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var product = Read(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            var old = Read(item.Id);
            old.Name = item.Name;
            old.Description = item.Description;
            old.Price = item.Price;
            _context.SaveChanges();
        }
    }
}
