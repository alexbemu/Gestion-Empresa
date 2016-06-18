using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEditarEmpleado : Form
    {
        private Empleados _owner;
        private int Id_Empleado;

        public frmEditarEmpleado()
        {
            InitializeComponent();
        }

        public frmEditarEmpleado(Empleados owner)
        {
            _owner = owner;
            InitializeComponent();

            this.Id_Empleado = Convert.ToInt32(_owner.ObtenerSeleccion().Cells["ID"].Value);
            this.textBoxNombre.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["NOMBRE"].Value);
            this.textBoxApellido.Text = Convert.ToString(_owner.ObtenerSeleccion().Cells["APELLIDO"].Value);
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
        {
            String mensaje = NEmpleados.Editar(this.Id_Empleado, this.textBoxNombre.Text, this.textBoxApellido.Text, this.textBoxDireccion.Text,
                this.textBoxCiudad.Text, this.textBoxRegion.Text, this.textBoxPais.Text, this.textBoxTelefono.Text);

            if (mensaje == "Y")
            {
                this._owner.Mensaje(String.Format("El Empleado {0}, {1} ha sido EDITADO",
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