
namespace UI.Desktop
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReporteCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportePlan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAsignarDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegistroNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.tsmiAdministracion,
            this.tsmiReporteCurso,
            this.tsmiReportePlan,
            this.tsmiCursos});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1177, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCerrarSesion,
            this.tsmiSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // tsmiCerrarSesion
            // 
            this.tsmiCerrarSesion.Name = "tsmiCerrarSesion";
            this.tsmiCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.tsmiCerrarSesion.Text = "Cerrar Sesión";
            this.tsmiCerrarSesion.Click += new System.EventHandler(this.tsmiCerrarSesion_Click);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(143, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // tsmiAdministracion
            // 
            this.tsmiAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlumnos,
            this.tsmiDocentes,
            this.tsmiEspecialidades,
            this.tsmiPlanes,
            this.tsmiComisiones});
            this.tsmiAdministracion.Name = "tsmiAdministracion";
            this.tsmiAdministracion.Size = new System.Drawing.Size(100, 20);
            this.tsmiAdministracion.Text = "Administración";
            // 
            // tsmiAlumnos
            // 
            this.tsmiAlumnos.Name = "tsmiAlumnos";
            this.tsmiAlumnos.Size = new System.Drawing.Size(180, 22);
            this.tsmiAlumnos.Text = "Alumnos";
            this.tsmiAlumnos.Click += new System.EventHandler(this.tsmiAlumnos_Click);
            // 
            // tsmiDocentes
            // 
            this.tsmiDocentes.Name = "tsmiDocentes";
            this.tsmiDocentes.Size = new System.Drawing.Size(180, 22);
            this.tsmiDocentes.Text = "Docentes";
            this.tsmiDocentes.Click += new System.EventHandler(this.tsmiDocentes_Click);
            // 
            // tsmiEspecialidades
            // 
            this.tsmiEspecialidades.Name = "tsmiEspecialidades";
            this.tsmiEspecialidades.Size = new System.Drawing.Size(180, 22);
            this.tsmiEspecialidades.Text = "Especialidades";
            this.tsmiEspecialidades.Click += new System.EventHandler(this.tsmiEspecialidades_Click);
            // 
            // tsmiPlanes
            // 
            this.tsmiPlanes.Name = "tsmiPlanes";
            this.tsmiPlanes.Size = new System.Drawing.Size(180, 22);
            this.tsmiPlanes.Text = "Planes y Materias";
            this.tsmiPlanes.Click += new System.EventHandler(this.tsmiPlanes_Click);
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(180, 22);
            this.tsmiComisiones.Text = "Comisiones";
            this.tsmiComisiones.Click += new System.EventHandler(this.tsmiComisiones_Click);
            // 
            // tsmiReporteCurso
            // 
            this.tsmiReporteCurso.Name = "tsmiReporteCurso";
            this.tsmiReporteCurso.Size = new System.Drawing.Size(115, 20);
            this.tsmiReporteCurso.Text = "Reporte de Cursos";
            this.tsmiReporteCurso.Click += new System.EventHandler(this.tsmiReporteCurso_Click);
            // 
            // tsmiReportePlan
            // 
            this.tsmiReportePlan.Name = "tsmiReportePlan";
            this.tsmiReportePlan.Size = new System.Drawing.Size(114, 20);
            this.tsmiReportePlan.Text = "Reporte De Planes";
            this.tsmiReportePlan.Click += new System.EventHandler(this.tsmiReportePlan_Click);
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdminCursos,
            this.tsmiAsignarDocentes,
            this.tsmiInscripcion,
            this.tsmiRegistroNotas});
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(55, 20);
            this.tsmiCursos.Text = "Cursos";
            // 
            // tsmiAdminCursos
            // 
            this.tsmiAdminCursos.Name = "tsmiAdminCursos";
            this.tsmiAdminCursos.Size = new System.Drawing.Size(180, 22);
            this.tsmiAdminCursos.Text = "Administrar Cursos";
            this.tsmiAdminCursos.Click += new System.EventHandler(this.tsmiAdminCursos_Click);
            // 
            // tsmiAsignarDocentes
            // 
            this.tsmiAsignarDocentes.Name = "tsmiAsignarDocentes";
            this.tsmiAsignarDocentes.Size = new System.Drawing.Size(180, 22);
            this.tsmiAsignarDocentes.Text = "Asignar Docentes";
            this.tsmiAsignarDocentes.Click += new System.EventHandler(this.tsmiAsignarDocentes_Click);
            // 
            // tsmiInscripcion
            // 
            this.tsmiInscripcion.Name = "tsmiInscripcion";
            this.tsmiInscripcion.Size = new System.Drawing.Size(180, 22);
            this.tsmiInscripcion.Text = "Inscripción";
            this.tsmiInscripcion.Click += new System.EventHandler(this.tsmiInscripcion_Click);
            // 
            // tsmiRegistroNotas
            // 
            this.tsmiRegistroNotas.Name = "tsmiRegistroNotas";
            this.tsmiRegistroNotas.Size = new System.Drawing.Size(180, 22);
            this.tsmiRegistroNotas.Text = "Registrar Notas";
            this.tsmiRegistroNotas.Click += new System.EventHandler(this.tsmiRegistroNotas_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 689);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Shown += new System.EventHandler(this.Principal_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdministracion;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocentes;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
        private System.Windows.Forms.ToolStripMenuItem tsmiReporteCurso;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportePlan;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiAsignarDocentes;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscripcion;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegistroNotas;
    }
}