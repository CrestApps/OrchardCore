using CrestApps.Pixulia.RealEstate.Data.Models.Enums;
using System;

namespace CrestApps.Pixulia.RealEstate.Service.Implementations
{
    public class JsonSettingProvider : ISettingProvider
    {
        public string AgentName { get; set; }

        public string AgentTitle { get; set; }

        public string AgentPicture { get; set; }

        public string SiteName { get; set; }

        public string Logo { get; set; }

        public string IntroductionTitle { get; set; }

        public string IntroductionSubTitle { get; set; }

        public int? TotalFeaturedProperties { get; set; }

        public int? TotalRecentListingProperties { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public long? OfficePhoneNumber { get; set; }

        public long? CellPhoneNumber { get; set; }

        public long? DirectPhoneNumber { get; set; }

        public long? FaxNumber { get; set; }

        public string DirectEmailAddress { get; set; }

        public string InfoEmailAddress { get; set; }

        public string BusinessName { get; set; }

        public string BrokerName { get; set; }

        public string FacebookContactLink { get; set; }

        public string SiteDescription { get; set; }

        public string SiteKeywords { get; set; }

        public string LicenseNumber { get; set; }

        public string GlobalJs { get; set; }

        public string GlobalCss { get; set; }

        public FieldDisplayType FieldDisplayType { get; set; }

        public long? PrimaryNumber { get; set; }

        public string SiteLink { get; set; }
        public string AssetsLink { get; set; }

        public string PhotosLink { get; set; }
        public string GoogleMapsKey { get; set; }

        public Uri MainUrl => new Uri(SiteLink);

        private Uri _AssetsUrl;
        public Uri AssetsUrl
        {
            get
            {
                if (_AssetsUrl == null && !string.IsNullOrWhiteSpace(AssetsLink))
                {
                    _AssetsUrl = new Uri(AssetsLink);
                }

                return _AssetsUrl;
            }
            set
            {
                _AssetsUrl = value;
            }
        }

        private Uri _PhotosUrl;

        public Uri PhotosUrl
        {
            get
            {
                if (_PhotosUrl == null && !string.IsNullOrWhiteSpace(PhotosLink))
                {
                    _PhotosUrl = new Uri(PhotosLink);
                }

                return _PhotosUrl;
            }

            set
            {
                _PhotosUrl = value;
            }
        }

        public bool HasCustomAssetsUri => AssetsUrl != null && Uri.IsWellFormedUriString(AssetsUrl.ToString(), UriKind.Absolute);
        public bool HasCustomPhotosUri => PhotosUrl != null && Uri.IsWellFormedUriString(PhotosUrl.ToString(), UriKind.Absolute);
    }
}
