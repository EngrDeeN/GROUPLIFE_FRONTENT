using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class Quotation_Event
    {
        public int FGQE_QUOTEVNT_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FSCE_COVREVENT_ID { get; set; }
        public DateTime FGQE_EVENTST_DATE { get; set; }
        public DateTime FGQE_EVENTEN_DATE { get; set; }
        public int FGQE_PFREQ_FSCD_DID { get; set; }
        public string FGQE_PAYBLE_FLAG { get; set; }
        public int FGQE_EVNT_CONTRIB { get; set; }
        public int FGQE_EVNT_LOADING { get; set; }
        public int FGQE_NET_CONTRIB { get; set; }
        public int FGQE_OTH_AMOUNT { get; set; }
        public int FGQE_MISC_AMOUNT { get; set; }
        public string FGQE_STATUS { get; set; }
        public int FGQE_CRUSER { get; set; }
        public DateTime FGQE_CRDATE { get; set; }
        public int _FGQG_COMPGRP_ID { get; set; }
        

    }
}
