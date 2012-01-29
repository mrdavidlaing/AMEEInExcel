using System;
using System.Diagnostics;
using AMEEInExcel.Core;

namespace AMEEInExcel
{
    public class UdfDispatcher : MarshalByRefObject
    {
        private static UdfDispatcher _dispatcher;
        private static AMEEConnector _ameeConnector = new AMEEConnector();
//        private ILog _log;

        public object GetDataItem(string workbookName, string path, string uid)
        {
            return _ameeConnector.GetDataItem(path, uid);
        }

        public string GetDataItemLabel(string workbookName, string path, string uid)
        {
            return _ameeConnector.GetDataItemLabel(path, uid);
        }

        public string GetDataItemValue(string workbookName, string path, string uid, string valuePath)
        {
            return _ameeConnector.GetDataItemValue(path, uid, valuePath);
        }

        public object Calculate(string workbookName, string path, string dataItemUid, string volume, string representation)
        {
            return _ameeConnector.Calculate(path, dataItemUid, volume, representation);
        }

      
        // call this method from the UDF appdomain only
        public static UdfDispatcher Get()
        {
            EnsureInit();
            return _dispatcher;
        }

        public static void Log(Exception exc)
        {
            try
            {
                UdfDispatcher dispatcher = Get();
                dispatcher.LogLocal(ToSerializable(exc));
            }
            catch (Exception exc2)
            {
                Trace.WriteLine(exc.ToString());
                Trace.WriteLine(exc2.ToString());
            }
        }

        // call from the master domain only
        private void LogLocal(Exception exc)
        {
            try
            {
//                if (_log == null)
//                    _log = LogManager.GetLogger(GetType());
//                _log.Error(exc);
            }
            catch (Exception exc2)
            {
                Trace.WriteLine(exc.ToString());
                Trace.WriteLine(exc2.ToString());
            }
        }

        private static void EnsureInit()
        {
            if (_dispatcher == null)
                _dispatcher = CrossDomain.CreateInMasterDomain<UdfDispatcher>();
        }

        private static Exception ToSerializable(Exception exc)
        {
            if (exc.GetType().IsSerializable)
                return exc;
            else
                return new ApplicationException(exc.Message, new Exception(exc.ToString()));
        }

        // remote references to this object never expire
        public override object InitializeLifetimeService()
        {
            return null;
        }

        // this object lives in the master appdomain
    }
}