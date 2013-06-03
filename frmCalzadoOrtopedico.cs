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
    public partial class frmCalzadoOrtopedico : Form
    {
        public bool Editando { get; set; }
        public int IdOrtopediaBlanda { get; set; }
        public ClientesBE ortopediaEdit { get; set; }
        public string RutaArchivo { get; set; }
        public frmCalzadoOrtopedico()
        {
            InitializeComponent();
        }

        void cargarCatalogosDetalle()
        {
            ddlEstantes.Items.Clear();
            ddlDeptos.Items.Clear();
            ddlProductos.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlNumeros.Items.Clear();

            List<CatalogosBE> catalogo = new List<CatalogosBE>();

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.EstantesOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEstantes, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.DepartamentosOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlDeptos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.ProveedoresOrtopedia).ToString(), "P", "", "");
            Funciones.LlenarDropDownCatalogo(ddlProveedor, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.ProductosOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlProductos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.NumerosCalzado).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlNumeros, true, catalogo);
        }

        void OcultarDetalle()
        {
            ddlEstantes.Items.Clear();
            ddlDeptos.Items.Clear();
            ddlProductos.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlNumeros.Items.Clear();

            txtCodigo.Text = "";
            txtDetalle.Text = "";
            RutaArchivo = "";
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            chkActivo.Checked = false;
            gbDetalle.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            gbDetalle.Visible = true;

            cargarCatalogosDetalle();

            chkActivo.Checked = true;

            Editando = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Editando)
                Editando = false;
            OcultarDetalle();
        }

        private void btnSeleccionarFotografia_Click(object sender, EventArgs e)
        {
            abrirArchivo.Filter = "Imágenes (*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (abrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(abrirArchivo.FileName);
                RutaArchivo = abrirArchivo.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bmp;
                pictureBox1.Tag = RutaArchivo;
            }
        }

        private void btnAgregarCodigo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                foreach (ComboItem item in lbCodigos.Items)
                {
                    if (txtCodigo.Text == item.Value)
                    {
                        MessageBox.Show("Este código ya fue agregado.");
                        return;
                    }
                }

                ComboItem c = new ComboItem();
                c.Text = txtCodigo.Text;
                c.Value = txtCodigo.Text;
                c.Tag = txtCodigo;
                lbCodigos.Items.Add(c);
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
            else
                MessageBox.Show("No has escrito un código.");
        }

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                foreach (ComboItem item in lbFotos.Items)
                {
                    if (pictureBox1.Tag.ToString() == item.Value)
                    {
                        MessageBox.Show("Esta fotografía ya fue seleccionada.");
                        return;
                    }
                }

                ComboItem c = new ComboItem();
                c.Text = pictureBox1.Tag.ToString();
                c.Value = pictureBox1.Tag.ToString();
                c.Tag = pictureBox1.Image;
                lbFotos.Items.Add(c);
            }
            else
                MessageBox.Show("No has seleccionado una fotografía.");
        }

        private void btnQuitarCodigo_Click(object sender, EventArgs e)
        {
            lbCodigos.Items.Remove(lbCodigos.SelectedItems[0]);
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            lbFotos.Items.Remove(lbFotos.SelectedItems[0]);
        }
    }
}
