
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.functionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.imageFamilyGroupBox = new System.Windows.Forms.GroupBox();
            this.imagesTextBox = new System.Windows.Forms.TextBox();
            this.imagesLabel = new System.Windows.Forms.Label();
            this.imagesButton = new System.Windows.Forms.Button();
            this.nameFamilyTextBox = new System.Windows.Forms.TextBox();
            this.nameFamilyLabel = new System.Windows.Forms.Label();
            this.pictureBoxHigh = new System.Windows.Forms.PictureBox();
            this.pictureBoxDx = new System.Windows.Forms.PictureBox();
            this.pictureBoxSx = new System.Windows.Forms.PictureBox();
            this.pictureBoxCentral = new System.Windows.Forms.PictureBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.functionGroupBox2 = new System.Windows.Forms.GroupBox();
            this.functionGroupBoxListBox = new System.Windows.Forms.GroupBox();
            this.functionGroupBox4 = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionGroupBox3 = new System.Windows.Forms.GroupBox();
            this.excelDistintaButton = new System.Windows.Forms.Button();
            this.textDistintaComboBox = new System.Windows.Forms.TextBox();
            this.importDistintaLabel = new System.Windows.Forms.Label();
            this.uploadExcelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.functionGroupBox1.SuspendLayout();
            this.imageFamilyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).BeginInit();
            this.functionGroupBox2.SuspendLayout();
            this.functionGroupBoxListBox.SuspendLayout();
            this.functionGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.functionGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionGroupBox1
            // 
            this.functionGroupBox1.Controls.Add(this.imageFamilyGroupBox);
            this.functionGroupBox1.Controls.Add(this.captureButton);
            this.functionGroupBox1.Location = new System.Drawing.Point(12, 13);
            this.functionGroupBox1.Name = "functionGroupBox1";
            this.functionGroupBox1.Size = new System.Drawing.Size(435, 605);
            this.functionGroupBox1.TabIndex = 0;
            this.functionGroupBox1.TabStop = false;
            this.functionGroupBox1.Text = "Seleziona un oggetto";
            // 
            // imageFamilyGroupBox
            // 
            this.imageFamilyGroupBox.Controls.Add(this.imagesTextBox);
            this.imageFamilyGroupBox.Controls.Add(this.imagesLabel);
            this.imageFamilyGroupBox.Controls.Add(this.imagesButton);
            this.imageFamilyGroupBox.Controls.Add(this.nameFamilyTextBox);
            this.imageFamilyGroupBox.Controls.Add(this.nameFamilyLabel);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxHigh);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxDx);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxSx);
            this.imageFamilyGroupBox.Controls.Add(this.pictureBoxCentral);
            this.imageFamilyGroupBox.Location = new System.Drawing.Point(6, 79);
            this.imageFamilyGroupBox.Name = "imageFamilyGroupBox";
            this.imageFamilyGroupBox.Size = new System.Drawing.Size(423, 513);
            this.imageFamilyGroupBox.TabIndex = 9;
            this.imageFamilyGroupBox.TabStop = false;
            this.imageFamilyGroupBox.Text = "Famiglia dell\'oggetto selezionato";
            // 
            // imagesTextBox
            // 
            this.imagesTextBox.Location = new System.Drawing.Point(123, 479);
            this.imagesTextBox.Name = "imagesTextBox";
            this.imagesTextBox.Size = new System.Drawing.Size(164, 22);
            this.imagesTextBox.TabIndex = 11;
            // 
            // imagesLabel
            // 
            this.imagesLabel.AutoSize = true;
            this.imagesLabel.Location = new System.Drawing.Point(6, 480);
            this.imagesLabel.Name = "imagesLabel";
            this.imagesLabel.Size = new System.Drawing.Size(119, 17);
            this.imagesLabel.TabIndex = 12;
            this.imagesLabel.Text = "Cartella Immagini:";
            // 
            // imagesButton
            // 
            this.imagesButton.Location = new System.Drawing.Point(293, 478);
            this.imagesButton.Name = "imagesButton";
            this.imagesButton.Size = new System.Drawing.Size(118, 25);
            this.imagesButton.TabIndex = 8;
            this.imagesButton.Text = "Carica Immagini";
            this.imagesButton.UseVisualStyleBackColor = true;
            this.imagesButton.Click += new System.EventHandler(this.imagesButton_Click);
            // 
            // nameFamilyTextBox
            // 
            this.nameFamilyTextBox.Location = new System.Drawing.Point(227, 30);
            this.nameFamilyTextBox.Name = "nameFamilyTextBox";
            this.nameFamilyTextBox.Size = new System.Drawing.Size(179, 22);
            this.nameFamilyTextBox.TabIndex = 10;
            // 
            // nameFamilyLabel
            // 
            this.nameFamilyLabel.AutoSize = true;
            this.nameFamilyLabel.Location = new System.Drawing.Point(6, 33);
            this.nameFamilyLabel.Name = "nameFamilyLabel";
            this.nameFamilyLabel.Size = new System.Drawing.Size(215, 17);
            this.nameFamilyLabel.TabIndex = 10;
            this.nameFamilyLabel.Text = "Nome della Famiglia selezionata:";
            // 
            // pictureBoxHigh
            // 
            this.pictureBoxHigh.Location = new System.Drawing.Point(97, 78);
            this.pictureBoxHigh.Name = "pictureBoxHigh";
            this.pictureBoxHigh.Size = new System.Drawing.Size(222, 25);
            this.pictureBoxHigh.TabIndex = 8;
            this.pictureBoxHigh.TabStop = false;
            // 
            // pictureBoxDx
            // 
            this.pictureBoxDx.Location = new System.Drawing.Point(341, 125);
            this.pictureBoxDx.Name = "pictureBoxDx";
            this.pictureBoxDx.Size = new System.Drawing.Size(65, 325);
            this.pictureBoxDx.TabIndex = 7;
            this.pictureBoxDx.TabStop = false;
            // 
            // pictureBoxSx
            // 
            this.pictureBoxSx.Location = new System.Drawing.Point(10, 125);
            this.pictureBoxSx.Name = "pictureBoxSx";
            this.pictureBoxSx.Size = new System.Drawing.Size(65, 325);
            this.pictureBoxSx.TabIndex = 6;
            this.pictureBoxSx.TabStop = false;
            // 
            // pictureBoxCentral
            // 
            this.pictureBoxCentral.Location = new System.Drawing.Point(97, 125);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 276);
            this.listBox1.TabIndex = 2;
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(19, 103);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(117, 28);
            this.cleanButton.TabIndex = 3;
            this.cleanButton.Text = "Cancella tutto";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "<- Scegli una pagina del foglio Excel ->";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // functionGroupBox2
            // 
            this.functionGroupBox2.Controls.Add(this.functionGroupBoxListBox);
            this.functionGroupBox2.Controls.Add(this.functionGroupBox4);
            this.functionGroupBox2.Controls.Add(this.dataGridView1);
            this.functionGroupBox2.Location = new System.Drawing.Point(453, 80);
            this.functionGroupBox2.Name = "functionGroupBox2";
            this.functionGroupBox2.Size = new System.Drawing.Size(857, 538);
            this.functionGroupBox2.TabIndex = 1;
            this.functionGroupBox2.TabStop = false;
            this.functionGroupBox2.Text = "Parametri della Distinta";
            // 
            // functionGroupBoxListBox
            // 
            this.functionGroupBoxListBox.Controls.Add(this.listBox1);
            this.functionGroupBoxListBox.Location = new System.Drawing.Point(697, 26);
            this.functionGroupBoxListBox.Name = "functionGroupBoxListBox";
            this.functionGroupBoxListBox.Size = new System.Drawing.Size(154, 310);
            this.functionGroupBoxListBox.TabIndex = 7;
            this.functionGroupBoxListBox.TabStop = false;
            this.functionGroupBoxListBox.Text = "Dimensioni della Cell";
            // 
            // functionGroupBox4
            // 
            this.functionGroupBox4.Controls.Add(this.exportButton);
            this.functionGroupBox4.Controls.Add(this.cleanButton);
            this.functionGroupBox4.Controls.Add(this.exitButton);
            this.functionGroupBox4.Location = new System.Drawing.Point(697, 342);
            this.functionGroupBox4.Name = "functionGroupBox4";
            this.functionGroupBox4.Size = new System.Drawing.Size(154, 183);
            this.functionGroupBox4.TabIndex = 6;
            this.functionGroupBox4.TabStop = false;
            this.functionGroupBox4.Text = "Utilità";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(19, 30);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(117, 28);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Salva";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(19, 137);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(117, 28);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Esci";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(7, 26);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 499);
            this.dataGridView1.TabIndex = 0;
            // 
            // functionGroupBox3
            // 
            this.functionGroupBox3.Controls.Add(this.excelDistintaButton);
            this.functionGroupBox3.Controls.Add(this.textDistintaComboBox);
            this.functionGroupBox3.Controls.Add(this.importDistintaLabel);
            this.functionGroupBox3.Controls.Add(this.comboBox1);
            this.functionGroupBox3.Location = new System.Drawing.Point(453, 13);
            this.functionGroupBox3.Name = "functionGroupBox3";
            this.functionGroupBox3.Size = new System.Drawing.Size(857, 57);
            this.functionGroupBox3.TabIndex = 2;
            this.functionGroupBox3.TabStop = false;
            this.functionGroupBox3.Text = "Mostra Distinta";
            // 
            // excelDistintaButton
            // 
            this.excelDistintaButton.Location = new System.Drawing.Point(290, 20);
            this.excelDistintaButton.Name = "excelDistintaButton";
            this.excelDistintaButton.Size = new System.Drawing.Size(118, 25);
            this.excelDistintaButton.TabIndex = 7;
            this.excelDistintaButton.Text = "Carica il File";
            this.excelDistintaButton.UseVisualStyleBackColor = true;
            this.excelDistintaButton.Click += new System.EventHandler(this.excelDistintaButton_Click);
            // 
            // textDistintaComboBox
            // 
            this.textDistintaComboBox.Location = new System.Drawing.Point(693, 23);
            this.textDistintaComboBox.Name = "textDistintaComboBox";
            this.textDistintaComboBox.Size = new System.Drawing.Size(145, 22);
            this.textDistintaComboBox.TabIndex = 6;
            // 
            // importDistintaLabel
            // 
            this.importDistintaLabel.AutoSize = true;
            this.importDistintaLabel.Location = new System.Drawing.Point(559, 25);
            this.importDistintaLabel.Name = "importDistintaLabel";
            this.importDistintaLabel.Size = new System.Drawing.Size(224, 21);
            this.importDistintaLabel.TabIndex = 5;
            this.importDistintaLabel.Text = "Ultima Distinta visualizzata:";
            // 
            // uploadExcelOpenFileDialog
            // 
            this.uploadExcelOpenFileDialog.DefaultExt = "xlsx";
            this.uploadExcelOpenFileDialog.FileName = "AbacoCells";
            this.uploadExcelOpenFileDialog.Filter = "File Excel (*.xlsx)|*.xlsx";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Scegli la Directory da cui vuoi attingere le immagini.";
            // 
            // ModelessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 630);
            this.MaximizeBox = false;
            this.Controls.Add(this.functionGroupBox2);
            this.Controls.Add(this.functionGroupBox1);
            this.Controls.Add(this.functionGroupBox3);
            this.Name = "ModelessForm";
            this.Text = "BOLD DataCell";
            this.Load += new System.EventHandler(this.ModelessForm_Load);
            this.functionGroupBox1.ResumeLayout(false);
            this.imageFamilyGroupBox.ResumeLayout(false);
            this.imageFamilyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).EndInit();
            this.functionGroupBox2.ResumeLayout(false);
            this.functionGroupBoxListBox.ResumeLayout(false);
            this.functionGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.functionGroupBox3.ResumeLayout(false);
            this.functionGroupBox3.PerformLayout();
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
        private System.Windows.Forms.Button excelDistintaButton;
        private System.Windows.Forms.GroupBox functionGroupBox4;
        private System.Windows.Forms.PictureBox pictureBoxHigh;
        private System.Windows.Forms.PictureBox pictureBoxDx;
        private System.Windows.Forms.PictureBox pictureBoxSx;
        private System.Windows.Forms.PictureBox pictureBoxCentral;
        private System.Windows.Forms.GroupBox imageFamilyGroupBox;
        private System.Windows.Forms.GroupBox functionGroupBoxListBox;
        private TextBox nameFamilyTextBox;
        private Label nameFamilyLabel;
        private OpenFileDialog uploadExcelOpenFileDialog;
        private TextBox imagesTextBox;
        private Label imagesLabel;
        private Button imagesButton;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}