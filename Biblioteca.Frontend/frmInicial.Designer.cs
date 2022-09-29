namespace Biblioteca.Frontend
{
    partial class frmInicial
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
            this.btnLibros = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLibros
            // 
            this.btnLibros.Location = new System.Drawing.Point(12, 152);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(213, 139);
            this.btnLibros.TabIndex = 0;
            this.btnLibros.Text = "Gestion de Libros";
            this.btnLibros.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(244, 152);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(243, 139);
            this.btnUsuarios.TabIndex = 1;
            this.btnUsuarios.Text = "Gestion de Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.Location = new System.Drawing.Point(512, 152);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(203, 139);
            this.btnPrestamos.TabIndex = 2;
            this.btnPrestamos.Text = "Gestion de Prestamos";
            this.btnPrestamos.UseVisualStyleBackColor = true;
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 370);
            this.Controls.Add(this.btnPrestamos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnLibros);
            this.Name = "frmInicial";
            this.Text = "Biblioteca ";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLibros;
        private Button btnUsuarios;
        private Button btnPrestamos;
    }
}