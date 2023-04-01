using Tienda_en_Linea.ViewModels;
using Tienda_en_Linea.ViewModels.ModeloUsuario;

namespace Tienda_en_Linea.Views.Login_Sesion;

public partial class CrearCuentaPage : ContentPage
{
	public CrearCuentaPage(CrearCuentaViewModel crearCuentaViewModel)
	{
		InitializeComponent();

        BindingContext = crearCuentaViewModel;
	}
    private async void TapGestureRecognizer_Tapped_Para_InicioSesion(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }
}