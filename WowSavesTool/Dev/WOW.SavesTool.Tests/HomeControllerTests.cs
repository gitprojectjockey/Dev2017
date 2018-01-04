using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FakeItEasy;
using NUnit.Framework;
using WOW.SavesTool.WebApp.Controllers;
using WOW.SavesTool.WebApp.Models;

namespace WOW.SavesTool.Tests
{
    [TestFixture]
  public  class HomeControllerTests
    {

        [Test]
        public void when_user_searches_for_a_account_CustomerDetailsByAccountNumber_should_be_called()
        {
            //arrange
            var modelValidator = A.Fake<IModelValidator>();
            var sut = new HomeController(modelValidator);
            A.CallTo(() => modelValidator.IsValid(A<ModelStateDictionary>.Ignored)).Returns(true);
            //act
            var result = sut.Index(new HomeModel { AccountNumber = "1234" }) as RedirectToRouteResult;

            //assert
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Customer"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        [Test]
        public void when_user_searches_with_an_empty_string_return_error()
        {
            //arrange
            var modelValidator = A.Fake<IModelValidator>();
            var sut = new HomeController(modelValidator);
            A.CallTo(() => modelValidator.IsValid(A<ModelStateDictionary>.Ignored)).Returns(false);

            //act
            var result = sut.Index(new HomeModel { AccountNumber = null }) as ViewResult;

            //assert
            Assert.That(result.ViewName, Is.EqualTo("Index"));


        }
    }
}
