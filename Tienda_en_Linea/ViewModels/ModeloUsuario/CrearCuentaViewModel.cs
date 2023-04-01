using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tienda_en_Linea.Models;

namespace Tienda_en_Linea.ViewModels.ModeloUsuario
{
    public partial class CrearCuentaViewModel : BaseViewModels
    {
        [ObservableProperty]
        string correo;
        [ObservableProperty]
        string password;

        public CrearCuentaViewModel() {}


        [RelayCommand]
        async Task CrearCuenta()
        {
            try
            {
                if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Password))
                {
                    await Shell.Current.DisplayAlert("Error", "Complete todos los campos", "ok");
                    return;
                }
                
                if (Password.Length < 9)
                {
                    var nuevoUsuario = new Usuario
                    {
                        Email = Correo,
                        Password = Password,
                        Token = "token"
                    };


                    await Shell.Current.GoToAsync("//InicioSesion");

                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Igrese maximo 8 caracteres", "ok");
                    return;
                }
            }
            catch (Exception)
            {

                await Shell.Current.DisplayAlert("Error", "Falla al crear cuenta", "ok");
                 LimpiarCampos();

            }

        }

        public void LimpiarCampos()
        {
            Correo = string.Empty;
            Password = string.Empty;
        }
    }
}
