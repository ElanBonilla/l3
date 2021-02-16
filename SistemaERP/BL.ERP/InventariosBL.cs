using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ERP
{
    public class InventariosBL
    {
        public BindingList<Inventario> ListaInventarios { get; set; }

        public InventariosBL()
        {
            ListaInventarios = new BindingList<Inventario>();

            var producto1 = new Inventario();
            producto1.Id = 1;
            producto1.Descripcion = "IphoneX";
            producto1.Precio = 25000;
            producto1.Existencia = 15;
            producto1.Activo = true;


            var producto2 = new Inventario();
            producto2.Id = 2;
            producto2.Descripcion = "Samsung S9";
            producto2.Precio = 20000;
            producto2.Existencia = 8;
            producto2.Activo = true;


            var producto3 = new Inventario();
            producto3.Id = 3;
            producto3.Descripcion = "LGE7";
            producto3.Precio = 12000;
            producto3.Existencia = 17;
            producto3.Activo = true;


            ListaInventarios.Add(producto1);
            ListaInventarios.Add(producto2);
            ListaInventarios.Add(producto3);
        }
        
        public BindingList<Inventario> ObtenerProductos()
        {
            return ListaInventarios;
        }

    }

    public class Inventario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
