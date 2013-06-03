namespace Ortopedia.UI
{
    partial class frmEmpresas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresas));
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.ddlPuestos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbTelefonos = new System.Windows.Forms.GroupBox();
            this.ddlTelefonos = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnQuitarTelefono = new System.Windows.Forms.Button();
            this.btnAgregarTelefono = new System.Windows.Forms.Button();
            this.lbTelefonos = new System.Windows.Forms.ListBox();
            this.gbMails = new System.Windows.Forms.GroupBox();
            this.ddlMails = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnQuitaMail = new System.Windows.Forms.Button();
            this.btnAgregarMail = new System.Windows.Forms.Button();
            this.lbMails = new System.Windows.Forms.ListBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.ddlEstados = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlCiudades = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.gvMedicos = new System.Windows.Forms.DataGridView();
            this.gradiente1 = new Ortopedia.UI.Gradiente();
            this.gbDetalle.SuspendLayout();
            this.gbTelefonos.SuspendLayout();
            this.gbMails.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbInformacion.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.ddlPuestos);
            this.gbDetalle.Controls.Add(this.label5);
            this.gbDetalle.Controls.Add(this.txtContacto);
            this.gbDetalle.Controls.Add(this.label3);
            this.gbDetalle.Controls.Add(this.gbTelefonos);
            this.gbDetalle.Controls.Add(this.gbMails);
            this.gbDetalle.Controls.Add(this.chkActivo);
            this.gbDetalle.Controls.Add(this.ddlEstados);
            this.gbDetalle.Controls.Add(this.label11);
            this.gbDetalle.Controls.Add(this.ddlCiudades);
            this.gbDetalle.Controls.Add(this.label10);
            this.gbDetalle.Controls.Add(this.txtCp);
            this.gbDetalle.Controls.Add(this.label7);
            this.gbDetalle.Controls.Add(this.txtColonia);
            this.gbDetalle.Controls.Add(this.label8);
            this.gbDetalle.Controls.Add(this.txtCalle);
            this.gbDetalle.Controls.Add(this.label9);
            this.gbDetalle.Controls.Add(this.txtRFC);
            this.gbDetalle.Controls.Add(this.label2);
            this.gbDetalle.Controls.Add(this.txtNombre);
            this.gbDetalle.Controls.Add(this.label1);
            this.gbDetalle.Controls.Add(this.toolStrip2);
            this.gbDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbDetalle.Location = new System.Drawing.Point(0, 289);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(937, 305);
            this.gbDetalle.TabIndex = 10;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Visible = false;
            // 
            // ddlPuestos
            // 
            this.ddlPuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPuestos.FormattingEnabled = true;
            this.ddlPuestos.Location = new System.Drawing.Point(616, 84);
            this.ddlPuestos.Name = "ddlPuestos";
            this.ddlPuestos.Size = new System.Drawing.Size(187, 21);
            this.ddlPuestos.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Puesto";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(616, 58);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(187, 20);
            this.txtContacto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Contacto";
            // 
            // gbTelefonos
            // 
            this.gbTelefonos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTelefonos.Controls.Add(this.ddlTelefonos);
            this.gbTelefonos.Controls.Add(this.txtTelefono);
            this.gbTelefonos.Controls.Add(this.btnQuitarTelefono);
            this.gbTelefonos.Controls.Add(this.btnAgregarTelefono);
            this.gbTelefonos.Controls.Add(this.lbTelefonos);
            this.gbTelefonos.Location = new System.Drawing.Point(428, 138);
            this.gbTelefonos.Name = "gbTelefonos";
            this.gbTelefonos.Size = new System.Drawing.Size(399, 156);
            this.gbTelefonos.TabIndex = 30;
            this.gbTelefonos.TabStop = false;
            this.gbTelefonos.Text = "Teléfonos";
            // 
            // ddlTelefonos
            // 
            this.ddlTelefonos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTelefonos.FormattingEnabled = true;
            this.ddlTelefonos.Location = new System.Drawing.Point(212, 24);
            this.ddlTelefonos.Name = "ddlTelefonos";
            this.ddlTelefonos.Size = new System.Drawing.Size(174, 21);
            this.ddlTelefonos.TabIndex = 14;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(213, 51);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(175, 20);
            this.txtTelefono.TabIndex = 15;
            // 
            // btnQuitarTelefono
            // 
            this.btnQuitarTelefono.Location = new System.Drawing.Point(213, 116);
            this.btnQuitarTelefono.Name = "btnQuitarTelefono";
            this.btnQuitarTelefono.Size = new System.Drawing.Size(91, 23);
            this.btnQuitarTelefono.TabIndex = 17;
            this.btnQuitarTelefono.Text = "Quitar Teléfono";
            this.btnQuitarTelefono.UseVisualStyleBackColor = true;
            this.btnQuitarTelefono.Click += new System.EventHandler(this.btnQuitarTelefono_Click);
            // 
            // btnAgregarTelefono
            // 
            this.btnAgregarTelefono.Location = new System.Drawing.Point(213, 77);
            this.btnAgregarTelefono.Name = "btnAgregarTelefono";
            this.btnAgregarTelefono.Size = new System.Drawing.Size(91, 23);
            this.btnAgregarTelefono.TabIndex = 16;
            this.btnAgregarTelefono.Text = "Agregar";
            this.btnAgregarTelefono.UseVisualStyleBackColor = true;
            this.btnAgregarTelefono.Click += new System.EventHandler(this.btnAgregarTelefono_Click);
            // 
            // lbTelefonos
            // 
            this.lbTelefonos.FormattingEnabled = true;
            this.lbTelefonos.Location = new System.Drawing.Point(11, 18);
            this.lbTelefonos.Name = "lbTelefonos";
            this.lbTelefonos.Size = new System.Drawing.Size(195, 121);
            this.lbTelefonos.TabIndex = 4;
            // 
            // gbMails
            // 
            this.gbMails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMails.Controls.Add(this.ddlMails);
            this.gbMails.Controls.Add(this.txtMail);
            this.gbMails.Controls.Add(this.btnQuitaMail);
            this.gbMails.Controls.Add(this.btnAgregarMail);
            this.gbMails.Controls.Add(this.lbMails);
            this.gbMails.Location = new System.Drawing.Point(25, 138);
            this.gbMails.Name = "gbMails";
            this.gbMails.Size = new System.Drawing.Size(397, 156);
            this.gbMails.TabIndex = 29;
            this.gbMails.TabStop = false;
            this.gbMails.Text = "Mails";
            // 
            // ddlMails
            // 
            this.ddlMails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMails.FormattingEnabled = true;
            this.ddlMails.Location = new System.Drawing.Point(216, 24);
            this.ddlMails.Name = "ddlMails";
            this.ddlMails.Size = new System.Drawing.Size(174, 21);
            this.ddlMails.TabIndex = 10;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(215, 51);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(175, 20);
            this.txtMail.TabIndex = 11;
            // 
            // btnQuitaMail
            // 
            this.btnQuitaMail.Location = new System.Drawing.Point(216, 122);
            this.btnQuitaMail.Name = "btnQuitaMail";
            this.btnQuitaMail.Size = new System.Drawing.Size(75, 23);
            this.btnQuitaMail.TabIndex = 13;
            this.btnQuitaMail.Text = "Quitar Mail";
            this.btnQuitaMail.UseVisualStyleBackColor = true;
            this.btnQuitaMail.Click += new System.EventHandler(this.btnQuitaMail_Click);
            // 
            // btnAgregarMail
            // 
            this.btnAgregarMail.Location = new System.Drawing.Point(216, 77);
            this.btnAgregarMail.Name = "btnAgregarMail";
            this.btnAgregarMail.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMail.TabIndex = 12;
            this.btnAgregarMail.Text = "Agregar";
            this.btnAgregarMail.UseVisualStyleBackColor = true;
            this.btnAgregarMail.Click += new System.EventHandler(this.btnAgregarMail_Click);
            // 
            // lbMails
            // 
            this.lbMails.FormattingEnabled = true;
            this.lbMails.Location = new System.Drawing.Point(14, 24);
            this.lbMails.Name = "lbMails";
            this.lbMails.Size = new System.Drawing.Size(195, 121);
            this.lbMails.TabIndex = 0;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(747, 115);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 28;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // ddlEstados
            // 
            this.ddlEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEstados.FormattingEnabled = true;
            this.ddlEstados.Location = new System.Drawing.Point(73, 111);
            this.ddlEstados.Name = "ddlEstados";
            this.ddlEstados.Size = new System.Drawing.Size(200, 21);
            this.ddlEstados.TabIndex = 7;
            this.ddlEstados.SelectedIndexChanged += new System.EventHandler(this.ddlEstados_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Estado";
            // 
            // ddlCiudades
            // 
            this.ddlCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCiudades.FormattingEnabled = true;
            this.ddlCiudades.Location = new System.Drawing.Point(349, 111);
            this.ddlCiudades.Name = "ddlCiudades";
            this.ddlCiudades.Size = new System.Drawing.Size(200, 21);
            this.ddlCiudades.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ciudad";
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(616, 111);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(80, 20);
            this.txtCp.TabIndex = 9;
            this.txtCp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCp_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "C.P.";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(349, 85);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(200, 20);
            this.txtColonia.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Colonia";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(73, 85);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(200, 20);
            this.txtCalle.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Calle";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(349, 58);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(200, 20);
            this.txtRFC.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "RFC";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(73, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnCancelar});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(931, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Ortopedia.UI.Properties.Resources.guardar;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(69, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Ortopedia.UI.Properties.Resources.cancelar;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 22);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.label23);
            this.gbInformacion.Controls.Add(this.textBox2);
            this.gbInformacion.Controls.Add(this.label22);
            this.gbInformacion.Controls.Add(this.textBox1);
            this.gbInformacion.Controls.Add(this.toolStrip1);
            this.gbInformacion.Controls.Add(this.gvMedicos);
            this.gbInformacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInformacion.Location = new System.Drawing.Point(0, 42);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(937, 247);
            this.gbInformacion.TabIndex = 9;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Listado";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(437, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "RFC";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(471, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 101;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(349, 20);
            this.textBox1.TabIndex = 100;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscar,
            this.btnAgregar,
            this.btnEditar,
            this.btnImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(931, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Ortopedia.UI.Properties.Resources.buscar;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 22);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Image = global::Ortopedia.UI.Properties.Resources.agregar;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 22);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::Ortopedia.UI.Properties.Resources.editar;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = global::Ortopedia.UI.Properties.Resources.imprimir;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(73, 22);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gvMedicos
            // 
            this.gvMedicos.AllowUserToAddRows = false;
            this.gvMedicos.AllowUserToDeleteRows = false;
            this.gvMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMedicos.Location = new System.Drawing.Point(6, 76);
            this.gvMedicos.Name = "gvMedicos";
            this.gvMedicos.ShowEditingIcon = false;
            this.gvMedicos.Size = new System.Drawing.Size(925, 165);
            this.gvMedicos.TabIndex = 4;
            this.gvMedicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMedicos_CellClick);
            // 
            // gradiente1
            // 
            this.gradiente1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gradiente1.BackgroundImage")));
            this.gradiente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradiente1.Caption = "INSTITUCIONES PUBLICAS Y PRIVADAS";
            this.gradiente1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradiente1.Imagen = null;
            this.gradiente1.img = null;
            this.gradiente1.Location = new System.Drawing.Point(0, 0);
            this.gradiente1.Name = "gradiente1";
            this.gradiente1.PageEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(119)))), ((int)(((byte)(157)))));
            this.gradiente1.PageStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(169)))), ((int)(((byte)(215)))));
            this.gradiente1.Size = new System.Drawing.Size(937, 42);
            this.gradiente1.TabIndex = 8;
            // 
            // frmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 594);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.gradiente1);
            this.Controls.Add(this.gbDetalle);
            this.Name = "frmEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instituciones Públicas y Privadas";
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.gbTelefonos.ResumeLayout(false);
            this.gbTelefonos.PerformLayout();
            this.gbMails.ResumeLayout(false);
            this.gbMails.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.GroupBox gbTelefonos;
        private System.Windows.Forms.ComboBox ddlTelefonos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnQuitarTelefono;
        private System.Windows.Forms.Button btnAgregarTelefono;
        private System.Windows.Forms.ListBox lbTelefonos;
        private System.Windows.Forms.GroupBox gbMails;
        private System.Windows.Forms.ComboBox ddlMails;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnQuitaMail;
        private System.Windows.Forms.Button btnAgregarMail;
        private System.Windows.Forms.ListBox lbMails;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox ddlEstados;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlCiudades;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.DataGridView gvMedicos;
        private Gradiente gradiente1;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ComboBox ddlPuestos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label3;
    }
}