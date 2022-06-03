using StoreAppModel;

namespace StoreAppUI
{
    public class MainMenu : iMenu
    {
        public void Display()
        {
            Console.WriteLine("Please make a selection: ");
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. Search for customer");
            Console.WriteLine("3. Exit");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Log.Information("User is adding customer");
                //Logic to add customer
                return "AddCustomer";

            }
            else if (userInput == "2")
            {
                Log.Information("User is searching  for customer");
                //logic to search for customer
                return "SearchCustomer";
            }
            else if (userInput == "3")
            {
                //Logic to exit
                return "Exit";
            }
            else
            {
                Log.Warning("User entered invalid response");
                Console.WriteLine("Please input a valid response");
                return "MainMenu";
            }
        }
    }
}