#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74d6e116080b99ad2bbe0be954d306dd44eb605e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Results_TestData), @"mvc.1.0.view", @"/Areas/User/Views/Results/TestData.cshtml")]
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
#line 1 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\_ViewImports.cshtml"
using Generate_TestCase_Selenium_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d6e116080b99ad2bbe0be954d306dd44eb605e", @"/Areas/User/Views/Results/TestData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Results_TestData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Input_Result_test>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Results", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResultDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_StatusMessage.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
  
    ViewData["Title"] = "TestData";
    Layout = "~/Views/Shared/_LayoutManage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Test Datas of test case ");
#nullable restore
#line 8 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                       Write(ViewBag.id_testcase);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<ol class=\"breadcrumb mb-4\">\r\n    <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74d6e116080b99ad2bbe0be954d306dd44eb605e5914", async() => {
                WriteLiteral("Results");
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
            WriteLiteral("</li>\r\n    <li class=\"breadcrumb-item\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74d6e116080b99ad2bbe0be954d306dd44eb605e7516", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                WriteLiteral(ViewBag.id_result);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n    <li class=\"breadcrumb-item active\">Test data</li>\r\n</ol>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "74d6e116080b99ad2bbe0be954d306dd44eb605e9847", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 14 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
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
            WriteLiteral(@"
<hr />
<div class=""card mb-4"">
    <div class=""card-header"">

        <div class=""row"">
            <div class=""col-2"">
                <i class=""fas fa-table mr-1""></i>Test data list
            </div>
            <div class=""col-10"">
                <div class=""container"">
                    <div class=""text-right"">

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-condensed table-hover table-bordered"" id=""inputtable"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>
                            ");
#nullable restore
#line 38 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                       Write(Html.DisplayName("Step"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 41 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                       Write(Html.DisplayName("Id element"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n                        <th>\r\n                            ");
#nullable restore
#line 45 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                       Write(Html.DisplayName("Action"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>Input value</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 51 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 55 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                           Write(item.step.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 58 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                  
                                    string detail = "d" + @item.id_element.ToString();
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-custon-rounded-three btn-primary btn-xs\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 60 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                                                                               Write(detail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 60 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                                                                                        Write(item.id_element);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
            WriteLiteral("                                    <!-- Modal -->\r\n");
            WriteLiteral("                                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 2475, "\"", 2487, 1);
#nullable restore
#line 64 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 2480, detail, 2480, 7, false);

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
#line 69 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
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
#line 78 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Id elemnet"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 4022, "\"", 4046, 1);
#nullable restore
#line 80 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 4030, item.id_element, 4030, 16, false);

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
#line 84 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 4593, "\"", 4615, 1);
#nullable restore
#line 86 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 4601, item.id_.name, 4601, 14, false);

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
#line 90 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Class Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 5170, "\"", 5198, 1);
#nullable restore
#line 92 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 5178, item.id_.class_name, 5178, 20, false);

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
#line 96 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Tag name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 5751, "\"", 5777, 1);
#nullable restore
#line 98 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 5759, item.id_.tag_name, 5759, 18, false);

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
#line 102 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Type"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 6326, "\"", 6348, 1);
#nullable restore
#line 104 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 6334, item.id_.type, 6334, 14, false);

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
#line 108 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Href"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 6897, "\"", 6919, 1);
#nullable restore
#line 110 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 6905, item.id_.href, 6905, 14, false);

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
#line 114 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Title"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 7469, "\"", 7492, 1);
#nullable restore
#line 116 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 7477, item.id_.title, 7477, 15, false);

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
#line 120 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                 Write(Html.Label("Xpath"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                            <div class=\"col-12 col-md-9\">\r\n                                                                <input type=\"text\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 8042, "\"", 8065, 1);
#nullable restore
#line 122 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 8050, item.id_.xpath, 8050, 15, false);

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
            WriteLiteral("                            </td>\r\n\r\n                            <td>\r\n                                ");
#nullable restore
#line 142 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                           Write(Html.DisplayFor(modelItem => item.action));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 145 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                  
                                    string showvalue = "dv" + @item.id_element.ToString();
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-custon-rounded-three btn-success btn-xs\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 147 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                                                                               Write(showvalue);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Value</button>\r\n");
            WriteLiteral("                                    <!-- Modal -->\r\n");
            WriteLiteral("                                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 9491, "\"", 9506, 1);
#nullable restore
#line 151 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 9496, showvalue, 9496, 10, false);

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
#line 156 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
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
#line 165 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                                                                                  Write(Html.Label("Input value"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

                                                        </div>
                                                        <div class=""row form-group"">

                                                            <div class=""col-12 col-md-12"">
                                                                <input type=""text"" name=""idpost"" class=""input-md form-control""");
            BeginWriteAttribute("value", " value=\"", 11209, "\"", 11228, 1);
#nullable restore
#line 171 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
WriteAttributeValue("", 11217, item.value, 11217, 11, false);

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
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 189 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\TestData.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Input_Result_test>> Html { get; private set; }
    }
}
#pragma warning restore 1591
