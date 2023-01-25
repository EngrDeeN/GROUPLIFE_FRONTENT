using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class QuotationProcess
    {
        public int FPQP_QUOTATPLAN_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public string FGQH_QUOTATHDR_CODE { get; set; }
        public string FGQH_QUOTATION_CONFIRM { get; set; }
        public int FPQP_WAKALA_PERC { get; set; }
        public int FPQP_GROSSPREMIUM { get; set; }
        public int FPQP_NETPREMIUM { get; set; }
        public int FPQP_SUMASSURED { get; set; }
        public int FPQP_SERVICETAX { get; set; }
        public int FPQP_DISCOUNT_AMT { get; set; }
        public int FPQP_CHARGES_AMT { get; set; }
        public int FPQP_OTHER_AMT { get; set; }
        public string FPQP_OTHER_DESCR { get; set; }
        public string FPQP_STATUS { get; set; }
        public int FPQP_CRUSER { get; set; }
        public DateTime FPQP_CRDATE { get; set; }
        public string FGQH_WITHRCPT_YN { get; set; }
       


    }
}
