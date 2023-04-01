using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tienda_en_Linea.Models;
using Tienda_en_Linea.Views.Login_Sesion;

namespace Tienda_en_Linea.Services
{
    public class ProductoApiService
    {
        HttpClient _HttpClient;

        public string MensajeEstado { get; private set; }

        //generamos la direccion base
        public static string DireccionBase = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";

        public ProductoApiService()
        {
            //agregamos nuestra direccion base
            _HttpClient = new() { BaseAddress = new Uri(DireccionBase)};
        }

        public async Task< List<Producto>> ObtenrPorductos()
        {
            try
            {
                await InicializarTokenAutenticacion();
                var respuesta = await _HttpClient.GetStringAsync("/productos");

                return JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    MensajeEstado = "Sesion Caducada ....";
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
                    
                }
            }
            return null;
        }

        public async Task AgregarProducto (Producto producto)
        {
            try
            {
                await InicializarTokenAutenticacion();

                var respuesta = await _HttpClient.PostAsJsonAsync("/productos", producto);

                respuesta.EnsureSuccessStatusCode();

                MensajeEstado = "Ingreso Exitoso";
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    MensajeEstado = "Sesion Caducada ....";
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

                }
            }
        }

        internal async Task EliminarProducto(int id)
        {
            try
            {
                await InicializarTokenAutenticacion();

                var respuesta = await _HttpClient.DeleteAsync($"/productos/{id}");

                respuesta.EnsureSuccessStatusCode();

                MensajeEstado = "Eliminado";
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    MensajeEstado = "Sesion Caducada ....";
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

                }
            }
        }

        public async Task<Producto> ObtenrPorducto(int id)
        {
            try
            {

                await InicializarTokenAutenticacion();

                var respuesta = await _HttpClient.GetStringAsync($"/productos/{id}");

                return JsonConvert.DeserializeObject<Producto>(respuesta);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    MensajeEstado = "Sesion Caducada ....";
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

                }
            }
            return null;
        }

        public async Task EditarProducto(int id, Producto productomodificado)
        {
            try
            {
                await InicializarTokenAutenticacion();

                var respuesta = await _HttpClient.PutAsJsonAsync($"/productos/{id}", productomodificado);

                respuesta.EnsureSuccessStatusCode();

                MensajeEstado = "Auto editado";

            }
            catch (Exception e)
            {

                if (e.Message.Contains("401"))
                {
                    MensajeEstado = "Sesion Caducada ....";
                    await Shell.Current.GoToAsync($"{nameof(LoginPage)}");

                }
            }
        }


        private async Task InicializarTokenAutenticacion()
        {
            var token = await SecureStorage.GetAsync("token");
            //cabecera request
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

    }
}

