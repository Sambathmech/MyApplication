using System.IO;
using System.Reflection;

#nullable disable
namespace VectraSQLiteManager
{
  public  class ProjectConnection
    {
        public static string AddInDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

        public static string DatabaseFilePath
        {
            get => Path.Combine(ProjectConnection.AddInDirectory, ".db");
        }

        public static string DatabaseConnectionString
        {
            get => "Data Source=" + ProjectConnection.DatabaseFilePath + ";Version=3;";
        }
    }
}