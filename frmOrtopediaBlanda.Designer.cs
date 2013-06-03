namespace Ortopedia.UI
{
    partial class frmOrtopediaBlanda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrtopediaBlanda));
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.gvMedicos = new System.Windows.Forms.DataGridView();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.btnQuitarCodigo = new System.Windows.Forms.Button();
            this.btnAgregarFoto = new System.Windows.Forms.Button();
            this.btnAgregarCodigo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFotografia = new System.Windows.Forms.Button();
            this.ddlDeptos = new System.Windows.Forms.ComboBox();
            this.ddlEstantes = new System.Windows.Forms.ComboBox();
            this.ddlProductos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlProveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlTamaños = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.gradiente1 = new Ortopedia.UI.Gradiente();
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbFotos = new System.Windows.Forms.ListBox();
            this.lbCodigos = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductoBusqueda = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbInformacion.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).BeginInit();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.comboBox1);
            this.gbInformacion.Controls.Add(this.label9);
            this.gbInformacion.Controls.Add(this.textBox2);
            this.gbInformacion.Controls.Add(this.label8);
            this.gbInformacion.Controls.Add(this.textBox1);
            this.gbInformacion.Controls.Add(this.label5);
            this.gbInformacion.Controls.Add(this.txtProductoBusqueda);
            this.gbInformacion.Controls.Add(this.label14);
            this.gbInformacion.Controls.Add(this.toolStrip1);
            this.gbInformacion.Controls.Add(this.gvMedicos);
            this.gbInformacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInformacion.Location = new System.Drawing.Point(0, 42);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(947, 228);
            this.gbInformacion.TabIndex = 14;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Listado";
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
            this.toolStrip1.Size = new System.Drawing.Size(941, 25);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMedicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMedicos.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvMedicos.Location = new System.Drawing.Point(6, 73);
            this.gvMedicos.Name = "gvMedicos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMedicos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvMedicos.ShowEditingIcon = false;
            this.gvMedicos.Size = new System.Drawing.Size(935, 149);
            this.gvMedicos.TabIndex = 4;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.label11);
            this.gbDetalle.Controls.Add(this.label10);
            this.gbDetalle.Controls.Add(this.lbFotos);
            this.gbDetalle.Controls.Add(this.lbCodigos);
            this.gbDetalle.Controls.Add(this.btnQuitarFoto);
            this.gbDetalle.Controls.Add(this.btnQuitarCodigo);
            this.gbDetalle.Controls.Add(this.btnAgregarFoto);
            this.gbDetalle.Controls.Add(this.btnAgregarCodigo);
            this.gbDetalle.Controls.Add(this.pictureBox1);
            this.gbDetalle.Controls.Add(this.btnSeleccionarFotografia);
            this.gbDetalle.Controls.Add(this.ddlDeptos);
            this.gbDetalle.Controls.Add(this.ddlEstantes);
            this.gbDetalle.Controls.Add(this.ddlProductos);
            this.gbDetalle.Controls.Add(this.label7);
            this.gbDetalle.Controls.Add(this.label6);
            this.gbDetalle.Controls.Add(this.ddlProveedor);
            this.gbDetalle.Controls.Add(this.label4);
            this.gbDetalle.Controls.Add(this.ddlTamaños);
            this.gbDetalle.Controls.Add(this.label3);
            this.gbDetalle.Controls.Add(this.txtCodigo);
            this.gbDetalle.Controls.Add(this.lbl3);
            this.gbDetalle.Controls.Add(this.txtDetalle);
            this.gbDetalle.Controls.Add(this.chkActivo);
            this.gbDetalle.Controls.Add(this.label2);
            this.gbDetalle.Controls.Add(this.label1);
            this.gbDetalle.Controls.Add(this.toolStrip2);
            this.gbDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbDetalle.Location = new System.Drawing.Point(0, 270);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(947, 296);
            this.gbDetalle.TabIndex = 15;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Visible = false;
            // 
            // btnQuitarFoto
            // 
            this.btnQuitarFoto.Location = new System.Drawing.Point(866, 148);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(60, 23);
            this.btnQuitarFoto.TabIndex = 75;
            this.btnQuitarFoto.Text = "Quitar";
            this.btnQuitarFoto.UseVisualStyleBackColor = true;
            // 
            // btnQuitarCodigo
            // 
            this.btnQuitarCodigo.Location = new System.Drawing.Point(866, 68);
            this.btnQuitarCodigo.Name = "btnQuitarCodigo";
            this.btnQuitarCodigo.Size = new System.Drawing.Size(60, 23);
            this.btnQuitarCodigo.TabIndex = 74;
            this.btnQuitarCodigo.Text = "Quitar";
            this.btnQuitarCodigo.UseVisualStyleBackColor = true;
            // 
            // btnAgregarFoto
            // 
            this.btnAgregarFoto.Location = new System.Drawing.Point(628, 133);
            this.btnAgregarFoto.Name = "btnAgregarFoto";
            this.btnAgregarFoto.Size = new System.Drawing.Size(41, 23);
            this.btnAgregarFoto.TabIndex = 73;
            this.btnAgregarFoto.Text = ">>>";
            this.btnAgregarFoto.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCodigo
            // 
            this.btnAgregarCodigo.Location = new System.Drawing.Point(628, 49);
            this.btnAgregarCodigo.Name = "btnAgregarCodigo";
            this.btnAgregarCodigo.Size = new System.Drawing.Size(41, 23);
            this.btnAgregarCodigo.TabIndex = 72;
            this.btnAgregarCodigo.Text = ">>>";
            this.btnAgregarCodigo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(520, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 73);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // btnSeleccionarFotografia
            // 
            this.btnSeleccionarFotografia.Location = new System.Drawing.Point(375, 128);
            this.btnSeleccionarFotografia.Name = "btnSeleccionarFotografia";
            this.btnSeleccionarFotografia.Size = new System.Drawing.Size(139, 76);
            this.btnSeleccionarFotografia.TabIndex = 45;
            this.btnSeleccionarFotografia.Text = "Seleccionar Fotografía";
            this.btnSeleccionarFotografia.UseVisualStyleBackColor = true;
            this.btnSeleccionarFotografia.Click += new System.EventHandler(this.btnSeleccionarFotografia_Click);
            // 
            // ddlDeptos
            // 
            this.ddlDeptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptos.FormattingEnabled = true;
            this.ddlDeptos.Location = new System.Drawing.Point(224, 185);
            this.ddlDeptos.Name = "ddlDeptos";
            this.ddlDeptos.Size = new System.Drawing.Size(77, 21);
            this.ddlDeptos.TabIndex = 44;
            // 
            // ddlEstantes
            // 
            this.ddlEstantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEstantes.FormattingEnabled = true;
            this.ddlEstantes.Location = new System.Drawing.Point(96, 185);
            this.ddlEstantes.Name = "ddlEstantes";
            this.ddlEstantes.Size = new System.Drawing.Size(77, 21);
            this.ddlEstantes.TabIndex = 43;
            // 
            // ddlProductos
            // 
            this.ddlProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProductos.FormattingEnabled = true;
            this.ddlProductos.Location = new System.Drawing.Point(96, 75);
            this.ddlProductos.Name = "ddlProductos";
            this.ddlProductos.Size = new System.Drawing.Size(523, 21);
            this.ddlProductos.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Depto.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Estante";
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProveedor.FormattingEnabled = true;
            this.ddlProveedor.Location = new System.Drawing.Point(96, 155);
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Size = new System.Drawing.Size(273, 21);
            this.ddlProveedor.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Proveedor";
            // 
            // ddlTamaños
            // 
            this.ddlTamaños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTamaños.FormattingEnabled = true;
            this.ddlTamaños.Location = new System.Drawing.Point(96, 128);
            this.ddlTamaños.Name = "ddlTamaños";
            this.ddlTamaños.Size = new System.Drawing.Size(273, 21);
            this.ddlTamaños.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tamaño";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(96, 49);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(523, 20);
            this.txtCodigo.TabIndex = 31;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(50, 52);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(40, 13);
            this.lbl3.TabIndex = 30;
            this.lbl3.Text = "Código";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(96, 102);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(523, 20);
            this.txtDetalle.TabIndex = 29;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(313, 187);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 28;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Detalle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripción";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnCancelar});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(941, 25);
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
            this.gradiente1.Caption = "ORTOPEDIA BLANDA";
            this.gradiente1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradiente1.Imagen = null;
            this.gradiente1.img = null;
            this.gradiente1.Location = new System.Drawing.Point(0, 0);
            this.gradiente1.Name = "gradiente1";
            this.gradiente1.PageEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(119)))), ((int)(((byte)(157)))));
            this.gradiente1.PageStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(169)))), ((int)(((byte)(215)))));
            this.gradiente1.Size = new System.Drawing.Size(947, 42);
            this.gradiente1.TabIndex = 3;
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.FileName = "openFileDialog1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(675, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Fotografías";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(675, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "Códigos de barras";
            // 
            // lbFotos
            // 
            this.lbFotos.FormattingEnabled = true;
            this.lbFotos.Location = new System.Drawing.Point(678, 151);
            this.lbFotos.Name = "lbFotos";
            this.lbFotos.Size = new System.Drawing.Size(185, 43);
            this.lbFotos.TabIndex = 77;
            // 
            // lbCodigos
            // 
            this.lbCodigos.FormattingEnabled = true;
            this.lbCodigos.Location = new System.Drawing.Point(678, 70);
            this.lbCodigos.Name = "lbCodigos";
            this.lbCodigos.Size = new System.Drawing.Size(185, 43);
            this.lbCodigos.TabIndex = 76;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(726, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 107;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(664, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Proveedor";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(606, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 112;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(556, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "Número";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(371, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 110;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 109;
            this.label5.Text = "Descripción";
            // 
            // txtProductoBusqueda
            // 
            this.txtProductoBusqueda.Location = new System.Drawing.Point(114, 46);
            this.txtProductoBusqueda.Name = "txtProductoBusqueda";
            this.txtProductoBusqueda.Size = new System.Drawing.Size(178, 20);
            this.txtProductoBusqueda.TabIndex = 108;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 105;
            this.label14.Text = "Código de Barras";
            // 
            // frmOrtopediaBlanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 566);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.gradiente1);
            this.Name = "frmOrtopediaBlanda";
            this.Text = "Ortopedia Blanda";
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicos)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gradiente gradiente1;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.DataGridView gvMedicos;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.ComboBox ddlProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlTamaños;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlProductos;
        private System.Windows.Forms.ComboBox ddlDeptos;
        private System.Windows.Forms.ComboBox ddlEstantes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSeleccionarFotografia;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Button btnQuitarCodigo;
        private System.Windows.Forms.Button btnAgregarFoto;
        private System.Windows.Forms.Button btnAgregarCodigo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbFotos;
        private System.Windows.Forms.ListBox lbCodigos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductoBusqueda;
        private System.Windows.Forms.Label label14;
    }
}