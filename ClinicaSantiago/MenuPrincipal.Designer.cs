namespace ClinicaSantiago
{
    partial class MenuPrincipal
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            Doctoresbtn = new Button();
            Pacientesbtn = new Button();
            Diagnosticobtn = new Button();
            button1 = new Button();
            cerrarsesionbtn = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(954, 125);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(843, 104);
            label2.TabIndex = 1;
            label2.Text = "SISTEMA CLINICO SANTIAGO";
            // 
            // Doctoresbtn
            // 
            Doctoresbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Doctoresbtn.Location = new Point(12, 143);
            Doctoresbtn.Name = "Doctoresbtn";
            Doctoresbtn.Size = new Size(186, 47);
            Doctoresbtn.TabIndex = 1;
            Doctoresbtn.Text = "Doctores";
            Doctoresbtn.UseVisualStyleBackColor = true;
            Doctoresbtn.Click += Doctoresbtn_Click;
            // 
            // Pacientesbtn
            // 
            Pacientesbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Pacientesbtn.Location = new Point(204, 143);
            Pacientesbtn.Name = "Pacientesbtn";
            Pacientesbtn.Size = new Size(186, 47);
            Pacientesbtn.TabIndex = 2;
            Pacientesbtn.Text = "Consulta Paciente";
            Pacientesbtn.UseVisualStyleBackColor = true;
            Pacientesbtn.Click += Pacientesbtn_Click;
            // 
            // Diagnosticobtn
            // 
            Diagnosticobtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Diagnosticobtn.Location = new Point(396, 143);
            Diagnosticobtn.Name = "Diagnosticobtn";
            Diagnosticobtn.Size = new Size(186, 47);
            Diagnosticobtn.TabIndex = 3;
            Diagnosticobtn.Text = "Diagnosticos";
            Diagnosticobtn.UseVisualStyleBackColor = true;
            Diagnosticobtn.Click += Diagnosticobtn_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(588, 143);
            button1.Name = "button1";
            button1.Size = new Size(186, 47);
            button1.TabIndex = 4;
            button1.Text = "Pacientes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cerrarsesionbtn
            // 
            cerrarsesionbtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cerrarsesionbtn.Location = new Point(780, 143);
            cerrarsesionbtn.Name = "cerrarsesionbtn";
            cerrarsesionbtn.Size = new Size(186, 47);
            cerrarsesionbtn.TabIndex = 5;
            cerrarsesionbtn.Text = "Cerrar Sesion";
            cerrarsesionbtn.UseVisualStyleBackColor = true;
            cerrarsesionbtn.Click += cerrarsesionbtn_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(981, 585);
            Controls.Add(cerrarsesionbtn);
            Controls.Add(button1);
            Controls.Add(Diagnosticobtn);
            Controls.Add(Pacientesbtn);
            Controls.Add(Doctoresbtn);
            Controls.Add(flowLayoutPanel1);
            MaximizeBox = false;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Button Doctoresbtn;
        private Button Pacientesbtn;
        private Button Diagnosticobtn;
        private Button button1;
        private Button cerrarsesionbtn;
    }
}