

using Newtonsoft.Json;
using System.Net.Http.Json;
using Tienda_en_Linea.Models.DTO;

namespace Tienda_en_Linea.Services
{
    public  class LoginService
    {
        HttpClient _httpClient;

        public static string DireccionBase = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";

        public string MensajeEstado {  get; private set; }

        public LoginService()
        {
            _httpClient = new() {BaseAddress = new Uri(DireccionBase) };
        }

        public async Task<RespuestaAutenticacion> Login (LoginModel loginModel)
        {
            try
            {
                var respuesta = await _httpClient.PostAsJsonAsync("/login", loginModel);
                respuesta.EnsureSuccessStatusCode();

                MensajeEstado = "Inicio de sesion exitoso";

                //convierte el json que recibe a una clase que la aplicacion entiende
                return JsonConvert.DeserializeObject<RespuestaAutenticacion>(await respuesta.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                MensajeEstado="Inicio de sesion fallido";
                return default;
            }
        }
    }
}
