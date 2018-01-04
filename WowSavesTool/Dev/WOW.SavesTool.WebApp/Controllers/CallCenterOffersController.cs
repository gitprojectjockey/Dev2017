using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductQuery;
using WOW.SaveTool.Data.ProductCommand;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class CallCenterOffersController : Controller
    {

        private readonly IModelValidator _modelValidator;

        public CallCenterOffersController(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;
        }

        private readonly ICustomerRepository _customerRepository;
        private readonly ILogRepository _logRepository;
        private readonly HttpContextBase _httpContextBase;
        private readonly IMapper _mapper;

        public CallCenterOffersController(ICustomerRepository customerRepository, ILogRepository logRepository, HttpContextBase httpContextBase, IMapper mapper)
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
            customerModel.Rating = _customerRepository.GetCustomerRatingData(id);

            var packages = _mapper.Map<PackageInfo[], Package[]>(customer.Packages);
            var isCable = customer.Cable != null && customer.Cable.DisconnectDate == null;
            var isPhone = customer.Phone != null && customer.Phone.DisconnectDate == null;
            var isInternet = customer.Internet != null && customer.Internet.DisconnectDate == null;

            customerModel.RateIncrease = _customerRepository.GetCustomerRateIncrease(id, packages,
                customer.Account.MarketId, isCable, isPhone, isInternet);

            var offers = _customerRepository.GetOffers(packages, customerModel.Rating, Convert.ToInt32(customer.Account.MarketId),
                Convert.ToInt32(customer.Account.AccountTenure), isCable, isPhone, isInternet,
                EnumsOfferGroup.CallCenter, saveLogId);

            var goodWillOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.GoodWill);
            var proactiveOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Proactive);
            var discount1Offer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Discount1);
            var transferOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.TrasferToLoyalty);

            var callCenterOffersModel = new CallCenterOffersModel();
            callCenterOffersModel.CustomerModel = customerModel;

            callCenterOffersModel.GoodwillOffer = _mapper.Map<CallCenterOffer>(goodWillOffer);
            callCenterOffersModel.ProactiveOffer = _mapper.Map<CallCenterOffer>(proactiveOffer);
            callCenterOffersModel.Discount1Offer = _mapper.Map<CallCenterOffer>(discount1Offer);
            callCenterOffersModel.TransferToLoyalty = _mapper.Map<CallCenterOffer>(transferOffer);
            callCenterOffersModel.DisconnectAccepted = false;
            callCenterOffersModel.SavesLogId = saveLogId;

            return View(callCenterOffersModel);
        }

        [HttpPost]
        public ActionResult Index(CallCenterOffersModel offersModel, string command)
        {
            if (command == "Submit")
            {
                OfferList[] listArray = new OfferList[5];

                var goodWillOfferList = new OfferList();
                goodWillOfferList.IsOffered = offersModel.GoodwillOffer.WasOffered;
                goodWillOfferList.IsAccepted = offersModel.GoodwillOffer.WasAccepted;
                goodWillOfferList.OfferType = "GoodWill";
                listArray[0] = goodWillOfferList;

                var proactiveOfferList = new OfferList();
                proactiveOfferList.IsOffered = offersModel.ProactiveOffer.WasOffered;
                proactiveOfferList.IsAccepted = offersModel.ProactiveOffer.WasAccepted;
                proactiveOfferList.OfferType = "Proactive";
                listArray[1] = proactiveOfferList;

                var discount1OfferList = new OfferList();
                discount1OfferList.IsOffered = offersModel.Discount1Offer.WasOffered;
                discount1OfferList.IsAccepted = offersModel.Discount1Offer.WasAccepted;
                discount1OfferList.OfferType = "Discount1";
                listArray[2] = discount1OfferList;

                var transferToLoyaltyOfferList = new OfferList();
                transferToLoyaltyOfferList.IsOffered = offersModel.TransferToLoyalty.WasOffered;
                transferToLoyaltyOfferList.IsAccepted = offersModel.TransferToLoyalty.WasAccepted;
                transferToLoyaltyOfferList.OfferType = "TransferToLoyalty";
                listArray[3] = transferToLoyaltyOfferList;

                var disconnectOfferList = new OfferList();
                disconnectOfferList.IsOffered = offersModel.DisconnectAccepted;
                disconnectOfferList.IsAccepted = offersModel.DisconnectAccepted;
                disconnectOfferList.OfferType = "Disconnect";
                listArray[4] = disconnectOfferList;

                _logRepository.LogSaveOffers(listArray, offersModel.SavesLogId, null, null, null, "Save", 0, false);

                return View("Summary", offersModel);
            }

            //TODO: Log Action
            return RedirectToAction("Index", "Home");

        }
    }
}