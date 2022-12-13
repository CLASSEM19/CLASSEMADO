using System;
using System.Collections.Generic;
using System.IO;
using CLASSEM19.Interface;
using CLASSEM19.Menu;
using CLASSEM19.Model;
using MySql.Data.MySqlClient;

namespace CLASSEM19.Implementation
{
    public class CarManager : ICarManager
    {
        public string connectString = "SERVER = localhost; User Id = root; Password = 1234; DATABASE = CLASSEM20";
        public double carprice;
        public double newCarPrice;
        public string connnectString;

        public void CreateCar(string carName, string carColor, decimal carPrice, string carEngineType)
        {
            Random rand = new Random();
            string refNumber = "CLM/" + rand.Next(0001, 1000) + "/CAR";
            var car = new Car(refNumber, carName, carColor, carPrice, carEngineType);
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryCreate = $"insert into car (REFNUMBER, CARNAME, CARCOLOR, CARPRICE, CARENGINETYPE) value ('{refNumber}','{carName}','{carColor}','{carPrice}','{carEngineType}')";
                    using (var command = new MySqlCommand(querryCreate, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.Beep();
            Console.WriteLine("\n\tCREATE SUCCESSFULLY!");
        }

        public void DeleteCar()
        {
            Console.Write("\nEnter Car Refrence No to Delete: ");
            string refNumber = Console.ReadLine().Trim();
            var car = GetCar(refNumber);
            if (car != null)
            {
                try
                {
                    Console.Beep();
                    var deleteCar = $"\n{car.CarName} DELETED SUCCESSFULY!";
                    using (var connection = new MySqlConnection(connectString))
                    {
                        connection.Open();
                        var querryCreate = $"Delete from car Where REFNUMBER = '{refNumber}'";
                        using (var command = new MySqlCommand(querryCreate, connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.Beep();
                            Console.WriteLine(deleteCar);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tCAR NOT FOUND!");
            }
        }

        public void GetAllCars()
        {
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryGet = $"select * from car";
                    using (var command = new MySqlCommand(querryGet, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}\t{reader["REFNUMBER"]}\t{reader["CARNAME"].ToString()}\t{reader["CARCOLOR"].ToString()}\t{(decimal)(reader["CARPRICE"])}\t{reader["CARENGINETYPE"].ToString()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public Car GetCar(string refNumber)
        {
            Car car = null;
            try
            {
                using(var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryGet = $"select * from car where REFNUMBER = '{refNumber}'";
                    using (var command = new MySqlCommand(querryGet, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            car = new  Car(reader["REFNUMBER"].ToString(), reader["CARNAME"].ToString(),reader["CARCOLOR"].ToString(), (decimal)(reader["CARPRICE"]), reader["CARENGINETYPE"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            return car != null && car.RefNumber.ToUpper() == refNumber.ToUpper() ? car : null;
        }

        public void UpdateCar()
        {
            Console.Write("\nEnter Refrence of Car Updating: ");
            string refNumber = Console.ReadLine().Trim();
            Console.Write("Enter Car Name Updating To: ");
            string carName = Console.ReadLine().Trim();
            Console.Write("Enter Car Color Updating To: ");
            string carColor = Console.ReadLine().Trim();
            Console.Write("Enter Car Price Updating To: ");
            string carPrice = Console.ReadLine().Trim();
            Console.Write("Enter Car Engine Type Updating To: ");
            string carEngineType = Console.ReadLine().Trim();
            var car = GetCar(refNumber);
            if (car != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectString))
                    {
                        Console.Beep();
                        var feedBack = $"\n\t{carName} UPDATED SUCCESSFULY!";
                        connection.Open();
                        var querryUpdate = $"update car SET(CARNAME, CARCOLOR, CARPRICE, CARENGINETYPE) value ('{carName}','{carColor}','{carPrice}','{carEngineType}' where REFNUMBER = '{refNumber}')";
                        using (var command = new MySqlCommand(querryUpdate, connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.WriteLine(feedBack);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tGOODS NOT FOUND!");
            }
        }
    }
}
