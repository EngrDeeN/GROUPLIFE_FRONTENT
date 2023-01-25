using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class ProductMaster
    {
        public int FSPM_PRODUCT_ID { get; set; }
        public string FSPM_PRODUCT_CODE { get; set; }
        public string FSPM_PRODUCT_NAME { get; set; }
        public string FSPM_PRODUCT_DESP { get; set; }
        public string FSPM_PRODUCTION_LINE { get; set; }
        public int FSPM_PRODUCT_TYPE { get; set; }
        public string FSPM_PRODUCT_CATEG { get; set; }
        public string FSPM_PRODUCT_NATURE { get; set; }
        public string FSPM_PRODLIFE_FLAG { get; set; }
        public string FSPM_PRODINDEX_TYPE { get; set; }
        public string FSPM_PRODINTREST_YN { get; set; }
        public int FSPM_1STAGEENT_MIN { get; set; }
        public int FSPM_1STAGEENT_MAX { get; set; }
        public int FSPM_2NDAGEENT_MIN { get; set; }
        public int FSPM_2NDAGEENT_MAX { get; set; }
        public int FSPM_1STAGEMAT_MIN { get; set; }
        public int FSPM_1STAGEMAT_MAX { get; set; }
        public int FSPM_2NDAGEMAT_MIN { get; set; }
        public int FSPM_2NDAGEMAT_MAX { get; set; }
        public int FSPM_SUMASSURD_MIN { get; set; }
        public int FSPM_SUMASSURD_MAX { get; set; }
        public int FSPM_BENEFTERM_MIN { get; set; }
        public int FSPM_BENEFTERM_MAX { get; set; }
        public int FSPM_PREMITERM_MIN { get; set; }
        public int FSPM_PREMITERM_MAX { get; set; }
        public string FSPM_NONSMOKER_YN { get; set; }
        public string FSPM_FEMALEADJ_YN { get; set; }
        public string FSPM_INDXATION_YN { get; set; }
        public string FSPM_CASHVALU_YN { get; set; }
        public string FSPM_TOPUPCONTRB_YN { get; set; }
        public string FSPM_LOAN_YN { get; set; }
        public string FSPM_PERSISTBONS_YN { get; set; }
        public DateTime FSPM_START_DATE { get; set; }
        public DateTime FSPM_END_DATE { get; set; }
        public int FSPM_GROUPSIZE_FROM { get; set; }
        public int FSPM_GROUPSIZE_TO { get; set; }
        public int FSPM_GROUPSA_FROM { get; set; }
        public int FSPM_GROUPSA_TO { get; set; }
        public string FSPM_UNIT_RATE { get; set; }
        public string FSPM_SERVICE_RATE { get; set; }
        public string FSPM_PREMIUM_BREAKUP { get; set; }
        public string FSPM_POLICYLVL_COMM { get; set; }
        public string FSPM_RENEWAL_ALLW { get; set; }
        public int FSPM_GRACE_PERIOD { get; set; }
        public int FSPM_GROUPLVL_COMM { get; set; }
        public int FSPM_MAXFAMILY_MEMB { get; set; }
        public int FSPM_MAXCERTIFICATES { get; set; }
        public int FSPM_PERLIFE_SAVALID { get; set; }
        public int FSPM_MIN_COMMISSION { get; set; }
        public int FSPM_MAX_COMMISSION { get; set; }
        public int FSPM_MIN_EXPERIENCE { get; set; }
        public int FSPM_MAX_EXPERIENCE { get; set; }
        public int FSPM_MIN_SVCFEE { get; set; }
        public int FSPM_MAX_SVCFEE { get; set; }
        public int FSPM_MIN_WAKALAFEE { get; set; }
        public int FSPM_MAX_WAKALAFEE { get; set; }
        public string FSPM_STATUS { get; set; }
        public int FSPM_STATUS_USER { get; set; }
        public DateTime FSPM_STATUS_DATE { get; set; }
        public DateTime FSPM_FLXFLD_DATE1 { get; set; }
        public DateTime FSPM_FLXFLD_DATE2 { get; set; }
        public string FSPM_FLXFLD_VCHAR1 { get; set; }
        public string FSPM_FLXFLD_VCHAR2 { get; set; }
        public int FSPM_FLXFLD_NUMBER1 { get; set; }
        public int FSPM_FLXFLD_NUMBER2 { get; set; }
        public int FSPM_CRUSER { get; set; }
        public DateTime FSPM_CRDATE { get; set; }
        public int FSPM_CHKUSER { get; set; }
        public DateTime FSPM_CHKDATE { get; set; }
        public int fspm_AUTHUSER { get; set; }
        public DateTime FSPM_AUTHDATE { get; set; }
        public int FSPM_CNCLUSER { get; set; }
        public DateTime FSPM_CNCLDATE { get; set; }
        public string FSPM_STATU_FUND { get; set; }

    }
}
