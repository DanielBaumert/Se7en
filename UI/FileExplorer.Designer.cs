namespace Se7en.UI
{
    partial class FileExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox2 = new Se7en.UI.TextBox();
            this.textBox3 = new Se7en.UI.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.AutoScaleByText = false;
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox2.CompareWith = null;
            this.textBox2.CueText = "Path";
            this.textBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox2.IsntInput = null;
            this.textBox2.LineColor = System.Drawing.Color.DodgerBlue;
            this.textBox2.LineHeight = 2;
            this.textBox2.LineMarginHorizontal = 0;
            this.textBox2.LineMarginLeft = 0;
            this.textBox2.LineMarginRight = 0;
            this.textBox2.LineMarginToText = 1;
            this.textBox2.Location = new System.Drawing.Point(375, 416);
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.textBox2.PasswortChar = '\0';
            this.textBox2.Patter = null;
            this.textBox2.PatterError = System.Drawing.Color.Red;
            this.textBox2.Size = new System.Drawing.Size(158, 17);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = null;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox2.UseSystemPasswordChar = false;
            // 
            // textBox3
            // 
            this.textBox3.AutoScaleByText = false;
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox3.CompareWith = null;
            this.textBox3.CueText = "Suche";
            this.textBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox3.IsntInput = null;
            this.textBox3.LineColor = System.Drawing.Color.DodgerBlue;
            this.textBox3.LineHeight = 2;
            this.textBox3.LineMarginHorizontal = 0;
            this.textBox3.LineMarginLeft = 0;
            this.textBox3.LineMarginRight = 0;
            this.textBox3.LineMarginToText = 1;
            this.textBox3.Location = new System.Drawing.Point(523, 6);
            this.textBox3.Multiline = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.textBox3.PasswortChar = '\0';
            this.textBox3.Patter = null;
            this.textBox3.PatterError = System.Drawing.Color.Red;
            this.textBox3.Size = new System.Drawing.Size(213, 17);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = null;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox3.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 28);
            this.panel1.TabIndex = 6;
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Name = "FileExplorer";
            this.Text = "FileExplorer";
            this.Load += new System.EventHandler(this.FileExplorer_Load);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox2;
        private TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
    }
}