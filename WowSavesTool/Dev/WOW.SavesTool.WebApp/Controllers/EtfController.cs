using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class EtfController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly HttpContextBase _httpContextBase;
        private readonly IMapper _mapper;

        public EtfController(ICustomerRepository customerRepository, HttpContextBase httpContextBase, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _httpContextBase = httpContextBase;
            _mapper = mapper;
        }

        // GET: Etf
        public ActionResult Index(string accountIdForEtf, DateTime etfContractPlanStartDate, int saveLogId)
        {
            var customer = _customerRepository.GetCustomerInformation(accountIdForEtf,
                _httpContextBase.User.Identity.Name);

            if (customer == null || customer.Account == null || customer.Packages == null)
            {
                return RedirectToAction("NotFound", "Customer", new {accountNumber = accountIdForEtf});
            }

            var customerModel = _mapper.Map<CustomerModel>(customer);
            customerModel.Rating = _customerRepository.GetCustomerRatingData(accountIdForEtf);

            var packages = _mapper.Map<PackageInfo[], Package[]>(customer.Packages);


            var isCable = customer.Cable != null && customer.Cable.DisconnectDate == null;
            var isPhone = customer.Phone != null && customer.Phone.DisconnectDate == null;
            var isInternet = customer.Internet != null && customer.Internet.DisconnectDate == null;

            customerModel.RateIncrease = _customerRepository.GetCustomerRateIncrease(accountIdForEtf, packages, customer.Account.MarketId, isCable, isPhone, isInternet);
            customerModel.SaveLogId = saveLogId;
            return
                View(new EtfModel
                {
                    CustomerModel = customerModel,
                    EndDate = DateTime.Now,
                    EtfAmount = 0,
                    StartDate = etfContractPlanStartDate
                });
        }

        public ActionResult EtfDateSelection()
        {
            return PartialView("EtfDateSelection");
        }

        public ActionResult EtfData(DateTime startDate, DateTime endDate)
        {
            var etfDollarValue = _customerRepository.GetCustomerEtfData(startDate, endDate);
            return PartialView("EtfData", new EtfModel {EndDate = endDate, EtfAmount = etfDollarValue});
        }
    }
}
