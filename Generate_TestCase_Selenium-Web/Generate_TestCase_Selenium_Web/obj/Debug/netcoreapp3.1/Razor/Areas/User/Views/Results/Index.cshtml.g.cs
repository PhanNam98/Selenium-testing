#pragma checksum "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d04dd81bd5e42a138551a120120592bf7171224d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Results_Index), @"mvc.1.0.view", @"/Areas/User/Views/Results/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d04dd81bd5e42a138551a120120592bf7171224d", @"/Areas/User/Views/Results/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d260bb0ae66002328ebfb4fb6c01df819a63b6", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Results_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Running_process>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResultDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
  
    ViewData["Title"] = "Result";
    Layout = "~/Views/Shared/_LayoutManage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Result</h2>
<ol class=""breadcrumb mb-4"">
    <li class=""breadcrumb-item active"">Result</li>
</ol>
<div class=""card mb-4"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-3""><i class=""fas fa-table mr-1""></i>Process</div>
            <div class=""col-9"">
                <div class=""container"">
                    <div class=""text-right"">

                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table id=""resulttable"" class=""table table-striped table-condensed table-hover table-bordered"">
                <thead>
                    <tr>
");
            WriteLiteral("                        <th>\r\n                            ");
#nullable restore
#line 35 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                       Write(Html.DisplayName("id"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 38 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                       Write(Html.DisplayName("date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n");
            WriteLiteral("                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 53 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n");
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 60 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.id_process));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 63 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.end_time));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("                            <td>\r\n");
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d04dd81bd5e42a138551a120120592bf7171224d8002", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
                                                               WriteLiteral(item.id_process);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 80 "D:\downloads\Programing\Selenium\Selenium-testing\Generate_TestCase_Selenium-Web\Generate_TestCase_Selenium_Web\Areas\User\Views\Results\Index.cshtml"
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
            $('#resulttable').DataTable(
                {
                    ""lengthMenu"": [[10, 25, 50, - 1], [10, 25, 50, ""All record""]],
                    ""ordering"": false,


                }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Generate_TestCase_Selenium_Web.Models.ModelDB.Running_process>> Html { get; private set; }
    }
}
#pragma warning restore 1591
