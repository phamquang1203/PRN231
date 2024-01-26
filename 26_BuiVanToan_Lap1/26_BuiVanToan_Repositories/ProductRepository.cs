using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product p)
        {
            ProductDAO.DeleteProduct(p);
        }

        public Product GetProductById(int id)
        {
            return ProductDAO.FindProductById(id);
        }

        public List<Product> GetProducts()
        {
            return ProductDAO.GetProducts();
        }
        public List<Category> GetCategories()
        {
            return CategoryDAO.GetCategories();
        }
        
        public void SaveProduct(Product p)
        {
            ProductDAO.SaveProduct(p);
        }

        public void UpdateProduct(Product p)
        {
            ProductDAO.UpdateProduct(p);
        }
        public Category? GetCategoryById(int id)
        {
            return CategoryDAO.GetCategoryById(id);
        }
    }
}
