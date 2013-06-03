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
using System.Reflection;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Ortopedia.UI
{
    public partial class frmCatalogoMedicos : Form
    {

        public bool Editando { get; set; }
        public int IdMedico { get; set; }
        public MedicosBE medicoEdit { get; set; }

        public frmCatalogoMedicos()
        {
            InitializeComponent();
            gradiente1.img = Properties.Resources.doctor;
            gradiente1.Imagen = "Doctor";
            List<CatalogosBE> catalogo = new List<CatalogosBE>();
            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Especialidad).ToString(), "", "", "");
            //Funciones.LlenarDropDownCatalogo(ddlEspecialidad, true, catalogo);
            Funciones.LlenarDropDownCatalogo(comboBox1, true, catalogo);
        }

        void LlenaInformacionGrid()
        {
            List<MedicosBE> lista = new List<MedicosBE>();
            DataTable dt = CreaDataTable();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            lista = new OrtopediaService.OrtopediaServiceClient().ObtieneListaMedicos(text1.Text, text2.Text, text3.Text, int.Parse(((ComboItem)comboBox1.SelectedItem).Value));

            if (lista.Count > 0)
                btnImprimir.Enabled = true;
            else
                btnImprimir.Enabled = false;

            foreach (MedicosBE m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdMedico"] = m.IdMedico;
                dr["Nombre"] = m.Nombre;
                dr["Ap. Paterno"] = m.ApPaterno;
                dr["Ap. Materno"] = m.ApMaterno;
                dr["Especialidad"] = m.Especialidad;
                dr["Hospital"] = m.NombreHospital;
                dr["Horario"] = m.Horario;
                dr["Calle"] = m.Calle;
                dr["Colonia"] = m.Colonia;
                dr["CP"] = m.CP;
                dr["Ciudad"] = m.Ciudad;
                dr["Estado"] = m.Estado;
                dr["Estatus"] = (m.Estatus) ? "ACTIVO" : "INACTIVO";
                dr["Ciudad "] = m.DescCiudad;
                dr["Estado "] = m.DescEstado;
                dr[" Especialidad"] = m.DescEspecialidad;
                dr["VerMails"] = new Bitmap(Resources.mail, new Size(18, 18));
                dr["VerTelefonos"] = new Bitmap(Resources.phone, new Size(18, 18));
                dt.Rows.Add(dr);
            }
            
            gvMedicos.DataSource = dt;
            gvMedicos.Columns["IdMedico"].Visible = false;
            gvMedicos.Columns["Ciudad"].Visible = false;
            gvMedicos.Columns["Estado"].Visible = false;
            gvMedicos.Columns["Estatus"].Visible = false;
            gvMedicos.Columns["Especialidad"].Visible = false;
            gvMedicos.Columns["VerMails"].HeaderText = "";
            gvMedicos.Columns["VerTelefonos"].HeaderText = "";
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdMedico");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Ap. Paterno");
            dt.Columns.Add("Ap. Materno");
            dt.Columns.Add("Especialidad");
            dt.Columns.Add("Hospital");
            dt.Columns.Add("Horario");
            dt.Columns.Add(" Especialidad");
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
            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            gbDetalle.Visible = true;

            cargarCatalogosDetalle();
            ddlCiudades.Items.Clear();
            chkActivo.Checked = true;
            
            Editando = false;

        }
  
        void cargarCatalogosDetalle()
        {
            ddlEspecialidad.Items.Clear();
            ddlEstados.Items.Clear();
            ddlCiudades.Items.Clear();
            ddlMails.Items.Clear();
            ddlTelefonos.Items.Clear();

            List<CatalogosBE> catalogo = new List<CatalogosBE>();
            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Especialidad).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEspecialidad, true, catalogo);
            Funciones.LlenarDropDownCatalogo(comboBox1, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Mails).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlMails, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Telefonos).ToString(), "", "", "");
            Funciones.LlenarDropDownCatalogo(ddlTelefonos, true, catalogo);

            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogo(((int)Funciones.Catalogos.Estados).ToString(), "E", "", "");
            Funciones.LlenarDropDownCatalogo(ddlEstados, true, catalogo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            cargarCatalogosDetalle();

            gbDetalle.Visible = true;
            txtNombre.Text = medicoEdit.Nombre;
            txtApPaterno.Text = medicoEdit.ApPaterno;
            txtApMaterno.Text = medicoEdit.ApMaterno;
            txtHorario.Text = medicoEdit.Horario;
            txtNombreHospital.Text = medicoEdit.NombreHospital;
            int posicion = 0;
            posicion = ddlEspecialidad.FindStringExact(medicoEdit.DescEspecialidad, -1);
            ddlEspecialidad.SelectedIndex = posicion;

            posicion = ddlEstados.FindStringExact(medicoEdit.DescEstado, -1);
            ddlEstados.SelectedIndex = posicion;

            posicion = ddlCiudades.FindStringExact(medicoEdit.DescCiudad, -1);
            ddlCiudades.SelectedIndex = posicion;
            
            txtCalle.Text = medicoEdit.Calle;
            txtColonia.Text = medicoEdit.Colonia;
            txtCp.Text = medicoEdit.CP.ToString();
            chkActivo.Checked = medicoEdit.Estatus;

            IdMedico = medicoEdit.IdMedico;

            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            foreach (MailsBE m in medicoEdit.ListaMails)
            {
                ComboItem c = new ComboItem();
                c.Text = m.DescTipoMail + " " + m.Mail;
                c.Value = m.Mail;
                c.Tag = m.TipoMail.ToString();
                lbMails.Items.Add(c);
              
            }

            foreach (TelefonosBE t in medicoEdit.ListaTelefonos)
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
                string.IsNullOrEmpty(txtApPaterno.Text) ||
                string.IsNullOrEmpty(txtApMaterno.Text) ||
                string.IsNullOrEmpty(txtHorario.Text) ||
              string.IsNullOrEmpty(txtCalle.Text) ||
              string.IsNullOrEmpty(txtNombreHospital.Text) ||
              string.IsNullOrEmpty(txtColonia.Text) ||
              string.IsNullOrEmpty(txtCp.Text) ||
              lbTelefonos.Items.Count == 0 ||
              ddlEstados.SelectedIndex == 0 ||
              ddlCiudades.SelectedIndex == 0 ||
              ddlEspecialidad.SelectedIndex == 0)
            {
                MessageBox.Show("Faltan datos por capturar.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                string validacion = "";
                MedicosBE medico = new MedicosBE();
                medico.Nombre = txtNombre.Text;
                medico.ApPaterno = txtApPaterno.Text;
                medico.ApMaterno = txtApMaterno.Text;
                validacion = new OrtopediaService.OrtopediaServiceClient().ValidaExistenciaMedico(medico);
                if (Editando)
                    validacion = "0";

                if (validacion == "1")
                {
                    MessageBox.Show("Este médico ya está registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MedicosBE m = new MedicosBE();
                    m.Nombre = txtNombre.Text;
                    m.ApPaterno = txtApPaterno.Text;
                    m.ApMaterno = txtApMaterno.Text;
                    m.Especialidad = int.Parse(((ComboItem)ddlEspecialidad.SelectedItem).Value);
                    m.Horario = txtHorario.Text;
                    m.NombreHospital = txtNombreHospital.Text;
                    m.Calle = txtCalle.Text;
                    m.Colonia = txtColonia.Text;
                    m.CP = int.Parse(txtCp.Text);
                    m.Ciudad = int.Parse(((ComboItem)ddlCiudades.SelectedItem).Value);
                    m.Estado = int.Parse(((ComboItem)ddlEstados.SelectedItem).Value);
                    m.Estatus = chkActivo.Checked;
                    m.Editando = Editando;
                    m.IdMedico = IdMedico;
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

                    bool respuesta = new OrtopediaService.OrtopediaServiceClient().InsertaMedico(m);

                    try
                    {
                        if (respuesta)
                        {
                            if (!Editando)
                                MessageBox.Show("Se registró el médico con éxito.", "Mensaje", MessageBoxButtons.OK);
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
            ddlEspecialidad.Items.Clear();
            ddlCiudades.Items.Clear();
            ddlCiudades.Text = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtHorario.Text = "";
            txtNombreHospital.Text = "";
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

        private void gvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            medicoEdit = new MedicosBE();
            if (e.RowIndex >= 0)
            {
                medicoEdit.Nombre = ((DataGridView)sender).Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                medicoEdit.ApPaterno = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ap. Paterno"].Value.ToString();
                medicoEdit.ApMaterno = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ap. Materno"].Value.ToString();
                medicoEdit.Horario = ((DataGridView)sender).Rows[e.RowIndex].Cells["Horario"].Value.ToString();
                medicoEdit.NombreHospital = ((DataGridView)sender).Rows[e.RowIndex].Cells["Hospital"].Value.ToString();
                medicoEdit.Calle = ((DataGridView)sender).Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                medicoEdit.Colonia = ((DataGridView)sender).Rows[e.RowIndex].Cells["Colonia"].Value.ToString();
                medicoEdit.CP = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["CP"].Value.ToString());
                medicoEdit.Especialidad = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Especialidad"].Value.ToString());
                medicoEdit.DescEspecialidad = ((DataGridView)sender).Rows[e.RowIndex].Cells[" Especialidad"].Value.ToString();
                medicoEdit.Estado = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Estado"].Value.ToString());
                medicoEdit.Ciudad = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Ciudad"].Value.ToString());
                medicoEdit.DescEstado = ((DataGridView)sender).Rows[e.RowIndex].Cells["Estado "].Value.ToString();
                medicoEdit.DescCiudad = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ciudad "].Value.ToString();
                medicoEdit.Estatus = (((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO") ? true : false;
                medicoEdit.IdMedico = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdMedico"].Value.ToString());
                btnEditar.Enabled = true;

                List<MailsBE> mails = new List<MailsBE>();
                mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsMedico(medicoEdit.IdMedico);

                List<TelefonosBE> tels = new List<TelefonosBE>();
                tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosMedico(medicoEdit.IdMedico);

                medicoEdit.ListaMails = mails;
                medicoEdit.ListaTelefonos = tels;
                
                if (e.ColumnIndex == 16)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaMails = mails;
                    frm.listaTelefonos = new List<TelefonosBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Mails";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 17)
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

        private void text1_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void text2_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void text3_TextChanged(object sender, EventArgs e)
        {
            LlenaInformacionGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                            celdaTitle.Phrase = new Phrase(gvMedicos.Rows[i].Cells["Nombre"].Value.ToString() + " " + gvMedicos.Rows[i].Cells["Ap. Paterno"].Value.ToString() + " " + 
                            gvMedicos.Rows[i].Cells["Ap. Materno"].Value.ToString(), times);


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
                            textoDirs = "Clínica: " + gvMedicos.Rows[i].Cells["Hospital"].Value.ToString() + " Especialidad: " + gvMedicos.Rows[i].Cells[" Especialidad"].Value.ToString() + Environment.NewLine + Environment.NewLine +
                                    "Horario: " + gvMedicos.Rows[i].Cells["Horario"].Value.ToString() + Environment.NewLine + Environment.NewLine + "Dirección: " + gvMedicos.Rows[i].Cells["Calle"].Value.ToString() + ", " +
                                     gvMedicos.Rows[i].Cells["Colonia"].Value.ToString() + ", " + gvMedicos.Rows[i].Cells["CP"].Value.ToString() + " " + gvMedicos.Rows[i].Cells["Ciudad "].Value.ToString() + ", " +
                                      gvMedicos.Rows[i].Cells["Estado "].Value.ToString();


                            celdainfo.Phrase = new Phrase(textoDirs);
                            t.AddCell(celdainfo);

                            
                            

                            //List<DireccionesBE> dirs = new List<DireccionesBE>();
                            //dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesAcreedor(int.Parse(gvMedicos.Rows[i].Cells["IdAcreedor"].Value.ToString()));

                            //espacio
                            t.AddCell(espacio);


                            //mails
                            List<MailsBE> mails = new List<MailsBE>();
                            mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(int.Parse(gvMedicos.Rows[i].Cells["IdMedico"].Value.ToString()));

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
                            tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(int.Parse(gvMedicos.Rows[i].Cells["IdMedico"].Value.ToString()));

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
    }
}

