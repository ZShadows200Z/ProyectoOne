using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleado.Modelos
{
    public class MotivoExoneraciones
    {
        public int IdMotivoExoneracion { get; set; }
        public string Motivo { get; set; }
        public bool Activo { get; set; }
    }
}
