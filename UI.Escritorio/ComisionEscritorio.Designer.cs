namespace UI.Escritorio
{
    partial class ComisionEscritorio
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtDescCom = new System.Windows.Forms.TextBox();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.lblAnioEsp = new System.Windows.Forms.Label();
            this.lblDescCom = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtIDCom = new System.Windows.Forms.TextBox();
            this.txtAnioEsp = new System.Windows.Forms.TextBox();
            this.cbIdPlan = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(378, 177);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(271, 177);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtDescCom
            // 
            this.txtDescCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescCom.Location = new System.Drawing.Point(110, 61);
            this.txtDescCom.Name = "txtDescCom";
            this.txtDescCom.Size = new System.Drawing.Size(155, 20);
            this.txtDescCom.TabIndex = 9;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(271, 58);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(45, 13);
            this.lblIdPlan.TabIndex = 6;
            this.lblIdPlan.Text = "ID Plan:";
            // 
            // lblAnioEsp
            // 
            this.lblAnioEsp.AutoSize = true;
            this.lblAnioEsp.Location = new System.Drawing.Point(3, 116);
            this.lblAnioEsp.Name = "lblAnioEsp";
            this.lblAnioEsp.Size = new System.Drawing.Size(92, 13);
            this.lblAnioEsp.TabIndex = 2;
            this.lblAnioEsp.Text = "Año Especialidad:";
            // 
            // lblDescCom
            // 
            this.lblDescCom.AutoSize = true;
            this.lblDescCom.Location = new System.Drawing.Point(3, 58);
            this.lblDescCom.Name = "lblDescCom";
            this.lblDescCom.Size = new System.Drawing.Size(83, 13);
            this.lblDescCom.TabIndex = 1;
            this.lblDescCom.Text = "Desc. Comision:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescCom, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioEsp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIdPlan, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescCom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtIDCom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioEsp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbIdPlan, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 221);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtIDCom
            // 
            this.txtIDCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDCom.Location = new System.Drawing.Point(110, 3);
            this.txtIDCom.Name = "txtIDCom";
            this.txtIDCom.ReadOnly = true;
            this.txtIDCom.Size = new System.Drawing.Size(155, 20);
            this.txtIDCom.TabIndex = 17;
            // 
            // txtAnioEsp
            // 
            this.txtAnioEsp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnioEsp.Location = new System.Drawing.Point(110, 119);
            this.txtAnioEsp.Name = "txtAnioEsp";
            this.txtAnioEsp.Size = new System.Drawing.Size(155, 20);
            this.txtAnioEsp.TabIndex = 18;
            // 
            // cbIdPlan
            // 
            this.cbIdPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIdPlan.FormattingEnabled = true;
            this.cbIdPlan.Location = new System.Drawing.Point(378, 61);
            this.cbIdPlan.Name = "cbIdPlan";
            this.cbIdPlan.Size = new System.Drawing.Size(157, 21);
            this.cbIdPlan.TabIndex = 19;
            // 
            // ComisionEscritorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ComisionEscritorio";
            this.Text = "Comision";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtDescCom;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.Label lblAnioEsp;
        private System.Windows.Forms.Label lblDescCom;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtIDCom;
        private System.Windows.Forms.TextBox txtAnioEsp;
        private System.Windows.Forms.ComboBox cbIdPlan;

    }
}