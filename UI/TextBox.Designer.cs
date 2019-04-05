namespace Se7en.UI
{
    partial class TextBox
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.FaceTextBoxBase = new Se7en.UI.PromptedTextBoxBase();
            this.SuspendLayout();
            // 
            // FaceTextBoxBase
            // 
            this.FaceTextBoxBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FaceTextBoxBase.Cue = "WaterMark";
            this.FaceTextBoxBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceTextBoxBase.Location = new System.Drawing.Point(0, 0);
            this.FaceTextBoxBase.Name = "FaceTextBoxBase";
            this.FaceTextBoxBase.Size = new System.Drawing.Size(158, 13);
            this.FaceTextBoxBase.TabIndex = 0;
            // 
            // TextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.FaceTextBoxBase);
            this.Name = "TextBox";
            this.Size = new System.Drawing.Size(158, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PromptedTextBoxBase FaceTextBoxBase;
    }
}
