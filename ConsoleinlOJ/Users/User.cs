namespace ConsoleinlOJ.Users;

public class User
{
    public string Username { get; set; }
    public string LastName { get; set; }
    private string _email;

    //Continued crashing on this part. Had to do it this way. 
    public string Email
    {
        get { return _email ?? string.Empty; }  // return an empty if email is null
        set { _email = value; }
    }

    public string Postalcode { get; set; }
    public string Phone { get; set; }
}
