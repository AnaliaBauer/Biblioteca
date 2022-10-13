namespace Biblioteca.Frontend
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            var libros = new frmLibros();
            libros.Owner = this;
            libros.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var usuarios = new frmClientes();
            usuarios.Owner = this;
            usuarios.Show();
            this.Hide();
        }

       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Dispose();
            this.Close();
        }
    }
}