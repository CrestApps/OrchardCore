using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels
{
    public class ListContentsViewModel
    {
        public ListContentsViewModel()
        {
            Options = new ContentOptions();
        }

        public int? Page { get; set; }

        [BindNever]
        public IEnumerable<dynamic> ContentItems { get; set; }

        [BindNever]
        public dynamic Pager { get; set; }

        public ContentOptions Options { get; set; }
    }

}
