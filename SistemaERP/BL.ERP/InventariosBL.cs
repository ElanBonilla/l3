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


        public Resultado GuardarProducto(Inventario producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;

            }

            if (producto.Id==0)
            {
                producto.Id = ListaInventarios.Max(item => item.Id) + 1;      
            }

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Inventario();
            ListaInventarios.Add(nuevoProducto);
        }

        public bool EliminarProducto (int id)
        {
            foreach (var item in ListaInventarios)
            {
                if (item.Id == id)
                {
                    ListaInventarios.Remove(item);
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Inventario producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty (producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }

            if (producto.Existencia <0)
            {
                resultado.Mensaje = "La existencia es menor que cero";
                resultado.Exitoso = false;
            }

            if (producto.Precio <=0)
            {
                resultado.Mensaje = "El precio no puede ser menor o igual que cero";
                resultado.Exitoso = false;
            }

            return resultado;
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

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
