using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Web;
using Tienda_en_Linea.Models;
using Tienda_en_Linea.Services;
using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Admin;
using Tienda_en_Linea.Views.User;

namespace Tienda_en_Linea.ViewModels.ModeloProductos
{
    //qpar recibir un valor con el queryProperty y recibe 2 parametros
    //1 el nombre de donde viene 2 el id de la propiedad
    [QueryProperty("Identificador", "Id")]
    public partial class DetalleProductoViewModel : BaseViewModels, IQueryAttributable
    {
        [ObservableProperty]
        Producto articulo;
        [ObservableProperty]
        int identificador;

        [ObservableProperty]
        bool estaHabiltado;
        [ObservableProperty]
        int carrito;

        [ObservableProperty]
        string nombreProducto;
        [ObservableProperty]
        string marca;
        [ObservableProperty]
        string precio;
        [ObservableProperty]
        string foto;

        private readonly ProductoApiService _productoApiService;

        public DetalleProductoViewModel(ProductoApiService productoApiService)
        {
            Titulo = "Detalle de Producto";

            _productoApiService = productoApiService;

        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Identificador = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));

            Articulo = await _productoApiService.ObtenrPorducto(Identificador);
        }

        [RelayCommand]
        async Task EditarProducto(int id)
        {
            if (id == 0 || (string.IsNullOrEmpty(Marca) || string.IsNullOrEmpty(Precio) || string.IsNullOrEmpty(NombreProducto)))
            {
                await Shell.Current.DisplayAlert("Error", "El producto no tiende datos para editar", "ok");
                return;
            }

            Articulo = new Producto
            {
                Id = Identificador,
                Marca = Marca,
                NombreProducto = NombreProducto,
                Precio = Precio,
                Foto = Foto
            };

            await _productoApiService.EditarProducto(id, Articulo);
            await IrADetalleProducto(Identificador);
            await Shell.Current.DisplayAlert("Info", _productoApiService.MensajeEstado, "ok");
            await DatosEntry();
            EstaHabiltado = false;

        }

        [RelayCommand]
        async Task EliminarProducto(int id)
        {
            if (id == 0) return;

            bool result = await Shell.Current.DisplayAlert("Confirmación", "¿Está seguro de que desea continuar?", "Sí", "No");

            if (result == true)
            {
                await _productoApiService.EliminarProducto(id);
                await Shell.Current.DisplayAlert("Info", _productoApiService.MensajeEstado, "ok");
            }
            else
            {
                return;
            }

            await IrADetalleProducto(Identificador);

        }

        [RelayCommand]
        async Task<int> AgregarProductoCarrito()
        {
            await Shell.Current.DisplayAlert("Informativo", "Articulo agregado", "ok");
            return Carrito = +1;
        }

        [RelayCommand]
        async Task IrAListadoProductos(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(ListadoProductoPage)}");
        }

        public async Task DatosEntry()
        {
            if ((string.IsNullOrEmpty(Marca) || string.IsNullOrEmpty(Precio) || string.IsNullOrEmpty(NombreProducto)))
            {
                Articulo = await App._productoApi.ObtenrPorducto(Identificador);
                Marca = Articulo.Marca;
                NombreProducto = Articulo.NombreProducto;
                Precio = Articulo.Precio;
                Foto = Articulo.Foto;
            }
            else
            {
                NombreProducto = string.Empty;
                Marca = string.Empty;
                Precio = string.Empty;
                Foto = string.Empty;
            }

        }

        [RelayCommand]
        async Task HailitarEntry()
        {
            EstaHabiltado = true;

            await DatosEntry();
        }

        async Task IrADetalleProducto(int id)
        {
            if (id == 0) return;
            /*nameof () permite poner un nombre el cual se puede cambiar en xaml y cambiaria tambien autoamticamente aqui
                        await Shell.Current.GoToAsync(toma parametos que son) DetallesProductoPage, , diccionario le enviamos un diccionario de objetos
                        vamos a otra pagina llamada DetallesProductoPage, true para animacion
                        new Dictionary creamos un diccionario de objetos y enviamos como parametro el producto*/
            if (App.InfoUsuario.TipoDeRol() == "Administrador")
            {
                await Shell.Current.GoToAsync($"{nameof(DetalleProductoAdminPage)}?Id={id}", true);
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(DetalleProductoUserPage)}?Id={id}", true);
            }

        }
    }
}
