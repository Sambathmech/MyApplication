using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace MyApplication
{
    class sqlcon
    {
        public SQLiteConnection con {  get; set; }

        
        public void  connection(string dbname)

        {
            this.con = new SQLiteConnection($"Data Source={ dbname}.db" );
            con.Open();


            MessageBox.Show("on Opened");
            


        }
        public void createTable()
        {

            
            FeatureExtrude featExtrude = new FeatureExtrude();
            MessageBox.Show("Creating Table");
            
                
                string table = $"CREATE TABLE IF NOT EXISTS {featExtrude.featName}  (Id INTEGER PRIMARY KEY AUTOINCREMENT, Depth DOUBLE, Depth2 Double)";
            using (SQLiteCommand cmd = new SQLiteCommand(table,con))
            {
                cmd.ExecuteNonQuery();
            }
            //string insert = $"INSERT INTO {featExtrude.featName} (Depth, Depth2) VALUES ({featExtrude.depth}, {featExtrude.depth})";
               // cmd.CommandText = insert ;
            //cmd.ExecuteNonQuery();

            MessageBox.Show("Table Created");
            
            //string table = "CREATE TABLE IF NOT EXISTS Features (Id INTEGER PRIMARY KEY AUTOINCREMENT, FeatureName TEXT, Depth REAL)";
            //SQLiteCommand cmd = new SQLiteCommand(table, con);
            //cmd.ExecuteNonQuery();
           // MessageBox.Show("Table Created");
        }


    }
}
