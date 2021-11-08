
namespace UI.Desktop
{
    partial class ReportesCursosForm
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
            this.CursoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpwCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CursoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CursoBindingSource
            // 
            this.CursoBindingSource.DataSource = typeof(Business.Entities.Curso);
            // 
            // rpwCursos
            // 
            this.rpwCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CursoTable";
            reportDataSource1.Value = this.CursoBindingSource;
            this.rpwCursos.LocalReport.DataSources.Add(reportDataSource1);
            this.rpwCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteDeCursos.rdlc";
            this.rpwCursos.Location = new System.Drawing.Point(0, 0);
            this.rpwCursos.Name = "rpwCursos";
            this.rpwCursos.ServerReport.BearerToken = null;
            this.rpwCursos.Size = new System.Drawing.Size(800, 450);
            this.rpwCursos.TabIndex = 0;
            // 
            // ReportesCursosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpwCursos);
            this.Name = "ReportesCursosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Cursos";
            this.Load += new System.EventHandler(this.ReportesCursosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CursoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpwCursos;
        private System.Windows.Forms.BindingSource CursoBindingSource;
    }
}