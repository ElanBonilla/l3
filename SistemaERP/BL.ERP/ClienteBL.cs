using System.ComponentModel;
using System.Data.Entity;

namespace BL.ERP
{
    public class ClienteBL
    {
        Contexto _contexto;
        public BindingList<Cliente> ListaClientes { get; set; }

        public ClienteBL ()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();

            return ListaClientes;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
    }
}