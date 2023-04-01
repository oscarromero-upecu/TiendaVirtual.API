using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tienda.API.Modelos
{
    public class ProductosDbContext : IdentityDbContext
    {
        public ProductosDbContext(DbContextOptions<ProductosDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasData(
                new List<Producto>
                {
                    new Producto{ Id = 1, NombreProducto = "Camisa", Marca = "ToTo", Precio  ="$ 50", Foto="https://i.ibb.co/VN7hJHG/camisa.png" },
                    new Producto{ Id = 2, NombreProducto = "Zapatilla", Marca = "Nike", Precio  = "$ 120", Foto = "https://i.ibb.co/mT8Cq6t/pantalon.pngk"},
                    new Producto{ Id = 3, NombreProducto = "Sueter", Marca = "Zhara", Precio  = "$ 200", Foto = "https://i.ibb.co/0n11K12/sueter.png"},
                    new Producto{ Id = 4, NombreProducto = "Pantalon", Marca = "Pull&Bear", Precio  ="$ 100", Foto = "https://i.ibb.co/m5BvxBb/Znike.png" },
                                      
                });

            //generamos el rol por tipo de usuario
            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "6a6a7fcc-37ad-40ab-85f6-e080521661b5",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                },
                 new IdentityRole
                {
                    Id = "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a",
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                }
            });

            //se debe guardar la contrase;a encriptada
            //crea una instancia de la clase PasswordHasher para el tipo IdentityUser. La instancia hasher se puede utilizar para generar y verificar contraseñas hash para usuarios
            var hasher = new PasswordHasher<IdentityUser>();

            //generamos los usuarios con su hasher
            modelBuilder.Entity<IdentityUser>().HasData(new List<IdentityUser>
            {
                new IdentityUser
                {
                     Id = "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin.123"),
                    EmailConfirmed = true,
                },
                 new IdentityUser
                {
                    Id = "2ef59268-57d4-4933-9ed5-69d7e782256d",
                    Email = "usuario@localhost.com",
                    NormalizedEmail = "USUARIO@LOCALHOST.COM",
                    UserName = "usuario@localhost.com",
                    NormalizedUserName = "USUARIO@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "User.123"),
                    EmailConfirmed = true,
                }
            });

            //relacionamos el usaurio con su rol
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = "6a6a7fcc-37ad-40ab-85f6-e080521661b5",
                    UserId = "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f"
                },
                 new IdentityUserRole<string>
                {
                    RoleId = "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a",
                    UserId = "2ef59268-57d4-4933-9ed5-69d7e782256d"
                }

            });
        }
    }
}