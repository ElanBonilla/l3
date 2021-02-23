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

        private void listaInventariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaInventariosBindingSource.EndEdit();

            var producto = (Inventario)listaInventariosBindingSource.Current;

            var resultado = _productos.GuardarProducto(producto);
            if(resultado.Exitoso == true )
            {
                listaInventariosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaInventariosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);


        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            cancelar.Visible = !valor;
        }

        private void Inventarios_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (idTextBox.Text != "")
                {
                var resultado = MessageBox.Show("Desea eliminar este producto?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                }
      
        }

        private void Eliminar(int id)
        {
            
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listaInventariosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar producto");
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
