using System.Diagnostics;

namespace MyApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void click_Click(object sender, EventArgs e)
        {
            bool isrunning;
            try
            {
                // Whether Solidworks Application is Running or Not
                if (Process.GetProcessesByName("Sldworks").Any())
                {
                    MessageBox.Show("SolidWorks is running");
                    //if the application is running and execute the code
                    DocChecker docChecker = new DocChecker();
                    docChecker.currentDocument();

                }
                else
                {
                    MessageBox.Show("SolidWorks is not running");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
