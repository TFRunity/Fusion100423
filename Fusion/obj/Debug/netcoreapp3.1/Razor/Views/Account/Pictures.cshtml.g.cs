#pragma checksum "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Account\Pictures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "071428613f000401a926d3bdf36233c29834be1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Pictures), @"mvc.1.0.view", @"/Views/Account/Pictures.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Fusion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Fusion.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Fusion.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Fusion.DatabaseMethods;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Fusion.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"071428613f000401a926d3bdf36233c29834be1b", @"/Views/Account/Pictures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0066fb481a1991747b5617bf1e4514840a0627a", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Pictures : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserAtSite>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Account\Pictures.cshtml"
  
    bool authentificated = User.Identity.IsAuthenticated;
    if (authentificated == true)
    {
        OrderNavbarViewModel viewModel = new OrderNavbarViewModel() { Authentificated = true, OrderId = Model.OrderId, Email = Model.Email };
        if (ViewBag.Created == false)
        {
            viewModel.Created = false;
        }
        else
        {
            viewModel.Created = true;
        }
        await Html.RenderPartialAsync("_Navbar", viewModel);
    }
    else
    {
        OrderNavbarViewModel viewModel = new OrderNavbarViewModel() { Authentificated = false };
        await Html.RenderPartialAsync("_Navbar", viewModel);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex flex-row justify-content-center mt-3\">\r\n    <h2 class=\"text-center\">Фотографируйтесь с нашей пиццей и учавствуйте в еженедельных розыгрышах!</h2>\r\n</div>\r\n<div class=\"container mt-3 flex-wrap\">\r\n");
#nullable restore
#line 27 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Account\Pictures.cshtml"
       
        foreach (UsersPicture picture in Model.UserPictures)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-3 justify-content-center\">\r\n            <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1080, "\"", 1098, 1);
#nullable restore
#line 31 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Account\Pictures.cshtml"
WriteAttributeValue("", 1086, picture.URL, 1086, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n        </div>\r\n");
#nullable restore
#line 33 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Account\Pictures.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserAtSite> Html { get; private set; }
    }
}
#pragma warning restore 1591
