using ConsoleinlOJ.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void Email_PropertyShouldNotBeNull()
    {
        //arrange.
        User user = new User();

        //act
        //setting email to null.
        user.Email = null;

        //assert
        Assert.IsNotNull(user.Email);
    }

    [TestMethod]
    public void Email_PropertyShouldReturnEmptyStringWhenSetToNull()
    {
        //Arrange
        User user = new User();

        //Act
        user.Email = null;

        //assert
        Assert.AreEqual(string.Empty, user.Email);
    }

    [TestMethod]
    public void Email_PropertyShouldReturnAssignedValue()
    {
        //Arrange
        User user = new User();

        //Act
        string expectedEmail = "test@example.com";
        user.Email = expectedEmail;

        //Assert
        Assert.AreEqual(expectedEmail, user.Email);
    }
}