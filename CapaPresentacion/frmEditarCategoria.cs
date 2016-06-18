using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEditarCategoria : Form
    {
        private Categorias _owner;
        private int Id_Categoria;

        public frmEditarCategoria()
        {
            InitializeComponent();
        }

        public frmEditarCategoria(Categorias owner)
        {
            _owner = owner;
            InitializeComponent();

            this.Id_Categoria = Convert.ToInt32(_owner.ObtenerSeleccion().Cells["ID"].Value);
            this.textBoxNombre.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["NOMBRE"].Value);
            this.textBoxDescripcion.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["DESCRIPCIÓN"].Value);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String mensaje = NCategorias.Editar(this.Id_Categoria, this.textBoxNombre.Text, this.textBoxDescripcion.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("La Categoría {0} ha sido EDITADA", this.textBoxNombre.Text));
                this._owner.Refrescar();
                this.Close();
            }
            else
            {
                MensajeError(mensaje);
            }
        }
    }
}