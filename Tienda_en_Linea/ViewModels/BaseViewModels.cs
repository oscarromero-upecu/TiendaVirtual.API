using CommunityToolkit.Mvvm.ComponentModel;
using Tienda_en_Linea.ViewModels.ModeloProductos;

namespace Tienda_en_Linea.ViewModels
{
    public abstract partial class BaseViewModels : ObservableObject
    {
        [ObservableProperty]
        string titulo;

        [ObservableProperty]
        // cada vez que el valor cambie esta notificando 
        [NotifyPropertyChangedFor(nameof(NoEstaCargando))]
        bool estaCargando;

        public bool NoEstaCargando => !EstaCargando;

        //establece variable con la conexion actual  a internet
        NetworkAccess _conexionActual = Connectivity.Current.NetworkAccess;

        public bool ConexionAinternet()
        {
            return _conexionActual == NetworkAccess.Internet;
        }

        
    }
}
