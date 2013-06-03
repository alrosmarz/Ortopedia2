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
using Ortopedia.UI.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Ortopedia.UI
{
    public partial class frmProveedores : Form
    {
        public bool Editando { get; set; }
        public int IdProveedor { get; set; }
        public ProveedoresBE proveedorEdit { get; set; }

        public frmProveedores()
        {
            InitializeComponent();
            gradiente1.img = Properties.Resources.proveedor;
            gradiente1.Imagen = "Cliente";
            
        }

        void LlenaInformacionGrid()
        {
            List<ProveedoresBE> lista = new List<ProveedoresBE>();
            DataTable dt = CreaDataTable();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            lista = new OrtopediaService.OrtopediaServiceClient().ObtieneListaProveedores(textBox1.Text, textBox2.Text);
            
            if (lista.Count > 0)
                btnImprimir.Enabled = true;
            else
                btnImprimir.Enabled = false;

            foreach (ProveedoresBE m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdProveedor"] = m.IdProveedor;
                dr["Nombre"] = m.Nombre;
                dr["RFC"] = m.RFC;
                dr["Credito"] = m.Credito.ToString();
                dr["Observaciones"] = m.Observaciones;
                dr["RVentas"] = m.RVentas;
                dr["Gerente"] = m.Gerente;
                dr["Cobranzas"] = m.Cobranzas;
                dr["Horario"] = m.Horario;
                dr["Estatus"] = (m.Estatus) ? "ACTIVO" : "INACTIVO";
                dr["VerDirecciones"] = new Bitmap(Resources.dirs, new Size(18, 18));
                dr["VerMails"] = new Bitmap(Resources.mail, new Size(18, 18));
                dr["VerTelefonos"] = new Bitmap(Resources.phone, new Size(18, 18));
                dr["VerCuentas"] = new Bitmap(Resources.bank, new Size(18, 18));
                dt.Rows.Add(dr);
            }

            gvPacientes.DataSource = dt;
            gvPacientes.Columns["IdProveedor"].Visible = false;
            gvPacientes.Columns["Estatus"].Visible = false;
            gvPacientes.Columns["VerDirecciones"].HeaderText = "";
            gvPacientes.Columns["VerMails"].HeaderText = "";
            gvPacientes.Columns["VerTelefonos"].HeaderText = "";
            gvPacientes.Columns["VerCuentas"].HeaderText = "";
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProveedor");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("RFC");
            dt.Columns.Add("Credito");
            dt.Columns.Add("Observaciones");
            dt.Columns.Add("RVentas");
            dt.Columns.Add("Gerente");
            dt.Columns.Add("Cobranzas");
            dt.Columns.Add("Horario");
            dt.Columns.Add("Estatus");
            dt.Columns.Add("VerDirecciones", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerMails", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerTelefonos", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerCuentas", typeof(System.Drawing.Bitmap));
            return dt;
        }

        private void gbDetalle_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCalle.Text) &&
               !string.IsNullOrEmpty(txtColonia.Text) &&
               !string.IsNullOrEmpty(txtCp.Text) && ddlEstados.SelectedIndex > 0 && ddlCiudades.SelectedIndex > 0)
            {
                foreach (ComboItem item in lbDirecciones.Items)
                {
                    if (txtCalle.Text + "|" + txtColonia.Text + "|" + txtCp.Text + "|" + ((ComboItem)ddlEstados.SelectedItem).Value.ToString() + "|" + ((ComboItem)ddlCiudades.SelectedItem).Value.ToString() ==
                        item.Value.ToString())
                    {
                        MessageBox.Show("Esta dirección ya fue capturada.");
                        return;
                    }
                }
                ComboItem c = new ComboItem();
                c.Text = txtCalle.Text + " " + txtColonia.Text + " " + txtCp.Text + " " + ddlEstados.Text + " " + ddlCiudades.Text;
                c.Value = txtCalle.Text + "|" + txtColonia.Text + "|" + txtCp.Text + "|" + ((ComboItem)ddlEstados.SelectedItem).Value.ToString() + "|" + ((ComboItem)ddlCiudades.SelectedItem).Value.ToString(); ;
                lbDirecciones.Items.Add(c);
                txtCalle.Text = "";
                txtCp.Text = "";
                txtColonia.Text = "";
                ddlEstados.SelectedIndex = 0;
                ddlCiudades.Text = "";
                ddlCiudades.Items.Clear();
                txtCalle.Focus();
            }
            else
            {
                MessageBox.Show("No has capturado la dirección completa");
            }
        }

        private void btnAgregarMail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMail.Text) && ddlMails.SelectedIndex > 0)
            {
                foreach (ComboItem item in lbMails.Items)
                {
                    if (txtMail.Text == item.Value && ((ComboItem)ddlMails.SelectedItem).Value.ToString() == item.Tag.ToString())
                    {
                        MessageBox.Show("Este mail ya fue agregado.");
                        return;
                    }
                }
                ComboItem c = new ComboItem();
                c.Text = ((ComboItem)ddlMails.SelectedItem).Text.ToString() + " " + txtMail.Text;
                c.Value = txtMail.Text;
                c.Tag = ((ComboItem)ddlMails.SelectedItem).Value.ToString();
                lbMails.Items.Add(c);
                txtMail.Text = "";
                txtMail.Focus();
            }
            else
                MessageBox.Show("No has seleccionado un tipo de mail y/o falta capturar mail.");
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefono.Text) && ddlTelefonos.SelectedIndex > 0)
            {
                foreach (ComboItem item in lbTelefonos.Items)
                {
                    if (txtTelefono.Text == item.Value && ((ComboItem)ddlTelefonos.SelectedItem).Value.ToString() == item.Tag.ToString())
                    {
                        MessageBox.Show("Este teléfono ya fue agregado.");
                        return;
                    }
                }

                ComboItem c = new ComboItem();
                c.Text = ((ComboItem)ddlTelefonos.SelectedItem).Text.ToString() + " " + txtTelefono.Text;
                c.Value = txtTelefono.Text;
                c.Tag = ((ComboItem)ddlTelefonos.SelectedItem).Value.ToString();
                lbTelefonos.Items.Add(c);
                txtTelefono.Text = "";
                txtTelefono.Focus();
            }
            else
                MessageBox.Show("No has seleccionado un tipo de teléfono y/o falta capturar teléfono.");
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoCuenta.Text) &&
               !string.IsNullOrEmpty(txtNombreCuenta.Text) &&
               !string.IsNullOrEmpty(txtSucursal.Text) && 
               ddlEstadoCuenta.SelectedIndex > 0 && 
               ddlCiudadCuenta.SelectedIndex > 0 &&
               ddlBanco.SelectedIndex > 0)
            {
                ComboItem c = new ComboItem();
                c.Text = ddlBanco.Text + " " + txtNombreCuenta.Text + " " + txtNoCuenta.Text + " " + txtClabe.Text;
                c.Value = ((ComboItem)ddlBanco.SelectedItem).Value.ToString() + "|" + txtNombreCuenta.Text + "|" + txtNoCuenta.Text + "|" + txtSucursal.Text + "|" + txtObservacionesCuenta.Text + "|" + ((ComboItem)ddlEstadoCuenta.SelectedItem).Value.ToString() + "|" + ((ComboItem)ddlCiudadCuenta.SelectedItem).Value.ToString() + "|" + txtClabe.Text; 
                lbCuentas.Items.Add(c);
                txtNombreCuenta.Text = "";
                txtClabe.Text = "";
                txtNoCuenta.Text = "";
                txtSucursal.Text = "";
                txtObservacionesCuenta.Text = "";
                ddlEstadoCuenta.SelectedIndex = 0;
                ddlCiudadCuenta.Text = "";
                ddlCiudadCuenta.Items.Clear();
                ddlBanco.SelectedIndex = 0;
                txtNombreCuenta.Focus();
            }
            else
            {
                MessageBox.Show("No has capturado la información necesaria.");
            }
        }

        private void btnQuitarDireccion_Click(object sender, EventArgs e)
        {
            lbDirecciones.Items.Remove(lbDirecciones.SelectedItems[0]);
        }

        private void btnQuitaMail_Click(object sender, EventArgs e)
        {
            lbMails.Items.Remove(lbMails.SelectedItems[0]);
        }

        private void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            lbTelefonos.Items.Remove(lbTelefonos.SelectedItems[0]);
        }

        private void btnQuitarCuenta_Click(object sender, EventArgs e)
        {
            lbCuentas.Items.Remove(lbCuentas.SelectedItems[0]);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            gbDetalle.Visible = true;

            cargarCatalogosDetalle();
            ddlCiudades.Items.Clear();
            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            lbDirecciones.Items.Clear();
            chkActivo.Checked = true;

            Editando = false;
        }

        void OcultarDetalle()
        {
            ddlEstados.Items.Clear();
            ddlCiudades.Items.Clear();
            ddlCiudades.Text = "";
            txtNombre.Text = "";
            txtCalle.Text = "";
            txtColonia.Text = "";
            txtCp.Text = "";
            chkActivo.Checked = false;
            gbDetalle.Visible = false;
        }

        void cargarCatalogosDetalle()
        {
            ddlEstados.Items.Clear();
            ddlCiudades.Items.Clear();
            ddlMails.Items.Clear();
            ddlTelefonos.Items.Clear();
            ddlBanco.Items.Clear();
            ddlEstadoCuenta.Items.Clear();
            ddlCiudadCuenta.Items.Clear();

            List<CatalogosBE> catalogo = new List<CatalogosBE>();

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Mails).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlMails, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Telefonos).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlTelefonos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Estados).ToString(), "E", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEstados, true, catalogo);
            Funciones.LlenarDropDownCatalogo(ddlEstadoCuenta, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Bancos).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlBanco, true, catalogo);
        }

        private void ddlEstadoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoCuenta.SelectedIndex > 0)
            {
                ddlCiudadCuenta.Items.Clear();
                List<CatalogosBE> catalogo = new List<CatalogosBE>();

                catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Ciudades).ToString(), ((ComboItem)ddlEstadoCuenta.SelectedItem).Value.ToString(), "", "");
                Funciones.LlenarDropDownCatalogo(ddlCiudadCuenta, true, catalogo);

            }
        }

        private void gbDirecciones_Enter(object sender, EventArgs e)
        {

        }

        private void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstados.SelectedIndex > 0)
            {
                ddlCiudades.Items.Clear();
                List<CatalogosBE> catalogo = new List<CatalogosBE>();

                catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Ciudades).ToString(), ((ComboItem)ddlEstados.SelectedItem).Value.ToString(), "", "");
                Funciones.LlenarDropDownCatalogo(ddlCiudades, true, catalogo);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Editando)
                Editando = false;
            OcultarDetalle();
            ddlCiudades.Items.Clear();
            ddlCiudadCuenta.Items.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            cargarCatalogosDetalle();

            gbDetalle.Visible = true;
            txtNombre.Text = proveedorEdit.Nombre;
            txtRVentas.Text = proveedorEdit.RVentas;
            txtRFC.Text = proveedorEdit.RFC;
            txtHorario.Text = proveedorEdit.Horario;
            txtCredito.Text = proveedorEdit.Credito.ToString();
            txtGerente.Text = proveedorEdit.Gerente;
            txtCobranzas.Text = proveedorEdit.Cobranzas;
            txtObservacionesProveedor.Text = proveedorEdit.Observaciones;

            chkActivo.Checked = proveedorEdit.Estatus;

            IdProveedor = proveedorEdit.IdProveedor;

            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            lbDirecciones.Items.Clear();
            lbCuentas.Items.Clear();

            foreach (MailsBE m in proveedorEdit.ListaMails)
            {
                ComboItem c = new ComboItem();
                c.Text = m.DescTipoMail + " " + m.Mail;
                c.Value = m.Mail;
                c.Tag = m.TipoMail.ToString();
                lbMails.Items.Add(c);

            }

            foreach (TelefonosBE t in proveedorEdit.ListaTelefonos)
            {
                ComboItem c = new ComboItem();
                c.Text = t.DescTelefono + " " + t.Telefono;
                c.Value = t.Telefono;
                c.Tag = t.TipoTelefono.ToString();
                lbTelefonos.Items.Add(c);
            }

            foreach (DireccionesBE d in proveedorEdit.ListaDirecciones)
            {
                ComboItem c = new ComboItem();
                c.Text = d.Calle + " " + d.Colonia + " " + d.CP.ToString() + " " + d.DescEstado + " " + d.DescCiudad;
                c.Value = d.Calle + "|" + d.Colonia + "|" + d.CP.ToString() + "|" + d.Estado.ToString() + "|" + d.Ciudad.ToString();
                lbDirecciones.Items.Add(c);

            }

            foreach (CuentasBE b in proveedorEdit.ListaCuentas)
            {
                ComboItem c = new ComboItem();
                c.Text = b.DescBanco + " " + b.NombreCuenta + " " + b.NoCuenta + " " + b.Clabe;
                c.Value = b.IdBanco.ToString() + "|" + b.NombreCuenta + "|" + b.NoCuenta + "|" + b.Sucursal + "|" + b.Observaciones + "|" + b.Estado.ToString() + "|" + b.Ciudad.ToString() + "|" + b.Clabe; 
                lbCuentas.Items.Add(c);
            }
            Editando = true;
        }

        private void gvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            proveedorEdit = new ProveedoresBE();
            if (e.RowIndex >= 0)
            {
                proveedorEdit.Nombre = ((DataGridView)sender).Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                proveedorEdit.RVentas = ((DataGridView)sender).Rows[e.RowIndex].Cells["RVentas"].Value.ToString();
                proveedorEdit.RFC = ((DataGridView)sender).Rows[e.RowIndex].Cells["RFC"].Value.ToString();
                proveedorEdit.Horario  = ((DataGridView)sender).Rows[e.RowIndex].Cells["Horario"].Value.ToString();
                proveedorEdit.Cobranzas = ((DataGridView)sender).Rows[e.RowIndex].Cells["Cobranzas"].Value.ToString();
                proveedorEdit.Credito = ((DataGridView)sender).Rows[e.RowIndex].Cells["Credito"].Value.ToString();
                proveedorEdit.Gerente = ((DataGridView)sender).Rows[e.RowIndex].Cells["Gerente"].Value.ToString();
                proveedorEdit.Estatus = (((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO") ? true : false;
                proveedorEdit.Observaciones = ((DataGridView)sender).Rows[e.RowIndex].Cells["Observaciones"].Value.ToString();
                proveedorEdit.IdProveedor = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdProveedor"].Value.ToString());
                btnEditar.Enabled = true;

                List<MailsBE> mails = new List<MailsBE>();
                mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsProveedor(proveedorEdit.IdProveedor);

                List<TelefonosBE> tels = new List<TelefonosBE>();
                tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosProveedor(proveedorEdit.IdProveedor);

                List<DireccionesBE> dirs = new List<DireccionesBE>();
                dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesProveedor(proveedorEdit.IdProveedor);

                List<CuentasBE> cta = new List<CuentasBE>();
                cta = new OrtopediaService.OrtopediaServiceClient().ObtieneCuentasProveedor(proveedorEdit.IdProveedor);

                proveedorEdit.ListaDirecciones = dirs;
                proveedorEdit.ListaMails = mails;
                proveedorEdit.ListaTelefonos = tels;
                proveedorEdit.ListaCuentas = cta;

                if (e.ColumnIndex == 10)
                {
                    frmDirecciones frm = new frmDirecciones();
                    frm.listaDirecciones = dirs;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Direcciones";
                    frm.ShowDialog();
                }

                if (e.ColumnIndex == 11)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaMails = mails;
                    frm.listaTelefonos = new List<TelefonosBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Mails";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 12)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaTelefonos = tels;
                    frm.listaMails = new List<MailsBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Teléfonos";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 13)
                {
                    frmCuentasBanco frm = new frmCuentasBanco();
                    frm.cuentas = cta;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Cuentas";
                    frm.ShowDialog();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtRVentas.Text) ||
                string.IsNullOrEmpty(txtGerente.Text) ||
                string.IsNullOrEmpty(txtCobranzas.Text) ||
                string.IsNullOrEmpty(txtRFC.Text) ||
                string.IsNullOrEmpty(txtHorario.Text) ||
                string.IsNullOrEmpty(txtCredito.Text) ||
                string.IsNullOrEmpty(txtObservacionesProveedor.Text) ||
                lbDirecciones.Items.Count == 0 ||
                lbTelefonos.Items.Count == 0)
            {
                MessageBox.Show("Faltan datos por capturar.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                string validacion = "";
                ProveedoresBE proveedor = new ProveedoresBE();
                proveedor.Nombre = txtNombre.Text;
                proveedor.RFC = txtRFC.Text;
                validacion = new OrtopediaService.OrtopediaServiceClient().ValidaExistenciaProveedor(proveedor);
                
                if (Editando)
                    validacion = "0";

                if (validacion == "1")
                {
                    MessageBox.Show("Este proveedor ya está registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    ProveedoresBE m = new ProveedoresBE();
                    m.Nombre = txtNombre.Text;
                    m.Cobranzas = txtCobranzas.Text;
                    m.Credito = txtCredito.Text;
                    m.Gerente = txtGerente.Text;
                    m.Horario = txtHorario.Text;
                    m.Observaciones = txtObservacionesProveedor.Text;
                    m.RFC = txtRFC.Text;
                    m.RVentas = txtRVentas.Text;

                    m.Estatus = chkActivo.Checked;
                    m.Editando = Editando;
                    m.IdProveedor = IdProveedor;
                    List<MailsBE> listaMails = new List<MailsBE>();
                    List<TelefonosBE> listaTelefonos = new List<TelefonosBE>();
                    List<DireccionesBE> listaDirecciones = new List<DireccionesBE>();
                    List<CuentasBE> listaCuentas = new List<CuentasBE>();

                    if (lbDirecciones.Items.Count > 0)
                    {
                        foreach (ComboItem item in lbDirecciones.Items)
                        {
                            DireccionesBE d = new DireccionesBE();
                            string[] temp = item.Value.ToString().Split('|');
                            d.Calle = temp[0].ToString();
                            d.Colonia = temp[1].ToString();
                            d.CP = int.Parse(temp[2].ToString());
                            d.Estado = int.Parse(temp[3].ToString());
                            d.Ciudad = int.Parse(temp[4].ToString());

                            listaDirecciones.Add(d);
                        }
                    }

                    if (lbCuentas.Items.Count > 0)
                    {
                        foreach (ComboItem item in lbCuentas.Items)
                        {
                            CuentasBE d = new CuentasBE();
                            string[] temp = item.Value.ToString().Split('|');
                            //c.Value = b.IdBanco.ToString() + "|" + b.NombreCuenta + "|" + b.NoCuenta + "|" + b.Sucursal + "|" + b.Observaciones + "|" + b.Estado.ToString() + "|" + b.Ciudad.ToString(); 
                            d.IdBanco = int.Parse(temp[0].ToString());
                            d.NombreCuenta = temp[1].ToString();
                            d.NoCuenta = temp[2].ToString();
                            d.Sucursal = temp[3].ToString();
                            d.Observaciones = temp[4].ToString();
                            d.Estado = int.Parse(temp[5].ToString());
                            d.Ciudad = int.Parse(temp[6].ToString());
                            d.Clabe = temp[7].ToString();
                            listaCuentas.Add(d);
                        }
                    }

                    if (lbMails.Items.Count > 0)
                    {

                        foreach (ComboItem item in lbMails.Items)
                        {
                            MailsBE mail = new MailsBE();
                            mail.TipoMail = int.Parse(item.Tag.ToString());
                            mail.Mail = item.Value;
                            listaMails.Add(mail);
                        }
                    }

                    if (lbTelefonos.Items.Count > 0)
                    {
                        foreach (ComboItem item in lbTelefonos.Items)
                        {
                            TelefonosBE telefono = new TelefonosBE();
                            telefono.TipoTelefono = int.Parse(item.Tag.ToString());
                            telefono.Telefono = item.Value;
                            listaTelefonos.Add(telefono);
                        }

                    }

                    m.ListaMails = listaMails;
                    m.ListaTelefonos = listaTelefonos;
                    m.ListaDirecciones = listaDirecciones;
                    m.ListaCuentas = listaCuentas;
                    bool respuesta = new OrtopediaService.OrtopediaServiceClient().InsertaProveedor(m);

                    try
                    {
                        if (respuesta)
                        {
                            if (!Editando)
                                MessageBox.Show("Se registró el proveedor con éxito.", "Mensaje", MessageBoxButtons.OK);
                            else
                                MessageBox.Show("Se actualizó la información con éxito.", "Mensaje", MessageBoxButtons.OK);

                            LlenaInformacionGrid();
                            OcultarDetalle();
                        }
                    }
                    catch (Exception ex)
                    {
                        OcultarDetalle();
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

        }

        private void txtCp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtClabe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNoCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //This is the absolute path to the PDF that we will create
            string outputFile = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RutaImpresion"].ToString(), "pdf_" + Guid.NewGuid().ToString() + ".pdf");

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Create a new PDF document setting the size to A4
                using (Document doc = new Document(PageSize.A4, 0, 0, 100, 100))
                {
                    //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
                    using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                    {
                        //Open the document for writing
                        doc.Open();
                        eventosPagina eventopagina = new eventosPagina();
                        w.PageEvent = eventopagina;

                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resources.pie_pagina, System.Drawing.Imaging.ImageFormat.Bmp);

                        jpg.ScaleToFit(6000, 140);
                        jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                        jpg.SetAbsolutePosition(0, 0);

                        doc.Add(jpg);

                        iTextSharp.text.Image jpg2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resources.Encabezado, System.Drawing.Imaging.ImageFormat.Bmp);

                        jpg2.ScaleToFit(600, 140);
                        jpg2.Alignment = iTextSharp.text.Image.UNDERLYING;
                        jpg2.SetAbsolutePosition(0, 740);

                        doc.Add(jpg2);

                        //Create a table with two columns
                        PdfPTable t = new PdfPTable(2);


                        //obtengo todos los datos de cada registro del grid
                        for (int i = 0; i < gvPacientes.Rows.Count; i++)
                        {
                            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                            PdfPCell celdaTitle = new PdfPCell();
                            //celdaTitle.BackgroundColor = new BaseColor(61, 216, 255);
                            celdaTitle.BorderWidth = 0;
                            celdaTitle.Colspan = 2;
                            celdaTitle.Phrase = new Phrase(gvPacientes.Rows[i].Cells["Nombre"].Value.ToString(), times);


                            //PdfPCell celdaTitle2 = new PdfPCell();
                            ////celdaTitle2.BackgroundColor = new BaseColor(61, 216, 255);
                            //celdaTitle2.BorderWidth = 0;
                            //celdaTitle2.Phrase = new Phrase(gvMedicos.Rows[i].Cells["Estatus"].Value.ToString(), times);

                            t.AddCell(celdaTitle);
                            //t.AddCell(celdaTitle2);

                            //se agrega espacio
                            PdfPCell espacio = new PdfPCell();
                            espacio.BorderWidth = 0;
                            espacio.Colspan = 2;
                            t.AddCell(espacio);


                            iTextSharp.text.Font fuente = new iTextSharp.text.Font();

                            string textoInfo = "";
                            PdfPCell celdainfo = new PdfPCell();
                            celdainfo.Colspan = 2;
                            celdainfo.BackgroundColor = new BaseColor(61, 216, 255);

                            //llena la informacion necesaria para mostrar los datos de cada registro
                            textoInfo = "RFC: " + gvPacientes.Rows[i].Cells["RFC"].Value.ToString() + "Crédito: " + gvPacientes.Rows[i].Cells["RFC"].Value.ToString() +
                                Environment.NewLine + Environment.NewLine +
                                "Ventas: " + gvPacientes.Rows[i].Cells["RVentas"].Value.ToString() + " Gerente: " + gvPacientes.Rows[i].Cells["Gerente"].Value.ToString() +
                                " Cobranzas: " + gvPacientes.Rows[i].Cells["Cobranzas"].Value.ToString() + " Horario: " + gvPacientes.Rows[i].Cells["Horario"].Value.ToString()
                                + " Observaciones: " + gvPacientes.Rows[i].Cells["Observaciones"].Value.ToString(); 
                                   
                            celdainfo.Phrase = new Phrase(textoInfo);
                            t.AddCell(celdainfo);


                            t.AddCell(espacio);
                            List<DireccionesBE> dirs = new List<DireccionesBE>();
                            dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdProveedor"].Value.ToString()));

                            if (dirs.Count > 0)
                            {

                                string textoDirs = "";
                                PdfPCell c = new PdfPCell();
                                c.Colspan = 2;
                                c.BackgroundColor = new BaseColor(61, 216, 255);

                                foreach (DireccionesBE dir in dirs)
                                {
                                    textoDirs += dir.Calle + ", " + dir.Colonia + ", " + dir.CP.ToString() + " " + dir.DescCiudad + ", " + dir.DescEstado + Environment.NewLine;
                                }

                                c.Phrase = new Phrase(textoDirs);
                                t.AddCell(c);

                            }
                            else
                            {
                                //PdfPCell celdavacia = new PdfPCell();
                                //celdavacia.Colspan = 2;
                                //celdavacia.Phrase = new Phrase("No se encontraron registros.");
                                //t.AddCell(celdavacia);
                            }


                            //espacio
                            t.AddCell(espacio);

                            //cuentas
                            List<CuentasBE> cuentas = new List<CuentasBE>();
                            cuentas = new OrtopediaService.OrtopediaServiceClient().ObtieneCuentasProveedor(int.Parse(gvPacientes.Rows[i].Cells["IdProveedor"].Value.ToString()));


                            if (cuentas.Count > 0)
                            {
                                string textoCuenta = "Cuentas:" + Environment.NewLine;
                                PdfPCell c = new PdfPCell();
                                c.Colspan = 2;
                                //c.BorderWidth = 1;
                                c.BackgroundColor = new BaseColor(61, 216, 255);

                                foreach (CuentasBE cuenta in cuentas)
                                {
                                    textoCuenta += "Banco: " + cuenta.DescBanco + " Nombre: " + cuenta.NombreCuenta + " No. Cuenta: " + cuenta.NoCuenta + " Sucursal" + cuenta.Sucursal + " Clabe: " + cuenta.Clabe + " Ciudad/Estado:" + cuenta.DescCiudad + ", " + cuenta.DescEstado + " Observaciones:" + cuenta.Observaciones + Environment.NewLine + Environment.NewLine;
                                }

                                c.Phrase = new Phrase(textoCuenta);
                                t.AddCell(c);
                            }



                            //espacio
                            t.AddCell(espacio);


                            //mails
                            List<MailsBE> mails = new List<MailsBE>();
                            mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdProveedor"].Value.ToString()));


                            if (mails.Count > 0)
                            {
                                string textomail = "Mails:" + Environment.NewLine;
                                PdfPCell c = new PdfPCell();
                                c.Colspan = 2;
                                //c.BorderWidth = 1;
                                c.BackgroundColor = new BaseColor(61, 216, 255);

                                foreach (MailsBE mail in mails)
                                {
                                    textomail += mail.DescTipoMail + " - " + mail.Mail + Environment.NewLine;
                                }

                                c.Phrase = new Phrase(textomail);
                                t.AddCell(c);
                            }



                            //espacio
                            t.AddCell(espacio);



                            //telefonos
                            List<TelefonosBE> tels = new List<TelefonosBE>();
                            tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdProveedor"].Value.ToString()));


                            if (tels.Count > 0)
                            {
                                string textotel = "Teléfonos:" + Environment.NewLine;
                                PdfPCell c = new PdfPCell();
                                c.Colspan = 2;
                                c.BackgroundColor = new BaseColor(61, 216, 255);

                                foreach (TelefonosBE tel in tels)
                                {
                                    textotel += tel.DescTelefono + " - " + tel.Telefono + Environment.NewLine;
                                }
                                c.Phrase = new Phrase(textotel);
                                t.AddCell(c);
                            }



                            PdfPCell espacio2 = new PdfPCell();
                            espacio2.BorderWidth = 0;
                            espacio2.Colspan = 2;
                            //celdavacia.Phrase = new Phrase("No se encontraron registros.");
                            t.AddCell(espacio2);
                            t.AddCell(espacio2);
                        }

                        t.DefaultCell.Border = 0;

                        //Add the table to our document
                        doc.Add(t);

                        //Close our document
                        doc.Close();
                    }
                }
            }
            System.Diagnostics.Process.Start(outputFile);
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }
    }
}

