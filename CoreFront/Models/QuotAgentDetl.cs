using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class QuotAgentDetl
    {
        public int FGQA_COMPAGNT_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FSAG_AGENT_CODE { get; set; }
        public int FSLO_LOCATION_ID { get; set; }
        public int FGQA_COMMISSION_PERCENT { get; set; }
        public int FGQA_CHNLS_FSCD_DID { get; set; }
        public string FGQA_STATUS { get; set; }
        public DateTime FGQA_FLXFLD_DATE1 { get; set; }
        public DateTime FGQA_FLXFLD_DATE2 { get; set; }
        public string FGQA_FLXFLD_VCHAR1 { get; set; }
        public string FGQA_FLXFLD_VCHAR2 { get; set; }
        public int FGQA_FLXFLD_NUMBER1 { get; set; }
        public int FGQA_FLXFLD_NUMBER2 { get; set; }
        public int FGQA_CRUSER { get; set; }
        public DateTime FGQA_CRDATE { get; set; }
        public int FGQA_CHKUSER { get; set; }
        public DateTime FGQA_CHKDATE { get; set; }
        public int FGQA_AUTHUSER { get; set; }
        public DateTime FGQA_AUTHDATE { get; set; }
        public int FGQA_CNCLUSER { get; set; }
        public DateTime FGQA_CNCLDATE { get; set; }
        public string FGQA_AUDIT_COMMENTS { get; set; }
        public string FGQA_USER_IPADDR { get; set; }
        public int FGQA_WAKALA_ONPREM { get; set; }

    }
}
