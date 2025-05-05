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
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre un formulario para buscar un producto.
            BuscarProducto frm = new BuscarProducto();
            frm.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre un formulario para agregar un nuevo producto
            Agregar_producto frm = new Agregar_producto();
            frm.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre un formulario para modificar un producto existente
            Modifica_Producto frm = new Modifica_Producto();
            frm.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre un formulario para eliminar un producto
            Eliminar_Producto frm = new Eliminar_Producto();
            frm.ShowDialog();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            ConexionBD BD = new ConexionBD();
            BD.CargarProductosBajoStock(lstControl);
        }
    }
}
