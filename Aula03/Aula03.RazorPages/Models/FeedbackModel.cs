using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula03.RazorPages.Models
{
    public class FeedbackModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdFeedback { get; set; }
        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public DateTime DataFeedback { get; set; }
        [Required(ErrorMessage = "Comentário é obrigatório")]
        public string? Comentario { get; set; }
        [Required(ErrorMessage = "Avaliação é obrigatória")]
        public int Avaliacao { get; set; }
    }
}