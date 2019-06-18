namespace Se7en.UI {
    partial class WinFrom {
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
            Se7en.UI.ColorFadeItem colorFadeItem1 = new Se7en.UI.ColorFadeItem();
            Se7en.UI.ColorFadeItem colorFadeItem2 = new Se7en.UI.ColorFadeItem();
            this.Lb_WinFormTitle = new System.Windows.Forms.Label();
            this.Bt_WinFromClose = new Se7en.UI.CloseButton();
            this.smoothLine1 = new Se7en.UI.SmoothLine();
            Pl_WinForm = new System.Windows.Forms.Panel();
            Pl_WinForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lb_WinFormTitle
            // 
            this.Lb_WinFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.Lb_WinFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_WinFormTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lb_WinFormTitle.Font = new System.Drawing.Font("Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_WinFormTitle.ForeColor = System.Drawing.Color.White;
            this.Lb_WinFormTitle.Location = new System.Drawing.Point(0, 0);
            this.Lb_WinFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_WinFormTitle.Name = "Lb_WinFormTitle";
            this.Lb_WinFormTitle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.Lb_WinFormTitle.Size = new System.Drawing.Size(573, 26);
            this.Lb_WinFormTitle.TabIndex = 1;
            this.Lb_WinFormTitle.Text = "label1";
            this.Lb_WinFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bt_WinFromClose
            // 
            this.Bt_WinFromClose.CrossWidth = 3;
            this.Bt_WinFromClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bt_WinFromClose.ForeColor = System.Drawing.Color.White;
            this.Bt_WinFromClose.HoverEffect = System.Drawing.Color.DarkRed;
            this.Bt_WinFromClose.HoverScaleOutWidth = 7;
            this.Bt_WinFromClose.Location = new System.Drawing.Point(573, 0);
            this.Bt_WinFromClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Bt_WinFromClose.Name = "Bt_WinFromClose";
            this.Bt_WinFromClose.Padding = new System.Windows.Forms.Padding(11, 9, 11, 9);
            this.Bt_WinFromClose.ScaleOutHoverEffect = false;
            this.Bt_WinFromClose.Size = new System.Drawing.Size(30, 26);
            this.Bt_WinFromClose.TabIndex = 0;
            this.Bt_WinFromClose.Click += new System.EventHandler(this.Bt_WinFromClose_Click);
            // 
            // smoothLine1
            // 
            colorFadeItem1.Color = System.Drawing.Color.DodgerBlue;
            colorFadeItem1.Position = 0F;
            colorFadeItem2.Color = System.Drawing.Color.DeepSkyBlue;
            colorFadeItem2.Position = 1F;
            this.smoothLine1.Colors = new Se7en.UI.ColorFadeItem[] {
        colorFadeItem1,
        colorFadeItem2};
            this.smoothLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smoothLine1.Location = new System.Drawing.Point(0, 0);
            this.smoothLine1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.smoothLine1.Name = "smoothLine1";
            this.smoothLine1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.smoothLine1.Size = new System.Drawing.Size(603, 2);
            this.smoothLine1.TabIndex = 1;
            // 
            // Pl_WinForm
            // 
            Pl_WinForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            Pl_WinForm.Controls.Add(this.Lb_WinFormTitle);
            Pl_WinForm.Controls.Add(this.Bt_WinFromClose);
            Pl_WinForm.Dock = System.Windows.Forms.DockStyle.Top;
            Pl_WinForm.Enabled = false;
            Pl_WinForm.ImeMode = System.Windows.Forms.ImeMode.Off;
            Pl_WinForm.Location = new System.Drawing.Point(0, 2);
            Pl_WinForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Pl_WinForm.Name = "Pl_WinForm";
            Pl_WinForm.Size = new System.Drawing.Size(603, 26);
            Pl_WinForm.TabIndex = 0;
            // 
            // WinFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(603, 421);
            this.Controls.Add(this.Pl_WinForm);
            this.Controls.Add(this.smoothLine1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WinFrom";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinFrom";
            Pl_WinForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CloseButton Bt_WinFromClose;
        private System.Windows.Forms.Label Lb_WinFormTitle;
        private SmoothLine smoothLine1;
        private System.Windows.Forms.Panel Pl_WinForm;
    }
}