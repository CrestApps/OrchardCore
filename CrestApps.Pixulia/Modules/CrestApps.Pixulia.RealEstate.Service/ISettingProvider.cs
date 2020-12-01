using CrestApps.Pixulia.RealEstate.Data.Models.Enums;
using System;

namespace CrestApps.Pixulia.RealEstate.Service
{
    public interface ISettingProvider
    {
        string AgentName { get; }
        string AgentTitle { get; }
        string AgentPicture { get; }
        string SiteName { get; }
        string Logo { get; }
        string IntroductionTitle { get; }
        string IntroductionSubTitle { get; }
        int? TotalFeaturedProperties { get; }
        int? TotalRecentListingProperties { get; }
        string Address1 { get; }
        string Address2 { get; }
        string City { get; }
        string State { get; }
        string PostalCode { get; }
        long? OfficePhoneNumber { get; }
        long? CellPhoneNumber { get; }
        long? DirectPhoneNumber { get; }
        long? FaxNumber { get; }
        string DirectEmailAddress { get; }
        string InfoEmailAddress { get; }
        string BusinessName { get; }
        string BrokerName { get; }
        string FacebookContactLink { get; }
        string SiteDescription { get; }
        string SiteKeywords { get; }
        string LicenseNumber { get; }
        string GlobalJs { get; }
        string GlobalCss { get; }
        string GoogleMapsKey { get; }

        FieldDisplayType FieldDisplayType { get; }
        long? PrimaryNumber { get; }
        Uri MainUrl { get; }
        Uri AssetsUrl { get; set; }
        Uri PhotosUrl { get; set; }
        bool HasCustomAssetsUri { get; }
        bool HasCustomPhotosUri { get; }
    }
}
