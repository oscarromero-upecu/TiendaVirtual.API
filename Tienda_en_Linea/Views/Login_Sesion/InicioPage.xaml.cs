using Tienda_en_Linea.ViewModels.ModeloUsuario;

namespace Tienda_en_Linea.Views.Login_Sesion;

public partial class InicioPage : ContentPage
{
	public InicioPage(InicioViewModel inicioViewModel)
	{
		InitializeComponent();
      
		BindingContext = inicioViewModel;
	}

    
}