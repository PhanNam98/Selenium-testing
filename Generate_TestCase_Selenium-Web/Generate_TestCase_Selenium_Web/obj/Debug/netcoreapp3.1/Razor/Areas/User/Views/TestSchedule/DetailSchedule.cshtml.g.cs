#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1599e6f207c963ac7936e7e6ed9fd43bb59ef24b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_TestSchedule_DetailSchedule), @"mvc.1.0.view", @"/Areas/User/Views/TestSchedule/DetailSchedule.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1599e6f207c963ac7936e7e6ed9fd43bb59ef24b", @"/Areas/User/Views/TestSchedule/DetailSchedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_TestSchedule_DetailSchedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Testcase_scheduled>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TestSchedule", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_StatusMessage.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("moretescase"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("moretescase"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddMoreTestCase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
  
    ViewData["Title"] = "Detail Schedule";
    Layout = "~/Views/Shared/_LayoutManage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css"" />
<link rel=""stylesheet"" href=""https://cdn.datatables.net/fixedheader/3.1.7/css/fixedHeader.dataTables.min.css"" />
<script src=""https://code.jquery.com/jquery-3.5.1.js""></script>
<script src=""https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js""></script>
<script src=""https://cdn.datatables.net/fixedheader/3.1.7/js/dataTables.fixedHeader.min.js""></script>



