#pragma checksum "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95f0fc7f2a9191a568f84c6db46e60aa24519cf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_HolidayManagement), @"mvc.1.0.view", @"/Views/Admin/HolidayManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95f0fc7f2a9191a568f84c6db46e60aa24519cf0", @"/Views/Admin/HolidayManagement.cshtml")]
    public class Views_Admin_HolidayManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/edit.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 20px; width: 16px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/delete.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/anthem-infotecha.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("400"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("455"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
  
    ViewData["Title"] = "HolidayManagement";
    Layout = "~/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""min-height:537px;"">
    <h5 style=""margin-left:115px;color:#626262;float:left"" runat=""server"">Holidays</h5>
    <div style=""margin-left:1170px;margin-top:10px;height:40px;"">
        <p id=""puser"" style=""font-size:medium;color:#003366;font-weight:600;""></p>
    </div>

    <form runat=""server"" style=""margin-top:5px; "">
        <div style=""margin-left:115px;margin-bottom:5px;float:left"">
            <label style=""float:left;font-family:Verdana;font-size:14px;"">Please Select Year for Holidays</label>
");
            WriteLiteral("            <select id=\"ddlyear\" class=\"form-control\" style=\"float:left;width:150px;text-align:center;margin-left:18px;\">");
#nullable restore
#line 17 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                                                                                                                    Write(ViewBag.YearList);

#line default
#line hidden
#nullable disable
            WriteLiteral("</select>\r\n            <p id=\"pmessage\" runat=\"server\" style=\"color:red;float:left;width:120px\"></p>\r\n\r\n        </div>\r\n        <a href=\"\\Admin\\AddHoliday\" id=\"btnsubmit\" class=\"btn btn-primary\"");
            BeginWriteAttribute("value", " value=\"", 1158, "\"", 1166, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""color:white;font-size:16px;padding:7px 20px 5px 20px;font-family:Verdana;margin-bottom:5px;margin-left:54px"">Add Holiday</a> 
       
        <div class=""form-group"" style=""margin-left:115px;float:left"">
            <table id=""example"" ForeColor=""#333333"" Font-Size=""Small"">
                <thead>
                    <tr>
                        <th style=""width:200px;background-color:#0097E3;font-weight:bold;height:40px;color:white;"">Holiday Date</th>
                        <th style=""width:220px;background-color:#0097E3;font-weight:bold;height:40px;color:white;"">Holiday</th>
                        <th style=""width:100px;background-color:#0097E3;font-weight:bold;height:40px;color:white;"">Day</th>
                        <th style=""width:100px;background-color:#0097E3;font-weight:bold;height:40px;color:white;"">Edit</th>
                        <th style=""width:100px;background-color:#0097E3;font-weight:bold;height:40px;color:white;"">Delete</th>
                    </tr>
                <");
            WriteLiteral("/thead>\r\n                <tbody>\r\n");
#nullable restore
#line 35 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                     foreach (var item in @ViewBag.HolidayList)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                         if (Convert.ToDateTime(item.FestivalDate) < DateTime.Now)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"text-decoration:line-through;\">\r\n                                <td>");
#nullable restore
#line 40 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95f0fc7f2a9191a568f84c6db46e60aa24519cf09263", async() => {
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
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                                <td>\r\n                                    <a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95f0fc7f2a9191a568f84c6db46e60aa24519cf010584", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 54 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"font-weight:bold;\">\r\n                                <td>");
#nullable restore
#line 58 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 59 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 60 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                               Write(item.FestivalDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95f0fc7f2a9191a568f84c6db46e60aa24519cf013195", async() => {
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
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                                <td>\r\n                                    <a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95f0fc7f2a9191a568f84c6db46e60aa24519cf014517", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 72 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\HolidayManagement.cshtml"
                         

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n           \r\n        </div>\r\n\r\n\r\n        <div style=\"margin-left:880px;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95f0fc7f2a9191a568f84c6db46e60aa24519cf016354", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </form>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
