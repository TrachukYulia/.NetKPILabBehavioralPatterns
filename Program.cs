using System;
using System.Collections.Generic;
using EquipmentRental;
using System.Linq;

namespace BehavioralPatterns
{
    class Program
    {
        static void Main()
        {
            var listOfEquipment = GetEquipments();
            List<Client> listOfClient = new List<Client>();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine(" 1. Show info\t 2. Make order\t 3. Show order\t 4. Exit\t ");
                Console.WriteLine();
                try
                {
                    int pickNumber = Convert.ToInt32(Console.ReadLine());
                    if (pickNumber <= 0 || pickNumber > 4)
                        throw new Exception("Invalid pick number of category. Please, try again");
                    else
                        try
                        {
                            switch (pickNumber)
                            {
                                case 1:
                                    ShowInfoEquipment(GetEquipments());
                                    break;
                                case 2:
                                    Console.WriteLine("Enter full name of client");
                                    string fullNameOfClient = (Console.ReadLine());
                                    Client client = new Client(fullNameOfClient);
                                    Equipment equipment = PickEquipment(listOfEquipment);
                                    PickWay(client, equipment);
                                    listOfClient.Add(client);
                                    ShowCLients(listOfClient);
                                    break;
                                case 3:
                                    ShowCLients(listOfClient);
                                    break;
                                case 4:
                                    Exit();
                                    break;
                            }
                        }
                        catch (ArgumentException)
                        {
                            ConsoleColor color = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid pick number of category");
                            Console.ForegroundColor = color;
                        }
                }
                catch (Exception ex)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
            Console.ReadKey();
        }
        static List<Equipment> GetEquipments()
        {
            List<Equipment> _listOfEquipment = new List<Equipment>();
            Equipment bikeSport = new Bike("Sport Bike A", new StandartWay());
            bikeSport.PricePerDay = 20;
            Equipment bikeForCouple = new Bike("Bike for couple", new StandartWay());
            bikeForCouple.PricePerDay = 25;
            Equipment scooterElectro = new Scooter("Electro scooter", new StandartWay());
            scooterElectro.PricePerDay = 15;
            Equipment scooterForChild = new Scooter("Scooter for child", new StandartWay());
            scooterForChild.PricePerDay = 10;
           
            _listOfEquipment.Add(bikeSport);
            _listOfEquipment.Add(bikeForCouple);
            _listOfEquipment.Add(scooterForChild);
            _listOfEquipment.Add(scooterElectro);
            return _listOfEquipment;
        }
        static void Exit()
        {
            Environment.Exit(0);
        }
        static void ShowInfoWay()
        {
            Console.WriteLine("1. Standart\n 2. Preferential\n 3. Penal\n");
            Console.WriteLine();
        }
        static void ShowInfoEquipment(List<Equipment> listOfEquipment)
        {
            int i = 1;
            foreach (var item in listOfEquipment)
            {
                Console.WriteLine("{2}. Name:{0}, Price:{1}$", item.Name, item.PricePerDay, i);
                i++;
            }
            Console.WriteLine();
        }
        static void ShowCLients(List<Client> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine("Full name:{0}, Price of rental:{1}$", item.FullName, item.CostOfRental);
                foreach(var eq in item.ListOfOrder)
                    Console.WriteLine("Equipment: {0}, Type of rental: {1}", eq.Name, eq.TypeOfRental);
            }
            Console.WriteLine();
        }
        static Equipment PickEquipment(List<Equipment> listOfEquipment)
        {
            ShowInfoEquipment(GetEquipments());
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter the number of equipment for rent");
            int numberOfEquipment = Convert.ToInt32(Console.ReadLine());
            if (numberOfEquipment > 0 && numberOfEquipment < listOfEquipment.Count + 1)
                return listOfEquipment.ElementAt(numberOfEquipment - 1);
            else if (numberOfEquipment == 5)
            {
                Main();
                return null;
            }
            else
                throw new Exception("Invalid pick number of category");
        }
        static int PickNumberOfDaysToRental()
        {
            Console.WriteLine("Enter the number of days to rent");
            int numberOfDays = Convert.ToInt32(Console.ReadLine());
            if (numberOfDays > 0)
                return numberOfDays;
            else
                throw new Exception("Invalid pick number of category");
        }

        static void PickWay(Client client, Equipment equipment)
        {
            int days = PickNumberOfDaysToRental();
            ShowInfoWay();
            Console.WriteLine("Enter the number of way to rent");
            int numberOfWay = Convert.ToInt32(Console.ReadLine());
            if (numberOfWay > 0 && numberOfWay <= 4)
            {
                switch (numberOfWay)
                {
                    case 1:
                        equipment.Strategy = new StandartWay();
                        client.SetOrder(equipment, days);
                        break;
                    case 2:
                        equipment.Strategy = new PreferentialWay();
                        client.SetOrder(equipment, days);
                        break;
                    case 3:
                        equipment.Strategy = new PenalwAY();
                        client.SetOrder(equipment, days);
                        break;
                    case 4:
                        Main();
                        break;
                }
            }
            else
                throw new Exception("Invalid pick number of category");
        }
    }
}
