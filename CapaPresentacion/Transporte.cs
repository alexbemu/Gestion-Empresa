﻿using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Transporte : UserControl
    {
        private int numeroPagina = 1;
        private int registrosPorPagina = 25;
        private int cantidadPaginas;

        public Transporte()
        {
            InitializeComponent();
            Mostrar();
        }

        public void Mostrar()
        {
            try
            {
                this.Dock = DockStyle.Fill;
                this.dataGridViewTransporte.DataSource = NTransportistas.Mostrar(numeroPagina, registrosPorPagina);
                this.dataGridViewTransporte.Columns[0].Visible = false;
                cantidadPaginas = NTransportistas.Tamaño(registrosPorPagina);
                this.labelPagina.Text = String.Format("Página {0} de {1}", numeroPagina, cantidadPaginas);
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        public void Buscar()
        {
            try
            {
                this.dataGridViewTransporte.DataSource = NTransportistas.Buscar(this.textBoxBuscarNombre.Text);
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        public void Refrescar()
        {
            this.numeroPagina = 1;
            this.Mostrar();
            this.textBoxBuscarNombre.Text = String.Empty;
        }

        public void Mensaje(String mensaje)
        {
            this.labelMensajes.Text = mensaje;
        }

        public void LimpiarMensaje()
        {
            this.labelMensajes.Text = String.Empty;
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DataGridViewRow ObtenerSeleccion()
        {
            DataGridViewRow filaSeleccionada = this.dataGridViewTransporte.Rows[this.dataGridViewTransporte.CurrentRow.Index];
            return filaSeleccionada;
        }

        private void textBoxBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxBuscarNombre.Text == String.Empty)
            {
                this.numeroPagina = 1;
                this.Mostrar();
                this.tableLayoutPanelPaginacion.Show();
            }
            else
            {
                this.Buscar();
                this.tableLayoutPanelPaginacion.Hide();
            }
        }

        private void buttonRefrescar_Click(object sender, EventArgs e)
        {
            this.Refrescar();
            this.LimpiarMensaje();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewTransporte.Rows.Count > 0)
                {
                    frmEditarTransporte editarTransporte = new frmEditarTransporte(this);
                    editarTransporte.ShowDialog();
                }
                else
                {
                    MensajeError("Debes seleccionar una fila para editar");
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewTransporte.Rows.Count > 0)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Seguro deseas eliminar este transportista?", "Eliminar Transportista",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (confirmacion == DialogResult.OK)
                    {
                        String mensaje = NTransportistas.Eliminar(Convert.ToInt32(ObtenerSeleccion().Cells["ID"].Value));
                        if (mensaje == "Y")
                        {
                            Mensaje(String.Format("El Transportista {0} ha sido ELIMINADO",
                                Convert.ToString(ObtenerSeleccion().Cells["NOMBRE"].Value)));
                            Refrescar();
                        }
                        else
                        {
                            MensajeError(mensaje);
                            Refrescar();
                        }
                    }
                }
                else
                {
                    MensajeError("Debes seleccionar una fila para eliminar");
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarNuevoTransporte nuevoTransporte = new frmAgregarNuevoTransporte(this);
            nuevoTransporte.ShowDialog();
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            if (numeroPagina > 1)
            {
                numeroPagina = numeroPagina - 1;
                Mostrar();
            }
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            if (numeroPagina < cantidadPaginas)
            {
                numeroPagina = numeroPagina + 1;
                Mostrar();
            }
        }
    }
}