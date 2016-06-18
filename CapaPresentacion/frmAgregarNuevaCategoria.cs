using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregarNuevaCategoria : Form
    {
        private Categorias _owner;

        public frmAgregarNuevaCategoria()
        {
            InitializeComponent();
        }

        public frmAgregarNuevaCategoria(Categorias owner)
        {
            _owner = owner;
            InitializeComponent();
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
            String mensaje = NCategorias.Insertar(this.textBoxNombre.Text, this.textBoxDescripcion.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("La Categoría {0} ha sido AGREGADA", this.textBoxNombre.Text));
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