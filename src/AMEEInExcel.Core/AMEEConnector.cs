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
        private const string AmeeUrl = "https://stage.amee.com";
        private const string AmeeUserName = "jsonclient";
        private const string AmeePassword = "bktnkaq4";

        public DataItemResponse GetDataItem(string path, string uid)
        {
            var client = new Client(new Uri(AmeeUrl), AmeeUserName, AmeePassword);

            return client.GetDataItem(path, uid);
        }


        // transport/defra/passenger/flight
        // transport/defra/route 
        // transport/defra/vehicle
        // transport/defra/vehicle/class
        // transport/defra/vehicle/hgv
        // transport/defra/fuel
        // transport/defra/passenger

        /// <summary>
        /// http://www.amee.com/developer/docs/ch03.php
        /// 
        /// </summary>
        /// <param name="path"></param>
        public CalculateResponse GetEmissionFactors(string path)
        {
            var client = new Client(new Uri(AmeeUrl), AmeeUserName, AmeePassword);

            // Performing Drilldowns 

            // get choices for transport/defra/fuel
            DrillDownResponse r = client.GetDrillDown(path);

            // drill down to petrol
            var choice = r.Choices.Choices.FirstOrDefault(c => c.Name == "petrol");

            var selectionName = r.Choices.Name;
            var selection = new ValueItem(selectionName, choice.Name);

            // get the uid for petrol
            r = client.GetDrillDown(path, selection);

            // this is the end of this drilldown hierarchy. if more levels existed we would repeat previous step
            // but in this case, the choices will be 'uid' with a single value that we use to get a data item
//            Assert.AreEqual("uid", r.Choices.Name);
//            Assert.AreEqual(1, r.Choices.Choices.Count);

            choice = r.Choices.Choices[0];

            // Fetching Data Items 

            // use the uid to fetch the data item
            // (appears that the choice 'name' is the value to use and, when present, 'value' echoes 'name')

            DataItemResponse item = client.GetDataItem(path, choice.Name);

            // go ahead and hover item and explore. have yet to determine different response formats for different paths but DataItemResponse 
            // seems to cover this path

            // Do Calculation
            var profile = client.CreateProfile();

            var calc = client.Calculate(profile.Profile.Uid, path, new ValueItem("dataItemUid", item.DataItem.Uid), new ValueItem("volume", "500"), new ValueItem("representation", "full"));

            return calc;
        }
    }
}
