using System;
using System.Collections.Generic;
using System.Text;


namespace EquipmentRental
{
    public class Client
    {

        public string FullName { get; internal set; }

        private double _costOfRental;
        public double CostOfRental => _costOfRental;

        public List<Equipment> _listOfOrder;
        public List<Equipment> ListOfOrder => _listOfOrder;

        public Client(string fullName)
        {
            FullName = fullName;
            _listOfOrder = new List<Equipment>();
        }
        public void SetOrder(Equipment equipment, int dayToRent)
        {
            _costOfRental = equipment.CalculateTheCostOfRental() * dayToRent;
            _listOfOrder.Add(equipment);

        }
    }
}
