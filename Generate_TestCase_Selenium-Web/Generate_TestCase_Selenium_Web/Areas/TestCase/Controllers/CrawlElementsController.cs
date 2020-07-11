﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Generate_TestCase_Selenium_Web.Models.Contexts;
using Generate_TestCase_Selenium_Web.Models.ModelDB;
using Microsoft.AspNetCore.Authorization;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.AspNetCore.Routing;
using Generate_TestCase_Selenium_Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace Generate_TestCase_Selenium_Web.Areas.TestCase.Controllers
{
    [Area("TestCase")]
    [Authorize]
    public class CrawlElementsController : Controller
    {
        [TempData]
        public string StatusMessage { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ElementDBContext _context;
        private ChromeDriver chromedriver;
        private List<Form_elements> listForm;
        private List<Element> listElt;
        private int id_for_elt = 0;
        private string[] tag_elts;
        private string[] type_elts;
        private bool IsOnlyDislayed = false;
        private string Url;
        public CrawlElementsController(UserManager<ApplicationUser> userManager)
        {
            _context = new ElementDBContext();
            _userManager = userManager;
        }

        // GET: TestCase/CrawlElements
        public async Task<IActionResult> Index(int id_url)
        {
            ViewData["Message"] = StatusMessage;
            var id = _userManager.GetUserId(User);
            // var elementDBContext = await _context.Element.Include(e =>e.id_urlNavigation).Where(p => p.id_url == id_url).ToListAsync();
            var elementDBContext = await _context.Element.Include(e => e.id_urlNavigation).ThenInclude(p => p.project_).Where(p => p.id_url == id_url && p.id_urlNavigation.project_.Id_User == id).ToListAsync();
            ViewData["id_url"] = id_url;
            if (ViewData["Message"] == null)
            {
                if (elementDBContext.Count() == 0)
                {
                    ViewData["Message"] = "No element yet";
                }
                else
         if (elementDBContext.Count() > 0)
                {
                    ViewData["Message"] = String.Format("Success, {0} element(s) were found", elementDBContext.Count());
                }

                else
                {
                    ViewData["Message"] = "Error load data";
                }
            }
            else
            {

            }
            if (StatusMessage != null)
            {
                TempData.Remove(StatusMessage);
            }
            ViewData["LoadingTitle"] = "Generating test case. Please wait.";
            int countsubmit = elementDBContext.Where(p => p.type == "submit").Count();
            if (countsubmit == 0)
            {
                ViewData["Nosubmit"] = true;
            }
            else
                ViewData["Nosubmit"] = false;
            return View(elementDBContext);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteList(int id_url, IEnumerable<string> eltId_Delete)
        {
            try
            {
                if (eltId_Delete == null)
                {
                    return NotFound();
                }
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
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new
            {
                id_url = id_url

            }));
        }
        public async Task<IActionResult> CrawlElt(int id_url, bool IsOnlyDislayed, bool IsGetTagA = true, string returnUrl = null)
        {
            //--Code, dont delete
            string Url = _context.Url.Where(p => p.id_url == id_url).FirstOrDefault().url1;
            this.IsOnlyDislayed = IsOnlyDislayed;
            try
            {
                SetUp(Url);
            }
            catch
            {
                SetUp(Url);
            }

            int isSuccess = GetElements(Url, IsOnlyDislayed, id_url, IsGetTagA);
            if (isSuccess == 1)
            {
                if (listForm != null)
                    _context.Form_elements.AddRange(listForm);
                if (listElt != null)
                    _context.Element.AddRange(listElt);
                await _context.SaveChangesAsync();
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(Index), new RouteValueDictionary(new
                    {
                        id_url = id_url
                    }));
                }

            }

            return RedirectToAction(nameof(Index), new RouteValueDictionary(new
            {
                id_url = id_url

            }));

        }
        public async Task<IActionResult> CrawlEltSubUrl(int id_url, bool IsOnlyDislayed, string prerequisite_testcase, int prerequisite_url, bool IsGetTagA = true)
        {
            //--Code, dont delete
            string Url = _context.Url.Where(p => p.id_url == id_url).FirstOrDefault().url1;
            this.IsOnlyDislayed = IsOnlyDislayed;
            SetUp(Url);
            int isSuccess = await GetSubElements(Url, IsOnlyDislayed, id_url, prerequisite_testcase, prerequisite_url, IsGetTagA);
            if (isSuccess == 1)
            {
                if (listForm != null)
                    _context.Form_elements.AddRange(listForm);
                if (listElt != null)
                    _context.Element.AddRange(listElt);
                await _context.SaveChangesAsync();
                //if (returnUrl != null)
                //{
                //    return LocalRedirect(returnUrl);
                //}
                //else
                //{
                //    return RedirectToAction(nameof(Index), new RouteValueDictionary(new
                //    {
                //        id_url = id_url
                //    }));
                //}
                return RedirectToAction("Elements_SubTestcase", "Manage", new RouteValueDictionary(new
                {
                    id_url = id_url,
                    prerequisite_testcase = prerequisite_testcase,
                    prerequisite_url = prerequisite_url
                }));
            }

            return RedirectToAction("Elements_SubTestcase", "Manage", new RouteValueDictionary(new
            {
                id_url = id_url,
                prerequisite_testcase = prerequisite_testcase,
                prerequisite_url = prerequisite_url
            }));

        }
        #region Get Element from Web
        public int GetElements(string Url, bool IsOnlyDislayed, int id_url, bool IsGetTagA)
        {
            int flag = 0;
            var URL = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault();
            try
            {
                // usertesstvf
                SetUpDriver(Url);
                if (URL.trigger_element != null && URL.trigger_element != "")
                {
                    var trigger = chromedriver.FindElementByXPath(URL.trigger_element);
                    if (trigger.Displayed)
                    {
                        trigger.Click();
                    }
                }
                var form = chromedriver.FindElementsByXPath("//form");
                //List<Form_elements> form = null;
                if (form != null)// have at least one form
                {
                    listForm = new List<Form_elements>();
                    for (int i = 0; i < form.Count; i++)
                    {
                        Form_elements form_ = new Form_elements();
                        if (form[i].GetAttribute("id") != null && form[i].GetAttribute("id") != "")
                            form_.id_form = form[i].GetAttribute("id");
                        else
                            form_.id_form = "form_" + i;
                        form_.id_url = id_url;
                        try
                        {
                            form_.name = form[i].GetAttribute("name");
                        }
                        catch { }
                        try
                        {
                            form_.xpath = getAbsoluteXPath(chromedriver, form[i]);
                        }
                        catch { }
                        listForm.Add(form_);


                    }
                    var isgetlink = true;
                    if (IsGetTagA == false)
                    {
                        //tag_elts = tag_elts.Where(p => p.ToLower() != "a").ToArray();
                        isgetlink = false;
                    }
                    foreach (string tag in tag_elts)
                    {
                        if (this.IsOnlyDislayed)
                            GetElementsOnlyDisplay(chromedriver, tag, "", id_url, listForm, isgetlink);
                        else
                            GetElements(chromedriver, tag, "", id_url, listForm, isgetlink);
                    }
                    //GetElements(chromedriver, id_Url, "a", "", listForm);



                }
                else //no form found
                {
                    var isgetlink = true;
                    if (IsGetTagA == false)
                    {
                        //tag_elts = tag_elts.Where(p => p.ToLower() != "a").ToArray();
                        isgetlink = false;
                    }
                    foreach (string tag in tag_elts)
                    {
                        if (this.IsOnlyDislayed)
                            GetElementsOnlyDisplay(chromedriver, tag, "", id_url, null, isgetlink);
                        else
                            GetElements(chromedriver, tag, "", id_url, null, isgetlink);
                        //Thread thread = new Thread(() => GetElements(chromedriver, tag, "", id_url));
                        //thread.Start();
                        //GetElements(chromedriver, tag, "", id_url);
                    }
                }
                flag = 1;
            }
            catch
            {
                flag = -1;
            }
            CloseDriver();
            return flag;
        }
        public async Task<int> GetSubElements(string Url, bool IsOnlyDislayed, int id_url, string prerequisite_testcase, int prerequisite_url, bool IsGetTagA)
        {
            var URL = await _context.Url.Where(p => p.id_url == id_url).SingleOrDefaultAsync();
            int flag = 0;
            ChromeDriver Chromedriver = null;
            try
            {

                try
                {
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = true;//hide commandPromptWindow

                    var options = new ChromeOptions();
                    //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
                    Chromedriver = new ChromeDriver(service, options);

                }
                catch (Exception e)
                {
                    var a = e.Message;
                }
                var returnUrl = await RunPrerequesiteTestcase(Chromedriver, prerequisite_testcase, prerequisite_url);
                if (URL.IsChange == false)
                {
                    Chromedriver.Url = Url;
                    Chromedriver.Navigate();
                }

                if (URL.trigger_element != null && URL.trigger_element != "")
                {
                    var trigger = Chromedriver.FindElementByXPath(URL.trigger_element);
                    if (trigger.Displayed)
                    {
                        trigger.Click();
                    }
                }
                var form = Chromedriver.FindElementsByXPath("//form");
                if (form != null)// have at least one form
                {
                    listForm = new List<Form_elements>();
                    for (int i = 0; i < form.Count; i++)
                    {
                        Form_elements form_ = new Form_elements(); if (form[i].GetAttribute("id") != null && form[i].GetAttribute("id") != "")
                            form_.id_form = form[i].GetAttribute("id");
                        else
                            form_.id_form = "form_" + i;

                        form_.id_url = id_url;
                        try
                        {
                            form_.name = form[i].GetAttribute("name");
                        }
                        catch { }
                        try
                        {
                            form_.xpath = getAbsoluteXPath(Chromedriver, form[i]);
                        }
                        catch { }
                        listForm.Add(form_);


                    }
                    var isgetlink = true;
                    if (IsGetTagA == false)
                    {
                        //tag_elts = tag_elts.Where(p => p.ToLower() != "a").ToArray();
                        isgetlink = false;
                    }
                    foreach (string tag in tag_elts)
                    {
                        if (this.IsOnlyDislayed)
                            GetElementsOnlyDisplay(Chromedriver, tag, "", id_url, listForm, isgetlink);
                        else
                            GetElements(Chromedriver, tag, "", id_url, listForm, isgetlink);
                    }
                    //GetElements(chromedriver, id_Url, "a", "", listForm);



                }
                else //no form found
                {
                    var isgetlink = true;
                    if (IsGetTagA == false)
                    {
                        //tag_elts = tag_elts.Where(p => p.ToLower() != "a").ToArray();
                        isgetlink = false;
                    }
                    foreach (string tag in tag_elts)
                    {
                        if (this.IsOnlyDislayed)
                            GetElementsOnlyDisplay(chromedriver, tag, "", id_url, null, isgetlink);
                        else
                            GetElements(chromedriver, tag, "", id_url, null, isgetlink);
                        //Thread thread = new Thread(() => GetElements(Chromedriver, tag, "", id_url));
                        //thread.Start();
                        //GetElements(chromedriver, tag, "", id_url);
                    }
                }
                flag = 1;
            }
            catch
            {
                flag = -1;
            }
            Chromedriver.Close();
            return flag;
        }
        public async Task<string> RunPrerequesiteTestcase(ChromeDriver driver, string id_testcase, int id_url)
        {
            string return_url = "";
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            Url URL = _context.Url.Where(p => p.id_url == id_url).SingleOrDefault();
            string url = URL.url1;
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            if (Testcase.id_prerequisite_testcase != null)
            {
                return_url = await RunPrerequesiteTestcase(driver, Testcase.id_prerequisite_testcase, (int)Testcase.id_prerequisite_url);
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
        private void SetUp(string url)
        {
            Url = url;
            listElt = new List<Element>();
            tag_elts = new string[4];
            tag_elts[0] = "input";
            tag_elts[1] = "select";
            tag_elts[2] = "button";
            tag_elts[3] = "a";
            type_elts = new string[9];
            type_elts[0] = "text";
            type_elts[1] = "email";
            type_elts[2] = "button";
            type_elts[3] = "password";
            type_elts[4] = "submit";
            type_elts[5] = "radio";
            type_elts[6] = "checkbox";
            type_elts[7] = "number";
            type_elts[8] = "date";
        }

        private void SetUpDriver(string url)
        {
            try
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;//hide commandPromptWindow

                var options = new ChromeOptions();
                //options.AddArgument("--window-position=-32000,-32000");//hide chrome tab
                chromedriver = new ChromeDriver(service, options);
                chromedriver.Url = url;
                chromedriver.Navigate();
            }
            catch (Exception e)
            {
                var a = e.Message;
            }
        }

        private void QuitDriver()
        {

            chromedriver.Quit();

        }
        private void CloseDriver()
        {

            chromedriver.Close();

        }
        public static String getAbsoluteXPath(ChromeDriver driver, IWebElement element)
        {
            //https://gist.github.com/beatngu13/a3312b98de57610c5ecd27ea84a7fbeb
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            return (String)js.ExecuteScript(
                    "function absoluteXPath(element) {" +
                            "var comp, comps = [];" +
                            "var parent = null;" +
                            "var xpath = '';" +
                            "var getPos = function(element) {" +
                            "var position = 1, curNode;" +
                            "if (element.nodeType == Node.ATTRIBUTE_NODE) {" +
                            "return null;" +
                            "}" +
                            "for (curNode = element.previousSibling; curNode; curNode = curNode.previousSibling) {" +
                            "if (curNode.nodeName == element.nodeName) {" +
                            "++position;" +
                            "}" +
                            "}" +
                            "return position;" +
                            "};" +

                            "if (element instanceof Document) {" +
                            "return '/';" +
                            "}" +

                            "for (; element && !(element instanceof Document); element = element.nodeType == Node.ATTRIBUTE_NODE ? element.ownerElement :element.parentNode) {" +
                            "comp = comps[comps.length] = {};" +
                            "switch (element.nodeType) {" +
                            "case Node.TEXT_NODE:" +
                            "comp.name = 'text()';" +
                            "break;" +
                            "case Node.ATTRIBUTE_NODE:" +
                            "comp.name = '@' + element.nodeName;" +
                            "break;" +
                            "case Node.PROCESSING_INSTRUCTION_NODE:" +
                            "comp.name = 'processing-instruction()';" +
                            "break;" +
                            "case Node.COMMENT_NODE:" +
                            "comp.name = 'comment()';" +
                            "break;" +
                            "case Node.ELEMENT_NODE:" +
                            "comp.name = element.nodeName;" +
                            "break;" +
                            "}" +
                            "comp.position = getPos(element);" +
                            "}" +

                            "for (var i = comps.length - 1; i >= 0; i--) {" +
                            "comp = comps[i];" +
                            "xpath += '/' + comp.name.toLowerCase();" +
                            "if (comp.position !== null) {" +
                            "xpath += '[' + comp.position + ']';" +
                            "}" +
                            "}" +

                            "return xpath;" +

                            "} return absoluteXPath(arguments[0]);", element);
        }
        public static String getElementXPath(ChromeDriver driver, IWebElement elt)
        {
            //https://gist.github.com/beatngu13/a3312b98de57610c5ecd27ea84a7fbeb
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            return (String)js.ExecuteScript(
                    "function getElementXPath(elt) {" +

                        "var path = '';" +
                        "for (; elt && elt.nodeType == 1; elt = elt.parentNode){" +

                            " idx = getElementIdx(elt);" +
                             " xname = elt.tagName;" +
                            " if (idx > 1) xname += '[' + idx + ']';" +
                             "path = '/' + xname + path;}" +


                          " return path;}" +

                    "function getElementIdx(elt){" +

                           "var count = 1;" +
                         " for (var sib = elt.previousSibling; sib; sib = sib.previousSibling){" +

                      "   if (sib.nodeType == 1 && sib.tagName == elt.tagName) count++}" +


                    " return count;}" +
                    "return getElementXPath(arguments[0]);", elt);
        }

        public void GetElements(ChromeDriver driver, string TagName, string TypeName, int id_url, List<Form_elements> form_elts = null, bool IsGetTagA = true)
        {
            List<IWebElement> allElements = new List<IWebElement>();
            if (TypeName != "" && TagName.Equals("input"))
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}[@type='{1}']", TagName, TypeName)).ToList();
            }
            else
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}", TagName, TypeName)).ToList();
            }



            foreach (var item in allElements)
            {

                if (item.TagName.Equals("input") && Array.IndexOf(type_elts, item.GetAttribute("type")) <= -1)
                {

                }
                else
                {
                    Element elt = new Element();
                    elt.xpath = getAbsoluteXPath(driver, item);
                    if (form_elts != null)
                    {
                        //foreach (var form in form_elts)
                        //{
                        //    if (elt.xpath.Contains(form.xpath))
                        //    {

                        //        elt.id_form = form.id_form;

                        //        break;
                        //    }
                        //}
                        string temp = "";
                        foreach (var form in form_elts)
                        {
                            if (elt.xpath.Contains(form.xpath))
                            {
                                if (temp.Length < form.xpath.Length)
                                {
                                    temp = form.id_form;
                                }
                                //elt.id_form = form.id_form;

                                //break;
                            }
                        }
                        elt.id_form = temp;
                    }
                    elt.id_url = id_url;
                    elt.tag_name = item.TagName;
                    try
                    {
                        elt.id_element = item.GetAttribute("id");
                        if (elt.id_element.Equals(""))
                        {
                            elt.id_element = item.TagName + id_for_elt;
                            id_for_elt++;
                        }
                    }
                    catch
                    {
                        elt.id_element = item.TagName + id_for_elt;
                        id_for_elt++;
                    }
                    if (item.TagName == "a" && IsGetTagA == false && item.GetAttribute("href") != null)
                    {

                    }
                    else
                    {
                        if (item.GetAttribute("name") != null)
                        {
                            elt.name = item.GetAttribute("name");
                        }

                        if (item.GetAttribute("value") != null)
                        {
                            elt.value = item.GetAttribute("value");
                        }
                        else
                        {
                            elt.value = "";
                        }

                        if (item.GetAttribute("type") != null)
                        {
                            if (item.GetAttribute("type").Equals("select-multiple"))
                            {
                                elt.multiple = true;
                            }
                            else
                                elt.type = item.GetAttribute("type");
                        }

                        if (item.GetAttribute("title") != null)
                        {
                            elt.title = item.GetAttribute("title");
                        }

                        if (item.GetAttribute("href") != null)
                        {
                            elt.href = item.GetAttribute("href");
                        }

                        if (item.GetAttribute("required") != null)
                        {
                            elt.required = item.GetAttribute("required").Equals("true") ? true : false;
                        }

                        if (item.GetAttribute("class") != null)
                        {
                            elt.class_name = item.GetAttribute("class");
                        }

                        if (item.GetAttribute("maxlength") != null)
                        {
                            elt.maxlength = Double.Parse(item.GetAttribute("maxlength"));
                        }

                        if (item.GetAttribute("minlength") != null)
                        {
                            elt.minlength = Double.Parse(item.GetAttribute("minlength"));
                        }

                        if (item.GetAttribute("max") != null)
                        {
                            elt.max_value = item.GetAttribute("max");
                        }

                        if (item.GetAttribute("min") != null)
                        {
                            elt.min_value = item.GetAttribute("min");
                        }


                        if (item.GetAttribute("readonly") != null)
                        {
                            elt.read_only = item.GetAttribute("readonly").Equals("true") ? true : false;
                        }

                        if (item.GetAttribute("multiple") != null)
                        {
                            elt.multiple = item.GetAttribute("multiple").Equals("true") ? true : false;
                        }



                        listElt.Add(elt);
                    }

                }
            }

        }
        public void GetElementsOnlyDisplay(ChromeDriver driver, string TagName, string TypeName, int id_url, List<Form_elements> form_elts = null, bool IsGetTagA = true)
        {
            List<IWebElement> allElements = new List<IWebElement>();
            if (TypeName != "" && TagName.Equals("input"))
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}[@type='{1}']", TagName, TypeName)).ToList();
            }
            else
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}", TagName, TypeName)).ToList();
            }

            foreach (var item in allElements)
            {

                if (item.TagName.Equals("input") && Array.IndexOf(type_elts, item.GetAttribute("type")) <= -1)
                {

                }
                else if (item.Displayed)
                {
                    Element elt = new Element();
                    elt.xpath = getAbsoluteXPath(driver, item);
                    if (form_elts != null)
                    {
                        string temp = "";
                        foreach (var form in form_elts)
                        {
                            if (elt.xpath.Contains(form.xpath))
                            {
                                if(temp.Length< form.xpath.Length)
                                {
                                    temp = form.id_form;
                                }
                                //elt.id_form = form.id_form;

                                //break;
                            }
                        }
                        elt.id_form = temp;
                    }
                    elt.id_url = id_url;
                    elt.tag_name = item.TagName;

                    try
                    {
                        elt.id_element = item.GetAttribute("id");
                        if (elt.id_element.Equals(""))
                        {
                            elt.id_element = item.TagName + id_for_elt;
                            id_for_elt++;
                        }
                    }
                    catch
                    {
                        elt.id_element = item.TagName + id_for_elt;
                        id_for_elt++;
                    }
                    if (item.TagName == "a" && IsGetTagA == false && item.GetAttribute("href") != null && item.GetAttribute("href").Contains("/"))
                    {

                    }
                    else
                    {
                        if (item.GetAttribute("name") != null)
                        {
                            elt.name = item.GetAttribute("name");
                        }

                        if (item.GetAttribute("value") != null)
                        {
                            if (item.TagName == "select")
                            {

                                var listOption = item.FindElements(By.TagName("option")).ToList();
                                Random random = new Random();
                                int index = random.Next(0, listOption.Count() - 1);
                                elt.value = listOption[index].GetAttribute("value");
                            }
                            else
                                elt.value = item.GetAttribute("value");
                        }
                        else
                        {
                            elt.value = "";
                        }

                        if (item.GetAttribute("type") != null)
                        {
                            if (item.GetAttribute("type").Equals("select-multiple"))
                            {
                                elt.multiple = true;
                            }
                            else
                                elt.type = item.GetAttribute("type");
                        }

                        if (item.GetAttribute("title") != null)
                        {
                            elt.title = item.GetAttribute("title");
                        }

                        if (item.GetAttribute("href") != null)
                        {
                            elt.href = item.GetAttribute("href");
                        }
                        if (item.GetAttribute("class") != null)
                        {
                            elt.class_name = item.GetAttribute("class");
                        }

                        if ((item.TagName != "a"))
                        {
                            if (item.GetAttribute("required") != null)
                            {
                                elt.required = item.GetAttribute("required").Equals("true") ? true : false;
                            }


                            if (item.GetAttribute("maxlength") != null)
                            {
                                elt.maxlength = Double.Parse(item.GetAttribute("maxlength"));
                            }

                            if (item.GetAttribute("minlength") != null)
                            {
                                elt.minlength = Double.Parse(item.GetAttribute("minlength"));
                            }

                            if (item.GetAttribute("max") != null)
                            {
                                elt.max_value = item.GetAttribute("max");
                            }

                            if (item.GetAttribute("min") != null)
                            {
                                elt.min_value = item.GetAttribute("min");
                            }


                            //}
                            if (item.GetAttribute("readonly") != null)
                            {
                                elt.read_only = item.GetAttribute("readonly").Equals("true") ? true : false;
                            }

                            if (item.GetAttribute("multiple") != null)
                            {
                                elt.multiple = item.GetAttribute("multiple").Equals("true") ? true : false;
                            }
                        }

                        if (IsOnlyDislayed == false)
                        {
                            listElt.Add(elt);
                        }
                        else
                             if (item.Displayed == true && IsOnlyDislayed == true)
                        {
                            listElt.Add(elt);
                        }
                    }
                }
            }

        }
        public async Task<string> RunPrerequesiteTestcase(ChromeDriver driver, int id_url, string url, string id_testcase)
        {
            string return_url = "";
            var _context = new ElementDBContext();
            var Testcase = await _context.Test_case.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefaultAsync();
            var list_inputtest = _context.Input_testcase.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).OrderBy(p => p.test_step).ToList();
            var list_output = _context.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).ToList();
            driver.Url = url;
            driver.Navigate();
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
        public void GetElementsOnlyDisplay(ChromeDriver driver, string TagName, string TypeName, int id_url, List<Form_elements> form_elts = null)
        {
            List<IWebElement> allElements = new List<IWebElement>();
            if (TypeName != "" && TagName.Equals("input"))
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}[@type='{1}']",TagName, TypeName)).ToList();
            }
            else
            {
                allElements = driver.FindElementsByXPath(String.Format("//{0}", TagName,TypeName)).ToList();
            }



            foreach (var item in allElements)
            {

                if (item.TagName.Equals("input") && Array.IndexOf(type_elts, item.GetAttribute("type")) <= -1)
                {

                }
                else if (item.Displayed)
                {
                    Element elt = new Element();
                    elt.xpath = getAbsoluteXPath(driver, item);
                    if (form_elts != null)
                    {
                        foreach (var form in form_elts)
                        {
                            if (elt.xpath.Contains(form.xpath))
                            {

                                elt.id_form = form.id_form;

                                break;
                            }
                        }
                    }
                    elt.id_url = id_url;
                    elt.tag_name = item.TagName;
                    try
                    {
                        elt.id_element = item.GetAttribute("id");
                        if (elt.id_element.Equals(""))
                        {
                            elt.id_element = item.TagName + id_for_elt;
                            id_for_elt++;
                        }
                    }
                    catch
                    {
                        elt.id_element = item.TagName + id_for_elt;
                        id_for_elt++;
                    }
                    try
                    {
                        elt.name = item.GetAttribute("name");
                    }
                    catch
                    {

                    }

                    try
                    {
                        elt.value = item.GetAttribute("value");

                    }
                    catch
                    {
                        elt.value = "";
                    }
                    try
                    {

                        elt.type = item.GetAttribute("type");
                        if (item.GetAttribute("type").Equals("select-multiple"))
                        {
                            elt.multiple = true;
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.title = item.GetAttribute("title");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.href = item.GetAttribute("href");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.required = item.GetAttribute("required").Equals("true") ? true : false;
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.class_name = item.GetAttribute("class");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.maxlength = Double.Parse(item.GetAttribute("maxlength"));
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.minlength = Double.Parse(item.GetAttribute("minlength"));
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.max_value = item.GetAttribute("max");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.min_value = item.GetAttribute("min");
                    }
                    catch
                    {

                    }
                    try
                    {
                        elt.read_only = item.GetAttribute("readonly").Equals("true") ? true : false;
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (elt.multiple == null)
                        {
                            elt.multiple = item.GetAttribute("multiple").Equals("true") ? true : false;
                        }
                    }
                    catch
                    {

                    }

                    if (IsOnlyDislayed == false)
                    {
                        listElt.Add(elt);
                    }
                    else
                         if (item.Displayed == true && IsOnlyDislayed == true)
                    {
                        listElt.Add(elt);
                    }

                    //if (BUL.ElementBUL.insert_Element(elt) == -1)
                    //{
                    //    throw new Exception();
                    //}
                }
            }

        }*/

        #endregion

        #region Driver
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
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddSubmit(string id_element, int id_url, string returnurl = "", string prerequisite_url1 = "", string prerequisite_testcase1 ="")
        {
            try
            {
                var elt = await _context.Element.Where(p => p.id_element == id_element && p.id_url == id_url).SingleOrDefaultAsync();
                if(elt!=null)
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
            if(returnurl=="sub")
            {
                return RedirectToAction("Elements_SubTestcase", "Manage", new RouteValueDictionary(new
                {
                    id_url = id_url,
                    prerequisite_testcase= prerequisite_testcase1,
                    prerequisite_url= prerequisite_url1


                }));
            }
            else if(returnurl== "manage")
            {
                return RedirectToAction("Elements", "Manage", new RouteValueDictionary(new
                {
                    id_url = id_url

                }));
            }
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new
            {
                id_url = id_url

            }));
        }

        // GET: TestCase/CrawlElements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element
                .Include(e => e.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_element == id);
            if (element == null)
            {
                return NotFound();
            }

            return View(element);
        }

        // GET: TestCase/CrawlElements/Create
        public IActionResult Create()
        {
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name");
            return View();
        }

        // POST: TestCase/CrawlElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to,for// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_element,id_url,name,class_name,tag_name,type,value,href,title,id_form,minlength,maxlength,required,read_only,max_value,min_value,multiple,xpath")] Element element)
        {
            if (ModelState.IsValid)
            {
                _context.Add(element);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", element.id_url);
            return View(element);
        }

        // GET: TestCase/CrawlElements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", element.id_url);
            return View(element);
        }

        // POST: TestCase/CrawlElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_element,id_url,name,class_name,tag_name,type,value,href,title,id_form,minlength,maxlength,required,read_only,max_value,min_value,multiple,xpath")] Element element)
        {
            if (id != element.id_element)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(element);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementExists(element.id_element))
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
            ViewData["id_url"] = new SelectList(_context.Url, "id_url", "name", element.id_url);
            return View(element);
        }

        // GET: TestCase/CrawlElements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element
                .Include(e => e.id_urlNavigation)
                .FirstOrDefaultAsync(m => m.id_element == id);
            if (element == null)
            {
                return NotFound();
            }

            return View(element);
        }

        // POST: TestCase/CrawlElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var element = await _context.Element.FindAsync(id);
            _context.Element.Remove(element);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementExists(string id)
        {
            return _context.Element.Any(e => e.id_element == id);
        }
    }
}
