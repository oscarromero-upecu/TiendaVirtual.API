using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Admin;
using Tienda_en_Linea.Views.Login_Sesion;
using Tienda_en_Linea.Views.User;

namespace Tienda_en_Linea;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //accedemos a la ruta de la pagina 
        Routing.RegisterRoute(nameof(ListadoProductoPage), typeof(ListadoProductoPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(CrearCuentaPage), typeof(CrearCuentaPage));
        Routing.RegisterRoute(nameof(CerrarSesionPage), typeof(CerrarSesionPage));
        Routing.RegisterRoute(nameof(AgregarProductoAdminPage), typeof(AgregarProductoAdminPage));
        Routing.RegisterRoute(nameof(DetalleProductoAdminPage), typeof(DetalleProductoAdminPage));
        Routing.RegisterRoute(nameof(DetalleProductoUserPage), typeof(DetalleProductoUserPage));
	}
}
