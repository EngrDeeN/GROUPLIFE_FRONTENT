using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class CustomerMemberUpload
    {
        public int FGBU_UPLOAD_ID { get; set; }
        public int FGBU_CUST_CODE { get; set; }
        public string FGBU_CUST_TITLE { get; set; }
        public string FGBU_CUST_NAME { get; set; }
        public string FGBU_CUST_CNIC { get; set; }
        public string FGBU_CUST_PASSPORT { get; set; }
        public string FGBU_EMP_ID { get; set; }
        public string FGBU_EMP_NAME { get; set; }
        public string FGBU_EMP_DESIGN { get; set; }
        public int FGBU_EMP_AGE { get; set; }
        public string FGBU_EMP_RELATION { get; set; }
        public DateTime FGBU_CUST_DOB { get; set; }
        public string FGBU_CUST_GENDER { get; set; }
        public string FGBU_CUST_OCCUPATION { get; set; }
        public string FGBU_CUST_CATEGORY { get; set; }
        public int FGBU_EMP_SALARY { get; set; }
        public int FGBU_POL_COVGE_TERM { get; set; }
        public DateTime FGBU_POL_COVGE_STDATE { get; set; }
        public DateTime FGBU_POL_COVGE_EDDATE { get; set; }
        public int FGBU_POL_COVGE_SUMASSURD { get; set; }
        public string FGBU_INSTIT_HEADOFFICE { get; set; }
        public string FGBU_INSTIT_BRANCH { get; set; }
        public string FGBU_CUST_MOBILENO { get; set; }
        public string FGBU_CUST_EMAIL { get; set; }
        public string FGBU_CUST_FAMILYID { get; set; }
        public string FGBU_CUST_MARITALSTATUS { get; set; }
        public string FGBU_UPLOAD_STATUS { get; set; }
        public DateTime FGBU_FLXFLD_DATE { get; set; }
        public string FGBU_FLXFLD_VCHAR { get; set; }
        public int FGBU_FLXFLD_NUMBER { get; set; }
        public int FGBU_CRUSER { get; set; }
        public DateTime FGBU_CRDATE { get; set; }
        public int FGBU_CHKUSER { get; set; }
        public DateTime FGBU_CHKDATE { get; set; }
        public int FGBU_AUTHUSER { get; set; }
        public DateTime FGBU_AUTHDATE { get; set; }
        public int FGBU_CNCLUSER { get; set; }
        public DateTime FGBU_CNCLDATE { get; set; }
        public string FGBU_AUDIT_COMMENTS { get; set; }
        public string FGBU_USER_IPADDR { get; set; }
        public int FSSI_INSTITUTE_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
    }
}
