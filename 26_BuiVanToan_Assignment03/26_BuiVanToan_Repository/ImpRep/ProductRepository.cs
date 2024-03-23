using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repository.impl
{
    public class ProductRepository : IProductRepository
    {
        void IProductRepository.DeleteProduct(Product Product) => ProductDAO.DeleteProduct(Product);


        List<OrderDetail> IProductRepository.GetOrderDetails(int ProductId) => OrdersDetailDAO.FindAllOrderDetailsByProductID(ProductId);
    

        Product IProductRepository.GetProductById(int id) =>ProductDAO .FindProductById(id);
   

        List<Product> IProductRepository.GetProducts() => ProductDAO.GetProducts();
   

        void IProductRepository.SaveProduct(Product Product)=> ProductDAO.SaveProduct(Product);
   

        List<Product> IProductRepository.Search(string keyword) =>ProductDAO .Search(keyword);
    

        void IProductRepository.UpdateProduct(Product Product) =>ProductDAO.UpdateProduct(Product);
  
    }
}
