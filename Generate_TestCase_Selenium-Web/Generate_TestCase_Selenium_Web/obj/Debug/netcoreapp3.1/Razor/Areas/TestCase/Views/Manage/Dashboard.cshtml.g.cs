#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e06690d29e4617f29c9e8290174aa581e4b9ca8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TestCase_Views_Manage_Dashboard), @"mvc.1.0.view", @"/Areas/TestCase/Views/Manage/Dashboard.cshtml")]
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
#line 1 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e06690d29e4617f29c9e8290174aa581e4b9ca8", @"/Areas/TestCase/Views/Manage/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/TestCase/Views/_ViewImports.cshtml")]
    public class Areas_TestCase_Views_Manage_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("small text-white stretched-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "TestCase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Projects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_LayoutManage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1 class=""mt-4"">Dashboard</h1>
<ol class=""breadcrumb mb-4"">
    <li class=""breadcrumb-item active"">Dashboard</li>
</ol>
<hr />
<div class=""row"">
    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-primary text-white mb-4"">
            <div class=""card-body"">Project: ");
#nullable restore
#line 14 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml"
                                       Write(ViewBag.CountProjects);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"card-footer d-flex align-items-center justify-content-between\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e06690d29e4617f29c9e8290174aa581e4b9ca85829", async() => {
                WriteLiteral("View Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-warning text-white mb-4"">
            <div class=""card-body"">Url: ");
#nullable restore
#line 23 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml"
                                   Write(ViewBag.CountUrls);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

            <div class=""card-footer d-flex align-items-center justify-content-between"">
                <a class=""small text-white stretched-link"" href=""#""></a>
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>

    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-success text-white mb-4"">
            <div class=""card-body"">Test case:  ");
#nullable restore
#line 34 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml"
                                          Write(ViewBag.CountTestcases);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <div class=""card-footer d-flex align-items-center justify-content-between"">
                <a class=""small text-white stretched-link"" href=""#""></a>
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6"">
            <div class=""card bg-danger text-white mb-4"">
                <div class=""card-body"">Tested: ");
#nullable restore
#line 43 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\Dashboard.cshtml"
                                          Write(ViewBag.CountResult);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                <div class=""card-footer d-flex align-items-center justify-content-between"">
                    <a class=""small text-white stretched-link"" href=""#""></a>
                    <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
                </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591