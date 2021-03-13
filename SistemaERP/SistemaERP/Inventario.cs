using BL.ERP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP
{
    public partial class Inventario : Form
    {
        InventariosBL _productos;
        CategoriaBL _categorias;
        TiposBL _tipos;
        public Inventario()
        {
            InitializeComponent();
            _productos = new InventariosBL();
            listaInventariosBindingSource.DataSource = _productos.ObtenerProductos();
            _categorias = new CategoriaBL();
            listaCategoriasBindingSource.DataSource = _categorias.ObtenerCategorias();
            _tipos = new TiposBL();
            listaTiposBindingSource.DataSource = _tipos.ObtenerTipos();
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










        private void Inventario2_Load(object sender, EventArgs e)
        {

        }


        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaInventariosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
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

        private void listaInventariosBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            listaInventariosBindingSource.EndEdit();

            var producto = (BL.ERP.Inventario)listaInventariosBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                producto.Foto = null;
            }


            var resultado = _productos.GuardarProducto(producto);
            if (resultado.Exitoso == true)
            {
                listaInventariosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Producto Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void cancelar_Click_1(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var producto = (BL.ERP.Inventario)listaInventariosBindingSource.Current;
            if (producto != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileinfo = new FileInfo(archivo);
                    var fileStream = fileinfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show("Cree un producto antes de asignarle una imagen");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void listaInventariosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
