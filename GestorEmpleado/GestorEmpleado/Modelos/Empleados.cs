using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleado.Modelos
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaExoneracion { get; set; }
        public int IdMotivoExoneracion { get; set; }
        public int IdTipoContratacion { get; set; }
        public int IdSucursal { get; set; } 
        public int IdCargo { get; set; }
        public bool Activo { get; set; }
    }
}
