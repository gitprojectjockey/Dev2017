using System;
using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductCommand;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        
        [TestCase("12/15/2015", "1/14/2016")]
        [TestCase("2/1/2016", "3/1/2016")]
        [TestCase("3/1/2016", "3/31/2016")]
        [TestCase("4/15/2016", "4/14/2016")]
        [TestCase("6/5/2016", "7/4/2016")]
        public void if_contract_is_under_30_days_no_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase("6/5/2016", "7/6/2016")]
        [TestCase("12/5/2015", "1/6/2016")]
        [TestCase("11/15/2015", "1/14/2016")]
        [TestCase("8/3/2015", "10/2/2015")]
        [TestCase("3/6/2016", "4/6/2016")]
        public void if_contract_is_in_2nd_month_165_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(165));
        }

        [TestCase("6/5/2016", "8/6/2016")]
        [TestCase("12/5/2015", "2/6/2016")]
        [TestCase("11/15/2015", "2/14/2016")]
        [TestCase("8/3/2015", "11/2/2015")]
        [TestCase("3/6/2016", "5/6/2016")]
        public void if_contract_is_in_3rd_month_150_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(150));
        }

        [TestCase("6/5/2016", "9/6/2016")]
        [TestCase("12/5/2015", "3/6/2016")]
        [TestCase("11/15/2015", "3/14/2016")]
        [TestCase("8/3/2015", "12/2/2015")]
        [TestCase("3/6/2016", "6/6/2016")]
        public void if_contract_is_in_4th_month_135_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(135));
        }

        [TestCase("6/5/2016", "10/6/2016")]
        [TestCase("12/5/2015", "4/6/2016")]
        [TestCase("11/15/2015", "4/14/2016")]
        [TestCase("8/3/2015", "1/2/2016")]
        [TestCase("3/6/2016", "7/6/2016")]
        public void if_contract_is_in_5th_month_120_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(120));
        }

        [TestCase("6/5/2016", "11/6/2016")]
        [TestCase("12/5/2015", "5/6/2016")]
        [TestCase("11/15/2015", "5/14/2016")]
        [TestCase("8/3/2015", "2/2/2016")]
        [TestCase("3/6/2016", "8/6/2016")]
        public void if_contract_is_in_6th_month_105_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(105));
        }


        [TestCase("6/5/2016", "12/6/2016")]
        [TestCase("12/5/2015", "6/6/2016")]
        [TestCase("11/15/2015", "6/14/2016")]
        [TestCase("8/3/2015", "3/2/2016")]
        [TestCase("3/6/2016", "9/6/2016")]
        public void if_contract_is_in_7th_month_90_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(90));
        }

        [TestCase("6/5/2016", "1/6/2017")]
        [TestCase("12/5/2015", "7/6/2016")]
        [TestCase("11/15/2015", "7/14/2016")]
        [TestCase("8/3/2015", "4/2/2016")]
        [TestCase("3/6/2016", "10/6/2016")]
        public void if_contract_is_in_8th_month_75_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(75));
        }



        [TestCase("6/5/2016", "2/6/2017")]
        [TestCase("12/5/2015", "8/6/2016")]
        [TestCase("11/15/2015", "8/14/2016")]
        [TestCase("8/3/2015", "5/2/2016")]
        [TestCase("3/6/2016", "11/6/2016")]
        public void if_contract_is_in_9th_month_60_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(60));
        }

        [TestCase("6/5/2016", "3/6/2017")]
        [TestCase("12/5/2015", "9/6/2016")]
        [TestCase("11/15/2015", "9/14/2016")]
        [TestCase("8/3/2015", "6/2/2016")]
        [TestCase("3/6/2016", "12/6/2016")]
        public void if_contract_is_in_10th_month_45_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(45));
        }

        [TestCase("6/5/2016", "4/6/2017")]
        [TestCase("12/5/2015", "10/6/2016")]
        [TestCase("11/15/2015", "10/14/2016")]
        [TestCase("8/3/2015", "7/2/2016")]
        [TestCase("3/6/2016", "1/18/2017")]
        public void if_contract_is_in_11th_month_30_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(30));
        }

        [TestCase("6/5/2016", "5/6/2017")]
        [TestCase("12/5/2015", "11/6/2016")]
        [TestCase("11/15/2015", "11/14/2016")]
        [TestCase("8/3/2015", "8/2/2016")]
        [TestCase("3/6/2016", "2/18/2017")]
        public void if_contract_is_in_12th_month_15_etf_fee(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(15));
        }


        [TestCase("6/5/2016", "6/6/2017")]
        [TestCase("12/5/2015", "12/6/2016")]
        [TestCase("11/15/2015", "12/14/2016")]
        [TestCase("8/3/2015", "9/2/2016")]
        [TestCase("3/6/2016", "3/6/2017")]
        [TestCase("4/16/2016", "4/16/2017")]
        [TestCase("11/8/2016", "11/8/2017")]
        public void if_contract_is_outside_12_months_no_etf(DateTime startDate, DateTime endDate)
        {
            //act
            var customerRepository = new CustomerRepository(A.Fake<ICustomer>(), A.Fake<IProductQuery>(), A.Fake<IProductCommand>());
            var result = customerRepository.GetCustomerEtfData(startDate, endDate);

            //assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void if_get_customer_rating_throws_exception_return_0()
        {
            //setup
            var autoFakeContainer = new AutoFake();
            var customerRepository = autoFakeContainer.Resolve<CustomerRepository>();

            //arrange
            var customerRatingRequest = A.Fake<CustomerRatingRequest>();
            A.CallTo(
                () =>
                    autoFakeContainer.Resolve<IProductQuery>()
                        .GetCustomerRating(customerRatingRequest))
                        .Throws<Exception>().NumberOfTimes(3);

            //assert
            var result = customerRepository.GetCustomerRatingData(A<string>.Ignored);
            Assert.That(result,Is.EqualTo(0));
        }
    }
}