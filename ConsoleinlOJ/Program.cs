using ConsoleinlOJ.Users;
using Newtonsoft.Json;
using System.Xml;




    UserManager userManager = new();

    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("1. Add a new user");
        Console.WriteLine("2. List all users");
        Console.WriteLine("3. View a specific user by email");
        Console.WriteLine("4. Delete a user by email");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option (1, 2, 3, 4, or 5): ");

        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                userManager.AddNewUser();
                break;
            case "2":
                userManager.ListAllUsers();
                break;
            case "3":
                userManager.ViewUserByEmail();
                break;
            case "4":
                userManager.DeleteUserByEmail();
                break;
            case "5":
                exit = true;
                Console.WriteLine("Exiting the application.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, or 5.");
                break;
        }
    }

