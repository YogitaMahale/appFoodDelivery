#pragma checksum "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd5870ede7e2c44d5a8671b9f7f6616ffd937d28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
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
#line 1 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd5870ede7e2c44d5a8671b9f7f6616ffd937d28", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce4c353ae1028ea07b2b03f0350980e17deaa019", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<appFoodDelivery.Models.orderinvoice>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("lblid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "test", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-rounded btn-success float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-md-12 grid-margin grid-margin-md-0\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n");
            WriteLiteral("            \r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    \r\n                    <h2>Invoice Order No -  ");
#nullable restore
#line 17 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                       Write(Model.orderheader.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        <hr />
                        <div class=""form-row"">
                            
                            <div class=""form-group col-md-6"">
                                <p class=""font-weight-bold"" style=""color:white;""><h4>From</h4></p>
                                <p class=""font-weight-normal "">  ");
#nullable restore
#line 23 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                            Write(Model.orderheader.storename);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n                                <p class=\"font-weight-normal\">");
#nullable restore
#line 24 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                         Write(Model.orderheader.storeaddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  </p>


                            </div>
                            <div class=""form-group col-md-6"">
                                <p class=""font-weight-bold"" style=""color:white""><h4>To</h4></p>
                                <p class=""font-weight-bold"">  ");
#nullable restore
#line 30 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                         Write(Model.orderheader.customerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n                                <p class=\"font-weight-normal\">Mobile No. :  ");
#nullable restore
#line 31 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                                       Write(Model.orderheader.mobileno);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n                                <p class=\"font-weight-normal\">Delivery Address :  ");
#nullable restore
#line 32 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                                             Write(Model.orderheader.deliveryaddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  </p>
                            </div>

                        </div>
                         
                    </div>
                </div>
                         
                        <div class=""row"">
                            <div class=""col-md-12 table-responsive-md"">

                                <table class=""table table-striped tblShow"" style=""border: 1px solid black;"">
                                    <thead>
                                        <tr>
                                            <th style=""display:none;"">id</th>
                                            <th>ProductName</th>
                                            <th>Price</th>
                                            <th>Quantity</th>
                                            <th>Total</th>

                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 55 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                         foreach (var item in Model.orderdetails)
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td style=\"display:none;\">\r\n\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd5870ede7e2c44d5a8671b9f7f6616ffd937d289650", async() => {
                WriteLiteral("\r\n                                                        ");
#nullable restore
#line 62 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                   Write(item.id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    ");
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
#line 61 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                                                             WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 66 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                               Write(item.productname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 69 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                               Write(item.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 72 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                               Write(item.qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n\r\n                                                    ");
#nullable restore
#line 76 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                               Write(item.total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                                </td>\r\n\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 82 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th>Sub Total :</th>
                                            <th>");
#nullable restore
#line 89 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                           Write(Model.orderheader.productCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>

                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th>Delivery Charges :</th>
                                            <th>");
#nullable restore
#line 96 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                           Write(Model.orderheader.deliverycharges);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>

                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th>Total :</th>
                                            <th>");
#nullable restore
#line 103 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Order\Details.cshtml"
                                           Write(Model.orderheader.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>

                                        </tr>
                                    </tfoot>
                                </table><br />


                            </div>
                        </div>
                        <div class=""wrap d-flex justify-content-start justify-content-sm-center flex-wrap"">
");
            WriteLiteral("\r\n");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd5870ede7e2c44d5a8671b9f7f6616ffd937d2817420", async() => {
                WriteLiteral("<i class=\"fas fa-caret-square-left\" style=\"margin-right:0.7em\"></i>Back to Orders");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <br />
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                </div>
            </div>
        </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<appFoodDelivery.Models.orderinvoice> Html { get; private set; }
    }
}
#pragma warning restore 1591
