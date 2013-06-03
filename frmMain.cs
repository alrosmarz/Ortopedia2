using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ortopedia.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void catalogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos frmCatalogos = new frmCatalogos();
            frmCatalogos.MdiParent = this;
            frmCatalogos.WindowState = FormWindowState.Maximized;
            frmCatalogos.Show();
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogoMedicos frmCatalogoMedicos = new frmCatalogoMedicos();
            frmCatalogoMedicos.MdiParent = this;
            frmCatalogoMedicos.WindowState = FormWindowState.Maximized;
            frmCatalogoMedicos.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPacientes frmPacientes = new frmPacientes();
            frmPacientes.MdiParent = this;
            frmPacientes.WindowState = FormWindowState.Maximized;
            frmPacientes.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores();
            frmProveedores.MdiParent = this;
            frmProveedores.WindowState = FormWindowState.Maximized;
            frmProveedores.Show();
        }

        private void acreedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcreedores frmAcreedores = new frmAcreedores();
            frmAcreedores.MdiParent = this;
            frmAcreedores.WindowState = FormWindowState.Maximized;
            frmAcreedores.Show();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresas frmEmpresas = new frmEmpresas();
            frmEmpresas.MdiParent = this;
            frmEmpresas.WindowState = FormWindowState.Maximized;
            frmEmpresas.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteFiscal frmClienteFiscal = new frmClienteFiscal();
            frmClienteFiscal.MdiParent = this;
            frmClienteFiscal.WindowState = FormWindowState.Maximized;
            frmClienteFiscal.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acerdaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcercaDe = new frmAcercaDe();
            frmAcercaDe.MdiParent = this;
            frmAcercaDe.Show();
        }

        private void foliosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos frmCatalogos = new frmCatalogos();
            frmCatalogos.MdiParent = this;
            frmCatalogos.Show();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //Image newImage = Properties.Resources.pie_pagina;
            //System.Drawing.Rectangle drect = new Rectangle(1, 1, this.ClientSize.Width, this.ClientSize.Height);
            //e.Graphics.DrawImage(newImage, drect);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.White;

            MdiClient ctlMDI;
            //' Loop through all of the form's controls looking
            //' for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                    //ctlMDI.BackColor = System.Drawing.Color.Black;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void catálogoCalzadoOrtopedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalzadoOrtopedico frm = new frmCalzadoOrtopedico();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();

        }

        private void catálogoOrtopediaBlandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrtopediaBlanda frm = new frmOrtopediaBlanda();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void inventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario frm = new frmInventario();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void entradaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoEntradas frm = new frmListadoEntradas();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
