using System;
using System.Globalization;
using NUnit.Framework;
using WOW.SavesTool.WebApp.Automapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data.Customer;

namespace WOW.SavesTool.Tests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void should_map_a_customer_with_no_packages()
        {
            //arrange
            var sut = new AutoMapperConfig().RegisterMappings().CreateMapper();

            //act
            var model =
                sut.Map<CustomerModel>(new CustomerDetailsResponse
                {
                    Account = new AccountInfo(),
                    ServiceAddress = new ServiceAddressInfo()
                });

            //assert
            Assert.That(model, Is.Not.Null);
        }

        [Test]
        public void should_return_empty_packages_when_there_are_only_future_dated_packages()
        {
            //arrange
            var sut =new AutoMapperConfig().RegisterMappings().CreateMapper();

            //act
            var model = sut.Map<CustomerModel>(new CustomerDetailsResponse
            {
                Account = new AccountInfo(),
                ServiceAddress = new ServiceAddressInfo(),
                Packages = new[]
                {
                    new PackageInfo {StartDate = DateTime.Now.AddDays(1).ToString(CultureInfo.InvariantCulture)}
                }
            });

            //assert
            Assert.That(model.PackageInfoModels, Is.Empty);
        }

        [Test]
        public void should_return_1_package_when_packages_have_one_current_and_one_future_dated()
        {
            //arrange
            var sut =new AutoMapperConfig().RegisterMappings().CreateMapper();

            //act
            var model = sut.Map<CustomerModel>(new CustomerDetailsResponse
            {
                Account = new AccountInfo(),
                ServiceAddress = new ServiceAddressInfo(),
                Packages = new[]
                {
                    new PackageInfo {StartDate = DateTime.Now.AddDays(1).ToString(CultureInfo.InvariantCulture)},
                    new PackageInfo {StartDate = DateTime.Now.AddDays(-1).ToString(CultureInfo.InvariantCulture)}
                }
            });

            //assert
            Assert.That(model.PackageInfoModels.Count, Is.EqualTo(1));
        }
    }
}