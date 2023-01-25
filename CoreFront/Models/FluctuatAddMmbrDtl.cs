using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class FluctuatAddMmbrDtl
    {

        public string FGBU_CUST_CNIC { get; set; }
        public string FGPH_POLICY_NO { get; set; }
        public int FGBU_POL_COVGE_SUMASSURD { get; set; }
        public int FUPF_LOADING_AMTPERC { get; set; }
        public string FUPF_LOADING_TYP { get; set; }
        public DateTime FGBU_POL_COVGE_STDATE { get; set; }
        public DateTime FGBU_POL_COVGE_EDDATE { get; set; }
        public int FGBU_BATCH_ID { get; set; }
        //public string FGBU_CUST_CATEGORY { get; set; }
    }
}
