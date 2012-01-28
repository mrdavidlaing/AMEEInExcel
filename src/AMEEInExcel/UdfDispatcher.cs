using System;
using System.Diagnostics;

namespace AMEEInExcel
{
    public class UdfDispatcher : MarshalByRefObject
    {
        private static UdfDispatcher _dispatcher;
//        private ILog _log;

        public object GetDataItem(string workbookName, string path, string uid)
        {
//            var handler = ThisAddIn.Instance.GetHandler(workbookName);
//            if (handler == null)
//                return null;
//            var res = handler.GetCurrentPrice(callerRange, marketId, property);
//            return res;
            return "TODO:- Make this work :)";
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