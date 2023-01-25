using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class Institution
    {
        
        public int FSSI_INSTITUTE_ID { get; set; }
        public int FSIT_INSTITYP_ID { get; set; }
        public string FSSI_CATEGORY_CODE { get; set; }
        public string FSSI_SHORT_CODE { get; set; }
        public string FSSI_DESCRIPTION { get; set; }
        public string FSSI_SHORT_DESCRIPTION { get; set; }
        public string FSSI_WEB_ADDRESS { get; set; }
        public string FSSI_REGISTRATION_NO { get; set; }
        public DateTime FSSI_REGISTRATION_DATE { get; set; }
        public string FSSI_NTN_NO { get; set; }
        public string FSSI_STRN_NO { get; set; }
        public DateTime FSSI_EFFECT_FROM_DATE { get; set; }
        public DateTime FSSI_EFFECT_TO_DATE { get; set; }
        public string FSSI_BANK_ROLE { get; set; }
        public int FSSI_BANK_COMMSN { get; set; }
        public string FSSI_STATUS { get; set; }
        public string FSSI_OCCUP_INDSTRY_TYPE { get; set; }
        public string FSSI_COMP_SECTOR_TYPE { get; set; }
        public int FSSI_CRUSER { get; set; }
        public DateTime FSSI_CRDATE { get; set; }
    }
}
