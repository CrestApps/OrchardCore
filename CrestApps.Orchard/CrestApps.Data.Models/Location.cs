using CrestApps.Data.Core.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrestApps.Data.Models
{
    public class Location : IWriteModel
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string AddressLine1 { get; set; }

        [MaxLength(255)]
        public string AddressLine2 { get; set; }

        [MaxLength(75)]
        public string AddressCity { get; set; }

        [MaxLength(50)]
        public string AddressState { get; set; }

        [MaxLength(20)]
        public string AddressZipCode { get; set; }

        [MaxLength(20)]
        public string Phone1 { get; set; }

        [MaxLength(20)]
        public string Phone2 { get; set; }

        [MaxLength(20)]
        public string Phone3 { get; set; }

        [MaxLength(20)]
        public string Fax1 { get; set; }

        [MaxLength(20)]
        public string Fax2 { get; set; }

        [MaxLength(255)]
        public string WebSite { get; set; }

        public bool IsActive { get; set; }

    }
}
