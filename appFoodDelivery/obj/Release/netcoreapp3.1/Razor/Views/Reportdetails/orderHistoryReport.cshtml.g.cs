#pragma checksum "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportdetails_orderHistoryReport), @"mvc.1.0.view", @"/Views/Reportdetails/orderHistoryReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"379e64ce32a7608a995d3a99ab9ff8e02d07dbcb", @"/Views/Reportdetails/orderHistoryReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce4c353ae1028ea07b2b03f0350980e17deaa019", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportdetails_orderHistoryReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<orderHistoryReportViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Placed", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "approved", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "processorders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ongoingorders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "completedorders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "cancelledorders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
  
    ViewBag.Title = "Orders History Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12 grid-margin"">
        <div class=""card"">
           

            <div class=""card-body"">
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb7448", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">Order History Details</li>\r\n                    </ol>\r\n                </nav><br />\r\n");
#nullable restore
#line 21 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                 using (Html.BeginForm("orderHistoryReport", "Reportdetails", FormMethod.Post))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-row\">\r\n                <div class=\"form-group col-md-1\">\r\n                    <label>Start Date :</label>\r\n                </div>\r\n                <div class=\"form-group col-md-2\">\r\n                    <input type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 1063, "\"", 1084, 1);
#nullable restore
#line 29 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
WriteAttributeValue("", 1071, DateTime.Now, 1071, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"from\" />\r\n                </div>\r\n                <div class=\"form-group col-md-1\">\r\n                    <label>To Date :</label>\r\n                </div>\r\n                <div class=\"form-group col-md-2\">\r\n                    <input type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 1336, "\"", 1357, 1);
#nullable restore
#line 35 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
WriteAttributeValue("", 1344, DateTime.Now, 1344, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""to"" />
                </div>
                <div class=""form-group col-md-1"">
                    <label>Status :</label>
                </div>
                <div class=""form-group col-md-2"">
                    <select name=""status"" class=""form-control"">

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb11169", async() => {
                WriteLiteral("-- All --");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb12667", async() => {
                WriteLiteral("Pending");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb13852", async() => {
                WriteLiteral("Approved");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb15038", async() => {
                WriteLiteral("Process Orders");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb16230", async() => {
                WriteLiteral("On Going Orders");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb17423", async() => {
                WriteLiteral("Completed Orders");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb18617", async() => {
                WriteLiteral("Cancelled Orders");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    </select>
                </div>
                <div class=""form-group col-md-4"">
                    <input type=""submit"" name=""search"" value=""Search"" class=""btn btn-primary"" />
                    <input type=""submit"" name=""ExcelFileDownload"" value=""Excel Download"" class=""btn btn-primary"" />
                </div>
            </div>
");
#nullable restore
#line 58 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12 table-responsive-md\">\r\n");
            WriteLiteral("                        <b>  <h4>");
#nullable restore
#line 63 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                            Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4> </b>\r\n                        <table class=\"table table-striped tblShow\">\r\n                            <thead>\r\n                                <tr>\r\n");
            WriteLiteral(@"
                                    <th>Order Id</th>
                                    <th>Date</th>
                                    <th>Store</th>
                                    <th>Customer Name</th>
                                    <th>Amount</th>
                                    <th>Customer Amount</th>
                                    <th>Customer Delivery Charges</th>
                                    <th>deliveryboy Earning</th>
                                    <th>Status</th>
                                    <th>Deliveryboy</th>
");
            WriteLiteral("                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 84 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                 foreach (var item in Model)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td> ");
#nullable restore
#line 88 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                    Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("     </td>\r\n                                    <td>");
#nullable restore
#line 89 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.placedate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 91 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.storename);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 94 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.customerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 96 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.finalamt);

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n                                    <td>");
#nullable restore
#line 97 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.customeramt);

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n                                    <td>");
#nullable restore
#line 98 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.customerdeliverycharges);

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n                                    <td>");
#nullable restore
#line 99 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.deliveryboycharges);

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n                                    <td>");
#nullable restore
#line 100 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.orderstatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n                                    <td>");
#nullable restore
#line 101 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                   Write(item.deliveryboyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n");
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 109 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\orderHistoryReport.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table><br />\r\n");
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379e64ce32a7608a995d3a99ab9ff8e02d07dbcb27189", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<orderHistoryReportViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
