using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ERP
{
    public class InventariosBL
    {
        Contexto _contexto;
        public BindingList<Inventario> ListaInventarios { get; set; }

        public InventariosBL()
        {
            _contexto = new Contexto();
            ListaInventarios = new BindingList<Inventario>();


        }

        public BindingList<Inventario> ObtenerProductos()
        {
            _contexto.Productos.Load();
            ListaInventarios = _contexto.Productos.Local.ToBindingList();
            return ListaInventarios;
        }


        public Resultado GuardarProducto(Inventario producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;

            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Inventario();
            ListaInventarios.Add(nuevoProducto);
        }

        public bool EliminarProducto(int id)
        {
            foreach (var item in ListaInventarios)
            {
                if (item.Id == id)
                {
                    ListaInventarios.Remove(item);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Inventario producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }

            if (producto.Existencia < 0)
            {
                resultado.Mensaje = "La existencia es menor que cero";
                resultado.Exitoso = false;
            }

            if (producto.Precio <= 0)
            {
                resultado.Mensaje = "El precio no puede ser menor o igual que cero";
                resultado.Exitoso = false;
            }

/*
            if (producto.CategoriaID == 0)
            {
                resultado.Mensaje = "Seleccione una categoria";
                resultado.Exitoso = false;
            }

            if (producto.TipoId == 0)
            {
                resultado.Mensaje = "Seleccione un tipo";
                resultado.Exitoso = false;
            }
            */
            return resultado;
        }
        
    }

    public class Inventario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
    }

 /*     public Inventario()
       {
           Activo = true;
       }
   */ 
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}