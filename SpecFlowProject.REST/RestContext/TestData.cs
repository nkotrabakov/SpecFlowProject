using SpecFlowProject.Common.Helpers;
using SpecFlowProject.REST.Models;

namespace SpecFlowProject.REST.RestContext
{
    internal class TestData
    {
        public static User GetNewUser() => new User
        {
            Title = "Mr.",
            FirstName = "Test",
            SirName = "Test",
            City = "Test",
            Country = "Test",
            Email = Helper.GetRandomEmail(),
            Password = "pass123",
            IsAdmin = 0
        };
    }
}
