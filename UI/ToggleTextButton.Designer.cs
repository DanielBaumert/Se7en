namespace WindowsClean.UI {
    partial class ToggleTextButton {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.toggleButton1 = new Se7en.UI.ToggleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toggleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toggleButton1.Location = new System.Drawing.Point(0, 0);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffColor = System.Drawing.Color.DodgerBlue;
            this.toggleButton1.OnColor = System.Drawing.Color.Gray;
            this.toggleButton1.Size = new System.Drawing.Size(47, 25);
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.ToggleColor = System.Drawing.Color.White;
            this.toggleButton1.ToggleState = true;
            this.toggleButton1.Toggled += new Se7en.UI.ToggleButton.ToggledHandle(this.ToggleButton1_Toggled);
            // 
            // ToggleTextButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleButton1);
            this.Name = "ToggleTextButton";
            this.Size = new System.Drawing.Size(232, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private Se7en.UI.ToggleButton toggleButton1;
        private System.Windows.Forms.Label label1;
    }
}
