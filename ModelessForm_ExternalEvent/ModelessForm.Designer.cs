
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
            this.cleanButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.functionGroupBox2 = new System.Windows.Forms.GroupBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionGroupBox3 = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.functionGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.functionGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.functionGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionGroupBox1
            // 
            this.functionGroupBox1.Controls.Add(this.cleanButton);
            this.functionGroupBox1.Controls.Add(this.listBox1);
            this.functionGroupBox1.Controls.Add(this.captureButton);
            this.functionGroupBox1.Location = new System.Drawing.Point(12, 271);
            this.functionGroupBox1.Name = "functionGroupBox1";
            this.functionGroupBox1.Size = new System.Drawing.Size(293, 168);
            this.functionGroupBox1.TabIndex = 0;
            this.functionGroupBox1.TabStop = false;
            this.functionGroupBox1.Text = "Selezione dell\'elemento";
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(170, 134);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(117, 28);
            this.cleanButton.TabIndex = 3;
            this.cleanButton.Text = "Cancella";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 52);
            this.listBox1.TabIndex = 2;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(6, 21);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(280, 43);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "Cattura un oggetto";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 158);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(280, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "<- Scegli un File Excel da caricare ->";
            // 
            // functionGroupBox2
            // 
            this.functionGroupBox2.Controls.Add(this.importButton);
            this.functionGroupBox2.Controls.Add(this.exportButton);
            this.functionGroupBox2.Controls.Add(this.exitButton);
            this.functionGroupBox2.Controls.Add(this.dataGridView1);
            this.functionGroupBox2.Location = new System.Drawing.Point(330, 13);
            this.functionGroupBox2.Name = "functionGroupBox2";
            this.functionGroupBox2.Size = new System.Drawing.Size(859, 426);
            this.functionGroupBox2.TabIndex = 1;
            this.functionGroupBox2.TabStop = false;
            this.functionGroupBox2.Text = "Elenco degli elementi";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(140, 392);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(117, 28);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Importa";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(7, 392);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(117, 28);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Esporta..";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(735, 392);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(117, 28);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Esci";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(845, 363);
            this.dataGridView1.TabIndex = 0;
            // 
            // functionGroupBox3
            // 
            this.functionGroupBox3.Controls.Add(this.comboBox1);
            this.functionGroupBox3.Controls.Add(this.loadButton);
            this.functionGroupBox3.Controls.Add(this.pictureBox1);
            this.functionGroupBox3.Location = new System.Drawing.Point(12, 13);
            this.functionGroupBox3.Name = "functionGroupBox3";
            this.functionGroupBox3.Size = new System.Drawing.Size(293, 252);
            this.functionGroupBox3.TabIndex = 2;
            this.functionGroupBox3.TabStop = false;
            this.functionGroupBox3.Text = "Mostra file Excel";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(212, 52);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 28);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Mostra";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // ModelessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 451);
            this.Controls.Add(this.functionGroupBox3);
            this.Controls.Add(this.functionGroupBox2);
            this.Controls.Add(this.functionGroupBox1);
            this.Name = "ModelessForm";
            this.Text = "ModelessForm";
            this.Load += new System.EventHandler(this.ModelessForm_Load);
            this.functionGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.functionGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.functionGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox functionGroupBox1;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.GroupBox functionGroupBox2;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox functionGroupBox3;
        private System.Windows.Forms.Button loadButton;
    }
}