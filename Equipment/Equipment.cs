using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
    public abstract class Equipment
    {
        public Equipment(string name, IWayToBuy wayToBuy) { }
        public string Name { get; set; }
        public abstract double PricePerDay { get;  set; }
        public abstract string TypeOfRental { get; }
        public abstract double CalculateTheCostOfRental();
        public abstract IWayToBuy Strategy { get; set; }


    }
}
