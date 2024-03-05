using _26_BuiVanToan_BusinessObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _26_BuiVanToan_Repositories
{
    public interface IProductRepository
    {

            void SaveProduct(Product p);

            Product GetProductById(int id);

            void DeleteProduct(Product p);

            void UpdateProduct(Product p);

            List<Category> GetCategories(); 
            List<Product> GetProducts();
    }
}