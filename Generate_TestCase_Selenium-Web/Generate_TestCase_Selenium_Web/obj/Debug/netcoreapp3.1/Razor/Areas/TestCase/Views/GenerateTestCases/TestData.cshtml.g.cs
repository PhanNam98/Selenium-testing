#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1f49566030bcb983a31de854ba00fd02d0f6faa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TestCase_Views_GenerateTestCases_TestData), @"mvc.1.0.view", @"/Areas/TestCase/Views/GenerateTestCases/TestData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1f49566030bcb983a31de854ba00fd02d0f6faa", @"/Areas/TestCase/Views/GenerateTestCases/TestData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/TestCase/Views/_ViewImports.cshtml")]
    public class Areas_TestCase_Views_GenerateTestCases_TestData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Input_testcase>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GenerateTestCases", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-isload", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_StatusMessage.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
  
    ViewData["Title"] = "Test Data";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css\" />\r\n<h2>Test data of test case ");
#nullable restore
#line 8 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                      Write(ViewBag.id_testcase);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h4>Data input of test case</h4>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b1f49566030bcb983a31de854ba00fd02d0f6faa6504", async() => {
                WriteLiteral("Back to list test case");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id_url", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                                       WriteLiteral(ViewBag.id_url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_url"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id_url", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_url"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isload", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isload"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br />\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b1f49566030bcb983a31de854ba00fd02d0f6faa9737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 14 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ViewBag.Message;

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
            WriteLiteral("\r\n<div class=\"table-responsive\">\r\n    <table class=\"table table-condensed table-hover table-bordered\" id=\"inputtable\" style=\"width:100%\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 20 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
               Write(Html.DisplayName("Step"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 23 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
               Write(Html.DisplayName("Id element"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
               Write(Html.DisplayName("Action"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>Input value</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 33 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                   Write(item.test_step.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 40 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                          
                            string detail = "d" + @item.id_element.ToString();
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-custon-rounded-three btn-primary btn-xs\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 42 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                                                                                       Write(detail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 42 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                                                                                                Write(item.id_element);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
            WriteLiteral("                            <!-- Modal -->\r\n");
            WriteLiteral("                            <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 1794, "\"", 1806, 1);
#nullable restore
#line 46 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 1799, detail, 1799, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                                <div class=""center"">
                                    <div class=""modal-dialog modal-dialog-center"" role=""document"">
                                        <div class=""modal-content"">

                                            ");
#nullable restore
#line 51 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                       Write(Html.ValidationSummary(true, null, new { @class = "alert alert-block alert-danger fade in" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"" id=""exampleModalLabel"">Detail element</h5>
                                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Đóng"">
                                                    <span aria-hidden=""true"">&times;</span>
                                                </button>
                                            </div>
                                            <div class=""modal-body"">
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 60 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Id elemnet"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 3221, "\"", 3245, 1);
#nullable restore
#line 62 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 3229, item.id_element, 3229, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 66 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\"  class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 3745, "\"", 3767, 1);
#nullable restore
#line 68 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 3753, item.id_.name, 3753, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 72 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Class Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 4274, "\"", 4302, 1);
#nullable restore
#line 74 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 4282, item.id_.class_name, 4282, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 78 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Tag name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\"  class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 4808, "\"", 4834, 1);
#nullable restore
#line 80 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 4816, item.id_.tag_name, 4816, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 84 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Type"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 5335, "\"", 5357, 1);
#nullable restore
#line 86 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 5343, item.id_.type, 5343, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 90 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Href"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\"  class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 5859, "\"", 5881, 1);
#nullable restore
#line 92 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 5867, item.id_.href, 5867, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 96 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Title"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\"  class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 6384, "\"", 6407, 1);
#nullable restore
#line 98 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 6392, item.id_.title, 6392, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-3"">");
#nullable restore
#line 102 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                         Write(Html.Label("Xpath"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                    <div class=\"col-12 col-md-9\">\r\n                                                        <input type=\"text\"  class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 6910, "\"", 6933, 1);
#nullable restore
#line 104 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 6918, item.id_.xpath, 6918, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                    </div>
                                                </div>

                                            </div>
                                            <hr />
                                            <div class=""modal-footer"">

                                                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
");
            WriteLiteral("                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 124 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                   Write(Html.DisplayFor(modelItem => item.action));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 127 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                          
                            string showvalue = "dv" + @item.id_element.ToString();
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-custon-rounded-three btn-success btn-xs\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 129 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                                                                                       Write(showvalue);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Value</button>\r\n");
            WriteLiteral("                            <!-- Modal -->\r\n");
            WriteLiteral("                            <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 8183, "\"", 8198, 1);
#nullable restore
#line 133 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 8188, showvalue, 8188, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                                <div class=""center"">
                                    <div class=""modal-dialog modal-dialog-center"" role=""document"">
                                        <div class=""modal-content"">

                                            ");
#nullable restore
#line 138 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                       Write(Html.ValidationSummary(true, null, new { @class = "alert alert-block alert-danger fade in" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"" id=""exampleModalLabel"">Input Value</h5>
                                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Đóng"">
                                                    <span aria-hidden=""true"">&times;</span>
                                                </button>
                                            </div>
                                            <div class=""modal-body"">
                                                <div class=""row form-group"">
                                                    <div class=""col col-md-12"">");
#nullable restore
#line 147 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
                                                                          Write(Html.Label("Input value"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

                                                </div>
                                                <div class=""row form-group"">

                                                    <div class=""col-12 col-md-12"">
                                                        <input type=""text"" name=""idpost"" class=""input-md form-control""");
            BeginWriteAttribute("value", " value=\"", 9765, "\"", 9784, 1);
#nullable restore
#line 153 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
WriteAttributeValue("", 9773, item.value, 9773, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""modal-footer"">

                                                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
");
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 171 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\TestCase\Views\GenerateTestCases\TestData.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>
<br />
<br />
<script>


    $(document).ready(function () {
        $('#inputtable').DataTable(
            {
                ""lengthMenu"": [[10, 20, - 1], [10, 20, ""All record""]]
            }
        );
    });
    $('#modal').on('show.bs.modal', function () {
        $(this).find('.modal-body').css({
            width: 'auto', //probably not needed
            height: 'auto', //probably not needed
            'max-height': '100%'
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Input_testcase>> Html { get; private set; }
    }
}
#pragma warning restore 1591
