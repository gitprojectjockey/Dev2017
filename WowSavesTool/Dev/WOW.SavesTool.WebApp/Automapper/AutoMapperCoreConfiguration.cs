using System;
using System.Linq;
using AutoMapper;
using WOW.SavesTool.WebApp.Models;
using WOW.SaveTool.Data.Customer;
using WOW.SaveTool.Data.ProductQuery;
using WOW.Sugar.AutomapperCustomization.CustomResolvers;

namespace WOW.SavesTool.WebApp.Automapper
{
    public class AutoMapperCoreConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<PackageInfo, PackageInfoModel>();
            CreateMap<PackageInfo, Package>();

            CreateMap<Offers, FrontCounterOffer>()
                .ForMember(dest => dest.WasOffered, opts => opts.UseValue(false))
                .ForMember(dest => dest.WasAccepted, opts => opts.UseValue(false));

            CreateMap<Offers, CallCenterOffer>()
                .ForMember(dest => dest.WasOffered, opts => opts.UseValue(false))
                .ForMember(dest => dest.WasAccepted, opts => opts.UseValue(false));

            CreateMap<Offers, LoyaltyOffer>()
                .ForMember(dest => dest.WasOffered, opts => opts.UseValue(false))
                .ForMember(dest => dest.WasAccepted, opts => opts.UseValue(false));

            CreateMap<CustomerDetailsResponse, CustomerModel>()
                .ForMember(dest => dest.AccountNumber,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.AccountNumber))
                .ForMember(dest => dest.EveningPhoneNumber,
                    opts => opts.ResolveUsing<PhoneNumberResolver>().FromMember(src => src.Account.EveningPhoneNumber))
                .ForMember(dest => dest.DayTimePhoneNumber,
                    opts => opts.ResolveUsing<PhoneNumberResolver>().FromMember(src => src.Account.DaytimePhoneNumber))
                .ForMember(dest => dest.BillingSystem, opts => opts.MapFrom(src => src.BillingSystem))
                .ForMember(dest => dest.AccountStatus,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.AccountStatus))
                .ForMember(dest => dest.ContactEmail,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.ContactEmail))
                .ForMember(dest => dest.FirstName,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.FirstName))
                .ForMember(dest => dest.LastName,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.LastName))
                .ForMember(dest => dest.CustomerName,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.Account.AccountName))
                .ForMember(dest => dest.CurrentBalance, opts => opts.MapFrom(src => src.Billing.CurrentBalance))
                .ForMember(dest => dest.LastStatementAmount,
                    opts => opts.MapFrom(src => src.Billing.LastStatementAmount))
                .ForMember(dest => dest.LastStatementDate, opts => opts.MapFrom(src => src.Billing.LastStatementDate))
                .ForMember(dest => dest.PastDue, opts => opts.MapFrom(src => src.Billing.PastDueAmount))
                .ForMember(dest => dest.DelinquencyDays, opts => opts.MapFrom(src => src.Billing.PastDueDays))
                .ForMember(dest => dest.TotalDue, opts => opts.MapFrom(src => src.Billing.CurrentBalance))
                .ForMember(dest => dest.DueDate, opts => opts.MapFrom(src => src.Billing.LastDayToPay))
                .ForMember(dest => dest.LastPaymentDate, opts => opts.MapFrom(src => src.Billing.LastPaymentDate))
                .ForMember(dest => dest.LastPaymentAmount, opts => opts.MapFrom(src => src.Billing.LastPaymentAmount))
                .ForMember(dest => dest.PendingAmount, opts => opts.MapFrom(src => src.Billing.PendingPayment))
                .ForMember(dest => dest.AutoPay, opts => opts.MapFrom(src => src.Billing.AutoPay))
                .ForMember(dest => dest.AddressLine1,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.ServiceAddress.StreetAddress))
                .ForMember(dest => dest.AddressLine2,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.ServiceAddress.ApartmentNo))
                .ForMember(dest => dest.Postalcode, opts => opts.MapFrom(src => src.ServiceAddress.Zip))
                .ForMember(dest => dest.City,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.ServiceAddress.City))
                .ForMember(dest => dest.State,
                    opts => opts.ResolveUsing<StringResolver>().FromMember(src => src.ServiceAddress.State))
                .ForMember(dest => dest.CountryCode, opts => opts.UseValue("US"))
                .ForMember(dest => dest.PackageInfoModels,
                    opts =>
                        opts.MapFrom(src => src.Packages == null ? null: src.Packages.Where(o => Convert.ToDateTime(o.StartDate) <= DateTime.Today)))
                .ForMember(dest => dest.Rating, opts => opts.Ignore())
                .ForMember(dest => dest.RateIncrease, opts => opts.Ignore())
                .ForMember(dest=> dest.SaveLogId, opts=> opts.Ignore());

        }
    }
}