<h2>Detail Schedule</h2>
<ol class=""breadcrumb mb-4"">
    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1599e6f207c963ac7936e7e6ed9fd43bb59ef24b7553", async() => {
                WriteLiteral("Test schedule");
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
            WriteLiteral(@"</li>
    <li class=""breadcrumb-item active"">Detail</li>
</ol>

<hr />
<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Delete test case</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                Are you sure you want to delete these test cases?
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-warning "" name=""delete"" id=""delete"" onclick=""submitDelete()"">Delete</button>
           ");
            WriteLiteral(" </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1599e6f207c963ac7936e7e6ed9fd43bb59ef24b10282", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 42 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
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
<div class=""card mb-4"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-3""><i class=""fas fa-table mr-1""></i>Test cases list</div>
            <div class=""col-9"">
                <div class=""container"">
                    <div class=""text-right"">
");
            WriteLiteral("                        <button type=\"button\" class=\"btn btn-warning\" data-toggle=\"modal\" data-target=\"#deleteModal\">\r\n                            Delete\r\n                        </button>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1599e6f207c963ac7936e7e6ed9fd43bb59ef24b12508", async() => {
                WriteLiteral("Add more");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-scheduleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                                                                            WriteLiteral(ViewBag.scheduleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["scheduleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-scheduleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["scheduleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                 WriteLiteral(ViewBag.id_url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_url"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id_url", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_url"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n    <div class=\"card-body\">\r\n\r\n");
#nullable restore
#line 64 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
         using (Html.BeginForm("ChangeTimeSchedule", "TestSchedule", FormMethod.Post, htmlAttributes: new { enctype = "multipart/form-data", @class = "dropzone dropzone-custom needsclick add-professors dz-clickable", @id = "timeform", @novalidate = "novalidate", @name = "timeform", @id_url = ViewBag.id_url }))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-5\">\r\n                    <input id=\"scheduleId\" name=\"scheduleId\"");
            BeginWriteAttribute("value", " value=\"", 3447, "\"", 3474, 1);
#nullable restore
#line 69 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 3455, ViewBag.scheduleId, 3455, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden readonly />\r\n                    <label for=\"time\">Job repeat time (between 0h and 23h):</label>\r\n                    <input type=\"number\" id=\"time\" name=\"time\" min=\"0\" max=\"23\"");
            BeginWriteAttribute("value", " value=\"", 3660, "\"", 3691, 1);
#nullable restore
#line 71 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 3668, ViewBag.TimeScheduleId, 3668, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><br><br>\r\n                </div>\r\n                <div class=\"col-2\">\r\n                            <button type=\"submit\" class=\"btn btn-primary\">Update</button>\r\n                        </div>\r\n            </div>\r\n");
#nullable restore
#line 77 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"


        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
         using (Html.BeginForm("DeleteTestcasesSchedule", "TestSchedule", FormMethod.Post, htmlAttributes: new { enctype = "multipart/form-data", @class = "dropzone dropzone-custom needsclick add-professors dz-clickable", @id = "testcaseform", @novalidate = "novalidate", @name = "testcaseform", @id_url = ViewBag.id_url }))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input id=\"scheduleId\" name=\"scheduleId\"");
            BeginWriteAttribute("value", " value=\"", 4311, "\"", 4338, 1);
#nullable restore
#line 82 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 4319, ViewBag.scheduleId, 4319, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden readonly />
            <div class=""table-responsive"">
                <table id=""testcasetable"" class=""table table-striped table-condensed table-hover table-bordered"">
                    <thead>
                        <tr>
                            <th><input type=""checkbox"" id=""checkall"" /></th>
                            <th>
                                ");
#nullable restore
#line 89 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                           Write(Html.DisplayName("Test case id"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 92 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                           Write(Html.DisplayName("Url id"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 98 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input type=\"checkbox\" name=\"list_Idtestcase\"");
            BeginWriteAttribute("id", " id=\"", 5285, "\"", 5307, 1);
#nullable restore
#line 102 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 5290, item.id_testcase, 5290, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5308, "\"", 5333, 1);
#nullable restore
#line 102 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 5316, item.id_testcase, 5316, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 105 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                               Write(Html.DisplayFor(modelItem => item.id_.id_testcase));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 108 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                               Write(Html.DisplayFor(modelItem => item.id_url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 111 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                      
                                        string detail = "d" + @item.id_testcase.ToString();
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-custon-rounded-three btn-success btn-xs\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 113 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                                                                                   Write(detail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Detail</button>\r\n");
#nullable restore
#line 114 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                        string description = "des" + @item.id_testcase.ToString();
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Modal -->\r\n");
            WriteLiteral("                                        <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 6271, "\"", 6283, 1);
#nullable restore
#line 117 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 6276, detail, 6276, 7, false);

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
#line 121 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                         using (Html.BeginForm("UpdateTestcase", "GenerateTestCases", FormMethod.Post, htmlAttributes: new { enctype = "multipart/form-data", @class = "dropzone dropzone-custom needsclick add-professors dz-clickable", @id = detail, @novalidate = "novalidate", @name = "updatetestcase" }))
                                                        {
                                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                       Write(Html.ValidationSummary(true, null, new { @class = "alert alert-block alert-danger fade in" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""modal-header"">
                                                                <h5 class=""modal-title"" id=""exampleModalLabel"">Detail Test case</h5>
                                                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Đóng"">
                                                                    <span aria-hidden=""true"">&times;</span>
                                                                </button>
                                                            </div>
                                                            <div class=""modal-body"">
                                                                <input id=""id_url"" name=""id_url""");
            BeginWriteAttribute("value", " value=\"", 7979, "\"", 8002, 1);
#nullable restore
#line 131 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 7987, ViewBag.id_url, 7987, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden readonly />\r\n                                                                <div class=\"row form-group\">\r\n                                                                    <div class=\"col col-md-3\">");
#nullable restore
#line 133 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                         Write(Html.Label("Id testcase"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                                    <div class=\"col-12 col-md-9\">\r\n                                                                        <input type=\"text\" name=\"id_testcase\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 8484, "\"", 8513, 1);
#nullable restore
#line 135 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 8492, item.id_.id_testcase, 8492, 21, false);

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
#line 139 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                         Write(Html.Label("Description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                                    <div class=\"col-12 col-md-9\">\r\n                                                                        <input type=\"text\" name=\"description\"");
            BeginWriteAttribute("id", " id=\"", 9104, "\"", 9121, 1);
#nullable restore
#line 141 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 9109, description, 9109, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 9152, "\"", 9181, 1);
#nullable restore
#line 141 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 9160, item.id_.description, 9160, 21, false);

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
#line 146 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                         Write(Html.Label("CreatedDate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                                    <div class=\"col-12 col-md-9\">\r\n                                                                        <input type=\"text\" name=\"CreatedDate\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 9806, "\"", 9835, 1);
#nullable restore
#line 148 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 9814, item.id_.CreatedDate, 9814, 21, false);

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
#line 152 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                                                                                         Write(Html.Label("ModifiedDate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                                    <div class=\"col-12 col-md-9\">\r\n                                                                        <input type=\"text\" name=\"ModifiedDate\" class=\"input-md form-control\"");
            BeginWriteAttribute("value", " value=\"", 10460, "\"", 10490, 1);
#nullable restore
#line 154 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
WriteAttributeValue("", 10468, item.id_.ModifiedDate, 10468, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly />
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <div class=""modal-footer"">


                                                                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                                            </div>
");
#nullable restore
#line 165 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"

                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 174 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n            </div>\r\n");
#nullable restore
#line 179 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\TestSchedule\DetailSchedule.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<script type=""text/javascript"">


    $(document).ready(function () {
        var table = $('#testcasetable').DataTable(
            {
                ""lengthMenu"": [[10, 25, 50, - 1], [10, 25, 50, ""All record""]],
                ""scrollY"": ""500px"",
                ""scrollCollapse"": true,
                ""paging"": false,
                ""searching"": false,

            }
        );

    });
    function submitDelete() {
        if (document.getElementsByName(""list_Idtestcase"").length <= 0) {
            alert(""No test case have been selected"");
        }
        else {


            document.getElementById(""testcaseform"").submit();
        }
    };


    $(function () {
        $(""#checkall"").click(function () {
            $(""input[name='list_Idtestcase']"").prop(""checked"", this.checked);

            $(""input[name='list_Idtestcase']"").click(function () {
                if ($(""input[name='list_Idtestcase']"").length == $(""input[name='list_Idtestcase']:che");
            WriteLiteral(@"cked"").length) {
                    $(""#checkall"").prop(""checked"", ""checked"");
                }
                else {
                    $(""#checkall"").prop(""checked"", false);
                }
            });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Testcase_scheduled>> Html { get; private set; }
    }
}
#pragma warning restore 1591
