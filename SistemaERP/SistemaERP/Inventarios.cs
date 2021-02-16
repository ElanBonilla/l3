using BL.ERP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP
{
    public partial class Inventarios : Form
    {
        InventariosBL _productos;
        public Inventarios()
        {
            InitializeComponent();
            _productos = new InventariosBL();
            listaInventariosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        private void listaInventariosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
