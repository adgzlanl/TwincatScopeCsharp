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
        ScopeViewControlYAxis AbstandAxis;
        ScopeViewControlYAxis ServoSpeedAxis;
        ScopeViewControlYAxis EncDistanzAxis;
        ScopeViewControlYAxis LuftDruckAxis;
        public Form1()
        {
            InitializeComponent();
            /*  dataGridView1.Columns.Add("Time", "Position");
                dataGridView1.Columns.Add("Cursor", "Cursor\\Charts");
                dataGridView1.Columns.Add("Scope.Abstand", "Sensor Abstand");
                dataGridView1.Columns.Add("Scope.ServoSpeed", "Die Rolle Gesch.");
                dataGridView1.Columns.Add("Scope.EncDistanz", "Strecke");
                dataGridView1.Columns.Add("Scope.LuftDruck", "LuftDruck");
                dataGridView1.Rows.Clear();
            */
        }


        private void button_Load_Click(object sender, EventArgs e)
        {
            string filename = "";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 3;
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
                        channel.Acquisition.AmsNetId = AmsNetId.Parse("192.168.0.2.1.1");
                        channel.Acquisition.TargetPort = 851;
                        //dataGridView1.Columns.Add(channel.Acquisition.SymbolName, channel.Acquisition.SymbolName);
                        //dataGridView1.Columns[channel.Acquisition.SymbolName].DefaultCellStyle.ForeColor = channel.Style.Color;
                
                    }
                }

            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            ScopeViewControlChart chart = scopeViewControl2.NewChart();



            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {

                AxisSettings(AbstandAxis, "Abstand");
                AxisSettings(ServoSpeedAxis, "Servospeed");
                AxisSettings(EncDistanzAxis, "Strecke");
                AxisSettings(LuftDruckAxis, "Luftdruck");

            }



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
                ScopeViewControlChannel channel1 = scopeViewControl2.Charts[0].Axes[0].NewChannel();
                ChangeChannelSettings(channel1, Color.Red, Color.DarkRed);
                SetAcquisition(channel1, "Scope.Abstand");

                ScopeViewControlChannel channel2 = scopeViewControl2.Charts[0].Axes[1].NewChannel();
                ChangeChannelSettings(channel2, Color.Green, Color.DarkGreen);
                SetAcquisition(channel2, "Scope.ServoSpeed");
                ScopeViewControlChannel channel3 = scopeViewControl2.Charts[0].Axes[2].NewChannel();
                ChangeChannelSettings(channel3, Color.Orange, Color.DarkOrange);
                SetAcquisition(channel3, "Scope.EncDistanz");
                ScopeViewControlChannel channel4 = scopeViewControl2.Charts[0].Axes[3].NewChannel();
                ChangeChannelSettings(channel4, Color.Blue, Color.DarkBlue);
                SetAcquisition(channel4, "Scope.LuftDruck");

            }

        }

        private void buttonAxis_Click(object sender, EventArgs e)
        {
            if (scopeViewControl2.Charts.Count == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                
                AxisSettings(AbstandAxis, "Abstand");
                AxisSettings(ServoSpeedAxis, "Servospeed");
                AxisSettings(EncDistanzAxis, "Strecke");
                AxisSettings(LuftDruckAxis, "Luftdruck");

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
                ScopeViewControlChannel channel1 = scopeViewControl2.Charts[0].Axes[0].NewChannel();
                ChangeChannelSettings(channel1,Color.Red,Color.DarkRed);
                SetAcquisition(channel1,"Scope.Abstand");
                
                ScopeViewControlChannel channel2 = scopeViewControl2.Charts[0].Axes[1].NewChannel();
                ChangeChannelSettings(channel2,Color.Green,Color.DarkGreen);
                SetAcquisition(channel2, "Scope.ServoSpeed");
                ScopeViewControlChannel channel3 = scopeViewControl2.Charts[0].Axes[2].NewChannel();
                ChangeChannelSettings(channel3,Color.Orange,Color.DarkOrange);
                SetAcquisition(channel3, "Scope.EncDistanz");
                ScopeViewControlChannel channel4 = scopeViewControl2.Charts[0].Axes[3].NewChannel();
                ChangeChannelSettings(channel4,Color.Blue,Color.DarkBlue);
                SetAcquisition(channel4, "Scope.LuftDruck");
                /*dataGridView1.Columns.Add(channel1.Acquisition.SymbolName, channel1.Acquisition.SymbolName);
                dataGridView1.Columns[channel1.Acquisition.SymbolName].DefaultCellStyle.ForeColor = channel1.Style.Color;
                dataGridView1.Columns.Add(channel2.Acquisition.SymbolName, channel2.Acquisition.SymbolName);
                dataGridView1.Columns[channel2.Acquisition.SymbolName].DefaultCellStyle.ForeColor = channel2.Style.Color;
                dataGridView1.Columns.Add(channel3.Acquisition.SymbolName, channel3.Acquisition.SymbolName);
                dataGridView1.Columns[channel3.Acquisition.SymbolName].DefaultCellStyle.ForeColor = channel3.Style.Color;
                dataGridView1.Columns.Add(channel4.Acquisition.SymbolName, channel4.Acquisition.SymbolName);
                dataGridView1.Columns[channel4.Acquisition.SymbolName].DefaultCellStyle.ForeColor = channel4.Style.Color;
                */
            }
        }

        private void AxisSettings (ScopeViewControlYAxis axis,string AxisName)
        {
                axis= scopeViewControl2.Charts[0].NewAxis();
                axis.Caption = AxisName;
                
        }

        private void ChangeChannelSettings(ScopeViewControlChannel channel,Color colorLine,Color colorMark)
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
                channel.Style.LineColor = colorLine;
                channel.Style.MarkColor = colorMark;
                channel.Style.LineWidth = 2;
            }
        }

        private void SetAcquisition(ScopeViewControlChannel channel,string Symbolname)
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
                channel.Acquisition.AmsNetId = AmsNetId.Parse("192.168.0.2.1.1");
                channel.Acquisition.TargetPort = 851;
                channel.Acquisition.IsSymbolBased = true;
                channel.Acquisition.SymbolName = Symbolname;
                channel.Acquisition.DataType = DataTypeConverter.AdsToScope2Datatype(AdsDatatypeId.ADST_REAL64);
                channel.Acquisition.SampleTime = (uint)(1 * TimeSpan.TicksPerMillisecond);
            
         
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
            string DeviceNo = "18111";
            string FirmaName = "Pfluka";
            DateTime now = DateTime.Now;
            string format = "yMd_m_s";
            saveFileDialog1.FileName = DeviceNo + FirmaName + now.ToString(format);           
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
                        File.Create(filename).Close();
                        scopeViewControl2.Operating.SaveData(filename);
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



        private void buttonXCursor_Click(object sender, EventArgs e)
        {
          /*  try
            {
                ScopeViewControlCursor newCursor = scopeViewControl2.Charts[0].CursorModule.NewCursor(false);
                newCursor.ChannelValuesChanged += new System.EventHandler(this.resfreshX);
                newCursor.StatusTimesChanged += new System.EventHandler(this.timeRefreshX);
                newCursor.Selected += new System.EventHandler(this.actCursorRefresh);
                dataGridView1.Rows.Insert(scopeViewControl2.Charts[0].CursorModule.XCursor.Count - 1, newCursor.StatusTimes.ChartPositionTime.ToString(), newCursor.Style.Name);
                dataGridView1.Rows[scopeViewControl2.Charts[0].CursorModule.XCursor.Count - 1].Cells[1].Style.ForeColor = newCursor.Style.Color;
                resfreshX(newCursor, null);
                //setXDeltaView();
            }
            catch (Exception) { }
            */
        }


        private void setXDeltaView()
        {
            /*
            //delete old values
            while (scopeViewControl2.Charts[0].CursorModule.XCursor.Count != dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
            //set new values
            for (int i = 0; i < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; i++)
            {
                for (int k = i + 1; k < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; k++)
                {
                    dataGridView1.Rows.Add(TimeSpan.Parse(dataGridView1[0, i].Value.ToString()) - TimeSpan.Parse(dataGridView1[0, k].Value.ToString()), dataGridView1[1, i].Value + " - " + dataGridView1[1, k].Value);
                    for (int h = 2; h < scopeViewControl2.Charts[0].Axes[0].Channels.Count + 2; h++)
                    {
                        if (dataGridView1[h, k].Value != null)
                        {
                            dataGridView1[h, dataGridView1.Rows.Count - 1].Value = Convert.ToDouble(dataGridView1[h, i].Value) - Convert.ToDouble(dataGridView1[h, k].Value);
                        }
                    }
                }
            }
            */
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.D)
            {
                try
                {
                    scopeViewControl2.Charts[0].CursorModule.XCursor[dataGridView1.SelectedCells[0].RowIndex].MoveCursor(5);
                }
                catch (Exception)
                {
                    MessageBox.Show("There is no X-Axis to move!");
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                try
                {
                    scopeViewControl2.Charts[0].CursorModule.XCursor[dataGridView1.SelectedCells[0].RowIndex].MoveCursor(-5);
                }
                catch (Exception)
                {
                    MessageBox.Show("There is no X-Axis to move!");
                }
            }
            */
        }


        private void actCursorRefresh(object sender, EventArgs e)
        {
            /*
            ScopeViewControlCursor tmpCursor = (ScopeViewControlCursor)sender;

            if (tmpCursor.Style.Orientation == TwinCAT.Scope2.Charting.ChartingBase.CursorDirection.Vertical)
            {
                for (int i = 0; i < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; i++)
                {
                    if (tmpCursor == scopeViewControl2.Charts[0].CursorModule.XCursor[i])
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1[1, i].Selected = true;
                    }
                }
            }
            */
        }

        //Refresh the chart

        private void resfreshX(object sender, EventArgs e)
        {
            /*
            try
            {
                ScopeViewControlCursor tmpCursor = (ScopeViewControlCursor)sender;
                //set new channel value
                for (int k = 0; k < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; k++)
                {
                    if (scopeViewControl2.Charts[0].CursorModule.XCursor[k] == tmpCursor)
                    {
                        for (int j = 0; j < tmpCursor.ChannelValues.Count; j++)
                        {
                            dataGridView1[j + 2, k].Value = tmpCursor.ChannelValues[j];
                        }
                        break;
                    }
                }
                //refresh all delta values
                int m = scopeViewControl2.Charts[0].CursorModule.XCursor.Count;
                for (int i = 0; i < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; i++)
                {
                    for (int k = i + 1; k < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; k++)
                    {
                        for (int h = 2; h < scopeViewControl2.Charts[0].Axes[0].Channels.Count + 2; h++)
                        {
                            if (dataGridView1[h, k].Value != null)
                            {
                                dataGridView1[h, m].Value = Convert.ToDouble(dataGridView1[h, i].Value) - Convert.ToDouble(dataGridView1[h, k].Value);
                            }
                        }
                        m++;
                    }
                }
            }
            catch (Exception) { }
            */
        }


        private void timeRefreshX(object sender, EventArgs e)
        {
            /*
            //refresh the cursortime
            for (int i = 0; i < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; i++)
            {
                dataGridView1[0, i].Value = scopeViewControl2.Charts[0].CursorModule.XCursor[i].StatusTimes.ChartPositionTime.ToString();
            }
            //refresh the deltatime
            int m = scopeViewControl2.Charts[0].CursorModule.XCursor.Count;
            for (int i = 0; i < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; i++)
            {
                for (int k = i + 1; k < scopeViewControl2.Charts[0].CursorModule.XCursor.Count; k++)
                {
                    dataGridView1[0, m].Value = TimeSpan.Parse(dataGridView1[0, i].Value.ToString()) - TimeSpan.Parse(dataGridView1[0, k].Value.ToString());
                    m++;
                }
            }
            */
        }

        private void buttonDeleteXC_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                scopeViewControl2.Charts[0].CursorModule.DeleteCursor(scopeViewControl2.Charts[0].CursorModule.XCursor[dataGridView1.SelectedCells[0].RowIndex]);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                setXDeltaView();
            }
            catch (Exception) { }
            */
        }

        private void ScopeExport_Click(object sender, EventArgs e)
        {
            Form2 form2= new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
