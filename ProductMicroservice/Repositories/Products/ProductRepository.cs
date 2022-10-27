using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repositories.Products;

public class ProductRepository : IProductRepository
{
    #region Properties

    private readonly ProductContext _productContext;

    #endregion

    #region Constructors

    public ProductRepository(ProductContext productContext)
    {
        _productContext = productContext;
    }

    #endregion

    #region Methods

    public async Task<int> DeleteProduct(int id)
    {
        Product? product = _productContext.Products.Find(id);

        if (product is null) return 0;

        _productContext.Products.Remove(product);
        return await Save();
    }

    public async Task<Product?> GetProductByID(int id)
    {
        Product? product = await _productContext.Products.FindAsync(id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        List<Product> products = await _productContext.Products.ToListAsync();
        return products;
    }

    public async Task<int> InsertProduct(Product product)
    {
        await _productContext.Products.AddAsync(product);
        return await Save();
    }

    public async Task<int> Save()
    {
       int changes = await _productContext.SaveChangesAsync();
        return changes;
    }

    public async Task<int> UpdateProduct(Product product)
    {
        int changes = await Task.Run<int>(() =>
        {
            _productContext.Entry(product).State = EntityState.Modified;
            return Save();
        });
        
        return changes;
    }

    #endregion
}
