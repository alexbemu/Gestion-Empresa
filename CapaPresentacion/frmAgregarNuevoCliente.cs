using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregarNuevoCliente : Form
    {
        private Clientes _owner;

        public frmAgregarNuevoCliente()
        {
            InitializeComponent();
        }

        public frmAgregarNuevoCliente(Clientes owner)
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
            String mensaje = NClientes.Insertar(this.textBoxNombreCliente.Text, this.textBoxNombreContacto.Text, this.textBoxDireccion.Text,
                this.textBoxCiudad.Text, this.textBoxRegion.Text, this.textBoxPais.Text, this.textBoxTelefono.Text,
                this.textBoxFax.Text, this.textBoxEmail.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("El Cliente {0} ha sido AGREGADO",
                    this.textBoxNombreCliente.Text));
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