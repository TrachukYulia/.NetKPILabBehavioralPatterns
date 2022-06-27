using System;

namespace EquipmentRental
{
    public class Bike : Equipment
    {
        private double _price;
        public Bike(string name, IWayToBuy wayToBuy) : base(name, wayToBuy)
        {
            Name = name;
        }
        private string _typeOfRental;
        public override string TypeOfRental => _typeOfRental;
        
        public override double PricePerDay
        {
            get { return _price; }
            set { _price = value; }
        }
        public override IWayToBuy Strategy {  get; set; }

        public override double CalculateTheCostOfRental()
        {
            _typeOfRental = Strategy.Type;
            return Strategy.AlgorithmOfCost(_price);
        }

    }
}
