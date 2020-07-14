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
using Microsoft.AspNetCore.Identity;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Routing;
using OpenQA.Selenium.Chrome;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class ManageController : Controller
    {
        private readonly ElementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public ManageController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }

        #region Dashboard
        [Route("/Manage/Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            var listProject = await _context.Project.Where(p => p.Id_User == user.Id).ToListAsync();
            var listurl = await _context.Url.Include(p => p.project_).ThenInclude(p => p.Id_UserNavigation).Where(p => p.project_.Id_User == user.Id).ToListAsync();
            var listestcase = await _context.Test_case.Include(p => p.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_urlNavigation.project_.Id_User == user.Id).ToListAsync();
            var listresult = await _context.Result_testcase.Include(i => i.id_resultNavigation).Where(p => p.id_resultNavigation.id_user == user.Id).ToListAsync();
            ViewData["CountProjects"] = listProject.Count();
            ViewData["CountUrls"] = listurl.Count();
            ViewData["CountTestcases"] = listestcase.Count();
            ViewData["CountResult"] = listresult.Count();
            return View();
        }

        #endregion

        #region Project
        //Get list project
        [Route("/Manage/Projects")]
        public async Task<IActionResult> Projects()
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext = await _context.Project.Include(p => p.Id_UserNavigation).Where(p => p.Id_User == user.Id).OrderByDescending(d => d.ModifiedDate).ToListAsync();
            if (StatusMessage == null)
            {
                if (elementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No projects yet, create a new one";
                }
                else
                if (elementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Found {0} projects", elementDBContext.Count());
                }
                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            return View(elementDBContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(string projectName, string description)
        {
            Project project = new Project();
            if (ModelState.IsValid)
            {
                try
                {
                    project.description = description;
                    var user = await _userManager.GetUserAsync(User);
                    project.Id_User = user.Id;
                    project.name = projectName;
                    project.CreatedDate = DateTime.Now.Date;
                    project.ModifiedDate = DateTime.Now.Date;
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Add successfully";
                }
                catch
                {

                    StatusMessage = "Add project failed";
                }
                //return RedirectToAction("AddNewUrl", "Urls", new RouteValueDictionary(new { project_id = project.id }));
            }
            return RedirectToAction(nameof(Projects));

        }
        #endregion

        #region Url
        //Get list url
        [Route("/Manage/Urls/")]
        public async Task<IActionResult> Urls(int project_id)
        {
            var user = await _userManager.GetUserAsync(User);
            var elementDBContext = await _context.Url.Include(p => p.project_).Include(p => p.Test_case).Include(p => p.Element).Where(p => p.project_.Id_User == user.Id && p.project_id == project_id).OrderByDescending(p => p.ModifiedDate).ToListAsync();
            if (StatusMessage == null)
            {
                if (elementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No url yet, create a new one";
                }
                else
                if (elementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Found {0} url", elementDBContext.Count());
                }
                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
            {
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
            }
            ViewData["project_id"] = project_id;
            ViewData["project_name"] = _context.Project.Find(project_id).name;
            return View(elementDBContext);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUrl(string name, string url1, int project_id, bool IsOnlyDislayed, string trigger_element, bool IsGetTagA)
        {
            Url url = new Url();
            try
            {
                url.name = name;
                url.project_id = project_id;
                url.url1 = url1;
                url.trigger_element = trigger_element;
                url.CreatedDate = DateTime.Now.Date;
                url.ModifiedDate = DateTime.Now.Date;
                _context.Add(url);
                await _context.SaveChangesAsync();
                StatusMessage = "Add successful url";

                // return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = url.id_url, IsOnlyDislayed = IsOnlyDislayed }));
            }
            catch
            {

                StatusMessage = "Add failed";
            }

            return RedirectToAction(nameof(Urls), new { project_id = project_id });


            //return RedirectToAction("CrawlElt", "CrawlElements", new RouteValueDictionary(new { id_url = 1, IsOnlyDislayed = IsOnlyDislayed }));
        }

        public async Task<IActionResult> AddNewSubUrl(int project_id, string id_testcase, int id_url)
        {
            ViewData["project_id"] = project_id;
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            ViewData["project_name"] = _context.Project.Find(project_id).name;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSubUrl(string name, string url1, bool IsChange, string id_testcase, bool IsOnlyDislayed, int project_id, int id_url, string trigger_element, bool IsGetTagA)
        {
            Url url = new Url();
            try
            {
                url.name = name;
                url.project_id = project_id;
                url.url1 = url1;
                url.trigger_element = trigger_element;
                url.CreatedDate = DateTime.Now.Date;
                url.ModifiedDate = DateTime.Now.Date;
                url.IsChange = IsChange;
                _context.Add(url);
                await _context.SaveChangesAsync();
                StatusMessage = "Add successful url";

            }
            catch
            {

                StatusMessage = "Add failed";
            }

            return RedirectToAction("CrawlEltSubUrl", "CrawlElements", new
            {
                area = "TestCase",
                project_id = project_id,
                id_url = url.id_url,
                //id_url = 46,
                IsOnlyDislayed = IsOnlyDislayed,
                prerequisite_url = id_url,
                prerequisite_testcase = id_testcase,
                IsGetTagA = IsGetTagA
            });
            //return RedirectToAction("CrawlEltSubUrl", "CrawlElements", new { area="TestCase",project_id = project_id, id_url = 41, IsOnlyDislayed = IsOnlyDislayed , prerequisite_url =id_url,
            //    prerequisite_testcase= id_testcase
            //});
        }

        public async Task<IActionResult> DeleteUrl(int id_url, string returnUrl, int project_id)
        {


            try
            {
                var url = await _context.Url.Include(o => o.Element).Include(p => p.Form_elements).Where(p => p.id_url == id_url && p.project_id == project_id).SingleOrDefaultAsync();
                if (url.Element != null)
                {
                    _context.Element.RemoveRange(url.Element);

                }
                if (url.Form_elements != null)
                {
                    _context.Form_elements.RemoveRange(url.Form_elements);

                }
                if (url != null)
                {
                    _context.Url.Remove(url);
                }


                _context.SaveChanges();
                StatusMessage = "Delete successfully";
            }
            catch (Exception e)
            {
                var a = e.Message;
                StatusMessage = "Delete failed";
            }
            return RedirectToAction(nameof(Urls), new RouteValueDictionary(new
            {
                id_url = id_url,
                project_id = project_id

            }));
        }
        #endregion

        #region Elements
        [Route("/Manage/Elements/")]
        public async Task<IActionResult> Elements(int id_url)
        {
            var user = await _userManager.GetUserAsync(User);
            var listelt = await _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id).ToListAsync();
            if (listelt.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listelt.Count() == 0)
                    {
                        ViewData["Message"] = "No elements yet";
                    }
                    else
                    if (listelt.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} elements", listelt.Count());
                    }
                    else
                    {
                        ViewData["Message"] = "Error load data";
                    }
                }
                else
                {
                    ViewData["Message"] = StatusMessage;
                    TempData.Remove(StatusMessage);
                }
                ViewData["id_url"] = id_url;
                ViewData["project_id"] = listelt.FirstOrDefault().id_urlNavigation.project_.id;
                int countsubmit = listelt.Where(p => p.type == "submit").Count();
                if (countsubmit == 0)
                {
                    ViewData["Nosubmit"] = true;
                }
                else
                    ViewData["Nosubmit"] = false;
                return View(listelt);
            }
            return View(listelt);

        }
        [Route("/SubTestCase/Elements/")]
        public async Task<IActionResult> Elements_SubTestcase(int id_url, string prerequisite_testcase, int prerequisite_url)
        {
            var user = await _userManager.GetUserAsync(User);
            var listelt = await _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id).ToListAsync();

            if (listelt.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listelt.Count() == 0)
                    {
                        ViewData["Message"] = "No elements yet";
                    }
                    else
                    if (listelt.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} elements", listelt.Count());
                    }
                    else
                    {
                        ViewData["Message"] = "Error load data";
                    }
                }
                else
                {
                    ViewData["Message"] = StatusMessage;
                    TempData.Remove(StatusMessage);
                }
                ViewData["id_url"] = id_url;
                ViewData["prerequisite_testcase"] = prerequisite_testcase;
                ViewData["prerequisite_url"] = prerequisite_url;
                ViewData["project_id"] = listelt.FirstOrDefault().id_urlNavigation.project_.id;
                int countsubmit = listelt.Where(p => p.type == "submit").Count();
                if (countsubmit == 0)
                {
                    ViewData["Nosubmit"] = true;
                }
                else
                    ViewData["Nosubmit"] = false;
                return View(listelt);
            }
            return View(listelt);

        }
        public async Task<IActionResult> DeleteElts(int id_url, IEnumerable<string> eltId_Delete, bool isGenerate, string returnUrl, string prerequisite_testcase, int prerequisite_url)
        {
            if (isGenerate)
            {
                return RedirectToAction("Generate_testcase_selectedElement", "GenerateTestCases", new RouteValueDictionary(new
                {
                    id_url = id_url,
                    isGenerate = isGenerate,
                    returnUrl = returnUrl,
                    eltId = eltId_Delete,
                    prerequisite_testcase = prerequisite_testcase,
                    prerequisite_url = prerequisite_url

                }));
            }
            if (eltId_Delete == null)
            {
                return NotFound();
            }
            try
            {
                foreach (var id in eltId_Delete)
                {
                    var element = await _context.Element.Where(p => p.id_element == id && p.id_url == id_url).FirstOrDefaultAsync();
                    _context.Element.RemoveRange(element);
                }
                await _context.SaveChangesAsync();
                StatusMessage = "Delete successfully";
            }
            catch
            {
                StatusMessage = "Delete failed";
            }
            if (prerequisite_testcase != null && prerequisite_url != -1)
            {
                return RedirectToAction(nameof(Elements_SubTestcase), new RouteValueDictionary(new
                {
                    id_url = id_url,
                    prerequisite_testcase = prerequisite_testcase,
                    prerequisite_url = prerequisite_url
                }));
            }
            return RedirectToAction(nameof(Elements), new RouteValueDictionary(new
            {
                id_url = id_url

            }));
        }
        public async Task<IActionResult> DeleteElt(int id_url, IEnumerable<string> eltId_Delete, bool isGenerate, string returnUrl, string prerequisite_testcase, int prerequisite_url)
        {
            if (isGenerate)
            {
                return RedirectToAction("Generate_testcase_selectedElement", "GenerateTestCases", new RouteValueDictionary(new
                {
                    id_url = id_url,
                    isGenerate = isGenerate,
                    returnUrl = returnUrl,
                    eltId = eltId_Delete,
                    prerequisite_testcase = prerequisite_testcase,
                    prerequisite_url = prerequisite_url

                }));
            }
            if (eltId_Delete == null)
            {
                return NotFound();
            }
            try
            {
                foreach (var id in eltId_Delete)
                {
                    var element = await _context.Element.Where(p => p.id_element == id && p.id_url == id_url).FirstOrDefaultAsync();
                    _context.Element.RemoveRange(element);
                }
                await _context.SaveChangesAsync();
                StatusMessage = "Delete successfully";
            }
            catch
            {
                StatusMessage = "Delete failed";
            }
            return RedirectToAction(nameof(Elements_SubTestcase), new RouteValueDictionary(new
            {
                id_url = id_url,
                prerequisite_testcase = prerequisite_testcase,
                prerequisite_url = prerequisite_url

            }));
        }
        [HttpPost]
        public async Task<IActionResult> AddSubmit(string id_element, int id_url)
        {
            try
            {
                var elt = await _context.Element.Where(p => p.id_element == id_element && p.id_url == id_url).SingleOrDefaultAsync();
                if (elt != null)
                {
                    elt.type = "submit";
                    _context.Element.Update(elt);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Update successfully";
                }

            }
            catch
            {
                StatusMessage = "Update fail";
            }
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new
            {
                id_url = id_url

            }));
        }

        #endregion

        #region Test case
        [Route("/Manage/Testcases/")]
        public async Task<IActionResult> Testcases(int id_url)
        {
            var user = await _userManager.GetUserAsync(User);
            var listtestcase = await _context.Test_case.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Include(t => t.Element_test).Include(a => a.Alert_message)
                .Include(r => r.Redirect_url).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == user.Id).OrderBy(p => p.TestType).OrderByDescending(p => p.ModifiedDate).ToListAsync();
            if (listtestcase.Count > 0)
            {
                //var listelt = await _context.Element.Where(p => p.id_url == id_url).ToListAsync();
                if (StatusMessage == null)
                {
                    if (listtestcase.Count() == 0)
                    {
                        ViewData["Message"] = "No test cases yet";
                    }
                    else
                    if (listtestcase.Count() > 0)
                    {
                        ViewData["Message"] = String.Format("Found {0} test cases", listtestcase.Count());
                    }
                    else
                    {
                        ViewData["Message"] = "Error load data";
                    }
                }
                else
                {
                    ViewData["Message"] = StatusMessage;
                    TempData.Remove(StatusMessage);
                }
                ViewData["id_url"] = id_url;
                ViewData["project_id"] = listtestcase.FirstOrDefault().id_urlNavigation.project_.id;
                ViewData["url_name"] = listtestcase.FirstOrDefault().id_urlNavigation.name;
                ViewData["LoadingTitle"] = "Running test case. Please wait.";
                return View(listtestcase);
            }
            return View(listtestcase);

        }
        [Route("/Manage/Testcases/Result")]
        public async Task<IActionResult> TestcasesResult(int id_url, List<string> list_Idtestcase)
        {
            ViewData["id_url"] = id_url;
            var id = _userManager.GetUserId(User);
            int authen = _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).Count();
            if (authen > 0)
            {
                var testcaseDBContext = await _context.Test_case.Include(t => t.id_urlNavigation).ThenInclude(p => p.project_).Include(p => p.Input_testcase).Where(p => p.id_url == id_url && list_Idtestcase.Contains(p.id_testcase)).ToListAsync();

                ViewData["Pass"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("pass")).Count();
                ViewData["Skip"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("skip")).Count();
                ViewData["Failure"] = testcaseDBContext.Where(p => p.result.ToLower().Equals("failure")).Count();
                ViewData["id_url"] = id_url;
                ViewData["project_id"] = testcaseDBContext.FirstOrDefault().id_urlNavigation.project_.id;
                ViewData["url_name"] = testcaseDBContext.FirstOrDefault().id_urlNavigation.name;
                ViewData["Message"] = StatusMessage;
                TempData.Remove(StatusMessage);
                return View(testcaseDBContext);
            }
            return NotFound();

        }
        public async Task<IActionResult> DuplicateTestcase(int project_id, string id_testcase, int id_url)
        {
            try
            {
                var test_Case = await _context.Test_case.Include(p => p.Input_testcase).Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefaultAsync();
                var id_testcasenew = Guid.NewGuid().ToString("N").Substring(10);
                Test_case duplicateelt = new Test_case();
                duplicateelt.id_url = id_url;
                duplicateelt.id_testcase = id_testcasenew;
                duplicateelt.CreatedDate = DateTime.Now;
                duplicateelt.ModifiedDate = DateTime.Now;
                duplicateelt.is_test = true;
                duplicateelt.result = "";
                duplicateelt.description = test_Case.description+"-Copy";
                duplicateelt.TestType = test_Case.TestType;
                duplicateelt.id_prerequisite_testcase = test_Case.id_prerequisite_testcase;
                duplicateelt.id_prerequisite_url = test_Case.id_prerequisite_url;
                _context.Test_case.Add(duplicateelt);
                _context.SaveChanges();
                foreach (var i in test_Case.Input_testcase)
                {
                    Input_testcase newinput = new Input_testcase();
                    newinput.id_element = i.id_element;
                    newinput.id_testcase = id_testcasenew;
                    newinput.id_url = id_url;
                    newinput.value = i.value;
                    newinput.action = i.action;
                    newinput.xpath = i.xpath;
                    newinput.test_step = i.test_step;
                    _context.Input_testcase.Add(newinput);
                }
                _context.SaveChanges();
                StatusMessage = "Duplicate successfully";
            }
            catch
            {
                StatusMessage = "Duplicate failed";
            }
            return RedirectToAction("Testcases", new { id_url = id_url });
        }
        #endregion

        #region test elements
        [Route("/Manage/Testcase/TestElement")]
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
        #endregion

        #region Test data
        [Route("/Manage/Testcase/TestDatas")]
        public async Task<IActionResult> TestDatas(int id_url, string id_testcase)
        {
            ViewData["Message"] = StatusMessage;
            TempData.Remove("StatusMessage");
            ViewData["id_url"] = id_url;
            ViewData["id_testcase"] = id_testcase;
            var testdataDBContext = await _context.Input_testcase.Include(i => i.id_).Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToListAsync();
            if (ViewData["Message"] == null)
            {
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
            }
            return View(testdataDBContext);
        }
        [Route("/Manage/Testcase/TestDatas/ChangeOption")]
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
            return RedirectToAction("TestDatas", new { id_url = id_url, id_testcase = id_testcase });
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
            return RedirectToAction("TestDatas", new { id_url = id_url, id_testcase = id_testcase });
        }
        #endregion

    }
}