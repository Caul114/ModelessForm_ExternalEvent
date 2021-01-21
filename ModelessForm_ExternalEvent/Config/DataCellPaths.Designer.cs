
namespace ModelessForm_ExternalEvent.Config
{
    partial class DataCellPaths
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
            this.settingsDataCellGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsDataCellButton = new System.Windows.Forms.Button();
            this.settingsDataCellLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsDataCellGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsDataCellGroupBox
            // 
            this.settingsDataCellGroupBox.Controls.Add(this.settingsDataCellButton);
            this.settingsDataCellGroupBox.Controls.Add(this.settingsDataCellLabel);
            this.settingsDataCellGroupBox.Location = new System.Drawing.Point(28, 18);
            this.settingsDataCellGroupBox.Name = "settingsDataCellGroupBox";
            this.settingsDataCellGroupBox.Size = new System.Drawing.Size(426, 243);
            this.settingsDataCellGroupBox.TabIndex = 0;
            this.settingsDataCellGroupBox.TabStop = false;
            this.settingsDataCellGroupBox.Text = "Impostazioni";
            // 
            // settingsDataCellButton
            // 
            this.settingsDataCellButton.Location = new System.Drawing.Point(125, 110);
            this.settingsDataCellButton.Name = "settingsDataCellButton";
            this.settingsDataCellButton.Size = new System.Drawing.Size(169, 82);
            this.settingsDataCellButton.TabIndex = 1;
            this.settingsDataCellButton.Text = "Inserisci";
            this.settingsDataCellButton.UseVisualStyleBackColor = true;
            this.settingsDataCellButton.Click += new System.EventHandler(this.settingsDataCellButton_Click);
            // 
            // settingsDataCellLabel
            // 
            this.settingsDataCellLabel.AutoSize = true;
            this.settingsDataCellLabel.Location = new System.Drawing.Point(26, 51);
            this.settingsDataCellLabel.Name = "settingsDataCellLabel";
            this.settingsDataCellLabel.Size = new System.Drawing.Size(378, 34);
            this.settingsDataCellLabel.TabIndex = 0;
            this.settingsDataCellLabel.Text = "Inserisci l\'indirizzo della Cartella DataCell.\r\n";
            // 
            // DataCellPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 294);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.settingsDataCellGroupBox);
            this.Name = "DataCellPaths";
            this.Text = "Percorso della Cartella DataCell";
            this.settingsDataCellGroupBox.ResumeLayout(false);
            this.settingsDataCellGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsDataCellGroupBox;
        private System.Windows.Forms.Button settingsDataCellButton;
        private System.Windows.Forms.Label settingsDataCellLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}