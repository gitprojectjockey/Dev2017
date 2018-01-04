using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using WOW.SavesTool.WebApp.Automapper;
using WOW.SavesTool.WebApp.Controllers;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;

namespace WOW.SavesTool.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [SetUp]
        public void Setup()
        {
            var mapper = new AutoMapperConfig().RegisterMappings().CreateMapper();
            _autoFakeContainer = new AutoFake();

            _sut = new CustomerController(_autoFakeContainer.Resolve<ICustomerRepository>(), mapper,
                _autoFakeContainer.Resolve<HttpContextBase>());
        }

        private CustomerController _sut;
        private AutoFake _autoFakeContainer;

        [Test]
        public void if_packages_are_empty_show_no_packages_found()
        {
            //arrange
            var noPackageResponse = new CustomerDetailsResponse
            {
               Account = new AccountInfo
               {
                   AccountStatus = "ACTIVE"
               },
                ServiceAddress =  new ServiceAddressInfo(),
                Packages = new PackageInfo[0]
            };

            //act
            A.CallTo(
                () =>
                    _autoFakeContainer.Resolve<ICustomerRepository>()
                        .GetCustomerInformation(A<string>.Ignored, A<string>.Ignored)).Returns(noPackageResponse);

            var result = _sut.Index("11970203") as RedirectToRouteResult;

            //assert
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Customer"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("NoPackagesFound"));
        }

        [Test]
        public void if_packages_are_null_show_no_packages_found_error()
        {
            //arrange
            var noPackageResponse = new CustomerDetailsResponse
            {
                Account = new AccountInfo
                {
                    AccountStatus = "ACTIVE"
                },
                ServiceAddress = new ServiceAddressInfo(),
                Packages = null
            };

            //act
            A.CallTo(
                () =>
                    _autoFakeContainer.Resolve<ICustomerRepository>()
                        .GetCustomerInformation(A<string>.Ignored, A<string>.Ignored)).Returns(noPackageResponse);

            var result = _sut.Index("11970203") as RedirectToRouteResult;

            //assert
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Customer"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("NoPackagesFound"));
        }



        [Test]
        public void NotFound_action_should_display_error()
        {
            //arrange

            //act
            var result = _sut.NotFound("12345") as ViewResult;

            var model = result.Model as AccountResults;

            //assert
            Assert.That(model.Message, Is.EqualTo("No Records Found for Account Number 12345"));
        }

        [Test]
        public void when_user_searches_for_a_account_and_a_account_is_null_redirect_to_NoRecordsFound()
        {
            //arrange
            A.CallTo(
                () =>
                    _autoFakeContainer.Resolve<ICustomerRepository>()
                        .GetCustomerInformation(A<string>.Ignored, A<string>.Ignored))
                .Returns(new CustomerDetailsResponse());

            //act
            var result = _sut.Index("12345") as RedirectToRouteResult;

            //assert
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Customer"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("NotFound"));
        }

        [Test]
        public void when_user_searches_for_a_account_and_a_response_is_null_redirect_to_NoRecordsFound()
        {
            //arrange
            A.CallTo(
                () =>
                    _autoFakeContainer.Resolve<ICustomerRepository>()
                        .GetCustomerInformation(A<string>.Ignored, A<string>.Ignored)).Returns(null);

            //act
            var result = _sut.Index("12345") as RedirectToRouteResult;

            //assert
            Assert.That(result.RouteValues["controller"], Is.EqualTo("Customer"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("NotFound"));
        }

        [Test]
        public void when_user_searches_for_a_account_and_its_found_return_index_view()
        {
            //arrange
            A.CallTo(
                () =>
                    _autoFakeContainer.Resolve<ICustomerRepository>()
                        .GetCustomerInformation(A<string>.Ignored, A<string>.Ignored))
                .Returns(new CustomerDetailsResponse
                {
                    Account = new AccountInfo()
                    {
                        AccountStatus =  "Active"
                    },
                    ServiceAddress = new ServiceAddressInfo(),
                    Packages =
                        new PackageInfo[1]
                        {new PackageInfo {Type = "Contract", StartDate = DateTime.Now.AddDays(-1).ToString()}}
                });

            //act
            var result = _sut.Index("11970203") as ViewResult;

            //assert
            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void when_user_searches_for_a_account_CustomerDetailsByAccountNumber_should_be_called()
        {
            //arrange
            A.CallTo(() => _autoFakeContainer.Resolve<HttpContextBase>().User)
                .Returns(new GenericPrincipal(new GenericIdentity("some user"), null));

            //act
            _sut.Index("12345");

            //assert
            A.CallTo(
                () => _autoFakeContainer.Resolve<ICustomerRepository>().GetCustomerInformation("12345", "some user"))
                .MustHaveHappened();
        }
    }
}