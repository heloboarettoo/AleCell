using AleCell.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AleCell.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    private const double V = 3.000;

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
                NormalizedEmail = "HELOOBOARETTOO@GMAIL.COM",
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
                Cor = " "
            },
            new Categoria() {
                Id = 2,
                Nome = "Xiaomi",
                Foto = "/img/categorias/2.jpg",
                Cor = " "
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
                Descricao = "256GB de armazenamento interno;\n" +
                "Tamanho da tela: 6,3 polegadas;\n" +
                "Câmera traseira: 48MP;\n" +
                "Câmera frontal: 18MP;\n" + 
                "Bateria de íon de lítio;\n" +
                "Com 5G",
                CategoriaId = 1,
                ValorVenda = 8798,
                Foto = "/img/Produtos/iphone-17.jpg",
                Qtde = 100,
                Destaque = true
            },
            new Produto() {
                Id = 2,
                Nome = "Iphone 17 pro max",
                Descricao = "256GB de armazenamento interno;\n" +
                "Tamanho da tela: 6,3 polegadas;\n" +
                "Câmera traseira: 48MP;\n" +
                "Câmera frontal: 18MP;\n" +
                "Bateria interna de íon de lítio;\n" +
                "Com 5G",
                CategoriaId = 1,
                ValorVenda = 10450,
                Foto = "/img/Produtos/iphone-17pro.jpg",
                Qtde = 100,
                Destaque = true 
            },
            new Produto() {
                Id = 3,
                Nome = "Iphone Air",
                Descricao = "512GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,5 polegadas;\n" +
                "Câmera traseira: 48MP;\n" +
                "Câmera frontal: 18MP;\n" +
                "Bateria interna de íon de lítio;\n" +
                "Com 5G",
                CategoriaId = 1,
                ValorVenda = 11400,
                Foto = "/img/Produtos/iphone-air.jpg",
                Qtde = 100
            },
            new Produto() {
                Id = 4,
                Nome = "Iphone 16",
                Descricao =  "128GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,1 polegadas;\n" +
                "Câmera traseira: 48MP;\n" +
                "Câmera frontal: 12MP;\n" +
                "Bateria Interna Recarregável de íon de lítios;\n" +
                "Com 5G",
                CategoriaId = 1,
                ValorVenda = 4780,
                Foto = "/img/Produtos/iphone16.jpg",
                Qtde = 100
            },
            new Produto() {
                Id = 5,
                Nome = "Iphone 16e",
                Descricao = "128GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,1 polegadas;\n" +
                "Câmera traseira: 48MP;\n" +
                "Câmera frontal: 12MP;\n" +
                "Bateria Interna Recarregável de íon de lítios;\n" +
                "Com 5G",
                CategoriaId = 1,
                ValorVenda = 3494,
                Foto = "/img/Produtos/iphone16e.jpg",
                Qtde = 100
            },
            new Produto() {
                Id = 6,
                Nome = "Xiaomi 15T",
                Descricao = "512GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,8 polegadas;\n" +
                "Câmera traseira: 50MP;\n" +
                "Câmera frontal: 32MP;\n" +
                "Bateria 5500 mAh;\n" +
                "12 GB de memória RAM",
                CategoriaId = 2,
                ValorVenda = 4950,
                Foto = "/img/Produtos/xiaomi15T.jpg",
                Qtde = 100
            },
            new Produto() {
                Id = 7,
                Nome = "Xiaomi 17 pro",
                Descricao = "512GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,9 polegadas;\n" +
                "Câmera traseira: 50MP;\n" +
                "Câmera frontal: 50 MP;",
                CategoriaId = 2,
                ValorVenda = 11799,
                Foto = "/img/Produtos/Xiaomi17ProMax.jpg",
                Qtde = 100,
                Destaque = true 

            },
            new Produto() {
                Id = 8,
                Nome = "XRedmi 15C",
                Descricao = "256GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,9 polegadas;\n" +
                "Câmera traseira: 50MP;\n" +
                "Câmera frontal: 8MP;\n" +
                "Bateria 6000 mAh;\n" +
                "8GB de memória RAM",
                CategoriaId = 2,
                ValorVenda = 1450,
                Foto = "/img/Produtos/Xredmi15C.jpg",
                Qtde = 100
            },
             new Produto() {
                Id = 9,
                Nome = "Redmi 14 Pro",
                Descricao = "256GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,67 polegadas;\n" +
                "Câmera traseira: 200MP;\n" +
                "Câmera frontal: 32MP;\n" +
                "Bateria 5500mAh;\n" +
                "8GB de memória RAM",
                CategoriaId = 2,
                ValorVenda = 1752,
                Foto = "/img/Produtos/redmi14pro.jpg",
                Qtde = 100
            },
             new Produto() {
                Id = 10,
                Nome = "Poco x7 Pro",
                Descricao =  "256GB de armazenamento interno;\n" +
                "Tamanho da Tela: 6,67 polegadas;\n" +
                "Câmera traseira: 50MP;\n" +
                "Câmera frontal: 20MP;\n" +
                "Bateria 6000mAh;\n" +
                "8GB de memória RAM",
                CategoriaId = 2,
                ValorVenda = 2220,
                Foto = "/img/Produtos/pocox7pro.jpg",
                Qtde = 100
            },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}