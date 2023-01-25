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
    public class InstitutionController : Controller
    {

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
      
        IConfiguration configuration;
        static string Result_API = "", IP_Address = "", Port_No = "";
        public InstitutionController(IConfiguration _configuration)
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

        public IActionResult Institution()
        {
            GetIPHostAPI();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrUpdateInstitution(  int FSSI_INSTITUTE_ID, int FSIT_INSTITYP_ID, string FSSI_CATEGORY_CODE, string FSSI_OCCUP_INDSTRY_TYPE, string FSSI_COMP_SECTOR_TYPE, string FSSI_SHORT_CODE, string FSSI_DESCRIPTION,
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
    }
}

