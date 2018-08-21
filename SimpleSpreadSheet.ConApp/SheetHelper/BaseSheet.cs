using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSpreadSheet.ConApp.SheetHelper
{
    public abstract class BaseSheet
    {
        /// <summary>
        /// width  string of the sheet
        /// </summary>
        private string _wdith;
        /// <summary>
        /// height string of the sheet
        /// </summary>
        private string _height;
        /// <summary>
        /// Create a spreed sheet
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>return the output result</returns>
        public string InitSheet(int x, int y)
        {
            this._wdith = Utils.RepeatWidth("-", x);
            this._height = Utils.RepeatHeight("|", x, y, "");
            return string.Format("{0}{1}\r\n{0}", this._wdith, this._height);
        }
    }
}
