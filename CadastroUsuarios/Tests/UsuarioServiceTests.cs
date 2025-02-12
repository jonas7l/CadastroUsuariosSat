using CadastroUsuarios.Data;
using CadastroUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

public class UsuarioServiceTests
{
    private readonly ApplicationDbContext _context;

    public UsuarioServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;
        _context = new ApplicationDbContext(options);
    }

    //[Fact]
    //public void DeveCriarUsuario()
    //{
    //    var usuario = new Usuario { Nome = "Teste", Senha = "123456" };
    //    _context.Usuarios.Add(usuario);
    //    _context.SaveChanges();

    //    Assert.Single(_context.Usuarios);
    //}
}
