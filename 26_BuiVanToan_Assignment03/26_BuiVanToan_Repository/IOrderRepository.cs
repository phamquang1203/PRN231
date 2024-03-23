using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface IOrderRepository
    {
        Order SaveOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetOrders();
        List<Order> GetAllOrdersByMemberId(string id);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        List<OrderDetail> GetOrderDetails(int orderId);
    }
}
