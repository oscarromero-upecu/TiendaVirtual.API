using Microsoft.Extensions.Logging;
using Tienda_en_Linea.Services;
using Tienda_en_Linea.ViewModels.ModeloProductos;
using Tienda_en_Linea.ViewModels.ModeloUsuario;
using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Admin;
using Tienda_en_Linea.Views.Login_Sesion;
using Tienda_en_Linea.Views.User;

namespace Tienda_en_Linea;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var pathDb = Path.Combine(FileSystem.AppDataDirectory, "tienda.db");

        //AddSingleton representa el cliclo de vida del objeto
		//AddScope crea una instancia por cada request
		//AddTransient crea una instancia nueva cada vez que lo llamen
		//servicios
        builder.Services.AddSingleton(servicios => ActivatorUtilities.CreateInstance<ProductService>(servicios,pathDb));
        builder.Services.AddSingleton<ProductoApiService>();
        builder.Services.AddSingleton<LoginService>();

		//vistas modelo
        builder.Services.AddSingleton<ListPorductsViewModel>();
        builder.Services.AddSingleton<InicioViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<CerrarSesionViewModel>();
        builder.Services.AddTransient<DetalleProductoViewModel>();
        builder.Services.AddTransient<CrearCuentaViewModel>();

        //paginas
        builder.Services.AddSingleton<ListadoProductoPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<InicioPage>();
        builder.Services.AddTransient<CrearCuentaPage>();
        builder.Services.AddTransient<DetalleProductoAdminPage>();
        builder.Services.AddTransient<DetalleProductoUserPage>();
        builder.Services.AddTransient<AgregarProductoAdminPage>();
        builder.Services.AddTransient<CerrarSesionPage>();



		return builder.Build();
	}
}
