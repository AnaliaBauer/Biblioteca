using Biblioteca.Backend.Modelos;
using Biblioteca.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Frontend
{

    public partial class frmLibros : Form
    {
        Acciones acciones;
        public frmLibros()
        {
            InitializeComponent();
            acciones = new Acciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCódigo.Text))
            {
                Libro libro = acciones.BuscarLibro(txtCódigo.Text);


                if (!string.IsNullOrEmpty(txtTitulo.Text) && !string.IsNullOrEmpty(txtAutor.Text) && !string.IsNullOrEmpty(txtEditorial.Text) && !string.IsNullOrEmpty(txtAño.Text))
                {

                    if (libro != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Libro ya existente. Desea modificar los datos?", "Atencion", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {



                            libro.Titulo = txtTitulo.Text;
                            libro.Autor = txtAutor.Text;
                            libro.Editorial = txtEditorial.Text;
                            libro.Año = Convert.ToInt32(txtAño.Text);

                            bool respuesta = acciones.ModificarLibro(libro);

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
                        libro = new Libro();
                        libro.Código = txtCódigo.Text;
                        libro.Titulo = txtTitulo.Text;
                        libro.Autor = txtAutor.Text;
                        libro.Editorial = txtEditorial.Text;
                        libro.Año = Convert.ToInt32(txtAño.Text);

                        acciones.AgregarLibro(libro);
                        LimpiarCampos();

                    }
                }

            }
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
            this.Close();
        }

        private void frmLibros_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.Owner != null)
                this.Owner.Show();

        }

        private void frmLibros_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvLibros.Rows.Clear();
            dgvLibros.DataSource = acciones.DTLibros;
            dgvLibros.Update();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool respuesta = acciones.BorrarLibro(txtCódigo.Text);

            if (respuesta)
            {
                LimpiarCampos();
                txtCódigo.Focus();
                MessageBox.Show("El registro se elimino correctamente", "Gestion de Libros", MessageBoxButtons.OK);
            }
            else
            {
                txtCódigo.Focus();
                txtCódigo.SelectAll();
            }

        }

        private void LimpiarCampos()
        {

            txtCódigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtAño.Text = "";

            txtCódigo.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtAño.Text = "";

            if (!string.IsNullOrEmpty(txtCódigo.Text))
            {

                Libro libro = new Libro();

                libro = acciones.BuscarLibro(txtCódigo.Text);

                if (libro != null)
                {
                    txtCódigo.Text = libro.Código;
                    txtTitulo.Text = libro.Titulo;
                    txtAutor.Text = libro.Autor;
                    txtEditorial.Text = libro.Editorial;
                    txtAño.Text = libro.Año.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos", "Error", MessageBoxButtons.OK);
                }

                txtCódigo.Focus();
                txtCódigo.SelectAll();
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvLibros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCódigo.Text = dgvLibros.CurrentRow.Cells[0].Value.ToString();
            txtTitulo.Text = dgvLibros.CurrentRow.Cells[1].Value.ToString();
            txtAutor.Text = dgvLibros.CurrentRow.Cells[2].Value.ToString();
            txtEditorial.Text = dgvLibros.CurrentRow.Cells[3].Value.ToString();
            txtAño.Text = dgvLibros.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
