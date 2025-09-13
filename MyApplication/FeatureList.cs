using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace MyApplication
{
    class FeatureExtrude
    {
        public SldWorks swApp = new SldWorks();
        public sqlcon myCon = new sqlcon();
        
        
        //extrude properties value declaration
        public bool sd {  get; set; }= false;
        public bool flip { get; set; }
        public bool dir { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public double Depth1 { get; set; }
        public double Depth2 { get; set; }
        public double draftCheck1 { get; set; }
        public double draftCheck2 { get; set; }
        public bool draftDir1 { get; set; }
        public bool draftDir2 { get; set; }
        public double draftangle1 { get; set; }
        public double draftangle2 { get; set; }
        public bool offsetrev1 { get; set; }
        public bool offsetrev2 { get; set; }
        public bool translatesurface1 {  get; set; }
        public bool translatesurface2 { get; set; }
        public bool merge {  get; set; }
        public bool usefeatscope1 { get; set; }
        public bool useautoselect1 { get; set; }
        public int T0 { get; set; }

        public double startoffset { get; set; }
        public bool flipoffset { get; set; }


        


        public void extrude(string message)
        {
            ModelDoc2 Model = (ModelDoc2)swApp.ActiveDoc;
            PartDoc part = (PartDoc)Model;
            Feature feature = (Feature)part.FeatureByName(message);
            sketchExtractor sk = new sketchExtractor();
            sk.extractor(message);
         //get the feature in part 
            MessageBox.Show(feature.Name);
            ExtrudeFeatureData2 feat = (ExtrudeFeatureData2)feature.GetDefinition();

           

            //Get the feture values
            flip = feat.FlipSideToCut;
            dir = feat.BothDirections;
            T1 = feat.GetEndCondition(true);
            T2 = feat.GetEndCondition(false);
            Depth1 = feat.GetDepth(true);
            Depth2 = feat.GetDepth(false);
            draftCheck1 = feat.GetDraftAngle(true);
            draftCheck2 = feat.GetDraftAngle(false);
            draftDir1 = feat.GetDraftOutward(true);
            draftDir2 = feat.GetDraftOutward(false);
            draftangle1 = feat.GetDraftAngle(true);
            draftangle2 = feat.GetDraftAngle(false);
            offsetrev1 = feat.GetReverseOffset(true);
            offsetrev2 = feat.GetReverseOffset(false);
            translatesurface1 = feat.GetTranslateSurface(true);
            translatesurface2 = feat.GetTranslateSurface(false);
            merge = feat.Merge;
            usefeatscope1 = feat.FeatureScope;
            useautoselect1 = feat.AutoSelect;
            T0= feat.GetEndCondition(true);
            startoffset = feat.FromOffsetDistance;
            flipoffset = feat.FromOffsetReverse;
            string featname= message.ToString();



            string insertValue = $"INSERT INTO Extrude(FeatureName , sd , flip , dir,T1,T2,Depth1,Depth2,Draft1, Draft2,DraftDir1,DraftDir2,DraftAng1," +
                $"DraftAng2,offrev1,offrev2,TransSur1,TransSur2, Merge,useFeatScope,useAutoSelect,Tcon,startoffset,flipOffset) " +
                $"VALUES('{message}',{sd},{flip},{dir},{T1},{T2},{Depth1},{Depth2},{draftCheck1},{draftCheck2},{draftDir1},{draftDir2}," +
                $"{draftangle1},{draftangle2},{offsetrev1},{offsetrev2},{translatesurface1},{translatesurface2},{merge},{usefeatscope1}," +
                $"{useautoselect1},{T0},{startoffset},{flipoffset})";
            MessageBox.Show(insertValue);
            myCon.insertvalue(insertValue);

        }
        
    }
    public class fillet
    {
        public SldWorks swApp = new SldWorks();
       
        public void Fillet(string message)
        {
            ModelDoc2 model = (ModelDoc2)swApp.ActiveDoc;
            PartDoc part = (PartDoc)model;
            Feature feature = (Feature)part.FeatureByName(message);
            MessageBox.Show(feature.Name);

            





        }
    }
}
