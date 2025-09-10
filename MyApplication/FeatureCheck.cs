using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace MyApplication
{
    class FeatureCheck
    {
        public SldWorks sldworks = new SldWorks();

        public void checkFeat()
        {
            ModelDoc2 Model = (ModelDoc2)sldworks.ActiveDoc;
            Feature feat = (Feature)Model.FirstFeature();
            while (feat != null)

            {
                MessageBox.Show(feat.GetTypeName2());
                if (feat.GetTypeName2() == "Extrusion")
                {
                    MessageBox.Show("Extrude feature found.");
                    FeatureExtrude featExtrude = new FeatureExtrude();
                    featExtrude.extrude(feat.Name);
                }
                else if (feat.GetTypeName2() == "ICE")
                {
                    MessageBox.Show("Imported feature found.");
                }
                feat = (Feature)feat.GetNextFeature();

            }
            
        }
    }
}
