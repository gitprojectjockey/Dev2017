using System;
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
    public class FrontCounterOffersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogRepository _logRepository;
        private readonly HttpContextBase _httpContextBase;
        private readonly IMapper _mapper;

        public FrontCounterOffersController(ICustomerRepository customerRepository, ILogRepository logRepository, HttpContextBase httpContextBase, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logRepository = logRepository;
            _httpContextBase = httpContextBase;
            _mapper = mapper;
        }

        // GET: CallCenterOffer
        public ActionResult Index(string id, int saveLogId)
        {
            var customer = _customerRepository.GetCustomerInformation(id, _httpContextBase.User.Identity.Name);

            if (customer == null || customer.Account == null || customer.Packages == null)
            {
                return RedirectToAction("NotFound", "Customer", new { accountNumber = id });
            }

            var customerModel = _mapper.Map<CustomerModel>(customer);
            var rating = _customerRepository.GetCustomerRatingData(id);
            customerModel.Rating = rating;
            
            var packages= _mapper.Map<PackageInfo[],Package[]>(customer.Packages);


            var isCable = customer.Cable != null && customer.Cable.DisconnectDate == null;
            var isPhone = customer.Phone != null && customer.Phone.DisconnectDate == null;
            var isInternet = customer.Internet!=null && customer.Internet.DisconnectDate == null;

            customerModel.RateIncrease = _customerRepository.GetCustomerRateIncrease(id, packages, customer.Account.MarketId,
                isCable, isPhone, isInternet);

            var offers = _customerRepository.GetOffers(packages, rating, Convert.ToInt32(customer.Account.MarketId),
               Convert.ToInt32(customer.Account.AccountTenure), isCable, isPhone, isInternet,
               EnumsOfferGroup.FrontCounter,saveLogId);

            var goodWillOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.GoodWill);
            var proactiveOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Proactive);
            var discount1Offer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Discount1);
            var loyalty1Offer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Loyalty1);
            var transferOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.TrasferToLoyalty);

            var frontCounterOffersModel = new FrontCounterOffersModel();
            frontCounterOffersModel.CustomerModel = customerModel;
            frontCounterOffersModel.GoodwillOffer = _mapper.Map<FrontCounterOffer>(goodWillOffer);
            frontCounterOffersModel.ProactiveOffer = _mapper.Map<FrontCounterOffer>(proactiveOffer);
            frontCounterOffersModel.Discount1Offer = _mapper.Map<FrontCounterOffer>(discount1Offer);
            frontCounterOffersModel.Loyalty1Offer= _mapper.Map<FrontCounterOffer>(loyalty1Offer);
            frontCounterOffersModel.TransferToLoyalty = _mapper.Map<FrontCounterOffer>(transferOffer);
            frontCounterOffersModel.SavesLogId = saveLogId;

            return View(frontCounterOffersModel);
        }

        [HttpPost]
        public ActionResult Index(FrontCounterOffersModel offersModel, string command)
        {
            if (command == "Submit")
            {
                //TODO: Log the saves offers   
                //_logRepository.LogSaveOffers(); 
                return View("Summary", offersModel);
            }
           
            //TODO: Log cancel action
            return RedirectToAction("Index", "Home");
        }
    }
}