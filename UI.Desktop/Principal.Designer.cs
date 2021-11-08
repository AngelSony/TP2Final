
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
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscribirseACursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.cuentaToolStripMenuItem,
            this.administraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1177, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(96, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCursos,
            this.tsmiMaterias,
            this.tsmiAlumnos,
            this.tsmiDocentes,
            this.tsmiEspecialidades,
            this.tsmiPlanes,
            this.tsmiComisiones,
            this.registrarNotasToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarDocentesToolStripMenuItem,
            this.administrarCursosToolStripMenuItem,
            this.inscribirseACursosToolStripMenuItem});
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(180, 22);
            this.tsmiCursos.Text = "Cursos";
            // 
            // asignarDocentesToolStripMenuItem
            // 
            this.asignarDocentesToolStripMenuItem.Name = "asignarDocentesToolStripMenuItem";
            this.asignarDocentesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.asignarDocentesToolStripMenuItem.Text = "Asignar Docentes";
            this.asignarDocentesToolStripMenuItem.Click += new System.EventHandler(this.asignarDocentesToolStripMenuItem_Click);
            // 
            // administrarCursosToolStripMenuItem
            // 
            this.administrarCursosToolStripMenuItem.Name = "administrarCursosToolStripMenuItem";
            this.administrarCursosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.administrarCursosToolStripMenuItem.Text = "Administrar Cursos";
            this.administrarCursosToolStripMenuItem.Click += new System.EventHandler(this.administrarCursosToolStripMenuItem_Click);
            // 
            // inscribirseACursosToolStripMenuItem
            // 
            this.inscribirseACursosToolStripMenuItem.Name = "inscribirseACursosToolStripMenuItem";
            this.inscribirseACursosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.inscribirseACursosToolStripMenuItem.Text = "Inscribirse a Cursos";
            this.inscribirseACursosToolStripMenuItem.Click += new System.EventHandler(this.inscribirseACursosToolStripMenuItem_Click);
            // 
            // tsmiMaterias
            // 
            this.tsmiMaterias.Name = "tsmiMaterias";
            this.tsmiMaterias.Size = new System.Drawing.Size(180, 22);
            this.tsmiMaterias.Text = "Materias";
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
            this.tsmiPlanes.Text = "Planes";
            this.tsmiPlanes.Click += new System.EventHandler(this.tsmiPlanes_Click);
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(180, 22);
            this.tsmiComisiones.Text = "Comisiones";
            this.tsmiComisiones.Click += new System.EventHandler(this.tsmiComisiones_Click);
            // 
            // registrarNotasToolStripMenuItem
            // 
            this.registrarNotasToolStripMenuItem.Name = "registrarNotasToolStripMenuItem";
            this.registrarNotasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarNotasToolStripMenuItem.Text = "Registrar Notas";
            this.registrarNotasToolStripMenuItem.Click += new System.EventHandler(this.registrarNotasToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocentes;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
        private System.Windows.Forms.ToolStripMenuItem asignarDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscribirseACursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarNotasToolStripMenuItem;
    }
}