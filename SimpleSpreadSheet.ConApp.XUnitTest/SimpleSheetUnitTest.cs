using System;
using Xunit;
using SimpleSpreadSheet.ConApp.SheetHelper;
using System.Linq;
namespace SimpleSpreadSheet.ConApp.XUnitTest
{
    /// <summary>
    /// Unit test for simple spread sheet
    /// </summary>
    public class SimpleSheetUnitTest
    {
        [Fact]
        public void TestSimpleSheet()
        {
            SimpleSheet simpleSheet = new SimpleSheet();
            string str = simpleSheet.InitSheet(20, 4);
            Assert.NotNull(str);
            Assert.StartsWith("-", str);

            string ret = Utils.CalculateNewOutPut(str, 1, 2, 2);
            Assert.NotNull(ret);
            Assert.StartsWith("-", ret);
            Assert.True(ret.Contains("2"));

            ret = Utils.CalculateNewOutPut(ret, 1, 3, 4);
            Assert.NotNull(ret);
            Assert.StartsWith("-", ret);
            Assert.True(ret.Contains("2"));
            Assert.True(ret.Contains("4"));

            ret = Utils.CalculateSumOutPut(ret, new int[] { 1, 2, 1, 3, 1, 4 });
            Assert.NotNull(ret);
            Assert.StartsWith("-", ret);
            Assert.True(ret.Contains("2"));
            Assert.True(ret.Contains("4"));
            Assert.True(ret.Contains("6"));
        }
    }
}
