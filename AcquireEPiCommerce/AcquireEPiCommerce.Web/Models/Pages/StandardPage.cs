using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AcquireEPiCommerce.Web.Models.Pages
{
    [ContentType(
        DisplayName = "Standard Page", 
        GUID = "ec7090c1-8aa2-40b6-ae70-56df762ac0c4", 
        Description = "")]
    [ImageUrl("~/Content/Icons/IconStandardPage.png")]
    public class StandardPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "The heading of the page, there you can insert text of heading, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 0)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content area",
            Description = "The content area of the page, using to place inside the blocks of page.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentArea ContentArea { get; set; }


    }
}