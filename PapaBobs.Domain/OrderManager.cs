using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            if (orderDTO.Name.Trim().Length == 0)
                throw new Exception("Please Enter A Name.");
            if (orderDTO.Address.Trim().Length == 0)
                throw new Exception("Please enter an Address.");
            if (orderDTO.Zipcode.Trim().Length == 0)
                throw new Exception("Please Enter A Zipcode.");
            if (orderDTO.Phone.Trim().Length == 0)
                throw new Exception("Please Enter A Contact Phone Number.");
            orderDTO.OrderId = Guid.NewGuid();
            orderDTO.TotalCost = PizzaPriceManager.CalculatePizzaPrice(orderDTO);
            Persistence.OrderRepository.CreateOrder(orderDTO);
        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
            
        }

        public static object GetOrders()
        {
            return Persistence.OrderRepository.GetOrders();
            ;
        }
    }
}
