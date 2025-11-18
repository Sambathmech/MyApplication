using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace MyApplication
{
    public class DocChecker
    {
        // Create a SolidWorks application instance
        public SldWorks sldWorks = new SldWorks();
        
        public void currentDocument()
        {
            // check the type of the current document
            ModelDoc2 Model = (ModelDoc2)sldWorks.ActiveDoc;
            if (Model != null)
            {
                int doc = Model.GetType();
                switch (doc)
                {
                    case 1:
                        // Part
                        Console.WriteLine("Current document is a Part.");
                        sqlcon sqlCon = new sqlcon();
                       string partName = Model.GetTitle();
                        //MessageBox.Show(partName);


                        // Connect to the database named after the part
                        sqlCon.connection(partName);
                        //create the instance for FeatureCheck class
                        FeatureCheck featureCheck = new FeatureCheck();
                        featureCheck.checkFeat();
                        featureCheck.TableCreation();
                        break;
                    case 2:
                        // Assembly
                        Console.WriteLine("Current document is an Assembly.");
                        break;
                    case 3:
                        // Drawing
                        Console.WriteLine("Current document is a Drawing.");
                        break;
                    default:
                        Console.WriteLine("Unknown document type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No active document.");
            }
        }
    }
}
