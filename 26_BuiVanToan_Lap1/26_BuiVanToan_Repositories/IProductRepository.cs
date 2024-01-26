using _26_BuiVanToan_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_BuiVanToan_Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product p);
        List<Product> GetProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
        List<Category> GetCategories();
        Category? GetCategoryById(int id);


    }
}
