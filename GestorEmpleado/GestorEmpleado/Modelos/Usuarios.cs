using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleado.Modelos
{
    public class Usuarios
    {
        public int IdUsusario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public byte[] Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
