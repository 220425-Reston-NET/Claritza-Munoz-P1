using StoreAppBL;
using StoreAppModel;
public class AddCustomer : iMenu
{

    private Customer custobj = new Customer();
    //====Dependency Injection Pattern======
    
    //field of the interface you are trying to add
    private iCustomerBL _custBL;
    //constructor w/parameter of that interface
    public AddCustomer(iCustomerBL _custobjBL)
    {
        //set field with parameter
        _custBL = _custobjBL;
    }
    //=======================================
    public void Display()
    {
        Console.WriteLine("Enter customer details");
        Console.WriteLine("Enter Username: ");
        custobj.Username = Console.ReadLine();
        Console.WriteLine("Enter Name: ");
        custobj.Name = Console.ReadLine();
        Console.WriteLine("Enter Address: ");
        custobj.Address = Console.ReadLine();
        Console.WriteLine("Enter Email Address: ");
        custobj.Email = Console.ReadLine();
        Console.WriteLine("What would you like  to do next?");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Go Back");
    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();

        if(userInput == "1")
        {
            try
            {
                _custBL.AddCustomer(custobj);
                
            }
            catch (System.NotImplementedException)
            {
                Log.Warning("User tried to add an already existing username");
                Log.Information(custobj.ToString());
                Console.WriteLine("Username already exists!");
                Console.ReadLine();
            }
            Console.WriteLine("Customer Added!");
            return "MainMenu";
        }
        else if(userInput  == "2")
        {
            return "MainMenu";
        }
        else
        {
            Console.WriteLine("Please enter valid choice.");
            return "AddCustomer";
        }
    }
}