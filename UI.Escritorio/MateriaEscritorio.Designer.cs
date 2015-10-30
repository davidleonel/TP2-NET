namespace UI.Escritorio
{
    partial class MateriaEscritorio
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
            this.tlpMateria = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDMateria = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblHsSem = new System.Windows.Forms.Label();
            this.lblHsTot = new System.Windows.Forms.Label();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtHsSem = new System.Windows.Forms.TextBox();
            this.txtHsTot = new System.Windows.Forms.TextBox();
            this.cbPlanes = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tlpMateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMateria
            // 
            this.tlpMateria.ColumnCount = 3;
            this.tlpMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMateria.Controls.Add(this.lblIDMateria, 0, 0);
            this.tlpMateria.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlpMateria.Controls.Add(this.lblHsSem, 0, 2);
            this.tlpMateria.Controls.Add(this.lblHsTot, 0, 3);
            this.tlpMateria.Controls.Add(this.lblIDPlan, 0, 4);
            this.tlpMateria.Controls.Add(this.txtID, 1, 0);
            this.tlpMateria.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlpMateria.Controls.Add(this.txtHsSem, 1, 2);
            this.tlpMateria.Controls.Add(this.txtHsTot, 1, 3);
            this.tlpMateria.Controls.Add(this.cbPlanes, 1, 4);
            this.tlpMateria.Controls.Add(this.btnAceptar, 1, 5);
            this.tlpMateria.Controls.Add(this.btnSalir, 2, 5);
            this.tlpMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMateria.Location = new System.Drawing.Point(0, 0);
            this.tlpMateria.Name = "tlpMateria";
            this.tlpMateria.RowCount = 6;
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMateria.Size = new System.Drawing.Size(284, 261);
            this.tlpMateria.TabIndex = 0;
            // 
            // lblIDMateria
            // 
            this.lblIDMateria.AutoSize = true;
            this.lblIDMateria.Location = new System.Drawing.Point(3, 0);
            this.lblIDMateria.Name = "lblIDMateria";
            this.lblIDMateria.Size = new System.Drawing.Size(18, 13);
            this.lblIDMateria.TabIndex = 0;
            this.lblIDMateria.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 43);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblHsSem
            // 
            this.lblHsSem.AutoSize = true;
            this.lblHsSem.Location = new System.Drawing.Point(3, 86);
            this.lblHsSem.Name = "lblHsSem";
            this.lblHsSem.Size = new System.Drawing.Size(75, 13);
            this.lblHsSem.TabIndex = 2;
            this.lblHsSem.Text = "Hs Semanales";
            // 
            // lblHsTot
            // 
            this.lblHsTot.AutoSize = true;
            this.lblHsTot.Location = new System.Drawing.Point(3, 129);
            this.lblHsTot.Name = "lblHsTot";
            this.lblHsTot.Size = new System.Drawing.Size(58, 13);
            this.lblHsTot.TabIndex = 3;
            this.lblHsTot.Text = "Hs Totales";
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(3, 172);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(28, 13);
            this.lblIDPlan.TabIndex = 4;
            this.lblIDPlan.Text = "Plan";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(84, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(116, 20);
            this.txtID.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(84, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(116, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtHsSem
            // 
            this.txtHsSem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHsSem.Location = new System.Drawing.Point(84, 89);
            this.txtHsSem.Name = "txtHsSem";
            this.txtHsSem.Size = new System.Drawing.Size(116, 20);
            this.txtHsSem.TabIndex = 7;
            // 
            // txtHsTot
            // 
            this.txtHsTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHsTot.Location = new System.Drawing.Point(84, 132);
            this.txtHsTot.Name = "txtHsTot";
            this.txtHsTot.Size = new System.Drawing.Size(116, 20);
            this.txtHsTot.TabIndex = 8;
            // 
            // cbPlanes
            // 
            this.cbPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPlanes.FormattingEnabled = true;
            this.cbPlanes.Location = new System.Drawing.Point(84, 175);
            this.cbPlanes.Name = "cbPlanes";
            this.cbPlanes.Size = new System.Drawing.Size(116, 21);
            this.cbPlanes.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(125, 218);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(206, 218);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // MateriaEscritorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tlpMateria);
            this.Name = "MateriaEscritorio";
            this.Text = "Materia";
            this.tlpMateria.ResumeLayout(false);
            this.tlpMateria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMateria;
        private System.Windows.Forms.Label lblIDMateria;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblHsSem;
        private System.Windows.Forms.Label lblHsTot;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHsSem;
        private System.Windows.Forms.TextBox txtHsTot;
        private System.Windows.Forms.ComboBox cbPlanes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
    }
}