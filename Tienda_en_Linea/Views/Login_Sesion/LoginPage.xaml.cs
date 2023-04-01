using Tienda_en_Linea.ViewModels.ModeloUsuario;

namespace Tienda_en_Linea.Views.Login_Sesion;

public partial class LoginPage : ContentPage
{

	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}

    private async void TapGestureRecognizer_Tapped_Para_CrearCuenta(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync($"{nameof(CrearCuentaPage)}");
    }
}