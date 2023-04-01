using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tienda_en_Linea.Helpers;
using Tienda_en_Linea.Models.DTO;
using Tienda_en_Linea.Services;
using Tienda_en_Linea.Views;

namespace Tienda_en_Linea.ViewModels.ModeloUsuario
{
    public partial class LoginViewModel : BaseViewModels
    {
        [ObservableProperty]
        string correo;  
        [ObservableProperty]
        string clave;

        private readonly LoginService _loginService;
        

        public LoginViewModel(LoginService loginService)
        {
            _loginService = loginService;   
        }

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Clave))
            {
                await MensajeLogin("Usuario o Password incorrectos");
                return;
            }
            else
            {
                //llmara a la API

                var loginModel = new LoginModel
                {
                    Email = Correo,
                    Password = Clave
                };

                var respuestaAutenticacion = await _loginService.Login(loginModel);


                if (!string.IsNullOrEmpty(respuestaAutenticacion.Token))
                {
                    await SecureStorage.SetAsync("token", respuestaAutenticacion.Token);

                    //convertir el string en Jwt
                    var tokenJson = new JwtSecurityTokenHandler().ReadJwtToken(respuestaAutenticacion.Token);

                    //obtener el valor de claim de rol
                    var rol = tokenJson.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role)).Value;

                    App.InfoUsuario = new InfoUsuario
                    {
                        NombreUsuario = Correo,
                        Rol = rol
                    };

                    ConstructorMenu.ContruirMenu();

                    await App._productoApi.ObtenrPorductos();


                    await Shell.Current.GoToAsync($"{nameof(ListadoProductoPage)}");

                    LimpiarCampos();
                };
                

            }


        }

        private async Task MensajeLogin(string mensaje)
        {
            await Shell.Current.DisplayAlert("Informativo", mensaje, "ok");

            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            Clave = string.Empty;
        }

    }
}
