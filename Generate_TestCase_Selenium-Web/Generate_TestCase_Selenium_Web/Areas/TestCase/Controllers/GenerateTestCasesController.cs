using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Microsoft.AspNetCore.Routing;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Identity;
using Generate_TestCase_Selenium_Web.Areas.TestCase.Models;
using System.Data;
using FastMember;
using OfficeOpenXml;
using System.IO;
using Generate_TestCase_Selenium_Web.Models.Constants;
using Generate_TestCase_Selenium_Web.Models.Mail;
using OfficeOpenXml.Style;
using System.Drawing;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using Coravel.Queuing.Interfaces;
using Quartz;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class GenerateTestCasesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ElementDBContext _context;
        private int Id_Url;
        private List<Test_case> ListTestCase;
        private List<List<Input_testcase>> List_ListInputTestcase;
        private List<string> listSpecialCharacter;
        private string browserRun;
        private readonly IQueue _queue;
        private readonly ILogger<GenerateTestCasesController> _logger;
        private readonly IHubContext<JobProgressHub> _hubContext;
        private int Prerequisite_url = -1;
        private string Prerequisite_testcase = null;
        IScheduler _scheduler;
        //private ChromeDriver chromedriver;
        [TempData]
        public string StatusMessage { get; set; }

        private enum Actions
        {
            fill,
            click,
            select,
            submit,
            check,
            notcheck
        }
        public GenerateTestCasesController(UserManager<ApplicationUser> userManager, ILogger<GenerateTestCasesController> logger, IQueue queue, IHubContext<JobProgressHub> hubContext)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
            _logger = logger;
            // _scheduler = scheduler;
            _queue = queue;
            _hubContext = hubContext;
            Setup();
        }

        //GET: TestCase/id_url/isload
        [Route("/TestCase/{id_url?}/{isload?}")]
        public async Task<IActionResult> Index(int id_url, bool isload = false)
        {
            ViewData["Message"] = StatusMessage;
            //if(StatusMessage!=null)
            //TempData.Remove(StatusMessage);
            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                ViewData["id_url"] = id_url;
                var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Include(e=>e.Element_test).Include(a=>a.Alert_message).Include(r=>r.Redirect_url).Where(p => p.id_url == id_url).OrderBy(p=>p.TestType).ToListAsync();
                if (ViewData["Message"] == null)
                {
                    if (!isload)
                    {
                        if (testcaseDBContext.Count() == 0)
                        {
                            ViewData["Message"] = "No test case yet";
                        }
                        else
                      if (testcaseDBContext.Count() > 0)
                        {
                            ViewData["Message"] = String.Format("Success, {0} test case(s) were created", testcaseDBContext.Count());
                        }

                        else
                        {
                            ViewData["Message"] = "Error load data";
                        }
                    }
                    else
                        ViewData["Message"] = null;
                }

                ViewData["LoadingTitle"] = "Running test case. Please wait.";
                return View(testcaseDBContext);
            }

            return NotFound();


        }
        // not use. but not delete
        public async Task<IActionResult> Result(int id_url)
        {
            ViewData["id_url"] = id_url;
            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url).ToListAsync();

                //  if (testcaseDBContext.Count() == 0)
                //  {
                //      ViewData["Message"] = "No testcase yet";
                //  }
                //  else
                //if (testcaseDBContext.Count() > 0)
                //  {
                //      ViewData["Message"] = String.Format("Success, {0} test case(s) were fo", testcaseDBContext.Count());
                //  }

                //  else
                //  {
                //      ViewData["Message"] = "Error load data";
                //  }

                ViewData["Pass"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("pass")).Count();
                ViewData["Skip"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("skip")).Count();
                ViewData["Failure"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("failure")).Count();
                return View(testcaseDBContext);
            }
            return NotFound();

        }
        private void Setup()
        {

            listSpecialCharacter = new List<string>();
            listSpecialCharacter.Add("!");
            listSpecialCharacter.Add("#");
            listSpecialCharacter.Add("$");
            listSpecialCharacter.Add("%");
            listSpecialCharacter.Add("&");
            listSpecialCharacter.Add("^");
            listSpecialCharacter.Add("|");
            listSpecialCharacter.Add(@"\");
            listSpecialCharacter.Add("/");
            listSpecialCharacter.Add("=");
            listSpecialCharacter.Add("?");
            listSpecialCharacter.Add(";");
            listSpecialCharacter.Add(">");
            listSpecialCharacter.Add("<");
            listSpecialCharacter.Add("-");
            listSpecialCharacter.Add("*");
            listSpecialCharacter.Add("+");
            listSpecialCharacter.Add("{");
            listSpecialCharacter.Add("}");
            listSpecialCharacter.Add("(");
            listSpecialCharacter.Add(")");

        }

        public async Task<IActionResult> Generate_testcase(int id_url, string returnUrl = null)
        {
            Id_Url = id_url;
            ListTestCase = new List<Test_case>();
            List_ListInputTestcase = new List<List<Input_testcase>>();
            List<Form_elements> forms = await _context.Form_elements.Where(p => p.id_url == Id_Url).ToListAsync();
            if (forms.Count > 0)
            {
                for (int i = 0; i < forms.Count; i++)
                {
                    var _context1 = new ElementDBContext();
                    List<Element> submit = await _context1.Element.Where(p => p.id_url == Id_Url && p.id_form == forms[i].id_form && p.type == "submit").ToListAsync();
                    for (int j = 0; j < submit.Count; j++)
                    {

                        await NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                        await Input_Type_Email(forms[i].id_form, j, submit[j]);
                        await Input_Type_Text(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                        await SelectAllElement_TypeSelect(forms[i].id_form, j, submit[j]);
                        await SkipOneSelect_TypeSelect(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                        await Input_Type_Password(forms[i].id_form, j, submit[j]);
                        await Click_Any_CheckBox_TypeCheckBox(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeCheckBox(forms[i].id_form, j, submit[j]);
                        await Input_Type_TypeDate(forms[i].id_form, j, submit[j]);
                        await Input_Type_TypeNumber(forms[i].id_form, j, submit[j]);
                        await Fill_Form(forms[i].id_form, j, submit[j]);
                    }
                }
                //await ClickAll_Tag_a();
                //await ClickAll_Tag_Button();
            }
            else
            {
                //not form
                var _context1 = new ElementDBContext();
                List<Element> submit = await _context1.Element.Where(p => p.id_url == Id_Url && p.type == "submit").ToListAsync();
                for (int j = 0; j < submit.Count; j++)
                {

                    await NotFill_ClickSubmit(null, j, submit[j]);
                    await Input_Type_Email(null, j, submit[j]);
                    await Input_Type_Text(null, j, submit[j]);
                    await ClickAll_TypeRadio(null, j, submit[j]);
                    await SelectAllElement_TypeSelect(null, j, submit[j]);
                    await SkipOneSelect_TypeSelect(null, j, submit[j]);
                    await ClickAll_TypeRadio(null, j, submit[j]);
                    await Input_Type_Password(null, j, submit[j]);
                    await Click_Any_CheckBox_TypeCheckBox(null, j, submit[j]);
                    await ClickAll_TypeCheckBox(null, j, submit[j]);
                    await Input_Type_TypeDate(null, j, submit[j]);
                    await Input_Type_TypeNumber(null, j, submit[j]);
                    await Fill_Form(null, j, submit[j]);
                }


            }
            await ClickAll_Tag_a();
            await ClickAll_Tag_Button();

            _context.Test_case.AddRange(ListTestCase);
            _context.SaveChanges();

            foreach (var inputtest in List_ListInputTestcase)
            {
                _context.Input_testcase.AddRange(inputtest);

            }
            if (_context.SaveChanges() > 0)
            {
                StatusMessage = String.Format("Success, {0} test case(s) were created", ListTestCase.Count());
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { id_url = id_url }));
                }
            }

            return RedirectToAction(nameof(Index), new RouteValueDictionary(new { id_url = id_url }));


        }
        public async Task<IActionResult> Generate_Subtestcase(int id_url, int prerequisite_url, string prerequisite_testcase, string returnUrl = null)
        {
            Id_Url = id_url;
            ListTestCase = new List<Test_case>();
            List_ListInputTestcase = new List<List<Input_testcase>>();
            List<Form_elements> forms = await _context.Form_elements.Where(p => p.id_url == Id_Url).ToListAsync();
            this.Prerequisite_url = prerequisite_url;
            this.Prerequisite_testcase = prerequisite_testcase;
            if (forms.Count > 0)
            {
                for (int i = 0; i < forms.Count; i++)
                {
                    var _context1 = new ElementDBContext();
                    List<Element> submit = await _context1.Element.Where(p => p.id_url == Id_Url && p.id_form == forms[i].id_form && p.type == "submit").ToListAsync();
                    for (int j = 0; j < submit.Count; j++)
                    {
                        await NotFill_ClickSubmit(forms[i].id_form, j, submit[j]);
                        await Input_Type_Email(forms[i].id_form, j, submit[j]);
                        await Input_Type_Text(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                        await SelectAllElement_TypeSelect(forms[i].id_form, j, submit[j]);
                        await SkipOneSelect_TypeSelect(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeRadio(forms[i].id_form, j, submit[j]);
                        await Input_Type_Password(forms[i].id_form, j, submit[j]);
                        await Click_Any_CheckBox_TypeCheckBox(forms[i].id_form, j, submit[j]);
                        await ClickAll_TypeCheckBox(forms[i].id_form, j, submit[j]);
                        await Input_Type_TypeDate(forms[i].id_form, j, submit[j]);
                        await Input_Type_TypeNumber(forms[i].id_form, j, submit[j]);
                        await Fill_Form(forms[i].id_form, j, submit[j]);
                    }
                }
                //await ClickAll_Tag_a();
                //await ClickAll_Tag_Button();
            }
            else
            {
                //not form
                var _context1 = new ElementDBContext();
                List<Element> submit = await _context1.Element.Where(p => p.id_url == Id_Url && p.type == "submit").ToListAsync();
                for (int j = 0; j < submit.Count; j++)
                {

                    await NotFill_ClickSubmit(null, j, submit[j]);
                    await Input_Type_Email(null, j, submit[j]);
                    await Input_Type_Text(null, j, submit[j]);
                    await ClickAll_TypeRadio(null, j, submit[j]);
                    await SelectAllElement_TypeSelect(null, j, submit[j]);
                    await SkipOneSelect_TypeSelect(null, j, submit[j]);
                    await ClickAll_TypeRadio(null, j, submit[j]);
                    await Input_Type_Password(null, j, submit[j]);
                    await Click_Any_CheckBox_TypeCheckBox(null, j, submit[j]);
                    await ClickAll_TypeCheckBox(null, j, submit[j]);
                    await Input_Type_TypeDate(null, j, submit[j]);
                    await Input_Type_TypeNumber(null, j, submit[j]);
                    await Fill_Form(null, j, submit[j]);
                }
            }
            await ClickAll_Tag_a();
            await ClickAll_Tag_Button();

            _context.Test_case.AddRange(ListTestCase);
            await _context.SaveChangesAsync();

            foreach (var inputtest in List_ListInputTestcase)
            {
                _context.Input_testcase.AddRange(inputtest);

            }
            if (_context.SaveChanges() > 0)
            {
                StatusMessage = String.Format("Success, {0} test case(s) were created", ListTestCase.Count());
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new { id_url = id_url }));
                }
            }

            return RedirectToAction(nameof(Index), new RouteValueDictionary(new { id_url = id_url }));


        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateTestcase(int id_url, string id_testcase, string description)
        {

            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                var testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                if (testcase == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        testcase.ModifiedDate = DateTime.Now.Date;
                        testcase.description = description;
                        _context.Update(testcase);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Update successfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!Test_caseExists(testcase.id_testcase))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return Json(new { Result = "OK", Message = "Success" });
                    //return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
                }
                StatusMessage = "Update fail";
                return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteTestcases(int id_url, string[] List_id_testcase)
        {

            var id = _userManager.GetUserId(User);
            List<string> List_id_testcases = List_id_testcase.ToList();
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                //var _context = new ElementDBContext();
                var testcase = await _context.Test_case.Include(p => p.Input_testcase).Where(p => List_id_testcase.Contains(p.id_testcase) && p.id_url == id_url).ToListAsync();
                if (testcase == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        foreach (var t in testcase)
                        {
                            _context.Input_testcase.RemoveRange(t.Input_testcase);
                        }
                        foreach (var t in testcase)
                        {
                            _context.Element_test.RemoveRange(t.Element_test);
                        }
                        _context.Test_case.RemoveRange(testcase);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Delete successfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        StatusMessage = "Delete fail";
                        return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
                    }
                    return Json(new { Result = "OK", Message = "Success" });
                    //return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
                }
                StatusMessage = "Delete fail";
                return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
            }
            return NotFound();

        }

        #region Test case 

        #region Input Type Text
        private async Task<bool> Input_Type_Text(string id_form, int index_submit, Element submit)
        {
            var a = Fill_1000_charter_TypeText(id_form, index_submit, submit);
            var a1 = Fill_Text_TypeText(id_form, index_submit, submit);
            var a2 = Fill_out_1_Field_Blank_TypeText(id_form, index_submit, submit);
            var a3 = Fill_Text_Two_Leading_Spaces_TypeText(id_form, index_submit, submit);
            var a4 = Fill_One_letter_characters_TypeText(id_form, index_submit, submit);
            var a5 = Fill_Text_Number_TypeText(id_form, index_submit, submit);
            var a6 = Fill_Text_Number_Special_TypeText(id_form, index_submit, submit);
            var result = await a;
            var result1 = await a1;
            var result2 = await a2;
            var result3 = await a3;
            var result4 = await a4;
            var result5 = await a5;
            var result6 = await a6;
            return true;
            //return result && result1;
            //Task<bool> firstFinishedTask = await Task.WaitAll(runTasks);
        }
        private async Task<bool> Fill_1000_charter_TypeText(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "Fill 1000 character for all element TypeText_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill 1000 character for all element TypeText_" + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypeText = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypeText.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeText.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1000), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_Text_TypeText(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "Fill text for all element TypeTest_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill text for all element TypeTest_" + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_out_1_Field_Blank_TypeText(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            var listTypeText = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "text" && p.tag_name == "input").ToListAsync();

            int number_of_elements = listTypeText.Count;

            if (number_of_elements > 1)
            {

                for (int i = 0; i < number_of_elements; i++)
                {
                    string DescriptiontestCase = $"Not fill {listTypeText[i].id_element} -TypeText-form:" + id_form + "_" + index_submit + "_" + i;
                    if(id_form==null)
                    {
                        DescriptiontestCase = $"Not fill {listTypeText[i].id_element} -TypeText_" + "_" + index_submit + "_" + i;
                    }
                    var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                    List<Input_testcase> listInputElt = new List<Input_testcase>();
                    int step = 1;
                    for (int j = 0; j < number_of_elements; j++)
                    {
                        if (i == j)
                        {
                            listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase, "", Actions.fill.ToString(), step++));
                        }
                        else
                        {
                            Random random = new Random();
                            listInputElt.Add(Crate_InputTestcase(listTypeText[j], id_testCase, Generate_RandomString(random, 8), Actions.fill.ToString(), step++));
                        }


                    }
                    listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                    List_ListInputTestcase.Add(listInputElt);

                }
                return true;
            }
            return false;

        }
        private async Task<bool> Fill_Text_Two_Leading_Spaces_TypeText(string id_form, int index_submit, Element submit)
        {


            string DescriptiontestCase = "Fill Two Leading Spaces TypeText_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill Two Leading Spaces TypeText_" + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, " " + Generate_RandomString(random, 8) + " ", Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_One_letter_characters_TypeText(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "Fill one character TypeText_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill one character TypeText_"  + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text") ;
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, 1), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_Text_Number_TypeText(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "Fill text and number character TypeText_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill text and number character TypeText_"  + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, 6) + Generate_RandomNumber(random, 0, 100) + Generate_RandomString(random, 3), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_Text_Number_Special_TypeText(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "Fill text, number and special character TypeText_form:" + id_form + "_" + index_submit;
            if(id_form==null)
            {
                DescriptiontestCase = "";
                DescriptiontestCase = "Fill text, number and special character TypeText_"  + index_submit;
            }
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "text").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type text");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomStringNumberSpecialString(random), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion

        #region Not Fill, Submit
        private async Task<bool> NotFill_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
                if(id_form!=null)
            {
                DescriptiontestCase = "Not fill form, click submit-formId:" + id_form + "_" + index_submit;
            }
                else
            DescriptiontestCase = "Not fill data, click submit-" + index_submit;
            var _context = new ElementDBContext();
            int step = 1;
            var id_testCase = Create_Testcase(DescriptiontestCase,"");
            List<Input_testcase> listInputElt = new List<Input_testcase>();
            listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

            List_ListInputTestcase.Add(listInputElt);
            return true;

        }
        #endregion

        #region Input Type Email
        private async Task Input_Type_Email(string id_form, int index_submit, Element submit)
        {
            var a = Fill_Not_Format_Email_TypeEmail(id_form, index_submit, submit);
            var a1 = Fill_Not_Email_TypeEmail(id_form, index_submit, submit);
            var a2 = Fill_Format_Email_TypeEmail(id_form, index_submit, submit);
            var a3 = Fill_Special_characters_TypeEmail_TypeEmail(id_form, index_submit, submit);

            List<Task<bool>> runTasks = new List<Task<bool>>();
            runTasks.Add(a);
            runTasks.Add(a1);
            runTasks.Add(a2);
            runTasks.Add(a3);

            while (runTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<bool> firstFinishedTask = await Task.WhenAny(runTasks);
                runTasks.Remove(firstFinishedTask);
                // Await the completed task.


            }

        }
        public async Task<bool> Fill_Not_Format_Email_TypeEmail(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Fill incorrect email format TypeEmail_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill incorrect email format TypeEmail_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeEmail = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "email" && p.tag_name == "input").ToListAsync();
            if (listTypeEmail.Count > 0)
            {
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type email");
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeEmail.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeEmail[i], id_testCase, Generate_RandomString(random, 5) + "@" + Generate_RandomString(random, 4), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }

            return false;
        }
        public async Task<bool> Fill_Not_Email_TypeEmail(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill incorrect email format TypeEmail_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill incorrect email format TypeEmail_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeEmail = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "email" && p.tag_name == "input").ToListAsync();
            if (listTypeEmail.Count > 0)
            {

                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type email");
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                int step = 1;
                for (int i = 0; i < listTypeEmail.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeEmail[i], id_testCase, Generate_RandomString(random, 5) + Generate_RandomNumber(random, 0, 100) + Generate_RandomString(random, 2), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }

            return false;
        }
        public async Task<bool> Fill_Format_Email_TypeEmail(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Fill email TypeEmail_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill email TypeEmail_" + index_submit;
            var listTypeEmail = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "email" && p.tag_name == "input").ToListAsync();
            int step = 1;
            if (listTypeEmail.Count > 0)
            {
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type email");
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                for (int i = 0; i < listTypeEmail.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeEmail[i], id_testCase, Generate_RandomEmail(), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));
                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Special_characters_TypeEmail_TypeEmail(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!="")
            DescriptiontestCase = "Fill email with special characters  TypeEmail_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill email with special characters  TypeEmail" + "_" + index_submit;
            var listTypeEmail = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type == "email" && p.tag_name == "input").ToListAsync();
            int step = 1;
            if (listTypeEmail.Count > 0)
            {
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type email");
                List<Input_testcase> listInputElt = new List<Input_testcase>();
                for (int i = 0; i < listTypeEmail.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeEmail[i], id_testCase, Generate_RandomString(random, 1) + Generate_RandomSpecialString(random, 1) + Generate_RandomEmail(), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));
                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion

        #region Input Type Radio
        public async Task<bool> ClickAll_TypeRadio(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Click All element TypeRadio_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Click All element TypeRadio_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeRadio = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "radio").ToListAsync();



            //for (int i = 0; i < listTypeRadio.Count; i++)
            //{
            //    Input_testcase newinput = new Input_testcase();
            //    newinput.id_element = listTypeRadio[i].id_element;
            //    newinput.id_testcase = id_testCase;
            //    newinput.id_url = Id_Url;
            //    newinput.value = "";
            //    newinput.action = "select";
            //    newinput.xpath = listTypeRadio[i].xpath;
            //    listInputElt.Add(newinput);
            //}

            if (listTypeRadio.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type radio");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                List<List<Element>> listRadio = new List<List<Element>>();
                List<Element> listEltRadio = new List<Element>();
                var groupedRadioList = listTypeRadio
                .GroupBy(u => u.name)
                .Select(grp => grp.ToList())
                .ToList();
                foreach (var group in groupedRadioList)
                {

                    Input_testcase newinput = new Input_testcase();
                    Random random = new Random();
                    Element radio = group[random.Next(0, group.Count)];


                    listInputElt.Add(Crate_InputTestcase(radio, id_testCase, "", Actions.click.ToString(), step++));

                }

                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;

        }

        #endregion

        #region Input Type Password
        private async Task Input_Type_Password(string id_form, int index_submit, Element submit)
        {
            var a = Fill_1000_character_TypePassword_ClickSubmit(id_form, index_submit, submit);
            var a1 = Fill_Less_Than_8_character_TypePassword_ClickSubmit(id_form, index_submit, submit);
            var a2 = Fill__Special_character_TypePassword_ClickSubmit(id_form, index_submit, submit);
            var a3 = Fill__Capital_Number_Special_character_TypePassword_ClickSubmit(id_form, index_submit, submit);

            List<Task<bool>> runTasks = new List<Task<bool>>();
            runTasks.Add(a);
            runTasks.Add(a1);
            runTasks.Add(a2);
            runTasks.Add(a3);

            while (runTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<bool> firstFinishedTask = await Task.WhenAny(runTasks);
                runTasks.Remove(firstFinishedTask);
                // Await the completed task.


            }

        }
        private async Task<bool> Fill_1000_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill 1000 character for all element TypePassword_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill 1000 character for all element TypePassword_" + index_submit;
              
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "password").ToListAsync();

            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type password");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, 1000), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill_Less_Than_8_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill less 8 character for all element TypePassword_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill less 8 character for all element TypePassword_" + index_submit;
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "password").ToListAsync();
            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type password");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    int num = random.Next(6, 8);
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, num), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill__Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill data Contains Special character for all element TypePassword_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill data Contains Special character for all element TypePassword_" + index_submit;
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "password").ToListAsync();
            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type password");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    int num = random.Next(6, 8);
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, num) + Generate_RandomSpecialString(random, 1) + Generate_RandomString(random, 2), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill__Number_Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill data Contains number, special character for all element TypePassword _form: " + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill data Contains number, special character for all element TypePassword_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "password").ToListAsync();
            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type password");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    int num = random.Next(6, 8);
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomString(random, num) + Generate_RandomNumber(0, 100) +
                        Generate_RandomSpecialString(random, 1) + Generate_RandomString(random, 2), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        private async Task<bool> Fill__Capital_Number_Special_character_TypePassword_ClickSubmit(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill data Contains number, special, Capital character for all element TypePassword _form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill data Contains number, special, Capital character for all element TypePassword_" + index_submit;
            var _context = new ElementDBContext();
            var listTypePass = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "password").ToListAsync();
            if (listTypePass.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase);
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypePass.Count; i++)
                {
                    Random random = new Random();
                    int num = random.Next(6, 8);
                    listInputElt.Add(Crate_InputTestcase(listTypePass[i], id_testCase, Generate_RandomPassword(), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion

        #region Input CheckBox
        public async Task<bool> Click_Any_CheckBox_TypeCheckBox(string id_form, int index_submit, Element submit)
        {

            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Click some CheckBox element TypeCkeckBox_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Click some CheckBox element TypeCkeckBox_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeCheckbox = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "checkbox").ToListAsync();
            if (listTypeCheckbox.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type checkbox");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeCheckbox.Count; i++)
                {
                    Random random = new Random();
                    int ramdomnumber = random.Next(0, 2);
                    if (ramdomnumber == 1)
                        listInputElt.Add(Crate_InputTestcase(listTypeCheckbox[i], id_testCase, "true", Actions.check.ToString(), step++));
                    else
                        listInputElt.Add(Crate_InputTestcase(listTypeCheckbox[i], id_testCase, "false", Actions.notcheck.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> ClickAll_TypeCheckBox(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Click all element TypeCkeckBox_form:" + id_form + "_" + index_submit;
            else

                DescriptiontestCase = "Click all element TypeCkeckBox_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeCheckbox = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "checkbox").ToListAsync();
            if (listTypeCheckbox.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type checkbox");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeCheckbox.Count; i++)
                {

                    listInputElt.Add(Crate_InputTestcase(listTypeCheckbox[i], id_testCase, "true", Actions.check.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion

        #region Input Type Date
        private async Task Input_Type_TypeDate(string id_form, int index_submit, Element submit)
        {
            var a = Fill_Only_Day_TypeDate(id_form, index_submit, submit);
            var a1 = Fill_Only_Month_TypeDate(id_form, index_submit, submit);
            var a2 = Fill_Only_Year_TypeDate(id_form, index_submit, submit);
            var a3 = Fill_Incorrect_format_TypeDate(id_form, index_submit, submit);
            var a4 = Fill_OverDayInMonth_TypeDate(id_form, index_submit, submit);
            var a5 = Fill_OverMonthInYear_TypeDate(id_form, index_submit, submit);
            var a6 = Fill_LeapYear_TypeDate(id_form, index_submit, submit);
            var a7 = Fill_No_profitYear_TypeDate(id_form, index_submit, submit);
            var a8 = Fill_Day31InMonth_TypeDate(id_form, index_submit, submit);
            var a9 = Fill_NotDay31InMonth_TypeDate(id_form, index_submit, submit);

            List<Task<bool>> runTasks = new List<Task<bool>>();
            runTasks.Add(a);
            runTasks.Add(a1);
            runTasks.Add(a2);
            runTasks.Add(a3);
            runTasks.Add(a4);
            runTasks.Add(a5);
            runTasks.Add(a6);
            runTasks.Add(a7);
            runTasks.Add(a8);
            runTasks.Add(a9);


            while (runTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<bool> firstFinishedTask = await Task.WhenAny(runTasks);
                runTasks.Remove(firstFinishedTask);
                // Await the completed task.


            }

        }
        public async Task<bool> Fill_Only_Day_TypeDate(string id_form, int index_submit, Element submit)
        {

            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Only fill day of element TypeDate_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Only fill day of element TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, "0000-00" + Generate_RandomNumber(random, 1, 32).ToString(), Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Only_Month_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
                 DescriptiontestCase = "Only fill month of element TypeDate_form" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Only fill month of element TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, "0000-" + Generate_RandomNumber(random, 1, 13).ToString() + "-00", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Only_Year_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Only fill year of element TypeDate_form" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Only fill year of element TypeDate_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(random, 1900, (int)DateTime.Now.Year + 1).ToString() + "-00-00", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Incorrect_format_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
                DescriptiontestCase = "Fill the wrong format TypeDate_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill the wrong format TypeDate_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(random, 1990, (int)DateTime.Now.Year) + "," + Generate_RandomNumber(random, 1, 32).ToString() + "," + Generate_RandomNumber(random, 1, 13), Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_OverDayInMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
                if(id_form!=null)
             DescriptiontestCase = "Fill Over Day In Month - TypeDate_form:" + id_form + "_" + index_submit;
                else
            DescriptiontestCase = "Fill Over Day In Month - TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(1990, (int)DateTime.Now.Year) + "-" + Generate_RandomNumber(1, 12) + "-" + 32, Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_OverMonthInYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill Over Day In Year - TypeDate_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill Over Day In Year - TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(1990, (int)DateTime.Now.Year) + "-" + 13 + "-" + Generate_RandomNumber(1, 32), Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_LeapYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill LeapYear - TypeDate_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill LeapYear - TypeDate_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, "1996-02-29", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_No_profitYear_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill  No profit year - TypeDate_form: " + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill  No profit year - TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, "1998-11-05", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Day31InMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill Day 31 In Month - TypeDate_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill Day 31 In Month - TypeDate_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(random, 1990, DateTime.Now.Year) + "-05-31", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_NotDay31InMonth_TypeDate(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Fill Day 31 In Month have 30 day - TypeDate_form:" + id_form + "_" + index_submit;
            else
                 DescriptiontestCase = "Fill Day 31 In Month have 30 day - TypeDate_"  + index_submit;
            var _context = new ElementDBContext();
            var listTypeDate = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "date").ToListAsync();
            if (listTypeDate.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Date");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeDate.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeDate[i], id_testCase, Generate_RandomNumber(random, 1990, DateTime.Now.Year) + "-04-31", Actions.fill.ToString(), step++));


                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion

        #region Tag a
        public async Task<bool> ClickAll_Tag_a()
        {
            var _context = new ElementDBContext();
            var listTaga = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "a").ToListAsync();

            if (listTaga.Count > 0)
            {
                for (int i = 0; i < listTaga.Count; i++)
                {
                    int step = 1;
                    string DescriptiontestCase = "Click Tag a:" + listTaga[i].id_element.ToString();
                    var id_testCase = Create_Testcase(DescriptiontestCase,"Tag a");
                    List<Input_testcase> listInputElt = new List<Input_testcase>();

                    listInputElt.Add(Crate_InputTestcase(listTaga[i], id_testCase, "", Actions.click.ToString(), step++));
                    List_ListInputTestcase.Add(listInputElt);
                }
                return true;
            }
            return false;

        }
        #endregion

        #region Tag Button
        public async Task<bool> ClickAll_Tag_Button()
        {
            var _context = new ElementDBContext();
            string DescriptionScript = "Click  element tag button: ";
            var listTaga = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "button" && p.type != "submit").ToListAsync();

            if (listTaga.Count > 0)
            {
                for (int i = 0; i < listTaga.Count; i++)
                {
                    int step = 1;
                    string DescriptiontestCase = DescriptionScript + listTaga[i].id_element.ToString();
                    var id_testCase = Create_Testcase(DescriptiontestCase,"Button");
                    List<Input_testcase> listInputElt = new List<Input_testcase>();

                    listInputElt.Add(Crate_InputTestcase(listTaga[i], id_testCase, "", Actions.click.ToString(), step++));
                    List_ListInputTestcase.Add(listInputElt);
                }
                return true;
            }
            return false;

        }
        #endregion

        #region Select
        //public async Task<bool> NotSelect_TypeSelect(string id_form, int index_submit, Element submit)
        //{
        //    string id_testCase = "Not Select-TypeSelect" + id_form + "_" + index_submit;
        //    var _context = new ElementDBContext();
        //    var listTypeSelect =await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form  && p.tag_name == "select").ToListAsync();

        //    Test_case newTestCase = new Test_case();
        //    newTestCase.id_testcase = id_testCase;
        //    newTestCase.id_url = Id_Url;
        //    newTestCase.result = "";
        //    newTestCase.is_test = true;
        //    newTestCase.CreatedDate = DateTime.Now.Date;
        //    newTestCase.ModifiedDate = DateTime.Now.Date;
        //    ListTestCase.Add(newTestCase);
        //    List<Input_testcase> listInputElt = new List<Input_testcase>();
        //    bool isclick = true;
        //    for (int i = 0; i < listTypeSelect.Count; i++)
        //    {
        //        if (isclick)
        //        {
        //            Input_testcase newinput = new Input_testcase();
        //            newinput.id_element = listTypeSelect[i].id_element;
        //            newinput.id_testcase = id_testCase;
        //            newinput.id_url = Id_Url;
        //            newinput.value = "1";
        //            newinput.action = "select";
        //            newinput.xpath = listTypeSelect[i].xpath;
        //            listInputElt.Add(newinput);
        //            isclick = false;
        //        }
        //        else
        //            isclick = true;

        //    }
        //    Input_testcase newsubmit = new Input_testcase();
        //    newsubmit.id_element = submit.id_element;
        //    newsubmit.id_testcase = id_testCase;
        //    newsubmit.id_url = Id_Url;
        //    newsubmit.action = "click";
        //    newsubmit.xpath = submit.xpath;
        //    listInputElt.Add(newsubmit);
        //    List_ListInputTestcase.Add(listInputElt);

        //    if (listTypeText.Count > 0)
        //    {
        //        int step = 1;
        //        Crate_Testcase(id_testCase);
        //        List<Input_testcase> listInputElt = new List<Input_testcase>();

        //        for (int i = 0; i < listTypeText.Count; i++)
        //        {
        //            Random random = new Random();
        //            listInputElt.Add(Crate_InputTestcase(listTypeText[i], id_testCase, Generate_RandomString(random, 1000), Actions.fill.ToString(), step++));

        //        }
        //        listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

        //        List_ListInputTestcase.Add(listInputElt);
        //        return true;
        //    }
        //    return false;
        //}
        public async Task<bool> SkipOneSelect_TypeSelect(string id_form, int index_submit, Element submit)
        {

            var _context = new ElementDBContext();
            var listTypeSelect = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "select").ToListAsync();

            if (listTypeSelect.Count > 1)
            {
                int number_of_elements = listTypeSelect.Count;
                for (int i = 0; i < number_of_elements; i++)
                {
                    string DescriptiontestCase = "";
                    if(id_form!=null)
                        DescriptiontestCase = $"Skip {listTypeSelect[i].id_element} element _TypeSelect_form:" + id_form + "_" + index_submit;
                    else
                        DescriptiontestCase = $"Skip {listTypeSelect[i].id_element} element _TypeSelect_" + "_" + index_submit;
                    int step = 1;
                    var id_testCase = Create_Testcase(DescriptiontestCase,"Select");
                    List<Input_testcase> listInputElt = new List<Input_testcase>();

                    for (int j = 0; j < listTypeSelect.Count; j++)
                    {
                        if (i != j)
                        {
                            Random random = new Random();
                            listInputElt.Add(Crate_InputTestcase(listTypeSelect[j], id_testCase, listTypeSelect[j].value, Actions.select.ToString(), step++));
                        }

                    }
                    listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                    List_ListInputTestcase.Add(listInputElt);

                }

                return true;
            }
            return false;
        }
        public async Task<bool> SelectAllElement_TypeSelect(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
             DescriptiontestCase = "Select All Element_TypeSelect_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Select All Element_TypeSelect_" +  "_" + index_submit;
            var _context = new ElementDBContext();
            var listTypeSelect = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "select").ToListAsync();

            if (listTypeSelect.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Select");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeSelect.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeSelect[i], id_testCase, listTypeSelect[i].value, Actions.select.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        #endregion


        #region Input type Number
        private async Task Input_Type_TypeNumber(string id_form, int index_submit, Element submit)
        {
            var a = Fill_Big_Number_TypeNumber(id_form, index_submit, submit);
            var a1 = Fill_Letter_characters_TypeNumber(id_form, index_submit, submit);
            var a2 = Fill_Special_characters_TypeNumber(id_form, index_submit, submit);
            var a3 = Fill_Number_characters_TypeNumber(id_form, index_submit, submit);

            List<Task<bool>> runTasks = new List<Task<bool>>();
            runTasks.Add(a);
            runTasks.Add(a1);
            runTasks.Add(a2);
            runTasks.Add(a3);

            while (runTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<bool> firstFinishedTask = await Task.WhenAny(runTasks);
                runTasks.Remove(firstFinishedTask);
                // Await the completed task.


            }

        }
        public async Task<bool> Fill_Big_Number_TypeNumber(string id_form, int index_submit, Element submit)
        {

            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!=null)
                DescriptiontestCase = "Fill big number elementS TypeNumber_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill big number elementS TypeNumber" + "_" + index_submit;
            var listTypeNumber = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "input" && p.type == "number").ToListAsync();
            if (listTypeNumber.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type number");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeNumber.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeNumber[i], id_testCase, 999999999999999999.ToString(), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Letter_characters_TypeNumber(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Fill Letter charter - elementS TypeNumber_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill Letter charter - elementS TypeNumber" + "_" + index_submit;
            var listTypeNumber = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "input" && p.type == "number").ToListAsync();
            if (listTypeNumber.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type number");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeNumber.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeNumber[i], id_testCase, Generate_RandomString(random, 1), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Special_characters_TypeNumber(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Fill Special characters - elementS TypeNumber_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill Special characters - elementS TypeNumber"  + "_" + index_submit;
            var listTypeNumber = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "input" && p.type == "number").ToListAsync();
            if (listTypeNumber.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type number");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeNumber.Count; i++)
                {
                    Random random = new Random();
                    listInputElt.Add(Crate_InputTestcase(listTypeNumber[i], id_testCase, Generate_RandomSpecialString(random, 2), Actions.fill.ToString(), step++));

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;
        }
        public async Task<bool> Fill_Number_characters_TypeNumber(string id_form, int index_submit, Element submit)
        {
            var _context = new ElementDBContext();
            string DescriptiontestCase = "";
            if(id_form!=null)
            DescriptiontestCase = "Fill number - elementS TypeNumber_form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill number - elementS TypeNumber" + "_" + index_submit;
            var listTypeNumber = await _context.Element.Where(p => p.id_url == Id_Url && p.tag_name == "input" && p.type == "number").ToListAsync();
            if (listTypeNumber.Count > 0)
            {
                int step = 1;
                var id_testCase = Create_Testcase(DescriptiontestCase,"Input type number");
                List<Input_testcase> listInputElt = new List<Input_testcase>();

                for (int i = 0; i < listTypeNumber.Count; i++)
                {
                    Random random = new Random();
                    try
                    {
                        listInputElt.Add(Crate_InputTestcase(listTypeNumber[i], id_testCase, Generate_RandomNumber(random, (int)listTypeNumber[i].minlength, (int)listTypeNumber[i].maxlength).ToString()
                            , Actions.fill.ToString(), step++));
                    }
                    catch
                    {
                        listInputElt.Add(Crate_InputTestcase(listTypeNumber[i], id_testCase, Generate_RandomNumber(random, 0, 10).ToString(), Actions.fill.ToString(), step++));

                    }

                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));

                List_ListInputTestcase.Add(listInputElt);
                return true;
            }
            return false;




        }
        #endregion

        #region Form
        private async Task<bool> Fill_Form(string id_form, int index_submit, Element submit)
        {
            string DescriptiontestCase = "";
            if(id_form!=null)
                DescriptiontestCase = "Fill form:" + id_form + "_" + index_submit;
            else
                DescriptiontestCase = "Fill data all element:" + id_form + "_" + index_submit;
            var _context = new ElementDBContext();
            var listElt = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.type != "submit" && p.type != "radio" && p.tag_name != "a").ToListAsync();
            int step = 1;

            List<Input_testcase> listInputElt = new List<Input_testcase>();
            if (listElt.Count > 0)
            {
                var id_testCase = "";
                if(id_form!=null)
                    id_testCase = Create_Testcase(DescriptiontestCase,"Form");
                else
                    id_testCase = Create_Testcase(DescriptiontestCase, "All element");
                for (int i = 0; i < listElt.Count; i++)
                {
                    switch (listElt[i].tag_name)
                    {

                        case "input":
                            {
                                try
                                {

                                    switch (listElt[i].type)
                                    {

                                        case "text":
                                            {
                                                try
                                                {
                                                    Random random = new Random();
                                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, Generate_RandomStringNumberSpecialString(random), Actions.fill.ToString(), step++));
                                                }
                                                catch (Exception e)
                                                {

                                                }


                                                break;
                                            }
                                        case "email":
                                            {
                                                try
                                                {
                                                    Random random = new Random();
                                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, Generate_RandomEmail(), Actions.fill.ToString(), step++));

                                                }
                                                catch (Exception e)
                                                {

                                                }
                                                break;
                                            }
                                        case "password":
                                            {
                                                try
                                                {
                                                    Random random = new Random();
                                                    int num = random.Next(6, 8);
                                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, Generate_RandomPassword(), Actions.fill.ToString(), step++));

                                                }
                                                catch (Exception e)
                                                {

                                                }
                                                break;
                                            }
                                        case "number":
                                            {
                                                try
                                                {
                                                    Random random = new Random();
                                                    try
                                                    {
                                                        listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, Generate_RandomNumber(random, (int)listElt[i].minlength, (int)listElt[i].maxlength).ToString()
                                                            , Actions.fill.ToString(), step++));
                                                    }
                                                    catch
                                                    {
                                                        listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, Generate_RandomNumber(random, 0, 10).ToString(), Actions.fill.ToString(), step++));

                                                    }
                                                }
                                                catch (Exception e)
                                                {

                                                }
                                                break;
                                            }
                                        case "checkbox":
                                            {
                                                try
                                                {

                                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, "true", Actions.check.ToString(), step++));
                                                }
                                                catch (Exception e)
                                                {

                                                }
                                                break;
                                            }
                                        //case "radio":
                                        //    {
                                        //        try
                                        //        {

                                        //            listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, "", Actions.click.ToString(), step++));
                                        //        }
                                        //        catch (Exception e)
                                        //        {

                                        //        }
                                        //        break;
                                        //    }
                                        case "date":
                                            {
                                                try
                                                {

                                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, DateTime.Now.Date.AddDays(-1).AddMonths(-1).ToString(), Actions.click.ToString(), step++));
                                                }
                                                catch (Exception e)
                                                {

                                                }
                                                break;
                                            }

                                    }

                                }
                                catch (Exception e)
                                {

                                }


                                break;
                            }
                        case "select":
                            {
                                try
                                {
                                    Random random = new Random();
                                    listInputElt.Add(Crate_InputTestcase(listElt[i], id_testCase, listElt[i].value, Actions.select.ToString(), step++));

                                }
                                catch (Exception e)
                                {

                                }
                                break;
                            }

                    }

                }
                

                var listTypeRadio = await _context.Element.Where(p => p.id_url == Id_Url && p.id_form == id_form && p.tag_name == "input" && p.type == "radio").ToListAsync();

                if (listTypeRadio.Count > 0)
                {
                    List<List<Element>> listRadio = new List<List<Element>>();
                    List<Element> listEltRadio = new List<Element>();
                    var groupedRadioList = listTypeRadio
                    .GroupBy(u => u.name)
                    .Select(grp => grp.ToList())
                    .ToList();
                    foreach (var group in groupedRadioList)
                    {

                        Input_testcase newinput = new Input_testcase();
                        Random random = new Random();
                        Element radio = group[random.Next(0, group.Count)];


                        listInputElt.Add(Crate_InputTestcase(radio, id_testCase, "", Actions.click.ToString(), step++));

                    }
                }
                listInputElt.Add(Crate_InputTestcase(submit, id_testCase, "", Actions.submit.ToString(), step++));
                List_ListInputTestcase.Add(listInputElt);
                return true;
            }


            return false;
        }

        #endregion

        #endregion

        #region Helper Generate
        ///https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

        public string Generate_RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(4, true));
            builder.Append(Generate_RandomSpecialString(1));
            builder.Append(Generate_RandomNumber(1000, 9999));
            builder.Append(Generate_RandomString(2, false));
            return builder.ToString();
        }
        public string Generate_RandomEmail()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append("@email.com");
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(8, true));
            builder.Append(Generate_RandomNumber(0, 99));
            builder.Append(Generate_RandomSpecialString(2));
            return builder.ToString();
        }
        public string Generate_RandomStringNumberSpecialString(Random random)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Generate_RandomString(random, 8, true));
            builder.Append(Generate_RandomSpecialString(random, 2));
            builder.Append(Generate_RandomNumber(random, 0, 100));
            builder.Append(Generate_RandomString(random, 3, true));
            return builder.ToString();
        }
        public string Generate_RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomString(Random random, int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Thread.Sleep(10);

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public string Generate_RandomSpecialString(Random random, int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(
                   listSpecialCharacter[random.Next(0, 20)]);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public int Generate_RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public int Generate_RandomNumber(Random random, int min, int max)
        {

            return random.Next(min, max);
        }

        public bool Crate_Testcase(string id_testCase)
        {
            Test_case newTestCase = new Test_case();
            newTestCase.id_testcase = id_testCase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            ListTestCase.Add(newTestCase);
            //return BUL.TestCaseBUL.InsertTestcase(newTestCase);
            return true;

        }
        public string Create_Testcase(string description)
        {
            Test_case newTestCase = new Test_case();
            var id_testcase = Guid.NewGuid().ToString("N").Substring(10);
            newTestCase.id_testcase = id_testcase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.description = description;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            if (this.Prerequisite_testcase != null && this.Prerequisite_url != -1)
            {
                newTestCase.id_prerequisite_testcase = Prerequisite_testcase;
                newTestCase.id_prerequisite_url = Prerequisite_url;
            }
            ListTestCase.Add(newTestCase);
            //return BUL.TestCaseBUL.InsertTestcase(newTestCase);
            return id_testcase;

        }
        public string Create_Testcase(string description,string testtype)
        {
            Test_case newTestCase = new Test_case();
            var id_testcase = Guid.NewGuid().ToString("N").Substring(10);
            newTestCase.id_testcase = id_testcase;
            newTestCase.id_url = Id_Url;
            newTestCase.result = "";
            newTestCase.is_test = true;
            newTestCase.description = description;
            newTestCase.CreatedDate = DateTime.Now.Date;
            newTestCase.ModifiedDate = DateTime.Now.Date;
            newTestCase.TestType = testtype;
            if (this.Prerequisite_testcase != null && this.Prerequisite_url != -1)
            {
                newTestCase.id_prerequisite_testcase = Prerequisite_testcase;
                newTestCase.id_prerequisite_url = Prerequisite_url;
            }
            ListTestCase.Add(newTestCase);
            //return BUL.TestCaseBUL.InsertTestcase(newTestCase);
            return id_testcase;

        }
        public Input_testcase Crate_InputTestcase(Element testElt, string id_testCase, string value, string action, int step)
        {
            Input_testcase newinput = new Input_testcase();
            try
            {
                newinput.id_element = testElt.id_element;
                newinput.id_testcase = id_testCase;
                newinput.id_url = Id_Url;
                newinput.value = value;
                newinput.action = action;
                newinput.xpath = testElt.xpath;
                newinput.test_step = step;

            }
            catch
            {
                return null;
            }
            return newinput;


        }
        #endregion


        #region Run test case
        [HttpPost]//not use
        [Route("/TestCase/Result")]
        public async Task<IActionResult> RunTestCase(int id_url, List<string> list_Idtestcase, string returnUrl = null)
        {
            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                browserRun = _context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().Browser;
                var url = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault().url1;
                //var list_Idtestcase1 = _context.Test_case.Where(p => p.id_url == id_url).ToList();
                IEnumerable<Task<string>> runTasksQuery =
                    from Id in list_Idtestcase select Run_ReturnResult(id_url, url, Id);
                List<Task<string>> runTasks = runTasksQuery.ToList();
                //try
                //{
                while (runTasks.Count > 0)
                {
                    // Identify the first task that completes.
                    Task<string> firstFinishedTask = await Task.WhenAny(runTasks);

                    // ***Remove the selected task from the list so that you don't
                    // process it more than once.
                    runTasks.Remove(firstFinishedTask);
                    // Await the completed task.

                    string length = await firstFinishedTask;

                }
                StatusMessage = "Run successfully";
                ViewData["Message"] = "Run successfully";

                if (_context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().SendResultToMail == true)
                    await SendExcel(id_url, list_Idtestcase);
                //}
                //catch
                //{
                //    ViewData["Message"] = "Run failed";
                //}
                ViewData["id_url"] = id_url;
                var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();

                ViewData["Pass"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("pass")).Count();
                ViewData["Skip"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("skip")).Count();
                ViewData["Failure"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("failure")).Count();
                StatusMessage = ViewData["Message"].ToString();
                //return RedirectToAction(nameof(Result), new RouteValueDictionary(new { id_url = id_url }));
                if (returnUrl != null)
                {
                    return RedirectToAction("TestcasesResult", "Manage", new RouteValueDictionary(new { id_url = id_url, list_Idtestcase = list_Idtestcase }));
                }
                else
                {
                    return View("Result", testcaseDBContext);
                }
                // return View("Result", testcaseDBContext);
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> RunTestCasesJob(int id_url, List<string> list_Idtestcase, bool runall, string returnUrl = null)
        {
            string jobId = Guid.NewGuid().ToString("N");
            string id = _userManager.GetUserId(User);
            Running_process running_Process = new Running_process();
            running_Process.id_process = jobId;
            running_Process.id_user = id;
            running_Process.start_time = DateTime.Now;
            running_Process.end_time = null;
            running_Process.status = "waiting";
            _context.Running_process.Add(running_Process);
            if (runall == true)
            {
                list_Idtestcase.Clear();
                list_Idtestcase = _context.Test_case.Where(p => p.id_url == id_url).Select(t => t.id_testcase).ToList();
            }
            await _context.SaveChangesAsync();
            _queue.QueueAsyncTask(() => RunTestCaseJob(id, jobId, id_url, list_Idtestcase, returnUrl));

            return RedirectToAction("Progress", new { jobId });
        }
        [Route("/TestCase/Run/Process")]
        public IActionResult Progress(string jobId)
        {
            ViewBag.JobId = jobId;
            ViewBag.Message = _context.Running_process.Find(jobId).message;
            return View();
        }
        public async Task RunTestCaseJob(string id_user, string jobId, int id_url, List<string> list_Idtestcase, string returnUrl = null)
        {
            string id = id_user;
            //string id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                int runsize = _context.ConfigWeb.ToList().FirstOrDefault().number_of_test_cases_running_concurrently;
                int sizeList = list_Idtestcase.Count();
                int cont = 0;
                browserRun = _context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().Browser;
                var url = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault().url1;
                //var list_Idtestcase1 = _context.Test_case.Where(p => p.id_url == id_url).ToList();
                try
                {
                    do
                    {
                        List<string> list_Idtestcase_Cut = list_Idtestcase.Skip(cont * runsize).Take(runsize).ToList();
                        IEnumerable<Task<string>> runTasksQuery =
                            from Id in list_Idtestcase_Cut select Run_ReturnResultJob(jobId, id_url, url, Id);
                        List<Task<string>> runTasks = runTasksQuery.ToList();
                        await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running test case");
                        //try
                        //{
                        while (runTasks.Count > 0)
                        {
                            // Identify the first task that completes.

                            Task<string> firstFinishedTask = await Task.WhenAny(runTasks);

                            // ***Remove the selected task from the list so that you don't
                            // process it more than once.
                            runTasks.Remove(firstFinishedTask);
                            // Await the completed task.

                            string length = await firstFinishedTask;

                        }
                        cont++;
                    }
                    while (cont * runsize < sizeList);
                    StatusMessage = "Run successfully";
                    ViewData["Message"] = "Run successfully";
                }
                catch
                {
                    StatusMessage = "Run failed";
                    ViewData["Message"] = "Run failed";
                }
               

                //}
                //catch
                //{
                //    ViewData["Message"] = "Run failed";
                //}
                //ViewData["id_url"] = id_url;
                //var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).Include(p => p.Input_testcase).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();



                var running_Process = _context.Running_process.Find(jobId);
                running_Process.status = "finished";
                _context.Running_process.Update(running_Process);
                await _context.SaveChangesAsync();

                await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Finished!");

                if (_context.Setting_.Where(p => p.Id_User == id).SingleOrDefault().SendResultToMail == true)
                    await SendExcelBackground(id_url, list_Idtestcase, jobId, id_user);

                Thread.Sleep(1000);
            }
        }

        // no used
        public async Task<string> Run_ReturnResult(int id_url, string url, string id_testcase)
        {

            int isPass = 0;
            int isFailure = 0;
            int isSkip = 0;
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();
            var URL = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault();
            //try
            //{

            if (browserRun.Equals("chrome"))
            {

                ChromeDriver chromedriver = SetUpDriver(url);
                if (URL.trigger_element != null || URL.trigger_element != "")
                {
                    var trigger = chromedriver.FindElementByXPath(URL.trigger_element);
                    if (trigger.Displayed)
                    {
                        trigger.Click();
                    }
                }
                //chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //run test case
                foreach (var inputtest in list_inputtest)
                {
                    switch (inputtest.action)
                    {

                        case "fill":
                            {
                                try
                                {
                                    var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (fill.Displayed)
                                    {
                                        fill.Click();
                                        fill.SendKeys(inputtest.value);
                                    }

                                }
                                catch (Exception e)
                                {
                                    //if (e.Message.Equals("element not interactable"))
                                    //{

                                    //}
                                }


                                break;
                            }
                        case "select":
                            {
                                try
                                {
                                    var select = chromedriver.FindElementByXPath(inputtest.xpath);
                                    var selectElement = new SelectElement(select);
                                    int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                    Random random = new Random();
                                    int index = random.Next(0, CountallSelectedOptions + 1);
                                    //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                    selectElement.SelectByIndex(index);
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }
                                break;
                            }
                        case "click":
                            {
                                try
                                {
                                    var click = chromedriver.FindElementByXPath(inputtest.xpath);
                                    click.Click();
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                        case "submit":
                            {
                                try
                                {
                                    chromedriver.FindElementByXPath(inputtest.xpath).Click();

                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                    }
                }

                //test
                if (list_output.Count > 0)
                {
                    foreach (var outputtest in list_output)
                    {
                        bool WasTested = false;
                        IWebElement testelt;
                        string DataResult = "";
                        if (!outputtest.xpath.Equals(""))
                        {
                            if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                            {
                                testelt = chromedriver.FindElementByXPath(outputtest.xpath);

                                string vt;
                                try
                                {
                                    vt = testelt.Text;
                                }
                                catch
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {
                                    var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                        {

                                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;
                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }

                                }

                            }
                        }

                        if (!outputtest.xpath_full.Equals("") && !WasTested)
                        {

                            if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                            {
                                testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                string vt = null;
                                if (testelt.Text != null)
                                {
                                    vt = testelt.Text;
                                }
                                else if (testelt.GetAttribute("value") != null)
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {

                                    var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                        {
                                            testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;

                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }


                                }


                            }
                        }
                        if (!WasTested)// check skip case
                        {
                            isSkip++;
                        }

                        outputtest.value_return = DataResult;
                        _context.Element_test.Update(outputtest);
                        await _context.SaveChangesAsync();

                        #region backup
                       
                        #endregion


                    }
                }
                else
                {
                    isSkip++;
                }

               
                var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                if (RedirectUrl != null)
                {
                    string current_url = chromedriver.Url;
                    if (!RedirectUrl.current_url.Equals(current_url))
                    {
                        isFailure++;
                    }
                    RedirectUrl.current_url = current_url;
                    _context.Update(RedirectUrl);
                }
                chromedriver.Quit();
                string result = "";

                if (isFailure == 0 && isSkip == 0)
                {
                    result = "Pass";
                }
                else
                {
                    if (isFailure > 0)
                    {

                        result = "Failure";
                    }
                    else if (isSkip > 0)
                    {

                        result = "Skip";
                    }
                }
                Testcase.result = result;
                await _context.SaveChangesAsync();
                return result;
                //}
                //catch
                //{

                //}
            }
            else
            {

                FirefoxDriver firefoxdriver = SetUpDriverFireFox(url);
                if (URL.trigger_element != null || URL.trigger_element != "")
                {
                    var trigger = firefoxdriver.FindElementByXPath(URL.trigger_element);
                    if (trigger.Displayed)
                    {
                        trigger.Click();
                    }
                }
                //run test case
                foreach (var inputtest in list_inputtest)
                {
                    switch (inputtest.action)
                    {

                        case "fill":
                            {
                                try
                                {
                                    var fill = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    if (fill.Displayed)
                                    {
                                        fill.Click();
                                        fill.SendKeys(inputtest.value);
                                    }

                                }
                                catch (Exception e)
                                {
                                    //if (e.Message.Equals("element not interactable"))
                                    //{

                                    //}
                                }


                                break;
                            }
                        case "select":
                            {
                                try
                                {
                                    var select = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    var selectElement = new SelectElement(select);
                                    int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                    Random random = new Random();
                                    int index = random.Next(0, CountallSelectedOptions + 1);
                                    //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                    selectElement.SelectByIndex(index);
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }
                                break;
                            }
                        case "click":
                            {
                                try
                                {
                                    var click = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    click.Click();
                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                        case "submit":
                            {
                                try
                                {
                                    firefoxdriver.FindElementByXPath(inputtest.xpath).Click();

                                }
                                catch (Exception e)
                                {
                                    if (e.Message.Equals("element not interactable"))
                                    {

                                    }
                                }

                                break;
                            }
                    }
                }

                //test
                if (list_output.Count > 0)
                {
                    foreach (var outputtest in list_output)
                    {
                        bool WasTested = false;
                        IWebElement testelt;
                        string DataResult = "";
                        if (!outputtest.xpath.Equals(""))
                        {
                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                            {
                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);

                                string vt;
                                try
                                {
                                    vt = testelt.Text;
                                }
                                catch
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {
                                    var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                        {

                                            testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;
                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }

                                }

                            }
                        }

                        if (!outputtest.xpath_full.Equals("") && !WasTested)
                        {

                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                            {
                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                string vt = null;
                                if (testelt.Text != null)
                                {
                                    vt = testelt.Text;
                                }
                                else if (testelt.GetAttribute("value") != null)
                                {
                                    vt = testelt.GetAttribute("value");
                                }
                                if (vt != null)
                                {
                                    outputtest.value_return = vt;
                                    if (!vt.Equals(outputtest.value_test))
                                    {
                                        isFailure++;
                                    }
                                    else
                                        isPass++;
                                    WasTested = true;
                                    DataResult = vt;
                                }

                            }
                            else
                            {
                                foreach (var inputtest in list_inputtest)
                                {

                                    var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                    if (testDisplayed.Displayed)
                                    {
                                        testDisplayed.Click();
                                        firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                        if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                        {
                                            testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                            string vt = null;
                                            if (testelt.Text != null)
                                            {
                                                vt = testelt.Text;
                                            }
                                            else if (testelt.GetAttribute("value") != null)
                                            {
                                                vt = testelt.GetAttribute("value");
                                            }
                                            if (vt != null)
                                            {
                                                outputtest.value_return = vt;
                                                if (!vt.Equals(outputtest.value_test))
                                                {
                                                    isFailure++;
                                                }
                                                else
                                                    isPass++;
                                                WasTested = true;

                                                DataResult = vt;
                                            }
                                            break;
                                        }

                                    }


                                }


                            }
                        }
                        if (!WasTested)// check skip case
                        {
                            isSkip++;
                        }

                        outputtest.value_return = DataResult;
                        _context.Element_test.Update(outputtest);
                        await _context.SaveChangesAsync();




                    }
                }
                else
                {
                    isSkip++;
                }
                var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                if (RedirectUrl != null)
                {
                    string current_url = firefoxdriver.Url;
                    current_url = current_url.Remove(current_url.Length - 1);
                    if (RedirectUrl.redirect_url_test != current_url)
                    {
                        isFailure++;
                    }
                    RedirectUrl.current_url = current_url;
                    _context.Update(RedirectUrl);
                }
                firefoxdriver.Quit();
                string result = "";

                if (isFailure == 0 && isSkip == 0)
                {
                    result = "Pass";
                }
                else
                {
                    if (isFailure > 0)
                    {

                        result = "Failure";
                    }
                    else if (isSkip > 0)
                    {

                        result = "Skip";
                    }
                }
                Testcase.result = result;
                await _context.SaveChangesAsync();
                return result;
                //}
                //catch
                //{

                //}
            }

        }

        public async Task<string> Run_ReturnResultJob(string jobId, int id_url, string url, string id_testcase)
        {
            string logmessage = "";
            bool testobj = false;
            int isPass = 0;
            int isFailure = 0;
            int isSkip = 0;
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            var URL = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();
            await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running test case " + id_testcase);
            var running_Process = _context.Running_process.Find(jobId);
            running_Process.status = "running";
            running_Process.message = "Running test case " + id_testcase;
            _context.Running_process.Update(running_Process);

            Result_testcase result_Testcase = new Result_testcase();
            result_Testcase.id_result = running_Process.id_process;
            result_Testcase.id_testcase = id_testcase;
            result_Testcase.id_url = id_url;
            result_Testcase.Result = "";
            result_Testcase.TestDate = DateTime.Now;
            _context.Result_testcase.Add(result_Testcase);
            try
            {
                await _context.SaveChangesAsync();

                if (browserRun.Equals("chrome"))
                {
                    ChromeDriver chromedriver = null;
                    if(Testcase.id_prerequisite_testcase!=null)
                    {
                        chromedriver = SetUpDriver();
                        var r_url = await RunPrerequesiteTestcase(chromedriver,(int) Testcase.id_prerequisite_url, Testcase.id_prerequisite_testcase);
                        if (URL.IsChange == false)
                        {
                            chromedriver.Url = URL.url1;
                            chromedriver.Navigate();
                        }
                    }
                    else
                    {
                        chromedriver = SetUpDriver(url);
                    }

                    if (URL.trigger_element != null && URL.trigger_element != "")
                    {
                        var trigger = chromedriver.FindElementByXPath(URL.trigger_element);
                        if (trigger.Displayed)
                        {
                            trigger.Click();
                        }
                    }
                    //chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    //run test case
                    foreach (var inputtest in list_inputtest)
                    {
                        Input_Result_test input_Result_Test = new Input_Result_test();
                        input_Result_Test.id_element = inputtest.id_element;
                        input_Result_Test.id_result = jobId;
                        input_Result_Test.id_testcase = id_testcase;
                        input_Result_Test.id_url = id_url;
                        input_Result_Test.value = inputtest.value;
                        input_Result_Test.action = inputtest.action;
                        input_Result_Test.step = inputtest.test_step;
                        switch (inputtest.action)
                        {

                            case "fill":
                                {
                                    try
                                    {
                                        var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                        if (fill.Displayed)
                                        {
                                            fill.Click();
                                            fill.SendKeys(inputtest.value);
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        //if (e.Message.Equals("element not interactable"))
                                        //{

                                        //}
                                    }


                                    break;
                                }
                            case "select":
                                {
                                    try
                                    {
                                        var select = chromedriver.FindElementByXPath(inputtest.xpath);
                                        var selectElement = new SelectElement(select);
                                        //int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                        //Random random = new Random();
                                        //int index = random.Next(0, CountallSelectedOptions + 1);
                                        //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                        selectElement.SelectByValue(inputtest.value);
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }
                                    break;
                                }
                            case "click":
                                {
                                    try
                                    {
                                        var click = chromedriver.FindElementByXPath(inputtest.xpath);
                                        click.Click();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                            case "check":
                                {
                                    try
                                    {
                                        var click = chromedriver.FindElementByXPath(inputtest.xpath);
                                        click.Click();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                            case "submit":
                                {
                                    try
                                    {
                                        chromedriver.FindElementByXPath(inputtest.xpath).Click();

                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                        }
                        _context.Input_Result_test.Add(input_Result_Test);
                    }
                    await _context.SaveChangesAsync();
                    //alert
                    var AlertMessage = _context.Alert_message.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                    if (AlertMessage != null)
                    {
                        try
                        {
                            var alert_win = chromedriver.SwitchTo().Alert();
                            if (AlertMessage.message != alert_win.Text)
                            {
                                isFailure++;
                            }
                            Result_AlertMessage result_Alert = new Result_AlertMessage();
                            result_Alert.id_result = jobId;
                            result_Alert.test_message = AlertMessage.message;
                            result_Alert.message = alert_win.Text;
                            result_Alert.id_testcase = id_testcase;
                            alert_win.Accept();
                            _context.Result_AlertMessage.Add(result_Alert);
                            await _context.SaveChangesAsync();
                        }
                        catch
                        {
                            isSkip++;
                            Result_AlertMessage result_Alert = new Result_AlertMessage();
                            result_Alert.id_result = jobId;
                            result_Alert.test_message = AlertMessage.message;
                            result_Alert.message ="";
                            result_Alert.id_testcase = id_testcase;
                            _context.Result_AlertMessage.Add(result_Alert);
                            logmessage += "No found alert message\n";
                            await _context.SaveChangesAsync();
                        }
                        testobj = true;
                    }
                    //test
                    if (list_output.Count > 0)
                    {
                        testobj = true;
                        foreach (var outputtest in list_output)
                        {
                            Test_element_Result_test test_Element_Result_Test = new Test_element_Result_test();
                            test_Element_Result_Test.id_result = jobId;
                            test_Element_Result_Test.id_test_elements = outputtest.id_element;
                            test_Element_Result_Test.id_testcase = id_testcase;
                            test_Element_Result_Test.value_test = outputtest.value_test;
                            bool WasTested = false;
                            
                            IWebElement testelt;
                            string DataResult = "";
                            try
                            {
                                if (!outputtest.xpath.Equals(""))
                                {
                                    if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                        test_Element_Result_Test.xpath = outputtest.xpath;
                                        string vt;
                                        try
                                        {
                                            vt = testelt.Text;
                                        }
                                        catch
                                        {
                                            vt = testelt.GetAttribute("value");
                                        }
                                        if (vt != null)
                                        {
                                            outputtest.value_return = vt;

                                            if (!vt.Equals(outputtest.value_test))
                                            {
                                                isFailure++;
                                            }
                                            else
                                                isPass++;
                                            WasTested = true;
                                            DataResult = vt;
                                        }

                                    }
                                    else
                                    {
                                        foreach (var inputtest in list_inputtest)
                                        {
                                            var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                            if (testDisplayed.Displayed)
                                            {
                                                testDisplayed.Click();
                                                chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                                if (chromedriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                                {

                                                    testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                                    test_Element_Result_Test.xpath = outputtest.xpath;
                                                    string vt = null;
                                                    if (testelt.Text != null)
                                                    {
                                                        vt = testelt.Text;
                                                    }
                                                    else if (testelt.GetAttribute("value") != null)
                                                    {
                                                        vt = testelt.GetAttribute("value");
                                                    }
                                                    if (vt != null)
                                                    {
                                                        outputtest.value_return = vt;
                                                        if (!vt.Equals(outputtest.value_test))
                                                        {
                                                            isFailure++;
                                                        }
                                                        else
                                                            isPass++;
                                                        WasTested = true;
                                                        DataResult = vt;
                                                    }
                                                    break;
                                                }

                                            }

                                        }

                                    }
                                }

                                if (!outputtest.xpath_full.Equals("") && !WasTested)
                                {

                                    if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                        test_Element_Result_Test.xpath = outputtest.xpath_full;
                                        string vt = null;
                                        if (testelt.Text != null)
                                        {
                                            vt = testelt.Text;
                                        }
                                        else if (testelt.GetAttribute("value") != null)
                                        {
                                            vt = testelt.GetAttribute("value");
                                        }
                                        if (vt != null)
                                        {
                                            outputtest.value_return = vt;
                                            if (!vt.Equals(outputtest.value_test))
                                            {
                                                isFailure++;
                                            }
                                            else
                                                isPass++;
                                            WasTested = true;
                                            DataResult = vt;
                                        }

                                    }
                                    else
                                    {
                                        foreach (var inputtest in list_inputtest)
                                        {

                                            var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                            if (testDisplayed.Displayed)
                                            {
                                                testDisplayed.Click();
                                                chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                                if (chromedriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                                {
                                                    testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                                    test_Element_Result_Test.xpath = outputtest.xpath_full;
                                                    string vt = null;
                                                    if (testelt.Text != null)
                                                    {
                                                        vt = testelt.Text;
                                                    }
                                                    else if (testelt.GetAttribute("value") != null)
                                                    {
                                                        vt = testelt.GetAttribute("value");
                                                    }
                                                    if (vt != null)
                                                    {
                                                        outputtest.value_return = vt;
                                                        if (!vt.Equals(outputtest.value_test))
                                                        {
                                                            isFailure++;
                                                        }
                                                        else
                                                            isPass++;
                                                        WasTested = true;

                                                        DataResult = vt;
                                                    }
                                                    break;
                                                }

                                            }


                                        }


                                    }
                                }
                                if (!WasTested)// check skip case
                                {
                                    isSkip++;
                                    logmessage += "Not found element with xpath: " + outputtest.xpath != null ? outputtest.xpath : outputtest.xpath_full + "\n";
                                }
                            }
                            catch
                            {
                                isSkip++;
                                logmessage += "Not found element with xpath: " + outputtest.xpath != null ? outputtest.xpath : outputtest.xpath_full+"\n";
                            }
                            test_Element_Result_Test.value = DataResult;
                            _context.Test_element_Result_test.Add(test_Element_Result_Test);
                            outputtest.value_return = DataResult;
                            _context.Element_test.Update(outputtest);
                            await _context.SaveChangesAsync();

                        }
                    }
                    //else
                    //{
                    //    isSkip++;
                    //}

                    //BUL.RedirectUrlBUL.Update_RedirectUrl(Id_testcase, ID_URL, current_url);
                    //QuitDriver(chromedriver);
                    var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                    if (RedirectUrl != null)
                    {
                        string current_url = chromedriver.Url;
                        current_url = current_url.Remove(current_url.Length - 1);
                        if (RedirectUrl.redirect_url_test != current_url)
                        {
                            isFailure++;
                        }
                        RedirectUrl.current_url = current_url;
                        _context.Update(RedirectUrl);
                        RedirectUrl.current_url = current_url;
                        _context.Update(RedirectUrl);
                        Result_Url result_Url = new Result_Url();
                        result_Url.id_result = jobId;
                        result_Url.return_url = current_url;
                        result_Url.TestDate = DateTime.Now;
                        result_Url.test_url = RedirectUrl.redirect_url_test;
                        result_Url.id_testcase = id_testcase;
                        _context.Result_Url.Add(result_Url);
                        testobj = true;
                    }
                    if(!testobj)
                    {
                        isSkip++;
                        logmessage += "No validate item\n";
                    }
                    chromedriver.Quit();
                    string result = "";
                    running_Process.status = "finished";
                    running_Process.message = "Running finished test case " + id_testcase;
                    running_Process.end_time = DateTime.Now;
                    _context.Running_process.Update(running_Process);
                    if (isFailure == 0 && isSkip == 0)
                    {
                        result = "Pass";
                    }
                    else
                    {
                        if (isFailure > 0)
                        {

                            result = "Failure";
                        }
                        else if (isSkip > 0)
                        {

                            result = "Skip";
                        }
                    }
                    Testcase.result = result;
                    result_Testcase.Result = result;
                    result_Testcase.Log_message = logmessage;
                    await _context.SaveChangesAsync();
                    return result;

                }
                else if (browserRun.Equals("firefox"))
                {

                    //FirefoxDriver firefoxdriver = SetUpDriverFireFox(url);

                    FirefoxDriver firefoxdriver = null;
                    if (Testcase.id_prerequisite_testcase != null)
                    {
                        firefoxdriver = SetUpDriverFireFox();
                        var r_url = await RunPrerequesiteTestcase(firefoxdriver, (int)Testcase.id_prerequisite_url, Testcase.id_prerequisite_testcase);
                        if (URL.IsChange == false)
                        {
                            firefoxdriver.Url = URL.url1;
                            firefoxdriver.Navigate();
                        }
                    }
                    else
                    {
                        firefoxdriver = SetUpDriverFireFox(url);
                    }
                    if (URL.trigger_element != null && URL.trigger_element != "")
                    {
                        var trigger = firefoxdriver.FindElementByXPath(URL.trigger_element);
                        if (trigger.Displayed)
                        {
                            trigger.Click();
                        }
                    }
                    //run test case

                    foreach (var inputtest in list_inputtest)
                    {
                        Input_Result_test input_Result_Test = new Input_Result_test();
                        input_Result_Test.id_element = inputtest.id_element;
                        input_Result_Test.id_result = jobId;
                        input_Result_Test.id_testcase = id_testcase;
                        input_Result_Test.id_url = id_url;
                        input_Result_Test.value = inputtest.value;
                        input_Result_Test.action = inputtest.action;
                        input_Result_Test.step = inputtest.test_step;
                        switch (inputtest.action)
                        {

                            case "fill":
                                {
                                    try
                                    {

                                        var fill = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        if (fill.Displayed)
                                        {
                                            fill.Click();
                                            fill.SendKeys(inputtest.value);


                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        //if (e.Message.Equals("element not interactable"))
                                        //{

                                        //}
                                    }


                                    break;
                                }
                            case "select":
                                {
                                    try
                                    {
                                        //var select = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        //var selectElement = new SelectElement(select);
                                        //int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                        //Random random = new Random();
                                        //int index = random.Next(0, CountallSelectedOptions + 1);
                                        ////selectElement.SelectByIndex(int.Parse(inputtest.value));
                                        //selectElement.SelectByIndex(index);
                                        var select = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        var selectElement = new SelectElement(select);
                                        selectElement.SelectByValue(inputtest.value);

                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }
                                    break;
                                }
                            case "click":
                                {
                                    try
                                    {
                                        var click = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        click.Click();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                            case "check":
                                {
                                    try
                                    {
                                        var click = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        click.Click();
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                            case "submit":
                                {
                                    try
                                    {
                                        firefoxdriver.FindElementByXPath(inputtest.xpath).Click();

                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("element not interactable"))
                                        {

                                        }
                                    }

                                    break;
                                }
                        }
                        _context.Input_Result_test.Add(input_Result_Test);
                    }
                    await _context.SaveChangesAsync();
                    //alert
                    var AlertMessage = _context.Alert_message.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                    if (AlertMessage != null)
                    {
                        try
                        {
                            var alert_win = firefoxdriver.SwitchTo().Alert();
                            if (AlertMessage.message != alert_win.Text)
                            {
                                isFailure++;
                            }
                            Result_AlertMessage result_Alert = new Result_AlertMessage();
                            result_Alert.id_result = jobId;
                            result_Alert.test_message = AlertMessage.message;
                            result_Alert.message = alert_win.Text;
                            result_Alert.id_testcase = id_testcase;
                            alert_win.Accept();
                            _context.Result_AlertMessage.Add(result_Alert);
                            await _context.SaveChangesAsync();
                        }
                        catch
                        {
                            isSkip++;
                            Result_AlertMessage result_Alert = new Result_AlertMessage();
                            result_Alert.id_result = jobId;
                            result_Alert.test_message = AlertMessage.message;
                            result_Alert.message = "";
                            result_Alert.id_testcase = id_testcase;
                            _context.Result_AlertMessage.Add(result_Alert);
                            logmessage += "No found alert message\n";
                            await _context.SaveChangesAsync();
                        }
                        testobj = true;
                    }
                    //test
                    if (list_output.Count > 0)
                    {
                        foreach (var outputtest in list_output)
                        {
                            Test_element_Result_test test_Element_Result_Test = new Test_element_Result_test();
                            test_Element_Result_Test.id_result = jobId;
                            test_Element_Result_Test.id_test_elements = outputtest.id_element;
                            test_Element_Result_Test.id_testcase = id_testcase;
                            test_Element_Result_Test.value_test = outputtest.value_test;

                            bool WasTested = false;
                            IWebElement testelt;
                            string DataResult = "";
                            if (!outputtest.xpath.Equals(""))
                            {
                                if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                {
                                    testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);
                                    test_Element_Result_Test.xpath = outputtest.xpath;
                                    string vt;
                                    try
                                    {
                                        vt = testelt.Text;
                                    }
                                    catch
                                    {
                                        vt = testelt.GetAttribute("value");
                                    }
                                    if (vt != null)
                                    {
                                        outputtest.value_return = vt;
                                        test_Element_Result_Test.value = vt;
                                        if (!vt.Equals(outputtest.value_test))
                                        {
                                            isFailure++;
                                        }
                                        else
                                            isPass++;
                                        WasTested = true;
                                        DataResult = vt;
                                    }

                                }
                                else
                                {
                                    foreach (var inputtest in list_inputtest)
                                    {
                                        var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);
                                        if (testDisplayed.Displayed)
                                        {
                                            testDisplayed.Click();
                                            firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath).Count() > 0)
                                            {

                                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath);
                                                test_Element_Result_Test.xpath = outputtest.xpath;
                                                string vt = null;
                                                if (testelt.Text != null)
                                                {
                                                    vt = testelt.Text;
                                                }
                                                else if (testelt.GetAttribute("value") != null)
                                                {
                                                    vt = testelt.GetAttribute("value");
                                                }
                                                if (vt != null)
                                                {
                                                    outputtest.value_return = vt;
                                                    test_Element_Result_Test.value = vt;
                                                    if (!vt.Equals(outputtest.value_test))
                                                    {
                                                        isFailure++;
                                                    }
                                                    else
                                                        isPass++;
                                                    WasTested = true;
                                                    DataResult = vt;
                                                }
                                                break;
                                            }

                                        }

                                    }

                                }
                            }

                            if (!outputtest.xpath_full.Equals("") && !WasTested)
                            {

                                if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count() > 0)
                                {
                                    testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                    test_Element_Result_Test.xpath = outputtest.xpath_full;
                                    string vt = null;
                                    if (testelt.Text != null)
                                    {
                                        vt = testelt.Text;
                                    }
                                    else if (testelt.GetAttribute("value") != null)
                                    {
                                        vt = testelt.GetAttribute("value");
                                    }
                                    if (vt != null)
                                    {
                                        outputtest.value_return = vt;
                                        test_Element_Result_Test.value = vt;
                                        if (!vt.Equals(outputtest.value_test))
                                        {
                                            isFailure++;
                                        }
                                        else
                                            isPass++;
                                        WasTested = true;
                                        DataResult = vt;
                                    }

                                }
                                else
                                {
                                    foreach (var inputtest in list_inputtest)
                                    {

                                        var testDisplayed = firefoxdriver.FindElementByXPath(inputtest.xpath);

                                        if (testDisplayed.Displayed)
                                        {
                                            testDisplayed.Click();
                                            firefoxdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                                            if (firefoxdriver.FindElementsByXPath(outputtest.xpath_full).Count > 0)
                                            {
                                                testelt = firefoxdriver.FindElementByXPath(outputtest.xpath_full);
                                                test_Element_Result_Test.xpath = outputtest.xpath_full;
                                                string vt = null;
                                                if (testelt.Text != null)
                                                {
                                                    vt = testelt.Text;
                                                }
                                                else if (testelt.GetAttribute("value") != null)
                                                {
                                                    vt = testelt.GetAttribute("value");
                                                }
                                                if (vt != null)
                                                {
                                                    outputtest.value_return = vt;
                                                    test_Element_Result_Test.value = vt;
                                                    if (!vt.Equals(outputtest.value_test))
                                                    {
                                                        isFailure++;
                                                    }
                                                    else
                                                        isPass++;
                                                    WasTested = true;

                                                    DataResult = vt;
                                                }
                                                break;
                                            }

                                        }


                                    }


                                }
                            }
                            if (!WasTested)// check skip case
                            {
                                isSkip++;
                                logmessage += "Not found element with xpath: " + outputtest.xpath != null ? outputtest.xpath : outputtest.xpath_full + "\n";

                            }
                            _context.Test_element_Result_test.Add(test_Element_Result_Test);
                            outputtest.value_return = DataResult;
                            _context.Element_test.Update(outputtest);
                            await _context.SaveChangesAsync();
                        }
                    }
                    //else
                    //{
                    //    isSkip++;
                    //}
                    var RedirectUrl = _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                    if (RedirectUrl != null)
                    {
                        testobj = true;
                        string current_url = firefoxdriver.Url;
                        current_url = current_url.Remove(current_url.Length - 1);
                        if (RedirectUrl.redirect_url_test != current_url)
                        {
                            isFailure++;
                        }
                        RedirectUrl.current_url = current_url;
                        _context.Update(RedirectUrl);
                        Result_Url result_Url = new Result_Url();
                        result_Url.id_result = jobId;
                        result_Url.return_url = current_url;
                        result_Url.TestDate = DateTime.Now;
                        result_Url.test_url = RedirectUrl.redirect_url_test;
                        result_Url.id_testcase = id_testcase;
                        _context.Result_Url.Add(result_Url);
                    }
                    if (!testobj)
                    {
                        isSkip++;
                        logmessage += "No validate items\n";
                    }
                    firefoxdriver.Quit();
                    string result = "";
                    await _hubContext.Clients.Group(jobId).SendAsync(jobId, "Running finished test case: " + id_testcase);
                    running_Process.message = "Running finished test case " + id_testcase;
                    running_Process.end_time = DateTime.Now;
                    _context.Running_process.Update(running_Process);

                    if (isFailure == 0 && isSkip == 0)
                    {
                        result = "Pass";
                    }
                    else
                    {
                        if (isFailure > 0)
                        {

                            result = "Failure";
                        }
                        else if (isSkip > 0)
                        {

                            result = "Skip";
                        }
                    }
                    Testcase.result = result;
                    result_Testcase.Result = result;
                    result_Testcase.Log_message = logmessage;
                    await _context.SaveChangesAsync();

                    return result;
                    //}
                    //catch
                    //{

                    //}
                }
            }
            catch
            {
                logmessage = "Run error \n";
            }
            result_Testcase.Log_message = logmessage;
            await _context.SaveChangesAsync();
            return "Error";
        }

        public async Task<string> RunPrerequesiteTestcase(ChromeDriver driver, int id_url, string id_testcase)
        {
            string return_url = "";
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            Url URL = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault();
            string url = URL.url1;
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
           
            if (Testcase.id_prerequisite_testcase != null)
            {
                return_url = await RunPrerequesiteTestcase(driver, (int)Testcase.id_prerequisite_url, Testcase.id_prerequisite_testcase);
            }
            driver.Url = url;
            driver.Navigate();
            if (URL.trigger_element != null && URL.trigger_element != "")
            {
                var trigger = driver.FindElementByXPath(URL.trigger_element);
                if (trigger.Displayed)
                {
                    trigger.Click();
                }
            }
            foreach (var inputtest in list_inputtest)
            {
                switch (inputtest.action)
                {

                    case "fill":
                        {
                            try
                            {
                                var fill = driver.FindElementByXPath(inputtest.xpath);
                                if (fill.Displayed)
                                {
                                    fill.Click();
                                    fill.SendKeys(inputtest.value);
                                }

                            }
                            catch (Exception e)
                            {

                            }


                            break;
                        }
                    case "select":
                        {
                            try
                            {
                                var select = driver.FindElementByXPath(inputtest.xpath);
                                var selectElement = new SelectElement(select);

                                selectElement.SelectByValue(inputtest.value);
                            }
                            catch (Exception e)
                            {

                            }
                            break;
                        }
                    case "click":
                        {
                            try
                            {
                                var click = driver.FindElementByXPath(inputtest.xpath);
                                click.Click();
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
                            }

                            break;
                        }
                    case "check":
                        {
                            try
                            {
                                var click = driver.FindElementByXPath(inputtest.xpath);
                                click.Click();
                            }
                            catch (Exception e)
                            {

                            }

                            break;
                        }
                    case "submit":
                        {
                            try
                            {
                                driver.FindElementByXPath(inputtest.xpath).Click();

                            }
                            catch (Exception e)
                            {

                            }

                            break;
                        }
                }

            }

            return_url = driver.Url;


            return return_url;
        }
        public async Task<string> RunPrerequesiteTestcase(FirefoxDriver driver, int id_url, string id_testcase)
        {
            string return_url = "";
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            Url URL = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault();
            string url = URL.url1;
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
        
            if(Testcase.id_prerequisite_testcase!=null)
            {
                return_url = await RunPrerequesiteTestcase(driver, (int)Testcase.id_prerequisite_url, Testcase.id_prerequisite_testcase);
            }
            driver.Url = url;
            driver.Navigate();
            if (URL.trigger_element != null && URL.trigger_element != "")
            {
                var trigger = driver.FindElementByXPath(URL.trigger_element);
                if (trigger.Displayed)
                {
                    trigger.Click();
                }
            }
            foreach (var inputtest in list_inputtest)
            {
                switch (inputtest.action)
                {

                    case "fill":
                        {
                            try
                            {
                                var fill = driver.FindElementByXPath(inputtest.xpath);
                                if (fill.Displayed)
                                {
                                    fill.Click();
                                    fill.SendKeys(inputtest.value);
                                }

                            }
                            catch (Exception e)
                            {

                            }


                            break;
                        }
                    case "select":
                        {
                            try
                            {
                                var select = driver.FindElementByXPath(inputtest.xpath);
                                var selectElement = new SelectElement(select);

                                selectElement.SelectByValue(inputtest.value);
                            }
                            catch (Exception e)
                            {

                            }
                            break;
                        }
                    case "click":
                        {
                            try
                            {
                                var click = driver.FindElementByXPath(inputtest.xpath);
                                click.Click();
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
                            }

                            break;
                        }
                    case "check":
                        {
                            try
                            {
                                var click = driver.FindElementByXPath(inputtest.xpath);
                                click.Click();
                            }
                            catch (Exception e)
                            {

                            }

                            break;
                        }
                    case "submit":
                        {
                            try
                            {
                                driver.FindElementByXPath(inputtest.xpath).Click();

                            }
                            catch (Exception e)
                            {

                            }

                            break;
                        }
                }

            }

            return_url = driver.Url;


            return return_url;
        }
        /*
        public async Task<string> Run_ReturnResult(int id_url, string url, string id_testcase)
        {

            int isPass = 0;
            int isFailure = 0;
            int isSkip = 0;
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            //try
            //{
            ChromeDriver chromedriver = SetUpDriver(url);

            chromedriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();
            //run test case
            foreach (var inputtest in list_inputtest)
            {
                switch (inputtest.action)
                {

                    case "fill":
                        {
                            try
                            {
                                var fill = chromedriver.FindElementByXPath(inputtest.xpath);
                                if (fill.Displayed)
                                {
                                    fill.Click();
                                    fill.SendKeys(inputtest.value);
                                }

                            }
                            catch (Exception e)
                            {
                                //if (e.Message.Equals("element not interactable"))
                                //{

                                //}
                            }


                            break;
                        }
                    case "select":
                        {
                            try
                            {
                                var select = chromedriver.FindElementByXPath(inputtest.xpath);
                                var selectElement = new SelectElement(select);
                                int CountallSelectedOptions = selectElement.AllSelectedOptions.Count();
                                Random random = new Random();
                                int index = random.Next(0, CountallSelectedOptions + 1);
                                //selectElement.SelectByIndex(int.Parse(inputtest.value));
                                selectElement.SelectByIndex(index);
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
                            }
                            break;
                        }
                    case "click":
                        {
                            try
                            {
                                var click = chromedriver.FindElementByXPath(inputtest.xpath);
                                click.Click();
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
                            }

                            break;
                        }
                    case "submit":
                        {
                            try
                            {
                                chromedriver.FindElementByXPath(inputtest.xpath).Click();

                            }
                            catch (Exception e)
                            {
                                if (e.Message.Equals("element not interactable"))
                                {

                                }
                            }

                            break;
                        }
                }
            }

            //test
            if (list_output.Count > 0)
            {
                foreach (var outputtest in list_output)
                {
                    bool WasTested = false;
                    IWebElement testelt;
                    string DataResult = "";
                    if (!outputtest.xpath.Equals(""))
                    {
                        try
                        {

                            testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                            string vt;
                            try
                            {
                                vt = testelt.Text;
                            }
                            catch
                            {
                                vt = testelt.GetAttribute("value");
                            }
                            if (vt != null)
                            {
                                outputtest.value_return = vt;
                                if (!vt.Equals(outputtest.value_test))
                                {
                                    isFailure++;
                                }
                                else
                                    isPass++;
                                WasTested = true;
                                DataResult = vt;
                            }

                        }
                        catch
                        {
                            foreach (var inputtest in list_inputtest)
                            {
                                var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                if (testDisplayed.Displayed)
                                {
                                    testDisplayed.Click();
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                                        string vt;
                                        try
                                        {
                                            vt = testelt.Text;
                                        }
                                        catch
                                        {
                                            vt = testelt.GetAttribute("value");
                                        }
                                        if (vt != null)
                                        {
                                            outputtest.value_return = vt;
                                            if (!vt.Equals(outputtest.value_test))
                                            {
                                                isFailure++;
                                            }
                                            else
                                                isPass++;
                                            WasTested = true;
                                            DataResult = vt;
                                        }
                                        break;
                                    }
                                    catch
                                    {


                                    }


                                }

                            }

                        }
                    }

                    if (!outputtest.xpath_full.Equals("") && !WasTested)
                    {

                        try
                        {
                            testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                            string vt;
                            try
                            {
                                vt = testelt.Text;
                            }
                            catch
                            {
                                vt = testelt.GetAttribute("value");
                            }
                            if (vt != null)
                            {
                                outputtest.value_return = vt;
                                if (!vt.Equals(outputtest.value_test))
                                {
                                    isFailure++;
                                }
                                else
                                    isPass++;
                                WasTested = true;
                                DataResult = vt;
                            }

                        }
                        catch
                        {
                            foreach (var inputtest in list_inputtest)
                            {

                                var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                                if (testDisplayed.Displayed)
                                {
                                    testDisplayed.Click();
                                    try
                                    {
                                        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                                        string vt;
                                        try
                                        {
                                            vt = testelt.Text;
                                        }
                                        catch
                                        {
                                            vt = testelt.GetAttribute("value");
                                        }
                                        if (vt != null)
                                        {
                                            outputtest.value_return = vt;
                                            if (!vt.Equals(outputtest.value_test))
                                            {
                                                isFailure++;
                                            }
                                            else
                                                isPass++;
                                            WasTested = true;

                                            DataResult = vt;
                                        }
                                        break;
                                    }
                                    catch
                                    {


                                    }
                                }


                            }


                        }
                    }
                    if (!WasTested)// check skip case
                    {
                        isSkip++;
                    }

                    outputtest.value_return = DataResult;
                    _context.Element_test.Update(outputtest);
                    await _context.SaveChangesAsync();

#region backup
                    //try
                    //{

                    //    testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                    //    string vt;
                    //    try
                    //    {
                    //        vt = testelt.Text;
                    //    }
                    //    catch
                    //    {
                    //        vt = testelt.GetAttribute("value");
                    //    }
                    //    if (vt != null)
                    //    {
                    //        outputtest.value_return = vt;
                    //        if (!vt.Equals(outputtest.value_test))
                    //        {
                    //            isPass = 0;
                    //        }
                    //        BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //    }



                    //}
                    //catch
                    //{
                    //    try
                    //    {
                    //        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                    //        string vt;
                    //        try
                    //        {
                    //            vt = testelt.Text;
                    //        }
                    //        catch
                    //        {
                    //            vt = testelt.GetAttribute("value");
                    //        }
                    //        if (vt != null)
                    //        {
                    //            outputtest.value_return = vt;
                    //            if (!vt.Equals(outputtest.value_test))
                    //            {
                    //                isPass = 0;
                    //            }
                    //            BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //        }

                    //    }
                    //    catch
                    //    {
                    //        foreach (var inputtest in list_inputtest)
                    //        {

                    //            var testDisplayed = chromedriver.FindElementByXPath(inputtest.xpath);
                    //            if (testDisplayed.Displayed)
                    //            {
                    //                testDisplayed.Click();
                    //                try
                    //                {
                    //                    testelt = chromedriver.FindElementByXPath(outputtest.xpath);
                    //                    string vt;
                    //                    try
                    //                    {
                    //                        vt = testelt.Text;
                    //                    }
                    //                    catch
                    //                    {
                    //                        vt = testelt.GetAttribute("value");
                    //                    }
                    //                    if (vt != null)
                    //                    {
                    //                        outputtest.value_return = vt;
                    //                        if (!vt.Equals(outputtest.value_test))
                    //                        {
                    //                            isPass = 0;
                    //                        }
                    //                        BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //                    }
                    //                    break;
                    //                }
                    //                catch
                    //                {
                    //                    try
                    //                    {
                    //                        testelt = chromedriver.FindElementByXPath(outputtest.xpath_full);
                    //                        string vt;
                    //                        try
                    //                        {
                    //                            vt = testelt.Text;
                    //                        }
                    //                        catch
                    //                        {
                    //                            vt = testelt.GetAttribute("value");
                    //                        }
                    //                        if (vt != null)
                    //                        {
                    //                            outputtest.value_return = vt;
                    //                            if (!vt.Equals(outputtest.value_test))
                    //                            {
                    //                                isPass = 0;
                    //                            }
                    //                            BUL.TestElementBUL.Update_ValueResult_Testcase(ID_URL, Id_testcase, vt);
                    //                        }
                    //                        break;
                    //                    }
                    //                    catch
                    //                    {

                    //                    }

                    //                }


                    //            }

                    //        }
                    //    }
                    //}

#endregion


                }
            }
            else
            {
                isSkip++;
            }
            //string current_url = chromedriver.Url;
            //BUL.RedirectUrlBUL.Update_RedirectUrl(Id_testcase, ID_URL, current_url);
            QuitDriver(chromedriver);
            string result = "";

            if (isFailure == 0 && isSkip == 0)
            {
                result = "Pass";
            }
            else
            {
                if (isFailure > 0)
                {

                    result = "Failure";
                }
                else if (isSkip > 0)
                {

                    result = "Skip";
                }
            }
            Testcase.result = result;
            await _context.SaveChangesAsync();
            return result;
            //}
            //catch
            //{

            //}
        }
        */

        #region Driver
        private ChromeDriver SetUpDriver(string url)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            ChromeDriver chromedriver = new ChromeDriver(service, options);
            chromedriver.Url = url;
            chromedriver.Navigate();
            //The HTTP request to the remote WebDriver server for URL 
            return chromedriver;
        }
        private FirefoxDriver SetUpDriverFireFox(string url)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new FirefoxOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            FirefoxDriver firefoxdriver = new FirefoxDriver(service, options);
            firefoxdriver.Url = url;
            firefoxdriver.Navigate();
            //The HTTP request to the remote WebDriver server for URL 
            return firefoxdriver;
        }
        private ChromeDriver SetUpDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            ChromeDriver chromedriver = new ChromeDriver(service, options);
            //The HTTP request to the remote WebDriver server for URL 
            return chromedriver;
        }
       
        private FirefoxDriver SetUpDriverFireFox()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;//hide commandPromptWindow

            var options = new FirefoxOptions();
            //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
            //options.AddArgument("headless");
            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            //drv.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //options.AddArgument("no-sandbox");
            //options.AddArgument("proxy-server='direct://'");
            //options.AddArgument("proxy-bypass-list=*");
            FirefoxDriver firefoxdriver = new FirefoxDriver(service, options);

            //The HTTP request to the remote WebDriver server for URL 
            return firefoxdriver;
        }
        private void QuitDriver(ChromeDriver chromedriver)
        {

            chromedriver.Quit();

        }
        private void CloseDriver(ChromeDriver chromedriver)
        {

            chromedriver.Close();

        }
        #endregion

        #endregion

        #region Output test case
        [Route("/TestCase/TestElement")]
        public async Task<IActionResult> TestElement(int id_url, string id_testcase)
        {
            ViewData["Message"] = StatusMessage;
            TempData.Remove("StatusMessage");
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            var testelementDBContext = await _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToListAsync();
            var urlRedirectDBContext = await _context.Redirect_url.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefaultAsync();
            var alertDBContext = await _context.Alert_message.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefaultAsync();
            if (urlRedirectDBContext != null)
            {
                ViewData["urlRedirecttest"] = urlRedirectDBContext.redirect_url_test;
                ViewData["current_url"] = urlRedirectDBContext.current_url;
            }
            else
            {
                ViewData["urlRedirecttest"] = "";
                ViewData["current_url"] = null;
            }
            if (alertDBContext != null)
            {
                ViewData["alertMessage"] = alertDBContext.message;
               
            }
            else
            {
                ViewData["alertMessage"] = null;
                
            }
            if (ViewData["Message"] == null)
            {
                if (testelementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No element yet, create a new one";
                }
                else
                if (testelementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("{0} test element(s)", testelementDBContext.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            return View(testelementDBContext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestElt(string xpath, string fullxpath, int id_url, string valuetest, string id_testcase, string returnUrl = null)
        {
            var elttest = new Element_test();
            try
            {
                if (ModelState.IsValid)
                {
                    if (xpath == null)
                        xpath = "";
                    if (fullxpath == null)
                        fullxpath = "";
                    if (valuetest == null)
                        valuetest = "";
                    Random random = new Random();
                    elttest.xpath = xpath;
                    elttest.xpath_full = fullxpath;
                    elttest.value_test = valuetest;
                    elttest.id_url = id_url;
                    elttest.id_testcase = id_testcase;
                    elttest.id_element = id_testcase + Generate_RandomString(random, 5);
                    _context.Add(elttest);
                    await _context.SaveChangesAsync();
                    StatusMessage = String.Format("Success");
                    //return RedirectToAction(nameof(TestElement), new RouteValueDictionary(new { id_url = id_url, id_testcase = id_testcase }));
                }
            }
            catch
            {
                StatusMessage = String.Format("Error");
            }
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(TestElement), new RouteValueDictionary(new { id_url = id_url, id_testcase = id_testcase }));
            }
            //return RedirectToAction(nameof(TestElement), new RouteValueDictionary(new { id_url = id_url, id_testcase = id_testcase }));
        }
        [HttpPost, ActionName("DeleteTestElt")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTestElt(string id_testcase, int id_url, string id_elementtest, string returnUrl = null)
        {
            try
            {
                var test_elt = await _context.Element_test.Where(p => p.id_element == id_elementtest && p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                _context.Element_test.Remove(test_elt);
                await _context.SaveChangesAsync();

                StatusMessage = String.Format("Success");
            }
            catch
            {
                StatusMessage = String.Format("Error");
            }
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(TestElement), new { id_testcase = id_testcase, id_url = id_url });
            }
            //return RedirectToAction(nameof(TestElement), new { id_testcase = id_testcase, id_url = id_url });
        }
        [HttpPost, ActionName("EditTestElt")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTestElt(string xpath, string fullxpath, string valuetest, string id_testcase, int id_url, string id_elementtest, string returnUrl = null)
        {
            try
            {
                var test_elt = await _context.Element_test.Where(p => p.id_element == id_elementtest && p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                if (xpath == null)
                    xpath = "";
                if (fullxpath == null)
                    fullxpath = "";
                if (valuetest == null)
                    valuetest = "";
                test_elt.value_test = valuetest;
                test_elt.xpath = xpath;
                test_elt.xpath_full = fullxpath;
                _context.Element_test.Update(test_elt);
                await _context.SaveChangesAsync();

                StatusMessage = String.Format("Success");
            }
            catch
            {
                StatusMessage = String.Format("Error");
            }
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(TestElement), new { id_testcase = id_testcase, id_url = id_url });
            }
            // return RedirectToAction(nameof(TestElement), new { id_testcase = id_testcase, id_url = id_url });
            // return View("TestElement", await _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToListAsync());
        }
        #endregion

        #region Input test case
        [Route("/TestCase/TestData")]
        public async Task<IActionResult> TestData(int id_url, string id_testcase)
        {
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            var testdataDBContext = await _context.Input_testcase.Include(i => i.id_).Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToListAsync();
            if (testdataDBContext.Count() == 0)
            {
                ViewData["Message"] = "No data yet, create a new one";
            }
            else
           if (testdataDBContext.Count() > 0)
            {
                ViewData["Message"] = String.Format("{0} test data(s)", testdataDBContext.Count());
            }

            else
            {
                ViewData["Message"] = "Error load data";
            }
            return View(testdataDBContext);
        }

        [Route("/Testcase/TestDatas/ChangeOption")]
        public async Task<IActionResult> ChaneOptionRadio(int id_url, string id_testcase, string id_element, string name_element)
        {
            ViewData["Message"] = StatusMessage;
            TempData.Remove("StatusMessage");
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            ViewData["id_element"] = id_element;
            var elt = await _context.Element.Where(p => p.id_url == id_url && p.type == "radio" && p.name == name_element).ToListAsync();
            if (ViewData["Message"] == null)
            {
                if (elt.Count() == 0)
                {
                    ViewData["Message"] = "No data yet, create a new one";
                }
                else
                if (elt.Count() > 0)
                {
                    ViewData["Message"] = String.Format("{0} test data(s)", elt.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            return View(elt);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeValueDataTest(int id_url, string id_testcase, string id_element, string testvalue)
        {
            try
            {
                var testdata = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase && p.id_element == id_element).SingleOrDefault();
                testdata.value = testvalue;
                if ((testvalue.ToLower().Equals("true") || testvalue.ToLower().Equals("false")) && (testdata.action.ToLower().Equals("check") || testdata.action.ToLower().Equals("nocheck")))
                {
                    if (testvalue.ToLower().Equals("true"))
                    {
                        testdata.action = "check";
                    }
                    else
                    {
                        testdata.action = "nocheck";
                    }
                }
                _context.Input_testcase.Update(testdata);
                await _context.SaveChangesAsync();
                StatusMessage = "Update successfully";
            }
            catch
            {
                StatusMessage = "Update failed";
            }
            return RedirectToAction("TestData", new { id_url = id_url, id_testcase = id_testcase });
        }
        [HttpPost]
        public async Task<IActionResult> SaveValueOption(int id_url, string id_testcase, string id_element, string id_elementchange)
        {
            try
            {
                var testdata = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase && p.id_element == id_element).SingleOrDefault();
                var elt = _context.Element.Where(p => p.id_url == id_url && p.id_element == id_elementchange).SingleOrDefault();
                //testdata.id_element = id_elementchange;
                Input_testcase input_Testcase = new Input_testcase();
                input_Testcase.id_element = id_elementchange;
                input_Testcase.id_testcase = id_testcase;
                input_Testcase.id_url = id_url;
                input_Testcase.test_step = testdata.test_step;
                input_Testcase.value = testdata.value;
                input_Testcase.action = testdata.action;
                input_Testcase.xpath = elt.xpath;
                _context.Input_testcase.Remove(testdata);
                _context.Input_testcase.Add(input_Testcase);
                //_context.Input_testcase.Update(testdata);
                await _context.SaveChangesAsync();
                StatusMessage = "Update successfully";
            }
            catch
            {
                StatusMessage = "Update failed";
            }
            return RedirectToAction("TestData", new { id_url = id_url, id_testcase = id_testcase });
        }
        #endregion

        #region Excel
        // Send excel to mail
        public async Task SendExcel(int id_url, List<string> list_Idtestcase)
        {
            var user = await _userManager.GetUserAsync(User);
            var url = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();
            var testcases = await _context.Test_case.Include(i => i.Input_testcase).Include(p => p.Element_test).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();
            TestcaseExcel testcaseExcel = new TestcaseExcel();
            var testcaseExcels = testcaseExcel.ConvertToTestcaseExcel(testcases);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();
            string filename = "Testcase-" + DateTime.Now.ToString("MM-dd-yyyy") + "-" + Generate_RandomString(5) + ".xlsx";
            var path = Path.Combine(Directory.GetCurrentDirectory(), Constants.EXCEL_FILE, filename);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Test case");
                package.Workbook.Properties.Author = "Genergate testcase web";
                //worksheet.Cells["A2"].LoadFromCollection<TestcaseExcel>(testcaseExcels, true);
                worksheet.Cells[1, 1].Value = "Url: " + url.url1;
                BindingFormatForExcel(worksheet, testcaseExcels);
                fileContents = package.GetAsByteArray();
                System.IO.File.WriteAllBytes(path, fileContents);// save to dissk

            }


            if (fileContents == null || fileContents.Length == 0)
            {
                NotFound();
            }
            else
            {
                string emailcontent = "Thank you for using our service. " +
                           "The excel file has been attached below.";
                await SendMail.SendMailWithFile(emailcontent, user.Email, "Export Test case", path);
                //await SendMail.SendMailWithFile("file exel", user.Email, "Export Excel", path);
            }


        }
        public async Task SendExcelBackground(int id_url, List<string> list_Idtestcase, string id_result, string id_user)
        {
            var user = _context.AspNetUsers.Find(id_user);
            var url = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();
            var testcases = await _context.Result_testcase.Include(d => d.id_).Include(i => i.Input_Result_test).Include(p => p.Test_element_Result_test).Where(p => p.id_url == id_url && p.id_result == id_result).ToListAsync();
            TestcaseExcel testcaseExcel = new TestcaseExcel();
            var testcaseExcels = testcaseExcel.ConvertToTestcaseExcel(testcases);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();
            string filename = "Testcase-" + DateTime.Now.ToString("MM-dd-yyyy") + "-" + Generate_RandomString(5) + ".xlsx";
            var path = Path.Combine(Directory.GetCurrentDirectory(), Constants.EXCEL_FILE, filename);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Test case");
                package.Workbook.Properties.Author = "Genergate testcase web";
                //worksheet.Cells["A2"].LoadFromCollection<TestcaseExcel>(testcaseExcels, true);
                worksheet.Cells[1, 1].Value = "Url: " + url.url1;
                BindingFormatForExcel(worksheet, testcaseExcels);
                fileContents = package.GetAsByteArray();
                System.IO.File.WriteAllBytes(path, fileContents);// save to dissk

            }


            if (fileContents == null || fileContents.Length == 0)
            {
                NotFound();
            }
            else
            {
                string emailcontent = "Thank you for using our service. " +
                           "The excel file has been attached below.";
                await SendMail.SendMailWithFile(emailcontent, user.Email, "Export Test case", path);
                //await SendMail.SendMailWithFile("file exel", user.Email, "Export Excel", path);
            }


        }
        [HttpPost]
        public async Task<IActionResult> DownloadExcel(List<string> list_Idtestcase, int id_url)
        {
            var testcases = await _context.Test_case.Include(i => i.Input_testcase).Include(p => p.Element_test).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();
            var url = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();

            TestcaseExcel testcaseExcel = new TestcaseExcel();
            var testcaseExcels = testcaseExcel.ConvertToTestcaseExcel(testcases);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Test case");
                package.Workbook.Properties.Author = "Genergate testcase web";
                //worksheet.Cells["A2"].LoadFromCollection<TestcaseExcel>(testcaseExcels, true);
                worksheet.Cells[1, 1].Value = "Url: " + url.url1;
                BindingFormatForExcel(worksheet, testcaseExcels);
                fileContents = package.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Testcase.xlsx"
                );
        }
        [HttpPost]
        public async Task<IActionResult> DownloadExcel2(List<string> list_Idtestcase, int id_url, string id_result)
        {
            var testcases = await _context.Result_testcase.Include(d => d.id_).Include(i => i.Input_Result_test).Include(p => p.Test_element_Result_test).Where(p => p.id_url == id_url && p.id_result == id_result).ToListAsync();
            var url = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();

            TestcaseExcel testcaseExcel = new TestcaseExcel();
            var testcaseExcels = testcaseExcel.ConvertToTestcaseExcel(testcases);
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Test case");
                package.Workbook.Properties.Author = "Genergate testcase web";
                //worksheet.Cells["A2"].LoadFromCollection<TestcaseExcel>(testcaseExcels, true);
                worksheet.Cells[1, 1].Value = "Url: " + url.url1;
                BindingFormatForExcel(worksheet, testcaseExcels);
                fileContents = package.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Testcase.xlsx"
                );
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<TestcaseExcel> listItems)
        {
            // Set default width cho tất cả column
            //worksheet.DefaultColWidth = 10;
            worksheet.Cells["A1:C1"].Merge = true;
            worksheet.Cells[1, 1].Style.Font.SetFromFont(new Font("Arial", 14));
            worksheet.Column(1).Width = 50;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 30;
            worksheet.Column(5).Width = 150;
            worksheet.Column(6).Width = 150;
            worksheet.Column(7).Width = 150;
            worksheet.Cells[2, 1].Value = "No.";
            worksheet.Cells[2, 2].Value = "Test case";
            worksheet.Cells[2, 3].Value = "Description";
            worksheet.Cells[2, 4].Value = "Actural results";
            //worksheet.Cells[2, 5].Value = "Test Data";
            worksheet.Cells[2, 5].Value = "Test steps";
            //worksheet.Cells[2, 6].Value = "Test Elements";
            worksheet.Cells[2, 6].Value = "Expected results";
            worksheet.Cells[2, 7].Value = "Result Test Elements";
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header

            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A2:G2"])
            {
                // Set PatternType
                //range.Style.Fill.PatternType = ExcelFillStyle.;
                // Set Màu cho Background
                // range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Arial", 12));
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                // Set màu ch Border
                range.Style.Border.Bottom.Color.SetColor(Color.Blue);
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listItems.Count; i++)
            {
                var item = listItems[i];
                worksheet.Cells[i + 3, 1].Value = i + 1;
                worksheet.Cells[i + 3, 2].Value = item.Id_testcase;
                worksheet.Cells[i + 3, 3].Value = item.Description;
                worksheet.Cells[i + 3, 4].Value = item.Result;
                worksheet.Cells[i + 3, 5].Value = item.TestData;
                worksheet.Cells[i + 3, 6].Value = item.TestElement;
                worksheet.Cells[i + 3, 7].Value = item.ResultTestElement;

                worksheet.Cells[i + 3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 3, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[i + 3, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                // Format lại color nếu như thỏa điều kiện
                // Ở đây chúng ta sẽ format lại theo dạng fromRow,fromCol,toRow,toCol
                using (var range = worksheet.Cells[i + 3, 4])
                {
                    // Format text đỏ và đậm
                    if (item.Result == "Pass")
                    {
                        range.Style.Font.Color.SetColor(Color.Green);
                    }
                    else if (item.Result == "Skip")
                    {
                        range.Style.Font.Color.SetColor(Color.Blue);
                    }
                    else
                    {
                        range.Style.Font.Color.SetColor(Color.Red);
                    }

                    range.Style.Font.Bold = true;
                }


            }
            /*
            //// Format lại định dạng xuất ra ở cột Money
            //worksheet.Cells[2, 4, listItems.Count + 4, 4].Style.Numberformat.Format = "$#,##.00";
            // fix lại width của column với minimum width là 15
            //worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);

            // Thực hiện tính theo formula trong excel
            // Hàm Sum 
            //worksheet.Cells[listItems.Count + 3, 3].Value = "Total is :";
            //worksheet.Cells[listItems.Count + 3, 4].Formula = "SUM(D2:D" + (listItems.Count + 1) + ")";
            // Hàm SumIf
            //worksheet.Cells[listItems.Count + 4, 3].Value = "Greater than 20050 :";
            //worksheet.Cells[listItems.Count + 4, 4].Formula = "SUMIF(D2:D" + (listItems.Count + 1) + ",\">20050\")";
            // Tinh theo %
            //worksheet.Cells[listItems.Count + 5, 3].Value = "Percentatge: ";
            //worksheet.Cells[listItems.Count + 5, 4].Style.Numberformat.Format = "0.00%";
            // Dòng này có nghĩa là ở column hiện tại lấy với địa chỉ (Row hiện tại - 1)/ (Row hiện tại - 2) Cùng một colum
            //worksheet.Cells[listItems.Count + 5, 4].FormulaR1C1 = "(R[-1]C/R[-2]C)";
            */
        }
        #endregion
        #region Url Redirect
        [HttpPost]
        public async Task<IActionResult> UrlRedirect(int id_url, string id_testcase, string redirect_url_test, string returnUrl)
        {

            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                var urlred = await _context.Redirect_url.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                if (urlred == null)
                {
                    try
                    {
                        urlred = new Redirect_url();
                        urlred.current_url = "";
                        urlred.id_testcase = id_testcase;
                        urlred.id_url = id_url;
                        urlred.redirect_url_test = redirect_url_test;
                        _context.Redirect_url.Add(urlred);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Add successfully";
                    }
                    catch
                    {
                        StatusMessage = "Update fail";

                    }
                }
                else
                {


                    try
                    {
                        urlred.redirect_url_test = redirect_url_test;
                        _context.Update(urlred);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Update successfully";
                    }
                    catch
                    {
                        StatusMessage = "Update fail";

                    }

                    //return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
                }
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction(nameof(TestElement), new { id_url = id_url, id_testcase = id_testcase });
            }
            return NotFound();

        }
        #endregion
        #region Alert Message alertMessage
        [HttpPost]
        public async Task<IActionResult> AlertMessage(int id_url, string id_testcase, string alertMessage, string returnUrl)
        {

            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var _context = new ElementDBContext();
                var alert_Message = await _context.Alert_message.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
                if (alert_Message == null)
                {
                    try
                    {
                        alert_Message = new Alert_message();
                        alert_Message.message = alertMessage;
                        alert_Message.id_testcase = id_testcase;
                        alert_Message.id_url = id_url;
                        alert_Message.id_alert = Guid.NewGuid().ToString("N").Substring(10);
                        _context.Alert_message.Add(alert_Message);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Add successfully";
                    }
                    catch
                    {
                        StatusMessage = "Update failed";

                    }
                }
                else
                {


                    try
                    {
                        alert_Message.message = alertMessage;
                        _context.Update(alert_Message);
                        await _context.SaveChangesAsync();
                        StatusMessage = "Update successfully";
                    }
                    catch
                    {
                        StatusMessage = "Update failed";

                    }

                    //return RedirectToAction(nameof(Index), new { id_url = id_url, isload = true });
                }
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction(nameof(TestElement), new { id_url = id_url, id_testcase = id_testcase });
            }
            return NotFound();

        }
        #endregion
        /* temp

        // GET: TestCase/GenerateTestCases/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case
                .Include(t => t.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_testcase == id);
            if (test_case == null)
            {
                return NotFound();
            }

            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Create
        public IActionResult Create()
        {
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name");
            return View();
        }

        // POST: TestCase/GenerateTestCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_testcase,id_url,description,result,is_test,CreatedDate,ModifiedDate")] Test_case test_case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test_case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case.FindAsync(id);
            if (test_case == null)
            {
                return NotFound();
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // POST: TestCase/GenerateTestCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_testcase,id_url,description,result,is_test,CreatedDate,ModifiedDate")] Test_case test_case)
        {
            if (id != test_case.id_testcase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test_case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Test_caseExists(test_case.id_testcase))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", test_case.id_url);
            return View(test_case);
        }

        // GET: TestCase/GenerateTestCases/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test_case = await _context.Test_case
                .Include(t => t.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_testcase == id);
            if (test_case == null)
            {
                return NotFound();
            }

            return View(test_case);
        }

        // POST: TestCase/GenerateTestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var test_case = await _context.Test_case.FindAsync(id);
            _context.Test_case.Remove(test_case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool Test_caseExists(string id)
        {
            return _context.Test_case.Any(e => e.id_testcase == id);
        }
    }
}
