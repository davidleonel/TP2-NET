namespace UI.Escritorio
{
    partial class PlanEscritorio
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
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.cbEspecialidades = new System.Windows.Forms.ComboBox();
            this.lblIdEspecialidad = new System.Windows.Forms.Label();
            this.lblDescripcionPlan = new System.Windows.Forms.Label();
            this.txtDescripcionPlan = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblIdPlan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIdPlan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbEspecialidades, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIdEspecialidad, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcionPlan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcionPlan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.57831F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.42169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(353, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(3, 0);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(42, 13);
            this.lblIdPlan.TabIndex = 0;
            this.lblIdPlan.Text = "ID Plan";
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Location = new System.Drawing.Point(93, 3);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.ReadOnly = true;
            this.txtIdPlan.Size = new System.Drawing.Size(100, 20);
            this.txtIdPlan.TabIndex = 1;
            // 
            // cbEspecialidades
            // 
            this.cbEspecialidades.FormattingEnabled = true;
            this.cbEspecialidades.Location = new System.Drawing.Point(93, 79);
            this.cbEspecialidades.Name = "cbEspecialidades";
            this.cbEspecialidades.Size = new System.Drawing.Size(121, 21);
            this.cbEspecialidades.TabIndex = 3;
            // 
            // lblIdEspecialidad
            // 
            this.lblIdEspecialidad.AutoSize = true;
            this.lblIdEspecialidad.Location = new System.Drawing.Point(3, 76);
            this.lblIdEspecialidad.Name = "lblIdEspecialidad";
            this.lblIdEspecialidad.Size = new System.Drawing.Size(81, 13);
            this.lblIdEspecialidad.TabIndex = 2;
            this.lblIdEspecialidad.Text = "ID Especialidad";
            // 
            // lblDescripcionPlan
            // 
            this.lblDescripcionPlan.AutoSize = true;
            this.lblDescripcionPlan.Location = new System.Drawing.Point(3, 34);
            this.lblDescripcionPlan.Name = "lblDescripcionPlan";
            this.lblDescripcionPlan.Size = new System.Drawing.Size(84, 13);
            this.lblDescripcionPlan.TabIndex = 4;
            this.lblDescripcionPlan.Text = "DescripcionPlan";
            // 
            // txtDescripcionPlan
            // 
            this.txtDescripcionPlan.Location = new System.Drawing.Point(93, 37);
            this.txtDescripcionPlan.Name = "txtDescripcionPlan";
            this.txtDescripcionPlan.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcionPlan.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(194, 233);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(275, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PlanEscritorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 269);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlanEscritorio";
            this.Text = "Plan";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.ComboBox cbEspecialidades;
        private System.Windows.Forms.Label lblIdEspecialidad;
        private System.Windows.Forms.Label lblDescripcionPlan;
        private System.Windows.Forms.TextBox txtDescripcionPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}