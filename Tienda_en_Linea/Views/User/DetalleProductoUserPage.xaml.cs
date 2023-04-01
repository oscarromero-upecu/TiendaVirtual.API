using Tienda_en_Linea.ViewModels.ModeloProductos;

namespace Tienda_en_Linea.Views.User;

public partial class DetalleProductoUserPage : ContentPage
{
     public DetalleProductoUserPage(DetalleProductoViewModel detalleProductoViewModel)
	{
		InitializeComponent();
		BindingContext = detalleProductoViewModel;
	}
}