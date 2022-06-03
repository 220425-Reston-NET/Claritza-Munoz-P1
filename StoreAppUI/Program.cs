global using Serilog;
using StoreAppModel;
using StoreAppBL;
using StoreAppDL;
using StoreAppUI;
using Microsoft.Extensions.Configuration;

//initialize my logger
Log.Logger = new LoggerConfiguration()  //LoggerConfiguration used to configure logger and create it
    .WriteTo.File("./logs/user.txt")    //configuring the logger to save info to a file called user.txt inside of logs folder
    .CreateLogger();    //method to  create the logger

// See https://aka.ms/new-console-template for more information

//initializing configuratino object
var configuration = new ConfigurationBuilder() //create configuration object
    .SetBasePath(Directory.GetCurrentDirectory())   //set base path to current directory
    .AddJsonFile("appsettings.json")  //grabs json file that holds info
    .Build(); // creates object

Console.WriteLine("Hello, World!");

Console.Clear();

iMenu menu = new MainMenu();
bool repeat = true;

while (repeat)
{
    Console.Clear();

    menu.Display();
    string choice = menu.YourChoice();

    if (choice == "MainMenu")
    {
        Log.Information("User going to main menu");
        menu = new MainMenu();
    }
    else if (choice == "AddCustomer")
    {
        Log.Information("User went to Add Customer Menu");
        menu =  new AddCustomer(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Claritza Munoz"))));
    }
    else if (choice == "SearchCustomer")
    {
        Log.Information("User went to Search Customer Menu");
        menu = new SearchCustomer(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Claritza Munoz"))));
    }
    else if (choice == "SelectOrder")
    {
        Log.Information("User went to Select Order Menu");
        menu = new SelectOrder(new OrderBL(new OrderRepository()), new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Claritza Munoz"))));
    }
    else if (choice == "ViewCustomerOrder")
    {
        Log.Information("User went to View Customer Order Menu");
        menu = new ViewCustomerOrder();
    }
    else if (choice == "Exit")
    {
        repeat = false;
    }
    
}