using CommunityToolkit.Mvvm.Input;
using Tienda_en_Linea.Views.Login_Sesion;

namespace Tienda_en_Linea.ViewModels.ModeloUsuario
{
    public partial class CerrarSesionViewModel:BaseViewModels
    {
        public CerrarSesionViewModel()
        {
            CerrarSesion();
            Temporizador();
        }

        [RelayCommand]
        async void CerrarSesion()
        {
            SecureStorage.Remove("token");
            App.InfoUsuario = null;
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
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
