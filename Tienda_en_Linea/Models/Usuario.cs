using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_en_Linea.Models
{
    [Table("usuario")]
    public class Usuario:BaseModels
    {
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
