#pragma checksum "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47ca3e7f704f6b73e84b0484b8cd7c9a66a6327b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navbar), @"mvc.1.0.view", @"/Views/Shared/_Navbar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47ca3e7f704f6b73e84b0484b8cd7c9a66a6327b", @"/Views/Shared/_Navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0066fb481a1991747b5617bf1e4514840a0627a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderNavbarViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-mainboard justify-content-end align-self-md-auto rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/logos.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
  
    bool authentificated = User.Identity.IsAuthenticated;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav class=\"nav-class nav-min\">\r\n    <div class=\"main-box row\">\r\n        <div class=\"col-md-1 justify-content-md-end ms-3\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 234, "\"", 269, 1);
#nullable restore
#line 8 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 241, Url.Action("Index", "Home"), 241, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "47ca3e7f704f6b73e84b0484b8cd7c9a66a6327b5472", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </a>
        </div>
        <div class=""col-md-1 left"">
            <li class=""li-list"">
                <a href=""#Pizza"">
                    Пицца
                </a>
            </li>
        </div>
        <div class=""col-md-1 left"">
            <li class=""li-list"">
                <a href=""#Rolls"">
                    Роллы
                </a>
            </li>
        </div>
        <div class=""col-md-1 left"">
            <li class=""li-list"">
                <a href=""#Burgers"">
                    Бургеры
                </a>
            </li>
        </div>
        <div class=""col-md-1 left"">
            <li class=""li-list"">
                <a href=""#Soda"">
                    Напитки
                </a>
            </li>
        </div>
");
#nullable restore
#line 40 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
          
            if (User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""dropdown col-md-1 align-self-center"">
                    <button class=""btn btn-secondary dropdown-toggle"" type=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
                        <i class=""fa-solid fa-gear""></i>
                    </button>
                    <ul class=""dropdown-menu"">
                        <li><a class=""dropdown-item justify-content-md-start""");
            BeginWriteAttribute("href", " href=\"", 1685, "\"", 1720, 1);
#nullable restore
#line 48 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 1692, Url.Action("Index","Roles"), 1692, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Роли</a></li>\r\n                        <li><a class=\"dropdown-item justify-content-md-start\"");
            BeginWriteAttribute("href", " href=\"", 1814, "\"", 1866, 1);
#nullable restore
#line 49 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 1821, Url.Action("ListProduct","ProductModerator"), 1821, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Продукты</a></li>\r\n                        <li><a class=\"dropdown-item justify-content-md-start\"");
            BeginWriteAttribute("href", " href=\"", 1964, "\"", 2017, 1);
#nullable restore
#line 50 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 1971, Url.Action("ListCategory","ProductModerator"), 1971, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Категории</a></li>\r\n                        <li><a class=\"dropdown-item justify-content-md-start\"");
            BeginWriteAttribute("href", " href=\"", 2116, "\"", 2154, 1);
#nullable restore
#line 51 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 2123, Url.Action("List","Moderator"), 2123, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Пользователи</a></li>\r\n                    </ul>\r\n                </div>\r\n");
#nullable restore
#line 54 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
            }
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
          await Html.RenderPartialAsync("_Cart", Model); 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-1 justify-content-center align-items-center\">\r\n");
#nullable restore
#line 58 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
          
            if (authentificated)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""dropdown"">
                    <button class=""button-basket dropdown-toggle"" type=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"" data-size=""medium"">
                         <i class=""fa-solid fa-user""></i>
                    </button>
                    <ul class=""dropdown-menu"">
                        <li><a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 2826, "\"", 2899, 1);
#nullable restore
#line 66 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 2833, Url.Action("PersonalArea","Account", new { email = Model.Email }), 2833, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Личный кабинет</a></li>\r\n                        <li><a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 2978, "\"", 3051, 1);
#nullable restore
#line 67 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 2985, Url.Action("OrderHistory","Account", new { email = Model.Email }), 2985, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">История заказов</a></li>\r\n                    </ul>\r\n                </div>\r\n");
#nullable restore
#line 70 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"button-basket\" data-size=\"medium\"");
            BeginWriteAttribute("href", " href=\"", 3241, "\"", 3278, 1);
#nullable restore
#line 73 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 3248, Url.Action("Login","Account"), 3248, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-right-to-bracket\"></i><h6 style=\"opacity: 0%\">s</h6><i class=\"fa-solid fa-user\"></i></a>\r\n");
#nullable restore
#line 74 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\Shared\_Navbar.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</nav>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderNavbarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
