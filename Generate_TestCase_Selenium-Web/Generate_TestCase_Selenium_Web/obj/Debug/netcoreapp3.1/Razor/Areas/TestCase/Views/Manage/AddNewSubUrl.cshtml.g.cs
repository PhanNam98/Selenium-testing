#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "945216d378d90c14bd69dccabfe6b4773628f5a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TestCase_Views_Manage_AddNewSubUrl), @"mvc.1.0.view", @"/Areas/TestCase/Views/Manage/AddNewSubUrl.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945216d378d90c14bd69dccabfe6b4773628f5a8", @"/Areas/TestCase/Views/Manage/AddNewSubUrl.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/TestCase/Views/_ViewImports.cshtml")]
    public class Areas_TestCase_Views_Manage_AddNewSubUrl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Generate_TestCase_Selenium_Web.Models.ModelDB.Url>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "TestCase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Projects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/LoadingViewPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewSubUrl", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
  
    ViewData["Title"] = "AddNewSubUrl";
    Layout = "~/Views/Shared/_LayoutManage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Sub Urls of project: ");
#nullable restore
#line 8 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
                    Write(ViewBag.project_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<ol class=\"breadcrumb mb-4\">\r\n    <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945216d378d90c14bd69dccabfe6b4773628f5a86534", async() => {
                WriteLiteral("Project");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n    <li class=\"breadcrumb-item active\">Url</li>\r\n</ol>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "945216d378d90c14bd69dccabfe6b4773628f5a88167", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 14 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ViewBag.LoadingTitle;

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
            WriteLiteral(@"
<hr />
<div class=""card mb-4"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-3""><i class=""fas fa-table mr-1""></i>New url</div>
            <div class=""col-9"">
                <div class=""container"">
                    <div class=""text-right"">

                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-md-4"">
            </div>
            <div class=""col-md-6"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945216d378d90c14bd69dccabfe6b4773628f5a810410", async() => {
                WriteLiteral("\r\n                    <input id=\"id_testcase\" name=\"id_testcase\"");
                BeginWriteAttribute("value", " value=\"", 1182, "\"", 1210, 1);
#nullable restore
#line 36 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
WriteAttributeValue("", 1190, ViewBag.id_testcase, 1190, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden />\r\n                    <input id=\"project_id\" name=\"project_id\"");
                BeginWriteAttribute("value", " value=\"", 1283, "\"", 1310, 1);
#nullable restore
#line 37 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
WriteAttributeValue("", 1291, ViewBag.project_id, 1291, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden />\r\n                    <input id=\"id_url\" name=\"id_url\"");
                BeginWriteAttribute("value", " value=\"", 1375, "\"", 1398, 1);
#nullable restore
#line 38 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
WriteAttributeValue("", 1383, ViewBag.id_url, 1383, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden />\r\n\r\n");
                WriteLiteral(@"                    <div class=""form-group"">
                        <label class=""control-label"">Name<span style=""color:red;"">*</span></label>
                        <input name=""name"" class=""form-control"" required />

                    </div>
                    <div class=""form-group"">
                        <label class=""control-label"">Url</label>
                        <input name=""url1"" class=""form-control"" />
                    </div>
                    <div class=""form-group"" hidden=""hidden"">
                        <input name=""project_id"" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 2097, "\"", 2124, 1);
#nullable restore
#line 51 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\Manage\AddNewSubUrl.cshtml"
WriteAttributeValue("", 2105, ViewBag.project_id, 2105, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>

                    <div class=""form-group"">
                        <input type=""checkbox"" name=""IsChange"" id=""IsChange"" value=""true"" />
                        <label>
                            Change according to the results of the prerequisite test case
                        </label>
                    </div>
                    <div class=""form-group"">
                        <input type=""checkbox"" name=""IsOnlyDislayed"" id=""IsOnlyDislayed"" value=""true"" />
                        <label>
                            Only element is displayed
                        </label>
                    </div>
");
                WriteLiteral(@"
                    <div class=""form-group"">
                        <div class=""text-right"">
                            <input type=""submit"" value=""Add and Crawl data"" class=""btn btn-primary"" onclick=""ShowProgress()"" />
                        </div>

                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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

<script>

    function IsEmpty() {
        if (document.getElementById(""url1"").value === """" || document.getElementById(""name"").value === """") {

            return false;
        }
        ShowProgress();;
        return true;
    }

</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Generate_TestCase_Selenium_Web.Models.ModelDB.Url> Html { get; private set; }
    }
}
#pragma warning restore 1591