namespace TwincatScope
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TwinCAT.Scope2.Tools.EventList<TwinCAT.Scope2.View.ScopeViewControlLib.ScopeViewControlChannel> eventList_11 = new TwinCAT.Scope2.Tools.EventList<TwinCAT.Scope2.View.ScopeViewControlLib.ScopeViewControlChannel>();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button_Load = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonChart = new System.Windows.Forms.ToolStripButton();
            this.buttonAxis = new System.Windows.Forms.ToolStripButton();
            this.buttonChannel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.button_StartRecord = new System.Windows.Forms.ToolStripButton();
            this.button_StopRecord = new System.Windows.Forms.ToolStripButton();
            this.button_SaveData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.button_Run = new System.Windows.Forms.ToolStripButton();
            this.button_Pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelChart = new System.Windows.Forms.ToolStripButton();
            this.buttonXCursor = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteXC = new System.Windows.Forms.ToolStripButton();
            this.ScopeExport = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.scopeViewControl2 = new TwinCAT.Scope2.View.ScopeViewControlLib.ScopeViewControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button_Load,
            this.toolStripSeparator1,
            this.buttonChart,
            this.buttonAxis,
            this.buttonChannel,
            this.toolStripSeparator2,
            this.button_StartRecord,
            this.button_StopRecord,
            this.button_SaveData,
            this.toolStripSeparator3,
            this.button_Run,
            this.button_Pause,
            this.toolStripSeparator4,
            this.toolStripButtonDelChart,
            this.buttonXCursor,
            this.buttonDeleteXC,
            this.ScopeExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1243, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button_Load
            // 
            this.button_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(37, 22);
            this.button_Load.Text = "Load";
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonChart
            // 
            this.buttonChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(62, 22);
            this.buttonChart.Text = "AddChart";
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // buttonAxis
            // 
            this.buttonAxis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonAxis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAxis.Name = "buttonAxis";
            this.buttonAxis.Size = new System.Drawing.Size(57, 22);
            this.buttonAxis.Text = "Add Axis";
            this.buttonAxis.Click += new System.EventHandler(this.buttonAxis_Click);
            // 
            // buttonChannel
            // 
            this.buttonChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonChannel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonChannel.Name = "buttonChannel";
            this.buttonChannel.Size = new System.Drawing.Size(80, 22);
            this.buttonChannel.Text = "Add Channel";
            this.buttonChannel.Click += new System.EventHandler(this.buttonChannel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // button_StartRecord
            // 
            this.button_StartRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_StartRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_StartRecord.Name = "button_StartRecord";
            this.button_StartRecord.Size = new System.Drawing.Size(35, 22);
            this.button_StartRecord.Text = "Start";
            this.button_StartRecord.Click += new System.EventHandler(this.button_StartRecord_Click);
            // 
            // button_StopRecord
            // 
            this.button_StopRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_StopRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_StopRecord.Name = "button_StopRecord";
            this.button_StopRecord.Size = new System.Drawing.Size(35, 22);
            this.button_StopRecord.Text = "Stop";
            this.button_StopRecord.Click += new System.EventHandler(this.button_StopRecord_Click);
            // 
            // button_SaveData
            // 
            this.button_SaveData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_SaveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_SaveData.Name = "button_SaveData";
            this.button_SaveData.Size = new System.Drawing.Size(35, 22);
            this.button_SaveData.Text = "Save";
            this.button_SaveData.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // button_Run
            // 
            this.button_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(32, 22);
            this.button_Run.Text = "Run";
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(42, 22);
            this.button_Pause.Text = "Pause";
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelChart
            // 
            this.toolStripButtonDelChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelChart.Name = "toolStripButtonDelChart";
            this.toolStripButtonDelChart.Size = new System.Drawing.Size(57, 22);
            this.toolStripButtonDelChart.Text = "DelChart";
            this.toolStripButtonDelChart.Click += new System.EventHandler(this.toolStripButtonDelChart_Click);
            // 
            // buttonXCursor
            // 
            this.buttonXCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonXCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonXCursor.Name = "buttonXCursor";
            this.buttonXCursor.Size = new System.Drawing.Size(81, 22);
            this.buttonXCursor.Text = "Add X Cursor";
            this.buttonXCursor.Click += new System.EventHandler(this.buttonXCursor_Click);
            // 
            // buttonDeleteXC
            // 
            this.buttonDeleteXC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDeleteXC.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteXC.Image")));
            this.buttonDeleteXC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteXC.Name = "buttonDeleteXC";
            this.buttonDeleteXC.Size = new System.Drawing.Size(92, 22);
            this.buttonDeleteXC.Text = "Delete X Cursor";
            this.buttonDeleteXC.Click += new System.EventHandler(this.buttonDeleteXC_Click);
            // 
            // ScopeExport
            // 
            this.ScopeExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScopeExport.Image = ((System.Drawing.Image)(resources.GetObject("ScopeExport.Image")));
            this.ScopeExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScopeExport.Name = "ScopeExport";
            this.ScopeExport.Size = new System.Drawing.Size(79, 22);
            this.ScopeExport.Text = "Scope Export";
            this.ScopeExport.Click += new System.EventHandler(this.ScopeExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // scopeViewControl2
            // 
            this.scopeViewControl2.AllowDrop = true;
            this.scopeViewControl2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scopeViewControl2.ConnectedChannels = eventList_11;
            this.scopeViewControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scopeViewControl2.IsWizardTemplate = false;
            this.scopeViewControl2.Location = new System.Drawing.Point(0, 0);
            this.scopeViewControl2.Name = "scopeViewControl2";
            this.scopeViewControl2.Size = new System.Drawing.Size(1243, 280);
            this.scopeViewControl2.SortPriority = -1;
            this.scopeViewControl2.SuppressMessages = false;
            this.scopeViewControl2.TabIndex = 2;
            this.scopeViewControl2.Title = "Scope 6";
            this.scopeViewControl2.UnsafedChanges = true;
            this.scopeViewControl2.UseGraphic = TwinCAT.Scope2.View.ScopeViewControlLib.GraphicLibrary.GDI_Plus;
            this.scopeViewControl2.ViewDetailLevel = TwinCAT.Scope2.Communications.ScopeViewDetailLevel.Default;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scopeViewControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 561);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 586);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Twincat Scope .NET API Test Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

   
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton button_Load;
        private System.Windows.Forms.ToolStripButton buttonChart;
        private System.Windows.Forms.ToolStripButton buttonAxis;
        private System.Windows.Forms.ToolStripButton buttonChannel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton button_StartRecord;
        private System.Windows.Forms.ToolStripButton button_StopRecord;
        private System.Windows.Forms.ToolStripButton button_SaveData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton button_Run;
        private System.Windows.Forms.ToolStripButton button_Pause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelChart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private TwinCAT.Scope2.View.ScopeViewControlLib.ScopeViewControl scopeViewControl2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton buttonXCursor;
        private System.Windows.Forms.ToolStripButton buttonDeleteXC;
        private System.Windows.Forms.ToolStripButton ScopeExport;
    }
}

