using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental
{
    public interface IWayToBuy
    {
        string Type { get; }
        double AlgorithmOfCost(double price);
    }
}
