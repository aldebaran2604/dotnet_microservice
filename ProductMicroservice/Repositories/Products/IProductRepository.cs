using ProductMicroservice.Models;

namespace ProductMicroservice.Repositories.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();

    Task<Product?> GetProductByID(int id);

    Task<int> InsertProduct(Product product);

    Task<int> DeleteProduct(int id);

    Task<int> UpdateProduct(Product product);

    Task<int> Save();
}
