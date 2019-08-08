namespace Calculator_App
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EDDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MFDB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MPWDB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MDCDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EFDB = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comPortToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comPortToolStripMenuItem
            // 
            this.comPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.comPortToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
            this.comPortToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.comPortToolStripMenuItem.Text = "&Com Port";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM102";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn1.BackColor = System.Drawing.Color.DimGray;
            this.btn1.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.LightGray;
            this.btn1.Location = new System.Drawing.Point(71, 301);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 60);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.button_click);
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn2.BackColor = System.Drawing.Color.DimGray;
            this.btn2.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.LightGray;
            this.btn2.Location = new System.Drawing.Point(176, 301);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(60, 60);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.button_click);
            // 
            // btn3
            // 
            this.btn3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn3.BackColor = System.Drawing.Color.DimGray;
            this.btn3.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.Color.LightGray;
            this.btn3.Location = new System.Drawing.Point(290, 301);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(60, 60);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.button_click);
            // 
            // btn4
            // 
            this.btn4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn4.BackColor = System.Drawing.Color.DimGray;
            this.btn4.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.Color.LightGray;
            this.btn4.Location = new System.Drawing.Point(71, 216);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 60);
            this.btn4.TabIndex = 4;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.button_click);
            // 
            // btn5
            // 
            this.btn5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn5.BackColor = System.Drawing.Color.DimGray;
            this.btn5.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.LightGray;
            this.btn5.Location = new System.Drawing.Point(176, 216);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(60, 60);
            this.btn5.TabIndex = 5;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.button_click);
            // 
            // btn6
            // 
            this.btn6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn6.BackColor = System.Drawing.Color.DimGray;
            this.btn6.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.Color.LightGray;
            this.btn6.Location = new System.Drawing.Point(290, 216);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(60, 60);
            this.btn6.TabIndex = 6;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.button_click);
            // 
            // btn7
            // 
            this.btn7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn7.BackColor = System.Drawing.Color.DimGray;
            this.btn7.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.Color.LightGray;
            this.btn7.Location = new System.Drawing.Point(71, 124);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(60, 60);
            this.btn7.TabIndex = 7;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.button_click);
            // 
            // btn8
            // 
            this.btn8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn8.BackColor = System.Drawing.Color.DimGray;
            this.btn8.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.Color.LightGray;
            this.btn8.Location = new System.Drawing.Point(176, 124);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(60, 60);
            this.btn8.TabIndex = 8;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.button_click);
            // 
            // btn9
            // 
            this.btn9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn9.BackColor = System.Drawing.Color.DimGray;
            this.btn9.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.Color.LightGray;
            this.btn9.Location = new System.Drawing.Point(290, 124);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(60, 60);
            this.btn9.TabIndex = 9;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.button_click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlus.BackColor = System.Drawing.Color.DarkGray;
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.Location = new System.Drawing.Point(407, 311);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(126, 126);
            this.btnPlus.TabIndex = 11;
            this.btnPlus.Text = "#";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.operator_click);
            // 
            // btn0
            // 
            this.btn0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn0.BackColor = System.Drawing.Color.DimGray;
            this.btn0.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.ForeColor = System.Drawing.Color.LightGray;
            this.btn0.Location = new System.Drawing.Point(71, 388);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(279, 60);
            this.btn0.TabIndex = 0;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.button_click);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnClear.BackColor = System.Drawing.Color.Maroon;
            this.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.BtnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.BtnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(407, 124);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(126, 60);
            this.BtnClear.TabIndex = 16;
            this.BtnClear.Text = "Reset";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMultiply.BackColor = System.Drawing.Color.DarkGray;
            this.btnMultiply.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnMultiply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnMultiply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiply.Font = new System.Drawing.Font("Segoe WP", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiply.ForeColor = System.Drawing.Color.White;
            this.btnMultiply.Location = new System.Drawing.Point(407, 216);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(126, 60);
            this.btnMultiply.TabIndex = 13;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = false;
            this.btnMultiply.Click += new System.EventHandler(this.operator_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(836, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Entered Duty Cycle";
            // 
            // EDDB
            // 
            this.EDDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EDDB.BackColor = System.Drawing.SystemColors.Info;
            this.EDDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EDDB.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDDB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.EDDB.Location = new System.Drawing.Point(802, 108);
            this.EDDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EDDB.MaxLength = 20;
            this.EDDB.Name = "EDDB";
            this.EDDB.Size = new System.Drawing.Size(186, 55);
            this.EDDB.TabIndex = 18;
            this.EDDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EDDB.TextChanged += new System.EventHandler(this.EDDB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Measured Frequency";
            // 
            // MFDB
            // 
            this.MFDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MFDB.BackColor = System.Drawing.SystemColors.Info;
            this.MFDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MFDB.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MFDB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.MFDB.Location = new System.Drawing.Point(567, 221);
            this.MFDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MFDB.MaxLength = 20;
            this.MFDB.Name = "MFDB";
            this.MFDB.Size = new System.Drawing.Size(186, 55);
            this.MFDB.TabIndex = 20;
            this.MFDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MFDB.TextChanged += new System.EventHandler(this.MFDB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Measure Positive Pulse Width";
            // 
            // MPWDB
            // 
            this.MPWDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MPWDB.BackColor = System.Drawing.SystemColors.Info;
            this.MPWDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MPWDB.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPWDB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.MPWDB.Location = new System.Drawing.Point(802, 234);
            this.MPWDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MPWDB.MaxLength = 20;
            this.MPWDB.Name = "MPWDB";
            this.MPWDB.Size = new System.Drawing.Size(186, 55);
            this.MPWDB.TabIndex = 22;
            this.MPWDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MPWDB.TextChanged += new System.EventHandler(this.MPWDB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(572, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Measured Duty Cycle";
            // 
            // MDCDB
            // 
            this.MDCDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MDCDB.BackColor = System.Drawing.SystemColors.Info;
            this.MDCDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MDCDB.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDCDB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.MDCDB.Location = new System.Drawing.Point(567, 322);
            this.MDCDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MDCDB.MaxLength = 20;
            this.MDCDB.Name = "MDCDB";
            this.MDCDB.Size = new System.Drawing.Size(186, 55);
            this.MDCDB.TabIndex = 24;
            this.MDCDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MDCDB.TextChanged += new System.EventHandler(this.MDCDB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Entered Freqeuency";
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDisplay.BackColor = System.Drawing.SystemColors.Info;
            this.tbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDisplay.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplay.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tbDisplay.Location = new System.Drawing.Point(71, 62);
            this.tbDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDisplay.MaxLength = 20;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(449, 55);
            this.tbDisplay.TabIndex = 26;
            this.tbDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Work Screen";
            // 
            // EFDB
            // 
            this.EFDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EFDB.BackColor = System.Drawing.SystemColors.Info;
            this.EFDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EFDB.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFDB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.EFDB.Location = new System.Drawing.Point(567, 108);
            this.EFDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFDB.MaxLength = 20;
            this.EFDB.Name = "EFDB";
            this.EFDB.Size = new System.Drawing.Size(186, 55);
            this.EFDB.TabIndex = 28;
            this.EFDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EFDB.TextChanged += new System.EventHandler(this.EFDB_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1121, 606);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EFDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MDCDB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MPWDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MFDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EDDB);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSerialTx_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EDDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MFDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MPWDB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MDCDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EFDB;
    }
}

