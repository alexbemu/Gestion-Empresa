using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEditarCliente : Form
    {
        private Clientes _owner;
        private int Id_Cliente;

        public frmEditarCliente()
        {
            InitializeComponent();
        }

        public frmEditarCliente(Clientes owner)
        {
            _owner = owner;
            InitializeComponent();

            this.Id_Cliente = Convert.ToInt32(_owner.ObtenerSeleccion().Cells["ID"].Value);
            this.textBoxNombreCliente.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["CLIENTE"].Value);
            this.textBoxNombreContacto.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["CONTACTO"].Value);
            this.textBoxDireccion.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["DIRECCIÓN"].Value);
            this.textBoxCiudad.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["CIUDAD"].Value);
            this.textBoxRegion.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["REGIÓN"].Value);
            this.textBoxPais.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["PAÍS"].Value);
            this.textBoxTelefono.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["TELÉFONO"].Value);
            this.textBoxFax.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["FAX"].Value);
            this.textBoxEmail.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["EMAIL"].Value);
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
            String mensaje = NClientes.Editar(this.Id_Cliente, this.textBoxNombreCliente.Text, this.textBoxNombreContacto.Text,
                this.textBoxDireccion.Text, this.textBoxCiudad.Text, this.textBoxRegion.Text, this.textBoxPais.Text,
                this.textBoxTelefono.Text, this.textBoxFax.Text, this.textBoxEmail.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("El Cliente {0} ha sido EDITADO", this.textBoxNombreCliente.Text));
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