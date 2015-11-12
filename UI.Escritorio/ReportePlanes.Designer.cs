namespace UI.Escritorio
{
    partial class ReportePlanes
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
            this.tP2DataSetPlanes = new UI.Escritorio.TP2DataSetPlanes();
            this.tP2DataSetPlanesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesTableAdapter = new UI.Escritorio.TP2DataSetPlanesTableAdapters.planesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetPlanesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InformePlanes";
            reportDataSource1.Value = this.planesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Escritorio.InformePlanes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(726, 530);
            this.reportViewer1.TabIndex = 0;
            // 
            // tP2DataSetPlanes
            // 
            this.tP2DataSetPlanes.DataSetName = "TP2DataSetPlanes";
            this.tP2DataSetPlanes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tP2DataSetPlanesBindingSource
            // 
            this.tP2DataSetPlanesBindingSource.DataSource = this.tP2DataSetPlanes;
            this.tP2DataSetPlanesBindingSource.Position = 0;
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.tP2DataSetPlanes;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 530);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tP2DataSetPlanesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tP2DataSetPlanesBindingSource;
        private TP2DataSetPlanes tP2DataSetPlanes;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private TP2DataSetPlanesTableAdapters.planesTableAdapter planesTableAdapter;
    }
}