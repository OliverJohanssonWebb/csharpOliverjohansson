using Newtonsoft.Json;
namespace ConsoleinlOJ.Users;

public class UserManager
{
    public void AddNewUser()
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

    public void ListAllUsers()
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
    public void ViewUserByEmail()
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

    public void DeleteUserByEmail()
    {
        // Prompt the user for the email to delete
        Console.Write("Enter the email of the user to delete: ");
        string emailToDelete = Console.ReadLine();

        // Retrieve the list of existing users
        List<User> existingUsers = ReadUsersFromFile();

        if (existingUsers != null)
        {
            // Find and remove all users with the specified email (case-insensitive)
            existingUsers.RemoveAll(u => u.Email.Equals(emailToDelete, StringComparison.OrdinalIgnoreCase));

            // Convert the updated list of users to JSON
            string json = JsonConvert.SerializeObject(existingUsers, Newtonsoft.Json.Formatting.Indented);

            // Save JSON to the file
            string filePath = Path.Combine("C:\\projects", "users.json");
            File.WriteAllText(filePath, json);

            Console.WriteLine($"Deleted user(s) with email '{emailToDelete}'.");
        }
        else
        {
            Console.WriteLine("Error: Unable to retrieve user data from the file.");
        }
    }
}


