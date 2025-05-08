using System;
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
    public partial class Eliminar_Producto : Form
    {
        public Eliminar_Producto()
        {
            InitializeComponent();
        }

        private void Eliminar_Producto_Load(object sender, EventArgs e)
        {
            //Crea una nueva instancia de la clase ConexionBD, que maneja la conexión a la base de datos
            ConexionBD BD = new ConexionBD();
            //Llama al método listarProductos de la clase ConexionBD para llenar el DataGridView (dgvProductos)
            //con la lista actual de productos desde la base de datos
            BD.listarProductos(dgvProductos);
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Agregar_producto
            Agregar_producto frm = new Agregar_producto();
            //Muestra el formulario de manera modal,
            //lo que significa que el usuario debe cerrar este formulario antes de regresar a la ventana principal
            frm.Show();
            this.Hide();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Modifica_producto
            Modifica_Producto frm = new Modifica_Producto();
            //Muestra el formulario de manera modal, permitiendo al usuario modificar un producto existente
            frm.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya ingresado un ID válido
            int idProducto;
            //Intenta convertir el texto ingresado en txtCodigo a un entero.
            //Si falla, muestra un mensaje indicando que el ID no es válido y retorna
            if (!int.TryParse(txtCodigo.Text, out idProducto))
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.");
                return;
            }

            //Crea una nueva instancia de ConexionBD
            ConexionBD conexion = new ConexionBD();

            try
            {
                //Llama al método EliminarProducto de ConexionBD para eliminar el producto con el ID especificado
                conexion.EliminarProducto(idProducto);
                conexion.listarProductos(dgvProductos);  // Actualizar la lista de productos
                Limpiar();  // Limpiar los campos del formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
        }
        public void Limpiar()
        {
            //Establece el texto del TextBox txtCodigo a una cadena vacía, eliminando cualquier texto que contenga
            txtCodigo.Text = "";

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
