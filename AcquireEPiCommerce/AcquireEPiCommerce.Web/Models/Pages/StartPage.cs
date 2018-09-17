using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AcquireEPiCommerce.Web.Models.Pages
{
    [ContentType(
        DisplayName = "Start Page", 
        GUID = "8b66f09a-7035-469b-9738-d3067e67db76", 
        Description = "The main root page pattern.")]
    [ImageUrl("~/Content/Icons/IconStartPage.png")]
    public class StartPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The page is used as the main container under which will be placed all other pages.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}