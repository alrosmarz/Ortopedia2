using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.BE;
using Ortopedia.UI.Properties;
using Ortopedia.UI.Shared;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Ortopedia.UI
{
    public partial class frmEmpresas : Form
    {
        public bool Editando { get; set; }
        public int IdEmpresa { get; set; }
        public EmpresasBE empresaEdit { get; set; }

        public frmEmpresas()
        {
            InitializeComponent();
            gradiente1.img = Properties.Resources.empresas;
            gradiente1.Imagen = "Empresa";
            
        }

        void LlenaInformacionGrid()
        {
            List<EmpresasBE> lista = new List<EmpresasBE>();
            DataTable dt = CreaDataTable();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            lista = new OrtopediaService.OrtopediaServiceClient().ObtieneListaEmpresas(textBox1.Text, textBox2.Text);

            if (lista.Count > 0)
                btnImprimir.Enabled = true;
            else
                btnImprimir.Enabled = false;

            foreach (EmpresasBE m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdEmpresa"] = m.IdEmpresa;
                dr["Nombre"] = m.Nombre;
                dr["RFC"] = m.RFC;
                
                dr["Contacto"] = m.Contacto;
                dr["DescPuesto"] = m.DescPuesto;
                dr["IdPuesto"] = m.IdPuesto;

                dr["Calle"] = m.Calle;
                dr["Colonia"] = m.Colonia;
                dr["CP"] = m.CP;
                dr["Ciudad"] = m.Ciudad;
                dr["Estado"] = m.Estado;
                dr["Estatus"] = (m.Estatus) ? "ACTIVO" : "INACTIVO";
                dr["Ciudad "] = m.DescCiudad;
                dr["Estado "] = m.DescEstado;
                dr["VerMails"] = new Bitmap(Resources.mail, new Size(18, 18));
                dr["VerTelefonos"] = new Bitmap(Resources.phone, new Size(18, 18));
                dt.Rows.Add(dr);
            }

            gvMedicos.DataSource = dt;
            gvMedicos.Columns["IdEmpresa"].Visible = false;
            gvMedicos.Columns["IdPuesto"].Visible = false;
            gvMedicos.Columns["Ciudad"].Visible = false;
            gvMedicos.Columns["DescPuesto"].HeaderText = "Puesto";
            gvMedicos.Columns["Estado"].Visible = false;
            gvMedicos.Columns["Estatus"].Visible = false;
            gvMedicos.Columns["VerMails"].HeaderText = "";
            gvMedicos.Columns["VerTelefonos"].HeaderText = "";
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdEmpresa");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("RFC");
            dt.Columns.Add("Contacto");
            dt.Columns.Add("DescPuesto");
            dt.Columns.Add("IdPuesto");
            dt.Columns.Add("Calle");
            dt.Columns.Add("Colonia");
            dt.Columns.Add("CP");
            dt.Columns.Add("Ciudad ");
            dt.Columns.Add("Estado ");
            dt.Columns.Add("Ciudad");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Estatus");
            dt.Columns.Add("VerMails", typeof(System.Drawing.Bitmap));
            dt.Columns.Add("VerTelefonos", typeof(System.Drawing.Bitmap));
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            gbDetalle.Visible = true;

            cargarCatalogosDetalle();
            ddlCiudades.Items.Clear();
            chkActivo.Checked = true;

            Editando = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            cargarCatalogosDetalle();

            gbDetalle.Visible = true;
            txtNombre.Text = empresaEdit.Nombre;
            txtRFC.Text = empresaEdit.RFC;

            txtContacto.Text = empresaEdit.Contacto;

            int posicion = 0;

            posicion = ddlPuestos.FindStringExact(empresaEdit.DescPuesto, -1);
            ddlPuestos.SelectedIndex = posicion;

            posicion = ddlEstados.FindStringExact(empresaEdit.DescEstado, -1);
            ddlEstados.SelectedIndex = posicion;

            posicion = ddlCiudades.FindStringExact(empresaEdit.DescCiudad, -1);
            ddlCiudades.SelectedIndex = posicion;

            txtCalle.Text = empresaEdit.Calle;
            txtColonia.Text = empresaEdit.Colonia;
            txtCp.Text = empresaEdit.CP.ToString();
            chkActivo.Checked = empresaEdit.Estatus;

            IdEmpresa = empresaEdit.IdEmpresa;

            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            foreach (MailsBE m in empresaEdit.ListaMails)
            {
                ComboItem c = new ComboItem();
                c.Text = m.DescTipoMail + " " + m.Mail;
                c.Value = m.Mail;
                c.Tag = m.TipoMail.ToString();
                lbMails.Items.Add(c);

            }

            foreach (TelefonosBE t in empresaEdit.ListaTelefonos)
            {
                ComboItem c = new ComboItem();
                c.Text = t.DescTelefono + " " + t.Telefono;
                c.Value = t.Telefono;
                c.Tag = t.TipoTelefono.ToString();
                lbTelefonos.Items.Add(c);
            }

            Editando = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtCalle.Text) ||
                string.IsNullOrEmpty(txtRFC.Text) ||
                string.IsNullOrEmpty(txtColonia.Text) ||
                string.IsNullOrEmpty(txtCp.Text) ||
                lbTelefonos.Items.Count == 0 ||
                ddlEstados.SelectedIndex == 0 ||
                ddlCiudades.SelectedIndex == 0)
            {
                MessageBox.Show("Faltan datos por capturar.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                string validacion = "";
                EmpresasBE empresa = new EmpresasBE();
                empresa.Nombre = txtNombre.Text;
                empresa.RFC = txtRFC.Text;

               


                validacion = new OrtopediaService.OrtopediaServiceClient().ValidaExistenciaEmpresa(empresa);
                if (Editando)
                    validacion = "0";

                if (validacion == "1")
                {
                    MessageBox.Show("Esta empresa ya está registrada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    EmpresasBE m = new EmpresasBE();
                    m.Nombre = txtNombre.Text;
                    m.RFC = txtRFC.Text;

                    m.Contacto = txtContacto.Text;
                    m.IdPuesto = ((ComboItem)ddlPuestos.SelectedItem).Value.ToString();
                    m.DescPuesto = ((ComboItem)ddlPuestos.SelectedItem).Text.ToString();

                    m.Calle = txtCalle.Text;
                    m.Colonia = txtColonia.Text;
                    m.CP = int.Parse(txtCp.Text);
                    m.Ciudad = int.Parse(((ComboItem)ddlCiudades.SelectedItem).Value);
                    m.Estado = int.Parse(((ComboItem)ddlEstados.SelectedItem).Value);
                    m.Estatus = chkActivo.Checked;
                    m.Editando = Editando;
                    m.IdEmpresa = IdEmpresa;
                    List<MailsBE> listaMails = new List<MailsBE>();
                    List<TelefonosBE> listaTelefonos = new List<TelefonosBE>();

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

                    bool respuesta = new OrtopediaService.OrtopediaServiceClient().InsertaEmpresa(m);

                    try
                    {
                        if (respuesta)
                        {
                            if (!Editando)
                                MessageBox.Show("Se registró la empresa con éxito.", "Mensaje", MessageBoxButtons.OK);
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
            ddlCiudades.Text = "";
            txtNombre.Text = "";
            txtRFC.Text = "";
            txtContacto.Text = "";
            ddlPuestos.Items.Clear();
            txtCalle.Text = "";
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

        private void btnQuitaMail_Click(object sender, EventArgs e)
        {
            lbMails.Items.Remove(lbMails.SelectedItems[0]);
        }

        private void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            lbTelefonos.Items.Remove(lbTelefonos.SelectedItems[0]);
        }

        private void gvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            empresaEdit = new EmpresasBE();
            if (e.RowIndex >= 0)
            {
                empresaEdit.Nombre = ((DataGridView)sender).Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                empresaEdit.RFC = ((DataGridView)sender).Rows[e.RowIndex].Cells["RFC"].Value.ToString();

                empresaEdit.Contacto = ((DataGridView)sender).Rows[e.RowIndex].Cells["Contacto"].Value.ToString();
                empresaEdit.DescPuesto = ((DataGridView)sender).Rows[e.RowIndex].Cells["DescPuesto"].Value.ToString();
                empresaEdit.IdPuesto = ((DataGridView)sender).Rows[e.RowIndex].Cells["IdPuesto"].Value.ToString();

                empresaEdit.Calle = ((DataGridView)sender).Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                empresaEdit.Colonia = ((DataGridView)sender).Rows[e.RowIndex].Cells["Colonia"].Value.ToString();
                empresaEdit.CP = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["CP"].Value.ToString());
                empresaEdit.Estado = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Estado"].Value.ToString());
                empresaEdit.Ciudad = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Ciudad"].Value.ToString());
                empresaEdit.DescEstado = ((DataGridView)sender).Rows[e.RowIndex].Cells["Estado "].Value.ToString();
                empresaEdit.DescCiudad = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ciudad "].Value.ToString();
                empresaEdit.Estatus = (((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO") ? true : false;
                empresaEdit.IdEmpresa = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdEmpresa"].Value.ToString());
                btnEditar.Enabled = true;

                List<MailsBE> mails = new List<MailsBE>();
                mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsEmpresa(empresaEdit.IdEmpresa);

                List<TelefonosBE> tels = new List<TelefonosBE>();
                tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosEmpresa(empresaEdit.IdEmpresa);

                empresaEdit.ListaMails = mails;
                empresaEdit.ListaTelefonos = tels;

                if (e.ColumnIndex == 14)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaMails = mails;
                    frm.listaTelefonos = new List<TelefonosBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Mails";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 15)
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
                        for (int i = 0; i < gvMedicos.Rows.Count; i++)
                        {
                            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                            PdfPCell celdaTitle = new PdfPCell();
                            //celdaTitle.BackgroundColor = new BaseColor(61, 216, 255);
                            celdaTitle.BorderWidth = 0;
                            celdaTitle.Colspan = 2;
                            celdaTitle.Phrase = new Phrase(gvMedicos.Rows[i].Cells["Nombre"].Value.ToString(), times);


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

                            string textoDirs = "";
                            PdfPCell celdainfo = new PdfPCell();
                            celdainfo.Colspan = 2;
                            celdainfo.BackgroundColor = new BaseColor(61, 216, 255);

                            //llena la informacion necesaria para mostrar los datos de cada registro
                            textoDirs = "RFC: " + gvMedicos.Rows[i].Cells["RFC"].Value.ToString() + Environment.NewLine + Environment.NewLine +
                                   "Dirección: " + gvMedicos.Rows[i].Cells["Calle"].Value.ToString() + ", " + gvMedicos.Rows[i].Cells["Colonia"].Value.ToString() + ", "
                                   + gvMedicos.Rows[i].Cells["CP"].Value.ToString() + " " + gvMedicos.Rows[i].Cells["Ciudad "].Value.ToString() + ", " +
                                      gvMedicos.Rows[i].Cells["Estado "].Value.ToString();


                            celdainfo.Phrase = new Phrase(textoDirs);
                            t.AddCell(celdainfo);

                            //espacio
                            t.AddCell(espacio);


                            //mails
                            List<MailsBE> mails = new List<MailsBE>();
                            mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(int.Parse(gvMedicos.Rows[i].Cells["IdEmpresa"].Value.ToString()));


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
                            tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(int.Parse(gvMedicos.Rows[i].Cells["IdEmpresa"].Value.ToString()));


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
