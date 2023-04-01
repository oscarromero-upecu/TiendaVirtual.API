using Tienda_en_Linea.ViewModels;
using Tienda_en_Linea.ViewModels.ModeloProductos;

namespace Tienda_en_Linea.Views.Admin;

public partial class AgregarProductoAdminPage : ContentPage
{
	public AgregarProductoAdminPage(ListPorductsViewModel listPorductsViewModel)
	{
		InitializeComponent();

		BindingContext = listPorductsViewModel;
	}
}