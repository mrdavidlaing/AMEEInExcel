using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMEEClient;
using AMEEClient.CS.Model;
using AMEEClient.Model;

namespace AMEEInExcel.Core
{
    public class AMEEConnector
    {
        private Client _client;
        private const string AmeeUrl = "https://stage.amee.com";
        private const string AmeeUserName = "jsonclient";
        private const string AmeePassword = "bktnkaq4";

        public AMEEConnector()
        {
            _client = new Client(new Uri(AmeeUrl), AmeeUserName, AmeePassword);
        }

        public string GetDataItemLabel(string path, string uid)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            return dataItemResponse.DataItem.Label;
        }

        public string GetDataItemValue(string path, string uid, string valuePath)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            var dataItemValue = dataItemResponse.DataItem.ItemValues.First(v => v.ItemValueDefinition.Path == valuePath).Value;
            return dataItemValue;
        }

        public string Calculate(string path, string uid, string amountType, string argName, string argValue)
        {
            var dataItemResponse = _client.Calculate(path, uid, new ValueItem(argName, argValue));
            var dataItemValue = dataItemResponse.Amounts.Amount.First(a => a.Type == amountType).Value;
            return dataItemValue;
        }

    }
}
