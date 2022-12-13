namespace CLASSEM19.Model
{
    public class Admin:User
    {
        public string id;
        public string AdminId { get; set; }
        public string PhoneNumber{get;set;}
        public string Post { get; set; }
        public Admin (string firstName, string lastName, string email, string pin, string adminId, string phoneNumber, string post) : base(firstName, lastName, email, pin)
        {
            AdminId = adminId;
            PhoneNumber = phoneNumber;
            Post = post;
        }
    }
}