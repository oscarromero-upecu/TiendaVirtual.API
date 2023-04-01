using SQLite;
using Tienda_en_Linea.Models;


namespace Tienda_en_Linea.Services
{
    public class ProductService
    {
        private SQLiteConnection _conn;

        private readonly string _pathDb;

        public string MensajeEstado { get;private set; }

        public ProductService(string pathDb)
        {
            _pathDb = pathDb;
        }

        private void InicizlizarDB()
        {
            if(_conn!=null)  return;

            _conn = new SQLiteConnection(_pathDb);
            _conn.CreateTable<Producto>();
        }
        public List<Producto> ObtenrPorductos()
        {
            try
            {
                InicizlizarDB();
                return _conn.Table<Producto>().ToList();
            }
            catch (Exception)
            {
                MensajeEstado = "No se obtuvo los datos del producto";
            }
            return null;
        }

        public void AgregarProducto(Producto producto) 
        {
            try
            {
                InicizlizarDB();

                if (producto == null) throw new Exception("Producto no valido");

                var resultado = _conn.Insert(producto);
                MensajeEstado = resultado == 0 ? "Ingreso fallido" : "Ingreso exitoso";
            }
            catch (Exception)
            {
                MensajeEstado = "No se pudo agregar el producto";
            }
        }

        internal void EliminarProducto(int id)
        {
            try
            {
                InicizlizarDB();

                if (id == 0) throw new Exception("Producto no valido");

                var resultado = _conn.Delete(ObtenrPorducto(id));
                MensajeEstado = resultado == 0 ? "La operacion fallo" : "Elimando";
            }
            catch (Exception)
            {
                MensajeEstado = "No se pudo eliminar el producto";
            }
        }

        public Producto ObtenrPorducto(int id)
        {
            try
            {
                InicizlizarDB();
                return _conn.Table<Producto>().FirstOrDefault(producto => producto.Id == id);
            }
            catch (Exception)
            {
                MensajeEstado = "No se obtuvo los datos del producto";
            }
            return null;
        }
        public void EditarProducto(Producto nuevoauto)
        {
            try
            {
                if (nuevoauto == null) throw new Exception("Auto no valido");

                var resultado = _conn.Update(nuevoauto);

                MensajeEstado = resultado == 0 ? "La operacion fallo" : "producto editado";

            }
            catch (Exception)
            {

                MensajeEstado = "No se ha pudido editar el producto";
            }

        }

    }
}
