namespace ConsoleinlOJ.Users;

public class User
{
    public string Username { get; set; }
    public string LastName { get; set; }
    private string _email;  // backing field for the Email property

    public string Email
    {
        get { return _email ?? string.Empty; }  // return an empty string if _email is null
        set { _email = value; }
    }

    public string Postalcode { get; set; }
    public string Phone { get; set; }
}
