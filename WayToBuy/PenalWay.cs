using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
    public class PenalwAY: IWayToBuy
    {
        public string Type => "Penal";
        public double AlgorithmOfCost(double price)
        {
            return price * 1 + price * 0.2;
        }
    }
}
