using System;
using CLASSEM19.Interface;
using CLASSEM19.Model;
using MySql.Data.MySqlClient;
namespace CLASSEM19.Implementation
{
    public class AdminManager : IAdminManager
    {
        public string ConnectString = "SERVER = localhost; User Id = root; Password = 1234 ; DATABASE = CLASSEM20";

        public void CreateAdmin(string firstName, string lastName, string email, string pin, string phoneNumber, string post)
        {
            Random rand = new Random();
            string adminId = "CLM/" + rand.Next(1000, 9999) + "/" + lastName;
            Admin adm = new Admin(firstName, lastName, email, pin, adminId, phoneNumber, post);
            
            try
            {
                using (var connection = new MySqlConnection(ConnectString))
                {
                    connection.Open();
                    var querryCreate = $"insert into admin (FIRSTNAME, LASTNAME, EMAIL, PIN, ADMINID, PHONENUMBER, POST) value ('{firstName}','{lastName}','{email}','{pin}','{adminId}','{phoneNumber}','{post}')";
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
            Console.WriteLine($"\n\tThank you Dear. {adm.FirstName}, your STAFF IDENTITY NUMBER is {adm.AdminId}\n\t KEEP IT SAFE.");
        }

        public void DeleteAdmin()
        {
            Console.Write("\n\tEnter Admin Email to delete: ");
            string email = Console.ReadLine().Trim();
            var admin = GetAdmin(email);
            if (admin != null)
            {
                try
                {
                    var deleteAdmin = $"\n\t{admin.FirstName} {admin.LastName} Account Successfully Deleted";
                    using (var connection = new MySqlConnection(ConnectString))
                    {
                        connection.Open();
                        var querryCreate = $"Delete from admin Where EMAIL = '{email}'";
                        using (var command = new MySqlCommand(querryCreate, connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.Beep();
                            Console.WriteLine(deleteAdmin);
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
                Console.WriteLine("\n\tUSER NOT FOUND");
            }
        }
        public Admin GetAdmin(string email)
        {
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection(ConnectString))
                {
                    connection.Open();
                    var querryCreate = $"select * from admin where EMAIL = '{email}'";
                    using (var command = new MySqlCommand(querryCreate, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin(reader["FIRSTNAME"].ToString(), reader["LASTNAME"].ToString(), reader["EMAIL"].ToString(), reader["PIN"].ToString(), reader["ADMINID"].ToString(), reader["PHONENUMBER"].ToString(), reader["POST"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return admin is not null && admin.Email.ToUpper() == email.ToUpper() ? admin : null;
        }
        public void GetAllAdmin()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectString))
                {
                    connection.Open();
                    var querryCreate = $"select * from admin";
                    using (var command = new MySqlCommand(querryCreate, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}\t{reader["FIRSTNAME"].ToString()}\t{reader["LASTNAME"].ToString()}\t{reader["EMAIL"].ToString()}\t{reader["PIN"].ToString()}\t{reader["ADMINID"].ToString()}\t{reader["PHONENUMBER"].ToString()}\t{reader["POST"].ToString()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public Admin Login(string email, string pin)
        {
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection(ConnectString))
                {
                    connection.Open();
                    var querryLogIn = $"select * from admin where EMAIL = '{email}'";
                    using (var command = new MySqlCommand(querryLogIn, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin(reader["FIRSTNAME"].ToString(), reader["LASTNAME"].ToString(), reader["EMAIL"].ToString(), reader["PIN"].ToString(), reader["ADMINID"].ToString(), reader["PHONENUMBER"].ToString(), reader["POST"].ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return admin != null && admin.Email == email && admin.Pin == pin ? admin : null;
        }

        public void UpdateAdmin(string firstName, string lastName, string email, string phoneNumber)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectString))
                {
                    var feedBack = $"\n\t{firstName} {lastName} Updated Account Successfully!";
                    connection.Open();
                    var querryUpdate = $"(Update admin SET (FIRSTNAME, LASTNAME, EMAIL, PHONENUMBER) value ('{firstName}','{lastName}','{email}','{phoneNumber}') where EMAIL = '{email}')";
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

    }
}