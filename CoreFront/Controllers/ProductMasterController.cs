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
    public class ProductMasterController : Controller
    {
        private readonly string Save_Product = "http://"+Result_API+"/api/Product/PostProduct";
        private readonly string Update_Product = "http://"+Result_API+"/api/Product/PutProduct";
      
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public ProductMasterController(IConfiguration _configuration)
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

        public IActionResult ProductMaster()
        {
            GetIPHostAPI();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrUpdateProduct(string FSPM_PRODUCT_CODE, int FSPM_PRODUCT_ID, string FSPM_PRODUCT_NAME, string FSPM_PRODUCT_DESP, string FSPM_PRODUCTION_LINE,
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
                                                            DateTime FSPM_AUTHDATE, int FSPM_CNCLUSER, DateTime FSPM_CNCLDATE, string FSPM_STATU_FUND)
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
                        using (var response = await client.PostAsync(Save_Product, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["ProductMaster"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                    else if (product.FSPM_PRODUCT_ID != 0)
                    {
                        using (var response = await client.PostAsync(Update_Product, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["ProductMaster"] = " " + apiResponse.Replace('"', ' ').Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["ProductMaster"] = ex.ToString();
                }
                return RedirectToAction("ProductMaster");
            }
        }
    }
}

