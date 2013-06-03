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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Ortopedia.UI
{
    public partial class frmPacientes : Form
    {
        public bool Editando { get; set; }
        public int IdPaciente { get; set; }
        public PacientesBE pacienteEdit { get; set; }

        public frmPacientes()
        {
            InitializeComponent();
            gradiente1.img = Properties.Resources.pacientes;
            gradiente1.Imagen = "Paciente";
         
        }

        void LlenaInformacionGrid()
        {
            List<PacientesBE> lista = new List<PacientesBE>();
            DataTable dt = CreaDataTable();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;

            lista = new OrtopediaService.OrtopediaServiceClient().ObtieneListaPacientes(text1.Text, text2.Text, text3.Text, text4.Text);

            if (lista.Count > 0)
                btnImprimir.Enabled = true;
            else
                btnImprimir.Enabled = false;

            foreach (PacientesBE m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdPaciente"] = m.IdPaciente;
                dr["Nombre"] = m.Nombre;
                dr["Ap. Paterno"] = m.ApPaterno;
                dr["Ap. Materno"] = m.ApMaterno;
                dr["CURP"] = m.CURP;
                dr["Fecha Nacimiento"] = m.FechaNacimiento;
                dr["Edad"] = m.Edad;
                dr["Estatus"] = (m.Estatus) ? "ACTIVO" : "INACTIVO";
                dr["VerDirecciones"] = new Bitmap(Resources.dirs, new Size(18, 18));
                dr["VerMails"] = new Bitmap(Resources.mail, new Size(18, 18));
                dr["VerTelefonos"] = new Bitmap(Resources.phone, new Size(18, 18));
                dt.Rows.Add(dr);
            }

            gvPacientes.DataSource = dt;
            gvPacientes.Columns["IDPaciente"].Visible = false;
            gvPacientes.Columns["Estatus"].Visible = false;
            gvPacientes.Columns["VerDirecciones"].HeaderText = "";
            gvPacientes.Columns["VerMails"].HeaderText = "";
            gvPacientes.Columns["VerTelefonos"].HeaderText = "";
            btnEditar.Enabled = false;
        }

        DataTable CreaDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdPaciente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Ap. Paterno");
            dt.Columns.Add("Ap. Materno");
            dt.Columns.Add("CURP");
            dt.Columns.Add("Fecha Nacimiento");
            dt.Columns.Add("Edad");
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

        private void btnQuitarDireccion_Click(object sender, EventArgs e)
        {
            lbDirecciones.Items.Remove(lbDirecciones.SelectedItems[0]);
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
            txtFecNacimiento.Value = DateTime.Now;
            txtCurp.Text = "";
            txtEdad.Text = "";
            chkActivo.Checked = true;

            Editando = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OcultarDetalle();

            cargarCatalogosDetalle();

            gbDetalle.Visible = true;
            txtNombre.Text = pacienteEdit.Nombre;
            txtApPaterno.Text = pacienteEdit.ApPaterno;
            txtApMaterno.Text = pacienteEdit.ApMaterno;
            txtEdad.Text = pacienteEdit.Edad.ToString();
            txtCurp.Text = pacienteEdit.CURP;
            
            txtFecNacimiento.Value = DateTime.Parse(pacienteEdit.FechaNacimiento.ToShortDateString());

            chkActivo.Checked = pacienteEdit.Estatus;

            IdPaciente = pacienteEdit.IdPaciente;

            lbMails.Items.Clear();
            lbTelefonos.Items.Clear();
            lbDirecciones.Items.Clear();

            foreach (MailsBE m in pacienteEdit.ListaMails)
            {
                ComboItem c = new ComboItem();
                c.Text = m.DescTipoMail + " " + m.Mail;
                c.Value = m.Mail;
                c.Tag = m.TipoMail.ToString();
                lbMails.Items.Add(c);

            }

            foreach (TelefonosBE t in pacienteEdit.ListaTelefonos)
            {
                ComboItem c = new ComboItem();
                c.Text = t.DescTelefono + " " + t.Telefono;
                c.Value = t.Telefono;
                c.Tag = t.TipoTelefono.ToString();
                lbTelefonos.Items.Add(c);
            }

            foreach (DireccionesBE d in pacienteEdit.ListaDirecciones)
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
                string.IsNullOrEmpty(txtApMaterno.Text) ||
                string.IsNullOrEmpty(txtApPaterno.Text) ||
                string.IsNullOrEmpty(txtCurp.Text) ||
                 lbDirecciones.Items.Count == 0 ||
                lbTelefonos.Items.Count == 0)
            {
                MessageBox.Show("Faltan datos por capturar.", "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                string validacion = "";
                PacientesBE paciente = new PacientesBE();
                paciente.Nombre = txtNombre.Text;
                paciente.ApPaterno = txtApPaterno.Text;
                paciente.ApMaterno = txtApMaterno.Text;
                paciente.FechaNacimiento = DateTime.Parse(txtFecNacimiento.Text);
                validacion = new OrtopediaService.OrtopediaServiceClient().ValidaExistenciaPaciente(paciente);
                if (Editando)
                    validacion = "0";

                if (validacion == "1")
                {
                    MessageBox.Show("Este paciente ya está registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    PacientesBE m = new PacientesBE();
                    m.Nombre = txtNombre.Text;
                    m.ApPaterno = txtApPaterno.Text;
                    m.ApMaterno = txtApMaterno.Text;
                    m.Edad = int.Parse(txtEdad.Text);
                    m.FechaNacimiento = DateTime.Parse(txtFecNacimiento.Value.ToShortDateString());
                    m.CURP = txtCurp.Text;

                    //m.Calle = txtCalle.Text;
                    //m.Colonia = txtColonia.Text;
                    //m.CP = int.Parse(txtCp.Text);
                    //m.Ciudad = int.Parse(((ComboItem)ddlCiudades.SelectedItem).Value);
                    //m.Estado = int.Parse(((ComboItem)ddlEstados.SelectedItem).Value);
                    m.Estatus = chkActivo.Checked;
                    m.Editando = Editando;
                    m.IdPaciente = IdPaciente;
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
                    bool respuesta = new OrtopediaService.OrtopediaServiceClient().InsertaPaciente(m);

                    try
                    {
                        if (respuesta)
                        {
                            if (!Editando)
                                MessageBox.Show("Se registró el paciente con éxito.", "Mensaje", MessageBoxButtons.OK);
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
            ddlCiudades.Text = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
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

        private void gvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pacienteEdit = new PacientesBE();
            if (e.RowIndex >= 0)
            {
                pacienteEdit.Nombre = ((DataGridView)sender).Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                pacienteEdit.ApPaterno = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ap. Paterno"].Value.ToString();
                pacienteEdit.ApMaterno = ((DataGridView)sender).Rows[e.RowIndex].Cells["Ap. Materno"].Value.ToString();
                pacienteEdit.Edad = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Edad"].Value.ToString());

                pacienteEdit.CURP = ((DataGridView)sender).Rows[e.RowIndex].Cells["CURP"].Value.ToString();
                pacienteEdit.FechaNacimiento = DateTime.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["Fecha Nacimiento"].Value.ToString());
                pacienteEdit.Estatus = (((DataGridView)sender).Rows[e.RowIndex].Cells["Estatus"].Value.ToString() == "ACTIVO") ? true : false;
                pacienteEdit.IdPaciente = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["IdPaciente"].Value.ToString());
                btnEditar.Enabled = true;

                List<MailsBE> mails = new List<MailsBE>();
                mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsPaciente(pacienteEdit.IdPaciente);

                List<TelefonosBE> tels = new List<TelefonosBE>();
                tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosPaciente(pacienteEdit.IdPaciente);

                List<DireccionesBE> dirs = new List<DireccionesBE>();
                dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesPaciente(pacienteEdit.IdPaciente);
                
                pacienteEdit.ListaDirecciones = dirs;
                pacienteEdit.ListaMails = mails;
                pacienteEdit.ListaTelefonos = tels;

                if (e.ColumnIndex == 8)
                {
                    frmDirecciones frm = new frmDirecciones();
                    frm.listaDirecciones = dirs;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Direcciones";
                    frm.ShowDialog();
                }

                if (e.ColumnIndex == 9)
                {
                    frmTelefonoMail frm = new frmTelefonoMail();
                    frm.listaMails = mails;
                    frm.listaTelefonos = new List<TelefonosBE>();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Mails";
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 10)
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

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCalle.Text) &&
                !string.IsNullOrEmpty(txtColonia.Text) &&
                !string.IsNullOrEmpty(txtCp.Text) && ddlEstados.SelectedIndex > 0 && ddlCiudades.SelectedIndex > 0 )
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

        private void txtFecNacimiento_ValueChanged(object sender, EventArgs e)
        {
            txtEdad.Text = (DateTime.Now.Year - DateTime.Parse(txtFecNacimiento.Text).Year).ToString();
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

        private void text4_TextChanged(object sender, EventArgs e)
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
                            celdaTitle.Phrase = new Phrase(gvPacientes.Rows[i].Cells["Nombre"].Value.ToString() + " " + gvPacientes.Rows[i].Cells["Ap. Paterno"].Value.ToString() + " " +
                                                gvPacientes.Rows[i].Cells["Ap. Materno"].Value.ToString(), times);


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
                            textoInfo = "CURP: " + gvPacientes.Rows[i].Cells["CURP"].Value.ToString() + Environment.NewLine + Environment.NewLine +
                                   "Fecha de Nacimiento: " + gvPacientes.Rows[i].Cells["Fecha Nacimiento"].Value.ToString().Substring(0,10) + " Edad: " + gvPacientes.Rows[i].Cells["Edad"].Value.ToString();


                            celdainfo.Phrase = new Phrase(textoInfo);
                            t.AddCell(celdainfo);


                            List<DireccionesBE> dirs = new List<DireccionesBE>();
                            dirs = new OrtopediaService.OrtopediaServiceClient().ObtieneDireccionesAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdPaciente"].Value.ToString()));

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
                            mails = new OrtopediaService.OrtopediaServiceClient().ObtieneMailsAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdPaciente"].Value.ToString()));


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
                            tels = new OrtopediaService.OrtopediaServiceClient().ObtieneTelefonosAcreedor(int.Parse(gvPacientes.Rows[i].Cells["IdPaciente"].Value.ToString()));


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

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
