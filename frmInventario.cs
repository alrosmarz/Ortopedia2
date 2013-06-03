using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.UI.Properties;

namespace Ortopedia.UI
{
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }
        
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmInventario_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Detalle");
            dt.Columns.Add("Número");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("Ver Fotografías", typeof(System.Drawing.Bitmap));

            DataRow dr = dt.NewRow();
            dr["Descripción"] = "Rodillera 1";
            dr["Detalle"] = "Rodillera 1";
            dr["Número"] = "Rodillera 1";
            dr["Cantidad"] = "30";
            dr["Proveedor"] = "Rodillera 1";
            dr["Ver Fotografías"] = new Bitmap(Resources.mail, new Size(18, 18));

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Descripción"] = "Rodillera 2";
            dr["Detalle"] = "Rodillera 2";
            dr["Número"] = "Rodillera 2";
            dr["Cantidad"] = "40";
            dr["Proveedor"] = "Rodillera 2";
            dr["Ver Fotografías"] = new Bitmap(Resources.mail, new Size(18, 18));

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Descripción"] = "Rodillera 3";
            dr["Detalle"] = "Rodillera 3";
            dr["Número"] = "Rodillera 3";
            dr["Cantidad"] = "5";
            dr["Proveedor"] = "Rodillera 3";
            dr["Ver Fotografías"] = new Bitmap(Resources.mail, new Size(18, 18));

            dt.Rows.Add(dr);

            gvMedicos.AutoGenerateColumns = true;
            gvMedicos.DataSource = dt;
            
        }
    }
}
