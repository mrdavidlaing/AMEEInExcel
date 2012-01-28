using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace AMEEInExcel
{
    public partial class MainRibbon
    {
        public static MainRibbon Instance;

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Instance = this;
            versionLabel.Label = ThisAddIn.Instance.Version; 
        }

        private void findButton_Click(object sender, RibbonControlEventArgs e)
        {
            var f = new AMEEdiscoverForm();
            f.ShowDialog();
        }
    }
}
