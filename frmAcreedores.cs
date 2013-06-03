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
using Ortopedia.UI.Properties;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Ortopedia.UI
{
    public partial class frmAcreedores : Form
    {
        public bool Editando { get; set; }
        public int IdAcreedor { get; set; }
        public AcreedoresBE acreedorEdit { get; set; }

        public frmAcreedores()
        {
            InitializeComponent();
            //gradiente1.Imagen = System.Drawing.Image.FromStream(Resources.editar);
            gradiente1.img = Properties.Resources.acreedor;
            gradiente1.Imagen = "Editar";
            
        }

        void LlenaInformacionGrid()
        {
           
            List<AcreedoresBE> lista = new List<AcreedoresBE>();
            DataTable dt = CreaDataTable();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            
            lista = new OrtopediaService.OrtopediaServiceClient().ObtieneListaAcreedores(textBox1.Text);

            if (lista.Count > 0)
                btnImprimir.Enabled = true;
            else
                btnImprimir.Enabled = false;

            foreach (AcreedoresBE m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdAcreedor"] = m.IdAcreedor;
                dr["Nombre"] = m.Nombre;
                dr["Contacto"] = m.Contacto;
                dr["DescPuesto"] = m.DescPuesto;
                dr["IdPuesto"] = m.IdPuesto;
                dr["Estatus"] = (m.Estatus) ? "ACTIVO" : "INACTIVO";
                dr["VerDirecciones"] = new Bitmap(Resources.dirs, new Size(18, 18));
                dr["VerMails"] = new Bitmap(Resources.mail, new Size(18, 18));
                dr["VerTelefonos"] = new Bitmap(Resources.phone, new Size(18, 18));
                dt.Rows.Add(dr);
            }

            gvPacientes.DataSource = dt;
            gvPacientes.Columns["IdAcreedor"].Visible = false;
            gvPacientes.Columns["IdPuesto"].Visible = false;
            gvPacientes.Columns["Estatus"].Visible = false;
            gvPacientes.Columns["DescPuesto"].HeaderText = "Puesto";
            gvPacientes.Columns["VerDirecciones"].HeaderText = "";
            gvPacientes.Columns["VerMails"].HeaderText = "";
            gvPacientes.Columns["VerTelefonos"].HeaderText = "";
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdAcreedor");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Contacto");
            dt.Columns.Add("DescPuesto");
            dt.Columns.Add("IdPuesto");
            dt.Columns.Add("Estatus");
            dt.Columns.Add("VerDirecciones", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerMails", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerTelefonos", typeof(System.Drawing.Bitmap));
            return dt;
        }

        void cargarCatalogosDetalle()
        {
            ddlEstados.Items.Clear();
            ddlCiudades.Items.Clear();
            ddlMails.Items.Clear();
            ddlTelefonos.Items.Clear();

            List<CatalogosBE> catalogo = new List<CatalogosBE>();

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Mails).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlMails, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Telefonos).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlTelefonos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Estados).ToString(), "E", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEstados, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Puestos).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlPuestos, true, catalogo);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            cargarCatalogosDetalle();

            gbDetalle.Visible = true;
            txtNombre.Text = acreedorEdit.Nombre;
            txtContacto.Text = acreedorEdit.Contacto;

            int posicion = 0;
            posicion = ddlPuestos.FindStringExact(acreedorEdit.DescPuesto, -1);
            ddlPuestos.SelectedIndex = posicion;

            chkActivo.Checked = acreedorEdit.Estatus;

             IdAcreedor = acreedorEdit.IdAcreedor;

            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            lbDirecciones.Items.Clear();

            foreach (MailsBE m in acreedorEdit.ListaMails)
            {
                ComboItem c = new ComboItem();
                c.Text = m.DescTipoMail + " " + m.Mail;
                c.Value = m.Mail;
                c.Tag = m.TipoMail.ToString();
                lbMails.Items.Add(c);

            }

            foreach (TelefonosBE t in acreedorEdit.ListaTelefonos)
            {
                ComboItem c = new ComboItem();
                c.Text = t.DescTelefono + " " + t.Telefono;
                c.Value = t.Telefono;
                c.Tag = t.TipoTelefono.ToString();
                lbTelefonos.Items.Add(c);
            }

            foreach (DireccionesBE d in acreedorEdit.ListaDirecciones)
            {
                ComboItem c = new ComboItem();
                c.Text = d.Calle + " " + d.Colonia + " " + d.CP.ToString() + " " + d.DescEstado + " " + d.DescCiudad;
                c.Value = d.Calle + "|" + d.Colonia + "|" + d.CP.ToString() + "|" + d.Estado.ToString() + "|" + d.Ciudad.ToString();
                lbDirecciones.Items.Add(c);

            }
            Editando = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text) ||
                lbDirecciones.Items.Count == 0 ||
                lbTelefonos.Items.Count == 0)
            {
                MessageBox.Show("Faltan datos por capturar.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {

                string validacion = "";
                AcreedoresBE acreedor = new AcreedoresBE();
                acreedor.Nombre = txtNombre.Text;
                validacion = new OrtopediaService.OrtopediaServiceClient().ValidaExistenciaAcreedor(acreedor);

                if (Editando)
                    validacion = "0";


                if (validacion == "1")
                {
                    MessageBox.Show("Este acreedor ya está registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    AcreedoresBE m = new AcreedoresBE();
                    m.Nombre = txtNombre.Text;

                    m.Estatus = chkActivo.Checked;
                    m.Editando = Editando;
                    m.IdAcreedor = IdAcreedor;
                    m.Contacto = txtContacto.Text;
                    m.IdPuesto = ((ComboItem)ddlPuestos.SelectedItem).Value.ToString();
                    m.DescPuesto = ((ComboItem)ddlPuestos.SelectedItem).Text.ToString();

                    List<MailsBE> listaMails = new List<MailsBE>();
                    List<TelefonosBE> listaTelefonos = new List<TelefonosBE>();
                    List<DireccionesBE> listaDirecciones = new List<DireccionesBE>();

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
                    bool respuesta = new OrtopediaService.OrtopediaServiceClient().InsertaAcreedor(m);

                    try
                    {
                        if (respuesta)
                        {
                            if (!Editando)
                                MessageBox.Show("Se registró el acreedor con éxito.", "Mensaje", MessageBoxButtons.OK);
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

        void OcultarDetalle()
        {
            ddlEstados.Items.Clear();
            ddlCiudades.Items.Clear();
            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            lbDirecciones.Items.Clear();
            ddlCiudades.Text = "";
            txtNombre.Text = "";
            txtCalle.Text = "";
            txtContacto.Text = "";
            ddlPuestos.Items.Clear();
            txtColonia.Text = "";
            txtCp.Text = "";
            chkActivo.Checked = false;
            gbDetalle.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Editando)
                Editando = false;
            OcultarDetalle();
            ddlCiudades.Items.Clear();
        }

        private void gvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            acreedorEdit = new AcreedoresBE();
            if (e.RowIndex >= 0)
            {
                acreedorEdit.Nombre = ((DataGridView)sender).Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                
                acreedorEdit.Contacto = ((DataGridView)sender).Rows[e.RowIndex].Cells["Contacto"].Value.ToString();
                acreedorEdit.DescPuesto = ((DataGridView)sender).Rows[e.RowIndex].Cells["DescPuesto"].Value.ToString();
                acreedorEdit.IdPuesto= ((DataGridView)sender).Rows[e.RowIndex].Cells["IdPuesto"].Value.ToString();
                
                acreedorEdit.Estatus = (((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO") ? true : false;
                acreedorEdit.IdAcreedor = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdAcreedor"].Value.ToString());
                btnEditar.Enabled = true;

                List<MailsBE> mails = new List<MailsBE>();
                mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(acreedorEdit.IdAcreedor);

                List<TelefonosBE> tels = new List<TelefonosBE>();
                tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(acreedorEdit.IdAcreedor);

                List<DireccionesBE> dirs = new List<DireccionesBE>();
                dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesAcreedor(acreedorEdit.IdAcreedor);

                acreedorEdit.ListaDirecciones = dirs;
                acreedorEdit.ListaMails = mails;
                acreedorEdit.ListaTelefonos = tels;

                if (e.ColumnIndex == 6)
                {
                    frmDirecciones frm = new frmDirecciones();
                    frm.listaDirecciones = dirs;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Direcciones";
                    frm.ShowDialog();
                }

                if (e.ColumnIndex == 7)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaMails = mails;
                    frm.listaTelefonos = new List<TelefonosBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Mails";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 8)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaTelefonos = tels;
                    frm.listaMails = new List<MailsBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Teléfonos";
                    frm.ShowDialog();
                }
            }
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

        private void txtCp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmAcreedores_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //This is the absolute path to the PDF that we will create
            string outputFile = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RutaImpresion"].ToString(), "pdf_" + Guid.NewGuid().ToString() + ".pdf");

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Create a new PDF document setting the size to A4
                using (Document doc = new Document(PageSize.A4,0,0,100,100))
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
                            //celdaTitle2.Phrase = new Phrase(gvPacientes.Rows[i].Cells["Estatus"].Value.ToString(), times);

                            t.AddCell(celdaTitle);
                            //t.AddCell(celdaTitle2);

                            //se agrega espacio
                            PdfPCell espacio = new PdfPCell();
                            espacio.BorderWidth = 0;
                            espacio.Colspan = 2;
                            t.AddCell(espacio);


                            iTextSharp.text.Font fuente = new iTextSharp.text.Font();
                            

                            //obtengo direcciones de acreedores

                            List<DireccionesBE> dirs = new List<DireccionesBE>();
                            dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdAcreedor"].Value.ToString()));
                            
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


                            //mails
                            List<MailsBE> mails = new List<MailsBE>();
                            mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdAcreedor"].Value.ToString()));

                            //PdfPCell celdaMail = new PdfPCell();
                            //celdaMail.Colspan = 2;
                            //celdaMail.BackgroundColor = new BaseColor(61, 216, 255);
                            //celdaMail.Phrase = new Phrase("Mails", fuente);
                            //t.AddCell(celdaMail);

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
                            else
                            {
                                //PdfPCell celdavacia = new PdfPCell();
                                //celdavacia.Colspan = 2;
                                //celdavacia.Phrase = new Phrase("No se encontraron registros.");
                                //t.AddCell(celdavacia);
                            }


                            //espacio
                            t.AddCell(espacio);



                            //telefonos
                            List<TelefonosBE> tels = new List<TelefonosBE>();
                            tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdAcreedor"].Value.ToString()));

                            //PdfPCell celdaTel = new PdfPCell();
                            //celdaTel.Colspan = 2;
                            //celdaTel.BackgroundColor = new BaseColor(61, 216, 255);
                            //celdaTel.Phrase = new Phrase("Teléfonos", fuente);
                            //t.AddCell(celdaTel);

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
                            else
                            {
                                //PdfPCell celdavacia = new PdfPCell();
                                //celdavacia.Colspan = 2;
                                //celdavacia.Phrase = new Phrase("No se encontraron registros.");
                                //t.AddCell(celdavacia);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }
    }

    public class eventosPagina : PdfPageEventHelper
    {
        public override void  OnStartPage(PdfWriter writer, Document document)
        {
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resources.pie_pagina, System.Drawing.Imaging.ImageFormat.Bmp);

            jpg.ScaleToFit(6000, 140);
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            jpg.SetAbsolutePosition(0, 0);

            document.Add(jpg);

            iTextSharp.text.Image jpg2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resources.Encabezado, System.Drawing.Imaging.ImageFormat.Bmp);

            jpg2.ScaleToFit(600, 140);
            jpg2.Alignment = iTextSharp.text.Image.UNDERLYING;
            jpg2.SetAbsolutePosition(0, 740);

            document.Add(jpg2);

        }
    }

}
