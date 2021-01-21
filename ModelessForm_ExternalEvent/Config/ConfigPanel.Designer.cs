﻿
using System;

namespace ModelessForm_ExternalEvent.Config
{
    partial class ConfigPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.configInitialButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inserisci il Percorso del file di Configurazione.\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.configInitialButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impostazioni";
            // 
            // configInitialButton
            // 
            this.configInitialButton.Location = new System.Drawing.Point(91, 88);
            this.configInitialButton.Name = "configInitialButton";
            this.configInitialButton.Size = new System.Drawing.Size(147, 72);
            this.configInitialButton.TabIndex = 1;
            this.configInitialButton.Text = "Inserisci";
            this.configInitialButton.UseVisualStyleBackColor = true;
            this.configInitialButton.Click += new System.EventHandler(this.configInitialButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Config.xlsx";
            this.openFileDialog1.Filter = "File Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\Config";
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 246);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigPanel";
            this.Text = "Pannello di Configurazione";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button configInitialButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}