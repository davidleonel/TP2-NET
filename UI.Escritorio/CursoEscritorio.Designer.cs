namespace UI.Escritorio
{
    partial class CursoEscritorio
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblIdMateria = new System.Windows.Forms.Label();
            this.lblIdComision = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.lblAnioCalendario = new System.Windows.Forms.Label();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.txtAnioCalendario = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbIdMateria = new System.Windows.Forms.ComboBox();
            this.cbIdComision = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIdMateria, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIdComision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCupo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioCalendario, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIdCurso, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioCalendario, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbIdMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbIdComision, 1, 2);
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
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // lblIdMateria
            // 
            this.lblIdMateria.AutoSize = true;
            this.lblIdMateria.Location = new System.Drawing.Point(3, 58);
            this.lblIdMateria.Name = "lblIdMateria";
            this.lblIdMateria.Size = new System.Drawing.Size(59, 13);
            this.lblIdMateria.TabIndex = 1;
            this.lblIdMateria.Text = "ID Materia:";
            // 
            // lblIdComision
            // 
            this.lblIdComision.AutoSize = true;
            this.lblIdComision.Location = new System.Drawing.Point(3, 116);
            this.lblIdComision.Name = "lblIdComision";
            this.lblIdComision.Size = new System.Drawing.Size(66, 13);
            this.lblIdComision.TabIndex = 2;
            this.lblIdComision.Text = "ID Comision:";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(271, 116);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(35, 13);
            this.lblCupo.TabIndex = 4;
            this.lblCupo.Text = "Cupo:";
            // 
            // lblAnioCalendario
            // 
            this.lblAnioCalendario.AutoSize = true;
            this.lblAnioCalendario.Location = new System.Drawing.Point(271, 58);
            this.lblAnioCalendario.Name = "lblAnioCalendario";
            this.lblAnioCalendario.Size = new System.Drawing.Size(84, 13);
            this.lblAnioCalendario.TabIndex = 6;
            this.lblAnioCalendario.Text = "Anio Calendario:";
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdCurso.Location = new System.Drawing.Point(110, 3);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.ReadOnly = true;
            this.txtIdCurso.Size = new System.Drawing.Size(155, 20);
            this.txtIdCurso.TabIndex = 8;
            // 
            // txtCupo
            // 
            this.txtCupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCupo.Location = new System.Drawing.Point(378, 119);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(157, 20);
            this.txtCupo.TabIndex = 13;
            // 
            // txtAnioCalendario
            // 
            this.txtAnioCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnioCalendario.Location = new System.Drawing.Point(378, 61);
            this.txtAnioCalendario.Name = "txtAnioCalendario";
            this.txtAnioCalendario.Size = new System.Drawing.Size(157, 20);
            this.txtAnioCalendario.TabIndex = 14;
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
            // cbIdMateria
            // 
            this.cbIdMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIdMateria.FormattingEnabled = true;
            this.cbIdMateria.Location = new System.Drawing.Point(110, 61);
            this.cbIdMateria.Name = "cbIdMateria";
            this.cbIdMateria.Size = new System.Drawing.Size(155, 21);
            this.cbIdMateria.TabIndex = 17;
            // 
            // cbIdComision
            // 
            this.cbIdComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIdComision.FormattingEnabled = true;
            this.cbIdComision.Location = new System.Drawing.Point(110, 119);
            this.cbIdComision.Name = "cbIdComision";
            this.cbIdComision.Size = new System.Drawing.Size(155, 21);
            this.cbIdComision.TabIndex = 18;
            // 
            // CursoEscritorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursoEscritorio";
            this.Text = "Curso";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIdMateria;
        private System.Windows.Forms.Label lblIdComision;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblAnioCalendario;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.TextBox txtAnioCalendario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbIdMateria;
        private System.Windows.Forms.ComboBox cbIdComision;
    }
}