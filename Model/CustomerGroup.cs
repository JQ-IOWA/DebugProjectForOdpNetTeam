using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
  public class CustomerGroup
  {
    public CustomerGroup()
    {
      BookingBlocks = new List<BookingBlock>();
    }
    [Key]
    public int CUST_GROUP_IDFTN { get; set; }
    public string CUST_GROUP_NAME { get; set; }
    public string CUST_GROUP_DESC { get; set; }
    public string ENABLED_INDIC { get; set; }
    public string LAST_CHNGD_IDFTN { get; set; }
    public DateTime DATE_CRTD { get; set; }
    public DateTime DATE_LAST_CHNGD { get; set; }
    public List<BookingBlock> BookingBlocks { get; set; }
  }
}
