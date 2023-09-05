using Aula03.RazorPages.Data;
using Aula03.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula03.RazorPages.Pages.Feedbacks
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public FeedbackModel FeedbackModel { get; set; } = new();
        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            try
            {
                _context.Add(FeedbackModel);
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