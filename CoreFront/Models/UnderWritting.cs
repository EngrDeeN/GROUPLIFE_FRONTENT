using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class UnderWritting
    {

        public string FGQH_QUOTATHDR_CODE { get; set; }
        public string IDENTIF_NO { get; set; }
        public string FSPM_PRODUCT_ID { get; set; }
        public string FUPF_BASRIDR_YN { get; set; }
        public int FUPF_UNDERWRT_ID { get; set; }
        public int FUPF_LOADING_TYPE { get; set; }
        public int FUPF_LOADING_AMT { get; set; }
        public int FUPF_NEWFCL_AMT { get; set; }
        public string FUPF_UNDW_DESCD { get; set; }
        public string FUPF_UNDW_DESREASN { get; set; }
        public DateTime FUPF_APPRV_DATE { get; set; }
        public string FUPF_CRUSER { get; set; }
        public string FUPF_SUBSTNDRD_YN { get; set; }
        public int FUPF_AGEUSR_RATE { get; set; }
        public string FUPF_AGEUSRAT_TYP { get; set; }       
        public DateTime FUPF_CRDATE { get; set; }

    }
}
