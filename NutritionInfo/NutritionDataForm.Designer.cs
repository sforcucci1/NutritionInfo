namespace NutritionInfo
{
    partial class NutritionData
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.NutritionSelect = new System.Windows.Forms.ComboBox();
            this.groupBoxNutritionInfo = new System.Windows.Forms.GroupBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.txtConsole.Location = new System.Drawing.Point(28, 28);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "textBox1";
            this.txtConsole.Size = new System.Drawing.Size(950, 71);
            this.txtConsole.TabIndex = 0;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(28, 105);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(151, 44);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.button1_Click);
            // 
            // NutritionSelect
            // 
            this.NutritionSelect.FormattingEnabled = true;
            this.NutritionSelect.Location = new System.Drawing.Point(12, 164);
            this.NutritionSelect.Name = "NutritionSelect";
            this.NutritionSelect.Size = new System.Drawing.Size(342, 21);
            this.NutritionSelect.TabIndex = 2;
            this.NutritionSelect.SelectedIndexChanged += new System.EventHandler(this.NutritionSelect_SelectedIndexChanged);
            // 
            // groupBoxNutritionInfo
            // 
            this.groupBoxNutritionInfo.Location = new System.Drawing.Point(12, 202);
            this.groupBoxNutritionInfo.Name = "groupBoxNutritionInfo";
            this.groupBoxNutritionInfo.Size = new System.Drawing.Size(976, 373);
            this.groupBoxNutritionInfo.TabIndex = 3;
            this.groupBoxNutritionInfo.TabStop = false;
            this.groupBoxNutritionInfo.Text = "Nutrition Info";
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(13, 9);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(45, 13);
            this.lblConsole.TabIndex = 4;
            this.lblConsole.Text = "Console";
            this.lblConsole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NutritionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 587);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.groupBoxNutritionInfo);
            this.Controls.Add(this.NutritionSelect);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtConsole);
            this.Name = "NutritionData";
            this.Text = "Nutrition Data Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.ComboBox NutritionSelect;
        private System.Windows.Forms.GroupBox groupBoxNutritionInfo;
        private System.Windows.Forms.Label lblConsole;
    }
}

