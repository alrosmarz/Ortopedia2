using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ortopedia.UI
{
    public partial class frmListadoEntradas : Form
    {
        public frmListadoEntradas()
        {
            InitializeComponent();
        }

        private void btnCrearEntrada_Click(object sender, EventArgs e)
        {
            frmEntradaInventario frm = new frmEntradaInventario();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
