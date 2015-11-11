namespace UI.Escritorio
{
    partial class MenuAlum
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
            this.tlpAlum = new System.Windows.Forms.TableLayoutPanel();
            this.btnInscripAlum = new System.Windows.Forms.Button();
            this.tlpAlum.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAlum
            // 
            this.tlpAlum.ColumnCount = 3;
            this.tlpAlum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAlum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpAlum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAlum.Controls.Add(this.btnInscripAlum, 1, 0);
            this.tlpAlum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlum.Location = new System.Drawing.Point(0, 0);
            this.tlpAlum.Name = "tlpAlum";
            this.tlpAlum.RowCount = 1;
            this.tlpAlum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlum.Size = new System.Drawing.Size(284, 261);
            this.tlpAlum.TabIndex = 0;
            // 
            // btnInscripAlum
            // 
            this.btnInscripAlum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInscripAlum.Location = new System.Drawing.Point(95, 111);
            this.btnInscripAlum.Name = "btnInscripAlum";
            this.btnInscripAlum.Size = new System.Drawing.Size(92, 39);
            this.btnInscripAlum.TabIndex = 0;
            this.btnInscripAlum.Text = "Inscrbir a Curso";
            this.btnInscripAlum.UseVisualStyleBackColor = true;
            // 
            // MenuAlum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tlpAlum);
            this.Name = "MenuAlum";
            this.Text = "MenuAlum";
            this.tlpAlum.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAlum;
        private System.Windows.Forms.Button btnInscripAlum;
    }
}