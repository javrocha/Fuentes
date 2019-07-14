using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Controlador
{
    public class clsDespacho
    {
        public string strOperacion { get; set; }
        public string strOrden { get; set; }
        public int    intProducto{ get; set; }
        public int    intzona { get; set; }
        public int    intLote { get; set; }
        public int    intPallet { get; set; }
        public int    intCantidad{ get; set; }
    }
}
