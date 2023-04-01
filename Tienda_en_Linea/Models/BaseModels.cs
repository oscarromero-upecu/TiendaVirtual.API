using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_en_Linea.Models
{
    public abstract class BaseModels
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
