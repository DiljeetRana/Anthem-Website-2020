#pragma checksum "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Home\LoginNew.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e068d010d9eddcab63cb3d27a1aa519e10349ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_LoginNew), @"mvc.1.0.view", @"/Views/Home/LoginNew.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e068d010d9eddcab63cb3d27a1aa519e10349ee", @"/Views/Home/LoginNew.cshtml")]
    public class Views_Home_LoginNew : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/anthem-infotech.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Anthem infotech"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Anthem Infotech"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("45px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Logimages/back.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 30px; width: 31px; margin-top: 7px;margin-left:-7PX;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Home\LoginNew.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body {
        background: url(../Logimages/bg.png) repeat;
        font-family: ""HelveticaNeue-Light"", ""Helvetica Neue Light"", ""Helvetica Neue"", Helvetica, Arial, ""Lucida Grande"", sans-serif;
        font-weight: 300;
        text-align: left;
        text-decoration: none;
    }
    .login-form {
        width: 300px;
        position: relative;
        z-index: 5;
        background: #f3f3f3;
        border: 1px solid #fff;
        border-radius: 5px;
        box-shadow: 0 1px 3px rgba(0,0,0,0.5);
        -moz-box-shadow: 0 1px 3px rgba(0,0,0,0.5);
        -webkit-box-shadow: 0 1px 3px rgba(0,0,0,0.5);
    }

    .img1 {
        margin-left: 28px;
    }


    /* Second input field */
    .login-form .content .password, .login-form .content .pass-icon {
        margin-top: 25px;
    }

    .login-form .content .input:hover {
        background: #dfe9ec;
        color: #414848;
    }

    .login-form .content .input:focus {
        background: #dfe9ec;
       ");
            WriteLiteral(@" color: #414848;
        box-shadow: inset 0 1px 2px rgba(0,0,0,0.25);
        -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.25);
        -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.25);
    }


    /* Animation */
    .input, .user-icon, .pass-icon, .button, .register {
        transition: all 0.5s;
        -moz-transition: all 0.5s;
        -webkit-transition: all 0.5s;
        -o-transition: all 0.5s;
        -ms-transition: all 0.5s;
    }

    .login-form .header {
        padding: 25px 30px 30px 30px;
    }

    .user-icon, .pass-icon {
        width: 46px;
        height: 47px;
        display: block;
        position: absolute;
        left: 0px;
        margin-left: -47px;
        padding-right: 2px;
        z-index: 3;
        -moz-border-radius-topleft: 5px;
        -moz-border-radius-bottomleft: 5px;
        -webkit-border-top-left-radius: 5px;
        -webkit-border-bottom-left-radius: 5px;
    }

    .user-icon {
        top: 214px; /* Positioning fix for");
            WriteLiteral(@" slide-in, got lazy to think up of simpler method. */
        background: rgba(65,72,72,0.75) url(../Logimages/user-icon.png) no-repeat center;
    }

    .pass-icon {
        top: 287px;
        background: rgba(65,72,72,0.75) url(../Logimages/pass-icon.png) no-repeat center;
    }
</style>

<div id=""wrapper"" style=""margin-top:-250px!important;"">
");
#nullable restore
#line 90 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Home\LoginNew.cshtml"
     if (ViewBag.message != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script type=\"text/javascript\">\r\n            window.onload = function () {\r\n                alert(\"");
#nullable restore
#line 94 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Home\LoginNew.cshtml"
                  Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n            };\r\n        </script>\r\n");
#nullable restore
#line 97 "E:\Sahil Works\Management(Core)\Anthem_Management\Views\Home\LoginNew.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!--SLIDE-IN ICONS-->\r\n");
            WriteLiteral("    <!--END SLIDE-IN ICONS-->\r\n    <!--LOGIN FORM-->\r\n    <form class=\"login-form\" runat=\"server\" method=\"post\" action=\"\\Home\\LoginNew\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8e068d010d9eddcab63cb3d27a1aa519e10349ee9234", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
            WriteLiteral(@"
        <!--HEADER-->
        <div class=""header"">
            <!--DESCRIPTION-->
            <span>
                <b> Password Hint</b> : Concatenate ->Last 3 characters of your employee code | followed by  # character | followed by last 4 characters of your primary phone number | followed by  character | followed by year of your birth. In total 13 characters. i.e 001#2345@1997
            </span>
            <!--END DESCRIPTION-->
        </div>
        <!--END HEADER-->
        <!--CONTENT-->
        <div class=""content"">
            <input name=""username"" type=""text"" class=""input username"" value=""Username"" onfocus=""this.value=''"" />
            <input name=""password"" type=""password"" class=""input password"" value=""Password"" onfocus=""this.value=''"" />
        </div>
        <!--END CONTENT-->
        <!--FOOTER-->

        <div class=""footer"">

            <input type=""submit"" name=""submit"" value=""Login"" class=""button"" />
            <input type=""submit"" href=""#"" name=""submit"" value=""");
            WriteLiteral("Register\" class=\"register\" />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8e068d010d9eddcab63cb3d27a1aa519e10349ee11820", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!--END FOOTER-->\r\n\r\n    </form>\r\n    <!--END LOGIN FORM-->\r\n\r\n</div>\r\n\r\n\r\n");
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
