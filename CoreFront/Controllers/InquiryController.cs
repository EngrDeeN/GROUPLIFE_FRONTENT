using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using CoreFront.Models;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Net;

namespace CoreFront.Controllers
{
    public class InquiryController : Controller
    {

        private readonly string Check_Quotation_Policy_Code = "http://" + Result_API + "/api/UnderWritting/PutUnderWrittingDocument";

        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public InquiryController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string GetIPHostAPI()
        {
            IP_Address = configuration.GetSection("Endpoint").GetSection("CORE_API_IP").Value;
            Port_No = configuration.GetSection("Endpoint").GetSection("CORE_API_PNO").Value;
            Result_API = IP_Address + ":" + Port_No;
            ViewData["GetIPHostAPI"] = Result_API;
            //HttpContext.Session.SetComplexData("GetIPHostAPI", Result_API);
            return Result_API;
        }

        StringContent SendRequest;

        public IActionResult Inquiry()
        {
            GetIPHostAPI();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Inquiry(string CODE)
        {
            Inquiry inquiry = new();
            inquiry.CODE = CODE;

            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (inquiry.CODE != null)

                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(inquiry), Encoding.UTF8, "application/json");
                        using (var response = await client1.PostAsync(Check_Quotation_Policy_Code, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["Inquiry"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successInquiry"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("Inquiry");
        }
    }
}

