#pragma checksum "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18add196c32a98fb358dc12eb94ac0cca5132a3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SearchSales_List), @"mvc.1.0.view", @"/Views/SearchSales/List.cshtml")]
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
#line 1 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\_ViewImports.cshtml"
using CarDealer.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\_ViewImports.cshtml"
using CarDealer.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18add196c32a98fb358dc12eb94ac0cca5132a3a", @"/Views/SearchSales/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d1063a438c5cf09e5a03eb59a439515d1bde1b6", @"/Views/_ViewImports.cshtml")]
    public class Views_SearchSales_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarDealer.Web.ViewModels.Sales.SalesListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaleInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PagingPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-lg-9 col-xs-12\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 5 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
         foreach (var sale in Model.Sales)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-6 col-md-4 col-sm-6\">\r\n                <div class=\"courses-thumb courses-thumb-secondary\">\r\n                    <div class=\"courses-top\">\r\n                        <div class=\"courses-image\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 427, "\"", 465, 1);
#nullable restore
#line 11 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
WriteAttributeValue("", 433, sale.ImageUrls.FirstOrDefault(), 433, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 489, "\"", 495, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"courses-date\">\r\n                            <span title=\"Author\"><i class=\"fa fa-dashboard\"></i> ");
#nullable restore
#line 14 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                            Write(sale.Car.Mileage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" km</span>\r\n                            <span title=\"Author\"><i class=\"fa fa-cube\"></i> ");
#nullable restore
#line 15 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                       Write(sale.Car.EngineSize);

#line default
#line hidden
#nullable disable
            WriteLiteral(" cc</span>\r\n                            <span title=\"Views\"><i class=\"fa fa-cog\"></i> ");
#nullable restore
#line 16 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                     Write(sale.Car.Gearbox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"courses-detail\">\r\n                        <h3 class=\"mt-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18add196c32a98fb358dc12eb94ac0cca5132a3a6462", async() => {
#nullable restore
#line 21 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                                     Write(sale.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                    WriteLiteral(sale.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n\r\n                        <p class=\"lead\"><strong>");
#nullable restore
#line 23 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                           Write(sale.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" €</strong></p>\r\n\r\n                        <p>");
#nullable restore
#line 25 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                      Write(sale.Car.HorsePower);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hp &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 25 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                        Write(sale.Car.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 25 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                                                                     Write(sale.Car.ManufactureDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 25 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                                                                                                     Write(sale.Car.ManufactureDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 25 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
                                                                                                                                                                                                              Write(sale.Car.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(" vehicle</p>\r\n                    </div>\r\n\r\n                    <div class=\"courses-info\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1548, "\"", 1582, 2);
            WriteAttributeValue("", 1555, "/Sales/SaleInfo?id=", 1555, 19, true);
#nullable restore
#line 29 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
WriteAttributeValue("", 1574, sale.Id, 1574, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"section-btn btn btn-primary btn-block\">View More</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 33 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <hr />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "18add196c32a98fb358dc12eb94ac0cca5132a3a12016", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 36 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\SearchSales\List.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarDealer.Web.ViewModels.Sales.SalesListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
