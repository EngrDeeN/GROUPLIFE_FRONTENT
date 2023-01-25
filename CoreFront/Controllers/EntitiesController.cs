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
    public class EntitiesController : Controller
    {

        static HttpClient client = new HttpClient();

        private readonly string Add_Customer = "http://"+Result_API+"/api/Customer/PostCustomer";
        private readonly string Add_CustomerAddress = "http://"+Result_API+"/api/Customer/PostCustomerAddress";
        private readonly string Add_CustomerBankInfo = "http://"+Result_API+"/api/Customer/PostCustBankDetails";
        private readonly string Add_CustomerFamlyInfo = "http://"+Result_API+"/api/Customer/PostCustFamilyHist";
        private readonly string Add_CustomerFamDoctInfo = "http://"+Result_API+"/api/Customer/PostCustFamilyDoct";
        private readonly string Add_CustomerDocumUplInfo = "http://"+Result_API+"/api/Customer/PostCustDocumUpload";
        private readonly string Update_Customer = "http://"+Result_API+"/api/Customer/PutCustomer";
        private readonly string Update_CustomerAddress = "http://"+Result_API+"/api/Customer/PutCustomerAddress";
        private readonly string Update_CustomerBankInfo = "http://"+Result_API+"/api/Customer/PutCustBankDetails";
        private readonly string Update_CustomerFamlyInfo = "http://"+Result_API+"/api/Customer/PutCustFamilyHist";
        private readonly string Update_CustomerFamDoctInfo = "http://"+Result_API+"/api/Customer/PutCustFamilyDoct";
        private readonly string Update_CustomerDocumUplInfo = "http://"+Result_API+"/api/Customer/PutCustDocumUpload";
        private readonly string Add_InstitBasicInfo = "http://"+Result_API+"/api/Institution/PostInstitution";
        private readonly string Update_InstitBasicInfo = "http://"+Result_API+"/api/Institution/PutInstitution";

        private readonly string Add_InstitOwnerInfo = "http://"+Result_API+"/api/Institution/PostInstitOwnerInfo";
        private readonly string Update_InstitOwnerInfo = "http://"+Result_API+"/api/Institution/PutInstitOwnerInfo";
        private readonly string Add_InstitAddress = "http://"+Result_API+"/api/Institution/PostInstitAddress";
        private readonly string Update_InstitAddress = "http://"+Result_API+"/api/Institution/PutInstitAddress";
        private readonly string Add_InstitContacts = "http://"+Result_API+"/api/Institution/PostInstitContacts";
        private readonly string Update_InstitContacts = "http://"+Result_API+"/api/Institution/PutInstitContacts";
        private readonly string Add_InstitMobCont = "http://"+Result_API+"/api/Institution/PostInstitMobileDtls";
        private readonly string Update_InstitMobCont = "http://"+Result_API+"/api/Institution/PutInstitMobileDtls";
        private readonly string Add_CUSTBLUK = "http://"+Result_API+"/api/CustomerFile/UploadCustomerFile";
        private readonly string Add_Product = "http://"+Result_API+"/api/Product/PostProduct";
        private readonly string Updat_Product = "http://"+Result_API+"/api/Product/PutProduct";
        private readonly string Add_Quot = "http://"+Result_API+"/api/Quotation/PostQuotation";
        private readonly string Update_Quot = "http://"+Result_API+"/api/Quotation/PutQuotation";

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

        private readonly string Add_QuotProcFCL = "http://"+Result_API+"/api/QuotaProcess/PostQuotaFLCProcess";
        private readonly string Update_QuotProcFCL = "http://"+Result_API+"/api/QuotaProcess/PutQuotaFLCProcess";

        //private readonly string Add_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PostQuotaFLCProcess_1";
        //private readonly string Update_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PutQuotaFLCProcess_1";

        private readonly string Add_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PostQuotaProcessUR";   
        private readonly string Update_QuotProcUnitRate = "http://"+Result_API+"/api/QuotaProcess/PutQuotaProcessUR";

        private readonly string GeneratePolicyNo = "http://"+Result_API+"/api/QuotaProcess/PostQuotaProcessPolicy";
        private readonly string GeneratePolicyIssuce = "http://"+ Result_API+"/api/QuotaProcess/PolicyGenrtWithQuotationId";

        private readonly string CreateDuplicPolicy = "http://"+Result_API+"/api/QuotaProcess/CreateDuplicationQuoation";

        private readonly string Add_Receipting = "http://"+Result_API+"/api/Receipting/PostReceipting";
        private readonly string Update_Receipting = "http://"+Result_API+"/api/Receipting/PutReceipting";

        private readonly string Add_UnderWrite = "http://"+Result_API+"/api/UnderWritting/PostUnderWritting";
        private readonly string Update_UnderWrite = "http://"+Result_API+"/api/UnderWritting/PutUnderWritting";

        private readonly string Add_UnderWriteDoc = "http://"+Result_API+"/api/UnderWritting/PostUnderWrittingDocument";
        private readonly string Update_UnderWriteDoc = "http://"+Result_API+"/api/UnderWritting/PutUnderWrittingDocument";

        private readonly string Check_Quotation_Policy_Code = "http://" + Result_API + "/api/UnderWritting/PutUnderWrittingDocument";

        private readonly string Update_CustSMP = "http://"+Result_API+"/api/Customer/PutSocialMediaProfile";
        private readonly string Add_CustSMP = "http://"+Result_API+"/api/Customer/PostSocialMediaProfile";

        private readonly string Add_GLIAD = "http://"+Result_API+"/api/GLIndivAddi/PostGLIndiAddi";
        private readonly string FluctuatAddMmbrDtl = "http://"+Result_API+"/api/GLIndivAddi/FluctuatAddMmbrDtl";
             

        private readonly string Delt_GLIndi = "http://"+Result_API+"/api/GLIndivAddi/PurgeGLIndiAddi";

        private readonly string Add_Agent = "http://"+Result_API+"/api/Agent/PostAgent";
        private readonly string Update_Agent = "http://"+Result_API+"/api/Agent/PutAgent";

      
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public EntitiesController(IConfiguration _configuration)
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
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Index()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult PolicyIssuance()
        {
            return View();
        }
        public IActionResult Institution()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult Inquiry()
        {
            //GetIPHostAPI();
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
            GetIPHostAPI();
            return View();
        }

        public IActionResult QuotationProcess()
        {
            GetIPHostAPI();
            return View();
        }
        public IActionResult QuotationManagment()
        {
            return View();
        }
        public IActionResult Receipting()
        {
            return View();
        }
        public IActionResult UnderWritting()
        {
            return View();
        }
        public IActionResult GroupLifeIndividualAddition()
        {
            return View();
        }

        public IActionResult GroupLifeIndividualDeletion()
        {
            return View();
        }

        public IActionResult Claims()
        {
            return View();
        }
        public IActionResult UnderWritingPersons()
        {
            return View();
        }
        public IActionResult Agent_Registration()
        {
            return View();
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
            return RedirectToAction("GroupLifeIndividualDeletion");
        }

        [HttpPost]
        public async Task<ActionResult> SaveUpdateAgent(int FSAG_AGENT_CODE, string FSAG_AGENT_NAME, string FSAG_AGENT_TYPE, int FSNT_IDENTYPE_ID, string FSAG_PRIMARY_IDENTITY_NO, DateTime FSAG_DATE_OF_JOINING,
                                                        DateTime FSAG_DATE_OF_LEAVING, string FSAG_HAS_CAR_YN, string FSAG_SERVICE_STATUS, int FSAG_CHNLS_FSCD_DID, int FSHL_HIERCL_LEVEL_ID,
                                                        string FSAG_SALARIED_YN, string FSAG_STAR_RATED_YN, string FSAG_STATUS, DateTime fsag_date_of_confirm, int fsbk_bank_id, string fsag_ba_account_no,
                                                        string fsag_direct_agent_yn, int fsag_target_salary, int fsag_probation_period, int fsag_immedt_supvsr_code, string fsag_remarks)
        {

            AgentRegister agentRegister = new();
            agentRegister.FSAG_AGENT_CODE = FSAG_AGENT_CODE;
            agentRegister.FSAG_AGENT_NAME = FSAG_AGENT_NAME;
            agentRegister.FSAG_AGENT_TYPE = FSAG_AGENT_TYPE;
            agentRegister.FSNT_IDENTYPE_ID = FSNT_IDENTYPE_ID;
            agentRegister.FSAG_PRIMARY_IDENTITY_NO = FSAG_PRIMARY_IDENTITY_NO;
            agentRegister.FSAG_DATE_OF_JOINING = FSAG_DATE_OF_JOINING;
            agentRegister.FSAG_DATE_OF_LEAVING = FSAG_DATE_OF_LEAVING;
            agentRegister.FSAG_HAS_CAR_YN = FSAG_HAS_CAR_YN;
            agentRegister.FSAG_SERVICE_STATUS = FSAG_SERVICE_STATUS;
            agentRegister.FSAG_CHNLS_FSCD_DID = FSAG_CHNLS_FSCD_DID;
            agentRegister.FSHL_HIERCL_LEVEL_ID = FSHL_HIERCL_LEVEL_ID;
            agentRegister.FSAG_SALARIED_YN = FSAG_SALARIED_YN;
            agentRegister.FSAG_STAR_RATED_YN = FSAG_STAR_RATED_YN;
            agentRegister.FSAG_STATUS = FSAG_STATUS;
            agentRegister.fsag_date_of_confirm = fsag_date_of_confirm;
            agentRegister.fsbk_bank_id = fsbk_bank_id;
            agentRegister.fsag_ba_account_no = fsag_ba_account_no;
            agentRegister.fsag_direct_agent_yn = fsag_direct_agent_yn;
            agentRegister.fsag_target_salary = fsag_target_salary;
            agentRegister.fsag_probation_period = fsag_probation_period;
            agentRegister.fsag_immedt_supvsr_code = fsag_immedt_supvsr_code;
            agentRegister.fsag_remarks = fsag_remarks;
            agentRegister.FSAG_CRUSER = 1;


            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (agentRegister.FSAG_AGENT_CODE <= 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(agentRegister), Encoding.UTF8, "application/json");

                        //HttpResponseMessage apiResponse = await client.PostAsJsonAsync(Add_Agent, SendRequest);
                        //apiResponse.EnsureSuccessStatusCode();

                        
                        //var dict2 = JArray.Parse(apiResponse.ToString());
                        //foreach (JObject AgentParameter in dict2.Children<JObject>())
                        //{
                        //    if (AgentParameter != null)
                        //    {
                        //        //var address = AgentParameter["IDs"];
                        //        agentRegister.FSAG_AGENT_CODE = int.Parse(AgentParameter["FSAG_AGENT_CODE"].ToString());
                        //        TempData["FSAG_AGENT_CODE"] = agentRegister.FSAG_AGENT_CODE;
                        //        TempData["successAgent"] = "Agent Successfully Created.";
                        //    }
                        //}

                        
                        using (var response = await client1.PostAsync(Add_Agent, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successAgent"] = " " + apiResponse.Replace('"', ' ').Trim();
                            var dict2 = JArray.Parse(apiResponse);
                            foreach (JObject AgentParameter in dict2.Children<JObject>())
                            {
                                if (AgentParameter != null)
                                {
                                    //var address = AgentParameter["IDs"];
                                    agentRegister.FSAG_AGENT_CODE = int.Parse(AgentParameter["FSAG_AGENT_CODE"].ToString());
                                    TempData["FSAG_AGENT_CODE"] = agentRegister.FSAG_AGENT_CODE;
                                    TempData["successAgent"] = "Agent Successfully Created.";
                                }
                            }
                        }

                    }
                    catch (Exception ed)
                    {
                        TempData["successAgent"] = ed.ToString();
                    }
                }
                else
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(agentRegister), Encoding.UTF8, "application/json");

                        //HttpResponseMessage apiResponse = await client.PostAsJsonAsync(Add_Agent, SendRequest);
                        //apiResponse.EnsureSuccessStatusCode();

                      
                        using (var response = await client1.PostAsync(Update_Agent, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successAgent"] = " " + apiResponse.Replace('"', ' ').Trim();


                            //var dict2 = JArray.Parse(apiResponse);
                            //foreach (JObject AgentParameter in dict2.Children<JObject>())
                            //{
                            //    if (AgentParameter != null)
                            //    {
                            //        //var address = AgentParameter["IDs"];
                            //        agentRegister.FSAG_AGENT_CODE =int.Parse(AgentParameter["FSAG_AGENT_CODE"].ToString());
                            //        TempData["FSAG_AGENT_CODE"] = agentRegister.FSAG_AGENT_CODE;
                            //        TempData["successAgent"] = "Agent Successfully Created.";
                            //    }
                            //}
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successAgent"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("Agent_Registration");
        }


        [HttpPost]
        public async Task<ActionResult> GroupLifeIndividualAddition(string FGBU_CUST_CNIC, string FGBU_CUST_NAME, int FGBU_EMP_AGE, string FGBU_CUST_GENDER,
                                                                    string FGBU_CUST_OCCUPATION, string FGBU_EMP_NAME, string FGPH_POLICY_NO, int FGBU_POL_COVGE_SUMASSURD,
                                                                    int FUPF_LOADING_AMTPERC,string FUPF_LOADING_TYP,DateTime FGBU_POL_COVGE_STDATE, DateTime FGBU_POL_COVGE_EDDATE,
                                                                    string FGBU_CUST_CATEGORY)
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
            GLIndivDel.FGBU_CRUSER = 1;
            
            FluctuatAddMmbrDtl fluctuatAddMmbrDtl = new();
            fluctuatAddMmbrDtl.FGPH_POLICY_NO = FGPH_POLICY_NO;
            fluctuatAddMmbrDtl.FGBU_CUST_CNIC = FGBU_CUST_CNIC;

            fluctuatAddMmbrDtl.FGBU_POL_COVGE_SUMASSURD = FGBU_POL_COVGE_SUMASSURD;
            fluctuatAddMmbrDtl.FUPF_LOADING_AMTPERC = FUPF_LOADING_AMTPERC;
            fluctuatAddMmbrDtl.FUPF_LOADING_TYP = FUPF_LOADING_TYP;
            fluctuatAddMmbrDtl.FGBU_POL_COVGE_STDATE = FGBU_POL_COVGE_STDATE;
            fluctuatAddMmbrDtl.FGBU_POL_COVGE_EDDATE = FGBU_POL_COVGE_EDDATE;
          


            //GLIndivDel.FGBU_CRDATE = null;

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

                                }
                            }

                            fluctuatAddMmbrDtl.FGBU_BATCH_ID = GLIndivDel.FGBU_BATCH_ID_;

                            SendRequest = new StringContent(JsonConvert.SerializeObject(fluctuatAddMmbrDtl), Encoding.UTF8, "application/json");
                            using (var response2 = await client1.PostAsync(FluctuatAddMmbrDtl, SendRequest))
                            {
                                string apiResponse2 = await response2.Content.ReadAsStringAsync();
                                TempData["GroupLifeIndividual"] = " " + apiResponse2.Replace('"', ' ').Trim();
                            }                           
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["GroupLifeIndividual"] = ed.ToString();
                    }
                }
                //else
                //{
                //    try
                //    {
                //        SendRequest = new StringContent(JsonConvert.SerializeObject(GLIndivDel), Encoding.UTF8, "application/json");
                //        using (var response = await client1.PostAsync(FluctuatAddMmbrDtl, SendRequest))
                //        {
                //            string apiResponse = await response.Content.ReadAsStringAsync();
                //            TempData["GroupLifeIndividual"] = " " + apiResponse.Replace('"', ' ').Trim();
                //        }
                //    }
                //    catch (Exception ed)
                //    {
                //        TempData["GroupLifeIndividual"] = ed.ToString();
                //    }
                //}
            }
            return RedirectToAction("GroupLifeIndividualAddition");
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

        [HttpPost]
        public async Task<ActionResult> AddUpdateUnderWritting(string FGQH_QUOTATHDR_CODE_, string FSCU_IDENTIFICATION_NO, string FSPM_PRODUCT_ID, int FUPF_UNDERWRT_ID, string FUPF_BASRIDR_YN,
                                                               int FUPF_LOADING_TYPE, int FUPF_LOADING_AMT, int FUPF_NEWFCL_AMT, string FUPF_UNDW_DESCD, string FUPF_UNDW_DESREASN,
                                                               DateTime FUPF_APPRV_DATE, /*End Underwritting*/ string[] RIDER_NAME, string[] REV_INDIV_CONTRIB, string[] FGQR_LOADING_TYPE,
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
            UnderWritting.FUPF_BASRIDR_YN = "Y";
            UnderWritting.FUPF_CRUSER = "1";
            //UnderWritting.FUPF_CRDATE = DateTime.Now();

            UnderWritt_Doc UnderWritt_Doc = new();

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
                            TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                        UnderWritting UnderWritting_Rider = new();
                        //for (int IUR = 0; IUR < FGPD_UWDOC_FSCD_DID.Length; IUR++)
                        //{

                        //UnderWritting_Rider.FGQH_QUOTATHDR_CODE = FGQH_QUOTATHDR_CODE_[IUR];
                        //UnderWritting_Rider.IDENTIF_NO = FSCU_IDENTIFICATION_NO_[IUR]
                        //UnderWritting_Rider.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID_[IUR];
                        //UnderWritting_Rider.FUPF_UNDERWRT_ID = FUPF_UNDERWRT_ID_[IUR];
                        //UnderWritting_Rider.FUPF_LOADING_TYPE = FUPF_LOADING_TYPE_[IUR];
                        //UnderWritting_Rider.FUPF_LOADING_AMT = FUPF_LOADING_AMT_[IUR];
                        //UnderWritting_Rider.FUPF_NEWFCL_AMT = FUPF_NEWFCL_AMT_[IUR];
                        //UnderWritting_Rider.FUPF_UNDW_DESCD = FUPF_UNDW_DESCD_[IUR];
                        //UnderWritting_Rider.FUPF_UNDW_DESREASN = FUPF_UNDW_DESREASN_[IUR];
                        //UnderWritting_Rider.FUPF_APPRV_DATE = FUPF_APPRV_DATE_[IUR];
                        //UnderWritting_Rider.FUPF_BASRIDR_YN = "Y";
                        //UnderWritting_Rider.FUPF_CRUSER = "1";


                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(Add_UnderWrite_Doc), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Add_UnderWrite, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}


                        //for (int IUR = 0; IUR < FGPD_UWDOC_FSCD_DID.Length; IUR++)
                        //{

                        //    //UnderWritt_Doc.FGPD_POLUNW_DOC_ID = FGPD_POLUNW_DOC_ID[IUR];
                        //    UnderWritt_Doc.FGPD_UWDOC_FSCD_DID = FGPD_UWDOC_FSCD_DID[IUR];
                        //    UnderWritt_Doc.FGPD_REQUEST_DATE = FGPD_REQUEST_DATE[IUR];
                        //    UnderWritt_Doc.FGPD_RECEIVD_DATE = FGPD_RECEIVD_DATE[IUR];

                        //    UnderWritt_Doc.FGPD_STATUS = FGPD_STATUS[IUR];
                        //    UnderWritt_Doc.FGPD_CRUSER = "1";
                        //    //UnderWritt_Doc.FGPD_CRDATE =

                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(Add_UnderWrite_Doc), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Add_UnderWrite, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}
                    }
                    catch (Exception ed)
                    {
                        TempData["successUnderWritting"] = ed.ToString();
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
                            TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        //for (int IUR = 0; IUR < FGPD_UWDOC_FSCD_DID.Length; IUR++)
                        //{

                        //UnderWritting_Rider.FGQH_QUOTATHDR_CODE = FGQH_QUOTATHDR_CODE_[IUR];
                        //UnderWritting_Rider.IDENTIF_NO = FSCU_IDENTIFICATION_NO_[IUR]
                        //UnderWritting_Rider.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID_[IUR];
                        //UnderWritting_Rider.FUPF_UNDERWRT_ID = FUPF_UNDERWRT_ID_[IUR];
                        //UnderWritting_Rider.FUPF_LOADING_TYPE = FUPF_LOADING_TYPE_[IUR];
                        //UnderWritting_Rider.FUPF_LOADING_AMT = FUPF_LOADING_AMT_[IUR];
                        //UnderWritting_Rider.FUPF_NEWFCL_AMT = FUPF_NEWFCL_AMT_[IUR];
                        //UnderWritting_Rider.FUPF_UNDW_DESCD = FUPF_UNDW_DESCD_[IUR];
                        //UnderWritting_Rider.FUPF_UNDW_DESREASN = FUPF_UNDW_DESREASN_[IUR];
                        //UnderWritting_Rider.FUPF_APPRV_DATE = FUPF_APPRV_DATE_[IUR];
                        //UnderWritting_Rider.FUPF_BASRIDR_YN = "Y";
                        //UnderWritting_Rider.FUPF_CRUSER = "1";

                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(Add_UnderWrite_Doc), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Add_UnderWrite, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}


                        //for (int IUR = 0; IUR < FGPD_UWDOC_FSCD_DID.Length; IUR++)
                        //{
                        //    UnderWritt_Doc.FGPD_POLUNW_DOC_ID = FGPD_POLUNW_DOC_ID[IUR];
                        //    UnderWritt_Doc.FGPD_UWDOC_FSCD_DID = FGPD_UWDOC_FSCD_DID[IUR];
                        //    UnderWritt_Doc.FGPD_REQUEST_DATE = FGPD_REQUEST_DATE[IUR];
                        //    UnderWritt_Doc.FGPD_RECEIVD_DATE = FGPD_RECEIVD_DATE[IUR];
                        //    UnderWritt_Doc.FGPD_STATUS = FGPD_STATUS[IUR];
                        //    UnderWritt_Doc.FGPD_CRUSER = "1";
                        //    //UnderWritt_Doc.FGPD_CRDATE =

                        //    SendRequest = new StringContent(JsonConvert.SerializeObject(UnderWritt_Doc), Encoding.UTF8, "application/json");

                        //    using (var response = await client1.PostAsync(Update_UnderWriteDoc, SendRequest))
                        //    {
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        TempData["successUnderWritting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //    }
                        //}
                    }
                    catch (Exception ed)
                    {
                        TempData["successUnderWritting"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("UnderWritting");
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
                            TempData["successPolicyReceipting"] = " " + apiResponse.Replace('"', ' ').Trim();

                            var dict2 = JArray.Parse(apiResponse);
                            foreach (JObject receiptParameter in dict2.Children<JObject>())
                            {
                                if (receiptParameter != null)
                                {
                                    var address = receiptParameter["IDs"];
                                    receipt.FTPR_GLVOUCHR_NO = receiptParameter["RCPT_NO"].ToString();
                                    TempData["RCPT_NO"] = receipt.FTPR_GLVOUCHR_NO;
                                    TempData["successPolicyReceipting"] = "Receipt Successfully Generated.";
                                }
                            }
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPolicyReceipting"] = ed.ToString();
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
                            TempData["successPolicyReceipting"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successPolicyReceipting"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("Receipting");
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
            using (var client1 = new HttpClient())
            {
                SendRequest = null;

                if (PolIssu.FGQH_QUOTATHDR_ID != 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(PolIssu), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(CreateDuplicPolicy, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successPolicMangt"] = " " + apiResponse.Replace('"', ' ').Trim();

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
            return RedirectToAction("QuotationManagment");
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
        public async Task<ActionResult> SaveUpdateQuotaProcess( int FPQP_QUOTATPLAN_ID, int FGQH_QUOTATHDR_ID, string FGQH_QUOTATHDR_CODE, string FGQH_QUOTATION_CONFIRM, int FPQP_WAKALA_PERC, int FPQP_GROSSPREMIUM, int FPQP_NETPREMIUM, int FPQP_SUMASSURED, int FPQP_SERVICETAX,
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

        [HttpPost]
        public async Task<ActionResult> AddInstitution(int FSSI_INSTITUTE_ID, int FSIT_INSTITYP_ID, string FSSI_CATEGORY_CODE, string FSSI_OCCUP_INDSTRY_TYPE, string FSSI_COMP_SECTOR_TYPE, string FSSI_SHORT_CODE, string FSSI_DESCRIPTION,
                                                    string FSSI_SHORT_DESCRIPTION, string FSSI_WEB_ADDRESS, string FSSI_REGISTRATION_NO, DateTime FSSI_REGISTRATION_DATE, string FSSI_NTN_NO,
                                                    string FSSI_STRN_NO, DateTime FSSI_EFFECT_FROM_DATE, DateTime FSSI_EFFECT_TO_DATE, string FSSI_BANK_ROLE, string FSSI_STATUS/*Basic Info Ends*/,
                                                    string[] FSIO_OWNER_NAME, string[] FSIO_OWNER_DESIGN, string[] FSIO_OWNER_EMAIL, string[] FSIO_OWNER_CNIC, DateTime[] FSIO_OCNIC_ISSUDATE, DateTime[] FSIO_OCNIC_EXPRDATE,/*Owner Info Ends*/
                                                    string[] FSIA_ADDRESS1, string[] FSIA_ADDRESS2, string[] FSIA_ADDRESS3, int[] FSSC_COUNTRY_ID, int[] FSSP_PROVINCE_ID, int[] FSCT_CITY_ID, int[] FSPS_POSTAL_ID,
                                                    string[] FSIA_ADDR_ISCORSP/*Addr. Info Ends*/, string FSIM_MOBILE_NO1, string FSIM_MOBILE_NO2/*Mob. Info Ends*/, string FSIC_CONTACT_PERSON, string FSIC_CONT_DESIGNAT, string FSIC_CONT_CNIC,
                                                    string FSIC_CONTACT_NO1, string FSIC_CONTACT_NO2, string FSIC_FAX_NO, string FSIC_EMAIL1, string FSIC_EMAIL2, string FSIC_STATUS/*Contact Info Ends*/)
        {

            Institution institution = new();
            InstitutionOwnerInfo institOwnerInfo = new();
            InstituteAddress institAddress = new();
            InstitutionContacts institContacts = new();
            InstitutionMobContacts institMobCont = new();

            institution.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID;
            institution.FSIT_INSTITYP_ID = FSIT_INSTITYP_ID;
            institution.FSSI_CATEGORY_CODE = FSSI_CATEGORY_CODE;
            institution.FSSI_OCCUP_INDSTRY_TYPE = FSSI_OCCUP_INDSTRY_TYPE;
            institution.FSSI_COMP_SECTOR_TYPE = FSSI_COMP_SECTOR_TYPE;
            institution.FSSI_SHORT_CODE = FSSI_SHORT_CODE;
            institution.FSSI_DESCRIPTION = FSSI_DESCRIPTION;
            institution.FSSI_SHORT_DESCRIPTION = FSSI_SHORT_DESCRIPTION;
            institution.FSSI_WEB_ADDRESS = FSSI_WEB_ADDRESS;
            institution.FSSI_REGISTRATION_NO = FSSI_REGISTRATION_NO;
            institution.FSSI_REGISTRATION_DATE = FSSI_REGISTRATION_DATE;
            institution.FSSI_NTN_NO = FSSI_NTN_NO;
            institution.FSSI_STRN_NO = FSSI_STRN_NO;
            institution.FSSI_EFFECT_FROM_DATE = FSSI_EFFECT_FROM_DATE;
            institution.FSSI_EFFECT_TO_DATE = FSSI_EFFECT_TO_DATE;
            institution.FSSI_BANK_ROLE = FSSI_BANK_ROLE;
            institution.FSSI_STATUS = FSSI_STATUS;
            institution.FSSI_CRUSER = 1;

            institContacts.FSIC_CONTACT_PERSON = FSIC_CONTACT_PERSON;
            institContacts.FSIC_CONT_DESIGNAT = FSIC_CONT_DESIGNAT;
            institContacts.FSIC_EMAIL1 = FSIC_EMAIL1;
            institContacts.FSIC_EMAIL2 = FSIC_EMAIL2;
            institContacts.FSIC_CONT_CNIC = FSIC_CONT_CNIC;
            institContacts.FSIC_CONTACT_NO1 = FSIC_CONTACT_NO1;
            institContacts.FSIC_CONTACT_NO2 = FSIC_CONTACT_NO2;
            institContacts.FSIC_FAX_NO = FSIC_FAX_NO;
            // institContacts.FSIC_STATUS = FSIC_STATUS;

            string institIDValue = "";
            using (var client1 = new HttpClient())
            {

                if (institution.FSSI_INSTITUTE_ID == 0)
                {
                    try
                    {
                        SendRequest = new StringContent(JsonConvert.SerializeObject(institution), Encoding.UTF8, "application/json");

                        using (var response1 = await client1.PostAsync(Add_InstitBasicInfo, SendRequest))
                        {
                            string apiResponse = await response1.Content.ReadAsStringAsync();

                            var dict2 = JArray.Parse(apiResponse);

                            foreach (JObject instIdArr in dict2.Children<JObject>())
                            {
                                foreach (JProperty prop in instIdArr.Properties())
                                {
                                    institIDValue = prop.Value.ToString(); // This is not allowed 
                                }
                            }
                        }


                        /*Institution Contact Info Insert*/
                        institContacts.FSSI_INSTITUTE_ID = Int32.Parse(institIDValue);
                        institContacts.FSIC_CRUSER = 1;
                        TempData["Institutionid"] = Int32.Parse(institIDValue);
                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(institContacts), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_InstitContacts, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        /*Institution Mob. Contact Info Insert*/
                        institMobCont.FSIM_MOBILE_NO1 = FSIM_MOBILE_NO1;
                        institMobCont.FSIM_MOBILE_NO2 = FSIM_MOBILE_NO2;
                        institMobCont.FSSI_INSTITUTE_ID = Int32.Parse(institIDValue);
                        institMobCont.FSIM_STATUS = "Y";
                        institMobCont.FSIM_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(institMobCont), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Add_InstitMobCont, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        for (int iOW = 0; iOW < FSIO_OWNER_NAME.Length; iOW++)
                        {
                            /*Institution Owner Info Insert*/
                            institOwnerInfo.FSIO_OWNER_NAME = FSIO_OWNER_NAME[iOW];
                            institOwnerInfo.FSIO_OWNER_DESIGN = FSIO_OWNER_DESIGN[iOW];
                            institOwnerInfo.FSIO_OWNER_EMAIL = FSIO_OWNER_EMAIL[iOW];
                            institOwnerInfo.FSIO_OWNER_CNIC = FSIO_OWNER_CNIC[iOW];
                            institOwnerInfo.FSIO_OCNIC_EXPRDATE = FSIO_OCNIC_EXPRDATE[iOW];
                            institOwnerInfo.FSIO_OCNIC_ISSUDATE = FSIO_OCNIC_ISSUDATE[iOW];
                            institOwnerInfo.FSSI_INSTITUTE_ID = Int32.Parse(institIDValue);
                            institOwnerInfo.FSIO_STATUS = "Y";
                            institOwnerInfo.FSIO_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(institOwnerInfo), Encoding.UTF8, "application/json");

                            using (var response = await client1.PostAsync(Add_InstitOwnerInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successInstitution"] = "" + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                        /*Institution Address Info Insert*/
                        for (int iAd = 0; iAd < FSIA_ADDRESS1.Length; iAd++)
                        {
                            institAddress.FSSI_INSTITUTE_ID = Int32.Parse(institIDValue); // FSCU_CUSTOMER_CODE;
                            institAddress.FSIA_ADDRESS_TYPE = (iAd == 0) ? "P" : (iAd == 1) ? "R" : "B";
                            institAddress.FSIA_ADDRESS1 = FSIA_ADDRESS1[iAd];
                            institAddress.FSIA_ADDRESS2 = FSIA_ADDRESS2[iAd];
                            institAddress.FSIA_ADDRESS3 = FSIA_ADDRESS3[iAd];

                            if (institAddress.FSIA_ADDRESS1 != null)
                            {
                                institAddress.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID[iAd];
                                institAddress.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID[iAd];
                                institAddress.FSCT_CITY_ID = FSCT_CITY_ID[iAd];
                                institAddress.FSPS_POSTAL_ID = FSPS_POSTAL_ID[iAd];
                                institAddress.FSIA_ADDR_ISCORSP = FSIA_ADDR_ISCORSP[iAd]; // (iAd == 0) ? FSIA_ADDR_ISCORSP[iAd] : "";
                            }
                            institAddress.FSIA_STATUS = "Y";
                            institAddress.FSIA_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(institAddress), Encoding.UTF8, "application/json");

                            using (var response = await client1.PostAsync(Add_InstitAddress, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["successInstitution"] = ex.ToString();
                    }
                }
                else if (institution.FSSI_INSTITUTE_ID != 0)
                {

                    /*Institution Basic Info Insert*/
                    SendRequest = new StringContent(JsonConvert.SerializeObject(institution), Encoding.UTF8, "application/json");

                    try
                    {
                        using (var response = await client1.PostAsync(Update_InstitBasicInfo, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["PostPutResponse"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        /*Institution Contact Info Insert*/
                        institContacts.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID;
                        institContacts.FSIC_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(institContacts), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_InstitContacts, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        /*Institution Mob. Contact Info Insert*/
                        institMobCont.FSIM_MOBILE_NO1 = FSIM_MOBILE_NO1;
                        institMobCont.FSIM_MOBILE_NO2 = FSIM_MOBILE_NO2;
                        institMobCont.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID;
                        institMobCont.FSIM_STATUS = "Y";
                        institMobCont.FSIM_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(institMobCont), Encoding.UTF8, "application/json");

                        using (var response = await client1.PostAsync(Update_InstitMobCont, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }

                        ///*Institution Owner Info Insert*/
                        //institOwnerInfo.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID;
                        //institOwnerInfo.FSIO_STATUS = "Y";
                        //institOwnerInfo.FSIO_CRUSER = 1;

                        //SendRequest = null;
                        //SendRequest = new StringContent(JsonConvert.SerializeObject(institOwnerInfo), Encoding.UTF8, "application/json");

                        //using (var response = await client1.PostAsync(Update_InstitOwnerInfo, SendRequest))
                        //{
                        //    string apiResponse = await response.Content.ReadAsStringAsync();
                        //    TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                        //}

                        for (int iOW = 0; iOW < FSIO_OWNER_NAME.Length; iOW++)
                        {
                            /*Institution Owner Info Insert*/
                            institOwnerInfo.FSIO_OWNER_NAME = FSIO_OWNER_NAME[iOW];
                            institOwnerInfo.FSIO_OWNER_DESIGN = FSIO_OWNER_DESIGN[iOW];
                            institOwnerInfo.FSIO_OWNER_EMAIL = FSIO_OWNER_EMAIL[iOW];
                            institOwnerInfo.FSIO_OWNER_CNIC = FSIO_OWNER_CNIC[iOW];
                            institOwnerInfo.FSIO_OCNIC_EXPRDATE = FSIO_OCNIC_EXPRDATE[iOW];
                            institOwnerInfo.FSIO_OCNIC_ISSUDATE = FSIO_OCNIC_ISSUDATE[iOW];
                            institOwnerInfo.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID;
                            institOwnerInfo.FSIO_STATUS = "Y";
                            institOwnerInfo.FSIO_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(institOwnerInfo), Encoding.UTF8, "application/json");

                            using (var response = await client1.PostAsync(Update_InstitOwnerInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successInstitution"] = "" + apiResponse.Replace('"', ' ').Trim();
                            }
                        }



                        /*Institution Address Info Insert*/
                        for (int iAd = 0; iAd < FSIA_ADDRESS1.Length; iAd++)
                        {
                            institAddress.FSSI_INSTITUTE_ID = FSSI_INSTITUTE_ID; // FSCU_CUSTOMER_CODE;
                            institAddress.FSIA_ADDRESS_TYPE = (iAd == 0) ? "P" : (iAd == 1) ? "R" : "B";
                            institAddress.FSIA_ADDRESS1 = FSIA_ADDRESS1[iAd];
                            institAddress.FSIA_ADDRESS2 = FSIA_ADDRESS2[iAd];
                            institAddress.FSIA_ADDRESS3 = FSIA_ADDRESS3[iAd];

                            if (institAddress.FSIA_ADDRESS1 != null)
                            {
                                institAddress.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID[iAd];
                                institAddress.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID[iAd];
                                institAddress.FSCT_CITY_ID = FSCT_CITY_ID[iAd];
                                institAddress.FSPS_POSTAL_ID = FSPS_POSTAL_ID[iAd];
                                institAddress.FSIA_ADDR_ISCORSP = FSIA_ADDR_ISCORSP[iAd]; // (iAd == 0) ? FSIA_ADDR_ISCORSP[iAd] : "";
                            }
                            institAddress.FSIA_STATUS = "Y";
                            institAddress.FSIA_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(institAddress), Encoding.UTF8, "application/json");

                            using (var response = await client1.PostAsync(Update_InstitAddress, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successInstitution"] = " " + apiResponse.Replace('"', ' ').Trim();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["successInstitution"] = ex.ToString();
                    }
                }
                return RedirectToAction("Institution");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateCustomer(int FSCU_CUSTOMER_CODE, int FSNT_IDENTYPE_ID, string FSCU_IDENTIFICATION_NO, DateTime FSCU_IDENTISSUE_DATE,
                                                          DateTime FSCU_IDENTIEXPIRY_DATE, int FSCU_TITLE_FSCD_DID, string FSCU_FULL_NAME, string FSCU_FIRST_NAME, string FSCU_MIDDLE_NAME,
                                                          string FSCU_LAST_NAME, string FSCU_FATHUSB_NAME, string FSCU_MOTHER_NAME, int FSCU_GENDR_FSCD_DID, int FSCU_MRTST_FSCD_DID,
                                                          DateTime FSCU_DATEOFBIRTH, int FSCU_BIRTH_COUNTRY, string FSCU_FAMILY_ID, int FSCU_NOOFDEPENDENTS, int FSCU_RELGN_FSCD_DID,
                                                          int FSCU_RACES_FSCD_DID, int FSSC_COUNTRY_ID_BI, string FSCU_DUAL_NATIONAL_YN, string FSCU_CUST_STATUS, int FSCU_IDENTIFICTYPE2,
                                                          string FSCU_IDENTIFICATION_NO2, DateTime FSCU_IDENTISSUE_DATE2, DateTime FSCU_IDENTIEXPIRY_DATE2, int FSCU_CUOCP_FSCD_DID,
                                                          int FSCU_WORKEXP_YEARS, int FSCR_CURRENCY_CODE, int FSCU_CUST_ANNUAL_INCOME, string FSCU_NTN_NUMBER, string FSCU_VIP_CUSTOMER_YN,
                                                          string FSCU_AGE_ADMITTED_YN, string FSCU_CUST_TAX_EXEMPT_YN, string FSCU_CUST_ISEMPLOYEE_YN, string FSCU_CUST_EMPLOYEE_CODE,
                                                          string FSCU_CUST_SMOKER_YN, string FSCU_CUST_DRINKER_YN, decimal FSCU_CUST_HEIGHT, int FSCU_MSUNT_HEIT_FSCD_DID, decimal FSCU_CUST_WEIGHT,
                                                          int FSCU_MSUNT_WEIT_FSCD_DID, decimal FSCU_CUST_BMI /*Basic Info Ends*/, string[] FSCA_ADDRESS1, string[] FSCA_ADDRESS2, string[] FSCA_ADDRESS3,
                                                          int[] FSSC_COUNTRY_ID, int[] FSSP_PROVINCE_ID, int[] FSCT_CITY_ID, int[] FSPS_POSTAL_ID, int[] FSAP_AREA_ID, string FSCA_TELNO1,
                                                          string FSCA_TELNO2, string FSCA_MOBILE1, string FSCA_MOBILE2, string FSCA_POBOX, string FSCA_FAXNO, string FSCA_PAGER, string FSCA_EMAIL1,
                                                          string FSCA_EMAIL2, string FSCA_ADDR_ISCORSP, string FSCA_STATUS /*Address Info Ends*/, string[] FSCB_ACCOUNT_TITLE, string[] FSBK_BANK_NAME,
                                                          string[] FSCB_BRANCH_NAME, string[] FSCB_ACCOUNT_NO, string[] FSCB_ACCOUNT_TYPE /*Bank Info Ends*/, string[] FSCF_MEMBER_NAME, int[] FSCU_RELTN_FSCD_DID, string[] FSCF_MEMBER_STATUS,
                                                          int[] FSCF_AGE, string[] FSCF_STATOFHLTH, string[] FSCF_YEAROFDTH, int[] FSCF_AGEOFDTH, string[] FSCF_CAUSOFDTH,
                                                          int[] FSCF_SERIAL_NO, int[] FSCB_SERIAL_NO/*Family Hist Info Ends*/, int[] FSCB_ACCOUNT_CATGRY, string FSFD_DOCTOR_NAME, string FSFD_DOCTOR_TYPE, string FSFD_HOSPCLINC_ADDRESS, int FSSC_COUNTRY_ID_DC,
                                                          int FSSP_PROVINCE_ID_DC, int FSCT_CITY_ID_DC /*Family Doct. Info Ends*/, int FSDU_DOCUMENT_ID, string FSDU_DOCUMENT_NAME, string FSFD_DOCTR_CONTNO,
                                                          string FSDU_DOC_ACTUAL_PATH, string FSDU_STATUS, /*Document Upload Info Ends*/ string FSCS_SOCIALMED_TYP, string FSCS_SOCIALMED_LINK)
        {
            Customer customer = new();
            CustomerAddress custAddres = new();
            CustomerBankDtls custBankInfo = new();
            CustomerFamlyHist custFamInfo = new();
            CustomerFamlyDoctr custFamDoct = new();
            CustomerDocUpload custDocumInfo = new();
            CustomerSociMedProf CustSocMediPro = new();

            customer.FSCU_CUSTOMER_CODE = FSCU_CUSTOMER_CODE;
            customer.FSNT_IDENTYPE_ID = FSNT_IDENTYPE_ID;
            customer.FSCU_IDENTIFICATION_NO = FSCU_IDENTIFICATION_NO;
            customer.FSCU_IDENTISSUE_DATE = FSCU_IDENTISSUE_DATE;
            customer.FSCU_IDENTIEXPIRY_DATE = FSCU_IDENTIEXPIRY_DATE;
            customer.FSCU_TITLE_FSCD_DID = FSCU_TITLE_FSCD_DID;
            customer.FSCU_FULL_NAME = FSCU_FULL_NAME;
            customer.FSCU_FIRST_NAME = FSCU_FIRST_NAME;
            customer.FSCU_MIDDLE_NAME = FSCU_MIDDLE_NAME;
            customer.FSCU_LAST_NAME = FSCU_LAST_NAME;
            customer.FSCU_FATHUSB_NAME = FSCU_FATHUSB_NAME;
            customer.FSCU_MOTHER_NAME = FSCU_MOTHER_NAME;
            customer.FSCU_GENDR_FSCD_DID = FSCU_GENDR_FSCD_DID;
            customer.FSCU_MRTST_FSCD_DID = FSCU_MRTST_FSCD_DID;
            customer.FSCU_DATEOFBIRTH = FSCU_DATEOFBIRTH;
            customer.FSCU_BIRTH_COUNTRY = FSCU_BIRTH_COUNTRY;
            customer.FSCU_FAMILY_ID = FSCU_FAMILY_ID;
            customer.FSCU_NOOFDEPENDENTS = FSCU_NOOFDEPENDENTS;
            customer.FSCU_RELGN_FSCD_DID = FSCU_RELGN_FSCD_DID;
            customer.FSCU_RACES_FSCD_DID = FSCU_RACES_FSCD_DID;
            customer.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID_BI;
            customer.FSCU_DUAL_NATIONAL_YN = FSCU_DUAL_NATIONAL_YN;
            customer.FSCU_CUST_STATUS = FSCU_CUST_STATUS;
            customer.FSCU_IDENTIFICTYPE2 = FSCU_IDENTIFICTYPE2;
            customer.FSCU_IDENTIFICATION_NO2 = FSCU_IDENTIFICATION_NO2;
            customer.FSCU_IDENTISSUE_DATE2 = FSCU_IDENTISSUE_DATE2;
            customer.FSCU_IDENTIEXPIRY_DATE2 = FSCU_IDENTIEXPIRY_DATE2;
            customer.FSCU_CUOCP_FSCD_DID = FSCU_CUOCP_FSCD_DID;
            customer.FSCU_WORKEXP_YEARS = FSCU_WORKEXP_YEARS;
            customer.FSCR_CURRENCY_CODE = FSCR_CURRENCY_CODE;
            customer.FSCU_CUST_ANNUAL_INCOME = FSCU_CUST_ANNUAL_INCOME;
            customer.FSCU_NTN_NUMBER = FSCU_NTN_NUMBER;
            customer.FSCU_VIP_CUSTOMER_YN = FSCU_VIP_CUSTOMER_YN;
            customer.FSCU_AGE_ADMITTED_YN = FSCU_AGE_ADMITTED_YN;
            customer.FSCU_CUST_TAX_EXEMPT_YN = FSCU_CUST_TAX_EXEMPT_YN;
            customer.FSCU_CUST_ISEMPLOYEE_YN = FSCU_CUST_ISEMPLOYEE_YN;
            customer.FSCU_CUST_EMPLOYEE_CODE = FSCU_CUST_EMPLOYEE_CODE;
            customer.FSCU_CUST_SMOKER_YN = FSCU_CUST_SMOKER_YN;
            customer.FSCU_CUST_DRINKER_YN = FSCU_CUST_DRINKER_YN;
            customer.FSCU_CUST_HEIGHT = FSCU_CUST_HEIGHT;
            customer.FSCU_MSUNT_HEIT_FSCD_DID = FSCU_MSUNT_HEIT_FSCD_DID;
            customer.FSCU_CUST_WEIGHT = FSCU_CUST_WEIGHT;
            customer.FSCU_MSUNT_WEIT_FSCD_DID = FSCU_MSUNT_WEIT_FSCD_DID;
            customer.FSCU_CUST_BMI = FSCU_CUST_BMI;
            customer.FSCU_CRUSER = 1;

            using (var client = new HttpClient())
            {

                if (customer.FSCU_CUSTOMER_CODE <= 0)
                {
                    try
                    {
                        /*Customer Basic Info Insert*/
                        SendRequest = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Add_Customer, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            var dict2 = JArray.Parse(apiResponse);

                            foreach (JObject CustomerGetID in dict2.Children<JObject>())
                            {

                                if (CustomerGetID != null)
                                {
                                    var address = CustomerGetID["IDs"];
                                    customer.FSCU_CUSTOMER_CODE = int.Parse(CustomerGetID["NEW_GEN_CUST_CODE"].ToString());
                                    TempData["CustomerID"] = customer.FSCU_CUSTOMER_CODE;
                                }
                            }
                        }

                        /*Customer Address Info Insert*/
                        for (int iAd = 0; iAd < FSCA_ADDRESS1.Length; iAd++)
                        {
                            custAddres.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE; // FSCU_CUSTOMER_CODE;
                            custAddres.FSCA_ADDRESS_TYPE = (iAd == 0) ? "P" : (iAd == 1) ? "R" : "B";
                            custAddres.FSCA_ADDRESS1 = FSCA_ADDRESS1[iAd];
                            custAddres.FSCA_ADDRESS2 = FSCA_ADDRESS2[iAd];
                            custAddres.FSCA_ADDRESS3 = FSCA_ADDRESS3[iAd];

                            if (custAddres.FSCA_ADDRESS1 != null)
                            {
                                custAddres.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID[iAd];
                                custAddres.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID[iAd];
                                custAddres.FSCT_CITY_ID = FSCT_CITY_ID[iAd];
                                custAddres.FSPS_POSTAL_ID = FSPS_POSTAL_ID[iAd];
                                custAddres.FSAP_AREA_ID = FSAP_AREA_ID[iAd];

                            }
                            custAddres.FSCA_TELNO1 = (iAd == 0) ? FSCA_TELNO1 : "";
                            custAddres.FSCA_TELNO2 = (iAd == 0) ? FSCA_TELNO2 : "";
                            custAddres.FSCA_MOBILE1 = (iAd == 0) ? FSCA_MOBILE1 : "";
                            custAddres.FSCA_MOBILE2 = (iAd == 0) ? FSCA_MOBILE2 : "";
                            custAddres.FSCA_POBOX = (iAd == 0) ? FSCA_POBOX : "";
                            custAddres.FSCA_FAXNO = (iAd == 0) ? FSCA_FAXNO : "";
                            custAddres.FSCA_PAGER = (iAd == 0) ? FSCA_PAGER : "";
                            custAddres.FSCA_EMAIL1 = (iAd == 0) ? FSCA_EMAIL1 : "";
                            custAddres.FSCA_EMAIL2 = (iAd == 0) ? FSCA_EMAIL2 : "";
                            custAddres.FSCA_ADDR_ISCORSP = (iAd == 0) ? FSCA_ADDR_ISCORSP : "";
                            custAddres.FSCA_STATUS = FSCA_STATUS;
                            custAddres.FSCA_CRUSER = 1;
                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(custAddres), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustomerAddress, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                //TempData["successCustomer"] = " " + apiResponse.Replace('"', ' ').Trim();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }

                        /*Customer Bank Info Insert*/
                        for (int BInf = 0; BInf < FSCB_ACCOUNT_TITLE.Length; BInf++)
                        {
                            custBankInfo.FSCB_ACCOUNT_TITLE = FSCB_ACCOUNT_TITLE[BInf];
                            custBankInfo.FSBK_BANK_NAME = FSBK_BANK_NAME[BInf];
                            custBankInfo.FSCB_BRANCH_NAME = FSCB_BRANCH_NAME[BInf];
                            custBankInfo.FSCB_ACCOUNT_NO = FSCB_ACCOUNT_NO[BInf];
                            custBankInfo.FSCB_ACCOUNT_TYPE = FSCB_ACCOUNT_TYPE[BInf];
                            custBankInfo.FSCB_ACCOUNT_CATGRY = FSCB_ACCOUNT_CATGRY[BInf];
                            custBankInfo.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                            custBankInfo.FSCB_STATUS = "Y";
                            custBankInfo.FSCB_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(custBankInfo), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustomerBankInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }
                        /*Customer Family Info Insert*/
                        for (int iFh = 0; iFh < FSCF_MEMBER_NAME.Length; iFh++)
                        {
                            custFamInfo.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                            custFamInfo.FSCF_MEMBER_NAME = FSCF_MEMBER_NAME[iFh];
                            custFamInfo.FSCU_RELTN_FSCD_DID = FSCU_RELTN_FSCD_DID[iFh];
                            custFamInfo.FSCF_MEMBER_STATUS = FSCF_MEMBER_STATUS[iFh];
                            custFamInfo.FSCF_AGE = FSCF_AGE[iFh];

                            if (FSCF_MEMBER_STATUS[iFh] != " ")
                            {
                                custFamInfo.FSCF_MEMBER_STATUS = "1";
                            }
                            else
                            {
                                custFamInfo.FSCF_MEMBER_STATUS = "2";
                            }
                            custFamInfo.FSCF_STATOFHLTH = FSCF_STATOFHLTH[iFh];

                            if (custFamInfo.FSCF_YEAROFDTH != null)
                            {
                                custFamInfo.FSCF_YEAROFDTH = FSCF_YEAROFDTH[iFh];
                                custFamInfo.FSCF_AGEOFDTH = FSCF_AGEOFDTH[iFh];
                                custFamInfo.FSCF_CAUSOFDTH = FSCF_CAUSOFDTH[iFh];
                            }
                            else
                            {
                                custFamInfo.FSCF_YEAROFDTH = FSCF_YEAROFDTH[iFh];
                                custFamInfo.FSCF_AGEOFDTH = FSCF_AGEOFDTH[iFh];
                                custFamInfo.FSCF_CAUSOFDTH = FSCF_CAUSOFDTH[iFh];
                            }

                            custFamInfo.FSCF_STATUS = "Y";
                            custFamInfo.FSCF_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(custFamInfo), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustomerFamlyInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }

                        if (FSFD_DOCTOR_NAME != null)
                        {
                            /*Customer Family Doctor Info Insert*/
                            custFamDoct.FSFD_DOCTOR_NAME = FSFD_DOCTOR_NAME;
                            custFamDoct.FSFD_DOCTOR_TYPE = FSFD_DOCTOR_TYPE;
                            custFamDoct.FSFD_HOSPCLINC_ADDRESS = FSFD_HOSPCLINC_ADDRESS;
                            custFamDoct.FSFD_DOCTR_CONTNO = FSFD_DOCTR_CONTNO;
                            custFamDoct.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID_DC;
                            custFamDoct.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID_DC;
                            custFamDoct.FSCT_CITY_ID = FSCT_CITY_ID_DC;
                            custFamDoct.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                            custFamDoct.FSFD_SERIAL_NO = 1;
                            custFamDoct.FSFD_STATUS = "Y";
                            custFamDoct.FSFD_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(custFamDoct), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustomerFamDoctInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }

                        if (FSDU_DOCUMENT_NAME != null)
                        {
                            /*Customer Document Upload Info Insert*/
                            custDocumInfo.FSDU_DOCUMENT_ID = FSDU_DOCUMENT_ID;
                            custDocumInfo.FSDU_DOCUMENT_NAME = FSDU_DOCUMENT_NAME;

                            custDocumInfo.FSDU_DOC_ACTUAL_PATH = FSDU_DOC_ACTUAL_PATH;
                            custDocumInfo.FSDU_STATUS = FSDU_STATUS;
                            custDocumInfo.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                            custDocumInfo.FSDU_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(custDocumInfo), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustomerDocumUplInfo, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }


                        if (FSCS_SOCIALMED_TYP != null)
                        {
                            /*Customer Document Upload Info Insert*/
                            CustSocMediPro.FSCS_SOCIALMED_TYP = FSCS_SOCIALMED_TYP;
                            CustSocMediPro.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                            CustSocMediPro.FSCS_SOCIALMED_LINK = FSCS_SOCIALMED_LINK;
                            CustSocMediPro.FSCS_CRUSER = 1;

                            SendRequest = null;
                            SendRequest = new StringContent(JsonConvert.SerializeObject(CustSocMediPro), Encoding.UTF8, "application/json");

                            using (var response = await client.PostAsync(Add_CustSMP, SendRequest))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                            }
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successCustomer"] = ed.ToString();
                    }

                }

                else //if (customer.FSCU_CUSTOMER_CODE != 0)
                {

                    /*Customer Basic Info Insert*/
                    SendRequest = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                    using (var response = await client.PostAsync(Update_Customer, SendRequest))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                    }

                    /*Customer Address Info Insert*/
                    for (int iAd = 0; iAd < FSCA_ADDRESS1.Length; iAd++)
                    {
                        custAddres.FSCU_CUSTOMER_CODE = FSCU_CUSTOMER_CODE;
                        custAddres.FSCA_ADDRESS_TYPE = (iAd == 0) ? "P" : (iAd == 1) ? "R" : "B";
                        custAddres.FSCA_ADDRESS1 = FSCA_ADDRESS1[iAd];
                        custAddres.FSCA_ADDRESS2 = FSCA_ADDRESS2[iAd];
                        custAddres.FSCA_ADDRESS3 = FSCA_ADDRESS3[iAd];

                        if (custAddres.FSCA_ADDRESS1 != null)
                        {
                            custAddres.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID[iAd];
                            custAddres.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID[iAd];
                            custAddres.FSCT_CITY_ID = FSCT_CITY_ID[iAd];
                            custAddres.FSPS_POSTAL_ID = FSPS_POSTAL_ID[iAd];
                            custAddres.FSAP_AREA_ID = FSAP_AREA_ID[iAd];
                        }
                        custAddres.FSCA_TELNO1 = (iAd == 0) ? FSCA_TELNO1 : "";
                        custAddres.FSCA_TELNO2 = (iAd == 0) ? FSCA_TELNO2 : "";
                        custAddres.FSCA_MOBILE1 = (iAd == 0) ? FSCA_MOBILE1 : "";
                        custAddres.FSCA_MOBILE2 = (iAd == 0) ? FSCA_MOBILE2 : "";
                        custAddres.FSCA_POBOX = (iAd == 0) ? FSCA_POBOX : "";
                        custAddres.FSCA_FAXNO = (iAd == 0) ? FSCA_FAXNO : "";
                        custAddres.FSCA_PAGER = (iAd == 0) ? FSCA_PAGER : "";
                        custAddres.FSCA_EMAIL1 = (iAd == 0) ? FSCA_EMAIL1 : "";
                        custAddres.FSCA_EMAIL2 = (iAd == 0) ? FSCA_EMAIL2 : "";
                        custAddres.FSCA_ADDR_ISCORSP = (iAd == 0) ? FSCA_ADDR_ISCORSP : "";
                        custAddres.FSCA_STATUS = FSCA_STATUS;
                        custAddres.FSCA_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(custAddres), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustomerAddress, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successCustomer"] = " " + apiResponse.Replace('"', ' ').Trim();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }

                    /*Customer Bank Info Insert*/
                    for (int BInf = 0; BInf < FSCB_ACCOUNT_TITLE.Length; BInf++)
                    {
                        custBankInfo.FSCB_ACCOUNT_TITLE = FSCB_ACCOUNT_TITLE[BInf];
                        custBankInfo.FSBK_BANK_NAME = FSBK_BANK_NAME[BInf];
                        custBankInfo.FSCB_BRANCH_NAME = FSCB_BRANCH_NAME[BInf];
                        custBankInfo.FSCB_ACCOUNT_NO = FSCB_ACCOUNT_NO[BInf];
                        custBankInfo.FSCB_ACCOUNT_TYPE = FSCB_ACCOUNT_TYPE[BInf];
                        custBankInfo.FSCB_ACCOUNT_CATGRY = FSCB_ACCOUNT_CATGRY[BInf];
                        custBankInfo.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                        custBankInfo.FSCB_SERIAL_NO = FSCB_SERIAL_NO[BInf];
                        custBankInfo.FSCB_STATUS = "Y";
                        custBankInfo.FSCB_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(custBankInfo), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustomerBankInfo, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successCustomer"] = " " + apiResponse.Replace('"', ' ').Trim();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }


                    /*Customer Family Info Insert*/
                    for (int iFh = 0; iFh < FSCF_MEMBER_NAME.Length; iFh++)
                    {
                        custFamInfo.FSCU_CUSTOMER_CODE = FSCU_CUSTOMER_CODE;
                        custFamInfo.FSCF_MEMBER_NAME = FSCF_MEMBER_NAME[iFh];
                        custFamInfo.FSCU_RELTN_FSCD_DID = FSCU_RELTN_FSCD_DID[iFh];

                        custFamInfo.FSCF_SERIAL_NO = FSCF_SERIAL_NO[iFh];
                        custFamInfo.FSCF_AGE = FSCF_AGE[iFh];

                        if (FSCF_MEMBER_STATUS[iFh] == "1")
                        {
                            custFamInfo.FSCF_MEMBER_STATUS = "1";
                        }
                        else if (FSCF_MEMBER_STATUS[iFh] != "2")
                        {
                            custFamInfo.FSCF_MEMBER_STATUS = "2";
                        }
                        custFamInfo.FSCF_STATOFHLTH = FSCF_STATOFHLTH[iFh];

                        if (FSCF_YEAROFDTH[iFh] == null)
                        {
                            //custFamInfo.FSCF_YEAROFDTH = ""; //FSCF_YEAROFDTH[iFh];
                            //custFamInfo.FSCF_AGEOFDTH = FSCF_AGEOFDTH[iFh];
                            //custFamInfo.FSCF_CAUSOFDTH = FSCF_CAUSOFDTH[iFh];

                        }
                        else
                        {
                            custFamInfo.FSCF_YEAROFDTH = FSCF_YEAROFDTH[iFh];
                            custFamInfo.FSCF_AGEOFDTH = FSCF_AGEOFDTH[iFh];
                            custFamInfo.FSCF_CAUSOFDTH = FSCF_CAUSOFDTH[iFh];
                        }

                        custFamInfo.FSCF_STATUS = "Y";
                        custFamInfo.FSCF_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(custFamInfo), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustomerFamlyInfo, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //TempData["successCustomer"] = " " + apiResponse.Replace('"', ' ').Trim();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }
                    if (FSFD_DOCTOR_NAME != null)
                    {
                        /*Customer Family Doctor Info Insert*/
                        custFamDoct.FSFD_DOCTOR_NAME = FSFD_DOCTOR_NAME;
                        custFamDoct.FSFD_DOCTOR_TYPE = FSFD_DOCTOR_TYPE;
                        custFamDoct.FSFD_HOSPCLINC_ADDRESS = FSFD_HOSPCLINC_ADDRESS;
                        custFamDoct.FSFD_DOCTR_CONTNO = FSFD_DOCTR_CONTNO;
                        custFamDoct.FSSC_COUNTRY_ID = FSSC_COUNTRY_ID_DC;
                        custFamDoct.FSSP_PROVINCE_ID = FSSP_PROVINCE_ID_DC;
                        custFamDoct.FSCT_CITY_ID = FSCT_CITY_ID_DC;
                        custFamDoct.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                        custFamDoct.FSFD_SERIAL_NO = 1;
                        custFamDoct.FSFD_STATUS = "Y";
                        custFamDoct.FSFD_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(custFamDoct), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustomerFamDoctInfo, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }
                    if (FSDU_DOCUMENT_NAME != null)
                    {
                        /*Customer Document Upload Info Insert*/
                        custDocumInfo.FSDU_DOCUMENT_ID = FSDU_DOCUMENT_ID;
                        custDocumInfo.FSDU_DOCUMENT_NAME = FSDU_DOCUMENT_NAME;
                        custDocumInfo.FSDU_DOC_ACTUAL_PATH = FSDU_DOC_ACTUAL_PATH;
                        custDocumInfo.FSDU_STATUS = FSDU_STATUS;
                        custDocumInfo.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                        custDocumInfo.FSDU_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(custDocumInfo), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustomerDocumUplInfo, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }

                    if (FSCS_SOCIALMED_TYP != null)
                    {
                        /*Customer Document Upload Info Insert*/
                        CustSocMediPro.FSCS_SOCIALMED_TYP = FSCS_SOCIALMED_TYP;
                        CustSocMediPro.FSCU_CUSTOMER_CODE = customer.FSCU_CUSTOMER_CODE;
                        CustSocMediPro.FSCS_SOCIALMED_LINK = FSCS_SOCIALMED_LINK;
                        CustSocMediPro.FSCS_CRUSER = 1;

                        SendRequest = null;
                        SendRequest = new StringContent(JsonConvert.SerializeObject(CustSocMediPro), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(Update_CustSMP, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successCustomer"] = " Customer Record Successfully Saved. ";
                        }
                    }
                }
                return RedirectToAction("Customer");

            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(string FSPM_PRODUCT_CODE, int FSPM_PRODUCT_ID, string FSPM_PRODUCT_NAME, string FSPM_PRODUCT_DESP, string FSPM_PRODUCTION_LINE,
                                                   int FSPM_PRODUCT_TYPE, string FSPM_PRODUCT_CATEG, string FSPM_PRODUCT_NATURE, string FSPM_PRODLIFE_FLAG, string FSPM_PRODINDEX_TYPE,
                                                   string FSPM_PRODINTREST_YN, int FSPM_1STAGEENT_MIN, int FSPM_1STAGEENT_MAX, int FSPM_2NDAGEENT_MIN,
                                                   int FSPM_2NDAGEENT_MAX, int FSPM_1STAGEMAT_MIN, int FSPM_1STAGEMAT_MAX, int FSPM_2NDAGEMAT_MIN,
                                                   int FSPM_2NDAGEMAT_MAX, int FSPM_SUMASSURD_MIN, int FSPM_SUMASSURD_MAX, int FSPM_BENEFTERM_MIN,
                                                   int FSPM_BENEFTERM_MAX, int FSPM_PREMITERM_MIN, int FSPM_PREMITERM_MAX, string FSPM_NONSMOKER_YN,
                                                   string FSPM_FEMALEADJ_YN, string FSPM_INDXATION_YN, string FSPM_CASHVALU_YN, string FSPM_TOPUPCONTRB_YN,
                                                   string FSPM_LOAN_YN, string FSPM_PERSISTBONS_YN, DateTime FSPM_START_DATE, DateTime FSPM_END_DATE,
                                                   int FSPM_GROUPSIZE_FROM, int FSPM_GROUPSIZE_TO, int FSPM_GROUPSA_FROM, int FSPM_GROUPSA_TO,
                                                   string FSPM_UNIT_RATE, string FSPM_SERVICE_RATE, string FSPM_PREMIUM_BREAKUP, string FSPM_POLICYLVL_COMM,
                                                   string FSPM_RENEWAL_ALLW, int FSPM_GRACE_PERIOD, int FSPM_GROUPLVL_COMM, int FSPM_MAXFAMILY_MEMB,
                                                   int FSPM_MAXCERTIFICATES, int FSPM_PERLIFE_SAVALID, int FSPM_MIN_COMMISSION, int FSPM_MAX_COMMISSION,
                                                   int FSPM_MIN_EXPERIENCE, int FSPM_MAX_EXPERIENCE, int FSPM_MIN_SVCFEE, int FSPM_MAX_SVCFEE,
                                                   int FSPM_MIN_WAKALAFEE, int FSPM_MAX_WAKALAFEE, string FSPM_STATUS, int FSPM_STATUS_USER,
                                                   DateTime FSPM_STATUS_DATE, DateTime FSPM_FLXFLD_DATE1, DateTime FSPM_FLXFLD_DATE2, string FSPM_FLXFLD_VCHAR1,
                                                   string FSPM_FLXFLD_VCHAR2, int FSPM_FLXFLD_NUMBER1, int FSPM_FLXFLD_NUMBER2, int FSPM_CRUSER,
                                                   DateTime FSPM_CRDATE, int FSPM_CHKUSER, DateTime FSPM_CHKDATE, int fspm_AUTHUSER,
                                                   DateTime FSPM_AUTHDATE, int FSPM_CNCLUSER, DateTime FSPM_CNCLDATE,string FSPM_STATU_FUND)
        {

            ProductMaster product = new();
            product.FSPM_PRODUCT_CODE = FSPM_PRODUCT_CODE;
            product.FSPM_PRODUCT_ID = FSPM_PRODUCT_ID;
            product.FSPM_PRODUCT_NAME = FSPM_PRODUCT_NAME;
            product.FSPM_PRODUCT_DESP = FSPM_PRODUCT_DESP;
            product.FSPM_PRODUCTION_LINE = FSPM_PRODUCTION_LINE;
            product.FSPM_PRODUCT_TYPE = FSPM_PRODUCT_TYPE;
            product.FSPM_PRODUCT_CATEG = FSPM_PRODUCT_CATEG;
            product.FSPM_PRODUCT_NATURE = FSPM_PRODUCT_NATURE;
            product.FSPM_PRODLIFE_FLAG = FSPM_PRODLIFE_FLAG;
            product.FSPM_PRODINDEX_TYPE = FSPM_PRODINDEX_TYPE;
            product.FSPM_1STAGEENT_MIN = FSPM_1STAGEENT_MIN;
            product.FSPM_1STAGEENT_MAX = FSPM_1STAGEENT_MAX;
            product.FSPM_2NDAGEENT_MIN = FSPM_2NDAGEENT_MIN;
            product.FSPM_2NDAGEENT_MAX = FSPM_2NDAGEENT_MAX;
            product.FSPM_1STAGEMAT_MIN = FSPM_1STAGEMAT_MIN;
            product.FSPM_1STAGEMAT_MAX = FSPM_1STAGEMAT_MAX;
            product.FSPM_2NDAGEMAT_MIN = FSPM_2NDAGEMAT_MIN;
            product.FSPM_2NDAGEMAT_MAX = FSPM_2NDAGEMAT_MAX;
            product.FSPM_SUMASSURD_MIN = FSPM_SUMASSURD_MIN;
            product.FSPM_SUMASSURD_MAX = FSPM_SUMASSURD_MAX;
            product.FSPM_BENEFTERM_MIN = FSPM_BENEFTERM_MIN;
            product.FSPM_BENEFTERM_MAX = FSPM_BENEFTERM_MAX;
            product.FSPM_PREMITERM_MIN = FSPM_PREMITERM_MIN;
            product.FSPM_PREMITERM_MAX = FSPM_PREMITERM_MAX;
            product.FSPM_NONSMOKER_YN = FSPM_NONSMOKER_YN;
            product.FSPM_FEMALEADJ_YN = FSPM_FEMALEADJ_YN;
            product.FSPM_INDXATION_YN = FSPM_INDXATION_YN;
            product.FSPM_CASHVALU_YN = FSPM_CASHVALU_YN;
            product.FSPM_TOPUPCONTRB_YN = FSPM_TOPUPCONTRB_YN;
            product.FSPM_LOAN_YN = FSPM_LOAN_YN;
            product.FSPM_PERSISTBONS_YN = FSPM_PERSISTBONS_YN;
            product.FSPM_START_DATE = FSPM_START_DATE;
            product.FSPM_END_DATE = FSPM_END_DATE;
            product.FSPM_GROUPSIZE_FROM = FSPM_GROUPSIZE_FROM;
            product.FSPM_GROUPSIZE_TO = FSPM_GROUPSIZE_TO;
            product.FSPM_GROUPSA_FROM = FSPM_GROUPSA_FROM;
            product.FSPM_GROUPSA_TO = FSPM_GROUPSA_TO;
            product.FSPM_UNIT_RATE = FSPM_UNIT_RATE;
            product.FSPM_SERVICE_RATE = FSPM_SERVICE_RATE;
            product.FSPM_PREMIUM_BREAKUP = FSPM_PREMIUM_BREAKUP;
            product.FSPM_POLICYLVL_COMM = FSPM_POLICYLVL_COMM;
            product.FSPM_RENEWAL_ALLW = FSPM_RENEWAL_ALLW;
            product.FSPM_GRACE_PERIOD = FSPM_GRACE_PERIOD;
            product.FSPM_GROUPLVL_COMM = FSPM_GROUPLVL_COMM;
            product.FSPM_MAXFAMILY_MEMB = FSPM_MAXFAMILY_MEMB;
            product.FSPM_MAXCERTIFICATES = FSPM_MAXCERTIFICATES;
            product.FSPM_PERLIFE_SAVALID = FSPM_PERLIFE_SAVALID;
            product.FSPM_MIN_COMMISSION = FSPM_MIN_COMMISSION;
            product.FSPM_MAX_COMMISSION = FSPM_MAX_COMMISSION;
            product.FSPM_MIN_EXPERIENCE = FSPM_MIN_EXPERIENCE;
            product.FSPM_MAX_EXPERIENCE = FSPM_MAX_EXPERIENCE;
            product.FSPM_MIN_SVCFEE = FSPM_MIN_SVCFEE;
            product.FSPM_MAX_SVCFEE = FSPM_MAX_SVCFEE;
            product.FSPM_MIN_WAKALAFEE = FSPM_MIN_WAKALAFEE;
            product.FSPM_MAX_WAKALAFEE = FSPM_MAX_WAKALAFEE;
            product.FSPM_STATUS = FSPM_STATUS;
            product.FSPM_STATUS_USER = FSPM_STATUS_USER;
            product.FSPM_STATUS_DATE = FSPM_STATUS_DATE;
            product.FSPM_FLXFLD_DATE1 = FSPM_FLXFLD_DATE1;
            product.FSPM_FLXFLD_DATE2 = FSPM_FLXFLD_DATE2;
            product.FSPM_FLXFLD_VCHAR1 = FSPM_FLXFLD_VCHAR1;
            product.FSPM_FLXFLD_VCHAR2 = FSPM_FLXFLD_VCHAR2;
            product.FSPM_FLXFLD_NUMBER1 = FSPM_FLXFLD_NUMBER1;
            product.FSPM_FLXFLD_NUMBER2 = FSPM_FLXFLD_NUMBER2;
            product.FSPM_CRUSER = FSPM_CRUSER;
            product.FSPM_CRDATE = FSPM_CRDATE;
            product.FSPM_CHKUSER = FSPM_CHKUSER;
            product.FSPM_CHKDATE = FSPM_CHKDATE;
            product.fspm_AUTHUSER = fspm_AUTHUSER;
            product.FSPM_AUTHDATE = FSPM_AUTHDATE;
            product.FSPM_CNCLUSER = FSPM_CNCLUSER;
            product.FSPM_CNCLDATE = FSPM_CNCLDATE;
            product.FSPM_STATU_FUND = FSPM_STATU_FUND;

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

                try
                {
                    if (product.FSPM_PRODUCT_ID == 0)
                    {
                        using (var response = await client.PostAsync(Add_Product, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["PostProduct"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    else if (product.FSPM_PRODUCT_ID != 0)
                    {
                        using (var response = await client.PostAsync(Updat_Product, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["PostProduct"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["PostProduct"] = ex.ToString();
                }
                return RedirectToAction("ProductMaster");
            }
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

