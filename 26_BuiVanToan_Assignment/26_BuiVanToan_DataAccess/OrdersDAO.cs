﻿using _26_BuiVanToan_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_BuiVanToan_DataAccess
{
    public class OrdersDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrders = context.Orders.ToList();
                    listOrders.ForEach(o => o.Member = context.Members.Find(o.MemberId));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

        public static List<Order> FindAllOrdersByMemberId(int memberId)
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrders = context.Orders.Where(o => o.MemberId == memberId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

        public static Order FindOrderById(int orderId)
        {
            var order = new Order();
            try
            {
                using (var context = new MyDbContext())
                {
                    order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
                    if (order != null)
                        order.Member = context.Members.Find(order.MemberId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static Order SaveOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(order).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var orderToDelete = context
                        .Orders
                        .SingleOrDefault(o => o.OrderId == order.OrderId);
                    context.Orders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
