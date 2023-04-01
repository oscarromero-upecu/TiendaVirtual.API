namespace Tienda_en_Linea.Controles;

public partial class CabeceraFlyout : StackLayout
{
	public CabeceraFlyout()
	{
		InitializeComponent();
		AsignarValores();
	}

    private void AsignarValores()
    {
        if(App.InfoUsuario is not null)
		{
			lblNombreUsuario.Text = App.InfoUsuario.NombreUsuario;
			lblRol.Text = App.InfoUsuario.Rol;
		}
    }
}