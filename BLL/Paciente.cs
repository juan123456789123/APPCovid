using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Paciente
    {
        public string cedula { get; set; }
        public string  nombreCompleto { get; set; }
        public string provincia { get; set; }
        public char sexo { get; set; }
        public string usuario { get; set; }
        public int edad { get; set; }

    }
}
