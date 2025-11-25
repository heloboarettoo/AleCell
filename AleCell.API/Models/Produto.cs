using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AleCell.API.Models;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categoria Categoria {get; set; }

   [Required(ErrorMessage ="O nome é obrigatório")]
   [StringLength(100)] 
    public string Nome { get; set; }

    [StringLength(3000)]
    public string Descricao { get; set; }

    public int Qtde { get; set; }
    
    [Column(TypeName = "double(12,2)")]
    public decimal ValorCusto { get; set; }

    [Column(TypeName = "double(12,2)")]
    public decimal ValorVenda { get; set; }

    public bool Destaque { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

}