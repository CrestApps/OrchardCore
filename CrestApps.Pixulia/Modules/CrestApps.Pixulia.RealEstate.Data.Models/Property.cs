using CrestApps.Core.Data.Abstraction;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrestApps.Pixulia.RealEstate.Data.Models
{
    [Table("realestate_properties")]
    public class Property : IWriteModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public decimal? Bathrooms { get; set; }
        public decimal? Bedrooms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public DateTime? ListedAt { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string MlsId { get; set; }
        public bool IsFeatured { get; set; }
        public long MatrixId { get; set; }
        public int? IntegrationId { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public int? TypeId { get; set; }
        public int? SubTypeId { get; set; }
        public int? StatusId { get; set; }
        public int? CityId { get; set; }
        public int? PostalCodeId { get; set; }
        public int? CountyId { get; set; }
        public int? CommunityId { get; set; }

        public int? YearBuilt { get; set; }
        public decimal? AreaSize { get; set; }
        public decimal? LotSize { get; set; }

        public bool HasPool { get; set; }
        public bool HasSpa { get; set; }
        public bool HasFireplace { get; set; }
        public string FormattedAddressLine { get; set; }
        public string FormattedAddress { get; set; }

        public int? TotalPhotos { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? ForwardToId { get; set; }

        public bool? IsUnableToFindCoordinates { get; set; }


        public virtual Property ForwardTo { get; set; }

        /*
        public virtual PropertyStatus Status { get; set; }

        public virtual PropertyType Type { get; set; }

        public virtual PropertySubtype SubType { get; set; }

        [ForeignKey(nameof(PostalCodeId))]
        public virtual PostalCode ZipCode { get; set; }

        public virtual Community Community { get; set; }

        public virtual City City { get; set; }

        public virtual County County { get; set; }

        public virtual ICollection<PropertyExternalPost> PropertyExternalPosts { get; set; }
        public virtual ICollection<PropertyToList> PropertyToLists { get; set; }

        public virtual ICollection<PropertyToTextField> PropertyToTextFields { get; set; }
        public virtual ICollection<PropertyToLookupField> PropertyToLookupFields { get; set; }
        public virtual ICollection<PropertyToTimeField> PropertyToTimeFields { get; set; }
        public virtual ICollection<PropertyToBooleanField> PropertyToBooleanFields { get; set; }
        public virtual ICollection<PropertyToNumericField> PropertyToNumericFields { get; set; }

        public virtual ICollection<PropertyImage> Images { get; set; }

        public virtual PropertyPostalCodePriority PostalCodePriority { get; set; }
        */
        public Property()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public bool HasPictures()
        {
            return TotalPhotos.HasValue && TotalPhotos > 0;
        }
    }
}
