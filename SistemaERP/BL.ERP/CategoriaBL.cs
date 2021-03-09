using System.ComponentModel;
using System.Data.Entity;

namespace BL.ERP
{
    public class CategoriaBL
    {
        Contexto _contexto;
        public BindingList<Categoria> ListaCategorias { get; set; }

        public CategoriaBL()
        {
            _contexto = new Contexto();
            ListaCategorias = new BindingList<Categoria>();
        }

        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();
            ListaCategorias = _contexto.Categorias.Local.ToBindingList();

            return ListaCategorias;
        }

    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}