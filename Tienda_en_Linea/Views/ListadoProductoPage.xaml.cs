using Tienda_en_Linea.ViewModels.ModeloProductos;
namespace Tienda_en_Linea.Views;

public partial class ListadoProductoPage : ContentPage
{

	public ListadoProductoPage(ListPorductsViewModel listPorductsViewModel)
	{
		InitializeComponent();

		BindingContext= listPorductsViewModel;
	}

}

