using Aula03.RazorPages.Models;

namespace Aula03.RazorPages.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Feedbacks!.Any())
            {
                return;
            }

            var feedbacks = new FeedbackModel[]
            {
                    new FeedbackModel{
                    NomeCliente = "Maria dos Santos",
                    EmailCliente = "mariadossantos@gmail.com",
                    DataFeedback = DateTime.Now,
                    Comentario = "Muito interessante, voltarei sempre :)",
                    Avaliacao = 5
                },
            };

            context.AddRange(feedbacks);
            context.SaveChanges();
        }
    }
}