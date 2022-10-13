using Biblioteca.Backend;
using Biblioteca.Backend.Modelos;

namespace Biblioteca.Frontend
{
    public partial class frmClientes : Form
    {
        Acciones acciones;
        public frmClientes()
        {
            InitializeComponent();
            acciones = new Acciones();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                Persona persona = acciones.BuscarPersona(txtDNI.Text);

                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtTelefono.Text))
                {
                    if (persona != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Cliente ya existente. Desea modificar los datos?", "Atencion", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            persona.Nombre = txtNombre.Text;
                            persona.Apellido = txtApellido.Text;
                            persona.Telefono = txtTelefono.Text;

                            bool respuesta = acciones.ModificarPersona(persona);
                            if (respuesta)
                            {
                                MessageBox.Show("Los datos se guardaron correctamente");
                                LimpiarCampos();

                            }
                            else
                            {
                                MessageBox.Show("Los datos no se guardaron :(");
                            }

                        }
                    }

                    else
                    {
                        persona = new Persona();
                        persona.DNI = txtDNI.Text;
                        persona.Nombre = txtNombre.Text;
                        persona.Apellido = txtApellido.Text;
                        persona.Telefono = txtTelefono.Text;

                        acciones.AgregarCliente(persona);

                        LimpiarCampos();
                    }



                }
                //



                //
            }
        }

        private void LimpiarCampos()
        {

            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDNI.Focus();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvClientes.Rows.Clear();
            dgvClientes.DataSource = acciones.DTClientes;
            dgvClientes.Update();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
            this.Close();
        }

        private void frmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool resultado = acciones.BorrarPersona(txtDNI.Text);

            if (resultado)
            {
                LimpiarCampos();
                txtDNI.Focus();
                MessageBox.Show("El registro se elimino correctamente", "Gestion de Usuarios", MessageBoxButtons.OK);

            }
            else
            {
                txtDNI.Focus();
                txtDNI.SelectAll();
            }


        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";

            if (!string.IsNullOrEmpty(txtDNI.Text))
            {

                Persona persona = new Persona();

                persona = acciones.BuscarPersona(txtDNI.Text);
                if (persona != null)
                {
                    txtDNI.Text = persona.DNI;
                    txtNombre.Text = persona.Nombre;
                    txtApellido.Text = persona.Apellido;
                    txtTelefono.Text = persona.Telefono;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos", "Error", MessageBoxButtons.OK);
                }

                txtDNI.Focus();
                txtDNI.SelectAll();
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
