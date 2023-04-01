using Tienda_en_Linea.Models.DTO;
using Tienda_en_Linea.Services;

namespace Tienda_en_Linea;

public partial class App : Application
{
	public static ProductoApiService _productoApi { get;private set; }
	public static InfoUsuario InfoUsuario;

	public App(ProductoApiService productoApi)
	{
		InitializeComponent();

		MainPage = new AppShell();
		_productoApi= productoApi;
	}
}
