using Tienda.API.Modelos;
using Tienda.API.Modelos.DTO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
    o.AddPolicy("PermitirTodas", a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var pathDB = Path.Join("C:", "sqlite", "tienda.db");
var conexion = new SqliteConnection($"Data Source={pathDB}");
builder.Services.AddDbContext<ProductosDbContext>(o => o.UseSqlite(conexion));

//agregamos usuarios y roles
builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ProductosDbContext>();

//creamos autenticacion o validacion del token con bearer
//configura la autenticación en la aplicación. 
builder.Services.AddAuthentication(opciones =>
{//Se establece el esquema de autenticación predeterminado
    //lo que significa que el sistema de autenticación usará un esquema de autenticación basado en tokens JWT.
    opciones.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opciones.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer/*agrega un esquema de autenticación basado en tokens JWT a la aplicación*/
(opciones =>
{//Se configura la validación de los parámetros del token de seguridad y se establece la clave de firma para validar la autenticidad del token
    opciones.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["ConfiguracionJWT:Emisor"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["ConfiguracionJWT:Audiencia"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ConfiguracionJWT:Key"]!))
    };
});

//creamos la politica de autorizacion para todos los endPoint
builder.Services.AddAuthorization(opciones =>
{
    opciones.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("PermitirTodas");

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapGet("/productos", async (ProductosDbContext db) => await db.Productos.ToListAsync());
app.MapGet("/productos/{id}", async (int id, ProductosDbContext db) =>
    await db.Productos.FindAsync(id) is Producto producto ? Results.Ok(producto) : Results.NotFound()
);
app.MapPut("/productos/{id}", async (int id, Producto productoModificado, ProductosDbContext db) =>
{
    var producto = await db.Productos.FindAsync(id);
    if (producto == null) return Results.NotFound();

    producto.NombreProducto = productoModificado.NombreProducto;
    producto.Marca = productoModificado.Marca;
    producto.Precio = productoModificado.Precio;
    producto.Foto = productoModificado.Foto;
    await db.SaveChangesAsync();

    return Results.Ok();
});
app.MapDelete("/productos/{id}", async (int id, ProductosDbContext db) =>
{
    var producto = await db.Productos.FindAsync(id);
    if (producto == null) return Results.NotFound();
    db.Remove(producto);
    await db.SaveChangesAsync();

    return Results.Ok();
});
app.MapPost("/productos", async (Producto producto, ProductosDbContext db) =>
{
    await db.AddAsync(producto);
    await db.SaveChangesAsync();

    return Results.Created($"/productos/{producto.Id}", producto);
});

app.MapPost("/usuario", async (Producto producto, ProductosDbContext db) =>
{
    await db.AddAsync(producto);
    await db.SaveChangesAsync();

    return Results.Created($"/productos/{producto.Id}", producto);
});

//clase UserManager que utiliza el Entity es para manipular la autenticacion sin necedidad de utilizar el DBContext
app.MapPost("/login", async (LoginDTO loginDTO, UserManager<IdentityUser> _userManager) =>
{
    var usuario = await _userManager.FindByEmailAsync(loginDTO.Email);

    //Unauthorized: no esta autorizado
    if (usuario is null) return Results.Unauthorized();

    var loginValido = await _userManager.CheckPasswordAsync(usuario, loginDTO.Password);

    if (!loginValido) return Results.Unauthorized();

    //crea una clave simétrica de seguridad (SymmetricSecurityKey) que se utilizará para firmar y validar tokens JWT en la aplicación
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ConfiguracionJWT:Key"]!));

    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var roles = await _userManager.GetRolesAsync(usuario);

    var claims = await _userManager.GetClaimsAsync(usuario);

    var listaClaimsJWT = new List<Claim>
    {
        new Claim (JwtRegisteredClaimNames.Sub,usuario.Id),
        new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        new Claim (JwtRegisteredClaimNames.Email,usuario.Email!),
        new Claim ("Confirmado", usuario.EmailConfirmed.ToString())
    }.Union(claims)
    .Union(roles.Select(rol=> new Claim(ClaimTypes.Role, rol)));

    //creamos el token
    var securityToken = new JwtSecurityToken(
        issuer: builder.Configuration["ConfiguracionJWT:Emisor"],
        audience: builder.Configuration["ConfiguracionJWT:Audiencia"],
        claims: listaClaimsJWT,
        expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(builder.Configuration["ConfiguracionJWT:DuracionEnMinutos"])),
        signingCredentials: credenciales
        );

    var tokenAcceso = new JwtSecurityTokenHandler().WriteToken(securityToken);

    var respuesta = new RespuestaLoginDTO
    {
        Id = usuario.Id,
        Email = loginDTO.Email,
        Token = tokenAcceso
    };

    return Results.Ok(respuesta);

}).AllowAnonymous();//AllowAnonymous permite que los usuarios no autenticados puedan acceder.

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
