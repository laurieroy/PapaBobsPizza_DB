using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculatePizzaPrice(DTO.OrderDTO order )
        {
            decimal cost = 0.0M;
            var prices = getPizzaPrices();
            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateToppings(order, prices);
            return cost;
        }

        private static decimal calculateToppings(DTO.OrderDTO order, DTO.PizzaCostDTO prices)
        {
            decimal cost = 0.0M;
            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Onion) ? prices.OnionsCost : 0M;
            cost += (order.GreenPepper) ? prices.GreenPeppersCost : 0M;
            return cost;
        }

        private static decimal calculateCrustCost(DTO.OrderDTO order, DTO.PizzaCostDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case DTO.Enums.Crusts.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case DTO.Enums.Crusts.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case DTO.Enums.Crusts.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateSizeCost(DTO.OrderDTO order, DTO.PizzaCostDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Size)
            {
                case DTO.Enums.Sizes.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case DTO.Enums.Sizes.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case DTO.Enums.Sizes.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static DTO.PizzaCostDTO getPizzaPrices()
        {
            var prices = Persistence.PizzaPriceRepository.GetPizzaPrices();
            return prices;
        }
    }
}
