using ConsoleinlOJ.Users;
using Newtonsoft.Json;
using System.Xml;



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
            AddNewUser();
            break;
        case "2":
            ListAllUsers();
            break;
        case "3":
            ViewUserByEmail();
            break;
        case "4":
            DeleteUserByEmail();
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



static void AddNewUser()
{
    // Prompt the user for input
    Console.Write("Enter username: ");
    string username = Console.ReadLine()!;

    Console.Write("Enter last name: ");
    string lastName = Console.ReadLine()!;

    Console.Write("Enter email: ");
    string email = Console.ReadLine()!;

    Console.Write("Enter Phone: ");
    string phone = Console.ReadLine()!;

    Console.Write("Enter Postalcode: ");
    string postalcode = Console.ReadLine()!;

    // Create a user object
    User newUser = new()
    {
        Username = username,
        LastName = lastName,
        Email = email,
        Postalcode = postalcode,
        Phone = phone   
    };

    // Read existing users from the file, if any
    List<User> existingUsers = ReadUsersFromFile();

    // Add the new user to the list
    existingUsers.Add(newUser);

    // Convert the list of users to JSON
    string json = JsonConvert.SerializeObject(existingUsers, Newtonsoft.Json.Formatting.Indented);

    // Save JSON to a file
    string filePath = Path.Combine("C:\\projects", "users.json");
    File.WriteAllText(filePath, json);

    Console.WriteLine("User information saved to users.json");
}

static List<User> ReadUsersFromFile()
{
    // Specify the directory where the file is located
    string directoryPath = "C:\\projects";

    // Combine the directory path with the file name
    string filePath = Path.Combine(directoryPath, "users.json");

    // Read existing users from the file, if any
    if (File.Exists(filePath))
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<User>>(json);
    }
    else
    {
        return new List<User>();
    }
}

static void ListAllUsers()
{
    // Retrieve the list of existing users
    List<User> existingUsers = ReadUsersFromFile();

    // Display user information
    if (existingUsers.Count > 0)
    {
        Console.WriteLine("Existing users:");

        foreach (User user in existingUsers)
        {
            Console.WriteLine($"Username: {user.Username}, Last Name: {user.LastName}, Email: {user.Email}, Postalcode: {user.Postalcode}");
        }
    }
    else
    {
        Console.WriteLine("No users found.");
    }
}

static void ViewUserByEmail()
{
    // Prompt the user for the email to view
    Console.Write("Enter the email of the user to view: ");
    string emailToView = Console.ReadLine();

    // Retrieve the list of existing users
    List<User> existingUsers = ReadUsersFromFile();

    // Find the user with the specified email (case-insensitive)
    User userToView = existingUsers.Find(u => u.Email.Equals(emailToView, StringComparison.OrdinalIgnoreCase))!;

    if (userToView != null)
    {
        // Display user information
        Console.WriteLine($"User found with email '{emailToView}':");
        Console.WriteLine($"Username: {userToView.Username}, Last Name: {userToView.LastName}, Email: {userToView.Email}");
    }
    else
    {
        Console.WriteLine($"User with email '{emailToView}' not found.");
    }
}
static void DeleteUserByEmail()
{
    // Prompt the user for the email to delete
    Console.Write("Enter the email of the user to delete: ");
    string emailToDelete = Console.ReadLine();

    // Retrieve the list of existing users
    List<User> existingUsers = ReadUsersFromFile();

    // Find and remove all users with the specified email (case-insensitive)
    int removedCount = existingUsers.RemoveAll(u => u.Email.Equals(emailToDelete, StringComparison.OrdinalIgnoreCase));

    if (removedCount > 0)
    {
        // Convert the updated list of users to JSON
        string json = JsonConvert.SerializeObject(existingUsers, Newtonsoft.Json.Formatting.Indented);

        // Save JSON to the file
        string filePath = Path.Combine("C:\\projects", "users.json");
        File.WriteAllText(filePath, json);

        Console.WriteLine($"Deleted {removedCount} user(s) with email '{emailToDelete}'.");
    }
    else
    {
        Console.WriteLine($"User with email '{emailToDelete}' not found.");
    }
}
