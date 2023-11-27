// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Transactions;

// Check if the directory exists
string directoryPath = @"C:\Credentials\";
string filePath = Path.Combine(directoryPath, "credentials.txt");

if (!Directory.Exists(directoryPath))
{
    // If not, create the directory
    Directory.CreateDirectory(directoryPath);
    Console.WriteLine($"Directory '{directoryPath}' created.");
}
else
{
    Console.WriteLine($"Directory '{directoryPath}' already exists.");
}

// Check if the file exists
if (!File.Exists(filePath))
{
    // If not, create the file
    using (File.Create(filePath))
    {
        Console.WriteLine($"File '{filePath}' created.");
    }
}
else
{
    Console.WriteLine($"File '{filePath}' already exists.");
}
    
//login user
Console.WriteLine("Enter Username: ");
string username = Console.ReadLine();
Console.WriteLine("Enter Password: ");
string password = Console.ReadLine();

//check if user credentials exists in credentials.txt
if (username != null && password != null)
{
    // Read all lines from the file
    string[] files = File.ReadAllLines(filePath);
    if (files.Length == 0)
    {
        //save the credentials
        File.AppendAllText(filePath, username);
        File.AppendAllText(filePath, ":");
        File.AppendAllText(filePath, password);
        File.AppendAllText(filePath, ",");
        File.AppendAllText(filePath, "\n");
        Console.WriteLine("Credentials Successfully saved");

    } 
    if (files.Length >= 1) {
        //Console.WriteLine(files[0] + "I reached and found nothing in the file");
        foreach (var file in files)
        {
            string[] parts = file.Split(':');
            if (parts.Length == 2)
            {
                string storedUsername = parts[0].Trim();
                string StoredPassword = parts[1].Trim();

                //compare username and password
                if (storedUsername == username && StoredPassword == password)
                {
                    Console.WriteLine("Login successfull");
                    Console.WriteLine($"Welcome {username}");
                }
                else
                {
                    Console.WriteLine("Credentials not Found");
                    //register user
                    Console.WriteLine("Enter Username to register: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter Password to register: ");
                    password = Console.ReadLine();

                    //save the credentials
                    File.AppendAllText(filePath, username);
                    File.AppendAllText(filePath, ":");
                    File.AppendAllText(filePath, password);
                    File.AppendAllText(filePath, ",");
                    File.AppendAllText(filePath, "\n");
                    Console.WriteLine("Credentials Successfully saved");
                }
            }
        }

    } 
}


