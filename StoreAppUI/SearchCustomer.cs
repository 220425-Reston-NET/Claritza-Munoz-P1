using StoreAppBL;
using StoreAppModel;

public class SearchCustomer : iMenu
{
    public static Customer foundCustomer;
    //====Dependency Injection Pattern======
    
    //field of the interface you are trying to add
    private iCustomerBL _custBL;
    //constructor w/parameter of that interface
    public SearchCustomer(iCustomerBL _custobjBL)
    {
        //set field with parameter
        _custBL = _custobjBL;
    }
    //=======================================

    public void Display()
    {
        Console.WriteLine("Make a selection:");
        Console.WriteLine("1. Search customer's username");
        Console.WriteLine("2. Go back to Main Menu");
        
    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();

        if(userInput == "1")
        {
            Console.WriteLine("Enter Username: ");
            string _username = Console.ReadLine();

            foundCustomer = _custBL.SearchCustomer(_username);
            if (foundCustomer == null)
            {
                Log.Warning("User entered non-existing customer");
                Console.WriteLine("Customer was not found!");
            }
            else
            {
                
                Console.WriteLine(foundCustomer);
            
                Console.WriteLine("Would you like to add an order to your customer?");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. View Customer Orders");
                Console.WriteLine("3. Go back to Search Customer");
                string addOrderChoice = Console.ReadLine();

                if (addOrderChoice == "1")
                {
                    Log.Information("User is adding an order");
                    return "SelectOrder";
                }
                else if(addOrderChoice == "2")
                {
                    Log.Information("User is viewing customer order");
                    return "ViewCustomerOrder";
                }
                else
                {
                    Log.Information("User went back to Search customer menu");
                    return "SearchCustomer";
                }
            }

            Console.ReadLine();
            return "SearchCustomer";
        }
        else if(userInput == "2")
        {
            Log.Information("User went back to main menu");
            return "MainMenu";

        }
        else
        {
            Log.Warning("User entered invalid code");
            Console.WriteLine("Please enter valid choice.");
            return "SearchCustomer";
        }
    }
}