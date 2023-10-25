using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidaCurp.Comun;

namespace ValidaCurp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaCurpEmpleados_Click(object sender, EventArgs e)
        {
            //Rutina para validar curp de los empleados
            this.Cursor = Cursors.WaitCursor;
            Util util = new Util();
            util.ValidarCurpEmpleado();
            MessageBox.Show("Proceso terminado");
            this.Cursor = Cursors.Default;
        }
    }
}
