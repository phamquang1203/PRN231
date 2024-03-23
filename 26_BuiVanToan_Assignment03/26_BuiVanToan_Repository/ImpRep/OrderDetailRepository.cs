using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;
using _26_BuiVanToan_Repository;

namespace _26_BuiVanToan_Repositorys.impl
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void SaveOrderDetail(OrderDetail orderDetail) => OrdersDetailDAO.SaveOrderDetail(orderDetail);
        public OrderDetail GetOrderDetailByOrderIdAndProductId(int orderId, int flowerBouquetId) => OrdersDetailDAO.FindOrderDetailByOrderIdAndProductID(orderId, flowerBouquetId);
        public List<OrderDetail> GetOrderDetails() => OrdersDetailDAO.GetOrderDetails();
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrdersDetailDAO.FindAllOrderDetailsByOrderId(orderId);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrdersDetailDAO.UpdateOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrdersDetailDAO.DeleteOrderDetail(orderDetail);
    }
}
