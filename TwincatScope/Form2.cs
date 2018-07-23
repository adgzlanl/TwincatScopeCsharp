using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TwinCAT.Scope2.View.ScopeViewControlLib;
namespace TwincatScope
{
    public partial class Form2 : Form
    {
        static String svdFile, destination;
        int counter;
        ScopeViewControl control = new ScopeViewControl();
        public Form2()
        {
            InitializeComponent();
        }

        private void export_button_Click(object sender, EventArgs e)
        {

            try
            {
                //Checking the existens of the path
                if (destination == null)
                    destination = Environment.CurrentDirectory;

                if (string.IsNullOrEmpty(svdFile) || !File.Exists(svdFile))
                {
                    Console.Write("SVD File could not be found.");
                }
                else
                {
                    try
                    {
                        control.LoadScopeConfig(svdFile);
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString().Contains("0x7"))
                        {
                            Console.Write(ex.Message);
                        }
                    }
                }

                if (string.IsNullOrEmpty(destination))
                {
                    Console.Write("No destination file defined.");
                }
                else
                {
                    //search the Method with the right export
                    FileInfo fInfo = new FileInfo(destination);
                    string format = fInfo.Extension;

                    if (format.Equals(ScopeViewControl.socpeExportTdmsExtention))
                    {
                        control.Operating.ExportDataToTDMS(destination);
                    }
                    else if (format.Equals(ScopeViewControl.ScopeExportCSVExtension) || format.Equals(ScopeViewControl.ScopeExportTXTExtension))
                    {
                        control.Operating.ExportData(destination);
                    }
                    else if (format.Equals(ScopeViewControl.ScopeExportBinaryExtention))
                    {
                        control.Operating.ExportDataBinary(destination);
                    }
                    else if (format.Equals(ScopeViewControl.ScopeExportDatExtention))
                    {
                        control.Operating.ExportDataToDat(destination);
                    }
                    else
                    {
                        Console.Write("Unknown format.");
                    }

                    MessageBox.Show(this, "Konvertierung ist abgeschlossen", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //Disconnect the .svd File
                control.Operating.DisConnect(true);
                control.DeleteChart(control.Charts[0]);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                control.Operating.DisConnect(true);
            }
        }

        private void textBox_SVD_Click(object sender, EventArgs e)
        {
     
            openFileDialog1.FileName = "";
			openFileDialog1.FilterIndex=1;
            openFileDialog1.Filter = "Scope Files(*.svd)|*.svd|All files (*.*)|*.*";
            openFileDialog1.Title = "Scope Files hunterladen";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                svdFile = openFileDialog1.FileName;
                textBox_SVD.Text = svdFile;
            }
        }

        private void textBox_Export_Click(object sender, EventArgs e)
        {
            string DeviceNo = "18111";
            string FirmaName = "Pfluka";
            
            DateTime now = DateTime.Now;
            string format =  "yMd_m_s" ;
            saveFileDialog1.FileName= DeviceNo + FirmaName + now.ToString(format); 
			saveFileDialog1.Title = "Speichern Scope File in CVS"; 
            saveFileDialog1.DefaultExt = "cvs";
            saveFileDialog1.Filter = "csv Files (*.csv)|*.csv|Text Files(*.txt)| *.txt |svb Files(*.svb)| *.svb | tdms Files(*.tdms)| *.tdms| dat Files(*.dat)| *.dat| All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                destination = saveFileDialog1.FileName;
                textBox_Export.Text = destination;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
