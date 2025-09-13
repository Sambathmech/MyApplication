using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using VectraSQLiteManager;
using Microsoft.VisualBasic;

namespace MyApplication
{
  

    class sqlcon
    {
        internal SQLiteConnection DBCon;
        public void MyConnection()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.db");
            if(files.Length > 0)
            {
                string db = files[0];
                MessageBox.Show(db);
              DBCon = new SQLiteConnection($"Data Source ={db}");
                DBCon.Open();
            }
            
        }


        public void connection(string message)
        {
            DBCon = new SQLiteConnection("Data Source=features.db;Version=3;");
            DBCon.Open();
            MessageBox.Show("Database Connected");
        }


        public void createTable(string message)
        {
            
            MyConnection();
           // FeatureExtrude featExtrude = new FeatureExtrude();
           // MessageBox.Show("Creating Table");
          //  string featName = featExtrude.name
           // MessageBox.Show(featName);

           // string table = $"CREATE TABLE IF NOT EXISTS [{message}](Id INTEGER PRIMARY KEY AUTOINCREMENT, Depth REAL , Depth2 REAL ) ";
           // MessageBox.Show(table);
            SQLiteCommand cmd = new SQLiteCommand(message, DBCon);

               cmd.ExecuteNonQuery();
            
           // string insert = $"INSERT INTO {featExtrude.featName} (Depth, Depth2) VALUES ({featExtrude.depth}, {featExtrude.depth})";
            // cmd.CommandText = insert ;
            //cmd.ExecuteNonQuery();

           // MessageBox.Show("Table Created");
            
            //string table = "CREATE TABLE IF NOT EXISTS Features (Id INTEGER PRIMARY KEY AUTOINCREMENT, FeatureName TEXT, Depth REAL)";
            //SQLiteCommand cmd = new SQLiteCommand(table, con);
            //cmd.ExecuteNonQuery();
           // MessageBox.Show("Table Created");
        }
        public void insertvalue(string message)
        {
            MyConnection();
            SQLiteCommand cmd = new SQLiteCommand(message, DBCon);
            cmd.ExecuteNonQuery();
        }
    }
}
