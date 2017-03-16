using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OnlineShoppingService.Controllers;

namespace OnlineShoppingService.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Test_Get_Users_NotNull_CountGreaterThenZero()
        {
            //Moq.Mock<Domain.Abstract.IUserRepository> mock = new Moq.Mock<Domain.Abstract.IUserRepository>();
            //mock.Setup(u => u.Users).Returns(new List<Domain.Entities.User>
            //{
            //    new Domain.Entities.User {Id = 1, Name="Son of Sam",Password="Password123",Email="me@comcast.net"},
            //    new Domain.Entities.User {Id = 2, Name="Napoleon Dynamite",Password="Password456",Email="nd@comcast.net"},
            //    new Domain.Entities.User {Id = 3, Name="Dr Evil",Password="Password789",Email="de@comcast.net"}
            //});
            //UsersController controller = new UsersController(mock.Object);
            //controller.Request = new HttpRequestMessage();
            //controller.Configuration = new HttpConfiguration();
            //HttpResponseMessage response = controller.Get();
            //List<Domain.Entities.User> users;
            //Assert.IsTrue(response.TryGetContentValue(out users));
            //Assert.IsNotNull(users);
            //Assert.IsTrue(users.Count > 0);
        }
    }

}
