
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelessForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.functionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.nameProjectTextBox = new System.Windows.Forms.TextBox();
            this.nameProjectButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nrPositionalPanelsTextBox = new System.Windows.Forms.TextBox();
            this.nrCellPanelsTextBox = new System.Windows.Forms.TextBox();
            this.nrTypologiePanelsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.typologyTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.unitIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.panelTypeIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.captureButton = new System.Windows.Forms.Button();
            this.imageFamilyGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nameFamilyTextBox = new System.Windows.Forms.TextBox();
            this.magnifyingGlassGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.magnifyingGlassCloseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.magnifyingGlassButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxHigh = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxCentral = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBoxDx = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSx = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.functionGroupBox2 = new System.Windows.Forms.GroupBox();
            this.toggle_Switch1 = new ModelessForm_ExternalEvent.ToggleSwitch.Toggle_Switch();
            this.label11 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.functionGroupBoxListBox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveExcelDistintabutton = new System.Windows.Forms.Button();
            this.openExcelDistintaButton = new System.Windows.Forms.Button();
            this.functionGroupBox4 = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionGroupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uploadExcelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.functionGroupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.imageFamilyGroupBox.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.magnifyingGlassGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).BeginInit();
            this.functionGroupBox2.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.functionGroupBoxListBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.functionGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.functionGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionGroupBox1
            // 
            this.functionGroupBox1.Controls.Add(this.groupBox8);
            this.functionGroupBox1.Controls.Add(this.groupBox7);
            this.functionGroupBox1.Controls.Add(this.captureButton);
            this.functionGroupBox1.Controls.Add(this.imageFamilyGroupBox);
            this.functionGroupBox1.Location = new System.Drawing.Point(12, 13);
            this.functionGroupBox1.Name = "functionGroupBox1";
            this.functionGroupBox1.Size = new System.Drawing.Size(992, 1002);
            this.functionGroupBox1.TabIndex = 0;
            this.functionGroupBox1.TabStop = false;
            this.functionGroupBox1.Text = "Seleziona un oggetto";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox8.Controls.Add(this.nameProjectTextBox);
            this.groupBox8.Controls.Add(this.nameProjectButton);
            this.groupBox8.Location = new System.Drawing.Point(372, 21);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(158, 95);
            this.groupBox8.TabIndex = 28;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Progetto";
            // 
            // nameProjectTextBox
            // 
            this.nameProjectTextBox.BackColor = System.Drawing.Color.Lavender;
            this.nameProjectTextBox.Location = new System.Drawing.Point(8, 26);
            this.nameProjectTextBox.Name = "nameProjectTextBox";
            this.nameProjectTextBox.ReadOnly = true;
            this.nameProjectTextBox.Size = new System.Drawing.Size(144, 22);
            this.nameProjectTextBox.TabIndex = 2;
            this.nameProjectTextBox.Text = " -";
            // 
            // nameProjectButton
            // 
            this.nameProjectButton.Location = new System.Drawing.Point(8, 54);
            this.nameProjectButton.Name = "nameProjectButton";
            this.nameProjectButton.Size = new System.Drawing.Size(144, 31);
            this.nameProjectButton.TabIndex = 1;
            this.nameProjectButton.Text = "Inserisci";
            this.nameProjectButton.UseVisualStyleBackColor = true;
            this.nameProjectButton.Click += new System.EventHandler(this.nameProjectButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.nrPositionalPanelsTextBox);
            this.groupBox7.Controls.Add(this.nrCellPanelsTextBox);
            this.groupBox7.Controls.Add(this.nrTypologiePanelsTextBox);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.typologyTextBox);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.unitIdentifierTextBox);
            this.groupBox7.Controls.Add(this.panelTypeIdentifierTextBox);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new System.Drawing.Point(536, 21);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(450, 94);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 32;
            this.label14.Text = "Nr pannelli:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(330, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 31;
            this.label13.Text = "Nr pannelli:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(330, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Nr pannelli:";
            // 
            // nrPositionalPanelsTextBox
            // 
            this.nrPositionalPanelsTextBox.Location = new System.Drawing.Point(410, 65);
            this.nrPositionalPanelsTextBox.Name = "nrPositionalPanelsTextBox";
            this.nrPositionalPanelsTextBox.ReadOnly = true;
            this.nrPositionalPanelsTextBox.Size = new System.Drawing.Size(30, 22);
            this.nrPositionalPanelsTextBox.TabIndex = 29;
            // 
            // nrCellPanelsTextBox
            // 
            this.nrCellPanelsTextBox.Location = new System.Drawing.Point(410, 41);
            this.nrCellPanelsTextBox.Name = "nrCellPanelsTextBox";
            this.nrCellPanelsTextBox.ReadOnly = true;
            this.nrCellPanelsTextBox.Size = new System.Drawing.Size(30, 22);
            this.nrCellPanelsTextBox.TabIndex = 28;
            // 
            // nrTypologiePanelsTextBox
            // 
            this.nrTypologiePanelsTextBox.Location = new System.Drawing.Point(410, 15);
            this.nrTypologiePanelsTextBox.Name = "nrTypologiePanelsTextBox";
            this.nrTypologiePanelsTextBox.ReadOnly = true;
            this.nrTypologiePanelsTextBox.Size = new System.Drawing.Size(30, 22);
            this.nrTypologiePanelsTextBox.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Codice Gruppo:";
            // 
            // typologyTextBox
            // 
            this.typologyTextBox.Location = new System.Drawing.Point(156, 15);
            this.typologyTextBox.Name = "typologyTextBox";
            this.typologyTextBox.ReadOnly = true;
            this.typologyTextBox.Size = new System.Drawing.Size(164, 22);
            this.typologyTextBox.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Codice Elemento:";
            // 
            // unitIdentifierTextBox
            // 
            this.unitIdentifierTextBox.Location = new System.Drawing.Point(156, 65);
            this.unitIdentifierTextBox.Name = "unitIdentifierTextBox";
            this.unitIdentifierTextBox.ReadOnly = true;
            this.unitIdentifierTextBox.Size = new System.Drawing.Size(164, 22);
            this.unitIdentifierTextBox.TabIndex = 21;
            // 
            // panelTypeIdentifierTextBox
            // 
            this.panelTypeIdentifierTextBox.Location = new System.Drawing.Point(156, 40);
            this.panelTypeIdentifierTextBox.Name = "panelTypeIdentifierTextBox";
            this.panelTypeIdentifierTextBox.ReadOnly = true;
            this.panelTypeIdentifierTextBox.Size = new System.Drawing.Size(164, 22);
            this.panelTypeIdentifierTextBox.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Codice Oggetto:";
            // 
            // captureButton
            // 
            this.captureButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.captureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.captureButton.Location = new System.Drawing.Point(10, 24);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(353, 88);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "Cattura un oggetto";
            this.captureButton.UseVisualStyleBackColor = false;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // imageFamilyGroupBox
            // 
            this.imageFamilyGroupBox.Controls.Add(this.groupBox6);
            this.imageFamilyGroupBox.Controls.Add(this.magnifyingGlassGroupBox);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox3);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox2);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox4);
            this.imageFamilyGroupBox.Controls.Add(this.groupBox1);
            this.imageFamilyGroupBox.Location = new System.Drawing.Point(5, 116);
            this.imageFamilyGroupBox.Name = "imageFamilyGroupBox";
            this.imageFamilyGroupBox.Size = new System.Drawing.Size(981, 878);
            this.imageFamilyGroupBox.TabIndex = 9;
            this.imageFamilyGroupBox.TabStop = false;
            this.imageFamilyGroupBox.Text = "Famiglia dell\'oggetto selezionato";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nameFamilyTextBox);
            this.groupBox6.Location = new System.Drawing.Point(6, 27);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(184, 63);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Famiglia di Revit";
            // 
            // nameFamilyTextBox
            // 
            this.nameFamilyTextBox.Location = new System.Drawing.Point(13, 26);
            this.nameFamilyTextBox.Name = "nameFamilyTextBox";
            this.nameFamilyTextBox.ReadOnly = true;
            this.nameFamilyTextBox.Size = new System.Drawing.Size(162, 22);
            this.nameFamilyTextBox.TabIndex = 10;
            // 
            // magnifyingGlassGroupBox
            // 
            this.magnifyingGlassGroupBox.Controls.Add(this.label10);
            this.magnifyingGlassGroupBox.Controls.Add(this.magnifyingGlassCloseButton);
            this.magnifyingGlassGroupBox.Controls.Add(this.label5);
            this.magnifyingGlassGroupBox.Controls.Add(this.magnifyingGlassButton);
            this.magnifyingGlassGroupBox.Location = new System.Drawing.Point(6, 96);
            this.magnifyingGlassGroupBox.Name = "magnifyingGlassGroupBox";
            this.magnifyingGlassGroupBox.Size = new System.Drawing.Size(184, 301);
            this.magnifyingGlassGroupBox.TabIndex = 14;
            this.magnifyingGlassGroupBox.TabStop = false;
            this.magnifyingGlassGroupBox.Text = "Lente d\'ingrandimento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Clicca per attivarla";
            // 
            // magnifyingGlassCloseButton
            // 
            this.magnifyingGlassCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("magnifyingGlassCloseButton.Image")));
            this.magnifyingGlassCloseButton.Location = new System.Drawing.Point(61, 208);
            this.magnifyingGlassCloseButton.Name = "magnifyingGlassCloseButton";
            this.magnifyingGlassCloseButton.Size = new System.Drawing.Size(52, 52);
            this.magnifyingGlassCloseButton.TabIndex = 11;
            this.magnifyingGlassCloseButton.UseVisualStyleBackColor = true;
            this.magnifyingGlassCloseButton.Click += new System.EventHandler(this.magnifyingGlassCloseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clicca per spegnerla";
            // 
            // magnifyingGlassButton
            // 
            this.magnifyingGlassButton.Image = ((System.Drawing.Image)(resources.GetObject("magnifyingGlassButton.Image")));
            this.magnifyingGlassButton.Location = new System.Drawing.Point(54, 84);
            this.magnifyingGlassButton.Name = "magnifyingGlassButton";
            this.magnifyingGlassButton.Size = new System.Drawing.Size(65, 70);
            this.magnifyingGlassButton.TabIndex = 8;
            this.magnifyingGlassButton.UseVisualStyleBackColor = true;
            this.magnifyingGlassButton.Click += new System.EventHandler(this.magnifyingGlassButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxHigh);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(588, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 419);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // pictureBoxHigh
            // 
            this.pictureBoxHigh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxHigh.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxHigh.Name = "pictureBoxHigh";
            this.pictureBoxHigh.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxHigh.TabIndex = 8;
            this.pictureBoxHigh.TabStop = false;
            this.pictureBoxHigh.MouseEnter += new System.EventHandler(this.pictureBoxHigh_GlassButton_Enter);
            this.pictureBoxHigh.MouseLeave += new System.EventHandler(this.pictureBoxHigh_GlassButton_Leave);
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
            this.groupBox2.Location = new System.Drawing.Point(196, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 419);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // pictureBoxCentral
            // 
            this.pictureBoxCentral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCentral.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxCentral.Name = "pictureBoxCentral";
            this.pictureBoxCentral.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxCentral.TabIndex = 5;
            this.pictureBoxCentral.TabStop = false;
            this.pictureBoxCentral.MouseEnter += new System.EventHandler(this.pictureBoxCentral_GlassButton_Enter);
            this.pictureBoxCentral.MouseLeave += new System.EventHandler(this.pictureBoxCentral_GlassButton_Leave);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBoxDx);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(588, 452);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 419);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // pictureBoxDx
            // 
            this.pictureBoxDx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDx.Location = new System.Drawing.Point(7, 16);
            this.pictureBoxDx.Name = "pictureBoxDx";
            this.pictureBoxDx.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxDx.TabIndex = 7;
            this.pictureBoxDx.TabStop = false;
            this.pictureBoxDx.MouseEnter += new System.EventHandler(this.pictureBoxDx_GlassButton_Enter);
            this.pictureBoxDx.MouseLeave += new System.EventHandler(this.pictureBoxDx_GlassButton_Leave);
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
            this.groupBox1.Location = new System.Drawing.Point(196, 452);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 419);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // pictureBoxSx
            // 
            this.pictureBoxSx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxSx.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxSx.Name = "pictureBoxSx";
            this.pictureBoxSx.Size = new System.Drawing.Size(372, 372);
            this.pictureBoxSx.TabIndex = 6;
            this.pictureBoxSx.TabStop = false;
            this.pictureBoxSx.MouseEnter += new System.EventHandler(this.pictureBoxSx_GlassButton_Enter);
            this.pictureBoxSx.MouseLeave += new System.EventHandler(this.pictureBoxSx_GlassButton_Leave);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 820);
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
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // functionGroupBox2
            // 
            this.functionGroupBox2.Controls.Add(this.toggle_Switch1);
            this.functionGroupBox2.Controls.Add(this.label11);
            this.functionGroupBox2.Controls.Add(this.settingsGroupBox);
            this.functionGroupBox2.Controls.Add(this.functionGroupBoxListBox);
            this.functionGroupBox2.Controls.Add(this.groupBox5);
            this.functionGroupBox2.Controls.Add(this.functionGroupBox4);
            this.functionGroupBox2.Controls.Add(this.dataGridView1);
            this.functionGroupBox2.Controls.Add(this.functionGroupBox3);
            this.functionGroupBox2.Location = new System.Drawing.Point(1010, 13);
            this.functionGroupBox2.Name = "functionGroupBox2";
            this.functionGroupBox2.Size = new System.Drawing.Size(883, 1002);
            this.functionGroupBox2.TabIndex = 1;
            this.functionGroupBox2.TabStop = false;
            this.functionGroupBox2.Text = "Parametri della Distinta";
            // 
            // toggle_Switch1
            // 
            this.toggle_Switch1.BorderColor = System.Drawing.Color.LightGray;
            this.toggle_Switch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggle_Switch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggle_Switch1.ForeColor = System.Drawing.Color.Black;
            this.toggle_Switch1.IsOn = false;
            this.toggle_Switch1.Location = new System.Drawing.Point(628, 11);
            this.toggle_Switch1.Name = "toggle_Switch1";
            this.toggle_Switch1.OffColor = System.Drawing.Color.DarkGray;
            this.toggle_Switch1.OffText = "OFF";
            this.toggle_Switch1.OnColor = System.Drawing.SystemColors.Highlight;
            this.toggle_Switch1.OnText = "ON";
            this.toggle_Switch1.Size = new System.Drawing.Size(62, 33);
            this.toggle_Switch1.TabIndex = 11;
            this.toggle_Switch1.Text = "toggle_Switch1";
            this.toggle_Switch1.TextEnabled = true;
            this.toggle_Switch1.Click += new System.EventHandler(this.toggle_Switch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(324, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Clicca per visualizzare i valori in formato numerico";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.settingsButton);
            this.settingsGroupBox.Location = new System.Drawing.Point(595, 911);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(100, 85);
            this.settingsGroupBox.TabIndex = 3;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Impostazioni";
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(31, 29);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(38, 39);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // functionGroupBoxListBox
            // 
            this.functionGroupBoxListBox.Controls.Add(this.listBox1);
            this.functionGroupBoxListBox.Location = new System.Drawing.Point(702, 14);
            this.functionGroupBoxListBox.Name = "functionGroupBoxListBox";
            this.functionGroupBoxListBox.Size = new System.Drawing.Size(175, 867);
            this.functionGroupBoxListBox.TabIndex = 7;
            this.functionGroupBoxListBox.TabStop = false;
            this.functionGroupBoxListBox.Text = "Dimensioni dell\'oggetto";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveExcelDistintabutton);
            this.groupBox5.Controls.Add(this.openExcelDistintaButton);
            this.groupBox5.Location = new System.Drawing.Point(454, 911);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(134, 85);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Documento Excel";
            // 
            // saveExcelDistintabutton
            // 
            this.saveExcelDistintabutton.Location = new System.Drawing.Point(7, 29);
            this.saveExcelDistintabutton.Name = "saveExcelDistintabutton";
            this.saveExcelDistintabutton.Size = new System.Drawing.Size(77, 39);
            this.saveExcelDistintabutton.TabIndex = 8;
            this.saveExcelDistintabutton.Text = "Salva";
            this.saveExcelDistintabutton.UseVisualStyleBackColor = true;
            this.saveExcelDistintabutton.Click += new System.EventHandler(this.saveExcelDistintabutton_Click);
            // 
            // openExcelDistintaButton
            // 
            this.openExcelDistintaButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openExcelDistintaButton.Image = ((System.Drawing.Image)(resources.GetObject("openExcelDistintaButton.Image")));
            this.openExcelDistintaButton.Location = new System.Drawing.Point(90, 29);
            this.openExcelDistintaButton.Name = "openExcelDistintaButton";
            this.openExcelDistintaButton.Size = new System.Drawing.Size(38, 39);
            this.openExcelDistintaButton.TabIndex = 9;
            this.openExcelDistintaButton.UseVisualStyleBackColor = false;
            this.openExcelDistintaButton.Click += new System.EventHandler(this.openExcelDistintaButton_Click);
            // 
            // functionGroupBox4
            // 
            this.functionGroupBox4.Controls.Add(this.cleanButton);
            this.functionGroupBox4.Controls.Add(this.exitButton);
            this.functionGroupBox4.Location = new System.Drawing.Point(702, 887);
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(13, 47);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MintCream;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 857);
            this.dataGridView1.TabIndex = 0;
            // 
            // functionGroupBox3
            // 
            this.functionGroupBox3.Controls.Add(this.label6);
            this.functionGroupBox3.Controls.Add(this.comboBox1);
            this.functionGroupBox3.Location = new System.Drawing.Point(13, 911);
            this.functionGroupBox3.Name = "functionGroupBox3";
            this.functionGroupBox3.Size = new System.Drawing.Size(435, 85);
            this.functionGroupBox3.TabIndex = 2;
            this.functionGroupBox3.TabStop = false;
            this.functionGroupBox3.Text = "Mostra il foglio Excel, il cui nome corrisponde al Codice Gruppo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Foglio Excel:";
            // 
            // uploadExcelOpenFileDialog
            // 
            this.uploadExcelOpenFileDialog.DefaultExt = "xlsx";
            this.uploadExcelOpenFileDialog.FileName = "AbacoCells";
            this.uploadExcelOpenFileDialog.Filter = "File Excel (*.xlsx,*.xlsm)|*.xlsx;*.xlsm";
            this.uploadExcelOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BOLD Software\\DataQuery";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Scegli la Directory da cui vuoi prendere le immagini.";
            this.folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BOLD Software\\DataQuery\\Images";
            // 
            // ModelessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 1027);
            this.Controls.Add(this.functionGroupBox2);
            this.Controls.Add(this.functionGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModelessForm";
            this.Text = "BOLD - DataQuery";
            this.Load += new System.EventHandler(this.ModelessForm_Load);
            this.functionGroupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.imageFamilyGroupBox.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.magnifyingGlassGroupBox.ResumeLayout(false);
            this.magnifyingGlassGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHigh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCentral)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDx)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSx)).EndInit();
            this.functionGroupBox2.ResumeLayout(false);
            this.functionGroupBox2.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.functionGroupBoxListBox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox functionGroupBox3;
        private System.Windows.Forms.GroupBox functionGroupBox4;
        private System.Windows.Forms.PictureBox pictureBoxHigh;
        private System.Windows.Forms.PictureBox pictureBoxDx;
        private System.Windows.Forms.PictureBox pictureBoxSx;
        private System.Windows.Forms.PictureBox pictureBoxCentral;
        private System.Windows.Forms.GroupBox imageFamilyGroupBox;
        private System.Windows.Forms.GroupBox functionGroupBoxListBox;
        private TextBox nameFamilyTextBox;
        private OpenFileDialog uploadExcelOpenFileDialog;
        private FolderBrowserDialog folderBrowserDialog1;
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
        private Button openExcelDistintaButton;
        private Button saveExcelDistintabutton;
        private GroupBox settingsGroupBox;
        private Button settingsButton;
        private TextBox panelTypeIdentifierTextBox;
        private Label label9;
        private TextBox unitIdentifierTextBox;
        private Label label8;
        private Label label10;
        private GroupBox groupBox5;
        private Label label6;
        private TextBox typologyTextBox;
        private Label label7;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private Label label11;
        private ToggleSwitch.Toggle_Switch toggle_Switch1;
        private Label label14;
        private Label label13;
        private Label label12;
        private TextBox nrPositionalPanelsTextBox;
        private TextBox nrCellPanelsTextBox;
        private TextBox nrTypologiePanelsTextBox;
        private GroupBox groupBox8;
        private Button nameProjectButton;
        private TextBox nameProjectTextBox;
    }
}