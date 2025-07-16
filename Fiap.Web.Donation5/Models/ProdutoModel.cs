using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation5.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O campo nome é requerido")]
        [StringLength(50)]
        public string NomeProduto  { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage = "A descrição é requerida")]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        public string SugestaoTroca { get; set; }


        public bool Disponivel { get; set; } = true;

        [Required]
        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }

        // FK Categoria (Categoria que o produto pertence)
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; } // FK - Navigation Property

        // FK Usuario (Usuário dono do produto)
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; } //FK - Navigation Property


    }
}
