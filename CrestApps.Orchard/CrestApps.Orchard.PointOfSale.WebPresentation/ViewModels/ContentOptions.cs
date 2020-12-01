﻿namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels
{
    public class ContentOptions
    {
        public ContentOptions()
        {
            OrderBy = ContentsOrder.Modified;
            //BulkAction = ViewModels.ContentsBulkAction.None;
            //ContentsStatus = ContentsStatus.Latest;
        }

        //public string DisplayText { get; set; }

        //public string SelectedContentType { get; set; }

        //public bool CanCreateSelectedContentType { get; set; }

        public ContentsOrder OrderBy { get; set; }

        //public ContentsStatus ContentsStatus { get; set; }

        //public ContentsBulkAction BulkAction { get; set; }

        //#region Lists to populate

        //[BindNever]
        //public List<SelectListItem> Cultures { get; set; }

        //[BindNever]
        //public List<SelectListItem> ContentStatuses { get; set; }

        //[BindNever]
        //public List<SelectListItem> ContentSorts { get; set; }

        //[BindNever]
        //public List<SelectListItem> ContentsBulkAction { get; set; }

        //[BindNever]
        //public List<SelectListItem> ContentTypeOptions { get; set; }

        //[BindNever]
        //public List<SelectListItem> CreatableTypes { get; set; }

        //[BindNever]
        //public List<SelectListItem> Users { get; set; }

        //#endregion Lists to populate
    }


    public enum ContentsOrder
    {
        Modified,
        Published,
        Created,
        Title,
    }

    public enum ContentsStatus
    {
        Draft,
        Published,
        AllVersions,
        Latest,
        Owner
    }

    public enum ContentsBulkAction
    {
        None,
        PublishNow,
        Unpublish,
        Remove
    }
}
