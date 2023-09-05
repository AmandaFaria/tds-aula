using Aula03.RazorPages.Data;
using Aula03.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula03.RazorPages.Pages.Feedbacks
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public FeedbackModel FeedbackModel { get; set; } = new();
        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedbackModel = await _context.Feedbacks.FirstOrDefaultAsync(feedback => feedback.IdFeedback == id);

            if (feedbackModel == null)
            {
                return NotFound();
            }

            FeedbackModel = feedbackModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var feedbackToUpdate = await _context.Feedbacks!.FindAsync(id);

            if (feedbackToUpdate == null)
            {
                return NotFound();
            }

            feedbackToUpdate.NomeCliente = FeedbackModel.NomeCliente;
            feedbackToUpdate.EmailCliente = FeedbackModel.EmailCliente;
            feedbackToUpdate.DataFeedback = FeedbackModel.DataFeedback;
            feedbackToUpdate.Comentario = FeedbackModel.Comentario;
            feedbackToUpdate.Avaliacao = FeedbackModel.Avaliacao;

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Feedbacks/Index");
            }
            catch (DbUpdateException)
            {
                return Page();
            }
        }

    }
}