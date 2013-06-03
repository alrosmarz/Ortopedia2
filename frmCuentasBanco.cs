using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.BE;

namespace Ortopedia.UI
{
    public partial class frmCuentasBanco : Form
    {
        public List<CuentasBE> cuentas { get; set; }

        public frmCuentasBanco()
        {
            InitializeComponent();
        }

        DataTable creaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Banco");
            dt.Columns.Add("Nombre Cuenta");
            dt.Columns.Add("No. Cuenta");
            dt.Columns.Add("Clabe");
            dt.Columns.Add("Sucursal");
            dt.Columns.Add("Observaciones");
            dt.Columns.Add("Ciudad");
            dt.Columns.Add("Estado");
            return dt;
        }

        private void frmCuentasBanco_Load(object sender, EventArgs e)
        {
            DataTable dt = creaDataTable();

            if (cuentas.Count > 0)
            {
                foreach (CuentasBE i in cuentas)
                {
                    DataRow dr = dt.NewRow();
                    dr["Banco"] = i.DescBanco;
                    dr["Nombre Cuenta"] = i.NombreCuenta;
                    dr["No. Cuenta"] = i.NoCuenta;
                    dr["Clabe"] = i.Clabe;
                    dr["Sucursal"] = i.Sucursal;
                    dr["Observaciones"] = i.Observaciones; 
                    dr["Ciudad"] = i.DescCiudad;
                    dr["Estado"] = i.DescEstado;
                    dt.Rows.Add(dr);
                }
            }

            gvCuentas.DataSource = dt;
        }
    }
}
