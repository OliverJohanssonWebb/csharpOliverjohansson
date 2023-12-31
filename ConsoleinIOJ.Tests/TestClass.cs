using ConsoleinlOJ.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void Email_PropertyShouldNotBeNull()
    {
        // Arrange
        User user = new User();

        // Act
        // Setting Email to null to trigger the null-coalescing behavior
        user.Email = null;

        // Assert
        Assert.IsNotNull(user.Email);
    }

    [TestMethod]
    public void Email_PropertyShouldReturnEmptyStringWhenSetToNull()
    {
        // Arrange
        User user = new User();

        // Act
        user.Email = null;

        // Assert
        Assert.AreEqual(string.Empty, user.Email);
    }

    [TestMethod]
    public void Email_PropertyShouldReturnAssignedValue()
    {
        // Arrange
        User user = new User();

        // Act
        string expectedEmail = "test@example.com";
        user.Email = expectedEmail;

        // Assert
        Assert.AreEqual(expectedEmail, user.Email);
    }
}