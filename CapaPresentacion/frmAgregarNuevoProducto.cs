using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregarNuevoProducto : Form
    {
        private Productos _owner;

        public frmAgregarNuevoProducto()
        {
            InitializeComponent();
        }

        public frmAgregarNuevoProducto(Productos owner)
        {
            _owner = owner;
            InitializeComponent();

            try
            {
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        public void CargarCategorias()
        {
            this.comboBoxCategoria.DataSource = NCategorias.ListaCategorias();
            this.comboBoxCategoria.ValueMember = "ID";
            this.comboBoxCategoria.DisplayMember = "NOMBRE";
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
            try
            {
                if (String.IsNullOrWhiteSpace(this.textBoxNombreProducto.Text) || String.IsNullOrWhiteSpace(this.comboBoxCategoria.Text))
                {
                    MensajeError("Los campos Nombre de Producto y Categoría son obligatorios");
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(this.textBoxPrecioUnitario.Text))
                    {
                        this.textBoxPrecioUnitario.Text = "0";
                    }

                    String mensaje = NProductos.Insertar(this.textBoxNombreProducto.Text, this.comboBoxCategoria.Text,
                    Convert.ToDecimal(this.textBoxPrecioUnitario.Text), this.textBoxDetalles.Text);

                    if (mensaje == "Y")
                    {
                        this._owner.Mensaje(String.Format("El Producto {0} ha sido AGREGADO", this.textBoxNombreProducto.Text));
                        this._owner.Refrescar();
                        this.Close();
                    }
                    else
                    {
                        MensajeError(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError("Los valores ingresados son incorrectos. " + ex.Message);
            }
        }

        private void textBoxPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8 && e.KeyChar != ','))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBoxUnidadesStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}