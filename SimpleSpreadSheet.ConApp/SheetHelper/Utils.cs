using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSpreadSheet.ConApp.SheetHelper
{
    /// <summary>
    /// common utils
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// repeat width string by num
        /// </summary>
        /// <param name="str"></param>
        /// <param name="repeatNum"></param>
        /// <returns></returns>
        public static string RepeatWidth(string str, int repeatNum)
        {
            string newStr = "";
            for (int i = 0; i < repeatNum; i++)
            {
                newStr += str;
            }
            return newStr;
        }

        /// <summary>
        /// repeat height string by num
        /// </summary>
        /// <param name="str"></param>
        /// <param name="repeatNum"></param>
        /// <returns></returns>
        public static string RepeatHeight(string str, int repeatX, int repeatY, string input)
        {
            string tempStr = string.Format("\r\n{0}{1}{0}", str, RepeatWidth(" ", repeatX - 2));
            string newStr = string.Empty;
            for (int i = 0; i < repeatY; i++)
            {
                newStr += tempStr;
            }
            return newStr;
        }
        /// <summary>
        /// Calculate new output
        /// </summary>
        /// <param name="str"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static string CalculateNewOutPut(string str, int x, int y, int z)
        {
            string[] arr = str.Split("\r\n");
            if (arr.Length < 3 || arr.Length - 2 < y)
            {
                return "invalidate input , your row num must be validate";
            }
            string lineFirst = arr[0];
            if (x * 3 > lineFirst.Length - 2)
            {
                return "invalidate input , your col num must be validate";
            }
            string targetLine = arr[y];
            string targetEndStr = targetLine.Substring(x * 3 + 1);
            targetLine = targetLine.Substring(1, x * 3);
            if (z < 10)
            {
                targetLine = targetLine.Substring(1, targetLine.Length - 1) + z;
            }
            else if (z >= 10 && z <= 99)
            {
                targetLine = targetLine.Substring(1, targetLine.Length - 2) + z;
            }
            else
            {
                targetLine = targetLine.Substring(1, targetLine.Length - 3) + z;
            }
            arr[y] = "|" + targetLine + targetEndStr;
            return string.Join("\r\n", arr);
        }
        /// <summary>
        /// calculate the sum
        /// </summary>
        /// <param name="str"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string CalculateSumOutPut(string str, int[] arrData)
        {
            if (arrData.Length < 4 || arrData.Length % 2 != 0)
            {
                return "invalidate sum input , eg: S 1 2 1 3 1 4";
            }
            string newStr = string.Empty;
            int sum = 0;
            string[] arr = str.Split("\r\n");
            if (arr.Length < arrData.Length / 2)
            {
                return "invalidate input , your row num must be validate";
            }
            int x = 0, y = 0;
            string lineFirst = arr[0];
            for (int i = 0; i < arrData.Length; i += 2)
            {
                x = Convert.ToInt32(arrData[i]);
                y = Convert.ToInt32(arrData[i + 1]);
                if (i == arrData.Length - 2)
                {
                    newStr = CalculateNewOutPut(str, x, y, sum);
                    break;
                }
                string temp = arr[y];
                sum += Convert.ToInt32(temp.Substring(3 * (x - 1) + 1, 3 * x));
            }
            return newStr;
        }
    }
}
