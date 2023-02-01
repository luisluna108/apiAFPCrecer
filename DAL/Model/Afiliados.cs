using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Afiliados
    {
        [Key]
        public int IdAfiliado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Genero { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }

    }
}
