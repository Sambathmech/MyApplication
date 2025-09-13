using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace MyApplication
{
    class FeatureCheck
    {
        public SldWorks sldworks = new SldWorks();
        public sqlcon myCon = new sqlcon();

        public void checkFeat()
        {
            ModelDoc2 Model = (ModelDoc2)sldworks.ActiveDoc;
            Feature feat = (Feature)Model.FirstFeature();
            string createfeaturetable = $"CREATE TABLE IF NOT EXISTS FeatureList(Id INTEGER PRIMARY KEY AUTOINCREMENT , FeatureName STRING)";
            myCon.createTable(createfeaturetable);

            // Creating feature list in DATABASE
            while (feat != null)

            {

                if (feat.GetTypeName2() != "CommentsFolder"&&
                    feat.GetTypeName2() != "FavoriteFolder"&&
                    feat.GetTypeName2() !="HistoryFolder"&&
                    feat.GetTypeName2() !="SelectionSetFolder"&&
                    feat.GetTypeName2() !="SensorFolder"&&
                    feat.GetTypeName2() !="DocsFolder"&&
                    feat.GetTypeName2() !="DetailCabinet"&&
                    feat.GetTypeName2() !="SurfaceBodyFolder"&&
                    feat.GetTypeName2() !="SolidBodyFolder"&&
                    feat.GetTypeName2() !="EnvFolder"&&
                    feat.GetTypeName2() !="InkMarkupFolder"&&
                    feat.GetTypeName2() !="EqnFolder"&&
                    feat.GetTypeName2() !="MaterialFolder"&&
                    feat.GetTypeName2() !="RefPlane"&&
                    feat.GetTypeName2() !="OriginProfileFeature")
                {
                    MessageBox.Show(feat.GetTypeName2());
                    string insertTable = $"INSERT INTO FeatureList(FeatureName) VALUES('{feat.GetTypeName2()}')";
                    MessageBox.Show(insertTable);
                    myCon.insertvalue(insertTable);
                }




                feat = (Feature)feat.GetNextFeature();
            }
        }





        public void TableCreation() 
        {
            ModelDoc2 Model = (ModelDoc2)sldworks.ActiveDoc;
            Feature feat = (Feature)Model.FirstFeature();
            while (feat != null)

            {
                
                if (feat.GetTypeName2() == "Extrusion" || feat.GetTypeName2() == "ExtruThin" || feat.GetTypeName2() == "ICE")
                {
                    MessageBox.Show("Extrude feature found.");
                    string createTable = $"CREATE TABLE IF NOT EXISTS[Extrude](Id INTEGER PRIMARY KEY AUTOINCREMENT,FeatureName STRING, sd BOOL , flip BOOL , dir BOOL , " +
                $"T1 REAL, T2 REAL, Depth1 DOUBLE , Depth2 DOUBLE , Draft1 DOUBLE , Draft2 DOUBLE , DraftDir1 BOOL , DraftDir2 BOOL," +
                $"DraftAng1 DOUBLE , DraftAng2 DOUBLE, offrev1 BOOL , offrev2 BOOL , TransSur1 BOOL, TransSur2 BOOL , Merge BOOL," +
                $"useFeatScope BOOL , useAutoSelect BOOL, Tcon REAL , startoffset DOUBLE , flipOffset BOOL)";
                    MessageBox.Show(createTable);
                    myCon.createTable(createTable);


                    
                    FeatureExtrude featExtrude = new FeatureExtrude();
                    featExtrude.extrude(feat.Name);
                }
                else if (feat.GetTypeName2() == "Fillet")
                {
                    MessageBox.Show("Imported feature found.");
                }
                feat = (Feature)feat.GetNextFeature();

            }
            
        }
    }
}
