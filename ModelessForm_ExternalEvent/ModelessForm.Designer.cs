
using System.Drawing;
using System.Windows.Forms;

namespace ModelessForm_ExternalEvent
{
    partial class ModelessForm
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
            this.functionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.imageFamilyGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBoxHigh = new System.Windows.Forms.PictureBox();
            this.pictureBoxDx = new System.Windows.Forms.PictureBox();
            this.pictureBoxSx = new System.Windows.Forms.PictureBox();
            this.pictureBoxCentral = new System.Windows.Forms.PictureBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.textDistintaPicker = new System.Windows.Forms.TextBox();
            this.distintaLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.functionGroupBox2 = new System.Windows.Forms.GroupBox();
            this.functionGroupBox4 = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.functionGroupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonModifica = new System.Windows.Forms.Button();
            this.textDistintaComboBox = new System.Windows.Forms.TextBox();
            this.importDistintaLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionGroupBoxListBox = new System.Windows.Forms.GroupBox();
            this.functionGroupBox1.SuspendLayout();
            this.imageFamilyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).BeginInit();
            this.functionGroupBox2.SuspendLayout();
            this.functionGroupBox4.SuspendLayout();
            this.functionGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.functionGroupBoxListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionGroupBox1
            // 
            this.functionGroupBox1.Controls.Add(this.imageFamilyGroupBox);
            this.functionGroupBox1.Controls.Add(this.captureButton);
            this.functionGroupBox1.Controls.Add(this.textDistintaPicker);
            this.functionGroupBox1.Controls.Add(this.distintaLabel);
            this.functionGroupBox1.Location = new System.Drawing.Point(12, 13);
            this.functionGroupBox1.Name = "functionGroupBox1";
            this.functionGroupBox1.Size = new System.Drawing.Size(435, 605);
            this.functionGroupBox1.TabIndex = 0;
            this.functionGroupBox1.TabStop = false;
            this.functionGroupBox1.Text = "Seleziona un oggetto";
            // 
            // imageFamilyGroupBox
            // 
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxHigh);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxDx);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxSx);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxCentral);
            this.imageFamilyGroupBox.Location = new System.Drawing.Point(10, 140);
            this.imageFamilyGroupBox.Name = "imageFamilyGroupBox";
            this.imageFamilyGroupBox.Size = new System.Drawing.Size(415, 452);
            this.imageFamilyGroupBox.TabIndex = 9;
            this.imageFamilyGroupBox.TabStop = false;
            this.imageFamilyGroupBox.Text = "Immagine dell\'oggetto selezionato";
            // 
            // pictureBoxHigh
            // 
            this.pictureBoxHigh.Location = new System.Drawing.Point(97, 50);
            this.pictureBoxHigh.Name = "pictureBoxHigh";
            this.pictureBoxHigh.Size = new System.Drawing.Size(222, 25);
            this.pictureBoxHigh.TabIndex = 8;
            this.pictureBoxHigh.TabStop = false;
            // 
            // pictureBoxDx
            // 
            this.pictureBoxDx.Location = new System.Drawing.Point(341, 97);
            this.pictureBoxDx.Name = "pictureBoxDx";
            this.pictureBoxDx.Size = new System.Drawing.Size(65, 325);
            this.pictureBoxDx.TabIndex = 7;
            this.pictureBoxDx.TabStop = false;
            // 
            // pictureBoxSx
            // 
            this.pictureBoxSx.Location = new System.Drawing.Point(10, 97);
            this.pictureBoxSx.Name = "pictureBoxSx";
            this.pictureBoxSx.Size = new System.Drawing.Size(65, 325);
            this.pictureBoxSx.TabIndex = 6;
            this.pictureBoxSx.TabStop = false;
            // 
            // pictureBoxCentral
            // 
            this.pictureBoxCentral.Location = new System.Drawing.Point(97, 97);
            this.pictureBoxCentral.Name = "pictureBoxCentral";
            this.pictureBoxCentral.Size = new System.Drawing.Size(222, 325);
            this.pictureBoxCentral.TabIndex = 5;
            this.pictureBoxCentral.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(14, 21);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(402, 43);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "Cattura un oggetto";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // textDistintaPicker
            // 
            this.textDistintaPicker.Location = new System.Drawing.Point(237, 81);
            this.textDistintaPicker.Name = "textDistintaPicker";
            this.textDistintaPicker.Size = new System.Drawing.Size(115, 22);
            this.textDistintaPicker.TabIndex = 4;
            // 
            // distintaLabel
            // 
            this.distintaLabel.AutoSize = true;
            this.distintaLabel.Location = new System.Drawing.Point(19, 84);
            this.distintaLabel.Name = "distintaLabel";
            this.distintaLabel.Size = new System.Drawing.Size(212, 17);
            this.distintaLabel.TabIndex = 3;
            this.distintaLabel.Text = "Distinta dell\'oggetto selezionato:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 356);
            this.listBox1.TabIndex = 2;
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(19, 92);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(117, 28);
            this.cleanButton.TabIndex = 3;
            this.cleanButton.Text = "Cancella";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "<- Scegli un File Excel da caricare ->";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // functionGroupBox2
            // 
            this.functionGroupBox2.Controls.Add(this.functionGroupBoxListBox);
            this.functionGroupBox2.Controls.Add(this.functionGroupBox4);
            this.functionGroupBox2.Controls.Add(this.functionGroupBox3);
            this.functionGroupBox2.Controls.Add(this.dataGridView1);
            this.functionGroupBox2.Location = new System.Drawing.Point(453, 12);
            this.functionGroupBox2.Name = "functionGroupBox2";
            this.functionGroupBox2.Size = new System.Drawing.Size(857, 605);
            this.functionGroupBox2.TabIndex = 1;
            this.functionGroupBox2.TabStop = false;
            this.functionGroupBox2.Text = "Parametri della distinta";
            // 
            // functionGroupBox4
            // 
            this.functionGroupBox4.Controls.Add(this.exportButton);
            this.functionGroupBox4.Controls.Add(this.cleanButton);
            this.functionGroupBox4.Controls.Add(this.exitButton);
            this.functionGroupBox4.Location = new System.Drawing.Point(697, 423);
            this.functionGroupBox4.Name = "functionGroupBox4";
            this.functionGroupBox4.Size = new System.Drawing.Size(154, 170);
            this.functionGroupBox4.TabIndex = 6;
            this.functionGroupBox4.TabStop = false;
            this.functionGroupBox4.Text = "Utilità";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(19, 32);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(117, 28);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Salva";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(19, 126);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(117, 28);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Esci";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // functionGroupBox3
            // 
            this.functionGroupBox3.Controls.Add(this.buttonModifica);
            this.functionGroupBox3.Controls.Add(this.textDistintaComboBox);
            this.functionGroupBox3.Controls.Add(this.importDistintaLabel);
            this.functionGroupBox3.Controls.Add(this.comboBox1);
            this.functionGroupBox3.Location = new System.Drawing.Point(6, 22);
            this.functionGroupBox3.Name = "functionGroupBox3";
            this.functionGroupBox3.Size = new System.Drawing.Size(684, 57);
            this.functionGroupBox3.TabIndex = 2;
            this.functionGroupBox3.TabStop = false;
            this.functionGroupBox3.Text = "Mostra Distinta";
            // 
            // buttonModifica
            // 
            this.buttonModifica.Location = new System.Drawing.Point(262, 22);
            this.buttonModifica.Name = "buttonModifica";
            this.buttonModifica.Size = new System.Drawing.Size(75, 23);
            this.buttonModifica.TabIndex = 7;
            this.buttonModifica.Text = "Modifica";
            this.buttonModifica.UseVisualStyleBackColor = true;
            // 
            // textDistintaComboBox
            // 
            this.textDistintaComboBox.Location = new System.Drawing.Point(520, 23);
            this.textDistintaComboBox.Name = "textDistintaComboBox";
            this.textDistintaComboBox.Size = new System.Drawing.Size(145, 22);
            this.textDistintaComboBox.TabIndex = 6;
            // 
            // importDistintaLabel
            // 
            this.importDistintaLabel.AutoSize = true;
            this.importDistintaLabel.Location = new System.Drawing.Point(386, 25);
            this.importDistintaLabel.Name = "importDistintaLabel";
            this.importDistintaLabel.Size = new System.Drawing.Size(128, 17);
            this.importDistintaLabel.TabIndex = 5;
            this.importDistintaLabel.Text = "Ultima visualizzata:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(684, 511);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(this.dataGridView1.Font, FontStyle.Bold);
            this.dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dataGridView1.GridColor = Color.Black;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            // 
            // functionGroupBoxListBox
            // 
            this.functionGroupBoxListBox.Controls.Add(this.listBox1);
            this.functionGroupBoxListBox.Location = new System.Drawing.Point(697, 21);
            this.functionGroupBoxListBox.Name = "functionGroupBoxListBox";
            this.functionGroupBoxListBox.Size = new System.Drawing.Size(154, 396);
            this.functionGroupBoxListBox.TabIndex = 7;
            this.functionGroupBoxListBox.TabStop = false;
            this.functionGroupBoxListBox.Text = "Dimensioni della Cell";
            // 
            // ModelessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 630);
            this.Controls.Add(this.functionGroupBox2);
            this.Controls.Add(this.functionGroupBox1);
            this.Name = "ModelessForm";
            this.Text = "BOLD DataCell";
            this.Load += new System.EventHandler(this.ModelessForm_Load);
            this.functionGroupBox1.ResumeLayout(false);
            this.functionGroupBox1.PerformLayout();
            this.imageFamilyGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).EndInit();
            this.functionGroupBox2.ResumeLayout(false);
            this.functionGroupBox4.ResumeLayout(false);
            this.functionGroupBox3.ResumeLayout(false);
            this.functionGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.functionGroupBoxListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox functionGroupBox1;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.GroupBox functionGroupBox2;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox functionGroupBox3;
        private System.Windows.Forms.TextBox textDistintaComboBox;
        private System.Windows.Forms.Label importDistintaLabel;
        private System.Windows.Forms.TextBox textDistintaPicker;
        private System.Windows.Forms.Label distintaLabel;
        private System.Windows.Forms.Button buttonModifica;
        private System.Windows.Forms.GroupBox functionGroupBox4;
        private System.Windows.Forms.PictureBox pictureBoxHigh;
        private System.Windows.Forms.PictureBox pictureBoxDx;
        private System.Windows.Forms.PictureBox pictureBoxSx;
        private System.Windows.Forms.PictureBox pictureBoxCentral;
        private System.Windows.Forms.GroupBox imageFamilyGroupBox;
        private System.Windows.Forms.GroupBox functionGroupBoxListBox;
    }
}