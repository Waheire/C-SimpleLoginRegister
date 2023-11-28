// See https://aka.ms/new-console-template for more information
using login_Registration;

userManager userManager = new userManager(@"C:\Credentials\credentials.txt");

while (true)
{
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Dashboard");
    Console.WriteLine("4. Exit");

    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            userManager.RegisterUser();
            break;
        case "2":
            userManager.LoginUser();
            break;
        case "3":
            userManager.loadDashboard();
            break;
        case "4":
            userManager.saveUsers();
            Console.WriteLine("Exiting the program. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine();
}
    


