using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace StoreAppModel
{
    public class Customer
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        private string _email;

        public string Email 
        { 
            get {return _email; }
            set
            {
                try
                {
                    _email = value;
                }
                catch (FormatException)
                {
                    
                    throw new ValidationException("Invalid Email!");
                }
                _email = value;
            }   
        }
        public List<Order> Orders { get; set; }

        public Customer()
        {
            Username = this.Username;
            Name = this.Name;
            Address = this.Address;
            Email = this.Email;
            Orders = new List<Order>();
        }

        //override
        public override string ToString()
        {
            return $"=====Customer Information=====\nUsername: {Username}\nName: {Name}\nAddress: {Address}\nEmail: {Email}\n==============================";
        }

    }
}

