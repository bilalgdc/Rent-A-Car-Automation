namespace GDC_Arac_Kiralama
{
    partial class Form3
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
            this.yenisözleşmeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veritabanıDataSet = new GDC_Arac_Kiralama.veritabanıDataSet();
            this.yenisözleşmeTableAdapter = new GDC_Arac_Kiralama.veritabanıDataSetTableAdapters.yenisözleşmeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.yenisözleşmeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabanıDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.yenisözleşmeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GDC_Arac_Kiralama.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1195, 556);
            this.reportViewer1.TabIndex = 0;
            // 
            // yenisözleşmeBindingSource
            // 
            this.yenisözleşmeBindingSource.DataMember = "yenisözleşme";
            this.yenisözleşmeBindingSource.DataSource = this.veritabanıDataSet;
            // 
            // veritabanıDataSet
            // 
            this.veritabanıDataSet.DataSetName = "veritabanıDataSet";
            this.veritabanıDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yenisözleşmeTableAdapter
            // 
            this.yenisözleşmeTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 556);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yenisözleşmeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabanıDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource yenisözleşmeBindingSource;
        private veritabanıDataSet veritabanıDataSet;
        private veritabanıDataSetTableAdapters.yenisözleşmeTableAdapter yenisözleşmeTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}