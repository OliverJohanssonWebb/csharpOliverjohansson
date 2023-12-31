using Newtonsoft.Json;
namespace ConsoleinlOJ.Users;

public class UserManager
{
    private List<User> existingUsers;
    
    //Loading the file at start. 
    public UserManager() {
        existingUsers = ReadUsersFromFile();
    }    
    public void AddNewUser()
    {
        
        // All input strings. 
        Console.Write("Enter First name: ");
        string username = Console.ReadLine()!;

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter email: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("Enter Postalcode: ");
        string postalcode = Console.ReadLine()!;

        // Create a user.
        User newUser = new()
        {
            Username = username,
            LastName = lastName,
            Email = email,
            Postalcode = postalcode,
            Phone = phone
        };

        // Read existing users from the file.
        List<User> existingUsers = ReadUsersFromFile();

        // Add the new user to the list.
        existingUsers.Add(newUser);

        // Convert the list to JSON
        string json = JsonConvert.SerializeObject(existingUsers, Newtonsoft.Json.Formatting.Indented);

        // Save JSON to a file
        string filePath = Path.Combine("C:\\projects", "users.json");
        File.WriteAllText(filePath, json);

        
        SaveUsersToFile(existingUsers);
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
        // Retrieve the list of users
        List<User> existingUsers = ReadUsersFromFile();

        // Display users.
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
        //Asking for the email to be able to see specific info about a specific user. 
        Console.Write("Enter the email of the user to view: ");
        string emailToView = Console.ReadLine();

        // Retrieve the list of users
        List<User> existingUsers = ReadUsersFromFile();

        //made it case-insensitive.
        User userToView = existingUsers.Find(u => u.Email.Equals(emailToView, StringComparison.OrdinalIgnoreCase))!;

        if (userToView != null)
        {
            
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
        //Ask the user for the email to delete
        Console.Write("Enter the email of the user to delete: ");
        string emailToDelete = Console.ReadLine();

        // Retrieve the list of users
        List<User> existingUsers = ReadUsersFromFile();

        if (existingUsers != null)
        {
            //case-insensitive remowal of user/user with that email.
            existingUsers.RemoveAll(u => u.Email.Equals(emailToDelete, StringComparison.OrdinalIgnoreCase));

            // Convert the updated list of users to JSON
            string json = JsonConvert.SerializeObject(existingUsers, Newtonsoft.Json.Formatting.Indented);

            // Save JSON to file
            string filePath = Path.Combine("C:\\projects", "users.json");
            File.WriteAllText(filePath, json);

            Console.WriteLine($"Deleted user(s) with email '{emailToDelete}'.");
        }
        else
        {
            Console.WriteLine("Error: Unable to retrieve user data from the file.");
        }
    }

    private void SaveUsersToFile(List<User> users)
    {
        // Convert the list to JSON
        string json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

        // Save JSON to the file
        string filePath = Path.Combine("C:\\projects", "users.json");
        File.WriteAllText(filePath, json);
    }
}


