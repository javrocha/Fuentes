using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Controlador
{
    public class clsUsuario
    {
        public string strOperacion { get; set; }
        public long lonDocumento { get; set; }
        public string strNombre { get; set; }
        public string strLogin { get; set; }
        public string strPassword { get; set; }
        public int intRol { get; set; }
    }
}
