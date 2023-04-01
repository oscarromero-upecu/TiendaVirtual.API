using Tienda_en_Linea.Controles;
using Tienda_en_Linea.Views;
using Tienda_en_Linea.Views.Admin;
using Tienda_en_Linea.Views.Login_Sesion;

namespace Tienda_en_Linea.Helpers
{
    public static class ConstructorMenu
    {
        public static void ContruirMenu()
        {
            Shell.Current.Items.Clear();

            Shell.Current.FlyoutHeader = new CabeceraFlyout();

            var rol = App.InfoUsuario.Rol;

            if (rol.Equals("Administrador"))
            {
                var itemFlayout = new FlyoutItem()
                {
                    Title = "Administradcion Productos",
                    Route = nameof(ListadoProductoPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Icon ="admin.png",
                            Title = "Consolidado",
                            ContentTemplate = new DataTemplate(typeof(ListadoProductoPage)),
                        },
                        new ShellContent
                        {
                            Icon ="admin.png",
                            Title = "Agregar nuevo",
                            ContentTemplate = new DataTemplate(typeof(AgregarProductoAdminPage)),
                        },
                    },
                    
                };

                if (!Shell.Current.Items.Contains(itemFlayout))
                {
                    Shell.Current.Items.Add(itemFlayout);
                }
            }
            else if (rol.Equals("Usuario"))
            {
                var itemFlayout = new FlyoutItem()
                {
                    Title = "Menu",
                    Route = nameof(ListadoProductoPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Icon = "user.png",
                            Title = "Productos",
                            ContentTemplate = new DataTemplate(typeof(ListadoProductoPage)),
                        },
                        new ShellContent
                        {
                            Icon = "user.png",
                            Title = "Por marca",
                            ContentTemplate = new DataTemplate(typeof(ListadoProductoPage)),
                        }, 
                        new ShellContent
                        {
                            Icon = "user.png",
                            Title = "Por precio",
                            ContentTemplate = new DataTemplate(typeof(ListadoProductoPage)),
                        },

                    }
                };
                if (!Shell.Current.Items.Contains(itemFlayout))
                {
                    Shell.Current.Items.Add(itemFlayout);
                }
            }

            var flyoutCerrarSesion = new FlyoutItem()
            {
                Title = "CerrarSesion",
                Route = nameof(CerrarSesionPage),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
                Items =
                {
                    new ShellContent
                    {
                        Icon = "salir.jpg",
                        Title = "Cerrar Sesion",
                        ContentTemplate = new DataTemplate(typeof(CerrarSesionPage))
                    }
                }
            };

            if (!Shell.Current.Items.Contains(flyoutCerrarSesion))
            {
                Shell.Current.Items.Add(flyoutCerrarSesion);
            }
        }
    }
}
