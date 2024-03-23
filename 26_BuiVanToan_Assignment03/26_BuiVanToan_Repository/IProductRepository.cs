using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface IProductRepository
    {
        void SaveProduct(Product Product);
        Product GetProductById(int id);
        List<Product> GetProducts();
        List<Product> Search(string keyword);
        void UpdateProduct(Product Product);
        void DeleteProduct(Product Product);
        List<OrderDetail> GetOrderDetails(int ProductId);
    }
}
