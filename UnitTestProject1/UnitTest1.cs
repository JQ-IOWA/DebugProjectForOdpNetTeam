using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      using (var context = new DaleContext())
      {
        var customer = context.CustomerGroups.Where(cg => cg.CUST_GROUP_IDFTN == 275 && cg.BookingBlocks.FirstOrDefault().RPTNG_FLOW_PATH_ID == 2).ToList();
        Assert.AreEqual(1, customer.Count);
      }
    }
  }
}
