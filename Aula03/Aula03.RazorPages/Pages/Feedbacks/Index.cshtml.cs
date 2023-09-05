using Aula03.RazorPages.Data;
using Aula03.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula03.RazorPages.Pages.Feedbacks
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<FeedbackModel> FeedbackList { get; set; } = new();
        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            FeedbackList = await _context.Feedbacks!.ToListAsync();
            return Page();
        }
    }
}