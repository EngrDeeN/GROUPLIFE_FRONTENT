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
    public class Payment_ReceiptController : Controller
    {


        private readonly string Add_Receipting = "http://" + Result_API + "/api/Receipting/PostReceipting";
        private readonly string Update_Receipting = "http://" + Result_API + "/api/Receipting/PutReceipting";

        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public Payment_ReceiptController(IConfiguration _configuration)
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
        public IActionResult Payment_Receipt()
        {
            GetIPHostAPI();
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> SaveUpdatePolicyReceipting(DateTime FTPR_RCPT_VALUDATE, string ftpr_rcpt_refno1, int FTPR_RECEIPT_TYPE, int FTPR_PYMET_FSCD_DID, string FTPR_INSTR_NO, DateTime FTPR_INSTR_DATE, int FSCR_CURRENCY_CODE,
                                                                   int FSBK_BANK_ID, string FTPR_INSTR_BNK_BRCHNAME, int FTPR_ACCOUNT_TYPE, string FTPR_ACCOUNT_TITLE, string FTPR_ACCOUNT_NO,
                                                                   int FTPR_COLL_AMOUNT, int FTPR_DUE_AMOUNT, int FTPR_APPROVD_AMT, string FTPR_RCPT_POSTD_YN, string FTPR_GLVOUCHR_NO)
        {
            Receipting receipt = new();
            receipt.FTPR_RCPT_VALUDATE = FTPR_RCPT_VALUDATE;
            receipt.ftpr_rcpt_refno1 = ftpr_rcpt_refno1;
            receipt.FTPR_RECEIPT_TYPE = FTPR_RECEIPT_TYPE;
            receipt.FTPR_PYMET_FSCD_DID = FTPR_PYMET_FSCD_DID;
            receipt.FTPR_INSTR_NO = FTPR_INSTR_NO;
            receipt.FTPR_INSTR_DATE = FTPR_INSTR_DATE;
            receipt.FSCR_CURRENCY_CODE = FSCR_CURRENCY_CODE;
            receipt.FSBK_BANK_ID = FSBK_BANK_ID;
            receipt.FTPR_INSTR_BNK_BRCHNAME = FTPR_INSTR_BNK_BRCHNAME;
            receipt.FTPR_ACCOUNT_TYPE = FTPR_ACCOUNT_TYPE;
            receipt.FTPR_ACCOUNT_TITLE = FTPR_ACCOUNT_TITLE;
            receipt.FTPR_ACCOUNT_NO = FTPR_ACCOUNT_NO;
            receipt.FTPR_COLL_AMOUNT = FTPR_COLL_AMOUNT;
            receipt.FTPR_DUE_AMOUNT = FTPR_DUE_AMOUNT;
            receipt.FTPR_APPROVD_AMT = FTPR_APPROVD_AMT;
            receipt.FTPR_RCPT_POSTD_YN = FTPR_RCPT_POSTD_YN;
            receipt.FTPR_GLVOUCHR_NO = FTPR_GLVOUCHR_NO;
            receipt.FTPR_CRUSER = 1;

            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (receipt.FTPR_GLVOUCHR_NO == null)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(receipt), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_Receipting, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["Payment_Receipt"] = " " + apiResponse.Replace('"', ' ').Trim();

                            var dict2 = JArray.Parse(apiResponse);
                            foreach (JObject receiptParameter in dict2.Children<JObject>())
                            {
                                if (receiptParameter != null)
                                {
                                    var address = receiptParameter["IDs"];
                                    receipt.FTPR_GLVOUCHR_NO = receiptParameter["RCPT_NO"].ToString();
                                    TempData["RCPT_NO"] = receipt.FTPR_GLVOUCHR_NO;
                                    TempData["Payment_Receipt"] = "Receipt Successfully Generated.";
                                }
                            }
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["Payment_Receipt"] = ed.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(receipt), Encoding.UTF8, "application/json");
                        using (var response = await client1.PostAsync(Update_Receipting, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["Payment_Receipt"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["Payment_Receipt"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("Payment_Receipt");
        }
    }
}