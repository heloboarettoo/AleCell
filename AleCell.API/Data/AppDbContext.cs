using AleCell.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AleCell.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "helooboarettoo@gmail.com",
                NormalizedEmail = "HELOOBOARETTO@GMAIL.COM",
                UserName = "heloboaretto",
                NormalizedUserName = "HELOBOARETTO",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Heloísa Boaretto",
                DataNascimento = DateTime.Parse("24/07/2008"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
             new Categoria() {
                Id = 1,
                Nome = "Iphone",
                Foto = "/img/categorias/1.jpg",
                Cor = ""
            },
            new Categoria() {
                Id = 2,
                Nome = "Xiaomi",
                Foto = "/img/categorias/2.jpg"
            },
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto() {
                Id = 1,
                Nome = "Iphone 17",
                Descricao = " ",
                CategoriaId = 1,
                Foto = "/img/iphone-17/.jpg"
            },
            new Produto() {
                Id = 2,
                Nome = "Iphone 17 pro max",
                Descricao = " ",
                CategoriaId = 1,
                Foto = "/img/iphone-17pro/.jpg"
            },
            new Produto() {
                Id = 3,
                Nome = "Iphone Air",
                Descricao = " ",
                CategoriaId = 1,
                Foto = "/img/iphone-air/.jpg"
            },
            new Produto() {
                Id = 4,
                Nome = "Iphone 16",
                Descricao = " ",
                CategoriaId = 1,
                Foto = "/img/iphone16/.jpg"
            },
            new Produto() {
                Id = 5,
                Nome = "Iphone 16e",
                Descricao = " ",
                CategoriaId = 1,
                Foto = "/img/iphone16e/.jpg"
            },
            new Produto() {
                Id = 6,
                Nome = "Xiaomi 15T",
                Descricao = " ",
                CategoriaId = 2,
                Foto = "/img/xiaomi15T/.jpg"
            },
            new Produto() {
                Id = 7,
                Nome = "Xiaomi 17 pro",
                Descricao = " ",
                CategoriaId = 2,
                Foto = "/img/xiaomi17pro/.jpg"
            },
            new Produto() {
                Id = 8,
                Nome = "XRedmi 15C",
                Descricao = " ",
                CategoriaId = 2,
                Foto = "/img/Xredmi15C/.jpg"
            },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}