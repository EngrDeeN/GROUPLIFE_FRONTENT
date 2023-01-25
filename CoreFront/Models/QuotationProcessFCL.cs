using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class QuotationProcessFCL
    {
        
        public int FPQF_QUOTFCL_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FSPF_PRODFCL_ID { get; set; }
        public string FPQF_SYSUSR_FCL_FLAG { get; set; }
        public int FPQF_USER_FCL_AMT { get; set; }
        public int FPQF_SYS_FCL_AMT { get; set; }
        public string FPQF_STATUS { get; set; }
        public int FPQF_CRUSER { get; set; }
        public bool CheckUserFCLAMT { get; set; }



    }
}
