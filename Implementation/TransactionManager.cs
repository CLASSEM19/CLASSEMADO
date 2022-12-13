using System;
using CLASSEM19.Implementation;
using CLASSEM19.Interface;
using CLASSEM20.Interface;
using CLASSEM20.Model;
using MySql.Data.MySqlClient;

namespace CLASSEM20.Implementation
{
    public class TransactionManager : ITransactionMananger
    {
        public int w = 0;
        public string connectString = "SERVER=localhost; User Id=root; Password=1234; DATABASE= CLASSEM20";
        ICarManager _iCarManager = new CarManager();
        IAdminManager _iAdminManager = new AdminManager();
        ICustomerManager _iCustomerManager = new CustomerManager();
        public void CreateTransaction(string customerName, string custRegNo, string email, string refNumber, decimal cashDeposit)
        {
            var car = _iCarManager.GetCar(refNumber);
            var cust = _iCustomerManager.GetCustomer(email);
            // var adm = _iAdminManager.GetAdmin(adminI)
            var receiptNo = "CLM/" + new Random(new Random().Next(10)).Next(2332, 100000) + "/REP";
            var nameCar = car.CarName;
            var refCar = car.RefNumber;
            var total = car.CarPrice;
            var change = cashDeposit - total;
            var balance = total - cashDeposit;
            var dateAndTime = DateTime.Now;
            var manPhoneNo = "09035407565";
            var custNo = cust.PhoneNumber;
            if (change > 0)
            {
                Console.Beep();
                Console.WriteLine($"\n\tYou Can't Pay Lower than {total}.");
            }
            else if(balance > 0)
            {
                Console.Beep();
                Console.WriteLine($"\n\tDear Customer, You have {balance} to Complete your Payment");
            }
            else
            {
                Transaction transaction = new Transaction(receiptNo, cashDeposit, total, dateAndTime, manPhoneNo);
                try
                {
                    using (var connection = new MySqlConnection(connectString))
                    {
                        connection.Open();
                        var queryCreate = $"Insert into transaction (RECEIPTNO, CUSTOMERNAME, CUSTOMEREMAIL, CUSTOMERREGNO, CARNAME, CAREFNO, CARPRICE, CASHDEPOSITED, MANAGEMENTPHONENUMBER, CUSTOMERPHONENUMBER, DATEANDTIME) values ('{receiptNo}','{customerName}','{cust.Email}','{custRegNo}','{nameCar}','{refCar}','{total}', '{cashDeposit}','{manPhoneNo}','{custNo}','{dateAndTime}')";
                        using (var command = new MySqlCommand(queryCreate, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                Console.Beep(); Console.Beep();
                Console.Write("\n\t########################################");
                Console.Write("\t####### CLASSEM SUPERCAR OUTLET ########");
                Console.Write("\t########################################");
                Console.Write("\tMOTTO: ...ELEGANCY WITH SIMPLICITY....");
                Console.Write($"\n\t_____________________________________________\n\tTransaction Date: {dateAndTime}\n\tReceipt No: {receiptNo}\n\tCustomer Name: {customerName}\n\tCustomer Email: {cust.Email}\n\tCustomer RegNo: {custRegNo}\n\tCar Name: {nameCar}\n\tCar Ref Number: {refCar}\n\tCar Price: {total}\n\tMoney Deposited: {cashDeposit}\n\tCustomer Change: {change}\n\tBALANCE to COMPLETE PAYMENT: {balance}\n\tMANAGEMENT NUMBER: {manPhoneNo}\n\tCUSTOMER NUMBER: {cust.PhoneNumber}");
                Console.Write("\t....THANKS FOR YOUR PATRONAGE......");
            }
        }
        public void CreateDataBaseTable()
        {
            var TransactionQuery = "CREATE TABLE TRANSACTION(ID int auto_increment NOT NULL, RECEIPTNO VARCHAR (50) NOT NULL UNIQUE , CUSTOMERNAME varchar(50)NOT NULL, CUSTOMEREMAIL varchar(50) NOT NULL UNIQUE, CUSTOMERREGNO varchar(50) NOT NULL UNIQUE, CARNAME varchar(100) NOT NULL , CAREFNO varchar(50) NOT NULL, CARPRICE DECIMAL(65) NOT NULL, CASHDEPOSITED DECIMAL(65) NOT NULL, MANAGEMENTPHONENUMBER VARCHAR(60) not null UNIQUE, CUSTOMERPHONENUMBER VARCHAR (50) NOT NULL UNIQUE, DATEANDTIME varchar(50) NOT NULL, primary Key(ID,RECEIPTNO))";
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(TransactionQuery, connection))
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
        public void GetAllTransaction()
        {
            try
            {
                using (var connection = new MySqlConnection(connectString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From transaction", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["RECEIPTNO"]}\t{reader["CUSTOMERNAME"]}\t{reader["CUSTOMEREMAIL"]}\t{reader["CUSTOMERREGNO"]}\t{reader["CARNAME"]}\t{reader["CARPRICE"]}\t{reader["CASHDEPOSITED"]}\t{reader["MANAGEMENTPHONENUMBER"]}\t{reader["CUSTOMERPHONENUMBER"]}\t{reader["DATEANDTIME"]}");
                           // (RECEIPTNO, CUSTOMEREGNO, CARNAME, CARPRICE, CASHDEPOSITED, MANAGEMENTPHONENUMBER, CUSTOMERPHONENUMBER, DATEANDTIME) 
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public decimal CalculateTotalTransaction()
        {
            decimal totalTransaction = 0;

            return totalTransaction;
        }
    }
}