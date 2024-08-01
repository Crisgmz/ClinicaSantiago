namespace ClinicaSantiago
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginbtn = new Button();
            contrasenatxt = new TextBox();
            usuariotxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            crearusuariolinklbl = new LinkLabel();
            SuspendLayout();
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(276, 252);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(230, 48);
            loginbtn.TabIndex = 0;
            loginbtn.Text = "Iniciar Sesion";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += button1_Click;
            // 
            // contrasenatxt
            // 
            contrasenatxt.Location = new Point(276, 211);
            contrasenatxt.Multiline = true;
            contrasenatxt.Name = "contrasenatxt";
            contrasenatxt.Size = new Size(230, 35);
            contrasenatxt.TabIndex = 1;
            // 
            // usuariotxt
            // 
            usuariotxt.Location = new Point(276, 148);
            usuariotxt.Multiline = true;
            usuariotxt.Name = "usuariotxt";
            usuariotxt.Size = new Size(230, 35);
            usuariotxt.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(276, 125);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(276, 188);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 4;
            label2.Text = "Contrasena";
            // 
            // crearusuariolinklbl
            // 
            crearusuariolinklbl.AutoSize = true;
            crearusuariolinklbl.BackColor = Color.Transparent;
            crearusuariolinklbl.LinkColor = Color.Black;
            crearusuariolinklbl.Location = new Point(232, 303);
            crearusuariolinklbl.Name = "crearusuariolinklbl";
            crearusuariolinklbl.Size = new Size(333, 20);
            crearusuariolinklbl.TabIndex = 5;
            crearusuariolinklbl.TabStop = true;
            crearusuariolinklbl.Text = "SI NO TIENE USUARIO - CLICK PARA CREAR UNO";
            crearusuariolinklbl.LinkClicked += crearusuariolinklbl_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(crearusuariolinklbl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(usuariotxt);
            Controls.Add(contrasenatxt);
            Controls.Add(loginbtn);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginbtn;
        private TextBox contrasenatxt;
        private TextBox usuariotxt;
        private Label label1;
        private Label label2;
        private LinkLabel crearusuariolinklbl;
    }
}