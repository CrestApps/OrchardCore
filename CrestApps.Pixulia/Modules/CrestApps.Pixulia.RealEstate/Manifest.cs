using OrchardCore.Modules.Manifest;

[assembly: Module(
    // Name of the module to be displayed on the Modules page of the Dashboard.
    Name = "RealEstate",
    // Your name, company or any name that identifies the developers working on the project.
    Author = "CrestApps",
    // Optionally you can add a website URL (e.g. your company's website, GitHub repository URL).
    Website = "https://crestapps.com",
    // Version of the module.
    Version = "1.0.0",
    // Short description of the module. It will be displayed on the Dashboard.
    Description = "Real Estate service",
    // Modules are categorized on the Dashboard so it's a good idea to put similar modules together into a separate
    // section.
    Category = "RealEstate",
    // Modules can have dependencies which are other module names (name of the project) or if these modules have
    // subfeatures then the name of the feature. If you use any service, taghelper etc. coming from an Orchard Core
    // feature then you need to include them in this list. Orchard Core will make sure to enable all dependent modules
    // when you enable a module that has dependencies. Without this some features would not work even if the assembly
    // is referenced in the project.
    Dependencies = new string[] { }
)]

// END OF TRAINING SECTION: Manifest
// NEXT STATION: Controllers/YourFirstOrchardCoreController.cs