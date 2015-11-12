namespace UI.Escritorio
{
    partial class ReporteCursos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tP2DataSetCursos = new UI.Escritorio.TP2DataSetCursos();
            this.tP2DataSetCursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tP2DataSetCursosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursosTableAdapter = new UI.Escritorio.TP2DataSetCursosTableAdapters.cursosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InformeNuevo";
            reportDataSource1.Value = this.cursosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Escritorio.InformeCursos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(720, 428);
            this.reportViewer1.TabIndex = 0;
            // 
            // tP2DataSetCursos
            // 
            this.tP2DataSetCursos.DataSetName = "TP2DataSetCursos";
            this.tP2DataSetCursos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tP2DataSetCursosBindingSource
            // 
            this.tP2DataSetCursosBindingSource.DataSource = this.tP2DataSetCursos;
            this.tP2DataSetCursosBindingSource.Position = 0;
            // 
            // tP2DataSetCursosBindingSource1
            // 
            this.tP2DataSetCursosBindingSource1.DataSource = this.tP2DataSetCursos;
            this.tP2DataSetCursosBindingSource1.Position = 0;
            // 
            // cursosBindingSource
            // 
            this.cursosBindingSource.DataMember = "cursos";
            this.cursosBindingSource.DataSource = this.tP2DataSetCursos;
            // 
            // cursosTableAdapter
            // 
            this.cursosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 428);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteCursos";
            this.Text = "ReporteCursos";
            this.Load += new System.EventHandler(this.ReporteCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetCursosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tP2DataSetCursosBindingSource;
        private TP2DataSetCursos tP2DataSetCursos;
        private System.Windows.Forms.BindingSource cursosBindingSource;
        private System.Windows.Forms.BindingSource tP2DataSetCursosBindingSource1;
        private TP2DataSetCursosTableAdapters.cursosTableAdapter cursosTableAdapter;
    }
}