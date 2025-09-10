using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace MyApplication
{
    class FeatureExtrude
    {
        public SldWorks swApp = new SldWorks();
     public sqlcon sqlCon = new sqlcon();
        public double depth { get; set; }
        public string featName { get; set; }


        public void extrude(string message)
        {
            ModelDoc2 Model = (ModelDoc2)swApp.ActiveDoc;
            PartDoc part = (PartDoc)Model;
            Feature feature = (Feature)part.FeatureByName(message);

            MessageBox.Show("Extrusion Activatedxxx");
            ExtrudeFeatureData2 feat = (ExtrudeFeatureData2)feature.GetDefinition();
                 featName = feature.Name;
                 depth = feat.GetDepth(true);
            MessageBox.Show($"Feature Name: {featName}, Depth: {depth}");
            sqlCon.createTable();




        }
    }
}
