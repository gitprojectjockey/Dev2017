using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductQuery;
using System.Configuration;
using System.Collections.Generic;
using WebGrease.Css.Extensions;
using WOW.SaveTool.Data.ProductCommand;

namespace WOW.SavesTool.WebApp.Controllers
{
    public class LoyaltyOffersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogRepository _logRepository;
        private readonly HttpContextBase _httpContextBase;
        private readonly IMapper _mapper;

        public LoyaltyOffersController(ICustomerRepository customerRepository, ILogRepository logRepository, HttpContextBase httpContextBase, IMapper mapper)
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
                EnumsOfferGroup.Loyalty, saveLogId);


            var loyalty1Offer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Loyalty1);
            var loyalty2Offer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Loyalty2);
            var contractOffer = offers.FirstOrDefault(o => o.DiscountType == EnumsDiscountType.Contract);

            var loyaltyOffersModel = new LoyaltyOffersModel();
            loyaltyOffersModel.CustomerModel = customerModel;
            loyaltyOffersModel.Loyalty1Offer = _mapper.Map<LoyaltyOffer>(loyalty1Offer);
            loyaltyOffersModel.Loyalty2Offer = _mapper.Map<LoyaltyOffer>(loyalty2Offer);
            loyaltyOffersModel.ContractOffer = _mapper.Map<LoyaltyOffer>(contractOffer);

            loyaltyOffersModel.LoyaltyHsdSpeeds = GetHsdList();
            loyaltyOffersModel.LoyaltyCableSizes = GetCableList();
            loyaltyOffersModel.LoyaltyPhoneOptions = GetPhoneList();
            loyaltyOffersModel.FiveYearDiscountAmts = GetFiveYearDiscountList();
            loyaltyOffersModel.SavesLogId = saveLogId;

            return View(loyaltyOffersModel);
        }

        [HttpPost]
        public ActionResult Index(LoyaltyOffersModel offersModel, string command)
        {
            if (command == "Submit")
            {
                OfferList[] listArray = new OfferList[3];

                var loyalty1OfferList = new OfferList();
                loyalty1OfferList.IsOffered = offersModel.Loyalty1Offer.WasOffered;
                loyalty1OfferList.IsAccepted = offersModel.Loyalty1Offer.WasAccepted;
                loyalty1OfferList.OfferType = "Loyalty1";
                listArray[0] = loyalty1OfferList;

                var loyalty2OfferList = new OfferList();
                loyalty2OfferList.IsOffered = offersModel.Loyalty2Offer.WasOffered;
                loyalty2OfferList.IsAccepted = offersModel.Loyalty2Offer.WasAccepted;
                loyalty2OfferList.OfferType = "Loyalty2";
                listArray[1] = loyalty2OfferList;

                var contractOfferList = new OfferList();
                contractOfferList.IsOffered = offersModel.ContractOffer.WasOffered;
                contractOfferList.IsAccepted = offersModel.ContractOffer.WasAccepted;
                contractOfferList.OfferType = "Contract";
                listArray[2] = contractOfferList;


                decimal fiveYearDiscountAmt = 0;
                if (offersModel.ContractOffer.WasAccepted)
                {
                    string selectedDiscountAmt = offersModel.SelectedFiveYearDiscountAmt.Remove(0, 1).Trim();
                    decimal returnValue = 0;
                    fiveYearDiscountAmt = decimal.TryParse(selectedDiscountAmt, out returnValue)
                        ? Convert.ToDecimal(selectedDiscountAmt)
                        : 0;
                }

                _logRepository.LogSaveOffers(listArray, offersModel.SavesLogId, offersModel.SelectedHsd,offersModel.SelectedPhone,offersModel.SelectedCable, "Save",fiveYearDiscountAmt, offersModel.TwelveMonthContract.WasAccepted);

                return View("Summary", offersModel);
            }

            //TODO: Log Action
            return RedirectToAction("Index", "Home");
        }

        private List<SelectListItem> GetHsdList()
        {
            var seperator = new char[] { ',' };
            var hsdSpeeds = ConfigurationManager.AppSettings["LoyaltyOnly.Hsd"].Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            var speeds = new List<SelectListItem>();
            var defaultValue = new SelectListItem() { Text = "Select HSD Speed", Value = "-99", Selected = true };
            speeds.Add(defaultValue);

            //var id = 0;
            speeds.AddRange(hsdSpeeds.Select(s => new SelectListItem { Text = s, Value = s.Trim() }));
            return speeds;
        }

        private List<SelectListItem> GetCableList()
        {
            var seperator = new char[] { ',' };
            var cableSizes = ConfigurationManager.AppSettings["LoyaltyOnly.Cable"].Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            var sizes = new List<SelectListItem>();
            var defaultValue = new SelectListItem() { Text = "Select Cable Size", Value = "-99", Selected = true };
            sizes.Add(defaultValue);

            //var id = 0;
            sizes.AddRange(cableSizes.Select(s => new SelectListItem { Text = s, Value = s.Trim() }));
            return sizes;
        }

        private List<SelectListItem> GetPhoneList()
        {
            var seperator = new char[] { ',' };
            var phoneOptions = ConfigurationManager.AppSettings["LoyaltyOnly.Phone"].Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            var options = new List<SelectListItem>();
            var defaultValue = new SelectListItem() { Text = "Select Phone Option", Value = "-99", Selected = true };
            options.Add(defaultValue);

            //var id = 0;
            options.AddRange(phoneOptions.Select(s => new SelectListItem { Text = s, Value = s.Trim() }));
            return options;
        }

        private List<SelectListItem> GetFiveYearDiscountList()
        {
            var seperator = new char[] { ',' };
            var discountAmts = ConfigurationManager.AppSettings["LoyaltyOnly.FiveYearDiscountAmts"].Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            var amts = new List<SelectListItem>();
            var defaultValue = new SelectListItem() { Text = "Select Amount", Value = "-99", Selected = true };
            amts.Add(defaultValue);

            //var id = 0;
            amts.AddRange(discountAmts.Select(s => new SelectListItem { Text = s, Value = s.Trim() }));
            return amts;
        }
    }
}