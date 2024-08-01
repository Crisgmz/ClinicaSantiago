namespace ClinicaSantiago
{
    partial class VerPacientes
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
            label2 = new Label();
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
            pacientesdgv.Location = new Point(90, 115);
            pacientesdgv.Name = "pacientesdgv";
            pacientesdgv.RowHeadersWidth = 51;
            pacientesdgv.RowTemplate.Height = 29;
            pacientesdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pacientesdgv.Size = new Size(1024, 634);
            pacientesdgv.TabIndex = 46;
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
            // VerPacientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1204, 792);
            Controls.Add(idpacientetxt);
            Controls.Add(pacientesdgv);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "VerPacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vista Pacientes";
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
        private TextBox edaddoctortxt;
        private TextBox contrasenadoctortxt;
        private TextBox usuariodoctortxt;
        private Label label2;
    }
}