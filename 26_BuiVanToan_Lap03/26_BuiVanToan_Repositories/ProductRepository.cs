using _26_BuiVanToan_BusinessObjects;
using _26_BuiVanToan_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_BuiVanToan_Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product p) =>ProductDAO.DeleteProduct(p);
     

        public List<Category> GetCategories() => CategoryDAO.GetCategories();


        public Product GetProductById(int id) => ProductDAO.FindProductById(id);
    

        public List<Product> GetProducts()=>ProductDAO.GetProducts();
   
        public void SaveProduct(Product p)=>ProductDAO.SaveProduct(p);
     

        public void UpdateProduct(Product p)=>ProductDAO.UpdateProduct(p);
     
    }
}
