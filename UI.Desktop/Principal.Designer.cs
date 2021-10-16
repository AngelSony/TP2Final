
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
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.tsmiSalir.Size = new System.Drawing.Size(180, 22);
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
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuarios,
            this.tsmiCursos,
            this.tsmiMaterias,
            this.tsmiAlumnos,
            this.tsmiDocentes,
            this.tsmiEspecialidades,
            this.tsmiPlanes,
            this.tsmiComisiones});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.Size = new System.Drawing.Size(180, 22);
            this.tsmiUsuarios.Text = "Usuarios";
            this.tsmiUsuarios.Click += new System.EventHandler(this.tsmiUsuarios_Click);
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(180, 22);
            this.tsmiCursos.Text = "Cursos";
            this.tsmiCursos.Click += new System.EventHandler(this.tsmiCursos_Click);
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
            // 
            // tsmiDocentes
            // 
            this.tsmiDocentes.Name = "tsmiDocentes";
            this.tsmiDocentes.Size = new System.Drawing.Size(180, 22);
            this.tsmiDocentes.Text = "Docentes";
            // 
            // tsmiEspecialidades
            // 
            this.tsmiEspecialidades.Name = "tsmiEspecialidades";
            this.tsmiEspecialidades.Size = new System.Drawing.Size(180, 22);
            this.tsmiEspecialidades.Text = "Especialidades";
            // 
            // tsmiPlanes
            // 
            this.tsmiPlanes.Name = "tsmiPlanes";
            this.tsmiPlanes.Size = new System.Drawing.Size(180, 22);
            this.tsmiPlanes.Text = "Planes";
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(180, 22);
            this.tsmiComisiones.Text = "Comisiones";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
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
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocentes;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
    }
}