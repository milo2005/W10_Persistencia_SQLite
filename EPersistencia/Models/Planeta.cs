using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPersistencia.Models
{
    public class Planeta
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public float Tamanio { get; set; }
        public float Gravedad { get; set; }
    }
}
