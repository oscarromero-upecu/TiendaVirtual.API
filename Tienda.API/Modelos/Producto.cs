using System.ComponentModel.DataAnnotations;

namespace Tienda.API.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Precio { get; set; }
        public string Foto { get; set; }
    }
}
