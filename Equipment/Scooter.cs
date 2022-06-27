using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
   public class Scooter: Equipment
    {
        public Scooter(string name, IWayToBuy wayToBuy) : base(name, wayToBuy)
        {
            Name = name;
        }
        private string _typeOFRental;
        public override string TypeOfRental => _typeOFRental;
        public override IWayToBuy Strategy { get; set; }

        public override double PricePerDay { get;  set; }

        public override double CalculateTheCostOfRental()
        {
            _typeOFRental = Strategy.Type;
           return Strategy.AlgorithmOfCost(PricePerDay);
        }
    }
}
