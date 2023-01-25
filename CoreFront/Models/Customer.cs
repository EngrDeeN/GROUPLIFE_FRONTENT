using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class Customer
    {
        public int FSCU_CUSTOMER_CODE { get; set; }
        public int FSNT_IDENTYPE_ID { get; set; }
        public string FSCU_IDENTIFICATION_NO { get; set; }
        public DateTime FSCU_IDENTISSUE_DATE { get; set; }
        public DateTime FSCU_IDENTIEXPIRY_DATE { get; set; }
        public int FSCU_GROUP_CODE { get; set; }
        public string FSCU_FAMILY_ID { get; set; }
        public int FSCU_CLIENT_TYPE { get; set; }
        public int FSCU_TITLE_FSCD_DID { get; set; }
        public string FSCU_FULL_NAME { get; set; }
        public string FSCU_FIRST_NAME { get; set; }
        public string FSCU_MIDDLE_NAME { get; set; }
        public string FSCU_LAST_NAME { get; set; }
        public string FSCU_FATHUSB_NAME { get; set; }
        public string FSCU_MOTHER_NAME { get; set; }
        public int FSCU_RELTN_FSCD_DID { get; set; }
        public int FSCU_GENDR_FSCD_DID { get; set; }
        public int FSCU_MRTST_FSCD_DID { get; set; }
        public int FSCU_NOOFDEPENDENTS { get; set; }
        public int FSCU_CUOCP_FSCD_DID { get; set; }
        public int FSCU_WORKEXP_YEARS { get; set; }
        public DateTime FSCU_DATEOFBIRTH { get; set; }
        public int FSCU_BIRTH_COUNTRY { get; set; }
        public int FSCU_IDENTIFICTYPE2 { get; set; }
        public string FSCU_IDENTIFICATION_NO2 { get; set; }
        public DateTime FSCU_IDENTISSUE_DATE2 { get; set; }
        public DateTime FSCU_IDENTIEXPIRY_DATE2 { get; set; }
        public string FSCU_NTN_NUMBER { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public string FSCU_DUAL_NATIONAL_YN { get; set; }
        public int FSCU_RELGN_FSCD_DID { get; set; }
        public int FSCU_RACES_FSCD_DID { get; set; }
        public string FSCU_VIP_CUSTOMER_YN { get; set; }
        public string FSCU_EXIST_CUST_YN { get; set; }
        public string FSCU_WORKING_CUST_YN { get; set; }
        public string FSCU_AGE_ADMITTED_YN { get; set; }
        public string FSCU_CUST_ALIVE_YN { get; set; }
        public DateTime FSCU_CUST_DEATH_DATE { get; set; }
        public string FSCU_CUST_SMOKER_YN { get; set; }
        public string FSCU_CUST_DRINKER_YN { get; set; }
        public string FSCU_CUST_CORRADDR { get; set; }
        public string FSCU_AML_RISK_TYPE { get; set; }
        public decimal FSCU_CUST_HEIGHT { get; set; }
        public int FSCU_MSUNT_HEIT_FSCD_DID { get; set; }
        public decimal FSCU_CUST_WEIGHT { get; set; }
        public int FSCU_MSUNT_WEIT_FSCD_DID { get; set; }
        public decimal FSCU_CUST_BMI { get; set; }
        public string FSCU_CUST_TAX_EXEMPT_YN { get; set; }
        public string FSCU_CUST_POLICY_ISSU_YN { get; set; }
        public int FSCU_CUST_SAR { get; set; }
        public int FSCU_CUST_ANNUAL_INCOME { get; set; }
        public int FSCR_CURRENCY_CODE { get; set; }
        public string FSCU_CUST_ISEMPLOYEE_YN { get; set; }
        public string FSCU_CUST_EMPLOYEE_CODE { get; set; }
        public string FSCU_CUST_WEBSITE_ADDR { get; set; }
        public string FSCU_CUST_STATUS { get; set; }
        public int FSCU_CRUSER { get; set; }
        public DateTime FSCU_CRDATE { get; set; }

    }
}
