using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            var db = new OrdersDbEntities();
            var order = convertToEntity(orderDTO);
            db.Orders.Add(order);
            db.SaveChanges();
        }
        private static Order convertToEntity(DTO.OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onion = orderDTO.Onion;
            order.GreenPepper = orderDTO.GreenPepper;
            order.TotalCost = orderDTO.TotalCost;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.Zipcode = orderDTO.Zipcode;
            order.Phone = orderDTO.Phone;
            order.PaymentType = orderDTO.PaymentType;

            return order;
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new OrdersDbEntities();
            var orders = db.Orders.Where(p=> p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }
        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO();
                orderDTO.OrderId = order.OrderId;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.Zipcode = order.Zipcode;
                orderDTO.Phone = order.Phone;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onion = order.Onion;
                orderDTO.GreenPepper = order.GreenPepper;
                orderDTO.TotalCost = order.TotalCost;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.Completed = order.Completed;
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;        
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new OrdersDbEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId==orderId);
            order.Completed = true;
            db.SaveChanges();
        }
    }
}
