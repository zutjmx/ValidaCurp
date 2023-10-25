
namespace ValidaCurp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnValidaCurpEmpleados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnValidaCurpEmpleados
            // 
            this.btnValidaCurpEmpleados.Location = new System.Drawing.Point(12, 32);
            this.btnValidaCurpEmpleados.Name = "btnValidaCurpEmpleados";
            this.btnValidaCurpEmpleados.Size = new System.Drawing.Size(219, 42);
            this.btnValidaCurpEmpleados.TabIndex = 0;
            this.btnValidaCurpEmpleados.Text = "Valida curp\'s Empleados";
            this.btnValidaCurpEmpleados.UseVisualStyleBackColor = true;
            this.btnValidaCurpEmpleados.Click += new System.EventHandler(this.btnValidaCurpEmpleados_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnValidaCurpEmpleados);
            this.Name = "Form1";
            this.Text = "Valida Curp en tablas de PBI_ENROLA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnValidaCurpEmpleados;
    }
}

