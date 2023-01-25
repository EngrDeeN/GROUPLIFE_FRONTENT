using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class QuotationHDR
    {
        public int FGQH_QUOTATHDR_ID { get; set; }
        public string FGQH_QUOTATHDR_CODE { get; set; }
        public int FGQH_PFREQ_FSCD_DID { get; set; }
        public DateTime FGQH_QUOTATION_DATE { get; set; }
        public DateTime FGQH_QUOTATION_REQDATE { get; set; }
        public DateTime FGQH_QUOTATION_EXPDATE { get; set; }
        public string FGQH_QUOTATION_CONFIRM { get; set; }
        public int FSPM_PRODUCT_ID { get; set; }
        public int FSLO_LOCATION_ID { get; set; }
        public int FSLO_LOCATION_ID2 { get; set; }
        public string FGQH_QUOTATION_INTRONAME { get; set; }
        public int FGQH_QUOTATION_TOTALEMP { get; set; }
        public int FGQH_QUOTATION_PEREMP { get; set; }
        public string FGQH_QUOTATION_CONTNAME { get; set; }
        public string FGQH_QUOTATION_PERSNAME { get; set; }
        public string FGQH_QUOTATION_SVCTAX_YN { get; set; }
        public int FGQH_QUOTATION_SVCTAX_PERC { get; set; }
        public int FSCR_CURRENCY_CODE { get; set; }
        public int FGQH_PYMET_FSCD_DID { get; set; }
        public int FGQH_QUOTATCOMP_TERM { get; set; }
        public DateTime FGQH_QUOTATCOMP_POLSTDATE { get; set; }
        public DateTime FGQH_QUOTATCOMP_POLENDATE { get; set; }
        public DateTime FGQH_QUOTATCOMP_AGECALCDT { get; set; }
        public string FGQH_QUOTATCOMP_FCLTKOVR_YN { get; set; }
        public DateTime FGQH_QUOTATCOMP_FCLTKOVR_DT { get; set; }
        public int FSLO_LOCATION_ID3 { get; set; }
        public int FSLO_LOCATION_ID4 { get; set; }
        public string FGQH_QUOTATCOMP_POLBKDATD_YN { get; set; }
        public DateTime FGQH_QUOTATCOMP_POLBAKDATE { get; set; }
        public string FGQH_REASON_BKDATE { get; set; }
        public string FGQH_QUOTATCOMP_HEADCOUNT_YN { get; set; }
        public string FGQH_QUOTATCOMP_HDCNT_CRTRIA { get; set; }
        public string FGQH_STATUS { get; set; }
        public int FGQH_STATUS_USER { get; set; }
        public int FGQH_CRUSER { get; set; }
        public DateTime FGQH_CRDATE { get; set; }
        public int NEW_GEN_QUOT_ID { get; set; }
        public float FGQH_WAKALA_PERC { get; set; }
        public string NEW_GEN_QUOT_CODE { get; set; }
        

    }
}
