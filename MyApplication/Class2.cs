using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace MyApplication
{
    class sketchExtractor
    {
        public SldWorks swApp = new SldWorks();
        public void extractor(string message)
        {


            ModelDoc2 Model = (ModelDoc2)swApp.ActiveDoc;
            PartDoc part = (PartDoc)Model;
            Feature feature = (Feature)part.FeatureByName(message);
            object[] parents = feature.GetParents() as object[];
            if (parents != null)
            {

                foreach (object p in parents)
                {
                    Feature parentFeat = p as Feature;
                    if (parentFeat != null && parentFeat.GetTypeName2() == "ProfileFeature")
                    {
                       
                        Sketch sketch = parentFeat.GetSpecificFeature2() as Sketch;
                        MessageBox.Show(
                                                $"Extrude '{feature.Name}' uses Sketch '{parentFeat.Name}'"
                                            );

                        
                         int refType;
                        // object refEnt = sketch.GetReferenceEntity(out );
                        // if (refEnt is Feature planeFeat)
                        //System.Diagnostics.Debug.WriteLine($"   Sketch plane: {planeFeat.Name}");
                        // else if (refEnt is Face2)
                        // System.Diagnostics.Debug.WriteLine("   Sketch is on a face");
                    }
                }

            }
        }
    }
}
