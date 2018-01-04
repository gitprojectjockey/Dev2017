using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductQuery;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly HttpContextBase _httpContextBase;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, HttpContextBase httpContextBase)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _httpContextBase = httpContextBase;
        }

        // GET: Customer
        public ActionResult Index(string id)
        {
            var customer = _customerRepository.GetCustomerInformation(id, _httpContextBase.User.Identity.Name);

            if (customer == null || customer.Account == null)
            {
                return RedirectToAction("NotFound", "Customer", new { accountNumber = id });
            }
            if (customer.Account.AccountStatus.ToUpper() != "ACTIVE")
            {
                return RedirectToAction("AccountDisconnected", "Customer", new { accountNumber = id });
            }

            var model = _mapper.Map<CustomerModel>(customer);



            if (model.PackageInfoModels == null || !model.PackageInfoModels.Any())
            {
                return RedirectToAction("NoPackagesFound", "Customer", model);
            }

           

            model.Rating = _customerRepository.GetCustomerRatingData(id);

            model.SaveLogId = _customerRepository.GetSaveLogId(customer.Account.AccountNumber, _httpContextBase.User.Identity.Name);

            var packages= _mapper.Map<PackageInfo[],Package[]>(customer.Packages);


            var isCable = customer.Cable != null && customer.Cable.DisconnectDate == null;
            var isPhone = customer.Phone != null && customer.Phone.DisconnectDate == null;
            var isInternet = customer.Internet!=null && customer.Internet.DisconnectDate == null;

            model.RateIncrease = _customerRepository.GetCustomerRateIncrease(id, packages, customer.Account.MarketId,
                isCable, isPhone, isInternet);

            if (model.PackageInfoModels.Any(p => p.Type.ToUpper() == "CONTRACTPLAN"))
            {
                var packageInfoModel = model.PackageInfoModels.LastOrDefault(p => p.Type.ToUpper() == "CONTRACTPLAN");
                if (packageInfoModel == null) return View("Index", model);
                var planStartDate = packageInfoModel.StartDate;
                return RedirectToAction("Index", "Etf", new { accountIdForEtf = id, etfContractPlanStartDate = planStartDate, saveLogId = model.SaveLogId });
            }
            return View("Index", model);
        }

        public ActionResult NotFound(string accountNumber)
        {
            var message = string.Format("No Records Found for Account Number {0}", accountNumber);
            return View("AccountResults",new AccountResults { Message = message });
        }

        public ActionResult AccountDisconnected(string accountNumber)
        {
            var message = string.Format("Account {0} has been disconnected. Please confirm you have entered the account number correctly and verify services in the billing system. Please see a Supervisor if you have any questions.", accountNumber);
            return View("AccountResults", new AccountResults { Message = message });
        }

        public ActionResult NoPackagesFound(CustomerModel customerModel)
        {
            return View("NoPackageFound", customerModel);
        }

        public ActionResult LogAndRedirect()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
