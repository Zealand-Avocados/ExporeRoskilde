#pragma checksum "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "343fc2d1dab4b5928959e095db7034e575d69e6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ExploreRoskilde.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace ExploreRoskilde.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\_ViewImports.cshtml"
using ExploreRoskilde;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml"
using ExploreRoskilde.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"343fc2d1dab4b5928959e095db7034e575d69e6c", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9ddf1b88738d2c4b4656546f3aa366dee6c4644", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n\r\n\r\n\r\n\r\n\r\n\r\n    \r\n");
#nullable restore
#line 18 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml"
     foreach (Place place in Model.AllPlaces.Values)
     {

#line default
#line hidden
#nullable disable
            WriteLiteral("         <h1>");
#nullable restore
#line 20 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml"
        Write(place.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 21 "C:\Users\malsh\Source\Repos\ExporeRoskilde\ExploreRoskilde\Pages\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
