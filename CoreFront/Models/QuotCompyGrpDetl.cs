using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class QuotCompyGrpDetl
    {
        public int FGQG_COMPGRP_ID { get; set; }
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FGQH_QTGRC_FSCD_DID { get; set; }
        public int FGQG_PREMIUM { get; set; }
        public int FGQG_SUMASSRD_CRITRIA { get; set; }
        public int FGQG_NOOFSALARY_AMT { get; set; }
        public int FGQG_FIXED_AMOUNT { get; set; }
        public int FGQG_HEADCONT_TOTSALARY { get; set; }
        public string FGQG_STATUS { get; set; }
        public DateTime FGQG_FLXFLD_DATE1 { get; set; }
        public DateTime FGQG_FLXFLD_DATE2 { get; set; }
        public string FGQG_FLXFLD_VCHAR1 { get; set; }
        public string FGQG_FLXFLD_VCHAR2 { get; set; }
        public int FGQG_FLXFLD_NUMBER1 { get; set; }
        public int FGQG_FLXFLD_NUMBER2 { get; set; }
        public int FGQG_CRUSER { get; set; }
        public DateTime FGQG_CRDATE { get; set; }
        public int FGQG_CHKUSER { get; set; }
        public DateTime FGQG_CHKDATE { get; set; }
        public int FGQG_AUTHUSER { get; set; }
        public DateTime FGQG_AUTHDATE { get; set; }
        public int FGQG_CNCLUSER { get; set; }
        public DateTime FGQG_CNCLDATE { get; set; }
        public string FGQG_AUDIT_COMMENTS { get; set; }
        public string FGQG_USER_IPADDR { get; set; }
        public int FGQG_MIN_SUMASSURD { get; set; }
        public int FGQG_MAX_SUMASSURD { get; set; }
        public int FGQG_PER_FREQNCY { get; set; }

    }
}
