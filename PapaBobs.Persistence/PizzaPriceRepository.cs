using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaCostDTO GetPizzaPrices()
        {
            var db = new OrdersDbEntities();
            var prices = db.PizzaCostTables.First();
            var dto = convertToDTO(prices);
            return dto;
        }
        private static DTO.PizzaCostDTO convertToDTO(PizzaCostTable pizzaCost)
        {
            var dto = new DTO.PizzaCostDTO();

            dto.SmallSizeCost = pizzaCost.SmallSizeCost;
            dto.MediumSizeCost = pizzaCost.MediumSizeCost;
            dto.LargeSizeCost = pizzaCost.LargeSizeCost;
            dto.RegularCrustCost = pizzaCost.RegularCrustCost;
            dto.ThinCrustCost = pizzaCost.ThinCrustCost;
            dto.ThickCrustCost = pizzaCost.ThickCrustCost;
            dto.SausageCost = pizzaCost.SausageCost;
            dto.PepperoniCost = pizzaCost.PepperoniCost;
            dto.OnionsCost = pizzaCost.OnionsCost;
            dto.GreenPeppersCost = pizzaCost.GreenPeppersCost;
            return dto;
        }
            
    }

}
