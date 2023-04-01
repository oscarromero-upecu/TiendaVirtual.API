using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Tienda_en_Linea.Models;
using Tienda_en_Linea.Services;
using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Admin;
using Tienda_en_Linea.Views.User;

namespace Tienda_en_Linea.ViewModels.ModeloProductos
{
    public partial class ListPorductsViewModel : BaseViewModels
    {
        //defaul esta en false
        [ObservableProperty]
        bool estaRefrescando;

        [ObservableProperty]
        int identificador;

        [ObservableProperty]
        string nombreProducto;
        [ObservableProperty]
        string marca;
        [ObservableProperty]
        string precio; 
        [ObservableProperty]
        string foto;

        public ObservableCollection<Producto> Productos { get; private set; } = new();

        private readonly ProductoApiService _productoApiService;

        public ListPorductsViewModel(ProductoApiService productoApiService)
        {
            Titulo = "Productos";

            _productoApiService = productoApiService;

           ObtenerListaProductos();
        }


        [RelayCommand]
        async Task ObtenerListaProductos()
        {
            if (EstaCargando) return;

            try
            {
                EstaCargando = true;

                if (Productos.Any())
                    Productos.Clear();

                var productos = await _productoApiService.ObtenrPorductos();

                foreach (var product in productos)
                {
                    Productos.Add(product);
                }


            }
            catch (Exception e)
            {

                Debug.WriteLine($"Existe un error al obtener los productos: {e.Message}");
                await Shell.Current.DisplayAlert("Ups", "No se pudo obtener la lista de productos", "Ok");
            
            }
            finally
            {
                EstaRefrescando = false;
                EstaCargando = false;
            }
        }

        [RelayCommand]
        async Task AgregarProducto()
        {
            if (string.IsNullOrEmpty(NombreProducto) || string.IsNullOrEmpty(Precio) || string.IsNullOrEmpty(Marca)|| string.IsNullOrEmpty(Foto))
            {
                await Shell.Current.DisplayAlert("Error", "Complete los campos", "ok");
                return;
            }

            var producto = new Producto
            {
                NombreProducto = NombreProducto,
                Precio = Precio,
                Marca = Marca,
                Foto = Foto,
            };

           
                await _productoApiService.AgregarProducto(producto);
                await Shell.Current.DisplayAlert("Info", _productoApiService.MensajeEstado, "ok");
          

            LimpiarCampos();

            await ObtenerListaProductos();
        }

       
       

        [RelayCommand]
        async Task IrADetalleProducto(int id)
        {
            if (id == 0) return;
            /*nameof () permite poner un nombre el cual se puede cambiar en xaml y cambiaria tambien autoamticamente aqui
                        await Shell.Current.GoToAsync(toma parametos que son) DetallesProductoPage, , diccionario le enviamos un diccionario de objetos
                        vamos a otra pagina llamada DetallesProductoPage, true para animacion
                        new Dictionary creamos un diccionario de objetos y enviamos como parametro el producto*/
           if(App.InfoUsuario.TipoDeRol() == "Administrador")
            {
                await Shell.Current.GoToAsync($"{nameof(DetalleProductoAdminPage)}?Id={id}", true);
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(DetalleProductoUserPage)}?Id={id}", true);
            }
           
        }

       

        public void LimpiarCampos()
        {
            NombreProducto = string.Empty;
            Marca = string.Empty;
            Precio = string.Empty;
            Foto = string.Empty;
        }
    }
}
