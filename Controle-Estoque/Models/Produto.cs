using System.ComponentModel.DataAnnotations;

namespace Controle_Estoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço não pode ser negativo.")]
        public double Preco { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma categoria.")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}