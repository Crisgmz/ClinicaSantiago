namespace ClinicaSantiago
{
    partial class Diagnosticos
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
            iddiagnosticotxt = new TextBox();
            dgvmedicina = new DataGridView();
            Serial = new DataGridViewTextBoxColumn();
            NombreMedicina = new DataGridViewTextBoxColumn();
            Agregarbtn = new Button();
            guardarbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            pacientecbx = new ComboBox();
            edadtxt = new TextBox();
            label12 = new Label();
            label8 = new Label();
            label3 = new Label();
            label5 = new Label();
            tiposangretxt = new TextBox();
            contactotxt = new TextBox();
            codigopaciente = new TextBox();
            label6 = new Label();
            generotxt = new TextBox();
            txtmedicina = new TextBox();
            dgvsintomas = new DataGridView();
            descripciontxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvmedicina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvsintomas).BeginInit();
            SuspendLayout();
            // 
            // iddiagnosticotxt
            // 
            iddiagnosticotxt.Location = new Point(90, 755);
            iddiagnosticotxt.Name = "iddiagnosticotxt";
            iddiagnosticotxt.ReadOnly = true;
            iddiagnosticotxt.Size = new Size(200, 27);
            iddiagnosticotxt.TabIndex = 48;
            iddiagnosticotxt.Visible = false;
            // 
            // dgvmedicina
            // 
            dgvmedicina.AllowUserToResizeColumns = false;
            dgvmedicina.AllowUserToResizeRows = false;
            dgvmedicina.ColumnHeadersHeight = 29;
            dgvmedicina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvmedicina.Columns.AddRange(new DataGridViewColumn[] { Serial, NombreMedicina });
            dgvmedicina.Location = new Point(516, 272);
            dgvmedicina.Name = "dgvmedicina";
            dgvmedicina.RowHeadersWidth = 51;
            dgvmedicina.RowTemplate.Height = 29;
            dgvmedicina.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmedicina.Size = new Size(457, 478);
            dgvmedicina.TabIndex = 46;
            dgvmedicina.CellDoubleClick += dgvmedicina_CellDoubleClick;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial";
            Serial.MinimumWidth = 6;
            Serial.Name = "Serial";
            Serial.Width = 125;
            // 
            // NombreMedicina
            // 
            NombreMedicina.HeaderText = "Nombre de Medicina";
            NombreMedicina.MinimumWidth = 6;
            NombreMedicina.Name = "NombreMedicina";
            NombreMedicina.Width = 125;
            // 
            // Agregarbtn
            // 
            Agregarbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Agregarbtn.Location = new Point(296, 219);
            Agregarbtn.Name = "Agregarbtn";
            Agregarbtn.Size = new Size(186, 47);
            Agregarbtn.TabIndex = 42;
            Agregarbtn.Text = "Agregar";
            Agregarbtn.UseVisualStyleBackColor = true;
            Agregarbtn.Click += Agregarbtn_Click;
            // 
            // guardarbtn
            // 
            guardarbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guardarbtn.Location = new Point(488, 219);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(186, 47);
            guardarbtn.TabIndex = 41;
            guardarbtn.Text = "Guardar";
            guardarbtn.UseVisualStyleBackColor = true;
            guardarbtn.Click += guardarbtn_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins", 40.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(44, -10);
            label2.Name = "label2";
            label2.Size = new Size(951, 118);
            label2.TabIndex = 28;
            label2.Text = "SISTEMA CLINICO SANTIAGO";
            // 
            // pacientecbx
            // 
            pacientecbx.FormattingEnabled = true;
            pacientecbx.Location = new Point(90, 140);
            pacientecbx.Name = "pacientecbx";
            pacientecbx.Size = new Size(200, 28);
            pacientecbx.TabIndex = 50;
            pacientecbx.SelectedValueChanged += pacientecbx_SelectedValueChanged;
            // 
            // edadtxt
            // 
            edadtxt.Location = new Point(306, 141);
            edadtxt.Name = "edadtxt";
            edadtxt.ReadOnly = true;
            edadtxt.Size = new Size(87, 27);
            edadtxt.TabIndex = 77;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Location = new Point(306, 108);
            label12.Name = "label12";
            label12.Size = new Size(43, 20);
            label12.TabIndex = 76;
            label12.Text = "Edad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(522, 108);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 73;
            label8.Text = "Tipo Sangre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(399, 108);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 69;
            label3.Text = "Genero";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(617, 108);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 67;
            label5.Text = "Contacto";
            // 
            // tiposangretxt
            // 
            tiposangretxt.Location = new Point(524, 140);
            tiposangretxt.Name = "tiposangretxt";
            tiposangretxt.ReadOnly = true;
            tiposangretxt.Size = new Size(87, 27);
            tiposangretxt.TabIndex = 80;
            // 
            // contactotxt
            // 
            contactotxt.Location = new Point(617, 141);
            contactotxt.Name = "contactotxt";
            contactotxt.ReadOnly = true;
            contactotxt.Size = new Size(87, 27);
            contactotxt.TabIndex = 81;
            // 
            // codigopaciente
            // 
            codigopaciente.Location = new Point(716, 140);
            codigopaciente.Name = "codigopaciente";
            codigopaciente.ReadOnly = true;
            codigopaciente.Size = new Size(172, 27);
            codigopaciente.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(716, 108);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 82;
            label6.Text = "CodigoPaciente";
            // 
            // generotxt
            // 
            generotxt.Location = new Point(399, 140);
            generotxt.Name = "generotxt";
            generotxt.ReadOnly = true;
            generotxt.Size = new Size(111, 27);
            generotxt.TabIndex = 84;
            // 
            // txtmedicina
            // 
            txtmedicina.Location = new Point(90, 219);
            txtmedicina.Multiline = true;
            txtmedicina.Name = "txtmedicina";
            txtmedicina.Size = new Size(200, 47);
            txtmedicina.TabIndex = 86;
            // 
            // dgvsintomas
            // 
            dgvsintomas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvsintomas.Location = new Point(90, 272);
            dgvsintomas.Name = "dgvsintomas";
            dgvsintomas.RowHeadersWidth = 51;
            dgvsintomas.RowTemplate.Height = 29;
            dgvsintomas.Size = new Size(420, 477);
            dgvsintomas.TabIndex = 87;
            // 
            // descripciontxt
            // 
            descripciontxt.Location = new Point(90, 186);
            descripciontxt.Name = "descripciontxt";
            descripciontxt.Size = new Size(883, 27);
            descripciontxt.TabIndex = 88;
            // 
            // Diagnosticos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1054, 792);
            Controls.Add(descripciontxt);
            Controls.Add(dgvsintomas);
            Controls.Add(txtmedicina);
            Controls.Add(generotxt);
            Controls.Add(codigopaciente);
            Controls.Add(label6);
            Controls.Add(contactotxt);
            Controls.Add(tiposangretxt);
            Controls.Add(edadtxt);
            Controls.Add(label12);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(pacientecbx);
            Controls.Add(iddiagnosticotxt);
            Controls.Add(dgvmedicina);
            Controls.Add(Agregarbtn);
            Controls.Add(guardarbtn);
            Controls.Add(label1);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "Diagnosticos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diagnosticos";
            Load += pacientecbx_SelectedValueChanged;
            ((System.ComponentModel.ISupportInitialize)dgvmedicina).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvsintomas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginIDDoctortxt;
        private TextBox iddiagnosticotxt;
        private CheckBox permisologinchk;
        private DataGridView dgvmedicina;
        private Button eliminarbtn;
        private Button Agregarbtn;
        private Button guardarbtn;
        private Label label7;
        private TextBox direcciontxt;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn NombreMedicina;
        private ComboBox pacientecbx;
        private TextBox edadtxt;
        private Label label12;
        private ComboBox doctorcbx;
        private Label label9;
        private Label label8;
        private Label label3;
        private Label label5;
        private TextBox contactopacientetxt;
        private TextBox descripciontxt;
        private TextBox textBox2;
        private TextBox tiposangretxt;
        private TextBox contactotxt;
        private TextBox codigopaciente;
        private Label label6;
        private TextBox generotxt;
        private TextBox txtmedicina;
        private DataGridView dgvsintomas;
    }
}