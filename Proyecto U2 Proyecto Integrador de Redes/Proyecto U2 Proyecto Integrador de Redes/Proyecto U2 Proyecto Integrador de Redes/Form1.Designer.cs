namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    partial class frmServ
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServ));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDHCP = new System.Windows.Forms.TabPage();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtsubred = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalRed = new System.Windows.Forms.Label();
            this.lblIpLibres = new System.Windows.Forms.Label();
            this.txtTotalIP = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.lblIpsUs = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gBDHCP = new System.Windows.Forms.GroupBox();
            this.txtBroadcast = new System.Windows.Forms.TextBox();
            this.txtMascaraCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBroadcast = new System.Windows.Forms.Label();
            this.lblConsumo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.CBInac = new System.Windows.Forms.CheckBox();
            this.CBAct = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCrearC = new System.Windows.Forms.GroupBox();
            this.cBoxTipo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listCliente = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.lblselecionado = new System.Windows.Forms.Label();
            this.btnEliminarDNs = new System.Windows.Forms.Button();
            this.btnAgregarDNS = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDnsPrimario = new System.Windows.Forms.TextBox();
            this.txtDnsSecundario = new System.Windows.Forms.TextBox();
            this.txtNombreDNS = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tVDNS = new System.Windows.Forms.TreeView();
            this.rtbDNS = new System.Windows.Forms.RichTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusacar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtbbitacora = new System.Windows.Forms.RichTextBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timerSimulacion = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabDHCP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBDHCP.SuspendLayout();
            this.gbCrearC.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDHCP);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-1, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1009, 710);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDHCP
            // 
            this.tabDHCP.Controls.Add(this.btnDetener);
            this.tabDHCP.Controls.Add(this.btnSimular);
            this.tabDHCP.Controls.Add(this.groupBox1);
            this.tabDHCP.Controls.Add(this.gBDHCP);
            this.tabDHCP.Controls.Add(this.gbCrearC);
            this.tabDHCP.Controls.Add(this.btnEliminar);
            this.tabDHCP.Controls.Add(this.btnAgregar);
            this.tabDHCP.Controls.Add(this.label1);
            this.tabDHCP.Controls.Add(this.listCliente);
            this.tabDHCP.Location = new System.Drawing.Point(4, 39);
            this.tabDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDHCP.Name = "tabDHCP";
            this.tabDHCP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDHCP.Size = new System.Drawing.Size(1001, 667);
            this.tabDHCP.TabIndex = 0;
            this.tabDHCP.Text = "DHCP";
            this.tabDHCP.UseVisualStyleBackColor = true;
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Location = new System.Drawing.Point(25, 553);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(146, 30);
            this.btnDetener.TabIndex = 8;
            this.btnDetener.Text = "Terminar Simulación";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Visible = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnSimular
            // 
            this.btnSimular.BackColor = System.Drawing.Color.LightGreen;
            this.btnSimular.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimular.Location = new System.Drawing.Point(25, 495);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(146, 36);
            this.btnSimular.TabIndex = 7;
            this.btnSimular.Text = "Iniciar Simulación";
            this.btnSimular.UseVisualStyleBackColor = false;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsubred);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblTotalRed);
            this.groupBox1.Controls.Add(this.lblIpLibres);
            this.groupBox1.Controls.Add(this.txtTotalIP);
            this.groupBox1.Controls.Add(this.txtRed);
            this.groupBox1.Controls.Add(this.lblIpsUs);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(244, 431);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(710, 191);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DHCP Pool";
            // 
            // txtsubred
            // 
            this.txtsubred.Location = new System.Drawing.Point(277, 77);
            this.txtsubred.Name = "txtsubred";
            this.txtsubred.Size = new System.Drawing.Size(233, 37);
            this.txtsubred.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 30);
            this.label10.TabIndex = 9;
            this.label10.Text = "Direccion de Subred:";
            // 
            // lblTotalRed
            // 
            this.lblTotalRed.AutoSize = true;
            this.lblTotalRed.Location = new System.Drawing.Point(122, 161);
            this.lblTotalRed.Name = "lblTotalRed";
            this.lblTotalRed.Size = new System.Drawing.Size(285, 30);
            this.lblTotalRed.TabIndex = 8;
            this.lblTotalRed.Text = "Tráfico Total Red: 0 Mbps";
            // 
            // lblIpLibres
            // 
            this.lblIpLibres.Location = new System.Drawing.Point(463, 100);
            this.lblIpLibres.Name = "lblIpLibres";
            this.lblIpLibres.Size = new System.Drawing.Size(220, 42);
            this.lblIpLibres.TabIndex = 0;
            // 
            // txtTotalIP
            // 
            this.txtTotalIP.Location = new System.Drawing.Point(407, 33);
            this.txtTotalIP.Name = "txtTotalIP";
            this.txtTotalIP.Size = new System.Drawing.Size(199, 37);
            this.txtTotalIP.TabIndex = 6;
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(66, 33);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(233, 37);
            this.txtRed.TabIndex = 7;
            // 
            // lblIpsUs
            // 
            this.lblIpsUs.AutoSize = true;
            this.lblIpsUs.Location = new System.Drawing.Point(29, 122);
            this.lblIpsUs.Name = "lblIpsUs";
            this.lblIpsUs.Size = new System.Drawing.Size(118, 30);
            this.lblIpsUs.TabIndex = 2;
            this.lblIpsUs.Text = "IP Usadas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "Total IP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "Red:";
            // 
            // gBDHCP
            // 
            this.gBDHCP.Controls.Add(this.txtBroadcast);
            this.gBDHCP.Controls.Add(this.txtMascaraCliente);
            this.gBDHCP.Controls.Add(this.label11);
            this.gBDHCP.Controls.Add(this.lblBroadcast);
            this.gBDHCP.Controls.Add(this.lblConsumo);
            this.gBDHCP.Controls.Add(this.label7);
            this.gBDHCP.Controls.Add(this.btnModificar);
            this.gBDHCP.Controls.Add(this.txtHostName);
            this.gBDHCP.Controls.Add(this.txtIP);
            this.gBDHCP.Controls.Add(this.txtMac);
            this.gBDHCP.Controls.Add(this.CBInac);
            this.gBDHCP.Controls.Add(this.CBAct);
            this.gBDHCP.Controls.Add(this.label6);
            this.gBDHCP.Controls.Add(this.label5);
            this.gBDHCP.Controls.Add(this.label4);
            this.gBDHCP.Location = new System.Drawing.Point(256, 16);
            this.gBDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBDHCP.Name = "gBDHCP";
            this.gBDHCP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBDHCP.Size = new System.Drawing.Size(689, 420);
            this.gBDHCP.TabIndex = 5;
            this.gBDHCP.TabStop = false;
            this.gBDHCP.Visible = false;
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.Location = new System.Drawing.Point(160, 214);
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.Size = new System.Drawing.Size(233, 37);
            this.txtBroadcast.TabIndex = 12;
            // 
            // txtMascaraCliente
            // 
            this.txtMascaraCliente.Location = new System.Drawing.Point(276, 170);
            this.txtMascaraCliente.Name = "txtMascaraCliente";
            this.txtMascaraCliente.Size = new System.Drawing.Size(233, 37);
            this.txtMascaraCliente.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(235, 30);
            this.label11.TabIndex = 11;
            this.label11.Text = "Direccion de Subred:";
            // 
            // lblBroadcast
            // 
            this.lblBroadcast.AutoSize = true;
            this.lblBroadcast.Location = new System.Drawing.Point(26, 214);
            this.lblBroadcast.Name = "lblBroadcast";
            this.lblBroadcast.Size = new System.Drawing.Size(121, 30);
            this.lblBroadcast.TabIndex = 11;
            this.lblBroadcast.Text = "Broadcast:";
            // 
            // lblConsumo
            // 
            this.lblConsumo.AutoSize = true;
            this.lblConsumo.Location = new System.Drawing.Point(211, 314);
            this.lblConsumo.Name = "lblConsumo";
            this.lblConsumo.Size = new System.Drawing.Size(280, 30);
            this.lblConsumo.TabIndex = 10;
            this.lblConsumo.Text = "Consumo Actual: 0 Mbps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 30);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ancho de banda";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(276, 358);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(180, 54);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(195, 129);
            this.txtHostName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(316, 37);
            this.txtHostName.TabIndex = 7;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(131, 87);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(289, 37);
            this.txtIP.TabIndex = 6;
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(131, 39);
            this.txtMac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(295, 37);
            this.txtMac.TabIndex = 5;
            // 
            // CBInac
            // 
            this.CBInac.AutoSize = true;
            this.CBInac.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBInac.Location = new System.Drawing.Point(510, 267);
            this.CBInac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBInac.Name = "CBInac";
            this.CBInac.Size = new System.Drawing.Size(167, 35);
            this.CBInac.TabIndex = 4;
            this.CBInac.Text = "Inactividad";
            this.CBInac.UseVisualStyleBackColor = true;
            this.CBInac.CheckedChanged += new System.EventHandler(this.CBInac_CheckedChanged);
            // 
            // CBAct
            // 
            this.CBAct.AutoSize = true;
            this.CBAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBAct.Location = new System.Drawing.Point(30, 267);
            this.CBAct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBAct.Name = "CBAct";
            this.CBAct.Size = new System.Drawing.Size(111, 35);
            this.CBAct.TabIndex = 3;
            this.CBAct.Text = "Activa";
            this.CBAct.UseVisualStyleBackColor = true;
            this.CBAct.CheckedChanged += new System.EventHandler(this.CBAct_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Host Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "MAC:";
            // 
            // gbCrearC
            // 
            this.gbCrearC.Controls.Add(this.cBoxTipo);
            this.gbCrearC.Controls.Add(this.btnGuardar);
            this.gbCrearC.Controls.Add(this.txtNombre);
            this.gbCrearC.Controls.Add(this.label3);
            this.gbCrearC.Controls.Add(this.label2);
            this.gbCrearC.Location = new System.Drawing.Point(362, 4);
            this.gbCrearC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCrearC.Name = "gbCrearC";
            this.gbCrearC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCrearC.Size = new System.Drawing.Size(303, 208);
            this.gbCrearC.TabIndex = 4;
            this.gbCrearC.TabStop = false;
            this.gbCrearC.Text = "Crear Cliente";
            this.gbCrearC.Visible = false;
            // 
            // cBoxTipo
            // 
            this.cBoxTipo.FormattingEnabled = true;
            this.cBoxTipo.Items.AddRange(new object[] {
            "PC",
            "Laptop",
            "Consola",
            "Tv",
            "Celular",
            "Telefono",
            "Impresora"});
            this.cBoxTipo.Location = new System.Drawing.Point(29, 132);
            this.cBoxTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxTipo.Name = "cBoxTipo";
            this.cBoxTipo.Size = new System.Drawing.Size(223, 38);
            this.cBoxTipo.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(171, 171);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 32);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(28, 60);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 37);
            this.txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(151, 423);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(43, 34);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(25, 423);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(43, 34);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes";
            // 
            // listCliente
            // 
            this.listCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCliente.FormattingEnabled = true;
            this.listCliente.ItemHeight = 30;
            this.listCliente.Location = new System.Drawing.Point(25, 39);
            this.listCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listCliente.Name = "listCliente";
            this.listCliente.Size = new System.Drawing.Size(179, 304);
            this.listCliente.TabIndex = 0;
            this.listCliente.SelectedIndexChanged += new System.EventHandler(this.listCliente_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDesconectar);
            this.tabPage2.Controls.Add(this.lblselecionado);
            this.tabPage2.Controls.Add(this.btnEliminarDNs);
            this.tabPage2.Controls.Add(this.btnAgregarDNS);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.rtbDNS);
            this.tabPage2.Controls.Add(this.btnBuscar);
            this.tabPage2.Controls.Add(this.txtBusacar);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.rtbbitacora);
            this.tabPage2.Controls.Add(this.dgvClientes);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1001, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DNS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDesconectar.BackgroundImage")));
            this.btnDesconectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesconectar.Location = new System.Drawing.Point(468, 255);
            this.btnDesconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(43, 31);
            this.btnDesconectar.TabIndex = 9;
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // lblselecionado
            // 
            this.lblselecionado.AutoSize = true;
            this.lblselecionado.Location = new System.Drawing.Point(429, 329);
            this.lblselecionado.Name = "lblselecionado";
            this.lblselecionado.Size = new System.Drawing.Size(195, 30);
            this.lblselecionado.TabIndex = 8;
            this.lblselecionado.Text = "DNS selecionado";
            // 
            // btnEliminarDNs
            // 
            this.btnEliminarDNs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarDNs.BackgroundImage")));
            this.btnEliminarDNs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarDNs.Location = new System.Drawing.Point(468, 218);
            this.btnEliminarDNs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarDNs.Name = "btnEliminarDNs";
            this.btnEliminarDNs.Size = new System.Drawing.Size(43, 34);
            this.btnEliminarDNs.TabIndex = 7;
            this.btnEliminarDNs.UseVisualStyleBackColor = true;
            this.btnEliminarDNs.Click += new System.EventHandler(this.btnEliminarDNs_Click);
            // 
            // btnAgregarDNS
            // 
            this.btnAgregarDNS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarDNS.BackgroundImage")));
            this.btnAgregarDNS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarDNS.Location = new System.Drawing.Point(468, 181);
            this.btnAgregarDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarDNS.Name = "btnAgregarDNS";
            this.btnAgregarDNS.Size = new System.Drawing.Size(43, 34);
            this.btnAgregarDNS.TabIndex = 6;
            this.btnAgregarDNS.UseVisualStyleBackColor = true;
            this.btnAgregarDNS.Click += new System.EventHandler(this.btnAgregarDNS_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(513, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(486, 307);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDnsPrimario);
            this.tabPage1.Controls.Add(this.txtDnsSecundario);
            this.tabPage1.Controls.Add(this.txtNombreDNS);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(478, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Dominio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDnsPrimario
            // 
            this.txtDnsPrimario.Location = new System.Drawing.Point(139, 113);
            this.txtDnsPrimario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDnsPrimario.Name = "txtDnsPrimario";
            this.txtDnsPrimario.Size = new System.Drawing.Size(216, 37);
            this.txtDnsPrimario.TabIndex = 5;
            // 
            // txtDnsSecundario
            // 
            this.txtDnsSecundario.Location = new System.Drawing.Point(162, 165);
            this.txtDnsSecundario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDnsSecundario.Name = "txtDnsSecundario";
            this.txtDnsSecundario.Size = new System.Drawing.Size(216, 37);
            this.txtDnsSecundario.TabIndex = 4;
            // 
            // txtNombreDNS
            // 
            this.txtNombreDNS.Location = new System.Drawing.Point(193, 66);
            this.txtNombreDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreDNS.Name = "txtNombreDNS";
            this.txtNombreDNS.Size = new System.Drawing.Size(216, 37);
            this.txtNombreDNS.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 30);
            this.label16.TabIndex = 2;
            this.label16.Text = "Secundario:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 30);
            this.label15.TabIndex = 1;
            this.label15.Text = "Primario:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 30);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nombre DNS:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tVDNS);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(478, 264);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "VerDominios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tVDNS
            // 
            this.tVDNS.Location = new System.Drawing.Point(17, 12);
            this.tVDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tVDNS.Name = "tVDNS";
            this.tVDNS.Size = new System.Drawing.Size(445, 248);
            this.tVDNS.TabIndex = 0;
            this.tVDNS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVDNS_AfterSelect);
            // 
            // rtbDNS
            // 
            this.rtbDNS.Location = new System.Drawing.Point(36, 114);
            this.rtbDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbDNS.Name = "rtbDNS";
            this.rtbDNS.Size = new System.Drawing.Size(408, 182);
            this.rtbDNS.TabIndex = 6;
            this.rtbDNS.Text = "";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(388, 59);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(57, 34);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "🔎";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusacar
            // 
            this.txtBusacar.Location = new System.Drawing.Point(36, 59);
            this.txtBusacar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBusacar.Name = "txtBusacar";
            this.txtBusacar.Size = new System.Drawing.Size(328, 37);
            this.txtBusacar.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(516, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 30);
            this.label13.TabIndex = 3;
            this.label13.Text = "Cliente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(175, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 30);
            this.label12.TabIndex = 2;
            this.label12.Text = "Bitacora";
            // 
            // rtbbitacora
            // 
            this.rtbbitacora.Location = new System.Drawing.Point(22, 394);
            this.rtbbitacora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbbitacora.Name = "rtbbitacora";
            this.rtbbitacora.Size = new System.Drawing.Size(433, 220);
            this.rtbbitacora.TabIndex = 1;
            this.rtbbitacora.Text = "";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colHostname,
            this.colTipo,
            this.colIP,
            this.colActivo});
            this.dgvClientes.Location = new System.Drawing.Point(465, 401);
            this.dgvClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 62;
            this.dgvClientes.RowTemplate.Height = 28;
            this.dgvClientes.Size = new System.Drawing.Size(534, 182);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 8;
            this.colNombre.Name = "colNombre";
            this.colNombre.Width = 120;
            // 
            // colHostname
            // 
            this.colHostname.HeaderText = "Hostname";
            this.colHostname.MinimumWidth = 8;
            this.colHostname.Name = "colHostname";
            this.colHostname.Width = 130;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 8;
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 90;
            // 
            // colIP
            // 
            this.colIP.HeaderText = "IP";
            this.colIP.MinimumWidth = 8;
            this.colIP.Name = "colIP";
            this.colIP.Width = 120;
            // 
            // colActivo
            // 
            this.colActivo.HeaderText = "Activo";
            this.colActivo.MinimumWidth = 8;
            this.colActivo.Name = "colActivo";
            this.colActivo.Width = 60;
            // 
            // timerSimulacion
            // 
            this.timerSimulacion.Enabled = true;
            this.timerSimulacion.Interval = 1000;
            // 
            // frmServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 672);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmServ";
            this.Text = "Servidor";
            this.tabControl1.ResumeLayout(false);
            this.tabDHCP.ResumeLayout(false);
            this.tabDHCP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBDHCP.ResumeLayout(false);
            this.gBDHCP.PerformLayout();
            this.gbCrearC.ResumeLayout(false);
            this.gbCrearC.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDHCP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listCliente;
        private System.Windows.Forms.GroupBox gbCrearC;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gBDHCP;
        private System.Windows.Forms.CheckBox CBInac;
        private System.Windows.Forms.CheckBox CBAct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cBoxTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalIP;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.Label lblIpsUs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIpLibres;
        private System.Windows.Forms.Label lblConsumo;
        private System.Windows.Forms.Timer timerSimulacion;
        private System.Windows.Forms.Label lblTotalRed;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.TextBox txtsubred;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMascaraCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBroadcast;
        private System.Windows.Forms.TextBox txtBroadcast;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtbbitacora;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActivo;
        private System.Windows.Forms.RichTextBox rtbDNS;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBusacar;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tVDNS;
        private System.Windows.Forms.Button btnEliminarDNs;
        private System.Windows.Forms.Button btnAgregarDNS;
        private System.Windows.Forms.TextBox txtDnsPrimario;
        private System.Windows.Forms.TextBox txtDnsSecundario;
        private System.Windows.Forms.TextBox txtNombreDNS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblselecionado;
        private System.Windows.Forms.Button btnDesconectar;
    }
}

