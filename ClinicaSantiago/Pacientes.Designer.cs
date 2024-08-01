namespace ClinicaSantiago
{
    partial class Pacientes
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
            idpacientetxt = new TextBox();
            pacientesdgv = new DataGridView();
            Serial = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            obtenerrecetabtn = new Button();
            guardarbtn = new Button();
            label7 = new Label();
            direcciontxt = new TextBox();
            label6 = new Label();
            label5 = new Label();
            contactopacientetxt = new TextBox();
            label1 = new Label();
            nombrepacientetxt = new TextBox();
            label2 = new Label();
            generocbx = new ComboBox();
            label3 = new Label();
            sintomacbx = new ComboBox();
            label4 = new Label();
            tiposangrecbx = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            doctorcbx = new ComboBox();
            label10 = new Label();
            codigopacientelbl = new Label();
            AgregarPacientebtn = new Button();
            Otrosintomatxt = new TextBox();
            label11 = new Label();
            fechanacimientopicker = new DateTimePicker();
            label12 = new Label();
            edadtxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pacientesdgv).BeginInit();
            SuspendLayout();
            // 
            // idpacientetxt
            // 
            idpacientetxt.Location = new Point(90, 755);
            idpacientetxt.Name = "idpacientetxt";
            idpacientetxt.ReadOnly = true;
            idpacientetxt.Size = new Size(200, 27);
            idpacientetxt.TabIndex = 48;
            idpacientetxt.Visible = false;
            // 
            // pacientesdgv
            // 
            pacientesdgv.AllowUserToResizeColumns = false;
            pacientesdgv.AllowUserToResizeRows = false;
            pacientesdgv.ColumnHeadersHeight = 29;
            pacientesdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            pacientesdgv.Columns.AddRange(new DataGridViewColumn[] { Serial, Nombre });
            pacientesdgv.Location = new Point(90, 315);
            pacientesdgv.Name = "pacientesdgv";
            pacientesdgv.RowHeadersWidth = 51;
            pacientesdgv.RowTemplate.Height = 29;
            pacientesdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pacientesdgv.Size = new Size(1024, 434);
            pacientesdgv.TabIndex = 46;
            pacientesdgv.CellFormatting += patientDataGridView_CellFormatting;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial";
            Serial.MinimumWidth = 6;
            Serial.Name = "Serial";
            Serial.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // obtenerrecetabtn
            // 
            obtenerrecetabtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            obtenerrecetabtn.Location = new Point(954, 262);
            obtenerrecetabtn.Name = "obtenerrecetabtn";
            obtenerrecetabtn.Size = new Size(160, 47);
            obtenerrecetabtn.TabIndex = 42;
            obtenerrecetabtn.Text = "Obtener Receta";
            obtenerrecetabtn.UseVisualStyleBackColor = true;
            obtenerrecetabtn.Click += obtenerrecetabtn_Click;
            // 
            // guardarbtn
            // 
            guardarbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guardarbtn.Location = new Point(762, 262);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(186, 47);
            guardarbtn.TabIndex = 41;
            guardarbtn.Text = "Guardar";
            guardarbtn.UseVisualStyleBackColor = true;
            guardarbtn.Click += guardarbtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(244, 177);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 40;
            label7.Text = "Direccion";
            // 
            // direcciontxt
            // 
            direcciontxt.Location = new Point(244, 210);
            direcciontxt.Name = "direcciontxt";
            direcciontxt.Size = new Size(406, 27);
            direcciontxt.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(90, 177);
            label6.Name = "label6";
            label6.Size = new Size(128, 20);
            label6.TabIndex = 38;
            label6.Text = "Fecha Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(801, 108);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 36;
            label5.Text = "Contacto";
            // 
            // contactopacientetxt
            // 
            contactopacientetxt.Location = new Point(801, 141);
            contactopacientetxt.Name = "contactopacientetxt";
            contactopacientetxt.Size = new Size(111, 27);
            contactopacientetxt.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(90, 108);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 30;
            label1.Text = "Nombre del Paciente";
            // 
            // nombrepacientetxt
            // 
            nombrepacientetxt.Location = new Point(90, 141);
            nombrepacientetxt.Name = "nombrepacientetxt";
            nombrepacientetxt.Size = new Size(200, 27);
            nombrepacientetxt.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins", 40.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(132, 9);
            label2.Name = "label2";
            label2.Size = new Size(951, 118);
            label2.TabIndex = 28;
            label2.Text = "SISTEMA CLINICO SANTIAGO";
            // 
            // generocbx
            // 
            generocbx.FormattingEnabled = true;
            generocbx.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            generocbx.Location = new Point(389, 140);
            generocbx.Name = "generocbx";
            generocbx.Size = new Size(151, 28);
            generocbx.TabIndex = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(389, 108);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 51;
            label3.Text = "Genero";
            // 
            // sintomacbx
            // 
            sintomacbx.FormattingEnabled = true;
            sintomacbx.Items.AddRange(new object[] { "Dolor de cabeza", "Fiebre", "Diarrea", "Dolor de estomago", "Irritacion en la piel", "Irritacion en los ojos", "Otro" });
            sintomacbx.Location = new Point(546, 140);
            sintomacbx.Name = "sintomacbx";
            sintomacbx.Size = new Size(151, 28);
            sintomacbx.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(546, 108);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 53;
            label4.Text = "Sintoma";
            // 
            // tiposangrecbx
            // 
            tiposangrecbx.FormattingEnabled = true;
            tiposangrecbx.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-" });
            tiposangrecbx.Location = new Point(703, 140);
            tiposangrecbx.Name = "tiposangrecbx";
            tiposangrecbx.Size = new Size(90, 28);
            tiposangrecbx.TabIndex = 54;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(703, 108);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 55;
            label8.Text = "Tipo Sangre";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(918, 108);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 56;
            label9.Text = "Doctor";
            // 
            // doctorcbx
            // 
            doctorcbx.FormattingEnabled = true;
            doctorcbx.Location = new Point(918, 141);
            doctorcbx.Name = "doctorcbx";
            doctorcbx.Size = new Size(196, 28);
            doctorcbx.TabIndex = 57;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(657, 190);
            label10.Name = "label10";
            label10.Size = new Size(120, 20);
            label10.TabIndex = 58;
            label10.Text = "Codigo Paciente:";
            // 
            // codigopacientelbl
            // 
            codigopacientelbl.AutoSize = true;
            codigopacientelbl.BackColor = Color.Transparent;
            codigopacientelbl.Location = new Point(657, 217);
            codigopacientelbl.Name = "codigopacientelbl";
            codigopacientelbl.Size = new Size(73, 20);
            codigopacientelbl.TabIndex = 59;
            codigopacientelbl.Text = "00000000";
            // 
            // AgregarPacientebtn
            // 
            AgregarPacientebtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AgregarPacientebtn.Location = new Point(629, 262);
            AgregarPacientebtn.Name = "AgregarPacientebtn";
            AgregarPacientebtn.Size = new Size(127, 47);
            AgregarPacientebtn.TabIndex = 60;
            AgregarPacientebtn.Text = "Agregar";
            AgregarPacientebtn.UseVisualStyleBackColor = true;
            AgregarPacientebtn.Click += AgregarPacientebtn_Click;
            // 
            // Otrosintomatxt
            // 
            Otrosintomatxt.Enabled = false;
            Otrosintomatxt.Location = new Point(801, 212);
            Otrosintomatxt.Name = "Otrosintomatxt";
            Otrosintomatxt.ReadOnly = true;
            Otrosintomatxt.Size = new Size(313, 27);
            Otrosintomatxt.TabIndex = 61;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Location = new Point(801, 190);
            label11.Name = "label11";
            label11.Size = new Size(98, 20);
            label11.TabIndex = 62;
            label11.Text = "Otro Sintoma";
            // 
            // fechanacimientopicker
            // 
            fechanacimientopicker.Format = DateTimePickerFormat.Short;
            fechanacimientopicker.Location = new Point(90, 210);
            fechanacimientopicker.Name = "fechanacimientopicker";
            fechanacimientopicker.Size = new Size(139, 27);
            fechanacimientopicker.TabIndex = 63;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Location = new Point(296, 108);
            label12.Name = "label12";
            label12.Size = new Size(43, 20);
            label12.TabIndex = 64;
            label12.Text = "Edad";
            // 
            // edadtxt
            // 
            edadtxt.Location = new Point(296, 141);
            edadtxt.Name = "edadtxt";
            edadtxt.ReadOnly = true;
            edadtxt.Size = new Size(87, 27);
            edadtxt.TabIndex = 65;
            // 
            // Pacientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1204, 792);
            Controls.Add(edadtxt);
            Controls.Add(label12);
            Controls.Add(fechanacimientopicker);
            Controls.Add(label11);
            Controls.Add(Otrosintomatxt);
            Controls.Add(AgregarPacientebtn);
            Controls.Add(codigopacientelbl);
            Controls.Add(label10);
            Controls.Add(doctorcbx);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tiposangrecbx);
            Controls.Add(label4);
            Controls.Add(sintomacbx);
            Controls.Add(label3);
            Controls.Add(generocbx);
            Controls.Add(idpacientetxt);
            Controls.Add(pacientesdgv);
            Controls.Add(obtenerrecetabtn);
            Controls.Add(guardarbtn);
            Controls.Add(label7);
            Controls.Add(direcciontxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(contactopacientetxt);
            Controls.Add(label1);
            Controls.Add(nombrepacientetxt);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "Pacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pacientes";
            ((System.ComponentModel.ISupportInitialize)pacientesdgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginIDDoctortxt;
        private TextBox idpacientetxt;
        private CheckBox permisologinchk;
        private DataGridView pacientesdgv;
        private TextBox anosexpetxt;
        private Button obtenerrecetabtn;
        private Button guardarbtn;
        private Label label7;
        private TextBox direcciontxt;
        private Label label6;
        private TextBox edaddoctortxt;
        private Label label5;
        private TextBox contactopacientetxt;
        private Label label4;
        private TextBox contrasenadoctortxt;
        private TextBox usuariodoctortxt;
        private Label label3;
        private Label label1;
        private TextBox nombrepacientetxt;
        private Label label2;
        private ComboBox generocbx;
        private ComboBox sintomacbx;
        private ComboBox tiposangrecbx;
        private Label label8;
        private Label label9;
        private ComboBox doctorcbx;
        private Label label10;
        private Label codigopacientelbl;
        private Button AgregarPacientebtn;
        private TextBox Otrosintomatxt;
        private Label label11;
        private DateTimePicker fechanacimientopicker;
        private Label label12;
        private TextBox edadtxt;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn Nombre;
    }
}