#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\Shared\LoadingViewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbb243a7135745d66c5db467d49815efee28d907"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_LoadingViewPartial), @"mvc.1.0.view", @"/Views/Shared/LoadingViewPartial.cshtml")]
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
#line 1 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbb243a7135745d66c5db467d49815efee28d907", @"/Views/Shared/LoadingViewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_LoadingViewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style type=""text/css"">
    .modalblock {
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
        border: 5px solid #67CFF5;
        width: 600px;
        height: 300px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>
");
#nullable restore
#line 28 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\Shared\LoadingViewPartial.cshtml"
 if (!String.IsNullOrEmpty(Model))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"loading\" align=\"center\">\r\n        <h1>");
#nullable restore
#line 31 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\Shared\LoadingViewPartial.cshtml"
       Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1> <br />\r\n        <br />\r\n        <img src=\"https://cdn.dribbble.com/users/1867579/screenshots/6580156/loadin_gif.gif\"");
            BeginWriteAttribute("alt", " alt=\"", 821, "\"", 827, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px;height:100px;\" />\r\n\r\n    </div>\r\n");
#nullable restore
#line 36 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\Shared\LoadingViewPartial.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"loading\" align=\"center\">\r\n        <h2>Loading. Please wait a few minutes</h2> <br />\r\n        <br />\r\n        <img src=\"https://cdn.dribbble.com/users/1867579/screenshots/6580156/loadin_gif.gif\"");
            BeginWriteAttribute("alt", " alt=\"", 1103, "\"", 1109, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px;height:100px;\" />\r\n\r\n    </div>\r\n");
#nullable restore
#line 45 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Views\Shared\LoadingViewPartial.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"" integrity=""sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"" crossorigin=""anonymous""></script>
<script type=""text/javascript"">
    var modal, loading;
    function ShowProgress() {
        modal = document.createElement(""DIV"");
        modal.className = ""modalblock"";
        document.body.appendChild(modal);
        loading = document.getElementsByClassName(""loading"")[0];
        loading.style.display = ""block"";
        var top = Math.max(window.innerHeight / 2 - loading.offsetHeight / 2, 0);
        var left = Math.max(window.innerWidth / 2 - loading.offsetWidth / 2, 0);
        loading.style.top = top + ""px"";
        loading.style.left = left + ""px"";
    };

</script>



<script type=""text/javascript"">
    window.onload = function () {
        setTimeout(function () {
            document.b");
            WriteLiteral("ody.removeChild(modal);\r\n            loading.style.display = \"none\";\r\n        }, 0);\r\n    };\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
