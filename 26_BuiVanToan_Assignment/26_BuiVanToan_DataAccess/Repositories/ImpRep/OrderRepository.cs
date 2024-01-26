﻿using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_DataAccess.Repositoriess.impl
{
    public class OrderRepository : IOrderRepository
    {
        public Order SaveOrder(Order order) => OrdersDAO.SaveOrder(order);
        public Order GetOrderById(int id) => OrdersDAO.FindOrderById(id);
        public List<Order> GetOrders() => OrdersDAO.GetOrders();
        public List<Order> GetAllOrdersByMemberId(int customerId) => OrdersDAO.FindAllOrdersByMemberId(customerId);
        public void UpdateOrder(Order order) => OrdersDAO.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrdersDAO.DeleteOrder(order);
        public List<OrderDetail> GetOrderDetails(int orderId) => OrdersDetailDAO.FindAllOrderDetailsByOrderId(orderId);
    }
}
