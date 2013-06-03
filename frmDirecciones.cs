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
    public partial class frmDirecciones : Form
    {
        public List<DireccionesBE> listaDirecciones { get; set; }

        public frmDirecciones()
        {
            InitializeComponent();
        }

        DataTable creaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Calle");
            dt.Columns.Add("Colonia");
            dt.Columns.Add("CP");
            dt.Columns.Add("Ciudad");
            dt.Columns.Add("Estado");
            return dt;
        }

        private void frmDirecciones_Load(object sender, EventArgs e)
        {
            DataTable dt = creaDataTable();

            if (listaDirecciones.Count > 0)
            {
                foreach (DireccionesBE i in listaDirecciones)
                {
                    DataRow dr = dt.NewRow();
                    dr["Calle"] = i.Calle;
                    dr["Colonia"] = i.Colonia;
                    dr["CP"] = i.CP;
                    dr["Ciudad"] = i.DescCiudad;
                    dr["Estado"] = i.DescEstado;
                    dt.Rows.Add(dr);
                }
            }

            gvDirecciones.DataSource = dt;
        }

    }
}
