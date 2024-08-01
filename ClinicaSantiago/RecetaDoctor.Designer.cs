namespace ClinicaSantiago
{
    partial class RecetaDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecetaDoctor));
            recetabtn = new Button();
            cbxpaciente = new ComboBox();
            label1 = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // recetabtn
            // 
            recetabtn.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            recetabtn.Location = new Point(323, 214);
            recetabtn.Name = "recetabtn";
            recetabtn.Size = new Size(160, 47);
            recetabtn.TabIndex = 43;
            recetabtn.Text = "Ver Receta";
            recetabtn.UseVisualStyleBackColor = true;
            recetabtn.Click += recetabtn_Click;
            // 
            // cbxpaciente
            // 
            cbxpaciente.FormattingEnabled = true;
            cbxpaciente.Location = new Point(323, 180);
            cbxpaciente.Name = "cbxpaciente";
            cbxpaciente.Size = new Size(160, 28);
            cbxpaciente.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(323, 157);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 45;
            label1.Text = "Codigo del Paciente";
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            printPreviewDialog1.Load += printPreviewDialog1_Load;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // RecetaDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._9ff7d1a690e7bf508eda106f9bc13dab;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(cbxpaciente);
            Controls.Add(recetabtn);
            MaximizeBox = false;
            Name = "RecetaDoctor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecetaDoctor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button recetabtn;
        private ComboBox cbxpaciente;
        private Label label1;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}