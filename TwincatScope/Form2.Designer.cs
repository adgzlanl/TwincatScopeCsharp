namespace TwincatScope
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label_Destination = new System.Windows.Forms.Label();
            this.labelSVD = new System.Windows.Forms.Label();
            this.textBox_Export = new System.Windows.Forms.TextBox();
            this.textBox_SVD = new System.Windows.Forms.TextBox();
            this.export_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label_Destination
            // 
            this.label_Destination.AutoSize = true;
            this.label_Destination.Location = new System.Drawing.Point(12, 45);
            this.label_Destination.Name = "label_Destination";
            this.label_Destination.Size = new System.Drawing.Size(63, 13);
            this.label_Destination.TabIndex = 9;
            this.label_Destination.Text = "Destination:";
            // 
            // labelSVD
            // 
            this.labelSVD.AutoSize = true;
            this.labelSVD.Location = new System.Drawing.Point(12, 13);
            this.labelSVD.Name = "labelSVD";
            this.labelSVD.Size = new System.Drawing.Size(32, 13);
            this.labelSVD.TabIndex = 8;
            this.labelSVD.Text = "SVD:";
            // 
            // textBox_Export
            // 
            this.textBox_Export.Location = new System.Drawing.Point(108, 42);
            this.textBox_Export.Name = "textBox_Export";
            this.textBox_Export.Size = new System.Drawing.Size(486, 20);
            this.textBox_Export.TabIndex = 7;
            this.textBox_Export.Click += new System.EventHandler(this.textBox_Export_Click);
            // 
            // textBox_SVD
            // 
            this.textBox_SVD.Location = new System.Drawing.Point(108, 10);
            this.textBox_SVD.Name = "textBox_SVD";
            this.textBox_SVD.Size = new System.Drawing.Size(486, 20);
            this.textBox_SVD.TabIndex = 6;
            this.textBox_SVD.Click += new System.EventHandler(this.textBox_SVD_Click);
            // 
            // export_button
            // 
            this.export_button.Location = new System.Drawing.Point(235, 74);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(137, 31);
            this.export_button.TabIndex = 5;
            this.export_button.Text = "Export";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 114);
            this.Controls.Add(this.label_Destination);
            this.Controls.Add(this.labelSVD);
            this.Controls.Add(this.textBox_Export);
            this.Controls.Add(this.textBox_SVD);
            this.Controls.Add(this.export_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Twincat Scope .NET API Test Program";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Destination;
        private System.Windows.Forms.Label labelSVD;
        private System.Windows.Forms.TextBox textBox_Export;
        private System.Windows.Forms.TextBox textBox_SVD;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}