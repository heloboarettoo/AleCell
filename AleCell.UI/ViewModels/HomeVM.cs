using AleCell.UI.DTOs;

namespace AleCell.UI.ViewModels;

public class HomeVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> ProdutosDestaque { get; set; } = new();
}
