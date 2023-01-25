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
    public class New_BusinessController : Controller
    {

        private readonly string Add_QuotCompGrp = "http://"+Result_API+"/api/QuotCompyGrpDetl/PostQuotCompyGrpDetl";
        private readonly string Update_QuotCompGrp = "http://"+Result_API+"/api/QuotCompyGrpDetl/PutQuotCompyGrpDetl";
        private readonly string Add_QuotAgtDet = " http://"+Result_API+"/api/QuotAgentDetl/PostQuotAgentDetl";
        private readonly string Update_QuotAgtDet = "http://"+Result_API+"/api/QuotAgentDetl/PutQuotAgentDetl";
        private readonly string Add_QuotProc = "http://"+Result_API+"/api/QuotaProcess/PostQuotaProcess";
        private readonly string Update_QuotProc = "http://"+Result_API+"/api/QuotaProcess/PutQuotaProcess";

        private readonly string Add_QuotaRider = "http://"+Result_API+"/api/QuotationRider/PostQuotaRider";
        private readonly string Update_QuotaRider = "http://"+Result_API+"/api/QuotationRider/PutQuotaRider";
        private readonly string Add_QuotaEvent = "http://"+Result_API+"/api/QuotationEvent/PostQuotaEvent";
        private readonly string Update_QuotaEvent = "http://"+Result_API+"/api/QuotationEvent/PutQuotaEvent";

        private readonly string Add_Quot = "http://" + Result_API + "/api/Quotation/PostQuotation";
        private readonly string Update_Quot = "http://" + Result_API + "/api/Quotation/PutQuotation";

        private readonly string Add_QuotProcFCL = "http://"+Result_API+"/api/QuotaProcess/PostQuotaFLCProcess";
        private readonly string Update_QuotProcFCL = "http://"+Result_API+"/api/QuotaProcess/PutQuotaFLCProcess";

        private readonly string Add_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PostQuotaProcessUR";   
        private readonly string Update_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PutQuotaProcessUR";

        private readonly string GeneratePolicyNo = "http://"+Result_API+"/api/QuotaProcess/PostQuotaProcessPolicy";
        private readonly string GeneratePolicyIssuce = "http://"+ Result_API+"/api/QuotaProcess/PolicyGenrtWithQuotationId";

        private readonly string CreateDuplicPolicy = "http://"+Result_API+"/api/QuotaProcess/CreateDuplicationQuoation";
        private readonly string Add_CUSTBLUK = "http://" + Result_API + "/api/CustomerFile/UploadCustomerFile";
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public New_BusinessController(IConfiguration _configuration)
        {
            configuration = _configuration;
            //GetIPHostAPI();
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

        CustomerMemberUpload CustMemUpld = new CustomerMemberUpload();
        DataTable GetCustomerFile = new();
        StringContent SendRequest;
        public IActionResult Duplic_Quotation()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult PolicyIssuance()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult Quotation()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult QuotationProcess()
        {
            GetIPHostAPI();
            return View();
        }

                                                     
        [HttpPost]
        public void SaveQuotaRider(int FGQH_QUOTATHDR_ID, int _FGQG_COMPGRP_ID, int FSPM_PRODUCT_ID, int FGQE_QUOTEVNT_ID, DateTime FGQR_RIDERST_DATE, DateTime FGQR_RIDEREN_DATE,
                                   int FGQR_PFREQ_FSCD_DID, string FGQR_PAYBLE_FLAG, string FGQR_LOADING_TYPE, int FGQR_LOADING_VALUE, int FGQR_RIDER_CONTRIB,
                                   int FGQR_NET_CONTRIB, string FGQR_STATUS, int FGQR_QUOTRIDR_ID)
        {
            _ = SaveUpdateQuotaRider(FGQH_QUOTATHDR_ID, _FGQG_COMPGRP_ID, FSPM_PRODUCT_ID, FGQE_QUOTEVNT_ID, FGQR_RIDERST_DATE, FGQR_RIDEREN_DATE, FGQR_PFREQ_FSCD_DID,
                                      FGQR_PAYBLE_FLAG, FGQR_LOADING_TYPE, FGQR_LOADING_VALUE, FGQR_RIDER_CONTRIB, FGQR_NET_CONTRIB, FGQR_STATUS, FGQR_QUOTRIDR_ID);

        }


        [HttpPost]
        public async Task<ActionResult> SaveUpdateQuotaRider(int FGQH_QUOTATHDR_ID, int _FGQG_COMPGRP_ID, int FSPM_PRODUCT_ID, int FGQE_QUOTEVNT_ID, DateTime FGQR_RIDERST_DATE, DateTime FGQR_RIDEREN_DATE,
                                                             int FGQR_PFREQ_FSCD_DID, string FGQR_PAYBLE_FLAG, string FGQR_LOADING_TYPE, int FGQR_LOADING_VALUE, int FGQR_RIDER_CONTRIB,
                                                             int FGQR_NET_CONTRIB, string FGQR_STATUS, int FGQR_QUOTRIDR_ID)
        {
            Quotation_Rider Quot_Rider = new();
            Quot_Rider.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
            Quot_Rider._FGQG_COMPGRP_ID = _FGQG_COMPGRP_ID;
            Quot_Rider.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID;
            Quot_Rider.FGQE_QUOTEVNT_ID = FGQE_QUOTEVNT_ID;
            Quot_Rider.FGQR_RIDERST_DATE = FGQR_RIDERST_DATE;
            Quot_Rider.FGQR_RIDEREN_DATE = FGQR_RIDEREN_DATE;
            Quot_Rider.FGQR_PFREQ_FSCD_DID = FGQR_PFREQ_FSCD_DID;
            Quot_Rider.FGQR_PAYBLE_FLAG = FGQR_PAYBLE_FLAG;
            Quot_Rider.FGQR_LOADING_TYPE = FGQR_LOADING_TYPE;
            Quot_Rider.FGQR_LOADING_VALUE = FGQR_LOADING_VALUE;
            Quot_Rider.FGQR_RIDER_CONTRIB = FGQR_RIDER_CONTRIB;
            Quot_Rider.FGQR_NET_CONTRIB = FGQR_NET_CONTRIB;
            Quot_Rider.FGQR_STATUS = FGQR_STATUS;
            Quot_Rider.FGQR_QUOTRIDR_ID = FGQR_QUOTRIDR_ID;
            Quot_Rider.FGQR_CRUSER = 1;

            using (var client1 = new HttpClient())
            {
                SendRequest = null;
                if (Quot_Rider.FGQR_QUOTRIDR_ID == 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(Quot_Rider), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_QuotaRider, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successQuotaRider"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successQuotaRider"] = ed.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(Quot_Rider), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_QuotaRider, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successQuotaRider"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successQuotaRider"] = ed.ToString();

                    }
                }
            }
            return RedirectToAction("Quotation");
        }

        [HttpPost]
        public void SaveQuotaEvent(int FGQH_QUOTATHDR_ID, int _FGQG_COMPGRP_ID, int FSCE_COVREVENT_ID, DateTime FGQE_EVENTST_DATE, DateTime FGQE_EVENTEN_DATE, int FGQE_PFREQ_FSCD_DID,
                                                             string FGQE_PAYBLE_FLAG, int FGQE_EVNT_CONTRIB, int FGQE_EVNT_LOADING, int FGQE_NET_CONTRIB, string FGQE_STATUS, int FGQE_QUOTEVNT_ID)
        {
            _ = SaveUpdateQuotaEvent(FGQH_QUOTATHDR_ID, _FGQG_COMPGRP_ID, FSCE_COVREVENT_ID, FGQE_EVENTST_DATE, FGQE_EVENTEN_DATE, FGQE_PFREQ_FSCD_DID, FGQE_PAYBLE_FLAG, FGQE_EVNT_CONTRIB,
               FGQE_EVNT_LOADING, FGQE_NET_CONTRIB, FGQE_STATUS, FGQE_QUOTEVNT_ID);

        }

        [HttpPost]
        public async Task<ActionResult> SaveUpdateQuotaEvent(int FGQH_QUOTATHDR_ID, int _FGQG_COMPGRP_ID, int FSCE_COVREVENT_ID, DateTime FGQE_EVENTST_DATE, DateTime FGQE_EVENTEN_DATE, int FGQE_PFREQ_FSCD_DID,
                                                             string FGQE_PAYBLE_FLAG, int FGQE_EVNT_CONTRIB, int FGQE_EVNT_LOADING, int FGQE_NET_CONTRIB, string FGQE_STATUS, int FGQE_QUOTEVNT_ID)
        {
            Quotation_Event Quot_Event = new();
            Quot_Event.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
            Quot_Event._FGQG_COMPGRP_ID = _FGQG_COMPGRP_ID;
            Quot_Event.FSCE_COVREVENT_ID = FSCE_COVREVENT_ID;
            Quot_Event.FGQE_EVENTST_DATE = FGQE_EVENTST_DATE;
            Quot_Event.FGQE_EVENTEN_DATE = FGQE_EVENTEN_DATE;
            Quot_Event.FGQE_PFREQ_FSCD_DID = FGQE_PFREQ_FSCD_DID;
            Quot_Event.FGQE_PAYBLE_FLAG = FGQE_PAYBLE_FLAG;
            Quot_Event.FGQE_EVNT_CONTRIB = FGQE_EVNT_CONTRIB;
            Quot_Event.FGQE_EVNT_LOADING = FGQE_EVNT_LOADING;
            Quot_Event.FGQE_NET_CONTRIB = FGQE_NET_CONTRIB;
            Quot_Event.FGQE_STATUS = FGQE_STATUS;
            Quot_Event.FGQE_QUOTEVNT_ID = FGQE_QUOTEVNT_ID;
            Quot_Event.FGQE_CRUSER = 1;

            using (var client1 = new HttpClient())
            {

                SendRequest = null;
                if (Quot_Event.FGQE_QUOTEVNT_ID == 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(Quot_Event), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_QuotaEvent, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successPolicMangt"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPolicMangt"] = ed.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(Quot_Event), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_QuotaEvent, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successPolicMangt"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPolicMangt"] = ed.ToString();

                    }
                }
            }
            return RedirectToAction("Quotation");
        }

        [HttpPost]
        public async Task<ActionResult> SaveUpdateQuotaManagt(int FGQH_QUOTATHDR_ID)
        {
            PolicyIssuance PolIssu = new();
            PolIssu.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
            using (var client = new HttpClient())
            {
                SendRequest = null;

                if (PolIssu.FGQH_QUOTATHDR_ID != 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(PolIssu), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(CreateDuplicPolicy, SendRequest)){

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            
                            var dict2 = JArray.Parse(apiResponse);
                            foreach (JObject receiptParameter in dict2.Children<JObject>())
                            {
                                if (receiptParameter != null)
                                {
                                    var address = receiptParameter["IDs"];
                                    PolIssu.NEWPOLNO = receiptParameter["FGQH_QUOTCODE_NEW"].ToString();
                                    TempData["FGQH_QUOTCODE_NEW"] = PolIssu.NEWPOLNO;
                                    TempData["successPolicMangt"] = "Receipt Successfully Generated.";
                                }
                            }
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPolicMangt"] = ed.ToString();

                    }
                }
            }
            return RedirectToAction("Duplic_Quotation");
        }

        [HttpPost]
        public async Task<ActionResult> SaveUpdatePolicyIssue(int FGQH_QUOTATHDR_ID)
        {
            PolicyIssuance PolIssu = new();
            PolIssu.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (PolIssu.FGQH_QUOTATHDR_ID != 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(PolIssu), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(GeneratePolicyIssuce, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successPoliceIssuance"] = " " + apiResponse.Replace('"', ' ').Trim();

                            var dict2 = JArray.Parse(apiResponse);

                            foreach (JObject PolicyParameter in dict2.Children<JObject>())
                            {
                                if (PolicyParameter != null)
                                {
                                    var address = PolicyParameter["IDs"];
                                    PolIssu.NEWPOLNO = PolicyParameter["NEWPOLNO"].ToString(); 
                                    PolIssu.COMMANT =  PolicyParameter["COMMAMT"].ToString();
                                    TempData["NEWPOLNO"] = PolIssu.NEWPOLNO;
                                    TempData["COMMANT"] = PolIssu.COMMANT;
                                    TempData["successPoliceIssuance"] = "Quotation Process Successfully Generated.";
                                }
                            }
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPoliceIssuance"] = ed.ToString();  
                    }
                }
            }
            return RedirectToAction("PolicyIssuance");
        }


        [HttpPost]
        public async Task<ActionResult> SaveOrUpdateQuotaProcess( int FPQP_QUOTATPLAN_ID, int FGQH_QUOTATHDR_ID, string FGQH_QUOTATHDR_CODE, string FGQH_QUOTATION_CONFIRM, int FPQP_WAKALA_PERC, int FPQP_GROSSPREMIUM, int FPQP_NETPREMIUM, int FPQP_SUMASSURED, int FPQP_SERVICETAX,
                                                                int FPQP_DISCOUNT_AMT, int FPQP_OTHER_AMT, string FPQP_OTHER_DESCR, string FPQP_STATUS, string FGQH_WITHRCPT_YN,
                                                                int FPQF_QUOTFCL_ID, int FSPF_PRODFCL_ID,int FPQF_SYS_FCL_AMT, int FPQF_USER_FCL_AMT, bool CheckUserFCLAMT,
                                                                int FPQR_EVENT_ID, int FSPR_PRODRELTN_ID, float FPQR_SYSTMUNIT_RATE, float FPQR_USERUNIT_RATE, float FPQR_USERNET_RATE, float fpqr_rirate, string FPQR_SYSUSR_RATE_FLAG)
        {

            QuotationProcess QuotProc = new()
            {
                FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID,
                FGQH_QUOTATION_CONFIRM = FGQH_QUOTATION_CONFIRM,
                FGQH_QUOTATHDR_CODE = FGQH_QUOTATHDR_CODE,
                FPQP_WAKALA_PERC = FPQP_WAKALA_PERC,
                FPQP_GROSSPREMIUM = FPQP_GROSSPREMIUM,
                FPQP_NETPREMIUM = FPQP_NETPREMIUM,
                FPQP_SUMASSURED = FPQP_SUMASSURED,
                FPQP_SERVICETAX = FPQP_SERVICETAX,
                FPQP_DISCOUNT_AMT = FPQP_DISCOUNT_AMT,
                FPQP_OTHER_AMT = FPQP_OTHER_AMT,
                FPQP_OTHER_DESCR = FPQP_OTHER_DESCR,
                FGQH_WITHRCPT_YN = FGQH_WITHRCPT_YN,
                FPQP_QUOTATPLAN_ID = FPQP_QUOTATPLAN_ID,
                FPQP_STATUS = "Y",
                FPQP_CRUSER = 1,
            };
            int FGQH_QUOTATHDR_ID_ = FGQH_QUOTATHDR_ID;

            QuotationProcessFCL QuotaProFCL = new QuotationProcessFCL();
            QuotationProcessUnitRate QProcUnitRate = new QuotationProcessUnitRate();

            SendRequest = null;

            using (var client1 = new HttpClient())
            {

                if (QuotProc.FPQP_QUOTATPLAN_ID == 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(QuotProc), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_QuotProc, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                        }

                        
                            QuotaProFCL.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                            QuotaProFCL.FSPF_PRODFCL_ID = FSPF_PRODFCL_ID;
                            QuotaProFCL.FPQF_QUOTFCL_ID = FPQF_QUOTFCL_ID;

                            if (CheckUserFCLAMT == true)    // exception
                            {
                                QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "U";
                                QuotaProFCL.FPQF_USER_FCL_AMT = FPQF_USER_FCL_AMT;
                                QuotaProFCL.FPQF_SYS_FCL_AMT = FPQF_SYS_FCL_AMT;
                        }
                            else
                            {
                                QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "S";
                            }

                            QuotaProFCL.FPQF_STATUS = "Y";
                            QuotaProFCL.FPQF_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(QuotaProFCL), Encoding.UTF8, "application/json");

                            using (var response = await client1.PostAsync(Add_QuotProcFCL, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                //TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                            }




                        ///*Quotation Proces for FCL Info Insert*/
                        //for (int iAd = 0; iAd < FPQF_USER_FCL_AMT.Length; iAd++)
                        //{

                        //    QuotaProFCL.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        //    QuotaProFCL.FSPF_PRODFCL_ID = FSPF_PRODFCL_ID[iAd];
                        //    QuotaProFCL.FPQF_QUOTFCL_ID = FPQF_QUOTFCL_ID[iAd];

                        //    if (CheckUserFCLAMT[iAd] == true)    // exception
                        //    {
                        //        QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "U";
                        //        QuotaProFCL.FPQF_USER_FCL_AMT = FPQF_USER_FCL_AMT[iAd];
                        //    }
                        //    else
                        //    {
                        //        QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "S";
                        //    }

                        //    QuotaProFCL.FPQF_STATUS = "Y";
                        //    QuotaProFCL.FPQF_CRUSER = 1;

                        //    SendRequest = null;
                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(QuotaProFCL), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Add_QuotProcFCL, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        //TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}

                        /*Quotation Proces for Unite Rate Info Insert*/
                        //for (int IUR = 0; IUR < FPQR_USERUNIT_RATE.Length; IUR++)
                        //{
                        //    QProcUnitRate.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        //   // QProcUnitRate.FPQR_EVENT_ID = FPQR_EVENT_ID[IUR];
                        //    //QProcUnitRate.FSPR_PRODRELTN_ID = FSPR_PRODRELTN_ID[IUR];
                        //    QProcUnitRate.FPQR_SYSTMUNIT_RATE = FPQR_SYSTMUNIT_RATE[IUR];
                        //    QProcUnitRate.FPQR_USERUNIT_RATE = FPQR_USERUNIT_RATE[IUR];
                        //    QProcUnitRate.FPQR_USERNET_RATE = FPQR_USERNET_RATE[IUR];
                        //    QProcUnitRate.fpqr_rirate = fpqr_rirate[IUR];
                        //    QProcUnitRate.FPQR_SYSUSR_RATE_FLAG = FPQR_SYSUSR_RATE_FLAG[IUR];
                        //    QProcUnitRate.FPQR_BASPLN_FLAG = "Y";
                        //    QProcUnitRate.FPQR_CRUSER = 1;


                        //    SendRequest = null;
                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(QProcUnitRate), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Add_QuotProcUnitRate, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();

                        //        var dict2 = JArray.Parse(apiResponse);

                        //        foreach (JObject QuoPro in dict2.Children<JObject>())
                        //        {
                        //            if (QuoPro != null)
                        //            {
                        //                var address = QuoPro["IDs"];
                        //                QProcUnitRate.GROSS_PREMIUM = QuoPro["GROSS_PREMIUM"].ToString();
                        //                QProcUnitRate.NET_PREMIUM = QuoPro["NET_PREMIUM"].ToString();
                        //                QProcUnitRate.SUMASSURED = QuoPro["SUMASSURED"].ToString();

                        //                TempData["GROSS_PREMIUM"] = QProcUnitRate.GROSS_PREMIUM;
                        //                TempData["NET_PREMIUM"] = QProcUnitRate.NET_PREMIUM;
                        //                TempData["SUMASSURED"] = QProcUnitRate.SUMASSURED;
                        //            }
                        //        }
                        //        TempData["successQuotaProcess"] = "- Quotation Process Successfully Run.";
                        //    }
                        //}
                        QProcUnitRate.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        // QProcUnitRate.FPQR_EVENT_ID = FPQR_EVENT_ID[IUR];
                        //QProcUnitRate.FSPR_PRODRELTN_ID = FSPR_PRODRELTN_ID[IUR];
                        QProcUnitRate.FPQR_SYSTMUNIT_RATE = FPQR_SYSTMUNIT_RATE;
                        QProcUnitRate.FPQR_USERUNIT_RATE = FPQR_USERUNIT_RATE;
                        QProcUnitRate.FPQR_USERNET_RATE = FPQR_USERNET_RATE;
                        QProcUnitRate.fpqr_rirate = fpqr_rirate;
                        QProcUnitRate.FPQR_SYSUSR_RATE_FLAG = FPQR_SYSUSR_RATE_FLAG;
                        QProcUnitRate.FPQR_BASPLN_FLAG = "Y";
                        QProcUnitRate.FPQR_CRUSER = 1;


                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(QProcUnitRate), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_QuotProcUnitRate, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            var dict2 = JArray.Parse(apiResponse);

                            foreach (JObject QuoPro in dict2.Children<JObject>())
                            {
                                if (QuoPro != null)
                                {
                                    var address = QuoPro["IDs"];
                                    QProcUnitRate.GROSS_PREMIUM = QuoPro["GROSS_PREMIUM"].ToString();
                                    QProcUnitRate.NET_PREMIUM = QuoPro["NET_PREMIUM"].ToString();
                                    QProcUnitRate.SUMASSURED = QuoPro["SUMASSURED"].ToString();

                                    TempData["GROSS_PREMIUM"] = QProcUnitRate.GROSS_PREMIUM;
                                    TempData["NET_PREMIUM"] = QProcUnitRate.NET_PREMIUM;
                                    TempData["SUMASSURED"] = QProcUnitRate.SUMASSURED;
                                }
                            }
                            TempData["successQuotaProcess"] = "- Quotation Process Successfully Run.";
                        }
                        PolicyGeneration PolGen = new();
                        PolGen.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(PolGen), Encoding.UTF8, "application/json");

                    }
                    catch (Exception ex)
                    {
                        TempData["successQuotaProcess"] = ex.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(QuotProc), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_QuotProc, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                        }


                        /*Quotation Proces for FCL Info Insert*/
                        //for (int iAd = 0; iAd < FPQF_USER_FCL_AMT.Length; iAd++)
                        //{

                        //    QuotaProFCL.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        //    QuotaProFCL.FSPF_PRODFCL_ID = FSPF_PRODFCL_ID[iAd];
                        //    QuotaProFCL.FPQF_QUOTFCL_ID = FPQF_QUOTFCL_ID[iAd];

                        //    if (CheckUserFCLAMT[iAd])
                        //    {
                        //        QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "U";
                        //        QuotaProFCL.FPQF_USER_FCL_AMT = FPQF_USER_FCL_AMT[iAd];
                        //    }
                        //    else
                        //    {
                        //        QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "S";
                        //    }

                        //    QuotaProFCL.FPQF_STATUS = "Y";
                        //    QuotaProFCL.FPQF_CRUSER = 1;

                        //    SendRequest = null;
                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(QuotaProFCL), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Update_QuotProcFCL, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        //TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}
                        QuotaProFCL.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        QuotaProFCL.FSPF_PRODFCL_ID = FSPF_PRODFCL_ID;
                        QuotaProFCL.FPQF_QUOTFCL_ID = FPQF_QUOTFCL_ID;

                        if (CheckUserFCLAMT == true)
                        {
                            QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "U";
                            QuotaProFCL.FPQF_USER_FCL_AMT = FPQF_USER_FCL_AMT;
                            QuotaProFCL.FPQF_SYS_FCL_AMT =  FPQF_SYS_FCL_AMT;
    }
                        else
                        {
                            QuotaProFCL.FPQF_SYSUSR_FCL_FLAG = "S";
                        }

                        QuotaProFCL.FPQF_STATUS = "Y";
                        QuotaProFCL.FPQF_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(QuotaProFCL), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_QuotProcFCL, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        /*Quotation Proces for Unite Rate Info Insert*/
                        //for (int IUR = 0; IUR < FPQR_USERUNIT_RATE.Length; IUR++)
                        //{
                        //    QProcUnitRate.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        //    //QProcUnitRate.FPQR_EVENT_ID = FPQR_EVENT_ID[IUR];
                        //    //QProcUnitRate.FSPR_PRODRELTN_ID = FSPR_PRODRELTN_ID[IUR];
                        //    QProcUnitRate.FPQR_SYSTMUNIT_RATE = FPQR_SYSTMUNIT_RATE[IUR];
                        //    QProcUnitRate.FPQR_USERUNIT_RATE = FPQR_USERUNIT_RATE[IUR];
                        //    QProcUnitRate.FPQR_USERNET_RATE = FPQR_USERNET_RATE[IUR];
                        //    QProcUnitRate.fpqr_rirate = fpqr_rirate[IUR];
                        //    QProcUnitRate.FPQR_BASPLN_FLAG = "Y";
                        //    QProcUnitRate.FPQR_CRUSER = 1;

                        //    SendRequest = null;
                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(QProcUnitRate), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Update_QuotProcUnitRate, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        TempData["successQuotaProcess"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}

                        QProcUnitRate.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;
                        //QProcUnitRate.FPQR_EVENT_ID = FPQR_EVENT_ID[IUR];
                        //QProcUnitRate.FSPR_PRODRELTN_ID = FSPR_PRODRELTN_ID[IUR];
                        QProcUnitRate.FPQR_SYSTMUNIT_RATE = FPQR_SYSTMUNIT_RATE;
                        QProcUnitRate.FPQR_USERUNIT_RATE = FPQR_USERUNIT_RATE;
                        QProcUnitRate.FPQR_USERNET_RATE = FPQR_USERNET_RATE;
                        QProcUnitRate.fpqr_rirate = fpqr_rirate;
                        QProcUnitRate.FPQR_BASPLN_FLAG = "Y";
                        QProcUnitRate.FPQR_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(QProcUnitRate), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_QuotProcUnitRate, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successQuotaProcess"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                        PolicyGeneration PolGen = new();
                        PolGen.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID_;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(PolGen), Encoding.UTF8, "application/json");

                        //using (var response = await client1.PostAsync(GeneratePolicyNo, SendRequest))
                        //{
                        //    string apiResponse = await response.Content.ReadAsStringAsync();
                        //    TempData["successQuotaProcess"] = "- " + apiResponse.Replace('"', ' ').Trim();
                        //    // TempData["successQuotaProcess"] = "Quotation Process Successfully Run.";
                        //    //var dict2 = JArray.Parse(apiResponse);

                        //    //foreach (JObject PolicyParameter in dict2.Children<JObject>())
                        //    //{
                        //    //    if (PolicyParameter != null)
                        //    //    {
                        //    //        var address = PolicyParameter["IDs"];
                        //    //        PolGen.GROSS_PREMIUM = int.Parse(PolicyParameter["GROSS_PREMIUM"].ToString());
                        //    //        PolGen.NET_PREMIUM = int.Parse(PolicyParameter["NET_PREMIUM"].ToString());
                        //    //        PolGen.SUMASSURED = int.Parse(PolicyParameter["SUMASSURED"].ToString());
                        //    //        PolGen.NEWPOLNO = PolicyParameter["NEWPOLNO"].ToString();
                        //    //        TempData["GROSS_PREMIUM"] = PolGen.GROSS_PREMIUM;
                        //    //        TempData["NET_PREMIUM"] = PolGen.NET_PREMIUM;
                        //    //        TempData["SUMASSURED"] = PolGen.SUMASSURED;
                        //    //     // TempData["NEWPOLNO"] = PolGen.NEWPOLNO;
                        //    //    }
                        //    //}
                        //}

                    }
                    catch (Exception ex)
                    {
                        TempData["successQuotaProcess"] = ex.ToString();
                    }
                }
            }
            return RedirectToAction("QuotationProcess");
        }

       
        public async Task<ActionResult> SaveUpdateQuotation(int FGQH_QUOTATHDR_ID, string FGQH_QUOTATHDR_CODE, int FGQH_PFREQ_FSCD_DID, DateTime FGQH_QUOTATION_DATE,
         DateTime FGQH_QUOTATION_REQDATE, DateTime FGQH_QUOTATION_EXPDATE, string FGQH_QUOTATION_CONFIRM, int FSPM_PRODUCT_ID, int FSLO_LOCATION_ID,
         int FSLO_LOCATION_ID2, string FGQH_QUOTATION_INTRONAME, int FGQH_QUOTATION_TOTALEMP, int FGQH_QUOTATION_PEREMP, string FGQH_QUOTATION_CONTNAME,
         string FGQH_QUOTATION_PERSNAME, string FGQH_QUOTATION_SVCTAX_YN, /*int FGQH_QUOTATION_SVCTAX_PERC,*/ int FSCR_CURRENCY_CODE, int FGQH_PYMET_FSCD_DID,
         int FGQH_QUOTATCOMP_TERM, DateTime FGQH_QUOTATCOMP_POLSTDATE, DateTime FGQH_QUOTATCOMP_POLENDATE, DateTime FGQH_QUOTATCOMP_AGECALCDT, string FGQH_QUOTATCOMP_FCLTKOVR_YN,
         DateTime FGQH_QUOTATCOMP_FCLTKOVR_DT, int FSLO_LOCATION_ID3, int FSLO_LOCATION_ID4, string FGQH_QUOTATCOMP_POLBKDATD_YN, DateTime FGQH_QUOTATCOMP_POLBAKDATE,
         string FGQH_REASON_BKDATE, string FGQH_QUOTATCOMP_HEADCOUNT_YN, string FGQH_QUOTATCOMP_HDCNT_CRTRIA, string FGQH_STATUS, int FGQH_STATUS_USER,
         DateTime FGQH_STATUS_DATE, DateTime FGQH_FLXFLD_DATE1, DateTime FGQH_FLXFLD_DATE2, string FGQH_FLXFLD_VCHAR1, string FGQH_FLXFLD_VCHAR2, int FGQH_FLXFLD_NUMBER1,
         int FGQH_FLXFLD_NUMBER2, int FGQH_CRUSER, DateTime FGQH_CRDATE, int FGQH_CHKUSER, DateTime FGQH_CHKDATE, int FGQH_AUTHUSER, DateTime FGQH_AUTHDATE, int FGQH_CNCLUSER,
         DateTime FGQH_CNCLDATE, string FGQH_AUDIT_COMMENTS, string FGQH_USER_IPADDR, float FGQH_WAKALA_PERC, int CompanyRow, int AgentRow, int[] FGQA_COMPAGNT_ID,
        int[] FGQG_COMPGRP_ID, int[] FGQA_WAKALA_ONPREM, int[] FGQG_MIN_SUMASSURD, int[] FGQG_MAX_SUMASSURD, int[] FGQG_PER_FREQNCY,
        int[] FGQH_QTGRC_FSCD_DID, int[] FGQG_PREMIUM, int[] FGQG_SUMASSRD_CRITRIA, int[] FGQG_NOOFSALARY_AMT, int[] FGQG_FIXED_AMOUNT, int[] FGQG_HEADCONT_TOTSALARY,
        string[] FGQG_STATUS, int[] FSAG_AGENT_CODE, int[] FGQA_COMMISSION_PERCENT, int[] FGQA_CHNLS_FSCD_DID, string[] FGQA_STATUS)
        {

            QuotationHDR quotation = new();
            QuotCompyGrpDetl quoCompDetl = new();
            QuotAgentDetl quotAgentDetl = new();

            quotation.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
            quotation.FGQH_QUOTATHDR_CODE = FGQH_QUOTATHDR_CODE;
            quotation.FGQH_PFREQ_FSCD_DID = FGQH_PFREQ_FSCD_DID;
            quotation.FGQH_QUOTATION_DATE = FGQH_QUOTATION_DATE;
            quotation.FGQH_QUOTATION_REQDATE = FGQH_QUOTATION_REQDATE;
            quotation.FGQH_QUOTATION_EXPDATE = FGQH_QUOTATION_EXPDATE;
            quotation.FGQH_QUOTATION_CONFIRM = FGQH_QUOTATION_CONFIRM;
            quotation.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID;
            quotation.FSLO_LOCATION_ID = FSLO_LOCATION_ID;
            quotation.FSLO_LOCATION_ID2 = FSLO_LOCATION_ID2;
            quotation.FGQH_QUOTATION_INTRONAME = FGQH_QUOTATION_INTRONAME;
            quotation.FGQH_QUOTATION_TOTALEMP = FGQH_QUOTATION_TOTALEMP;
            quotation.FGQH_QUOTATION_PEREMP = FGQH_QUOTATION_PEREMP;
            quotation.FGQH_QUOTATION_CONTNAME = FGQH_QUOTATION_CONTNAME;
            quotation.FGQH_QUOTATION_PERSNAME = FGQH_QUOTATION_PERSNAME;
            quotation.FGQH_QUOTATION_SVCTAX_YN = FGQH_QUOTATION_SVCTAX_YN;
            quotation.FGQH_WAKALA_PERC = FGQH_WAKALA_PERC;
            quotation.FSCR_CURRENCY_CODE = FSCR_CURRENCY_CODE;
            quotation.FGQH_PYMET_FSCD_DID = FGQH_PYMET_FSCD_DID;
            quotation.FGQH_QUOTATCOMP_TERM = FGQH_QUOTATCOMP_TERM;
            quotation.FGQH_QUOTATCOMP_POLSTDATE = FGQH_QUOTATCOMP_POLSTDATE;
            quotation.FGQH_QUOTATCOMP_POLENDATE = FGQH_QUOTATCOMP_POLENDATE;
            quotation.FGQH_QUOTATCOMP_AGECALCDT = FGQH_QUOTATCOMP_AGECALCDT;
            quotation.FGQH_QUOTATCOMP_FCLTKOVR_YN = FGQH_QUOTATCOMP_FCLTKOVR_YN;
            quotation.FGQH_QUOTATCOMP_FCLTKOVR_DT = FGQH_QUOTATCOMP_FCLTKOVR_DT;
            quotation.FSLO_LOCATION_ID3 = FSLO_LOCATION_ID3;
            quotation.FSLO_LOCATION_ID4 = FSLO_LOCATION_ID4;
            quotation.FGQH_QUOTATCOMP_POLBKDATD_YN = FGQH_QUOTATCOMP_POLBKDATD_YN;
            quotation.FGQH_QUOTATCOMP_POLBAKDATE = FGQH_QUOTATCOMP_POLBAKDATE;
            quotation.FGQH_REASON_BKDATE = FGQH_REASON_BKDATE;
            quotation.FGQH_QUOTATCOMP_HEADCOUNT_YN = FGQH_QUOTATCOMP_HEADCOUNT_YN;
            quotation.FGQH_QUOTATCOMP_HDCNT_CRTRIA = FGQH_QUOTATCOMP_HDCNT_CRTRIA;
            quotation.FGQH_STATUS = FGQH_STATUS;
            quotation.FGQH_STATUS_USER = FGQH_STATUS_USER;
            quotation.FGQH_CRUSER = FGQH_CRUSER;
            quotation.FGQH_CRDATE = FGQH_CRDATE;

            string apiResponse = "";

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(quotation), Encoding.UTF8, "application/json");

                if (quotation.FGQH_QUOTATHDR_ID == 0)
                {
                    try
                    {
                        using (var response = await client.PostAsync(Add_Quot, content))
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["Quotation"] = "Quotation Saved Successfully.";// + apiResponse.Replace('"', ' ').Trim();
                        }
                        var dict2 = JArray.Parse(apiResponse);

                        foreach (JObject CompGrpDel in dict2.Children<JObject>())
                        {

                            if (CompGrpDel != null)
                            {
                                var address = CompGrpDel["IDs"];
                                quotation.FGQH_QUOTATHDR_ID = int.Parse(CompGrpDel["NEW_GEN_QUOT_ID"].ToString());
                                quotation.NEW_GEN_QUOT_CODE = CompGrpDel["NEW_GEN_QUOT_CODE"].ToString();
                                TempData["FGQH_QUOTATHDR_ID"] = quotation.NEW_GEN_QUOT_CODE;
                            }
                        }
                        /*Quotation Company Group Details Info Insert*/
                        for (int i = 0; i < CompanyRow; i++)
                        {
                            quoCompDetl.FGQG_COMPGRP_ID = FGQG_COMPGRP_ID[i];
                            quoCompDetl.FGQH_QUOTATHDR_ID = quotation.FGQH_QUOTATHDR_ID;
                            quoCompDetl.FGQH_QTGRC_FSCD_DID = FGQH_QTGRC_FSCD_DID[i];
                            quoCompDetl.FGQG_MIN_SUMASSURD = FGQG_MIN_SUMASSURD[i];
                            quoCompDetl.FGQG_MAX_SUMASSURD = FGQG_MAX_SUMASSURD[i];
                            quoCompDetl.FGQG_PER_FREQNCY = FGQG_PER_FREQNCY[i];
                            quoCompDetl.FGQG_SUMASSRD_CRITRIA = FGQG_SUMASSRD_CRITRIA[i];
                            quoCompDetl.FGQG_PREMIUM = FGQG_PREMIUM[i];


                            if (FGQG_SUMASSRD_CRITRIA[i] == 3)
                            {
                                quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                                quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                                quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];
                            }
                            else if (FGQG_SUMASSRD_CRITRIA[i] == 1)
                            {
                                quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                                quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];

                            }
                            else if (FGQG_SUMASSRD_CRITRIA[i] == 2)
                            {
                                quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                            }

                            quoCompDetl.FGQG_STATUS = FGQG_STATUS[i];

                            content = null;
                            content = new StringContent(JsonConvert.SerializeObject(quoCompDetl), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_QuotCompGrp, content))
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["Quotation"] = "Quotation Saved Successfully.";// + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                        /*Quotation Agent Details Info Insert*/
                        for (int j = 0; j < AgentRow; j++)
                        {
                            quotAgentDetl.FGQA_COMPAGNT_ID = FGQA_COMPAGNT_ID[j];
                            quotAgentDetl.FGQH_QUOTATHDR_ID = quotation.FGQH_QUOTATHDR_ID;
                            quotAgentDetl.FSAG_AGENT_CODE = FSAG_AGENT_CODE[j];
                            quotAgentDetl.FGQA_COMMISSION_PERCENT = FGQA_COMMISSION_PERCENT[j];
                            quotAgentDetl.FGQA_WAKALA_ONPREM = FGQA_WAKALA_ONPREM[j];

                            content = null;
                            content = new StringContent(JsonConvert.SerializeObject(quotAgentDetl), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_QuotAgtDet, content))
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["Quotation"] = " " + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["Quotation"] = ex.ToString();
                    }

                    HttpContext.Session.SetString("FSLO_LOCATION_ID", quotation.FSLO_LOCATION_ID.ToString());
                    HttpContext.Session.SetString("FGQH_QUOTATHDR_ID", quotation.FGQH_QUOTATHDR_ID.ToString());
                }
                else if (quotation.FGQH_QUOTATHDR_ID != 0)
                {
                   StringContent content1 = new StringContent(JsonConvert.SerializeObject(quotation), Encoding.UTF8, "application/json");
                    try
                    {
                        using (var response = await client.PostAsync(Update_Quot, content1))
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["Quotation"] = " Quotation Saved Successfully. ";// + apiResponse.Replace('"', ' ').Trim();
                           
                        }
                        for (int i = 0; i < CompanyRow; i++)
                        {
                            quoCompDetl.FGQG_COMPGRP_ID = FGQG_COMPGRP_ID[i];
                            quoCompDetl.FGQH_QUOTATHDR_ID = quotation.FGQH_QUOTATHDR_ID;
                            quoCompDetl.FGQH_QTGRC_FSCD_DID = FGQH_QTGRC_FSCD_DID[i];
                            quoCompDetl.FGQG_SUMASSRD_CRITRIA = FGQG_SUMASSRD_CRITRIA[i];
                            quoCompDetl.FGQG_MIN_SUMASSURD = FGQG_MIN_SUMASSURD[i];
                            quoCompDetl.FGQG_MAX_SUMASSURD = FGQG_MAX_SUMASSURD[i];
                            quoCompDetl.FGQG_PER_FREQNCY = FGQG_PER_FREQNCY[i];
                            quoCompDetl.FGQG_PREMIUM = FGQG_PREMIUM[i];


                            if (FGQG_SUMASSRD_CRITRIA[i] == 3)
                            {
                                quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                                quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                                quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];
                            }
                            else if (FGQG_SUMASSRD_CRITRIA[i] == 1)
                            {
                                quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                                quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];

                            }
                            else if (FGQG_SUMASSRD_CRITRIA[i] == 2)
                            {
                                quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                            }


                            //if (FGQG_PREMIUM[i] != 0){
                            //         quoCompDetl.FGQG_PREMIUM = FGQG_PREMIUM[i];
                            //}if (FGQG_NOOFSALARY_AMT[i] != 0){
                            //     quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                            //}if (FGQG_FIXED_AMOUNT[i] != 0){
                            //     quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                            //}if (FGQG_HEADCONT_TOTSALARY[i] != 0){
                            //     quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];
                            //}if (FGQG_STATUS[i] != null){
                            //     quoCompDetl.FGQG_STATUS = FGQG_STATUS[i];
                            //}if (FGQG_MIN_SUMASSURD[i] != 0){
                            //     quoCompDetl.FGQG_MIN_SUMASSURD = FGQG_MIN_SUMASSURD[i];
                            //}if (FGQG_MAX_SUMASSURD[i] != 0){
                            //     quoCompDetl.FGQG_MAX_SUMASSURD = FGQG_MAX_SUMASSURD[i];
                            //}if (FGQG_PER_FREQNCY[i] != 0){
                            //     quoCompDetl.FGQG_PER_FREQNCY = FGQG_PER_FREQNCY[i];
                            // }


                            //quoCompDetl.FGQG_COMPGRP_ID = FGQG_COMPGRP_ID[i];
                            //quoCompDetl.FGQH_QUOTATHDR_ID = FGQH_QUOTATHDR_ID;
                            //quoCompDetl.FGQH_QTGRC_FSCD_DID = FGQH_QTGRC_FSCD_DID[i];
                            //quoCompDetl.FGQG_PREMIUM = FGQG_PREMIUM[i];
                            //quoCompDetl.FGQG_SUMASSRD_CRITRIA = FGQG_SUMASSRD_CRITRIA[i];
                            //quoCompDetl.FGQG_NOOFSALARY_AMT = FGQG_NOOFSALARY_AMT[i];
                            //quoCompDetl.FGQG_FIXED_AMOUNT = FGQG_FIXED_AMOUNT[i];
                            //quoCompDetl.FGQG_HEADCONT_TOTSALARY = FGQG_HEADCONT_TOTSALARY[i];
                            //quoCompDetl.FGQG_STATUS = FGQG_STATUS[i];
                            //quoCompDetl.FGQG_MIN_SUMASSURD = FGQG_MIN_SUMASSURD[i];
                            //quoCompDetl.FGQG_MAX_SUMASSURD = FGQG_MAX_SUMASSURD[i];
                            //quoCompDetl.FGQG_PER_FREQNCY = FGQG_PER_FREQNCY[i];

                            content = null;
                            content = new StringContent(JsonConvert.SerializeObject(quoCompDetl), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Update_QuotCompGrp, content))
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["Quotation"] = "- Quotation Saved Successfully ";// + apiResponse.Replace('"', ' ').Trim();
                            }
                        }

                        /*Quotation Agent Details Info Insert*/
                        for (int j = 0; j < AgentRow ; j++)
                        {
                            quotAgentDetl.FGQA_COMPAGNT_ID = FGQA_COMPAGNT_ID[j];
                            quotAgentDetl.FGQH_QUOTATHDR_ID = quotation.FGQH_QUOTATHDR_ID;
                            quotAgentDetl.FSAG_AGENT_CODE = FSAG_AGENT_CODE[j];
                            quotAgentDetl.FGQA_COMMISSION_PERCENT = FGQA_COMMISSION_PERCENT[j];
                            quotAgentDetl.FGQA_WAKALA_ONPREM = FGQA_WAKALA_ONPREM[j];

                            content = null;
                            content = new StringContent(JsonConvert.SerializeObject(quotAgentDetl), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Update_QuotAgtDet, content))
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["Quotation"] = "- " + apiResponse.Replace('"', ' ').Trim();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        TempData["Quotation"] = ex.ToString();
                    }
                    HttpContext.Session.SetString("FSLO_LOCATION_ID", quotation.FSLO_LOCATION_ID.ToString());
                    HttpContext.Session.SetString("FGQH_QUOTATHDR_ID", quotation.FGQH_QUOTATHDR_ID.ToString());
                }
            }
            return RedirectToAction("Quotation");
        }
        [HttpPost]
        public void ExportGetPara(string FSLO_LOCATION_ID, string FGQH_QUOTATHDR_ID)
        {
            _ = Export(FSLO_LOCATION_ID, FGQH_QUOTATHDR_ID);

        }

        [HttpPost]
        public async Task<ActionResult> Export(string FSLO_LOCATION_ID, string FGQH_QUOTATHDR_ID)
        {
            var session = HttpContext.Session;
            ViewBag.data = HttpContext.Session.GetComplexData<DataTable>("CustomerFile");

            ViewBag.FSLO_LOCATION_ID = HttpContext.Session.GetString("FSLO_LOCATION_ID");
            ViewBag.FGQH_QUOTATHDR_ID = HttpContext.Session.GetString("FGQH_QUOTATHDR_ID");

            TempData["FSLO_LOCATION_ID"] = 0;
            TempData["FGQH_QUOTATHDR_ID"] = 0;

            if (FSLO_LOCATION_ID != null && FGQH_QUOTATHDR_ID != null)
            {
                TempData["FSLO_LOCATION_ID"] = int.Parse(FSLO_LOCATION_ID.ToString());
                TempData["FGQH_QUOTATHDR_ID"] = int.Parse(FGQH_QUOTATHDR_ID.ToString());
            }
            if (ViewBag.FSLO_LOCATION_ID != null && ViewBag.FGQH_QUOTATHDR_ID != null)
            {
                TempData["FSLO_LOCATION_ID"] = int.Parse(ViewBag.FSLO_LOCATION_ID);
                TempData["FGQH_QUOTATHDR_ID"] = int.Parse(ViewBag.FGQH_QUOTATHDR_ID);
            }

            GetCustomerFile = ViewBag.data;
            try
            {
                if (GetCustomerFile != null)
                {
                    using (var client = new HttpClient())
                    {
                        for (int i = 0; i < GetCustomerFile.Rows.Count; i++)
                        {
                            CustMemUpld.FGBU_CUST_TITLE = (string)GetCustomerFile.Rows[i]["Title"];
                            CustMemUpld.FGBU_CUST_NAME = (string)GetCustomerFile.Rows[i]["Employee Name"];
                            CustMemUpld.FGBU_CUST_CNIC = (string)GetCustomerFile.Rows[i]["CNIC"];
                            CustMemUpld.FGBU_CUST_PASSPORT = (string)GetCustomerFile.Rows[i]["Passport"];
                            CustMemUpld.FGBU_EMP_ID = (string)GetCustomerFile.Rows[i]["EMP ID"];
                            CustMemUpld.FGBU_EMP_NAME = (string)GetCustomerFile.Rows[i]["Employee Name"];
                            CustMemUpld.FGBU_EMP_DESIGN = (string)GetCustomerFile.Rows[i]["Designation"];
                            CustMemUpld.FGBU_EMP_AGE = int.Parse(GetCustomerFile.Rows[i]["Age"].ToString());
                            CustMemUpld.FGBU_EMP_RELATION = (string)GetCustomerFile.Rows[i]["Relationship"];
                            CustMemUpld.FGBU_CUST_DOB = DateTime.ParseExact(GetCustomerFile.Rows[i]["DOB"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            CustMemUpld.FGBU_CUST_GENDER = (string)GetCustomerFile.Rows[i]["Gender"];
                            CustMemUpld.FGBU_CUST_OCCUPATION = (string)GetCustomerFile.Rows[i]["Occupation"];
                            CustMemUpld.FGBU_CUST_CATEGORY = (string)GetCustomerFile.Rows[i]["cat"];
                            CustMemUpld.FGBU_EMP_SALARY = int.Parse(GetCustomerFile.Rows[i]["Salaries"].ToString());
                            CustMemUpld.FGBU_POL_COVGE_TERM = int.Parse(GetCustomerFile.Rows[i]["Term"].ToString());
                            CustMemUpld.FGBU_POL_COVGE_STDATE = DateTime.ParseExact(GetCustomerFile.Rows[i]["Effective Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            CustMemUpld.FGBU_POL_COVGE_EDDATE = DateTime.ParseExact(GetCustomerFile.Rows[i]["End Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            CustMemUpld.FGBU_POL_COVGE_SUMASSURD = int.Parse(GetCustomerFile.Rows[i]["Sum Covered"].ToString());
                            CustMemUpld.FGBU_INSTIT_HEADOFFICE = (string)GetCustomerFile.Rows[i]["Head office"];
                            CustMemUpld.FGBU_INSTIT_BRANCH = (string)GetCustomerFile.Rows[i]["Branch"];
                            CustMemUpld.FGBU_CUST_MOBILENO = (string)GetCustomerFile.Rows[i]["Cell No."];
                            CustMemUpld.FGBU_CUST_EMAIL = (string)GetCustomerFile.Rows[i]["Email Address"];
                            CustMemUpld.FGBU_CUST_FAMILYID = (string)GetCustomerFile.Rows[i]["Family Id"];
                            CustMemUpld.FGBU_CUST_MARITALSTATUS = (string)GetCustomerFile.Rows[i]["Marital Status"];

                            if (TempData["FSLO_LOCATION_ID"] != null)
                            {
                                CustMemUpld.FSSI_INSTITUTE_ID = (int)TempData["FSLO_LOCATION_ID"];
                            }
                            if (TempData["FSLO_LOCATION_ID"] != null)
                            {
                                CustMemUpld.FSSI_INSTITUTE_ID = (int)TempData["FSLO_LOCATION_ID"];

                            }
                            if (TempData["FGQH_QUOTATHDR_ID"] != null)
                            {
                                CustMemUpld.FGQH_QUOTATHDR_ID = (int)TempData["FGQH_QUOTATHDR_ID"];
                            }
                            if (TempData["FGQH_QUOTATHDR_ID"] != null)
                            {
                                CustMemUpld.FGQH_QUOTATHDR_ID = (int)TempData["FGQH_QUOTATHDR_ID"];

                            }

                            StringContent content = new StringContent(JsonConvert.SerializeObject(CustMemUpld), Encoding.UTF8, "application/json");
                            using (var response = await client.PostAsync(Add_CUSTBLUK, content))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["Quotation"] = " " + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Quotation"] = ex.ToString();
            }
            return RedirectToAction("CustomerFileUpload");
        }
    }
}

