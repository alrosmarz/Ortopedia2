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
    public partial class frmTelefonoMail : Form
    {
        public List<TelefonosBE> listaTelefonos { get; set; }
        public List<MailsBE> listaMails { get; set; }

        public frmTelefonoMail()
        {
            InitializeComponent();
            
        }

        DataTable creaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Descripcion");
            return dt;
        }

        private void frmTelefonos_Load(object sender, EventArgs e)
        {
            DataTable dt = creaDataTable();

            if (listaMails.Count > 0)
            {
                foreach (MailsBE i in listaMails)
                {
                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = i.DescTipoMail;
                    dr["Descripcion"] = i.Mail;
                    dt.Rows.Add(dr);
                }
            }

            if (listaTelefonos.Count > 0)
            {
                foreach (TelefonosBE i in listaTelefonos)
                {
                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = i.DescTelefono;
                    dr["Descripcion"] = i.Telefono;
                    dt.Rows.Add(dr);
                }
            }

            gvTelefonos.DataSource = dt;
        }
    }
}
