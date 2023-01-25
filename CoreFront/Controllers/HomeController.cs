using CoreFront.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataTable dt = new DataTable();
        [System.Obsolete]
        public IHostingEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IFormFile file;

        [Obsolete]
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _webHostEnvironment= webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Institution()
        {
            return View();
        }
        public IActionResult CustomerFileUpload()
        {
            return View();
        }
        public IActionResult ProductMaster()
        {
            return View();
        }
        public IActionResult Quotation()
        {
            return View();
        }
        public IActionResult QuotationManagment()
        {
            return View();
        }
        public IActionResult QuotationProcess()
        {
            return View();
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [System.Obsolete]
        public ActionResult ImportDataInGrid()
        {
            file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();

            if (file != null)
            {
                string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);

                bool firstRow = true;
                sb.Append("<div class='pagination'>");
                sb.Append("<div class='table-wrapper-scroll-y my-custom-scrollbar'>");
                sb.Append("<table id='datatables-reponsive' class='table table-striped' style='width:150%'><tr>");
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {
                                foreach (string cell in row.Split(','))
                                {
                                    //dt.Columns.Add(cell.Trim());
                                    sb.Append("<th>" + dt.Columns.Add(cell.Trim()) + "</th>");
                                }
                                firstRow = false;
                                sb.Append("</tr>");
                            }
                            else
                            {
                                dt.Rows.Add();
                                int Colume = 0;

                                foreach (string cell in row.Split(','))
                                {
                                    if (Colume == 0)
                                    {
                                        bool Titles = isValidTitles(cell);
                                        if (!Titles)
                                            if (!cell.Equals("Mrs.") && !cell.Equals("Mr.") && !cell.Equals("Miss.") && !cell.Equals("Dr.") && !cell.Equals("Er."))
                                            {
                                                return Content("<script language='javascript' type='text/javascript'>alert('Please check Title colum while you are uploading file!');</script>");
                                            }
                                    }
                                    if (Colume == 1)
                                    {
                                        bool EmplyeeName = isValidCher(cell);
                                        if (!EmplyeeName)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Emplyee Name colum contains Alhpa Numaric letters.!');</script>");
                                        }
                                    }
                                    if (Colume == 2)
                                    {
                                        bool CNICNo = isValidCNIC(cell);
                                        if (!CNICNo)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check CNIC Number's colume and Length Should be 13 degits.!');</script>");
                                        }
                                    }
                                    if (Colume == 3)
                                    {
                                        bool PassportNo = isAlphaNumeric(cell);
                                        if (!PassportNo)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Passport Number Only contains Alhpa Numaric letters.!');</script>");
                                        }
                                    }
                                    if (Colume == 4)
                                    {
                                        bool Designation = isValidCher(cell);
                                        if (!Designation)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Designation Colume Only contains letter.!');</script>");
                                        }
                                    }
                                    if (Colume == 5)
                                    {
                                        bool Occupation = isValidCher(cell);
                                        if (!Occupation)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Occupation Colume Only contains letters.!');</script>");
                                        }
                                    }
                                    if (Colume == 6)
                                    {
                                        bool DOB = isValidDate(cell);
                                        if (!DOB)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Date of Birth Colume Only contains Date.!');</script>");
                                        }
                                    }
                                    if (Colume == 7)
                                    {
                                        bool Age = IsValidTwoNumber(cell);
                                        if (!Age)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Age Colume Only contains two number.!');</script>");
                                        }
                                    }
                                    if (Colume == 8)
                                    {
                                        bool Gender = IsValidGender(cell);
                                        if (!Gender)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Gender Colume  Only contains one Char.!');</script>");
                                        }
                                    }
                                    if (Colume == 9)
                                    {
                                        bool Category = isValidCher(cell);
                                        if (!Category)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Category Colume Only contains one Char.!');</script>");
                                        }
                                    }
                                    if (Colume == 10)
                                    {
                                        bool OccupClass = IsValidSingleNumber(cell);
                                        if (!OccupClass)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Occupation colume Class Only contains one Char.!');</script>");
                                        }
                                    }
                                    if (Colume == 11)
                                    {
                                        bool Term = IsValidSingleNumber(cell);
                                        if (!Term)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Term colume Only contains one Char.!');</script>");
                                        }
                                    }
                                    if (Colume == 12)
                                    {
                                        bool EffectDate = EffectiveDate(cell);
                                        if (!EffectDate)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Only contains colume Effective Date.!');</script>");
                                        }
                                    }
                                    if (Colume == 13)
                                    {
                                        bool _EndDate = ENDDate(cell);
                                        if (!_EndDate)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Only contains colume End Date.!');</script>");
                                        }
                                    }
                                    if (Colume == 14)
                                    {
                                        bool Relationship = isValidCher(cell);
                                        if (!Relationship)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Relationship colume Only contains letter.!');</script>");
                                        }
                                    }
                                    if (Colume == 15)
                                    {
                                        bool EMPID = isAlphaNumeric(cell);
                                        if (!EMPID)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Employee colume Only contains Alhpa Numaric.!');</script>");
                                        }
                                    }
                                    if (Colume == 16)
                                    {
                                        bool Family_Id = isAlphaNumeric(cell);
                                        if (!Family_Id)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Family Id colume Only contains Alhpa Numaric.!');</script>");
                                        }
                                    }
                                    if (Colume == 17)
                                    {
                                        bool Headoffice = isValidCher(cell);
                                        if (!Headoffice)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Head office colume Only contains letter.!');</script>");
                                        }
                                    }
                                    if (Colume == 18)
                                    {
                                        bool Branch = isValidCher(cell);
                                        if (!Branch)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Branch colume Only contains letter.!');</script>");
                                        }
                                    }
                                    if (Colume == 19)
                                    {
                                        bool Salaries = IsValidNumber(cell);
                                        if (!Salaries)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Salaries colume Only contains Number.!');</script>");
                                        }
                                    }
                                    if (Colume == 20)
                                    {
                                        bool Sum_Covered = IsValidNumber(cell);
                                        if (!Sum_Covered)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Sum Covered colume Only contains Number's!');</script>");
                                        }
                                    }
                                    if (Colume == 21)
                                    {
                                        bool Marital_Status = isValidCher(cell);
                                        if (!Marital_Status)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Marital Status colume Only contains letter.!'" + cell.ToString() + ");</script>");
                                        }
                                    }
                                    if (Colume == 22)
                                    {
                                        bool Cell_No = IsValidNumber(cell);
                                        if (!Cell_No)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Phone Number colume Only contains Number's!'" + cell.ToString() + ");</script>");
                                        }
                                    }
                                    if (Colume == 23)
                                    {
                                        bool EmailAddress = isValidEmails(cell);
                                        if (!EmailAddress)
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>alert('Please check Email Address Colum in Excel File, its Only contains Email Addresses.!'" + cell.ToString() + ");</script>");
                                        }
                                    }
                                    dt.Rows[dt.Rows.Count - 1][Colume] = cell.Trim();
                                    sb.Append("<td id=col'" + Colume + "_" + (dt.Rows.Count - 1) + "'>" + dt.Rows[dt.Rows.Count - 1][Colume] + " </td>");
                                    Colume++;
                                }
                                sb.AppendLine("</tr>");
                            }
                        }
                    }
                }
                sb.Append("</table>");
                sb.Append("</div>");
                sb.Append("</div>");
            }

            HttpContext.Session.SetComplexData("CustomerFile", dt);

            return this.Content(sb.ToString());
        }
        public static Boolean isValidEmails(string Title)
        {
            Regex rg = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return rg.IsMatch(Title);
        }
        public static Boolean isValidCNIC(string NumRegrex)
        {
            Regex rg = new Regex(@"^\d{5}-\d{7}-\d{1}$");
            return rg.IsMatch(NumRegrex);
        }
        public static Boolean isValidDate(string DateRegex)
        {
            Regex rg = new Regex(@"([0-2][0-9]|(3)[0-1])[-|\/](((0)[0-9])|((1)[0-2]))[-|\/]\d{4}");
            return rg.IsMatch(DateRegex);
        }
        public static Boolean EffectiveDate(string DateRegex)
        {
            Regex rg = new Regex(@"([0-2][0-9]|(3)[0-1])[-|\/](((0)[0-9])|((1)[0-2]))[-|\/]\d{4}");
            return rg.IsMatch(DateRegex);
        }

        public static Boolean ENDDate(string DateRegex)
        {
            Regex rg = new Regex(@"([0-2][0-9]|(3)[0-1])[-|\/](((0)[0-9])|((1)[0-2]))[-|\/]\d{4}");
            return rg.IsMatch(DateRegex);
        }

        public static Boolean isValidCher(string CharRegex)
        {
            Regex rg = new Regex(@"^[a-zA-Z ]*$");
            return rg.IsMatch(CharRegex);
        }

        public static Boolean isValidTitles(string Title)
        {
            Regex rg = new Regex(@"/^(Mr.|Mrs.|Mr.|Dr.|Engr.)\.[A-Za-z]+$/;");
            return rg.IsMatch(Title);
        }

        public static Boolean isAlphaNumeric(string AlphaNumric)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(AlphaNumric);
        }
        public static Boolean IsValidTwoNumber(string Age)
        {
            Regex rg = new Regex(@"^[0-9]{2}$");
            return rg.IsMatch(Age);
        }
        public static Boolean IsValidSingleNumber(string Age)
        {
            Regex rg = new Regex(@"^[0-9]{1}$");
            return rg.IsMatch(Age);
        }
        public static Boolean IsValidGender(string Gender)
        {
            Regex rg = new Regex(@"^M(ale)?$|^F(emale)?$");
            return rg.IsMatch(Gender);
        }
        public static Boolean IsValidNumber(string Gender)
        {
            Regex rg = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            return rg.IsMatch(Gender);
        }
    }
}