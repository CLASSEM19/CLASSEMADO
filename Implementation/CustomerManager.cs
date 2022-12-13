using System;
using System.Collections.Generic;
using System.IO;
using CLASSEM19.Interface;
using CLASSEM19.Menu;
using CLASSEM19.Model;
using MySql.Data.MySqlClient;

namespace CLASSEM19.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        public string connectString = "SERVER=localhost; User Id=root; Password=1234; DATABASE= CLASSEM20";
        public string email;
        public string ConnectString { get; private set; }
        public void CreateCustomer(string firstName, string lastName, string email, string pin, string address, string phoneNumber)
        {
            Random rand = new Random();
            string regNumber = "CLM/" + rand.Next(0001, 1000) + "/CUS";
            //decimal wallet = 5000;
            var cust = new Customer(regNumber,firstName, lastName, email, pin, address, phoneNumber);
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryCreate = $"insert into customer (REGNUMBER,FIRSTNAME,LASTNAME,EMAIL,PIN,ADDRESS,PHONENUMBER) value ('{regNumber}','{firstName}','{lastName}','{email}',{pin},'{address}','{phoneNumber}')";
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
            Console.WriteLine($"\n\tDear {firstName}, Create Account Successfully!\n\tYour Customer Identity Number is {regNumber}.\n\tPLEASE, KEEP IT SAFE."); 
        }
        public Customer GetCustomer(string email)
        {
            Customer cust = null;
            try
            {
                using(var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querryGet = $"select * from customer where EMAIL = '{email}'";
                    using (var command = new MySqlCommand(querryGet, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cust = new Customer(reader["FIRSTNAME"].ToString(), reader["LASTNAME"].ToString(), reader["EMAIL"].ToString(), reader["PIN"].ToString(),reader["REGNUMBER"].ToString(), reader["ADDRESS"].ToString(), reader["PHONENUMBER"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cust != null && cust.Email.ToUpper() == email.ToUpper() ? cust: null;
        }

        public Customer LoginCustomer(string email, string pin)
        {
            Customer cust = null;
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    var querry = $"select * from  customer where Email = '{email}';";
                    using (var command = new MySqlCommand(querry, connection))
                    {
                       var reader = command.ExecuteReader();
                       while (reader.Read())
                       {
                            cust = new Customer(reader["REGNUMBER"].ToString(),reader["FIRSTNAME"].ToString(),reader["LASTNAME"].ToString(),reader["EMAIL"].ToString(),reader["PIN"].ToString(),reader["ADDRESS"].ToString(),reader["PHONENUMBER"].ToString());
                       }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cust != null && cust.Email == email && cust.Pin == pin ? cust:null;
        }
        public void DeleteCustomer()
        {
            Console.Write("\nEnter Customer Email to Delete: ");
            string email = Console.ReadLine().Trim();
            var cust = GetCustomer(email);
            if (cust != null)
            {
                try
                {
                    var deleteCustomer = $"\n\t{cust.FirstName} {cust.LastName} Account Successfully Deleted.";
                    using (var connection = new MySqlConnection(connectString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From customer WHERE EMAIL = '{email}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.Beep();
                            Console.WriteLine(deleteCustomer);
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
                Console.Write("\n\tUSER NOT FOUND!");
            }
        }
        public void GetAllCustomer()
        {
           try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From customer", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}\t{reader["REGNUMBER"].ToString()}\t{reader["FIRSTNAME"].ToString()}\t{reader["LASTNAME"].ToString()}\t{reader["EMAIL"].ToString()}\t{reader["ADDRESS"].ToString()}\t{reader["PHONENUMBER"].ToString()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void UpdateCustomer(string regNumber, string firstName, string lastName, string email, string address, string phoneNumber)
        {
           try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    var feedBack = $"\n\tCustomer With {regNumber} Reg Number Account  Updated Successfully. ";                  
                    connection.Open();
                    var queryUpdate = $"Update admin SET FIRSTNAME = '{firstName}', LASTNAME = '{lastName}', EMAIL = '{email}',PHONENUMBER = '{phoneNumber}' where REGNUMBER = '{regNumber}'";
                    using (var command = new MySqlCommand(queryUpdate, connection))
                    {
                        var yes = command.ExecuteNonQuery();
                        Console.Beep();
                        Console.Write(feedBack);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
        }

        public void CreateDataBaseTable()
        {
            var AdminQuery = "CREATE TABLE CUSTOMER(ID int auto_increment NOT NULL, REGNUMBER VARCHAR (25) NOT NULL UNIQUE , FIRSTNAME varchar(100) NOT NULL, LASTNAME varchar(100) NOT NULL , EMAIL varchar(100) NOT NULL UNIQUE,PIN VARCHAR (50) DEFAULT '0000', ADDRESS varchar(100) NOT NULL, PHONENUMBER VARCHAR (25) NOT NULL UNIQUE, primary Key(id,email))";
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(AdminQuery, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // public object GetCustomer(object email)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
