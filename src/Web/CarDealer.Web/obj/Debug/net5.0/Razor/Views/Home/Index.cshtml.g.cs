#pragma checksum "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d1063a438c5cf09e5a03eb59a439515d1bde1b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CarDealer.Web.ViewModels.Sales.SaleViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/BootstrapTemplate/Html/cars.cshtml"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("section-btn btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaleInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section id=""home"">
    <div class=""row"">
        <div class=""owl-carousel owl-theme home-slider"">
            <div class=""item item-first"">
                <div class=""caption"">
                    <div class=""container"">
                        <div class=""col-md-6 col-sm-12"">
                            <h1>Lorem ipsum dolor sit amet.</h1>
                            <h3>Voluptas dignissimos esse, explicabo cum fugit eaque, perspiciatis quia ab nisi sapiente delectus eiet.</h3>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa4869", async() => {
                WriteLiteral("Browse Cars");
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
                        </div>
                    </div>
                </div>
            </div>

            <div class=""item item-second"">
                <div class=""caption"">
                    <div class=""container"">
                        <div class=""col-md-6 col-sm-12"">
                            <h1>Distinctio explicabo vero animi culpa facere voluptatem.</h1>
                            <h3>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nemo, excepturi.</h3>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa6567", async() => {
                WriteLiteral("Browse Cars");
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
                        </div>
                    </div>
                </div>
            </div>

            <div class=""item item-third"">
                <div class=""caption"">
                    <div class=""container"">
                        <div class=""col-md-6 col-sm-12"">
                            <h1>Efficient Learning Methods</h1>
                            <h3>Nam eget sapien vel nibh euismod vulputate in vel nibh. Quisque eu ex eu urna venenatis sollicitudin ut at libero.</h3>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa8274", async() => {
                WriteLiteral("Browse Cars");
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
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            WriteLiteral(@"<section>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12 col-sm-12"">
                <div class=""section-title text-center"">
                    <h2>Featured Cars</h2>
                </div>
            </div>
            <br />
");
#nullable restore
#line 55 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
             foreach (var sale in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-4 col-sm-4"">
                    <div class=""courses-thumb courses-thumb-secondary"">
                        <div class=""courses-top"">
                            <div class=""courses-image"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 2714, "\"", 2752, 1);
#nullable restore
#line 61 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 2720, sale.ImageUrls.FirstOrDefault(), 2720, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\"");
            BeginWriteAttribute("alt", " alt=\"", 2776, "\"", 2782, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"courses-date\">\r\n                                <span title=\"Author\"><i class=\"fa fa-dashboard\"></i> ");
#nullable restore
#line 64 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                                Write(sale.Car.Mileage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" km</span>\r\n                                <span title=\"Author\"><i class=\"fa fa-cube\"></i> ");
#nullable restore
#line 65 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                           Write(sale.Car.EngineSize);

#line default
#line hidden
#nullable disable
            WriteLiteral(" cc</span>\r\n                                <span title=\"Views\"><i class=\"fa fa-cog\"></i> ");
#nullable restore
#line 66 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                         Write(sale.Car.Gearbox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"courses-detail\">\r\n                            <h3 class=\"mt-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff2313ff2b2864e7cd127d404ce7d9c54d2cdefa12454", async() => {
#nullable restore
#line 71 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                                         Write(sale.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
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
            WriteLiteral("</h3>\r\n\r\n                            <p class=\"lead\"><strong>");
#nullable restore
#line 73 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                               Write(sale.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" €</strong></p>\r\n\r\n                            <p>");
#nullable restore
#line 75 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                          Write(sale.Car.HorsePower);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hp &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 75 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                            Write(sale.Car.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 75 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                                                                         Write(sale.Car.ManufactureDate.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 75 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                                                                                                         Write(sale.Car.ManufactureDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;/&nbsp;&nbsp; ");
#nullable restore
#line 75 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
                                                                                                                                                                                                                  Write(sale.Car.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(" vehicle</p>\r\n                        </div>\r\n\r\n                        <div class=\"courses-info\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 3891, "\"", 3925, 2);
            WriteAttributeValue("", 3898, "/Sales/SaleInfo?id=", 3898, 19, true);
#nullable restore
#line 79 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 3917, sale.Id, 3917, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"section-btn btn btn-primary btn-block\">View More</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 83 "C:\Users\Dimitar\Desktop\CarDealer\src\Web\CarDealer.Web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CarDealer.Web.ViewModels.Sales.SaleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
