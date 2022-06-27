using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
    public class StandartWay: IWayToBuy
    {
        public string Type => "Standart";

        public double AlgorithmOfCost(double pricePerDay)
        {
            return pricePerDay * 1;
        }
    }
}
