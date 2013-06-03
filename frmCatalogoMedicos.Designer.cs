namespace Ortopedia.UI
{
    partial class frmCatalogoMedicos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogoMedicos));
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.text3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.gvMedicos = new System.Windows.Forms.DataGridView();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
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
            this.ddlEspecialidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreHospital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.gradiente1 = new Ortopedia.UI.Gradiente();
            this.gbInformacion.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).BeginInit();
            this.gbDetalle.SuspendLayout();
            this.gbTelefonos.SuspendLayout();
            this.gbMails.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.comboBox1);
            this.gbInformacion.Controls.Add(this.label15);
            this.gbInformacion.Controls.Add(this.text3);
            this.gbInformacion.Controls.Add(this.label12);
            this.gbInformacion.Controls.Add(this.text2);
            this.gbInformacion.Controls.Add(this.label13);
            this.gbInformacion.Controls.Add(this.text1);
            this.gbInformacion.Controls.Add(this.label14);
            this.gbInformacion.Controls.Add(this.toolStrip1);
            this.gbInformacion.Controls.Add(this.gvMedicos);
            this.gbInformacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInformacion.Location = new System.Drawing.Point(0, 42);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(937, 247);
            this.gbInformacion.TabIndex = 6;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Listado";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(671, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 103;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(598, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Especialidad";
            // 
            // text3
            // 
            this.text3.Location = new System.Drawing.Point(466, 46);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(121, 20);
            this.text3.TabIndex = 102;
            this.text3.TextChanged += new System.EventHandler(this.text3_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(394, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Ap. Materno";
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(267, 46);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(121, 20);
            this.text2.TabIndex = 101;
            this.text2.TextChanged += new System.EventHandler(this.text2_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(198, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Ap. Paterno";
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(71, 46);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(121, 20);
            this.text1.TabIndex = 100;
            this.text1.TextChanged += new System.EventHandler(this.text1_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Nombre";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMedicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMedicos.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvMedicos.Location = new System.Drawing.Point(6, 72);
            this.gvMedicos.Name = "gvMedicos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMedicos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvMedicos.ShowEditingIcon = false;
            this.gvMedicos.Size = new System.Drawing.Size(925, 169);
            this.gvMedicos.TabIndex = 4;
            this.gvMedicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMedicos_CellClick);
            // 
            // gbDetalle
            // 
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
            this.gbDetalle.Controls.Add(this.ddlEspecialidad);
            this.gbDetalle.Controls.Add(this.label4);
            this.gbDetalle.Controls.Add(this.txtNombreHospital);
            this.gbDetalle.Controls.Add(this.label5);
            this.gbDetalle.Controls.Add(this.txtHorario);
            this.gbDetalle.Controls.Add(this.label6);
            this.gbDetalle.Controls.Add(this.txtApMaterno);
            this.gbDetalle.Controls.Add(this.label3);
            this.gbDetalle.Controls.Add(this.txtApPaterno);
            this.gbDetalle.Controls.Add(this.label2);
            this.gbDetalle.Controls.Add(this.txtNombre);
            this.gbDetalle.Controls.Add(this.label1);
            this.gbDetalle.Controls.Add(this.toolStrip2);
            this.gbDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbDetalle.Location = new System.Drawing.Point(0, 289);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(937, 332);
            this.gbDetalle.TabIndex = 7;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Visible = false;
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
            this.gbTelefonos.Location = new System.Drawing.Point(428, 170);
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
            this.ddlTelefonos.TabIndex = 16;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(213, 51);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(175, 20);
            this.txtTelefono.TabIndex = 17;
            // 
            // btnQuitarTelefono
            // 
            this.btnQuitarTelefono.Location = new System.Drawing.Point(213, 116);
            this.btnQuitarTelefono.Name = "btnQuitarTelefono";
            this.btnQuitarTelefono.Size = new System.Drawing.Size(89, 23);
            this.btnQuitarTelefono.TabIndex = 19;
            this.btnQuitarTelefono.Text = "Quitar Teléfono";
            this.btnQuitarTelefono.UseVisualStyleBackColor = true;
            this.btnQuitarTelefono.Click += new System.EventHandler(this.btnQuitarTelefono_Click);
            // 
            // btnAgregarTelefono
            // 
            this.btnAgregarTelefono.Location = new System.Drawing.Point(213, 77);
            this.btnAgregarTelefono.Name = "btnAgregarTelefono";
            this.btnAgregarTelefono.Size = new System.Drawing.Size(89, 23);
            this.btnAgregarTelefono.TabIndex = 18;
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
            this.gbMails.Location = new System.Drawing.Point(25, 170);
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
            this.ddlMails.TabIndex = 12;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(215, 51);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(175, 20);
            this.txtMail.TabIndex = 13;
            // 
            // btnQuitaMail
            // 
            this.btnQuitaMail.Location = new System.Drawing.Point(216, 122);
            this.btnQuitaMail.Name = "btnQuitaMail";
            this.btnQuitaMail.Size = new System.Drawing.Size(75, 23);
            this.btnQuitaMail.TabIndex = 15;
            this.btnQuitaMail.Text = "Quitar Mail";
            this.btnQuitaMail.UseVisualStyleBackColor = true;
            this.btnQuitaMail.Click += new System.EventHandler(this.btnQuitaMail_Click);
            // 
            // btnAgregarMail
            // 
            this.btnAgregarMail.Location = new System.Drawing.Point(216, 77);
            this.btnAgregarMail.Name = "btnAgregarMail";
            this.btnAgregarMail.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMail.TabIndex = 14;
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
            this.chkActivo.Location = new System.Drawing.Point(564, 139);
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
            this.ddlEstados.Location = new System.Drawing.Point(73, 137);
            this.ddlEstados.Name = "ddlEstados";
            this.ddlEstados.Size = new System.Drawing.Size(200, 21);
            this.ddlEstados.TabIndex = 10;
            this.ddlEstados.SelectedIndexChanged += new System.EventHandler(this.ddlEstados_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Estado";
            // 
            // ddlCiudades
            // 
            this.ddlCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCiudades.FormattingEnabled = true;
            this.ddlCiudades.Location = new System.Drawing.Point(349, 137);
            this.ddlCiudades.Name = "ddlCiudades";
            this.ddlCiudades.Size = new System.Drawing.Size(200, 21);
            this.ddlCiudades.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ciudad";
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(627, 111);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(80, 20);
            this.txtCp.TabIndex = 9;
            this.txtCp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCp_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "C.P.";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(349, 111);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(200, 20);
            this.txtColonia.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Colonia";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(73, 111);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(200, 20);
            this.txtCalle.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Calle";
            // 
            // ddlEspecialidad
            // 
            this.ddlEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEspecialidad.FormattingEnabled = true;
            this.ddlEspecialidad.Location = new System.Drawing.Point(627, 85);
            this.ddlEspecialidad.Name = "ddlEspecialidad";
            this.ddlEspecialidad.Size = new System.Drawing.Size(200, 21);
            this.ddlEspecialidad.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Especialidad";
            // 
            // txtNombreHospital
            // 
            this.txtNombreHospital.Location = new System.Drawing.Point(349, 85);
            this.txtNombreHospital.Name = "txtNombreHospital";
            this.txtNombreHospital.Size = new System.Drawing.Size(200, 20);
            this.txtNombreHospital.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hospital";
            // 
            // txtHorario
            // 
            this.txtHorario.Location = new System.Drawing.Point(73, 85);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(200, 20);
            this.txtHorario.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Horario";
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Location = new System.Drawing.Point(627, 58);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(200, 20);
            this.txtApMaterno.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ap. Materno";
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Location = new System.Drawing.Point(349, 58);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(200, 20);
            this.txtApPaterno.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ap. Paterno";
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
            // gradiente1
            // 
            this.gradiente1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gradiente1.BackgroundImage")));
            this.gradiente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradiente1.Caption = "MÉDICOS";
            this.gradiente1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradiente1.Imagen = null;
            this.gradiente1.img = null;
            this.gradiente1.Location = new System.Drawing.Point(0, 0);
            this.gradiente1.Name = "gradiente1";
            this.gradiente1.PageEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(119)))), ((int)(((byte)(157)))));
            this.gradiente1.PageStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(169)))), ((int)(((byte)(215)))));
            this.gradiente1.Size = new System.Drawing.Size(937, 42);
            this.gradiente1.TabIndex = 2;
            // 
            // frmCatalogoMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 621);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.gradiente1);
            this.Name = "frmCatalogoMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Médicos";
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.gbTelefonos.ResumeLayout(false);
            this.gbTelefonos.PerformLayout();
            this.gbMails.ResumeLayout(false);
            this.gbMails.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gradiente gradiente1;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.DataGridView gvMedicos;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
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
        private System.Windows.Forms.ComboBox ddlEspecialidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreHospital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHorario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.GroupBox gbTelefonos;
        private System.Windows.Forms.GroupBox gbMails;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnQuitarTelefono;
        private System.Windows.Forms.Button btnAgregarTelefono;
        private System.Windows.Forms.ListBox lbTelefonos;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnQuitaMail;
        private System.Windows.Forms.Button btnAgregarMail;
        private System.Windows.Forms.ListBox lbMails;
        private System.Windows.Forms.ComboBox ddlTelefonos;
        private System.Windows.Forms.ComboBox ddlMails;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox text3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripButton btnBuscar;
    }
}