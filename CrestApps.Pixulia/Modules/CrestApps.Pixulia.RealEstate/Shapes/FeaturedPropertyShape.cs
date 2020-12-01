using CrestApps.Core.Support;
using OrchardCore.DisplayManagement.Shapes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrestApps.Pixulia.RealEstate.Shapes
{
    public class FeaturedPropertyShape : Shape
    {
        public int KeyId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
        public string PostalCode { get; set; }
        public string FormattedAddressLine { get; set; }
        public string FormattedAddress { get; set; }

        public virtual string FormattedState()
        {
            if (!string.IsNullOrWhiteSpace(StateName) && StateName.Length == 2)
            {
                return StateName.ToUpper();
            }

            return Str.TitleCase(StateName);
        }
        public virtual string FormattedCity()
        {
            return Str.TitleCase(CityName);
        }
        public virtual string AddressAsTitle()
        {
            string address = string.Format("{0}, {1}, {2} {3}", GetAddressLine(), FormattedCity(), FormattedState(), PostalCode);

            return address;
        }

        public virtual string GetFormattedAddress()
        {
            if (string.IsNullOrWhiteSpace(FormattedAddress))
            {
                var state = StateAbbreviation?.ToUpper();

                if (string.IsNullOrWhiteSpace(state))
                {
                    state = FormattedState();
                }

                string address = string.Format("{0}, {1}, {2} {3}", GetAddressLine(), FormattedCity(), state, PostalCode);

                FormattedAddress = Str.RemoveDuplicate(address, "  ", " ").Trim();
            }

            return FormattedAddress;
        }

        public virtual string GetAddressLine()
        {
            if (string.IsNullOrWhiteSpace(FormattedAddressLine))
            {
                var address = string.Format("{0} {1}", StreetNumber, Str.TitleCase(Str.AppendOnce(StreetName, " " + StreetSuffix)));

                FormattedAddressLine = Str.RemoveDuplicate(address, "  ", " ").Trim();
            }

            return FormattedAddressLine;
        }

        public virtual string Slug()
        {
            string address = string.Format("{0}, {1}, {2} {3}", GetAddressLine(), FormattedCity(), StateAbbreviation, PostalCode);

            return Str.RemoveDuplicate(address, "  ", " ").Trim();
        }

        public int IntegrationId { get; set; }
        public long MatrixId { get; set; }
        public bool HasPhotos { get; set; }


        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Bathrooms { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Bedrooms { get; set; }

        public bool IsHouse { get; set; }
        public bool IsRental { get; set; }
        public bool HasPool { get; set; }
        public bool HasSpa { get; set; }
        public bool HasFireplace { get; set; }


        [DisplayName("Built in"), DisplayFormat(DataFormatString = "{0:N0}")]
        public int? YearBuilt { get; set; }

        //[SquareFeetDisplayer, DisplayName("Lot Size"), DisplayFormat(DataFormatString = "{0:N2}"), DataType("SquareFeet")]
        public decimal? LotSize { get; set; }

        [DisplayName("SqFt"), DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? AreaSize { get; set; }


        private decimal? _PricePerSquareFoot;

        [DisplayName("Price/SqfFt"), DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? PricePerSquareFoot
        {
            get
            {
                if (!_PricePerSquareFoot.HasValue && Price.HasValue && AreaSize.HasValue && AreaSize.Value > 0)
                {
                    _PricePerSquareFoot = Math.Floor(Price.Value / AreaSize.Value);
                }

                return _PricePerSquareFoot;
            }
        }
        public string MlsId { get; set; }
        public string TypeName { get; set; }
        public string TypeTagName { get; set; }
        //public IList<RealEstatePropertyListButtonViewModel> ActionButtons { get; set; }
    }
}
