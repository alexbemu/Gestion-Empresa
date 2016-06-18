using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregarNuevoEmpleado : Form
    {
        private Empleados _owner;

        public frmAgregarNuevoEmpleado()
        {
            InitializeComponent();
        }

        public frmAgregarNuevoEmpleado(Empleados owner)
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
            String mensaje = NEmpleados.Insertar(this.textBoxNombre.Text, this.textBoxApellido.Text, this.textBoxDireccion.Text,
                this.textBoxCiudad.Text, this.textBoxRegion.Text, this.textBoxPais.Text, this.textBoxTelefono.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("El Empleado {0}, {1} ha sido AGREGADO",
                    this.textBoxApellido.Text,
                    this.textBoxNombre.Text));
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