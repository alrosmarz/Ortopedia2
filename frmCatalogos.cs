using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.UI.Shared;
using Ortopedia.BE;

namespace Ortopedia.UI
{
    public partial class frmCatalogos : Form
    {
        public int IdCatalogoMae { get; set; }
        public int IdCatalogoDet { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Auxiliar { get; set; }
        public bool Editando { get; set; }

        public frmCatalogos()
        {
            InitializeComponent();
            List<CatalogosBE> catalogos = new List<CatalogosBE>();
            Funciones.CargarCatalogo(Shared.Funciones.Catalogos.Bancos, comboBox1, "", "", "", "", true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                LlenaInformacionGrid();
                IdCatalogoMae = int.Parse(((ComboItem)comboBox1.SelectedItem).Value.ToString());
                
            }
        }

        void LlenaInformacionGrid()
        {
            List<CatalogosBE> catalogo = new List<CatalogosBE>();
            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((ComboItem)comboBox1.SelectedItem).Value.ToString(), "", "", "");
            btnAgregar.Enabled = true;
            DataTable dt = CreaDataTableCatalogos();
            foreach (CatalogosBE c in catalogo)
            {
                DataRow dr = dt.NewRow();
                dr["IdCatalogoDet"] = c.Id;
                dr["Descripción"] = c.Descripcion;
                if (c.Tag != null)
                {
                    string[] t = c.Tag.ToString().Split('|');
                    if (t.Length == 5)
                    {
                        dr["IdCatalogoMae"] = t[0].ToString();
                        dr["Auxiliar"] = t[1].ToString();
                        dr["Estatus"] = t[2].ToString() == "True" ? "ACTIVO" : "DESACTIVADO";
                        dr["Id Catalogo"] = t[3].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            gvCatalogosGenerales.DataSource = dt;
            gvCatalogosGenerales.Columns["IdCatalogoDet"].Visible = false;
            gvCatalogosGenerales.Columns["IdCatalogoMae"].Visible = false;
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTableCatalogos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCatalogoDet");
            dt.Columns.Add("Id Catalogo");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("IdCatalogoMae");
            dt.Columns.Add("Auxiliar");
            dt.Columns.Add("Estatus");
            return dt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Editando)
                Editando = false;
            OcultarDetalle();
        }

        void OcultarDetalle()
        {
            txtAuxiliar.Text = "";
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
            gbDetalle.Visible = false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in gvCatalogosGenerales.Rows)
            {
                //si es igual entonces regresa mensaje
                if (txtDescripcion.Text.ToUpper() == row.Cells["Descripción"].Value.ToString().ToUpper())
                {
                    MessageBox.Show("Este catálogo ya fue dado de alta.");
                    return;
                }
            }
            CatalogosBE catalogo = new CatalogosBE();
            catalogo.Descripcion = txtDescripcion.Text;
            catalogo.Auxiliar = txtAuxiliar.Text;
            catalogo.Activo = chkActivo.Checked;
            catalogo.Editar = Editando;
            catalogo.Id = IdCatalogoDet.ToString();
            catalogo.IdCatalogoMae = IdCatalogoMae;
            try
            {
                new OrtopediaService.OrtopediaServiceClient().GuardaCatalogo(catalogo);
                if (!Editando)
                    MessageBox.Show("Se Registró con éxito.", "Mensaje", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Se Actualizó con éxito.", "Mensaje", MessageBoxButtons.OK);

                LlenaInformacionGrid();
                OcultarDetalle();
            }
            catch (Exception ex)
            {
                OcultarDetalle();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Editando = false;
            gbDetalle.Visible = true;
            chkActivo.Checked = true;
        }

        private void gvCatalogosGenerales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            IdCatalogoDet = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdCatalogoDet"].Value.ToString());
            Descripcion = ((DataGridView)sender).Rows[e.RowIndex].Cells["Descripción"].Value.ToString();
            Auxiliar = ((DataGridView)sender).Rows[e.RowIndex].Cells["Auxiliar"].Value.ToString();
            Activo = ((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO" ? true : false;
            btnEditar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            gbDetalle.Visible = true;
            txtDescripcion.Text = Descripcion;
            txtAuxiliar.Text = Auxiliar;
            chkActivo.Checked = Activo;
            Editando = true;
        }

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

    }
}
