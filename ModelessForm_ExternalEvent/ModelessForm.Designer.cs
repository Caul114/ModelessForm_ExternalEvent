
using System;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.functionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.imageFamilyGroupBox = new System.Windows.Forms.GroupBox();
            this.magnifyingGlassGroupBox = new System.Windows.Forms.GroupBox();
            this.magnifyingGlassCloseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.magnifyingGlassButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxHigh = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxCentral = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imagesFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.imagesLabel = new System.Windows.Forms.Label();
            this.imagesButton = new System.Windows.Forms.Button();
            this.imagesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBoxDx = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSx = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameFamilyTextBox = new System.Windows.Forms.TextBox();
            this.nameFamilyLabel = new System.Windows.Forms.Label();
            this.captureButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.functionGroupBox2 = new System.Windows.Forms.GroupBox();
            this.functionGroupBoxListBox = new System.Windows.Forms.GroupBox();
            this.functionGroupBox4 = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionGroupBox3 = new System.Windows.Forms.GroupBox();
            this.openExcelDistintaButton = new System.Windows.Forms.Button();
            this.saveExcelDistintabutton = new System.Windows.Forms.Button();
            this.excelDistintaButton = new System.Windows.Forms.Button();
            this.uploadExcelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.functionGroupBox1.SuspendLayout();
            this.imageFamilyGroupBox.SuspendLayout();
            this.magnifyingGlassGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).BeginInit();
            this.imagesFolderGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).BeginInit();
            this.functionGroupBox2.SuspendLayout();
            this.functionGroupBoxListBox.SuspendLayout();
            this.functionGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.functionGroupBox3.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionGroupBox1
            // 
            this.functionGroupBox1.Controls.Add(this.imageFamilyGroupBox);
            this.functionGroupBox1.Controls.Add(this.captureButton);
            this.functionGroupBox1.Location = new System.Drawing.Point(12, 13);
            this.functionGroupBox1.Name = "functionGroupBox1";
            this.functionGroupBox1.Size = new System.Drawing.Size(992, 1002);
            this.functionGroupBox1.TabIndex = 0;
            this.functionGroupBox1.TabStop = false;
            this.functionGroupBox1.Text = "Seleziona un oggetto";
            // 
            // imageFamilyGroupBox
            // 
            this.imageFamilyGroupBox.Controls.Add(this.magnifyingGlassGroupBox);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox3);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox2);
            this.imageFamilyGroupBox.Controls.Add(this.imagesFolderGroupBox);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox4);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox1);
            this.imageFamilyGroupBox.Controls.Add(this.nameFamilyTextBox);
            this.imageFamilyGroupBox.Controls.Add(this.nameFamilyLabel);
            this.imageFamilyGroupBox.Location = new System.Drawing.Point(5, 79);
            this.imageFamilyGroupBox.Name = "imageFamilyGroupBox";
            this.imageFamilyGroupBox.Size = new System.Drawing.Size(981, 917);
            this.imageFamilyGroupBox.TabIndex = 9;
            this.imageFamilyGroupBox.TabStop = false;
            this.imageFamilyGroupBox.Text = "Famiglia dell\'oggetto selezionato";
            // 
            // magnifyingGlassGroupBox
            // 
            this.magnifyingGlassGroupBox.Controls.Add(this.magnifyingGlassCloseButton);
            this.magnifyingGlassGroupBox.Controls.Add(this.label6);
            this.magnifyingGlassGroupBox.Controls.Add(this.label5);
            this.magnifyingGlassGroupBox.Controls.Add(this.magnifyingGlassButton);
            this.magnifyingGlassGroupBox.Location = new System.Drawing.Point(804, 248);
            this.magnifyingGlassGroupBox.Name = "magnifyingGlassGroupBox";
            this.magnifyingGlassGroupBox.Size = new System.Drawing.Size(177, 224);
            this.magnifyingGlassGroupBox.TabIndex = 14;
            this.magnifyingGlassGroupBox.TabStop = false;
            this.magnifyingGlassGroupBox.Text = "Lente d\'ingrandimento";
            // 
            // magnifyingGlassCloseButton
            // 
            this.magnifyingGlassCloseButton.Location = new System.Drawing.Point(43, 158);
            this.magnifyingGlassCloseButton.Name = "magnifyingGlassCloseButton";
            this.magnifyingGlassCloseButton.Size = new System.Drawing.Size(89, 52);
            this.magnifyingGlassCloseButton.TabIndex = 11;
            this.magnifyingGlassCloseButton.Text = "Chiudi";
            this.magnifyingGlassCloseButton.UseVisualStyleBackColor = true;
            this.magnifyingGlassCloseButton.Click += new System.EventHandler(this.magnifyingGlassCloseButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "oppure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Premi \'Esc\' per uscire";
            // 
            // magnifyingGlassButton
            // 
            this.magnifyingGlassButton.Location = new System.Drawing.Point(29, 36);
            this.magnifyingGlassButton.Name = "magnifyingGlassButton";
            this.magnifyingGlassButton.Size = new System.Drawing.Size(118, 70);
            this.magnifyingGlassButton.TabIndex = 8;
            this.magnifyingGlassButton.Text = "Attiva";
            this.magnifyingGlassButton.UseVisualStyleBackColor = true;
            this.magnifyingGlassButton.Click += new System.EventHandler(this.magnifyingGlassButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxHigh);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(413, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 419);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // pictureBoxHigh
            // 
            this.pictureBoxHigh.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxHigh.Name = "pictureBoxHigh";
            this.pictureBoxHigh.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxHigh.TabIndex = 8;
            this.pictureBoxHigh.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Interior View";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxCentral);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 419);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // pictureBoxCentral
            // 
            this.pictureBoxCentral.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxCentral.Name = "pictureBoxCentral";
            this.pictureBoxCentral.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxCentral.TabIndex = 5;
            this.pictureBoxCentral.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Exterior View";
            // 
            // imagesFolderGroupBox
            // 
            this.imagesFolderGroupBox.Controls.Add(this.imagesLabel);
            this.imagesFolderGroupBox.Controls.Add(this.imagesButton);
            this.imagesFolderGroupBox.Controls.Add(this.imagesTextBox);
            this.imagesFolderGroupBox.Location = new System.Drawing.Point(804, 62);
            this.imagesFolderGroupBox.Name = "imagesFolderGroupBox";
            this.imagesFolderGroupBox.Size = new System.Drawing.Size(177, 179);
            this.imagesFolderGroupBox.TabIndex = 13;
            this.imagesFolderGroupBox.TabStop = false;
            this.imagesFolderGroupBox.Text = "Cartella Immagini";
            // 
            // imagesLabel
            // 
            this.imagesLabel.AutoSize = true;
            this.imagesLabel.Location = new System.Drawing.Point(29, 36);
            this.imagesLabel.Name = "imagesLabel";
            this.imagesLabel.Size = new System.Drawing.Size(119, 17);
            this.imagesLabel.TabIndex = 12;
            this.imagesLabel.Text = "Percorso cartella:";
            // 
            // imagesButton
            // 
            this.imagesButton.Location = new System.Drawing.Point(30, 120);
            this.imagesButton.Name = "imagesButton";
            this.imagesButton.Size = new System.Drawing.Size(118, 25);
            this.imagesButton.TabIndex = 8;
            this.imagesButton.Text = "Carica Immagini";
            this.imagesButton.UseVisualStyleBackColor = true;
            this.imagesButton.Click += new System.EventHandler(this.imagesButton_Click);
            // 
            // imagesTextBox
            // 
            this.imagesTextBox.Location = new System.Drawing.Point(19, 66);
            this.imagesTextBox.Name = "imagesTextBox";
            this.imagesTextBox.Size = new System.Drawing.Size(140, 22);
            this.imagesTextBox.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBoxDx);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(413, 487);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 419);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // pictureBoxDx
            // 
            this.pictureBoxDx.Location = new System.Drawing.Point(7, 16);
            this.pictureBoxDx.Name = "pictureBoxDx";
            this.pictureBoxDx.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxDx.TabIndex = 7;
            this.pictureBoxDx.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Right View";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxSx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 419);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // pictureBoxSx
            // 
            this.pictureBoxSx.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxSx.Name = "pictureBoxSx";
            this.pictureBoxSx.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxSx.TabIndex = 6;
            this.pictureBoxSx.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Left View";
            // 
            // nameFamilyTextBox
            // 
            this.nameFamilyTextBox.Location = new System.Drawing.Point(413, 33);
            this.nameFamilyTextBox.Name = "nameFamilyTextBox";
            this.nameFamilyTextBox.Size = new System.Drawing.Size(246, 22);
            this.nameFamilyTextBox.TabIndex = 10;
            // 
            // nameFamilyLabel
            // 
            this.nameFamilyLabel.AutoSize = true;
            this.nameFamilyLabel.Location = new System.Drawing.Point(184, 36);
            this.nameFamilyLabel.Name = "nameFamilyLabel";
            this.nameFamilyLabel.Size = new System.Drawing.Size(215, 17);
            this.nameFamilyLabel.TabIndex = 10;
            this.nameFamilyLabel.Text = "Nome della Famiglia selezionata:";
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(14, 21);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(972, 43);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "Cattura un oggetto";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 740);
            this.listBox1.TabIndex = 2;
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(30, 31);
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
            this.functionGroupBox2.Location = new System.Drawing.Point(1010, 80);
            this.functionGroupBox2.Name = "functionGroupBox2";
            this.functionGroupBox2.Size = new System.Drawing.Size(883, 935);
            this.functionGroupBox2.TabIndex = 1;
            this.functionGroupBox2.TabStop = false;
            this.functionGroupBox2.Text = "Parametri della Distinta";
            // 
            // functionGroupBoxListBox
            // 
            this.functionGroupBoxListBox.Controls.Add(this.listBox1);
            this.functionGroupBoxListBox.Location = new System.Drawing.Point(702, 14);
            this.functionGroupBoxListBox.Name = "functionGroupBoxListBox";
            this.functionGroupBoxListBox.Size = new System.Drawing.Size(175, 791);
            this.functionGroupBoxListBox.TabIndex = 7;
            this.functionGroupBoxListBox.TabStop = false;
            this.functionGroupBoxListBox.Text = "Dimensioni della Cell";
            // 
            // functionGroupBox4
            // 
            this.functionGroupBox4.Controls.Add(this.cleanButton);
            this.functionGroupBox4.Controls.Add(this.exitButton);
            this.functionGroupBox4.Location = new System.Drawing.Point(702, 809);
            this.functionGroupBox4.Name = "functionGroupBox4";
            this.functionGroupBox4.Size = new System.Drawing.Size(175, 109);
            this.functionGroupBox4.TabIndex = 6;
            this.functionGroupBox4.TabStop = false;
            this.functionGroupBox4.Text = "Utilità";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(30, 65);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(13, 21);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 897);
            this.dataGridView1.TabIndex = 0;
            // 
            // functionGroupBox3
            // 
            this.functionGroupBox3.Controls.Add(this.label7);
            this.functionGroupBox3.Controls.Add(this.openExcelDistintaButton);
            this.functionGroupBox3.Controls.Add(this.saveExcelDistintabutton);
            this.functionGroupBox3.Controls.Add(this.excelDistintaButton);
            this.functionGroupBox3.Controls.Add(this.comboBox1);
            this.functionGroupBox3.Location = new System.Drawing.Point(1010, 13);
            this.functionGroupBox3.Name = "functionGroupBox3";
            this.functionGroupBox3.Size = new System.Drawing.Size(726, 57);
            this.functionGroupBox3.TabIndex = 2;
            this.functionGroupBox3.TabStop = false;
            this.functionGroupBox3.Text = "Mostra Distinta";
            // 
            // openExcelDistintaButton
            // 
            this.openExcelDistintaButton.Location = new System.Drawing.Point(635, 20);
            this.openExcelDistintaButton.Name = "openExcelDistintaButton";
            this.openExcelDistintaButton.Size = new System.Drawing.Size(77, 25);
            this.openExcelDistintaButton.TabIndex = 9;
            this.openExcelDistintaButton.Text = "Apri";
            this.openExcelDistintaButton.UseVisualStyleBackColor = true;
            this.openExcelDistintaButton.Click += new System.EventHandler(this.openExcelDistintaButton_Click);
            // 
            // saveExcelDistintabutton
            // 
            this.saveExcelDistintabutton.Location = new System.Drawing.Point(552, 20);
            this.saveExcelDistintabutton.Name = "saveExcelDistintabutton";
            this.saveExcelDistintabutton.Size = new System.Drawing.Size(77, 25);
            this.saveExcelDistintabutton.TabIndex = 8;
            this.saveExcelDistintabutton.Text = "Salva";
            this.saveExcelDistintabutton.UseVisualStyleBackColor = true;
            this.saveExcelDistintabutton.Click += new System.EventHandler(this.saveExcelDistintabutton_Click);
            // 
            // excelDistintaButton
            // 
            this.excelDistintaButton.Location = new System.Drawing.Point(281, 20);
            this.excelDistintaButton.Name = "excelDistintaButton";
            this.excelDistintaButton.Size = new System.Drawing.Size(81, 25);
            this.excelDistintaButton.TabIndex = 7;
            this.excelDistintaButton.Text = "Sfoglia";
            this.excelDistintaButton.UseVisualStyleBackColor = true;
            this.excelDistintaButton.Click += new System.EventHandler(this.excelDistintaButton_Click);
            // 
            // uploadExcelOpenFileDialog
            // 
            this.uploadExcelOpenFileDialog.DefaultExt = "xlsx";
            this.uploadExcelOpenFileDialog.FileName = "AbacoCells";
            this.uploadExcelOpenFileDialog.Filter = "File Excel (*.xlsx,*.xlsm)|*.xlsx;*.xlsm";
            this.uploadExcelOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\DataCell";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Scegli la Directory da cui vuoi prendere le immagini.";
            this.folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\DataCell\Images";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.settingsButton);
            this.settingsGroupBox.Location = new System.Drawing.Point(1742, 13);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(140, 57);
            this.settingsGroupBox.TabIndex = 3;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Impostazioni";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(31, 20);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(77, 30);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.Text = "Modifica";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Operazioni sul foglio Excel:";
            // 
            // ModelessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 1027);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.functionGroupBox2);
            this.Controls.Add(this.functionGroupBox1);
            this.Controls.Add(this.functionGroupBox3);
            this.Name = "ModelessForm";
            this.Text = "BOLD DataCell";
            this.Load += new System.EventHandler(this.ModelessForm_Load);
            this.functionGroupBox1.ResumeLayout(false);
            this.imageFamilyGroupBox.ResumeLayout(false);
            this.imageFamilyGroupBox.PerformLayout();
            this.magnifyingGlassGroupBox.ResumeLayout(false);
            this.magnifyingGlassGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).EndInit();
            this.imagesFolderGroupBox.ResumeLayout(false);
            this.imagesFolderGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).EndInit();
            this.functionGroupBox2.ResumeLayout(false);
            this.functionGroupBoxListBox.ResumeLayout(false);
            this.functionGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.functionGroupBox3.ResumeLayout(false);
            this.functionGroupBox3.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox functionGroupBox3;
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
        private GroupBox imagesFolderGroupBox;
        private GroupBox groupBox3;
        private Label label4;
        private GroupBox groupBox2;
        private Label label1;
        private GroupBox groupBox4;
        private Label label3;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox magnifyingGlassGroupBox;
        private Label label5;
        private Button magnifyingGlassButton;
        private Button magnifyingGlassCloseButton;
        private Label label6;
        private Button openExcelDistintaButton;
        private Button saveExcelDistintabutton;
        private Label label7;
        private GroupBox settingsGroupBox;
        private Button settingsButton;
    }
}