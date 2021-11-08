
namespace UI.Desktop
{
    partial class ComisionesDesktop
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
            this.tlpComision = new System.Windows.Forms.TableLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPlanes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnioEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpComision.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpComision
            // 
            this.tlpComision.ColumnCount = 3;
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.Controls.Add(this.txtId, 1, 0);
            this.tlpComision.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlpComision.Controls.Add(this.label1, 0, 0);
            this.tlpComision.Controls.Add(this.label2, 0, 1);
            this.tlpComision.Controls.Add(this.label3, 0, 2);
            this.tlpComision.Controls.Add(this.cbPlanes, 1, 3);
            this.tlpComision.Controls.Add(this.label4, 0, 3);
            this.tlpComision.Controls.Add(this.txtAnioEspecialidad, 1, 2);
            this.tlpComision.Controls.Add(this.btnAceptar, 1, 4);
            this.tlpComision.Controls.Add(this.btnCancelar, 2, 4);
            this.tlpComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpComision.Location = new System.Drawing.Point(0, 0);
            this.tlpComision.Name = "tlpComision";
            this.tlpComision.RowCount = 6;
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpComision.Size = new System.Drawing.Size(361, 135);
            this.tlpComision.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(98, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.tlpComision.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(98, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(260, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(74, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(29, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Año Especialidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPlanes
            // 
            this.tlpComision.SetColumnSpan(this.cbPlanes, 2);
            this.cbPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPlanes.FormattingEnabled = true;
            this.cbPlanes.Location = new System.Drawing.Point(98, 81);
            this.cbPlanes.Name = "cbPlanes";
            this.cbPlanes.Size = new System.Drawing.Size(260, 21);
            this.cbPlanes.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(64, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnioEspecialidad
            // 
            this.tlpComision.SetColumnSpan(this.txtAnioEspecialidad, 2);
            this.txtAnioEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnioEspecialidad.Location = new System.Drawing.Point(98, 55);
            this.txtAnioEspecialidad.Name = "txtAnioEspecialidad";
            this.txtAnioEspecialidad.Size = new System.Drawing.Size(260, 20);
            this.txtAnioEspecialidad.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.Location = new System.Drawing.Point(202, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(283, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ComisionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 135);
            this.Controls.Add(this.tlpComision);
            this.Name = "ComisionesDesktop";
            this.Text = "Comisiones";
            this.tlpComision.ResumeLayout(false);
            this.tlpComision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpComision;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPlanes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAnioEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}