using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class Receipting
    {

        public string FTPR_RCPT_POSTD_YN { get; set; }
        public DateTime FTPR_RCPT_VALUDATE { get; set; }
        public string ftpr_rcpt_refno1 { get; set; }
        public int FTPR_RECEIPT_TYPE { get; set; }
        public int FTPR_PYMET_FSCD_DID { get; set; }
        public string FTPR_INSTR_NO { get; set; }
        public DateTime FTPR_INSTR_DATE{ get; set; }
        public int FSCR_CURRENCY_CODE { get; set; }
        public int FSBK_BANK_ID { get; set; }
        public string FTPR_INSTR_BNK_BRCHNAME { get; set; }
        public int FTPR_ACCOUNT_TYPE { get; set; }
        public string FTPR_ACCOUNT_TITLE { get; set; }
        public string FTPR_ACCOUNT_NO { get; set; }
        public int FTPR_COLL_AMOUNT { get; set; }
        public int FTPR_DUE_AMOUNT { get; set; }
        public int FTPR_APPROVD_AMT { get; set; }
        public int FTPR_CRUSER { get; set; }
        public DateTime FTPR_CRDATE { get; set; }
        public string FTPR_GLVOUCHR_NO { get; set; }

    }
}
