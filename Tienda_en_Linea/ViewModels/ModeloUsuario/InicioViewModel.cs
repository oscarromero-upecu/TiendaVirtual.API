using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tienda_en_Linea.Helpers;
using Tienda_en_Linea.Models.DTO;
using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Login_Sesion;

namespace Tienda_en_Linea.ViewModels.ModeloUsuario
{
    public partial class InicioViewModel : BaseViewModels
    {
        public InicioViewModel()
        {
            ValidarUsuario();
            Temporizador();
        }

        //valida si existe un token almacenado en la aplicacion del usuario
        private async void ValidarUsuario()
        {
            //guardamos el token en un storage seguro
            var token = await SecureStorage.GetAsync("token");

            if (string.IsNullOrEmpty(token))
            {
                IraPaginaLogin();
            }
            else
            {
                var tokenJson = new JwtSecurityTokenHandler().ReadJwtToken(token);

                if (tokenJson.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove("token");
                    IraPaginaLogin();
                }
                else
                {
                    var rol = tokenJson.Claims.FirstOrDefault(r => r.Type.Equals(ClaimTypes.Role))?.Value;
                    var usuario = tokenJson.Claims.FirstOrDefault(u => u.Type.Equals(JwtRegisteredClaimNames.Email))?.Value;

                    App.InfoUsuario = new InfoUsuario
                    {
                        NombreUsuario = usuario,
                        Rol = rol
                    };

                    ConstructorMenu.ContruirMenu();

                    IraPaginaPrincipal();
                }

              
            }
        }

        private async void IraPaginaPrincipal()
        {
            await Shell.Current.GoToAsync(nameof(ListadoProductoPage));
        }

        private async void IraPaginaLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }


        public bool IsLoading
        {
            get { return EstaCargando; }
            set
            {
                EstaCargando = value;
                new ActivityIndicator
                {
                    IsRunning = value,
                    IsEnabled = value
                };

            }
        }

        private async void Temporizador()
        {
            IsLoading = true;
            await Task.Delay(3000);
            IsLoading = false;
        }
    }
}