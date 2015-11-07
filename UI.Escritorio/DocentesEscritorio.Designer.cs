namespace UI.Escritorio
{
    partial class DocentesEscritorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocentesEscritorio));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocentes = new System.Windows.Forms.DataGridView();
            this.idPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlDocentes);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(809, 291);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(809, 316);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlDocentes
            // 
            this.tlDocentes.ColumnCount = 2;
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentes.Controls.Add(this.dgvDocentes, 0, 0);
            this.tlDocentes.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentes.Location = new System.Drawing.Point(0, 0);
            this.tlDocentes.Name = "tlDocentes";
            this.tlDocentes.RowCount = 2;
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentes.Size = new System.Drawing.Size(809, 291);
            this.tlDocentes.TabIndex = 0;
            // 
            // dgvDocentes
            // 
            this.dgvDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPersona,
            this.nombre,
            this.apellido,
            this.direccion,
            this.email,
            this.telefono,
            this.fechaNac,
            this.legajo,
            this.idPlan});
            this.tlDocentes.SetColumnSpan(this.dgvDocentes, 2);
            this.dgvDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentes.Location = new System.Drawing.Point(3, 3);
            this.dgvDocentes.MultiSelect = false;
            this.dgvDocentes.Name = "dgvDocentes";
            this.dgvDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocentes.Size = new System.Drawing.Size(803, 256);
            this.dgvDocentes.TabIndex = 0;
            // 
            // idPersona
            // 
            this.idPersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPersona.DataPropertyName = "Id";
            this.idPersona.HeaderText = "ID Docente";
            this.idPersona.Name = "idPersona";
            this.idPersona.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // fechaNac
            // 
            this.fechaNac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fechaNac.DataPropertyName = "fechaNacimiento";
            this.fechaNac.HeaderText = "Fecha Nacimiento";
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.ReadOnly = true;
            // 
            // legajo
            // 
            this.legajo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.legajo.DataPropertyName = "legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            this.legajo.ReadOnly = true;
            // 
            // idPlan
            // 
            this.idPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPlan.DataPropertyName = "IdPlan";
            this.idPlan.HeaderText = "ID Plan";
            this.idPlan.Name = "idPlan";
            this.idPlan.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(731, 265);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // DocentesEscritorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 316);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "DocentesEscritorio";
            this.Text = "Docentes";
            this.Load += new System.EventHandler(this.DocentesEscritorio_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlDocentes;
        private System.Windows.Forms.DataGridView dgvDocentes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlan;

    }
}

