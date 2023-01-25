using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class AgentRegister
    {

        public int FSAG_AGENT_CODE { get; set; }
        public string FSAG_AGENT_NAME { get; set; }
        public string FSAG_AGENT_TYPE { get; set; }
        public int FSNT_IDENTYPE_ID { get; set; }
        public string FSAG_PRIMARY_IDENTITY_NO { get; set; }
        public DateTime FSAG_DATE_OF_JOINING { get; set; }
        public DateTime FSAG_DATE_OF_LEAVING { get; set; }
        public string FSAG_HAS_CAR_YN { get; set; }
        public string FSAG_SERVICE_STATUS { get; set; }
        public int FSAG_CHNLS_FSCD_DID { get; set; }
        public int FSHL_HIERCL_LEVEL_ID { get; set; }
        public string FSAG_SALARIED_YN { get; set; }
        public string FSAG_STAR_RATED_YN { get; set; }
        public string FSAG_STATUS { get; set; }
        public DateTime fsag_date_of_confirm { get; set; }
        public int fsbk_bank_id { get; set; }
        public string fsag_ba_account_no { get; set; }
        public string fsag_direct_agent_yn { get; set; }
        public int fsag_target_salary { get; set; }
        public int fsag_probation_period { get; set; }
        public int fsag_immedt_supvsr_code { get; set; }
        public int FSAG_CRUSER { get; set; }
        public string fsag_remarks { get; set; }

    }
}
