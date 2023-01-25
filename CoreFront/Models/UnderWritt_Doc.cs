using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class UnderWritt_Doc
    {
        public string FGQH_QUOTATHDR_CODE { get; set; }
        public string IDENTIF_NO { get; set; }
        public int FGPD_POLUNW_DOC_ID { get; set; }
        public string FGPD_UWDOC_FSCD_DID { get; set; }
        public DateTime FGPD_REQUEST_DATE { get; set; }
        public DateTime FGPD_RECEIVD_DATE { get; set; }
        public string FGPD_STATUS { get; set; }
        public string FGPD_CRUSER { get; set; }
        public DateTime FGPD_CRDATE { get; set; }
    }
}
