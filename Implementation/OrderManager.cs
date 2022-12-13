using System;
using System.Collections.Generic;
using System.IO;
using CLASSEM19.Interface;
using CLASSEM19.Menu;
using CLASSEM19.Model;
using MySql.Data.MySqlClient;

namespace CLASSEM19.Implementation
{
    public class OrderManager : IOrderManager
    {
        public string connectString = "SERVER = localhost; User Id = root; Password = 1234; DATABASE = CLASSEM20";
        ICarManager _iCarManager = new CarManager();
        public void CreateOrder(string customerName, string goods, string deliveryAddress, string customerPhoneNumber, string customerEmail, decimal totalPrice)
        {
            Random rand = new Random();
            string refNumber = "CLM/" + rand.Next(2332, 100000) + "/ORD";
            var order = new Order(refNumber, customerName, goods, deliveryAddress, customerPhoneNumber,customerEmail, totalPrice);
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryCreate = $"insert into orders (REFNUMBER,CUSTOMERNAME,GOODS,DELIVERYADDRESS,CUSTOMERPHONENUMBER,CUSTOMEREMAIL, TOTALPRICE) value ('{refNumber}','{customerName}','{goods}','{deliveryAddress}','{customerPhoneNumber}','{customerEmail}','{totalPrice}')";
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
            Console.WriteLine($"\n\tDear Customer, You have Successfully Complete an Order\n\tYour Order Refrence Number is {refNumber}.\n\tKeep it Safe.");
        }

        public void DeleteOrder()
        {
            Console.Write("\nEnter Ref Number of Order To Delete: ");
            string refNumber = Console.ReadLine().Trim();
            var order = GetOrder(refNumber);
            if (order != null)
            {
                try
                {
                    var feedBack = $"\n\tYou Delete Order of Ref Number {refNumber} Successfully!";
                    using (var connection = new MySqlConnection(connectString))
                    {
                        connection.Open();
                        var querryDelete = $"DELETE From orders WHERE REFNUMBER = '{refNumber}'";
                        using (var command = new MySqlCommand(querryDelete, connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.Beep();
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
                Console.WriteLine("USER NOT FOUND!");
            }
        }

        public Order GetOrder(string refNumber)
        { 
            Order order = null;
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryGet = $"select * From orders WHERE REFNUMBER = '{refNumber}'";
                    using (var command = new MySqlCommand(querryGet, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            order = new Order(reader["REFNUMBER"].ToString().ToUpper(), reader["CUSTOMERNAME"].ToString(), reader["GOODS"].ToString(), reader["DELIVERYADDRESS"].ToString(), reader["CUSTOMERPHONENUMBER"].ToString(), reader["CUSTOMEREMAIL"].ToString(), (decimal)(reader["TOTALPRICE"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return order != null && order.RefNumber.ToUpper() == refNumber.ToUpper() ? order : null;
        }
        public void GetAllOrder()
        {
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryGet = "select * From orders";
                    using (var command = new MySqlCommand(querryGet, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}\t{reader["REFNUMBER"].ToString()}\t{reader["CUSTOMERNAME"].ToString()}\t{reader["GOODS"].ToString()}\t{reader["DELIVERYADDRESS"].ToString()}\t{reader["CUSTOMERPHONENUMBER"].ToString()}\t{reader["CUSTOMEREMAIL"].ToString()}\t{(decimal)(reader["TOTALPRICE"])}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateOrder()
        {
            Console.Write("\nEnter Ref Number of Order To Update: ");
            string refNumber = Console.ReadLine().Trim();
            Console.Write("Enter Goods Updating To: ");
            string goods = Console.ReadLine().Trim();
            Console.Write("Enter Address Updating To: ");
            string deliveryAddress = Console.ReadLine().Trim();
            Console.Write("Enter Phone Number Updating To: ");
            string customerPhoneNumber = Console.ReadLine().Trim();
            // Console.Write("\nEnter the New Ordering Goods Updating to: ");
            // decimal wallet = decimal.Parse(Console.ReadLine().Trim());
            var order = GetOrder(refNumber);
            if (order != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectString))
                    {
                        var feedBack = $"\n\tThe Orders of Ref Number {refNumber},\n\tUPDATED SUCCESSFULY!!";
                        connection.Open();
                        var queryUpdateA = $"Update orders SET GOODS = '{goods}', DELIVERYADDRESS = '{deliveryAddress}', CUSTOMERPHONENUMBER = '{customerPhoneNumber}' where REFNUMBER = '{refNumber}'";
                        using (var command = new MySqlCommand(queryUpdateA, connection))
                        {
                            var yes = command.ExecuteNonQuery();
                            Console.Beep();
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
                Console.WriteLine("\nORDER NOT FOUND!");
            }
        }
    }
}