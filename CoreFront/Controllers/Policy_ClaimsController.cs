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
    public class Policy_ClaimsController : Controller
    {

        private readonly string Create_Claim = "http://"+Result_API+"/api/Agent/PostAgent";
        private readonly string Update_Claim = "http://"+Result_API+"/api/Agent/PutAgent";
              
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public Policy_ClaimsController(IConfiguration _configuration)
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

        StringContent SendRequest;
      
        public IActionResult Policy_Claims()
        {
            GetIPHostAPI();
            return View();
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

                        using (var response = await client1.PostAsync(Create_Claim, SendRequest))
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
                        using (var response = await client1.PostAsync(Update_Claim, SendRequest))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["successAgent"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    catch (Exception ed)
                    {
                        TempData["successAgent"] = ed.ToString();
                    }
                }
            }
            return RedirectToAction("Policy_Claims");
        }
    }
}

