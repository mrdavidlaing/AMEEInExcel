using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;

namespace AMEEInExcel
{
    public static class Udf
    {
        [ExcelFunction(Category="AMEE", Description = "Get AMEE DataItem")]
        public static object DATAITEM(string path, string uid)
        {
            try
            {
                var defaultValue = string.Format("{0}->{1}", path, uid);
                var workbookName = GetCallingWorkbookName();

                var res = UdfDispatcher.Get().GetDataItem(workbookName, path, uid);
                return res ?? defaultValue;
            }
            catch (Exception exc)
            {
                UdfDispatcher.Log(exc);
                return exc.Message;
            }
        }

        static string CallingSheetName()
        {
            var tmp = XlCall.Excel(XlCall.xlfCaller);
            var caller = tmp as ExcelReference;
            if (caller == null)
                throw new ApplicationException("No calling worksheet found");
            var res = XlCall.Excel(XlCall.xlSheetNm, caller);
            return (string)res;
        }

        private static string GetCallingWorkbookName()
        {
            var sheetName = CallingSheetName();
            var parts = sheetName.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new ApplicationException();
            return parts[0];
        }
    }
}
