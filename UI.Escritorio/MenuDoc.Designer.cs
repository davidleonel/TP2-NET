namespace UI.Escritorio
{
    partial class MenuDoc
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
            this.tbpDoc = new System.Windows.Forms.TableLayoutPanel();
            this.btnInscripDoc = new System.Windows.Forms.Button();
            this.btnRegNotas = new System.Windows.Forms.Button();
            this.tbpDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpDoc
            // 
            this.tbpDoc.ColumnCount = 3;
            this.tbpDoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbpDoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbpDoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbpDoc.Controls.Add(this.btnRegNotas, 1, 1);
            this.tbpDoc.Controls.Add(this.btnInscripDoc, 1, 0);
            this.tbpDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpDoc.Location = new System.Drawing.Point(0, 0);
            this.tbpDoc.Name = "tbpDoc";
            this.tbpDoc.RowCount = 2;
            this.tbpDoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbpDoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbpDoc.Size = new System.Drawing.Size(284, 261);
            this.tbpDoc.TabIndex = 0;
            // 
            // btnInscripDoc
            // 
            this.btnInscripDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInscripDoc.Location = new System.Drawing.Point(104, 45);
            this.btnInscripDoc.Name = "btnInscripDoc";
            this.btnInscripDoc.Size = new System.Drawing.Size(75, 40);
            this.btnInscripDoc.TabIndex = 0;
            this.btnInscripDoc.Text = "Inscripcion a curso";
            this.btnInscripDoc.UseVisualStyleBackColor = true;
            // 
            // btnRegNotas
            // 
            this.btnRegNotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegNotas.Location = new System.Drawing.Point(104, 174);
            this.btnRegNotas.Name = "btnRegNotas";
            this.btnRegNotas.Size = new System.Drawing.Size(75, 43);
            this.btnRegNotas.TabIndex = 1;
            this.btnRegNotas.Text = "Registrar notas";
            this.btnRegNotas.UseVisualStyleBackColor = true;
            // 
            // MenuDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbpDoc);
            this.Name = "MenuDoc";
            this.Text = "MenuDoc";
            this.tbpDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbpDoc;
        private System.Windows.Forms.Button btnRegNotas;
        private System.Windows.Forms.Button btnInscripDoc;
    }
}