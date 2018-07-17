using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;
using System.IO;
using TwinCAT.Scope2.View.ScopeViewControlLib;
using TwinCAT.Scope2.Communications;


//*************************************************************************************************************************************************************************************
//Quelle Code auf Beckhoff Webseite link VS2010-Projekt verfügbar: https://infosys.beckhoff.com/content/1031/TE13xx_TC3_ScopeView/Resources/zip/2646930955.zip
//*************************************************************************************************************************************************************************************

namespace TwincatScope
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_Load_Click(object sender, EventArgs e)
        {
            string filename = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|Scope Files(*.sv2)|*.sv2|Scope Files(*.svd)|*.svd|Scope Files(*.tcscope)|*.tcscope|All files (*.*)|*.*";
            openFileDialog1.Title="Scope Files hunterladen";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                filename = openFileDialog1.FileName;

                FileInfo finfo = new FileInfo(filename);
                if (!finfo.Exists)
                {
                    MessageBox.Show(this, "File not found! Please use the 'Add Chart' buttons to create a config.\r\nOnce a config is created and saved it can be load using the 'Load' -Button!", "File not found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // alte Konfiguration löschen
                    while (scopeViewControl2.Charts.Count > 0)
                    {
                        scopeViewControl2.DeleteChart(scopeViewControl2.Charts[0]);
                    }

                    // Konfiguration laden
                    scopeViewControl2.LoadScopeConfig(filename);

                    foreach (ScopeViewControlChannel channel in scopeViewControl2.ConnectedChannels)
                    {
                        channel.Acquisition.AmsNetId = AmsNetId.Local;
                    }
                }

            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            ScopeViewControlChart chart = scopeViewControl2.NewChart();
        }

        private void buttonAxis_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ScopeViewControlYAxis axis = scopeViewControl2.Charts[0].NewAxis();
            }
        }

        private void buttonChannel_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes.Count == 0)
            {
                MessageBox.Show(this, "Please create an YAxis first!", "No axis connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes[0].Channels.Count > 0)
            {
                MessageBox.Show(this, "This sample contains only one channel!", "Channel still connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ScopeViewControlChannel channel = scopeViewControl2.Charts[0].Axes[0].NewChannel();
                ChangeChannelSettings(channel);
                SetAcquisition(channel);
            }
        }

        private void ChangeChannelSettings(ScopeViewControlChannel channel)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes.Count == 0)
            {
                MessageBox.Show(this, "Please create an YAxis first!", "No axis connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes[0].Channels.Count == 0)
            {
                MessageBox.Show(this, "Please create a Channel first!", "No channel connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                channel.Style.LineColor = Color.Red;
                channel.Style.MarkColor = Color.DarkRed;
                channel.Style.LineWidth = 2;
            }
        }

        private void SetAcquisition(ScopeViewControlChannel channel)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes.Count == 0)
            {
                MessageBox.Show(this, "Please create an YAxis first!", "No axis connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.Charts[0].Axes[0].Channels.Count == 0)
            {
                MessageBox.Show(this, "Please create a Channel first!", "No channel connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // AmsNetId und AmsPort benötigen die TwinCAT.Ads.dll
                channel.Acquisition.AmsNetId = AmsNetId.Local;
                channel.Acquisition.TargetPort = 851;
                channel.Acquisition.IsSymbolBased = true;
                channel.Acquisition.SymbolName = "Variables.fStairs";
                channel.Acquisition.DataType = DataTypeConverter.AdsToScope2Datatype(AdsDatatypeId.ADST_INT16);
                channel.Acquisition.SampleTime = (uint)(10 * TimeSpan.TicksPerMillisecond);
            }
        }

        private void button_StartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // alte Daten verwerfen
                if (scopeViewControl2.State == ScopeViewControlStates.REPLY)
                    scopeViewControl2.Operating.DisConnect(false);

                // Aufnahme starten
                if (scopeViewControl2.State == ScopeViewControlStates.CONFIG)
                    scopeViewControl2.Operating.StartRecord();

                // alle Charts starten
                if (scopeViewControl2.State == ScopeViewControlStates.CONNECTED)
                    scopeViewControl2.Operating.StartAllDisplays();
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on start record!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_StopRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (scopeViewControl2.State == ScopeViewControlStates.RECORD)
                    scopeViewControl2.Operating.StopRecord();
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on stop record!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string filename = "";
            
            saveFileDialog1.DefaultExt = "svd";
            saveFileDialog1.Filter ="Scope files (*.svd)|*.svd|All files (*.*)|*.*";

            try
            {

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                {
                    filename= saveFileDialog1.FileName;
                    // wenn Daten da sind speichern
                    if (scopeViewControl2.State == ScopeViewControlStates.REPLY)
                    {
                        File.Create("ExportData.svd").Close();
                        scopeViewControl2.Operating.SaveData("ExportData.svd");
                    }
                    // sonst nur die Konfiguration speichern
                    else
                    {

                        File.Create(filename).Close();
                        scopeViewControl2.SaveScopeConfig(filename);
                    }
                }

                
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on save!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.State != ScopeViewControlStates.RECORD)
            {
                MessageBox.Show(this, "Only possible if a record is running!", "Run not possible!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (scopeViewControl2.State == ScopeViewControlStates.RECORD)
                scopeViewControl2.Charts[0].ChartOperating.StartDisplay();
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.State != ScopeViewControlStates.RECORD)
            {
                MessageBox.Show(this, "Only possible if a record is running!", "Pause not possible!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (scopeViewControl2.State == ScopeViewControlStates.RECORD)
                scopeViewControl2.Charts[0].ChartOperating.StopDisplay();
        }

        private void toolStripButtonDelChart_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "No chart is connected!", "Nothing to delete!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeViewControl2.State == ScopeViewControlStates.RECORD)
            {
                scopeViewControl2.Operating.StopRecord();
                scopeViewControl2.Operating.DisConnect(false);
            }
            else if (scopeViewControl2.State == ScopeViewControlStates.REPLY)
            {
                scopeViewControl2.Operating.DisConnect(false);
            }
            else
            {
                scopeViewControl2.DeleteChart(scopeViewControl2.Charts[scopeViewControl2.Charts.Count - 1]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
