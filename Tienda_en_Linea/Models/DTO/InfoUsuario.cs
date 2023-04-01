namespace Tienda_en_Linea.Models.DTO
{
    public class InfoUsuario
    {
        public string NombreUsuario { get; set; }
        public string Rol {get; set; }

        public string TipoDeRol()
        {
            string rolActual = Rol == "Administrador" ? "Administrador" : "Usuario";
            return rolActual;
        }
    }
}
