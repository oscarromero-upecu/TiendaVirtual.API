using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_en_Linea.Models.DTO
{
    public class RespuestaAutenticacion
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
