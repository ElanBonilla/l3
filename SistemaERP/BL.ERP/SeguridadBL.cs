using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ERP
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario, string contrasena)
        {
            if (usuario == "admin" && contrasena == "12345")
            {
                return true;
            }
            else if (usuario == "invitado" && contrasena == "000000")
            {
                return true;
            }
            
                return false;
            }
    }
}
