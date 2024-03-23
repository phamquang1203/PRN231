using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;
using _26_BuiVanToan_Repository;
using _26_BuiVanToan_Repository.impl;
using _26_BuiVanToan_Repositorys.impl;
using eStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();
        private IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        private IProductRepository productRepository = new ProductRepository();
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => Ok(repository.GetOrders());
        //[Authorize(Roles = UserRoles.Customer)]
        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<Order>> GetAllOrdersByMemberId(string id)
        {
            var listOrder = repository.GetAllOrdersByMemberId(id);
            foreach (var o in listOrder)
            {
                var orderDetails = orderDetailRepository.GetOrderDetailsByOrderId(o.OrderID);
                o.OrderDetails = orderDetails;
            }
            return Ok(listOrder);
        }
        //[Authorize(Roles = UserRoles.Customer)]
        [HttpGet("member/detail/{id}")]
        public ActionResult<Order> GetOrderDetailById(int id)
        {
            var order = repository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDetails = orderDetailRepository.GetOrderDetailsByOrderId(id);
            order.OrderDetails = orderDetails;
            return Ok(order);
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = repository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDetails = orderDetailRepository.GetOrderDetailsByOrderId(id);
            order.OrderDetails = orderDetails;
            return Ok(order);
        }

        //[Authorize(Roles = "Admin, Customer")]
        [HttpPost]
        public ActionResult<Order> PostOrder(PostOrder orderReq)
        {
            var order = new Order
            {
                OrderDate = orderReq.OrderDate,
                ShippedDate = DateTime.Now,
                Freight = orderReq.Freight,
                MemberID = orderReq.MemberID,
                Total = orderReq.Total,
            };
            var savedOrder = repository.SaveOrder(order);
            foreach (var od in orderReq.OrderDetails)
            {
                var fb = productRepository.GetProductById(od.ProductID);
                fb.UnitsInStock -= od.Quantity;
                var orderDetail = new OrderDetail
                {
                    ProductID = od.ProductID,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    OrderID = savedOrder.OrderID,
                    Discount = 0
                };
                productRepository.UpdateProduct(fb);
                orderDetailRepository.SaveOrderDetail(orderDetail);
            }
            return Ok(savedOrder);
        }
            [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var o = repository.GetOrderById(id);
            if (o == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(o);
            return NoContent();
        }
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            var oTmp = repository.GetOrderById(id);
            if (oTmp == null)
            {
                return NotFound();
            }

            oTmp.OrderDate = order.OrderDate;
            oTmp.ShippedDate = order.ShippedDate;
            oTmp.Freight = order.Freight;
            oTmp.MemberID = order.MemberID;

            repository.UpdateOrder(oTmp);
            return NoContent();
        }

    }
}
