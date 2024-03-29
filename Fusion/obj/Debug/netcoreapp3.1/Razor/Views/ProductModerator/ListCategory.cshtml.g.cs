#pragma checksum "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0e68dbd551572d691f2ff7d914cd98dc703c3eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductModerator_ListCategory), @"mvc.1.0.view", @"/Views/ProductModerator/ListCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0e68dbd551572d691f2ff7d914cd98dc703c3eb", @"/Views/ProductModerator/ListCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0066fb481a1991747b5617bf1e4514840a0627a", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductModerator_ListCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
  
    OrderNavbarViewModel viewModel = new OrderNavbarViewModel() { Authentificated = false };

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"log-in-out-background edit-background\">\r\n");
#nullable restore
#line 6 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
      await Html.RenderPartialAsync("_Navbar", viewModel);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container mh-100 mt-3\">\r\n");
#nullable restore
#line 8 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
          
            if (Model != null)
                foreach (Category category in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row justify-content-between\">\r\n                        <h3 class=\"col-1\">");
#nullable restore
#line 13 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                                     Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 14 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                         if (category.ProductCategories != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"d-flex flex-row col-4 flex-wrap\">\r\n                                <h4>Продукты с этой категорией</h4>\r\n");
#nullable restore
#line 18 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                         foreach (ProductCategory relationship in category.ProductCategories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h5 class=\"me-4\">");
#nullable restore
#line 20 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                                            Write(relationship.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 1020, "\"", 1167, 1);
#nullable restore
#line 21 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
WriteAttributeValue("", 1027, Url.Action("DeleteProductRelationship","ProductModerator", new { productId = relationship.ProductId, categoryId = relationship.CategoryId}), 1027, 140, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Удалить связь</a>\r\n");
#nullable restore
#line 22 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 24 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3 class=\"col-3\">У категории нет продуктов</h3>\r\n");
#nullable restore
#line 28 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"col-3\">\r\n                        <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 1559, "\"", 1638, 1);
#nullable restore
#line 31 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
WriteAttributeValue("", 1566, Url.Action("EditCategory", "ProductModerator", new { id = category.Id}), 1566, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Изменить</a>\r\n                        <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 1703, "\"", 1783, 1);
#nullable restore
#line 32 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
WriteAttributeValue("", 1710, Url.Action("DeleteCategory","ProductModerator", new { id = category.Id}), 1710, 73, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Удалить</a>\r\n                    </div>\r\n");
#nullable restore
#line 34 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
                }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"d-flex flex-row justify-content-end mt-4\">\r\n            <a class=\"btn btn-primary p-4\"");
            BeginWriteAttribute("href", " href=\"", 1962, "\"", 2018, 1);
#nullable restore
#line 37 "C:\Users\Печенька\source\repos\Fusion\Fusion100423(1)\Fusion\Views\ProductModerator\ListCategory.cshtml"
WriteAttributeValue("", 1969, Url.Action("CreateCategory", "ProductModerator"), 1969, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h3>Создать категорию</h3></a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
