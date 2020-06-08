using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
  public class BookingBlock
  {
    public int RPTNG_FLOW_PATH_ID { get; set; }
    public int CUST_GROUP_IDFTN { get; set; }
    public int BLOCK_MIN_LEAD_TIME { get; set; }
    public int BLOCK_BKNG_WEEKS { get; set; }
    public string ENABLED_INDIC { get; set; }
    public int SORT_SEQ { get; set; }
    public string LAST_CHNGD_IDFTN { get; set; }
    public DateTime DATE_CRTD { get; set; }
    public DateTime DATE_LAST_CHNGD { get; set; }

   //public CustomerGroup CustomerGroup { get; set; }
  }
}
