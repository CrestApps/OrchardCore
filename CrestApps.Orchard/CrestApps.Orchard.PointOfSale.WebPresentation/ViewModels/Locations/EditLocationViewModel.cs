using System;
using System.ComponentModel.DataAnnotations;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations
{
    public class EditLocationViewModel : CreateLocationViewModel
    {
        [Required]
        public Guid? Id { get; set; }

        public bool IsActive { get; set; }
    }
}
