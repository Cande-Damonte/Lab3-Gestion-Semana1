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
    public partial class Modifica_Producto : Form
    {
        public Modifica_Producto()
        {
            InitializeComponent();
        }

        private void Modifica_Producto_Load(object sender, EventArgs e)
        {
            //Crea una nueva instancia de la clase ConexionBD,
            //que maneja las operaciones relacionadas con la base de datos (como la conexión y las consultas).
            // Al instanciar conexion, se establece una conexión a la base de datos a través
            // de la cadena de conexión definida en el constructor de ConexionBD.
            ConexionBD conexion = new ConexionBD();
            conexion.listarProductos(dgvProductos1);

            conexion.LlenarcmbCategorias(cmbCategorias);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia de la clase Productos llamada productoModificado,
            //que se usará para almacenar los datos del producto que se va a modificar.
            Productos productoModificado = new Productos();
            //Crea una nueva instancia de la clase ConexionBD para manejar la conexión a la base de datos y
            //realizar operaciones relacionadas con los productos.
            ConexionBD conexion = new ConexionBD();

            // Obtener el ID del producto a modificar (suponiendo que está en txtCodigo)
            int codigo;
            //Intenta convertir el texto ingresado en el cuadro de texto txtCodigo a un entero.Si no funciona marca un mensaje detallando el error
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.");
                return;
            }

            //Asigna el ID del producto que se va a modificar a la propiedad codigo del objeto productoModificado
            productoModificado.codigo = codigo;
            //Asigna el nombre del producto ingresado en txtNombre a la propiedad nombre de productoModificado
            productoModificado.nombre = txtNombre.Text;
            //Asigna la descripción del producto ingresada en txtDescripcion a la propiedad descripcion de productoModificado
            productoModificado.descripcion = txtDescripcion.Text;
            //Convierte el texto del cuadro de texto txtPrecio a un tipo double para que pueda ser decimal y lo asigna a la propiedad precio de productoModificado
            productoModificado.precio = double.Parse(txtPrecio.Text);
            productoModificado.stock = (int)nupStock.Value;


            try
            {
                //Llama al método ModificarProductos de la clase ConexionBD,
                //pasando el objeto productoModificado como parámetro para actualizar los datos en la base de datos
                conexion.ModificarProductos(productoModificado);
                //Actualiza el dgvProductos con la lista actualizada de productos después de la modificación
                conexion.listarProductos(dgvProductos1);
                //Llama al método llenarListbox para agregar el producto modificado a un lstDescripcion con su nombre, descripción, precio y stock
                conexion.llenarListbox(lstDescripcion, productoModificado.nombre, productoModificado.descripcion, (double)productoModificado.precio, (int)productoModificado.stock);
                //Llama al método Limpiar para borrar los campos del formulario
                Limpiar();

            }//Captura cualquier excepción que se produzca en el bloque try y
             //muestra un mensaje de error al usuario con el contenido de la excepción
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message);
            }
        }
        public void Limpiar()
        {
            //Establece el texto del cuadro de texto txtCodigo como una cadena vacía, lo que limpia el campo
            txtCodigo.Text = "";
            //Limpia el campo de texto txtNombre
            txtNombre.Text = "";
            //Limpia el campo de texto txtDescripcion
            txtDescripcion.Text = "";
            //Limpia el campo de texto txtPrecio
            txtPrecio.Text = "";
            cmbCategorias.SelectedIndex = -1;
            nupStock.Value = 0;

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Agregar_producto, que permite al usuario ingresar los detalles de un nuevo producto
            Agregar_producto frm = new Agregar_producto();
            //Muestra el formulario Agregar_producto como un cuadro de diálogo modal.
            //Esto significa que el usuario debe interactuar con este formulario antes de volver a la interfaz anterior.
            frm.Show();
            this.Hide();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Eliminar_Producto, que permite al usuario eliminar un producto existente
            Eliminar_Producto frm = new Eliminar_Producto();
            //Muestra el formulario Eliminar_Producto como un cuadro de diálogo modal
            frm.Show();
            this.Hide();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Reporte, que permite al usuario ver o generar reportes de productos
            Reporte frm = new Reporte();
            //Muestra el formulario Reporte como un cuadro de diálogo modal
            frm.Show();
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
