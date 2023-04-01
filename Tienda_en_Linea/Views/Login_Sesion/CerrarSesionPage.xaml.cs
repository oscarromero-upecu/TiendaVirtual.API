using Tienda_en_Linea.ViewModels.ModeloUsuario;

namespace Tienda_en_Linea.Views.Login_Sesion;

public partial class CerrarSesionPage : ContentPage
{
	public CerrarSesionPage(CerrarSesionViewModel cerrarSesionViewModel)
	{
        InitializeComponent();

        BindingContext = cerrarSesionViewModel;
	}

    
}