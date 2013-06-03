using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.BE;
using Ortopedia.UI.Shared;

namespace Ortopedia.UI
{
    public partial class frmOrtopediaBlanda : Form
    {
        public bool Editando { get; set; }
        public int IdOrtopediaBlanda { get; set; }
        public ClientesBE ortopediaEdit { get; set; }

        public frmOrtopediaBlanda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        void cargarCatalogosDetalle()
        {
            ddlEstantes.Items.Clear();
            ddlDeptos.Items.Clear();
            ddlProductos.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlTamaños.Items.Clear();

            List<CatalogosBE> catalogo = new List<CatalogosBE>();

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.EstantesOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEstantes, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.DepartamentosOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlDeptos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.ProveedoresOrtopedia).ToString(), "P", "", "");
            Funciones.LlenarDropDownCatalogo(ddlProveedor, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.ProductosOrtopedia).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlProductos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Tamaños).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlTamaños, true, catalogo);
        }

        void OcultarDetalle()
        {
            ddlEstantes.Items.Clear();
            ddlDeptos.Items.Clear();
            ddlProductos.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlTamaños.Items.Clear();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        public string RutaArchivo { get; set; }
        private void btnSeleccionarFotografia_Click(object sender, EventArgs e)
        {
            abrirArchivo.Filter = "Imágenes (*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (abrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(abrirArchivo.FileName);
                RutaArchivo = abrirArchivo.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bmp;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Editando)
                Editando = false;
            OcultarDetalle();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
