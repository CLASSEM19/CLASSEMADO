namespace CLASSEM19.Model
{
    public class User
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public string Pin{get;set;}
        public User(string firstName, string lastName, string email, string pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Pin = pin;
        }

    }
}