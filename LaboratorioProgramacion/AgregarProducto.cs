﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioProgramacion
{
    public partial class Agregar_producto : Form
    {
        public Agregar_producto()
        {
            InitializeComponent();
        }

        //Esto un procedimiento ya que no retorna un valor
        //Significado de private void:
        /////private: que solo se ejecuta en este formulario
        /////void: que esta vacio y no devuelve nada
        //El evento load refiere a las cosas que cargan apenas inicializamos el proyecto

        private void Agregar_producto_Load(object sender, EventArgs e)
        {
            //Crea una instancia de la clase ConexionBD, maneja la conexión a la base de datos y las operaciones de consulta.
            ConexionBD BD = new ConexionBD();
            //Llama al método listarProductos, llena dgvProductos con los productos de la base de datos
            BD.listarProductos(dgvProductos);

            //Llama al método LlenarcmbCategorias, carga el control cmbCategorias con las categorías de productos desde la base de datos
            BD.LlenarcmbCategorias(cmbCategorias);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Crea un nuevo objeto Productos para almacenar los datos del nuevo producto
            Productos nuevoProducto = new Productos();
            //Crea otra instancia de ConexionBD 
            ConexionBD conexion = new ConexionBD();

            // No asignar idProducto aquí, porque es autoincremental
            nuevoProducto.codigo = int.Parse(txtCodigo.Text);
            nuevoProducto.nombre = txtNombre.Text;
            nuevoProducto.categoria = cmbCategorias.Text;
            nuevoProducto.descripcion = txtDescripcion.Text;
            nuevoProducto.precio = double.Parse(txtPrecio.Text);
            nuevoProducto.stock = Convert.ToInt32(nupStock.Value);

            try
            {
                //Llama al método AgregarProducto para insertar nuevoProducto en la base de datos
                conexion.AgregarProducto(nuevoProducto);
                //Actualiza a dgvProductos para mostrar el producto recién agregado
                conexion.listarProductos(dgvProductos);
                //Llama a llenarListbox para agregar la descripción del producto en el lstDescripcion
                conexion.llenarListbox(lstDescripcion, nuevoProducto.nombre, nuevoProducto.descripcion, (double)nuevoProducto.precio, nuevoProducto.stock);
                //Llama al método Limpiar para borrar los campos de texto del formulario
                Limpiar();

            }//Atrapa cualquier excepción que pueda ocurrir y muestra un mensaje de error
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message);
            }
        }

        //Establece en vacío los campos txtCodigo, txtNombre, txtDescripcion, y txtPrecio
        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbCategorias.SelectedIndex = -1;
            nupStock.Value = 0;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modifica_Producto frmModificar = new Modifica_Producto();
            frmModificar.Show();
            this.Hide();

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Eliminar_Producto frmEliminar = new Eliminar_Producto();
            frmEliminar.Show();
            this.Hide();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte frmReportar = new Reporte();
            frmReportar.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }
    }
}
