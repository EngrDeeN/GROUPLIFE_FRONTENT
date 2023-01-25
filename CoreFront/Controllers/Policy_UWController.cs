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
    public class Policy_UWController : Controller
    {

        private readonly string Add_UnderWrite = "http://"+Result_API+"/api/UnderWritting/PostUnderWritting";
        private readonly string Update_UnderWrite = "http://"+Result_API+"/api/UnderWritting/PutUnderWritting";

        private readonly string Delt_GLIndi = "http://" + Result_API + "/api/GLIndivAddi/PurgeGLIndiAddi";
        private readonly string Add_GLIAD = "http://" + Result_API + "/api/GLIndivAddi/PostGLIndiAddi";

        private readonly string FluctuatAddMmbrDtl = "http://" + Result_API + "/api/GLIndivAddi/FluctuatAddMmbrDtl";

        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public Policy_UWController(IConfiguration _configuration)
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
        public IActionResult UnderWritingPersons()
        {
            GetIPHostAPI();
            return View();
        }

        public IActionResult IndivUnderWritting()
        {
            GetIPHostAPI();
            return View();
        }

        public IActionResult GL_IndivAddi()
        {
            GetIPHostAPI();
            return View();
        }

        public IActionResult GL_IndivDele()
        {
            GetIPHostAPI();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateUnderWritting(string FGQH_QUOTATHDR_CODE_, string FSCU_IDENTIFICATION_NO, string FSPM_PRODUCT_ID, int FUPF_UNDERWRT_ID, string FUPF_BASRIDR_YN,
                                                               int FUPF_LOADING_TYPE, int FUPF_LOADING_AMT, int FUPF_NEWFCL_AMT, string FUPF_UNDW_DESCD, string FUPF_UNDW_DESREASN,
                                                               DateTime FUPF_APPRV_DATE,string FUPF_SUBSTNDRD_YN, int FUPF_AGEUSR_RATE, string FUPF_AGEUSRAT_TYP, /*End Underwritting*/ string[] RIDER_NAME, string[] REV_INDIV_CONTRIB, string[] FGQR_LOADING_TYPE,
                                                               string[] FGQR_LOADING_VALUE, DateTime[] FUPF_CONTRIBDATE, DateTime[] FUPF_NEXTDUEDATE,/*End Underwritting Rider*/int[] FGPD_POLUNW_DOC_ID, string[] FGPD_UWDOC_FSCD_DID, DateTime[] FGPD_REQUEST_DATE,
                                                               DateTime[] FGPD_RECEIVD_DATE, string[] FGPD_STATUS)
        {
            UnderWritting UnderWritting = new();
            UnderWritting.FGQH_QUOTATHDR_CODE = FGQH_QUOTATHDR_CODE_;
            UnderWritting.IDENTIF_NO = FSCU_IDENTIFICATION_NO;
            UnderWritting.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID;
            UnderWritting.FUPF_UNDERWRT_ID = FUPF_UNDERWRT_ID;
            UnderWritting.FUPF_LOADING_TYPE = FUPF_LOADING_TYPE;
            UnderWritting.FUPF_LOADING_AMT = FUPF_LOADING_AMT;
            UnderWritting.FUPF_NEWFCL_AMT = FUPF_NEWFCL_AMT;
            UnderWritting.FUPF_UNDW_DESCD = FUPF_UNDW_DESCD;
            UnderWritting.FUPF_UNDW_DESREASN = FUPF_UNDW_DESREASN;
            UnderWritting.FUPF_APPRV_DATE = FUPF_APPRV_DATE;
            UnderWritting.FUPF_SUBSTNDRD_YN = FUPF_SUBSTNDRD_YN;
            UnderWritting.FUPF_AGEUSR_RATE = FUPF_AGEUSR_RATE;
            UnderWritting.FUPF_AGEUSRAT_TYP = FUPF_AGEUSRAT_TYP;
            UnderWritting.FUPF_BASRIDR_YN = "Y";
            UnderWritting.FUPF_CRUSER = "1";
            //UnderWritting.FUPF_CRDATE = DateTime.Now();

            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (UnderWritting.FUPF_UNDERWRT_ID == 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(UnderWritting), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_UnderWrite, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["IndivUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                        UnderWritting UnderWritting_Rider = new();
                    }
                    catch (Exception ed)
                    {
                        TempData["IndivUnderWritting"] = ed.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(UnderWritting), Encoding.UTF8, "application/json");
                        using (var response = await client1.PostAsync(Update_UnderWrite, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["IndivUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["IndivUnderWritting"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("IndivUnderWritting");
        }

        [HttpPost]
        public async Task<ActionResult> GroupLifeIndividualAddition(string FGBU_CUST_CNIC, string FGBU_CUST_NAME, int FGBU_EMP_AGE, string FGBU_CUST_GENDER,
                                                                    string FGBU_CUST_OCCUPATION, string FGBU_EMP_NAME, string FGPH_POLICY_NO, int FGBU_POL_COVGE_SUMASSURD,
                                                                    int FUPF_LOADING_AMTPERC, string FUPF_LOADING_TYP, DateTime FGBU_POL_COVGE_STDATE, DateTime FGBU_POL_COVGE_EDDATE,
                                                                    string FGBU_CUST_CATEGORY, string FGBU_CUST_TITLE, DateTime FGBU_CUST_DOB)
        {
            GLIndividualAddition GLIndivDel = new();

            GLIndivDel.FGPH_POLICY_NO = FGPH_POLICY_NO;
            GLIndivDel.FGBU_CUST_CNIC = FGBU_CUST_CNIC;
            GLIndivDel.FGBU_CUST_NAME = FGBU_CUST_NAME;
            GLIndivDel.FGBU_EMP_AGE = FGBU_EMP_AGE;
            GLIndivDel.FGBU_CUST_GENDER = FGBU_CUST_GENDER;
            GLIndivDel.FGBU_CUST_OCCUPATION = FGBU_CUST_OCCUPATION;
            GLIndivDel.FGBU_EMP_NAME = FGBU_EMP_NAME;
            GLIndivDel.FGBU_CUST_CATEGORY = FGBU_CUST_CATEGORY;
            GLIndivDel.FGBU_CUST_TITLE = FGBU_CUST_TITLE;
            GLIndivDel.FGBU_POL_COVGE_SUMASSURD = FGBU_POL_COVGE_SUMASSURD;
            GLIndivDel.FGBU_CUST_DOB = FGBU_CUST_DOB;
            GLIndivDel.FUPF_LOADING_TYP = FUPF_LOADING_TYP;
            GLIndivDel.FUPF_LOADING_AMTPERC = FUPF_LOADING_AMTPERC;
            GLIndivDel.FGBU_POL_COVGE_STDATE = FGBU_POL_COVGE_STDATE;
            GLIndivDel.FGBU_POL_COVGE_EDDATE = FGBU_POL_COVGE_EDDATE;
            GLIndivDel.FGBU_CRUSER = 1;

            //FluctuatAddMmbrDtl fluctuatAddMmbrDtl = new();
            //fluctuatAddMmbrDtl.FGPH_POLICY_NO = FGPH_POLICY_NO;
            //fluctuatAddMmbrDtl.FGBU_CUST_CNIC = FGBU_CUST_CNIC;

            //fluctuatAddMmbrDtl.FGBU_POL_COVGE_SUMASSURD = FGBU_POL_COVGE_SUMASSURD;
            //fluctuatAddMmbrDtl.FUPF_LOADING_AMTPERC = FUPF_LOADING_AMTPERC;
            //fluctuatAddMmbrDtl.FUPF_LOADING_TYP = FUPF_LOADING_TYP;
            //fluctuatAddMmbrDtl.FGBU_POL_COVGE_STDATE = FGBU_POL_COVGE_STDATE;
            //fluctuatAddMmbrDtl.FGBU_POL_COVGE_EDDATE = FGBU_POL_COVGE_EDDATE;

            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (GLIndivDel.FGBU_CUST_CNIC != null)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(GLIndivDel), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_GLIAD, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            var dict2 = JArray.Parse(apiResponse);
                            foreach (JObject FGBU_BATCH_ID in dict2.Children<JObject>())
                            {
                                if (FGBU_BATCH_ID != null)
                                {
                                    var address = FGBU_BATCH_ID["IDs"];
                                    GLIndivDel.FGBU_BATCH_ID_ = int.Parse(FGBU_BATCH_ID["V_FGBU_BATCH_ID"].ToString());
                                    TempData["FGBU_BATCH_ID_"] = GLIndivDel.FGBU_BATCH_ID_;
                                    TempData["GroupLifeIndividual"] = "Customer Successfully Added.";
                                }
                            }

                            //fluctuatAddMmbrDtl.FGBU_BATCH_ID = GLIndivDel.FGBU_BATCH_ID_;

                            //SendRequest = new StringContent(JsonConvert.SerializeObject(fluctuatAddMmbrDtl), Encoding.UTF8, "application/json");
                            //using (var response2 = await client1.PostAsync(FluctuatAddMmbrDtl, SendRequest))
                            //{
                            //    string apiResponse2 = await response2.Content.ReadAsStringAsync();
                            //    TempData["GroupLifeIndividual"] = " " + apiResponse2.Replace('"', ' ').Trim();
                            //}
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["GroupLifeIndividual"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("GL_IndivAddi");
        }

        [HttpPost]
        public async Task<ActionResult> GLIndivDelete(string FGBU_CUST_CNIC, string FGPH_POLICY_NO)
        {
            GLIndividualAddition GLIndivDelete = new();

            GLIndivDelete.FGBU_CUST_CNIC = FGBU_CUST_CNIC;
            GLIndivDelete.FGPH_POLICY_NO = FGPH_POLICY_NO;

            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                try
                {
                    SendRequest = new StringContent(JsonConvert.SerializeObject(GLIndivDelete), Encoding.UTF8, "application/json");

                    using (var response = await client1.PostAsync(Delt_GLIndi, SendRequest))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        TempData["successGLIndiviDelt"] = " " + apiResponse.Replace('"', ' ').Trim();
                    }
                }
                catch (Exception ed)
                {
                    TempData["successGLIndiviDelt"] = ed.ToString();
                }
            }
            return RedirectToAction("GL_IndivDele");
        }        
    }
}

