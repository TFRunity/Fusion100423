#pragma checksum "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b4689f4c6fd0953e0195e87916a00c5175458ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Cart), @"mvc.1.0.view", @"/Views/Shared/_Cart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b4689f4c6fd0953e0195e87916a00c5175458ff", @"/Views/Shared/_Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0066fb481a1991747b5617bf1e4514840a0627a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderNavbarViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
  
    Guid model = Model.OrderId;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
            switch(Model.Authentificated)
        {
            case false:

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-1\">\r\n                    <a class=\"button-basket\" data-size=\"medium\"");
            BeginWriteAttribute("href", " href=\"", 298, "\"", 335, 1);
#nullable restore
#line 10 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
WriteAttributeValue("", 305, Url.Action("Login","Account"), 305, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h6>Корзина</h6>\r\n                        <h6 style=\"opacity: 0%\">s</h6>\r\n                        <i class=\"fa-solid fa-trailer\"></i>\r\n                    </a>\r\n                </div>\r\n");
#nullable restore
#line 16 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
                break;
            default:

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-1\">\r\n                    <a class=\"button-basket\" data-size=\"medium\"");
            BeginWriteAttribute("href", " href=\"", 697, "\"", 759, 1);
#nullable restore
#line 19 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
WriteAttributeValue("", 704, Url.Action("Order","Account", new { OrderId = model }), 704, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h6>Корзина</h6>\r\n                        <h6 style=\"opacity: 0%\">s</h6>\r\n                        <i class=\"fa-solid fa-trailer\"></i>\r\n                    </a>\r\n                </div>\r\n");
#nullable restore
#line 25 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Cart.cshtml"
                break;
        }


#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOrderRepository<Order> _ordermethods { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderNavbarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
