#pragma checksum "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05277e414b070d925fafe821136a97ce09caf7c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_collection_Index), @"mvc.1.0.view", @"/Views/collection/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05277e414b070d925fafe821136a97ce09caf7c1", @"/Views/collection/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce4c353ae1028ea07b2b03f0350980e17deaa019", @"/Views/_ViewImports.cshtml")]
    public class Views_collection_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<appFoodDelivery.pagination.OrderPagination<collectionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "collect", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
  
    ViewBag.Title = "Collection Details";

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05277e414b070d925fafe821136a97ce09caf7c15744", async() => {
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
            WriteLiteral("</li>\r\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">Collection Details</li>\r\n                    </ol>\r\n                </nav><br />\r\n");
#nullable restore
#line 20 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                 using (Html.BeginForm("Index", "collection", FormMethod.Post))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""row"">
                <div class=""form-group col-md-2"">
                    <label>From Date</label>
                </div>
                <div class=""form-group col-md-3"">
                    <div class=""input-group date"" data-provide=""datepicker"">
");
            WriteLiteral("                        <input type=\"text\" id=\"datepicker1\" autocomplete=\"off\" class=\"form-control datepicker\"");
            BeginWriteAttribute("value", " value=\"", 1235, "\"", 1257, 1);
#nullable restore
#line 30 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
WriteAttributeValue("", 1243, ViewBag.from1, 1243, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""from1"">

                        <div class=""input-group-addon"">
                            <span class=""glyphicon glyphicon-th""></span>
                        </div>
                    </div>

                </div>
                <div class=""form-group col-md-3"">
                    <input type=""submit"" name=""search"" value=""Search"" class=""btn btn-primary"" />

                </div>
");
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n");
#nullable restore
#line 86 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                            
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-12 table-responsive-md\">\r\n");
            WriteLiteral("                                <b>  <h4>");
#nullable restore
#line 92 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                    Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4> </b>\r\n                                <table class=\"table table-bordered tblShow\">\r\n                                    <thead>\r\n                                        <tr>\r\n");
            WriteLiteral(@"
                                            <th>Name</th>
                                            <th>Photo</th>
                                            <th>Mobile No</th>
                                            <th>Cash Amount</th>
                                             
                                            <th class=""text-warning"">Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 108 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                         foreach (var item in Model)
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td> ");
#nullable restore
#line 112 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                                Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("       </td>\r\n                                                <td>\r\n                                                    <img alt=\"image\"");
            BeginWriteAttribute("src", " src=\"", 5119, "\"", 5156, 1);
#nullable restore
#line 114 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
WriteAttributeValue("", 5125, Url.Content(item.profilephoto), 5125, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 117 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                               Write(item.mobileno);

#line default
#line hidden
#nullable disable
            WriteLiteral("  \r\n                                                </td>\r\n                                                <td>\r\n                                                     ");
#nullable restore
#line 120 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                                Write(item.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                                     

                                                </td>
                                                
                                                <td>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05277e414b070d925fafe821136a97ce09caf7c113370", async() => {
                WriteLiteral("\r\n                                        <i class=\"fas fa-edit\"></i> Collect Amount\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 127 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                                                                   WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 127 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                                                                                               WriteLiteral(ViewBag.from1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 133 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table><br />\r\n");
#nullable restore
#line 136 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                  
                                    var disablePrevious = !Model.IsPreviousAvailable ? "disabled" : "";
                                    var disableNext = !Model.IsNextAvailable ? "disabled" : "";
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05277e414b070d925fafe821136a97ce09caf7c117812", async() => {
                WriteLiteral("\r\n                                    Previous\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 142 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                              WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 143 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                        WriteLiteral(ViewBag.from1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6791, "btn", 6791, 3, true);
            AddHtmlAttributeValue(" ", 6794, "btn-primary", 6795, 12, true);
#nullable restore
#line 145 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
AddHtmlAttributeValue(" ", 6806, disablePrevious, 6807, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05277e414b070d925fafe821136a97ce09caf7c121694", async() => {
                WriteLiteral("\r\n                                    Next\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 149 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                              WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 150 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
                                        WriteLiteral(ViewBag.from1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7197, "btn", 7197, 3, true);
            AddHtmlAttributeValue(" ", 7200, "btn-primary", 7201, 12, true);
#nullable restore
#line 152 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\appFoodDelivery\appFoodDelivery\Views\collection\Index.cshtml"
AddHtmlAttributeValue(" ", 7212, disableNext, 7213, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05277e414b070d925fafe821136a97ce09caf7c125684", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"<script>
    $(function () {
        //$(""#datepicker1"").datepicker({
        //    autoclose: true,
        //        format: 'dd/mm/yyyy'
        //});
        //$(""#datepicker2"").datepicker({
        //    autoclose: true,
        //    format: 'dd/mm/yyyy'
        //});
        $("".datepicker"").datepicker({
            autoclose: true,
            dateFormat: 'dd/mm/yy'
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<appFoodDelivery.pagination.OrderPagination<collectionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
