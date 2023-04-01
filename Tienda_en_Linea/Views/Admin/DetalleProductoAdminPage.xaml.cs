using Tienda_en_Linea.ViewModels.ModeloProductos;

namespace Tienda_en_Linea.Views.Admin;

public partial class DetalleProductoAdminPage : ContentPage
{
     public DetalleProductoAdminPage(DetalleProductoViewModel detalleProductoViewModel)
	{
		InitializeComponent();
		BindingContext = detalleProductoViewModel;
	}
}