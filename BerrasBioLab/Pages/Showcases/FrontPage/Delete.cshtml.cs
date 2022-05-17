using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.FrontPage
{
    public class DeleteModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public DeleteModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Showcase Showcase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Showcase == null)
            {
                return NotFound();
            }

            var showcase = await _context.Showcase.FirstOrDefaultAsync(m => m.Id == id);

            if (showcase == null)
            {
                return NotFound();
            }
            else 
            {
                Showcase = showcase;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Showcase == null)
            {
                return NotFound();
            }
            var showcase = await _context.Showcase.FindAsync(id);

            if (showcase != null)
            {
                Showcase = showcase;
                _context.Showcase.Remove(Showcase);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
