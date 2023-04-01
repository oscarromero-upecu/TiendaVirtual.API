using SQLite;

namespace Tienda_en_Linea.Models
{
    [Table("producto")]
    public class Producto : BaseModels
    {
        public string NombreProducto { get; set; }
        [MaxLength(2)]
        public string Marca { get; set; }
        public string Precio { get; set; }
        public string Foto { get; set; }
    }
}
