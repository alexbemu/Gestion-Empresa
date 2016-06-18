using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEditarTransporte : Form
    {
        private Transporte _owner;
        private int Id_Transportista;

        public frmEditarTransporte()
        {
            InitializeComponent();
        }

        public frmEditarTransporte(Transporte owner)
        {
            _owner = owner;
            InitializeComponent();

            this.Id_Transportista = Convert.ToInt32(_owner.ObtenerSeleccion().Cells["ID"].Value);
            this.textBoxNombre.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["NOMBRE"].Value);
            this.textBoxDireccion.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["DIRECCIÓN"].Value);
            this.textBoxCiudad.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["CIUDAD"].Value);
            this.textBoxRegion.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["REGIÓN"].Value);
            this.textBoxPais.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["PAÍS"].Value);
            this.textBoxTelefono.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["TELÉFONO"].Value);
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
        {//No importa el try ya que no hay conversiones
            String mensaje = NTransportistas.Editar(this.Id_Transportista, this.textBoxNombre.Text, this.textBoxDireccion.Text,
                this.textBoxCiudad.Text, this.textBoxRegion.Text, this.textBoxPais.Text, this.textBoxTelefono.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("El Transporte {0} ha sido EDITADO", this.textBoxNombre.Text));
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