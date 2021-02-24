
namespace ToggleSwitch
{
    partial class Form1
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
            this.toggle_Switch1 = new ToggleSwitch.Toggle_Switch();
            this.SuspendLayout();
            // 
            // toggle_Switch1
            // 
            this.toggle_Switch1.BorderColor = System.Drawing.Color.LightGray;
            this.toggle_Switch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggle_Switch1.ForeColor = System.Drawing.Color.White;
            this.toggle_Switch1.IsOn = false;
            this.toggle_Switch1.Location = new System.Drawing.Point(256, 123);
            this.toggle_Switch1.Name = "toggle_Switch1";
            this.toggle_Switch1.OffColor = System.Drawing.Color.DarkGray;
            this.toggle_Switch1.OffText = "OFF";
            this.toggle_Switch1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggle_Switch1.OnText = "ON";
            this.toggle_Switch1.Size = new System.Drawing.Size(220, 112);
            this.toggle_Switch1.TabIndex = 0;
            this.toggle_Switch1.Text = "toggle_Switch1";
            this.toggle_Switch1.TextEnabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toggle_Switch1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Toggle_Switch toggle_Switch1;
    }
}

