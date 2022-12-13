using CLASSEM19.Menu;
using CLASSEM19.Model;
namespace CLASSEM19.Interface
{
    public interface IAdminManager
    {
        public void CreateAdmin(string firstName, string lastName, string email, string pin, string phoneNumber, string post);
        public void UpdateAdmin(string firstName, string lastName, string email, string phoneNumber);
        public void DeleteAdmin();
        public Admin GetAdmin(string email);
        public void GetAllAdmin();
        public Admin Login(string email, string pin);
    }
}