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
    public class CustomerController : Controller
    {
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

        private readonly string Update_CustSMP = "http://"+Result_API+"/api/Customer/PutSocialMediaProfile";
        private readonly string Add_CustSMP = "http://"+Result_API+"/api/Customer/PostSocialMediaProfile";
              
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public CustomerController(IConfiguration _configuration)
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
        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Customer()
        {
            GetIPHostAPI();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrUpdateCustomer(int FSCU_CUSTOMER_CODE, int FSNT_IDENTYPE_ID, string FSCU_IDENTIFICATION_NO, DateTime FSCU_IDENTISSUE_DATE,
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
                        else if (FSCF_MEMBER_STATUS[iFh] == "2")
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
    }
}

