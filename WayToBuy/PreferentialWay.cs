using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
    public class PreferentialWay: IWayToBuy
    {
        public string Type => "Preferential";
        public double AlgorithmOfCost(double price)
        {
            return price * 1 - price * 0.3;
        }
    }
}
