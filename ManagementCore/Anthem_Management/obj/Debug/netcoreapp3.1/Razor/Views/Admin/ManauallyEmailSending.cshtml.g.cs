#pragma checksum "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d234b080171f893a3c0dbf8dea8e75ab49caa97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManauallyEmailSending), @"mvc.1.0.view", @"/Views/Admin/ManauallyEmailSending.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d234b080171f893a3c0dbf8dea8e75ab49caa97", @"/Views/Admin/ManauallyEmailSending.cshtml")]
    public class Views_Admin_ManauallyEmailSending : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/multifile-master/jquery.MultiFile.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/ajax_loader_blue_512.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml"
  
    ViewData["Title"] = "ManauallyEmailSending";
    Layout = "~/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d234b080171f893a3c0dbf8dea8e75ab49caa974343", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>

<script>
        $(window).load(function () {
            $('#popup').hide();
        });
</script>

<script type=""text/javascript"">

             function ShowProgress() {
                 setTimeout(function () {
                     var modal = $('<div />');
                     modal.addClass(""modal"");
                     $('body').append(modal);
                     var loading = $("".loading"");
                     loading.show();
                     var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                     var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                     loading.css({ top: top, left: left });
                 }, 200);
             }


             $('form').live(""submit"", function () {
                 var txt = $('#ContentPlaceHolder_txtto').val();
                 var txtmess");
            WriteLiteral(@"age = $('#ContentPlaceHolder_txtmessage').val();
                 var txtsubject = $('input[type=""text""]').val();
                 if (txtsubject == """" || txt == """" || txtmessage=="""") {
                 }
                 else {
                     ShowProgress();
                 }
                 });

</script>


<style>
    .modal {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }

    .loading {
        font-family: Arial;
        font-size: 10pt;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        width: 100%;
        height: 100%;
        display: none;
        position: fixed;
        background-color: black;
        z-index: 999;
        padding: 173px;
    }

    td {
        padding-left: 5px;
    }

    input[type='f");
            WriteLiteral(@"ile'] {
        color: transparent;
    }

    input[type='checkbox'] {
        margin-right: 2px;
    }
</style>
<form runat=""server"" id=""form1"">
    <div style=""min-height:543px;"">
        <div class=""loading"" align=""center"" id=""popup"" runat=""server"">
            <br />
            <br />
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d234b080171f893a3c0dbf8dea8e75ab49caa977842", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div style=""margin-left:100px;"">
            <div>
                <h3 style=""color:#626262;float:left;margin-top: -5px;"">Send Email</h3>
                <p id=""puser"" runat=""server"" style=""margin-left:1060px;font-size:medium;color:#003366;font-weight:600""></p>
            </div>
            <div style=""margin-top:30px;margin-left:10px;float:left"">
                <table>
                    <tr>
                        <td>
                            <label id=""lblto"" style=""text-align:right"">To</label>
                        </td>
                        <td style=""float:left"">
                            <textarea id=""txtto"" class=""form-control"" style=""width:500px;height:80px;""></textarea>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id=""lblsubject"" style=""text-align:right"">Subject</label>
             ");
            WriteLiteral(@"           </td>
                        <td style=""float:left"">
                            <input type=""text"" id=""txtsubject"" class=""form-control"" style=""float:left;width:500px;"" />
                        </td>
                        <td>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label id=""lblattachment"">Attachment</label>
                        </td>
                        <td>
                            <input type=""file"" id=""fldattachment"" class=""multi maxsize-25600"" maxlength=""3"" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id=""lblbody"" style=""text-align:right;"">Message</label>
                        </td>
                        <td style=""float:left"">
                            <textarea id=""txtmessage"" class=""form-control"" style=""float:left;width:500px;height:300px;""></textar");
            WriteLiteral(@"ea>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <table id=""attachedfiles""></table>
                        </td>
                    </tr>
                </table>
                <button id=""btnsend"" class=""btn btn-primary"" style=""font-size:18px;margin:5px 113px; padding:5px 30px;"">Send</button>
            </div>
");
#nullable restore
#line 149 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml"
             foreach (var item in @ViewBag.EmpNameList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div style=\"margin-left:960px;\">\r\n\r\n                    <input type=\"checkbox\" id=\"chkemployees\" class=\"labell\" style=\"padding-left:5px;font-size:small;color:#006699;margin-top:30px;\"");
            BeginWriteAttribute("name", " name=\"", 5466, "\"", 5483, 1);
#nullable restore
#line 153 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml"
WriteAttributeValue("", 5473, item.Name, 5473, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <label style=\"color: #006699; font-size: Small;\">");
#nullable restore
#line 154 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml"
                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                  \r\n\r\n                </div>\r\n");
#nullable restore
#line 158 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Admin\ManauallyEmailSending.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n    </div>\r\n\r\n</form>\r\n<style>\r\n    a.MultiFile-remove {\r\n        margin-left: 33px;\r\n    }\r\n\r\n    div.MultiFile-label {\r\n        float: left;\r\n    }\r\n</style>\r\n\r\n\r\n");
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
