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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Buscar_Producto
            BuscarProducto frm = new BuscarProducto();
            //Muestra el formulario de manera modal, permitiendo al usuario buscar un producto específico
            frm.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Agregar_producto
            Agregar_producto frm = new Agregar_producto();
            //Muestra el formulario de manera modal, permitiendo al usuario agregar un nuevo producto a la base de datos
            frm.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Modifica_producto
            Modifica_Producto frm = new Modifica_Producto();
            //Muestra el formulario de manera modal, permitiendo al usuario modificar un producto existente
            frm.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Eliminar_Producto
            Eliminar_Producto fr = new Eliminar_Producto();
            //Muestra el formulario de manera modal, permitiendo al usuario eliminar un producto específico
            fr.ShowDialog();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea una nueva instancia del formulario Reporte
            Reporte frm = new Reporte();
            //Muestra el formulario de manera modal,
            //lo que significa que el usuario debe interactuar con este formulario antes de poder regresar a la ventana principal
            frm.ShowDialog();
        }
    }
}
