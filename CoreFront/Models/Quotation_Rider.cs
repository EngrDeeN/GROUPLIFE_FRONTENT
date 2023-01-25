using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class Quotation_Rider
    {

        public int FGQR_QUOTRIDR_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FSPM_PRODUCT_ID { get; set; }
        public int FGQE_QUOTEVNT_ID { get; set; }
        public DateTime FGQR_RIDERST_DATE { get; set; }
        public DateTime FGQR_RIDEREN_DATE { get; set; }
        public int FGQR_PFREQ_FSCD_DID { get; set; }
        public string FGQR_PAYBLE_FLAG { get; set; }
        public string FGQR_LOADING_TYPE { get; set; }
        public int FGQR_LOADING_VALUE { get; set; }
        public int FGQR_RIDER_CONTRIB { get; set; }
        public int FGQR_NET_CONTRIB { get; set; }
        public string FGQR_STATUS { get; set; }
        public int FGQR_CRUSER { get; set; }
        public DateTime FGQR_CRDATE { get; set; }
        public int _FGQG_COMPGRP_ID { get; set; }

    }
}
