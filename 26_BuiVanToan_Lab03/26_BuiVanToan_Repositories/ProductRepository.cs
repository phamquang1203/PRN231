
using _26_BuiVanToan_BusinessObjects;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repositories
{

    public class ProductRepository : IProductRepository
    {

        public void DeleteProduct(Product p) => ProductDAO.DeleteProduct(p); 
        public void SaveProduct(Product p) => ProductDAO.SaveProduct(p); 
        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p); 
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
        public List<Product> GetProducts() => ProductDAO.GetProducts(); 
        public Product GetProductById(int id) => ProductDAO.FindProductById(id);
        public Category GetCategoryById(int id) => CategoryDAO.GetCategoryById(id);
    }
}
